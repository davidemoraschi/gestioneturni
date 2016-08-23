<%@ Page Language="VB" %>
<%@ import Namespace="System.Data" %>
<%@ import Namespace="System.Data.SqlClient" %>
<script runat="server">

    ' TODO: update the ConnectionString and Command values for your application
    
    Dim ConnectionString As String = ConfigurationSettings.AppSettings("ConnStr")
    Dim SelectCommand As String = "SELECT * from Itin"
    Dim isEditing As Boolean = False
    
    Sub Page_Load(Sender As Object, E As EventArgs)
    
        If Not Page.IsPostBack Then
    
            ' Databind the data grid on the first request only
            ' (on postback, bind only in editing, paging and sorting commands)
    
            BindGrid()
    
        End If
    
    End Sub
    
    ' ---------------------------------------------------------------
    '
    ' DataGrid Commands: Page, Sort, Edit, Update, Cancel, Delete
    '
    
    Sub DataGrid_ItemCommand(Sender As Object, E As DataGridCommandEventArgs)
    
        ' this event fires prior to all of the other commands
        ' use it to provide a more graceful transition out of edit mode
    
        CheckIsEditing(e.CommandName)
    
    End Sub
    
    Sub CheckIsEditing(commandName As String)
    
        If DataGrid1.EditItemIndex <> -1 Then
    
            ' we are currently editing a row
            If commandName <> "Cancel" And commandName <> "Update" Then
    
                ' user's edit changes (If any) will not be committed
                Message.Text = "Your changes have not been saved yet.  Please press update to save your changes, or cancel to discard your changes, before selecting another item."
                isEditing = True
    
            End If
    
        End If
    
    End Sub
    
    Sub DataGrid_Edit(Sender As Object, E As DataGridCommandEventArgs)
    
        ' turn on editing for the selected row
    
        If Not isEditing Then
    
            DataGrid1.EditItemIndex = e.Item.ItemIndex
            BindGrid()
    
        End If
    
    End Sub
    
    Sub DataGrid_Update(Sender As Object, E As DataGridCommandEventArgs)
    
        ' update the database with the new values
    
        ' get the edit text boxes
        Dim StartDate As String = CType(e.Item.Cells(2).Controls(0), TextBox).Text
        Dim StartTime As String = CType(e.Item.Cells(3).Controls(0), TextBox).Text
        Dim Venue As String = CType(e.Item.Cells(4).Controls(0), TextBox).Text
        Dim City As String = CType(e.Item.Cells(5).Controls(0), TextBox).Text
        Dim State As String = CType(e.Item.Cells(6).Controls(0), TextBox).Text
    
        ' TODO: update the Command value for your application
        Dim myConnection As New SqlConnection(ConnectionString)
        Dim UpdateCommand As SqlCommand = new SqlCommand()
        UpdateCommand.Connection = myConnection
    
        If AddingNew = True Then
            UpdateCommand.CommandText = "INSERT INTO Itin (StartDate, StartTime,Venue, City, State ) VALUES (@StartDate, @StartTime, @Venue, @City, @State )"
        Else
            UpdateCommand.CommandText = "UPDATE authors SET au_lname = @au_lname, au_fname = @au_fname WHERE au_id = @au_id"
        End If
    
        UpdateCommand.Parameters.Add("@StartDate", SqlDbType.VarChar, 11).Value = StartDate
        UpdateCommand.Parameters.Add("@StartTime", SqlDbType.VarChar, 40).Value = StartTime
        UpdateCommand.Parameters.Add("@Venue", SqlDbType.VarChar, 20).Value = Venue
        UpdateCommand.Parameters.Add("@City", SqlDbType.VarChar, 40).Value = City
        UpdateCommand.Parameters.Add("@State", SqlDbType.VarChar, 20).Value = State
    
        ' execute the command
        Try
            myConnection.Open()
            UpdateCommand.ExecuteNonQuery()
    
        Catch ex as Exception
            Message.Text = ex.ToString()
    
        Finally
            myConnection.Close()
    
        End Try
    
        ' Resort the grid for new records
        If AddingNew = True Then
            DataGrid1.CurrentPageIndex = 0
            AddingNew = false
        End If
    
        ' rebind the grid
        DataGrid1.EditItemIndex = -1
        BindGrid()
    
    End Sub
    
    Sub DataGrid_Cancel(Sender As Object, E As DataGridCommandEventArgs)
    
        ' cancel editing
    
        DataGrid1.EditItemIndex = -1
        BindGrid()
    
        AddingNew = False
    
    End Sub
    
    Sub DataGrid_Delete(Sender As Object, E As DataGridCommandEventArgs)
    
        ' delete the selected row
    
        If Not isEditing Then
    
            ' the key value for this row is in the DataKeys collection
            Dim keyValue As String = CStr(DataGrid1.DataKeys(e.Item.ItemIndex))
    
            ' TODO: update the Command value for your application
            Dim myConnection As New SqlConnection(ConnectionString)
            Dim DeleteCommand As New SqlCommand("DELETE from authors where au_id='" & keyValue & "'", myConnection)
    
            ' execute the command
            myConnection.Open()
            DeleteCommand.ExecuteNonQuery()
            myConnection.Close()
    
            ' rebind the grid
            DataGrid1.CurrentPageIndex = 0
            DataGrid1.EditItemIndex = -1
            BindGrid()
    
        End If
    
    End Sub
    
    Sub DataGrid_Page(Sender As Object, E As DataGridPageChangedEventArgs)
    
        ' display a new page of data
    
        If Not isEditing Then
    
            DataGrid1.EditItemIndex = -1
            DataGrid1.CurrentPageIndex = e.NewPageIndex
            BindGrid()
    
        End If
    
    End Sub
    
    Sub AddNew_Click(Sender As Object, E As EventArgs)
    
        ' add a new row to the end of the data, and set editing mode 'on'
    
        CheckIsEditing("")
    
        If Not isEditing = True Then
    
            ' set the flag so we know to do an insert at Update time
            AddingNew = True
    
            ' add new row to the end of the dataset after binding
    
            ' first get the data
            Dim myConnection As New SqlConnection(ConnectionString)
            Dim myCommand As New SqlDataAdapter("SELECT StartDate, StartTime,Venue, City, State from Itin", myConnection)
    
            Dim ds As New DataSet()
            myCommand.Fill(ds)
    
            ' add a new blank row to the end of the data
            Dim rowValues As Object() = {Today, Now, "", "", ""}
            ds.Tables(0).Rows.Add(rowValues)
    
            ' figure out the EditItemIndex, last record on last page
            Dim recordCount As Integer = ds.Tables(0).Rows.Count
    
            If recordCount > 1 Then
    
                recordCount -= 1
                DataGrid1.CurrentPageIndex = recordCount \ DataGrid1.PageSize
                DataGrid1.EditItemIndex = recordCount Mod DataGrid1.PageSize
    
            End If
    
            ' databind
            DataGrid1.DataSource = ds
            DataGrid1.DataBind()
    
        End If
    
    
    End Sub
    
    ' ---------------------------------------------------------------
    '
    ' Helpers Methods:
    '
    
    ' property to keep track of whether we are adding a new record,
    ' and save it in viewstate between postbacks
    
    Property AddingNew() As Boolean
    
        Get
            Dim o As Object = ViewState("AddingNew")
            If o Is Nothing Then
                Return False
            End If
            Return CBool(o)
        End Get
    
        Set(ByVal Value As Boolean)
            ViewState("AddingNew") = Value
        End Set
    
    End Property
    
    Sub BindGrid()
    
        Dim myConnection As New SqlConnection(ConnectionString)
        Dim myCommand As New SqlDataAdapter(SelectCommand, myConnection)
    
        Dim ds As New DataSet()
        myCommand.Fill(ds)
    
        DataGrid1.DataSource = ds
        DataGrid1.DataBind()
    
    End Sub

