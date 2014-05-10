Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class cAstorWinesCMS
    Dim m_ConnectionString As String

    Public Sub New(ByVal dsn As String)
        m_ConnectionString = dsn
    End Sub
    Public Function GetCMSWhatsHot() As DataSet

        Dim sSP As String = "GetCMSWhatsHot_sp"
        Dim _cnConnection As New SqlConnection(m_ConnectionString)
        Dim _scSC As New SqlCommand(sSP, _cnConnection)
        Dim _daLocal As New SqlDataAdapter
        Dim dsReturn As New DataSet

        With _scSC
            .CommandType = CommandType.StoredProcedure

            _daLocal = New SqlDataAdapter(_scSC)
            _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

            Try
                _daLocal.Fill(dsReturn)
            Catch ex As Exception
                Throw

            Finally
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End Try
        End With

        Return dsReturn

    End Function
End Class
