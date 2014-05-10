Imports System
Imports System.Data
Imports System.Data.SqlClient
'Imports System.Collections

Namespace AstorwinesCommerce

    Public Class Customer

        Dim m_ConnectionString As String

        Public Sub New(ByVal dsn As String)
            m_ConnectionString = dsn
        End Sub

        Public Function GetCustomerInfo(ByVal CustomerNumber As String, ByVal Idt As String) As DataSet

            Dim sSP As String = "GetCustomerInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
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
        Public Function GetCustomerInfoFormatted(ByVal CustomerNumber As String, ByVal Idt As String) As DataSet

            Dim sSP As String = "GetCustomerInfoFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
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
        Public Function GetCustomerSummaryFormatted(ByVal CustomerNumber As String, ByVal Idt As String) As DataSet

            Dim sSP As String = "GetCustomerSummaryFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
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
        Public Function GetCCInfo(ByVal CustomerNumber As String, ByVal Idt As String, ByVal ccRowID As String, ByVal ccRowIDU As String, ByVal bDefault As Boolean) As DataSet

            Dim sSP As String = "GetCCInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
                    .Add(New SqlParameter("@ccRowid", SqlDbType.Int, 10, ParameterDirection.Input)).Value = ccRowID
                    .Add(New SqlParameter("@ccRowidU", SqlDbType.UniqueIdentifier, 16, ParameterDirection.Input)).Value = ccRowIDU
                    .Add(New SqlParameter("@Default", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = bDefault

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
        Public Function CheckCustomerHasBillingInfo(ByVal CustomerNumber As String) As Boolean
            ' 

            Dim dsLocal As New DataSet
            Dim sLastName As String

            dsLocal = GetCustomerInfo(CustomerNumber, String.Empty)

            If dsLocal.Tables.Count = 0 Then
                CheckCustomerHasBillingInfo = False
            ElseIf dsLocal.Tables(0).Rows.Count = 0 Then
                CheckCustomerHasBillingInfo = False
            ElseIf dsLocal.Tables(0).Rows(0).Item("LastName") Is DBNull.Value Then
                CheckCustomerHasBillingInfo = False
            Else

                sLastName = dsLocal.Tables(0).Rows(0).Item("LastName")
                If RTrim(sLastName) = "" Then
                    CheckCustomerHasBillingInfo = False
                Else
                    CheckCustomerHasBillingInfo = True
                End If
            End If
        End Function
        Public Function CheckCustomerHasShippingInfo(ByVal CustomerNumber As String) As Boolean
            ' 

            Dim dsLocal As New DataSet
            Dim sDesc As String

            dsLocal = GetAllCustomersShipToInfo(CustomerNumber, String.Empty)

            If dsLocal.Tables.Count = 0 Then
                CheckCustomerHasShippingInfo = False
            ElseIf dsLocal.Tables(0).Rows.Count = 0 Then
                CheckCustomerHasShippingInfo = False
            Else
                sDesc = dsLocal.Tables(0).Rows(0).Item("desc")
                If RTrim(sDesc) = "" Then
                    CheckCustomerHasShippingInfo = False
                Else
                    CheckCustomerHasShippingInfo = True
                End If
            End If
        End Function
        Public Function GetCCInfoFormatted(ByVal CustomerNumber As String, ByVal Idt As String, ByVal ccRowID As Int32, ByVal ccRowIDU As String, ByVal bDefault As Boolean) As DataSet

            Dim sSP As String = "GetCCInfoFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
                    .Add(New SqlParameter("@ccRowid", SqlDbType.Int, 10, ParameterDirection.Input)).Value = ccRowID
                    .Add(New SqlParameter("@ccRowidU", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ccRowIDU
                    .Add(New SqlParameter("@Default", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = bDefault

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
        Public Function GetAllCustomersCCInfo(ByVal CustomerNumber As String, ByVal Idt As String) As DataSet

            Dim sSP As String = "GetAllCustomersCCInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
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
        Public Function CheckForOneTimeFreeShipping(ByVal customerNumber As String) As Boolean
            Dim sSP As String = "CheckForOneTimeFreeShipping_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bApplied As Boolean = False

            ' Create the required input parameters 
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmApplied As New SqlParameter

            _scSC.CommandType = CommandType.StoredProcedure

            _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
            _prmCustomerNumber.Direction = ParameterDirection.Input
            _prmCustomerNumber.Value = customerNumber

            _prmApplied = _scSC.Parameters.Add("@bApplied", System.Data.SqlDbType.Bit, 1)
            _prmApplied.Direction = ParameterDirection.Output


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()


            _bApplied = Convert.ToDecimal(_scSC.Parameters("@bApplied").Value)

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            Return _bApplied

        End Function
        Public Function MatchCustomerInfo(ByVal Lastname As String, ByVal Phone As String) As DataSet

            Dim sSP As String = "MatchCustomerInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@Lastname", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = Lastname.ToString.ToUpper
                    .Add(New SqlParameter("@Phone", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value = Phone
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
        Public Function MatchCustomerShipToInfo(ByVal CustomerNumber As String) As DataSet

            Dim sSP As String = "MatchCustomerShipToInfo_sp"
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
        Public Function GetCustomerShippingInfo(ByVal CustomerNumber As String, ByVal Idt As String, ByVal Ids As String, ByVal ShipDefault As Boolean) As DataSet

            Dim sSP As String = "GetCustomerShippingInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
                    .Add(New SqlParameter("@Ids", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value = Ids
                    .Add(New SqlParameter("@ShipDefault", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = ShipDefault

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
        Public Function GetCustomerShippingInfoFormatted(ByVal CustomerNumber As String, ByVal Idt As String, ByVal Ids As String) As DataSet

            Dim sSP As String = "GetCustomerShippingInfoFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
                    .Add(New SqlParameter("@Ids", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value = Ids
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
        Public Function GetAllCustomersShipToInfo(ByVal CustomerNumber As String, ByVal Idt As String) As DataSet

            Dim sSP As String = "GetAllCustomersShipToInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
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
        Public Sub UpdateCustomer(ByVal hstCustomerInfo As Hashtable)

            Dim sSP As String = "UpdateCustomerBillingInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("CustomerNumber")
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("Idt")
                    .Add(New SqlParameter("@LastName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("LastName").ToString.ToUpper
                    .Add(New SqlParameter("@FirstName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("FirstName").ToString.ToUpper
                    .Add(New SqlParameter("@Company", SqlDbType.VarChar, 150, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("Company").ToString.ToUpper
                    .Add(New SqlParameter("@Address", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("Address").ToString.ToUpper
                    .Add(New SqlParameter("@Apt", SqlDbType.VarChar, 25, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("Apt").ToString.ToUpper
                    .Add(New SqlParameter("@City", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("City").ToString.ToUpper
                    .Add(New SqlParameter("@State", SqlDbType.VarChar, 2, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("State").ToString.ToUpper
                    .Add(New SqlParameter("@ZipCode", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("ZipCode")
                    .Add(New SqlParameter("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("Country")
                    .Add(New SqlParameter("@DayPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("DayPhone")
                    .Add(New SqlParameter("@EveningPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("EveningPhone")
                    .Add(New SqlParameter("@MailingList", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = hstCustomerInfo.Item("bMailingList")
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
        Public Sub UpdateCustomerShipTo(ByVal hstCustomerShipToInfo As Hashtable)

            Dim sSP As String = "UpdateCustomerShipToInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("CustomerNumber")
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("Idt")
                    .Add(New SqlParameter("@Ids", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("Ids")
                    .Add(New SqlParameter("@ShipLastName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipLastName").ToString.ToUpper
                    .Add(New SqlParameter("@ShipFirstName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipFirstName").ToString.ToUpper
                    .Add(New SqlParameter("@ShipCompany", SqlDbType.VarChar, 150, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipCompany").ToString.ToUpper
                    .Add(New SqlParameter("@ShipAddress", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipAddress").ToString.ToUpper
                    .Add(New SqlParameter("@ShipApt", SqlDbType.VarChar, 25, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipApt").ToString.ToUpper
                    .Add(New SqlParameter("@ShipCity", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipCity").ToString.ToUpper
                    .Add(New SqlParameter("@ShipState", SqlDbType.VarChar, 2, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipState").ToString.ToUpper
                    .Add(New SqlParameter("@ShipZipCode", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipZipCode")
                    .Add(New SqlParameter("@ShipCountry", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipCountry")
                    .Add(New SqlParameter("@ShipDayPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value = hstCustomerShipToInfo.Item("ShipDayPhone")
                    .Add(New SqlParameter("@ShipEveningPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value = hstCustomerShipToInfo.Item("ShipEveningPhone")
                    .Add(New SqlParameter("@Scross", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = hstCustomerShipToInfo.Item("Scross")
                    .Add(New SqlParameter("@ShipEmail", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = hstCustomerShipToInfo.Item("ShipEmail")
                    .Add(New SqlParameter("@ShipDefault", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = hstCustomerShipToInfo.Item("ShipDefault")
                    .Add(New SqlParameter("@Idsout", SqlDbType.VarChar, 4, ParameterDirection.Output)).Value() = String.Empty

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
        Public Sub UpdateCustomerCCInfo(ByVal hstCustomerCCInfo As Hashtable)
            Dim sSP As String = "UpdateCustomerCCInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("CustomerNumber")
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = hstCustomerCCInfo.Item("Idt")
                    .Add(New SqlParameter("@cctype", SqlDbType.Char, 1, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("cctype")
                    .Add(New SqlParameter("@ccnum", SqlDbType.VarChar, 16, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("ccnum")
                    .Add(New SqlParameter("@ccdateyy", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("ccdateyyyy")
                    .Add(New SqlParameter("@ccdatemm", SqlDbType.VarChar, 2, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("ccdatemm")
                    .Add(New SqlParameter("@cvv", SqlDbType.VarChar, 5, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("cvv")
                    .Add(New SqlParameter("@ccName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("ccName").ToString.ToUpper
                    .Add(New SqlParameter("@ccRowid", SqlDbType.Int, 10, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("ccRowid")
                    .Add(New SqlParameter("@ccRowidU", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("ccRowIDU")
                    .Add(New SqlParameter("@Default", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = hstCustomerCCInfo.Item("ccDefault")
                 
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
        Public Sub DeleteCustomerCCInfo(ByVal CustomerNumber As String, ByVal Idt As String, ByVal ccRowID As Int32, ByVal ccRowIDU As String)
            Dim sSP As String = "DeleteCustomerCCInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = Idt
                    .Add(New SqlParameter("@ccRowid", SqlDbType.Int, 10, ParameterDirection.Input)).Value = ccRowID
                    .Add(New SqlParameter("@ccRowIDU", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ccRowIDU

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
        Public Sub DeleteCustomerShippingInfo(ByVal CustomerNumber As String, ByVal Idt As String, ByVal Ids As String)
            Dim sSP As String = "DeleteCustomerShippingInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = Idt
                    .Add(New SqlParameter("@Ids", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value() = Ids

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


