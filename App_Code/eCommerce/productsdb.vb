Imports System
Imports System.Data
Imports System.Data.SqlClient


Namespace AstorwinesCommerce

    Public Class ProductsDB

        Dim m_ConnectionString As String

        Public Sub New(ByVal dsn As String)
            m_ConnectionString = dsn
        End Sub

        Public Function GetInfoForItem(ByVal item As String) As String

            Dim sSP As String = "GetInfoForItem_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmItem As New SqlParameter
            Dim _prmInfo As New SqlParameter

            Try
                _scSC.CommandType = CommandType.StoredProcedure

                _prmItem = _scSC.Parameters.Add("@item", System.Data.SqlDbType.VarChar, 5)
                _prmItem.Direction = ParameterDirection.Input
                _prmItem.Value = item

                _prmInfo = _scSC.Parameters.Add("@Info", System.Data.SqlDbType.VarChar, 150)
                _prmInfo.Direction = ParameterDirection.Output

                _scSC.Connection.Open()
                _scSC.ExecuteNonQuery()

                GetInfoForItem = _scSC.Parameters("@Info").Value

            Catch ex As Exception
                Throw ex

            Finally
                If _scSC.Connection.State = ConnectionState.Open Then
                    _scSC.Connection.Close()
                End If
            End Try



        End Function
        Public Function GetUBCAwardsForItem(ByVal item As String) As DataSet

            Dim sSP As String = "GetUBCAwardsForItem_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@Item", SqlDbType.VarChar, 5, ParameterDirection.Input)).Value = item
                End With

                _daLocal = New SqlDataAdapter(_scSC)
                _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

                Try
                    _daLocal.Fill(dsReturn)
                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With

            Return dsReturn

        End Function
    End Class

End Namespace
