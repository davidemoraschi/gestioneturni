<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Itinday.aspx.vb" Inherits="gestioneturni.ItinDay" Culture="it-IT" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
	</HEAD>
	<body bgcolor="#b0c4de">
		<form id="Form1" method="post" runat="server">
			<center>
				<asp:Repeater ID="rptDetail" Runat="server">
					<HeaderTemplate>
						<table width="100%">
							<tr>
								<td bgcolor="#336699"><p class="HeaderGreen">Dettagli</p>
								</td>
							</tr>
						</table>
					</HeaderTemplate>
					<ItemTemplate>
						<table bgcolor="#99cc99" width="100%">
							<tr valign="top">
								<td><p class="smblu">Data</p>
								</td>
								<td bgcolor="#FFFFFFF"><%# Databinder.Eval(Container.DataItem, "StartDate", "{0:d}") %></td>
							</tr>
							<tr valign="top">
								<td><p class="smblu">Ora</p>
								</td>
								<td bgcolor="#FFFFFFF"><%# Databinder.Eval(Container.DataItem, "StartTime", "{0:t}") %></td>
							</tr>
							<tr valign="top">
								<td><p class="smblu">Cliente</p>
								</td>
								<td bgcolor="#FFFFFFF"><%# Container.DataItem("Venue") %></td>
							</tr>
							<tr valign="top">
								<td><p class="smblu">Progetto</p>
								</td>
								<td bgcolor="#FFFFFFF"><%# Container.DataItem("City") %>
									<%# Container.DataItem("State") %>
									<%# Container.DataItem("Country") %>
								</td>
							</tr>
						</table>
					</ItemTemplate>
					<SeparatorTemplate>
						<hr color="#336699" size="2">
					</SeparatorTemplate>
				</asp:Repeater></center>
		</form>
	</body>
</HTML>
