<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DataInsert.aspx.vb" Inherits="gestioneturni.DataInsert" Culture="it-IT"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
	</HEAD>
	<body style="FONT-FAMILY: arial">
		<h2>Inserire nuovo turno&nbsp;
		</h2>
		<hr size="1">
		<form runat="server" ID="Form1">
			<asp:datagrid id="DataGrid1" runat="server" width="80%" CellPadding="4" BackColor="White" OnPageIndexChanged="DataGrid_Page" PageSize="60" AllowPaging="True" OnDeleteCommand="DataGrid_Delete" OnCancelCommand="DataGrid_Cancel" OnUpdateCommand="DataGrid_Update" OnEditCommand="DataGrid_Edit" OnItemCommand="DataGrid_ItemCommand" AllowSorting="True" ShowFooter="True" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" ForeColor="#330099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
						<ItemStyle Font-Size="Smaller" Width="10%"></ItemStyle>
					</asp:EditCommandColumn>
					<asp:ButtonColumn Text="Delete" CommandName="Delete">
						<ItemStyle Font-Size="Smaller" Width="10%"></ItemStyle>
					</asp:ButtonColumn>
				</Columns>
				<PagerStyle Font-Size="Smaller" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<br>
			<asp:LinkButton id="LinkButton1" onclick="AddNew_Click" runat="server" Font-Size="smaller" Text="Add new item"></asp:LinkButton>
			<br>
			<br>
			<asp:Label id="Message" runat="server" width="80%" ForeColor="red" EnableViewState="false" BackColor="Silver" Font-Size="X-Small" Font-Bold="True"></asp:Label>
		</form>
	</body>
</HTML>
