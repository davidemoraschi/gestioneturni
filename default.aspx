<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="gestioneturni.ItinSample" Culture="it-IT" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<meta name="vs_showGrid" content="True">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="lblMsg" CssClass="Alert" Runat="server"></asp:label>
			<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="800" border="0">
				<TR>
					<TD>
						<asp:calendar id="Calendar1" Runat="server" OnSelectionChanged="CheckDay" OnVisibleMonthChanged="ChangeMonth" OnDayRender="Calendar1_DayRender" DayStyle-verticalalign="Top" DayStyle-Font-Size="8" TitleStyle-Font-Bold="True" TitleStyle-Font-Name="Verdana" TitleStyle-Font-Size="14" BackColor="#FFFFCC" BorderColor="#FFCC66" OtherMonthDayStyle-ForeColor="#C0C0C0" DayStyle-BorderStyle="Solid" DayStyle-BorderWidth="1" TodayDayStyle-ForeColor="Red" Height="500px" Width="390px" DayNameFormat="FirstLetter" ForeColor="#663399" Font-Size="8pt" Font-Names="Verdana" BorderWidth="1px" ShowGridLines="True">
							<TodayDayStyle ForeColor="White" BackColor="#FFCC66"></TodayDayStyle>
							<SelectorStyle BackColor="#FFCC66"></SelectorStyle>
							<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC"></NextPrevStyle>
							<DayHeaderStyle Height="1px" BackColor="#FFCC66"></DayHeaderStyle>
							<SelectedDayStyle Font-Bold="True" BackColor="#CCCCFF"></SelectedDayStyle>
							<TitleStyle Font-Size="9pt" Font-Bold="True" ForeColor="#FFFFCC" BackColor="#990000"></TitleStyle>
							<OtherMonthDayStyle ForeColor="#CC9966"></OtherMonthDayStyle>
						</asp:calendar></TD>
					<TD>
						<iframe id="Detail" name="Detail" src="ItinDay.aspx" Height="500" Width="390" frameBorder="yes" scrolling="yes" runat="server"></iframe></TD>
				</TR>
			</TABLE>
			<P>
				<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="DataInsert.aspx">Inserire turni</asp:HyperLink></P>
		</form>
	</body>
</HTML>
