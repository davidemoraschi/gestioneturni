Option Strict On
Option Explicit On 
Imports System
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Globalization
Imports System.Threading

Public Class ItinDay
    Inherits System.Web.UI.Page
    Protected WithEvents rptDetail As System.Web.UI.WebControls.Repeater
    Private cnString As String = ConfigurationSettings.AppSettings("ConnStr")
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim itinID As Integer = Convert.ToInt32(Request.QueryString("D"))
            Dim showDay As String = Convert.ToString(Request.QueryString("A"))
            Dim thisDay As DateTime
            If itinID > 0 Then
                RenderDetail(itinID)
            ElseIf showDay <> "" Then
                showDay = showDay.Replace("|", "/")
                thisDay = DateTime.Parse(showDay)
                RenderDay(thisDay)
            End If
        Catch x As InvalidCastException
            Response.Write("Invalid input")
        End Try
    End Sub
    Private Sub RenderDetail(ByVal ItinID As Integer)
        Dim detail As New StringBuilder()
        Dim cn As SqlConnection = New SqlConnection(cnString)
        Dim cmd As SqlCommand = New SqlCommand("GetDateDetail " & ItinID, cn)
        Dim myData As SqlDataReader
        Try
            cmd.Connection.Open()
            myData = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As SqlException
            myData = Nothing
        End Try
        rptDetail.DataSource = myData
        rptDetail.DataBind()
    End Sub
    Private Sub RenderDay_orig(ByVal thisDay As DateTime)
        Dim detail As New StringBuilder()
        Dim dh As New DataHelper()
        Dim cn As SqlConnection = New SqlConnection(cnString)
        Dim cmd As SqlCommand = New SqlCommand("GetAllDateDetail '" & thisDay & "'", cn)
        Dim myData As SqlDataReader
        Try
            cmd.Connection.Open()
            myData = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As SqlException
            myData = Nothing
        End Try
        rptDetail.DataSource = myData
        rptDetail.DataBind()
    End Sub
    Private Sub RenderDay(ByVal thisDay As DateTime)
        Dim detail As New StringBuilder()
        Dim dh As New DataHelper()
        Dim iDay As Integer = thisDay.Day
        Dim iMonth As Integer = thisDay.Month
        Dim iYear As Integer = thisDay.Year
        Dim cn As SqlConnection = New SqlConnection(cnString)
        Dim cmd As SqlCommand = New SqlCommand("GetAllDateDetail_Intl", cn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim myData As SqlDataReader
        Try
            dh.AppendSQLParameter(cmd, "@StartDay", SqlDbType.Int, ParameterDirection.Input, 4, iDay)
            dh.AppendSQLParameter(cmd, "@StartMonth", SqlDbType.Int, ParameterDirection.Input, 4, iMonth)
            dh.AppendSQLParameter(cmd, "@StartYear", SqlDbType.Int, ParameterDirection.Input, 4, iYear)
            dh.AppendSQLParameter(cmd, "@LCID", SqlDbType.Int, ParameterDirection.Input, 4, 103)
            cmd.Connection.Open()
            myData = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch e As SqlException
            myData = Nothing
        End Try
        rptDetail.DataSource = myData
        rptDetail.DataBind()
    End Sub
    Private Sub InitializeComponent()

    End Sub

    Private Sub rptDetail_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDetail.ItemCommand

    End Sub
End Class
