Imports System.Data
Imports System.Data.SqlClient

Public Class DataInsert

    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Message As System.Web.UI.WebControls.Label
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim ConnectionString As String = ConfigurationSettings.AppSettings("ConnStr")
    Dim SelectCommand As String = "select CONVERT(char(12), StartDate,105)  DATA, CONVERT(char(5), StartTime,108) ORA, Venue as Cliente, State as Progetto, Country as Sito, ItinID as ID from Itin"
    Dim isEditing As Boolean = False

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            BindGrid()
        End If
    End Sub

    Sub DataGrid_ItemCommand(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)

        CheckIsEditing(E.CommandName)

    End Sub

    Sub CheckIsEditing(ByVal commandName As String)

        If DataGrid1.EditItemIndex <> -1 Then
            If commandName <> "Cancel" And commandName <> "Update" Then
                Message.Text = "Your changes have not been saved yet.  Please press update to save your changes, or cancel to discard your changes, before selecting another item."
                isEditing = True
            End If
        End If
    End Sub

    Sub DataGrid_Edit(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)

        If Not isEditing Then
            DataGrid1.EditItemIndex = E.Item.ItemIndex
            BindGrid()
        End If

    End Sub

    Sub DataGrid_Update(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)

        Dim StartDate As Date = CDate(CType(E.Item.Cells(2).Controls(0), TextBox).Text)
        Dim StartTime As Date = CDate(CType(E.Item.Cells(2).Controls(0), TextBox).Text & " " & CType(E.Item.Cells(3).Controls(0), TextBox).Text)
        Dim Venue As String = CType(E.Item.Cells(4).Controls(0), TextBox).Text
        Dim State As String = CType(E.Item.Cells(5).Controls(0), TextBox).Text
        Dim Country As String = CType(E.Item.Cells(6).Controls(0), TextBox).Text
        Dim ItinID As Integer = CType(E.Item.Cells(7).Controls(0), TextBox).Text
        Dim myConnection As New SqlConnection(ConnectionString)
        Dim UpdateCommand As SqlCommand = New SqlCommand()
        UpdateCommand.Connection = myConnection

        If AddingNew = True Then
            UpdateCommand.CommandText = "INSERT INTO Itin (StartDate, StartTime, Venue , State, Country) VALUES (@StartDate, @StartTime, @Venue, @State, @Country)"
        Else
            UpdateCommand.CommandText = "UPDATE Itin SET StartDate = @StartDate, StartTime = @StartTime, Venue = @Venue, State = @State, Country = @Country WHERE ItinID = @ItinID"
        End If

        UpdateCommand.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate
        UpdateCommand.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = StartTime
        UpdateCommand.Parameters.Add("@Venue", SqlDbType.VarChar, 50).Value = Venue
        UpdateCommand.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = State
        UpdateCommand.Parameters.Add("@Country", SqlDbType.VarChar, 50).Value = Country
        UpdateCommand.Parameters.Add("@ItinID", SqlDbType.Int).Value = ItinID

        ' execute the command
        Try
            myConnection.Open()
            UpdateCommand.ExecuteNonQuery()

        Catch ex As Exception
            Message.Text = ex.ToString()

        Finally
            myConnection.Close()

        End Try

        ' Resort the grid for new records
        If AddingNew = True Then
            DataGrid1.CurrentPageIndex = 0
            AddingNew = False
        End If

        ' rebind the grid
        DataGrid1.EditItemIndex = -1
        BindGrid()

    End Sub

    Sub DataGrid_Cancel(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)

        ' cancel editing

        DataGrid1.EditItemIndex = -1
        BindGrid()

        AddingNew = False

    End Sub

    Sub DataGrid_Delete(ByVal Sender As Object, ByVal E As DataGridCommandEventArgs)

        ' delete the selected row

        If Not isEditing Then

            ' the key value for this row is in the DataKeys collection
            Dim keyValue As String = CStr(DataGrid1.DataKeys(E.Item.ItemIndex))

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

    Sub DataGrid_Page(ByVal Sender As Object, ByVal E As DataGridPageChangedEventArgs)

        ' display a new page of data

        If Not isEditing Then

            DataGrid1.EditItemIndex = -1
            DataGrid1.CurrentPageIndex = E.NewPageIndex
            BindGrid()

        End If

    End Sub

    Sub AddNew_Click(ByVal Sender As Object, ByVal E As EventArgs)

        ' add a new row to the end of the data, and set editing mode 'on'

        CheckIsEditing("")

        If Not isEditing = True Then

            ' set the flag so we know to do an insert at Update time
            AddingNew = True

            ' add new row to the end of the dataset after binding

            ' first get the data
            Dim myConnection As New SqlConnection(ConnectionString)
            Dim myCommand As New SqlDataAdapter(SelectCommand, myConnection)

            Dim ds As New DataSet()
            myCommand.Fill(ds)

            ' add a new blank row to the end of the data
            Dim rowValues As Object() = {"", "", ""}
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


End Class
