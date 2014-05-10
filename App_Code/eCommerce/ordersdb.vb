Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports System.Collections

Namespace AstorwinesCommerce

    Public Class OrdersDB

        Dim m_ConnectionString As String

        Public Sub New(ByVal dsn As String)
            m_ConnectionString = dsn
        End Sub

        Public Function GetOrdersForCustomer(ByVal CustomerNumber As String) As DataSet
            Dim sSP As String = "GetOrdersForCustomer_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
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
        Public Function GetOrdersForCustomerFormatted(ByVal CustomerNumber As String) As DataSet
            Dim sSP As String = "GetOrdersForCustomerFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
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
        Public Function GetOrderForCustomer(ByVal CustomerNumber As String, ByVal OrderNumber As String) As DataSet
            Dim sSP As String = "GetOrderForCustomer_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@OrderNumber", SqlDbType.Char, 6, ParameterDirection.Input)).Value = OrderNumber

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
        Public Function GetOrderForCustomerFormatted(ByVal CustomerNumber As String, ByVal OrderNumber As String) As DataSet
            Dim sSP As String = "GetOrderForCustomerFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@OrderNumber", SqlDbType.Char, 6, ParameterDirection.Input)).Value = OrderNumber

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
        Public Function GetOrderDetailCompletedForCustomerFormatted(ByVal CustomerNumber As String, ByVal OrderNumber As String) As DataSet
            Dim sSP As String = "GetOrderDetailCompletedForCustomerFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@OrderNumber", SqlDbType.Char, 6, ParameterDirection.Input)).Value = OrderNumber

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


        Public Function AddNewOrder(ByVal CustomerNumber As String, ByVal Ordered As Date) As String

            Dim sSP As String = "AddNewOrder_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmOrdered As New SqlParameter
            Dim _prmOrderNum As New SqlParameter

            Dim Inum As String
            Try
                _scSC.CommandType = CommandType.StoredProcedure

                _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
                _prmCustomerNumber.Direction = ParameterDirection.Input
                _prmCustomerNumber.Value = CustomerNumber

                _prmOrdered = _scSC.Parameters.Add("@Ordered", System.Data.SqlDbType.DateTime, 20)
                _prmOrdered.Direction = ParameterDirection.Input
                _prmOrdered.Value = Ordered


                _prmOrderNum = _scSC.Parameters.Add("@OrderNum", System.Data.SqlDbType.Char, 6)
                _prmOrderNum.Direction = ParameterDirection.Output


                _scSC.Connection.Open()

                _scSC.ExecuteNonQuery()

                Inum = Convert.ToDecimal(_scSC.Parameters("@OrderNum").Value)
            Catch ex As Exception
                Throw ex

            Finally
                If _scSC.Connection.State = ConnectionState.Open Then
                    _scSC.Connection.Close()
                End If
            End Try
            AddNewOrder = Inum

        End Function

        Public Sub DeleteOrdersForCustomer(ByVal customerNumber As String)
            Dim sSP As String = "DeleteOrdersForCustomer_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With


        End Sub

    End Class

End Namespace


