Option Strict On
Option Explicit On 
Imports System
Imports System.Text
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.Caching
Imports System.Globalization
Imports System.Threading

Public Class ItinSample
    Inherits System.Web.UI.Page
    Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar
    Private cnString As String = ConfigurationSettings.AppSettings("ConnStr")
    Private dtDates As DataTable
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Private curMonth As DateTime
    Private noDatesForMonth As Boolean = False
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Detail As System.Web.UI.HtmlControls.HtmlGenericControl
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            curMonth = Convert.ToDateTime("01" & "/" & DateTime.Today.Month.ToString & "/" & DateTime.Today.Year.ToString)
            Calendar1.VisibleDate = curMonth
            LoadCacheForMonth(curMonth)
        End If
    End Sub
    Private Sub LoadCacheForMonth(ByVal curMonth As DateTime)
        Dim iMonth As Integer = curMonth.Month
        Dim iYear As Integer = curMonth.Year
        Dim cacheName As String = iMonth.ToString & iYear.ToString & "Dates"
        If Cache(cacheName) Is Nothing Then
            dtDates = DatesForMonth(curMonth)
            Cache.Insert(cacheName, dtDates, Nothing, Cache.NoAbsoluteExpiration, _
                        TimeSpan.FromHours(3))
        Else
            dtDates = CType(Cache(cacheName), DataTable)
        End If
    End Sub
    Protected Sub ChangeMonth(ByVal sender As Object, ByVal e As MonthChangedEventArgs)
        Calendar1.SelectedDate = Nothing
        Detail.Attributes("src") = "ItinDay.aspx"
        curMonth = e.NewDate.Date
        LoadCacheForMonth(curMonth)
    End Sub
    Private Function DatesForMonth(ByVal Month As DateTime) As DataTable
        Dim dh As New DataHelper()
        Dim cn As SqlConnection = New SqlConnection(cnString)
        Dim cmd As SqlDataAdapter = New SqlDataAdapter("GetDatesForMonth", cn)
        cmd.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim dt As New DataTable()
        Try
            dh.AppendSQLParameter(cmd.SelectCommand, "@startDate", SqlDbType.DateTime, ParameterDirection.Input, 8, Month)
            cmd.Fill(dt)
            cmd.Dispose()
            cn.Close()
        Catch x As SqlException
            lblMsg.Text = x.Message
        Finally
            cn = Nothing
        End Try
        Return dt
    End Function
    Protected Sub CheckDay(ByVal sender As Object, ByVal e As EventArgs)
        Dim thisDay As String
        thisDay = Calendar1.SelectedDate.ToShortDateString
        Detail.Attributes("src") = "ItinDay.aspx?A=" & thisDay
        curMonth = Convert.ToDateTime(thisDay.Replace("|", "/"))
    End Sub
    Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
        If noDatesForMonth Then Exit Sub
        Dim matchRows() As DataRow
        Dim myMonth As Integer = curMonth.Month
        LoadCacheForMonth(curMonth)
        If ((dtDates Is Nothing) OrElse (dtDates.Rows.Count = 0)) Then
            noDatesForMonth = True
            Exit Sub
        End If
        Dim curDay As Integer
        Dim dr As DataRow
        Dim dayText As StringBuilder = New StringBuilder()
        Dim eventDay As Boolean
        Dim c As TableCell = e.Cell
        If e.Day.Date.Month = myMonth Then
            curDay = e.Day.Date.Day
            matchRows = dtDates.Select("ShowDay=" & curDay.ToString)
            For Each dr In matchRows
                eventDay = True
                dayText.Append("<br><b>")
                dayText.Append(Convert.ToString(dr.Item("Venue")))
                dayText.Append("</b><br>")
                dayText.Append("<ahref='ItinDay.aspx?D=")
                dayText.Append(Convert.ToString(dr.Item("ItinID")))
                dayText.Append("' target='Detail'>View Detail</a>")
            Next
            If eventDay Then
                e.Cell.BackColor = Color.Pink
                c.Controls.Add(New LiteralControl(dayText.ToString))
                dayText = New StringBuilder()
            End If
        End If
    End Sub
    Private Sub InitializeComponent()

    End Sub
End Class
