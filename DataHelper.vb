Imports System
Imports System.Text
Imports System.Drawing
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web.UI
Imports System.Web.Caching
Public Class DataHelper
    Public Sub AppendSQLParameter(ByRef cmd As SqlCommand, _
                ByVal strParamName As String, _
                ByVal strDataType As SqlDbType, _
                ByVal strDirection As ParameterDirection, _
                ByVal lngSize As Integer, _
                ByVal varValue As Object)
        Dim param As SqlParameter
        If lngSize > 0 Then
            param = New SqlParameter(strParamName, strDataType, lngSize)
        Else
            param = New SqlParameter(strParamName, strDataType)
        End If
        param.Direction = strDirection
        If Not strDirection = ParameterDirection.Output Then
            If Not ((varValue Is System.DBNull.Value) Or (varValue Is Nothing)) Then
                param.Value = varValue
            Else
                param.Value = System.DBNull.Value
            End If
        End If
        cmd.Parameters.Add(param)
    End Sub
End Class