</script>
<html>
<head>
</head>
<body style="FONT-FAMILY: arial">
    <h2>Editable Data Grid 
    </h2>
    <hr size="1" />
    <form runat="server">
        <asp:datagrid id="DataGrid1" runat="server" width="80%" CellPadding="4" BackColor="White" OnPageIndexChanged="DataGrid_Page" PageSize="6" AllowPaging="True" OnDeleteCommand="DataGrid_Delete" OnCancelCommand="DataGrid_Cancel" OnUpdateCommand="DataGrid_Update" OnEditCommand="DataGrid_Edit" OnItemCommand="DataGrid_ItemCommand" Font-Size="X-Small" BorderStyle="None" BorderWidth="1px" BorderColor="#CC9966" Font-Names="Verdana">
            <FooterStyle forecolor="#330099" backcolor="#FFFFCC"></FooterStyle>
            <HeaderStyle font-bold="True" forecolor="#FFFFCC" backcolor="#990000"></HeaderStyle>
            <PagerStyle font-size="Smaller" horizontalalign="Center" forecolor="#330099" backcolor="#FFFFCC"></PagerStyle>
            <SelectedItemStyle font-bold="True" forecolor="#663399" backcolor="#FFCC66"></SelectedItemStyle>
            <ItemStyle forecolor="#330099" backcolor="White"></ItemStyle>
            <Columns>
                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
                    <ItemStyle font-size="Smaller" width="10%"></ItemStyle>
                </asp:EditCommandColumn>
                <asp:ButtonColumn Text="Delete" CommandName="Delete">
                    <ItemStyle font-size="Smaller" width="10%"></ItemStyle>
                </asp:ButtonColumn>
            </Columns>
        </asp:datagrid>
        <br />
        <asp:LinkButton id="LinkButton1" onclick="AddNew_Click" runat="server" Font-Size="smaller" Text="Add new item"></asp:LinkButton>
        <br />
        <br />
        <asp:Label id="Message" runat="server" width="80%" ForeColor="red" EnableViewState="false"></asp:Label>
    </form>
</body>
</html>
