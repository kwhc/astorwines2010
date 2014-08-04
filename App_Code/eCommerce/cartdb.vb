Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Collections
Imports System.Web.UI

Namespace AstorwinesCommerce

    Public Class CartDB

        Dim m_ConnectionString As String

        Public Sub New(ByVal dsn As String)
            m_ConnectionString = dsn
        End Sub

        Public Sub AddShoppingCartItem(ByVal CustomerNumber As String, ByVal Item As String, ByVal Type As String, ByVal Quantity As Int16)

            If InStr(Type, "of") > 0 Then
                Type = Mid(Type, 1, 4)
            End If

            Dim previousItem As DataSet = GetShoppingCartItem(CustomerNumber, Item, Type)

            If (previousItem.Tables(0).Rows.Count > 0) Then
                UpdateShoppingCartItem(previousItem.Tables(0).Rows(0)("ShoppingCartID"), previousItem.Tables(0).Rows(0)("Quantity") + Quantity)
            Else


                Dim sSP As String = "AddShoppingCartItem_sp"
                Dim _cnConnection As New SqlConnection(m_ConnectionString)
                Dim _scSC As New SqlCommand(sSP, _cnConnection)

                With _scSC
                    .CommandType = CommandType.StoredProcedure

                    With .Parameters
                        .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                        .Add(New SqlParameter("@item", SqlDbType.Char, 5, ParameterDirection.Input)).Value = Item
                        .Add(New SqlParameter("@quantity", SqlDbType.Int, 10, ParameterDirection.Input)).Value = Quantity
                        .Add(New SqlParameter("@type", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Type
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


            End If

        End Sub
        Public Sub AddItemOutOfStockNotifyList(ByVal Email As String, ByVal Item As String)

            Dim sSP As String = "AddNewItemOutOfStockNotifyList_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@Email", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = Email
                    .Add(New SqlParameter("@item", SqlDbType.VarChar, 5, ParameterDirection.Input)).Value = Item
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception
                    Throw

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With




        End Sub
       
        Public Sub RemoveShoppingCartMergeItem(ByVal CustomerNumber As String, ByVal Item As String, ByVal Type As String, ByVal Quantity As Int16)

           

            Dim sSP As String = "RemoveShoppingCartMergeItem_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            If InStr(Type, "of") > 0 Then
                Type = Mid(Type, 1, 4)
            End If

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@item", SqlDbType.Char, 5, ParameterDirection.Input)).Value = Item
                    .Add(New SqlParameter("@quantity", SqlDbType.Int, 10, ParameterDirection.Input)).Value = Quantity
                    .Add(New SqlParameter("@type", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Type
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
        Public Sub UpdateShoppingCartItem(ByVal shoppingCartID As Integer, ByVal quantity As Integer)
            Dim sSP As String = "UpdateShoppingCartItem_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@shoppingCartID", SqlDbType.Int, 10, ParameterDirection.Input)).Value = shoppingCartID
                    .Add(New SqlParameter("@quantity", SqlDbType.Int, 10, ParameterDirection.Input)).Value = quantity
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
        
        Public Sub UpdateShoppingCartMergeItem(ByVal shoppingCartID As Integer, ByVal quantity As Integer)
            Dim sSP As String = "UpdateShoppingCartMergeItem_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@shoppingCartID", SqlDbType.Int, 10, ParameterDirection.Input)).Value = shoppingCartID
                    .Add(New SqlParameter("@quantity", SqlDbType.Int, 10, ParameterDirection.Input)).Value = quantity
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
        Public Sub UpdateShoppingCartCustInfoBilling(ByVal ShoppingCartCustInfo As Hashtable)

            Dim sSP As String = "UpdateShoppingCartCustInfoBilling_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("CustomerNumber")
                    .Add(New SqlParameter("@NewIdt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("NewIdt")
                    .Add(New SqlParameter("@LastName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("LastName").ToString.ToUpper
                    .Add(New SqlParameter("@FirstName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("FirstName").ToString.ToUpper
                    .Add(New SqlParameter("@Company", SqlDbType.VarChar, 150, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("Company").ToString.ToUpper
                    .Add(New SqlParameter("@Address", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("Address").ToString.ToUpper
                    .Add(New SqlParameter("@Apt", SqlDbType.VarChar, 25, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("Apt").ToString.ToUpper
                    .Add(New SqlParameter("@City", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("City").ToString.ToUpper
                    .Add(New SqlParameter("@State", SqlDbType.VarChar, 2, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("State").ToString.ToUpper
                    .Add(New SqlParameter("@ZipCode", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("ZipCode")
                    .Add(New SqlParameter("@Country", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("Country")
                    .Add(New SqlParameter("@DayPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("DayPhone")
                    .Add(New SqlParameter("@EveningPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("EveningPhone")
                    .Add(New SqlParameter("@MailingList", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("bMailingList")

                    
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
        Public Sub UpdateShoppingCartCustInfoBilling(ByVal CustomerNumber As String, ByVal Idt As String)

            Dim sSP As String = "UpdateShoppingCartCustInfoBillingCurrent_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = Idt

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
        Public Sub UpdateShoppingCartCustInfoShipping(ByVal ShoppingCartCustInfo As Hashtable)

            Dim sSP As String = "UpdateShoppingCartCustInfoShipping_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("CustomerNumber")
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("Idt")
                    .Add(New SqlParameter("@Ids", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("Ids")
                    .Add(New SqlParameter("@ShipLastName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipLastName").ToString.ToUpper
                    .Add(New SqlParameter("@ShipFirstName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipFirstName").ToString.ToUpper
                    .Add(New SqlParameter("@ShipCompany", SqlDbType.VarChar, 150, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipCompany").ToString.ToUpper
                    .Add(New SqlParameter("@ShipAddress", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipAddress").ToString.ToUpper
                    .Add(New SqlParameter("@ShipApt", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipApt").ToString.ToUpper
                    .Add(New SqlParameter("@ShipCity", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipCity").ToString.ToUpper
                    .Add(New SqlParameter("@ShipState", SqlDbType.VarChar, 2, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipState").ToString.ToUpper
                    .Add(New SqlParameter("@ShipZipCode", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipZipCode")
                    .Add(New SqlParameter("@ShipCountry", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipCountry")
                    .Add(New SqlParameter("@ShipDayPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("ShipDayPhone")
                    .Add(New SqlParameter("@ShipEveningPhone", SqlDbType.VarChar, 12, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("ShipEveningPhone")
                    .Add(New SqlParameter("@Scross", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = ShoppingCartCustInfo.Item("Scross")
                    .Add(New SqlParameter("@ShipType", SqlDbType.Int, 10, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipType")
                    .Add(New SqlParameter("@Gift", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("Gift")
                    .Add(New SqlParameter("@GiftNote", SqlDbType.VarChar, 500, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("GiftNote")
                    .Add(New SqlParameter("@Promo", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("Promo").ToString.ToUpper
                    .Add(New SqlParameter("@ShipInst", SqlDbType.VarChar, 70, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipInst").ToString.ToUpper
                    .Add(New SqlParameter("@ShipDefault", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipDefault")
                    .Add(New SqlParameter("@ShipDate", SqlDbType.DateTime, 12, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipDate")
                    .Add(New SqlParameter("@ShipEmail", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("ShipEmail")
                    .Add(New SqlParameter("@b3rdPartyShipInsAgreement", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("b3rdPartyShipInsAgreement")
                    .Add(New SqlParameter("@b3rdPartyShipIns", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("b3rdPartyShipIns")
                    .Add(New SqlParameter("@iPMCourier", SqlDbType.Int, 10, ParameterDirection.Input)).Value() = ShoppingCartCustInfo.Item("iPMCourier")
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
        Public Sub UpdateShoppingCartCustInfoShipping(ByVal CustomerNumber As String, ByVal Idt As String, ByVal Ids As String, ByVal sShipType As String, ByVal bGift As Boolean, ByVal sGiftNote As String, ByVal sPromo As String, ByVal sShipInst As String, ByVal dtShipDate As Date, ByVal b3rdPartyShipInsAgreement As Boolean, ByVal b3rdPartyShipIns As Boolean, ByVal iPMCourier As Int16)

            Dim sSP As String = "UpdateShoppingCartCustInfoShippingCurrent_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = Idt
                    .Add(New SqlParameter("@Ids", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value() = Ids
                    .Add(New SqlParameter("@ShipType", SqlDbType.Int, 10, ParameterDirection.Input)).Value() = sShipType
                    .Add(New SqlParameter("@Gift", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = bGift
                    .Add(New SqlParameter("@GiftNote", SqlDbType.VarChar, 500, ParameterDirection.Input)).Value() = sGiftNote
                    .Add(New SqlParameter("@Promo", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value() = sPromo.ToString.ToUpper
                    .Add(New SqlParameter("@ShipInst", SqlDbType.VarChar, 70, ParameterDirection.Input)).Value() = sShipInst.ToString.ToUpper
                    .Add(New SqlParameter("@ShipDate", SqlDbType.DateTime, 12, ParameterDirection.Input)).Value() = dtShipDate
                    .Add(New SqlParameter("@b3rdPartyShipInsAgreement", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = b3rdPartyShipInsAgreement
                    .Add(New SqlParameter("@b3rdPartyShipIns", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = b3rdPartyShipIns
                    .Add(New SqlParameter("@iPMCourier", SqlDbType.Int, 10, ParameterDirection.Input)).Value() = iPMCourier
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
        Public Sub UpdateShoppingCartGiftCardInfo(ByVal CustomerNumber As String, ByVal sGiftCardNumber As String, ByVal dGiftCardPresentValue As Decimal)

            Dim sSP As String = "UpdateShoppingCartGiftCardInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@GiftCardNumber", SqlDbType.VarChar, 19, ParameterDirection.Input)).Value() = sGiftCardNumber
                    .Add(New SqlParameter("@GiftCardPresentValue", SqlDbType.Decimal, 10, ParameterDirection.Input)).Value() = dGiftCardPresentValue
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
        Public Sub DeleteShoppingCartGiftCardInfo(ByVal CustomerNumber As String)

            Dim sSP As String = "DeleteShoppingCartGiftCardInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
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
        Public Sub UpdateShoppingCartCCInfo(ByVal ShoppingCartCCInfo As Hashtable)

            Dim sSP As String = "UpdateShoppingCartCCInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("CustomerNumber")
                    .Add(New SqlParameter("@cctype", SqlDbType.Char, 1, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("cctype")
                    .Add(New SqlParameter("@ccnum", SqlDbType.VarChar, 16, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("ccnum")
                    .Add(New SqlParameter("@ccdateyy", SqlDbType.VarChar, 4, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("ccdateyyyy")
                    .Add(New SqlParameter("@ccdatemm", SqlDbType.VarChar, 2, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("ccdatemm")
                    .Add(New SqlParameter("@cvv", SqlDbType.VarChar, 5, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("cvv")
                    .Add(New SqlParameter("@ccName", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("ccName").ToString.ToUpper
                    .Add(New SqlParameter("@ccRowid", SqlDbType.Int, 10, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("ccRowid")
                    .Add(New SqlParameter("@ccRowIDU", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ShoppingCartCCInfo.Item("ccRowIDU")
                    .Add(New SqlParameter("@Default", SqlDbType.Bit, 1, ParameterDirection.Input)).Value() = ShoppingCartCCInfo.Item("ccDefault")
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
        Public Sub UpdateShoppingCartCCInfo(ByVal CustomerNumber As String, ByVal Idt As String, ByVal ccRowID As Int32, ByVal ccRowIDU As String, ByVal ccCVV As String)

            Dim sSP As String = "UpdateShoppingCartCCInfoCurrent_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = Idt
                    .Add(New SqlParameter("@ccRowid", SqlDbType.Int, 10, ParameterDirection.Input)).Value = ccRowID
                    .Add(New SqlParameter("@ccRowIDU", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = ccRowIDU
                    .Add(New SqlParameter("@cvv", SqlDbType.VarChar, 5, ParameterDirection.Input)).Value = ccCVV

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

        Public Function GetTaxRate(ByVal sZipCode As String) As Double
            Dim sSP As String = "GetTaxRate_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmZipCode As New SqlParameter
            Dim _prmTaxRate As New SqlParameter
            Dim dblTaxRate As Double

            _scSC.CommandType = CommandType.StoredProcedure
            _prmZipCode = _scSC.Parameters.Add("@ZipCode", System.Data.SqlDbType.VarChar, 5)
            _prmZipCode.Direction = ParameterDirection.Input
            _prmZipCode.Value = sZipCode
            _prmTaxRate = _scSC.Parameters.Add("@TaxRate", System.Data.SqlDbType.Float, 9)
            _prmTaxRate.Direction = ParameterDirection.Output

            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            dblTaxRate = _scSC.Parameters("@TaxRate").Value

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            GetTaxRate = dblTaxRate

        End Function
        Public Sub CheckAmountNeededShippingFree(ByVal CustomerNumber As String, ByVal idt As String, ByVal ZipCode As String, ByRef AmountNeeded As Decimal, ByRef MinAmount As Decimal, ByRef Type As Int16, ByRef AmountNeededForFreeShipping As Decimal)
            Dim sSP As String = "WebCalcCheckFreeShipping_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmIdt As New SqlParameter
            Dim _prmZipCode As New SqlParameter
            Dim _prmNeeded As New SqlParameter
            Dim _prmMinAmount As New SqlParameter
            Dim _prmType As New SqlParameter
            Dim _prmNeededForFreeShipping As New SqlParameter

            _scSC.CommandType = CommandType.StoredProcedure

            _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
            _prmCustomerNumber.Direction = ParameterDirection.Input
            _prmCustomerNumber.Value = CustomerNumber

            _prmZipCode = _scSC.Parameters.Add("@ZipCode", System.Data.SqlDbType.VarChar, 5)
            _prmZipCode.Direction = ParameterDirection.Input
            _prmZipCode.Value = ZipCode

            _prmIdt = _scSC.Parameters.Add("@Idt", System.Data.SqlDbType.Char, 6)
            _prmIdt.Direction = ParameterDirection.Input
            _prmIdt.Value = idt


            _prmNeeded = _scSC.Parameters.Add("@AmountNeeded", System.Data.SqlDbType.Float, 9)
            _prmNeeded.Direction = ParameterDirection.Output

            _prmMinAmount = _scSC.Parameters.Add("@MinNeeded", System.Data.SqlDbType.Float, 9)
            _prmMinAmount.Direction = ParameterDirection.Output

            _prmType = _scSC.Parameters.Add("@Type", System.Data.SqlDbType.Int, 1)
            _prmType.Direction = ParameterDirection.Output

            _prmNeededForFreeShipping = _scSC.Parameters.Add("@AmountNeededForFreeShipping", System.Data.SqlDbType.Float, 9)
            _prmNeededForFreeShipping.Direction = ParameterDirection.Output

            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            AmountNeeded = Convert.ToDecimal(_scSC.Parameters("@AmountNeeded").Value)
            MinAmount = Convert.ToDecimal(_scSC.Parameters("@MinNeeded").Value)
            Type = Convert.ToDecimal(_scSC.Parameters("@Type").Value)
            AmountNeededForFreeShipping = Convert.ToDecimal(_scSC.Parameters("@AmountNeededForFreeShipping").Value)

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If


        End Sub
        Public Function IsPMCourierAvailable(ByVal CustomerNumber As String, ByVal idt As String, ByVal ShipZipCode As String) As Boolean
            Dim sSP As String = "IsPMCourierAvailable_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bAvailable As Boolean = False

            ' Create the required input parameters 
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmIdt As New SqlParameter
            Dim _prmShipZipCode As New SqlParameter
            Dim _prmAvailable As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure

                    _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
                    _prmCustomerNumber.Direction = ParameterDirection.Input
                    _prmCustomerNumber.Value = CustomerNumber

                    _prmShipZipCode = _scSC.Parameters.Add("@ShipZipCode", System.Data.SqlDbType.VarChar, 5)
                    _prmShipZipCode.Direction = ParameterDirection.Input
                    _prmShipZipCode.Value = ShipZipCode

                    _prmIdt = _scSC.Parameters.Add("@Idt", System.Data.SqlDbType.Char, 6)
                    _prmIdt.Direction = ParameterDirection.Input
                    _prmIdt.Value = idt

                    _prmAvailable = .Parameters.Add("@Available", System.Data.SqlDbType.Bit, 1)
                    _prmAvailable.Direction = ParameterDirection.Output

                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bAvailable = CType(.Parameters("@Available").Value, Boolean)

                Catch ex As Exception
                    Throw

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bAvailable
        End Function
        Public Function IsShipmentInAstorDeliveryZone(ByVal ShipZipCode As String) As Boolean
            Dim sSP As String = "IsShipmentInAstorDeliveryZone_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bExists As Boolean = False

            ' Create the required input parameters 
            Dim _prmShipZipCode As New SqlParameter
            Dim _prmExists As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure

                    _prmShipZipCode = _scSC.Parameters.Add("@ShipZipCode", System.Data.SqlDbType.VarChar, 5)
                    _prmShipZipCode.Direction = ParameterDirection.Input
                    _prmShipZipCode.Value = ShipZipCode


                    _prmExists = .Parameters.Add("@Exists", System.Data.SqlDbType.Bit, 1)
                    _prmExists.Direction = ParameterDirection.Output

                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bExists = CType(.Parameters("@Exists").Value, Boolean)

                Catch ex As Exception
                    Throw

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bExists
        End Function
        Public Function WebCalcShipping(ByVal CustomerNumber As String, ByVal idt As String) As Decimal
            Dim sSP As String = "WebCalcShipping062014_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmIdt As New SqlParameter
            Dim _prmUPS As New SqlParameter

            Dim dUPS As Decimal

            _scSC.CommandType = CommandType.StoredProcedure

            _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
            _prmCustomerNumber.Direction = ParameterDirection.Input
            _prmCustomerNumber.Value = CustomerNumber

            _prmIdt = _scSC.Parameters.Add("@Idt", System.Data.SqlDbType.Char, 6)
            _prmIdt.Direction = ParameterDirection.Input
            _prmIdt.Value = idt


            _prmUPS = _scSC.Parameters.Add("@UPSOut", System.Data.SqlDbType.Float, 10)
            _prmUPS.Direction = ParameterDirection.Output


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            dUPS = Convert.ToDecimal(_scSC.Parameters("@UPSOut").Value)

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            WebCalcShipping = dUPS

        End Function
        Public Function WebCalcShippingUsingZipCode(ByVal CustomerNumber As String, ByVal idt As String, ByVal ZipCode As String, ByVal ShipType As String) As Decimal
            Dim sSP As String = "WebCalcShippingUsingZipCode062014_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmIdt As New SqlParameter
            Dim _prmUPS As New SqlParameter
            Dim _prmZipCode As New SqlParameter
            Dim _prmShipType As New SqlParameter

            Dim dUPS As Decimal

            _scSC.CommandType = CommandType.StoredProcedure

            _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
            _prmCustomerNumber.Direction = ParameterDirection.Input
            _prmCustomerNumber.Value = CustomerNumber

            _prmIdt = _scSC.Parameters.Add("@Idt", System.Data.SqlDbType.Char, 6)
            _prmIdt.Direction = ParameterDirection.Input
            _prmIdt.Value = idt

            _prmZipCode = _scSC.Parameters.Add("@ZipCode", System.Data.SqlDbType.VarChar, 5)
            _prmZipCode.Direction = ParameterDirection.Input
            _prmZipCode.Value = ZipCode

            _prmShipType = _scSC.Parameters.Add("@ShipType", System.Data.SqlDbType.VarChar, 1)
            _prmShipType.Direction = ParameterDirection.Input
            _prmShipType.Value = ShipType


            _prmUPS = _scSC.Parameters.Add("@UPSOut", System.Data.SqlDbType.Float, 10)
            _prmUPS.Direction = ParameterDirection.Output


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            dUPS = Convert.ToDecimal(_scSC.Parameters("@UPSOut").Value)

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            WebCalcShippingUsingZipCode = dUPS

        End Function
        Public Function WebCalcAllShipping(ByVal CustomerNumber As String, ByVal idt As String, ByVal ZipCode As String) As DataSet

            Dim sSP As String = "WebCalcAllShipping062014_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = CustomerNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = idt
                    .Add(New SqlParameter("@ZipCode", SqlDbType.VarChar, 5, ParameterDirection.Input)).Value = ZipCode
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
        Public Function LoadShippingDatesAstorDelivery(ByVal DeliveryType As String) As DataSet

            Dim sSP As String = "LoadShippingDatesAstorDelivery062014_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@DeliveryType", SqlDbType.VarChar, 1, ParameterDirection.Input)).Value = DeliveryType
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
        Public Function GetNextUPSShipDate() As Date

            Dim sSP As String = "GetDefaultShipDateWeb062014_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmIType As New SqlParameter
            Dim _prmSDate As New SqlParameter

            Dim dtShipDate As Date
            _scSC.CommandType = CommandType.StoredProcedure

            _prmIType = _scSC.Parameters.Add("@IType", System.Data.SqlDbType.VarChar, 1)
            _prmIType.Direction = ParameterDirection.Input
            _prmIType.Value = "S"


            _prmSDate = _scSC.Parameters.Add("@sdate", System.Data.SqlDbType.DateTime, 12)
            _prmSDate.Direction = ParameterDirection.Output


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            dtShipDate = _scSC.Parameters("@sdate").Value

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            GetNextUPSShipDate = dtShipDate



        End Function
        Public Function GetShipmentDeliveryType(ByVal ZipCode As String, ByVal CustomerNumber As String) As String

            Dim sSP As String = "GetShipmentDeliveryType062014_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmZipCode As New SqlParameter
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmDeliveryType As New SqlParameter

            Dim sDeliveryType As String

            _scSC.CommandType = CommandType.StoredProcedure

            _prmZipCode = _scSC.Parameters.Add("@ZipCode", System.Data.SqlDbType.VarChar, 5)
            _prmZipCode.Direction = ParameterDirection.Input
            _prmZipCode.Value = ZipCode

            _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
            _prmCustomerNumber.Direction = ParameterDirection.Input
            _prmCustomerNumber.Value = CustomerNumber

            _prmDeliveryType = _scSC.Parameters.Add("@DeliveryType", System.Data.SqlDbType.VarChar, 1)
            _prmDeliveryType.Direction = ParameterDirection.Output


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            sDeliveryType = _scSC.Parameters("@DeliveryType").Value

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            GetShipmentDeliveryType = sDeliveryType



        End Function
        Public Function GetItemDescription(ByVal Item As String) As String

            Dim sSP As String = "GetItemDescription_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmItem As New SqlParameter
            Dim _prmDescription As New SqlParameter

            Dim sDescription As String = String.Empty

            _scSC.CommandType = CommandType.StoredProcedure

            _prmItem = _scSC.Parameters.Add("@Item", System.Data.SqlDbType.VarChar, 5)
            _prmItem.Direction = ParameterDirection.Input
            _prmItem.Value = Item


            _prmDescription = _scSC.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 110)
            _prmDescription.Direction = ParameterDirection.Output


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            sDescription = CType(_scSC.Parameters("@Description").Value, String)

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            GetItemDescription = sDescription



        End Function
        Public Function WebGetTaxRate(ByVal CustomerNumber As String, ByVal idt As String) As Decimal
            Dim sSP As String = "WebGetTaxRate_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmIdt As New SqlParameter
            Dim _prmTax As New SqlParameter

            Dim dTax As Decimal

            _scSC.CommandType = CommandType.StoredProcedure

            _prmCustomerNumber = _scSC.Parameters.Add("@CustomerNumber", System.Data.SqlDbType.Char, 100)
            _prmCustomerNumber.Direction = ParameterDirection.Input
            _prmCustomerNumber.Value = CustomerNumber

            _prmIdt = _scSC.Parameters.Add("@Idt", System.Data.SqlDbType.Char, 6)
            _prmIdt.Direction = ParameterDirection.Input
            _prmIdt.Value = idt


            _prmTax = _scSC.Parameters.Add("@TaxRateOut", System.Data.SqlDbType.Float, 10)
            _prmTax.Direction = ParameterDirection.Output


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            dTax = Convert.ToDecimal(_scSC.Parameters("@TaxRateOut").Value)

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            WebGetTaxRate = dTax

        End Function
        Private Function GetUPS(ByVal iQty As Int16, ByVal sZipCode As String, ByVal nInvAmount As Decimal, ByVal sShipType As String, ByVal sCompany As String) As Decimal
            Dim sSP As String = "GetUPS_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmQty As New SqlParameter
            Dim _prmZipCode As New SqlParameter
            Dim _prmUPS As New SqlParameter
            Dim _prmShipType As New SqlParameter
            Dim _prmCompany As New SqlParameter
            Dim _prmInvAmount As New SqlParameter
            Dim dUPS As Decimal

            _scSC.CommandType = CommandType.StoredProcedure
            _prmQty = _scSC.Parameters.Add("@Qty", System.Data.SqlDbType.Int, 5)
            _prmQty.Direction = ParameterDirection.Input
            _prmQty.Value = iQty

            _prmZipCode = _scSC.Parameters.Add("@ZipCode", System.Data.SqlDbType.Char, 3)
            _prmZipCode.Direction = ParameterDirection.Input
            _prmZipCode.Value = sZipCode

            _prmShipType = _scSC.Parameters.Add("@ShipType", System.Data.SqlDbType.Char, 1)
            _prmShipType.Direction = ParameterDirection.Input
            _prmShipType.Value = sShipType

            _prmCompany = _scSC.Parameters.Add("@Company", System.Data.SqlDbType.Char, 3)
            _prmCompany.Direction = ParameterDirection.Input
            _prmCompany.Value = sCompany

            _prmUPS = _scSC.Parameters.Add("@UPS", System.Data.SqlDbType.Float, 10)
            _prmUPS.Direction = ParameterDirection.Output

            _prmInvAmount = _scSC.Parameters.Add("@InvAmount", System.Data.SqlDbType.Decimal, 10)
            _prmInvAmount.Direction = ParameterDirection.Input
            _prmInvAmount.Value = nInvAmount


            _scSC.Connection.Open()

            _scSC.ExecuteNonQuery()

            dUPS = Convert.ToDecimal(_scSC.Parameters("@UPS").Value)

            If _scSC.Connection.State = ConnectionState.Open Then
                _scSC.Connection.Close()
            End If

            GetUPS = dUPS

        End Function
        Public Function dCalcUPS(ByVal iQty As Int16, ByVal sZipCode As String, ByVal nInvAmount As Decimal, ByVal sShipType As String, ByVal sCompany As String) As Decimal
            Dim _iShipBottleCount As Int32
            Dim _dHandingCharge As Decimal
            Dim _dUPS As Decimal

            If (sZipCode >= "100" And sZipCode <= "149") And nInvAmount >= 150 Then
                _dHandingCharge = 0
            Else
                _iShipBottleCount = Decimal.Floor((iQty + 5) / 6) * 6
                _dHandingCharge = _iShipBottleCount * 1.0
            End If

            _dUPS = GetUPS(iQty, sZipCode, nInvAmount, sShipType, sCompany)

            dCalcUPS = Decimal.Round((_dUPS + _dHandingCharge), 2)

        End Function
        Public Sub MigrateShoppingCartItems(ByVal currentShopperNumber As String, ByVal migrateShopperNumber As String)

            Dim sSP As String = "MigrateShoppingCartItems_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@currentShopperNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = currentShopperNumber
                    .Add(New SqlParameter("@migrateShopperNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = migrateShopperNumber
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

        Public Sub DeleteShoppingCartItem(ByVal shoppingcartid As Int32)

            Dim sSP As String = "DeleteShoppingCartItem_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@shoppingcartid", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = shoppingcartid
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception
                    Throw

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With


        End Sub
       
        Public Sub ResetShoppingCart(ByVal currentShopperNumber As String)

            Dim sSP As String = "ResetShoppingCart_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@currentShopperNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = currentShopperNumber
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception
                    Throw

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With


        End Sub
        Public Sub ResetShoppingCartMerge(ByVal currentShopperNumber As String)

            Dim sSP As String = "ResetShoppingCartMerge_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@currentShopperNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = currentShopperNumber
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

        Public Function GetShoppingCartItem(ByVal customerNumber As String, ByVal item As String, ByVal unittype As String) As DataSet

            Dim sSP As String = "GetShoppingCartItem_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                    .Add(New SqlParameter("@item", SqlDbType.VarChar, 50, ParameterDirection.Input)).Value = item
                    .Add(New SqlParameter("@unittype", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = unittype
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
       
        Public Function CheckCartForWineClub(ByVal CustomerNumber As String, ByVal Item As String) As Boolean
            Dim sSP As String = "CheckCartForWineClub_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bExists As Boolean = False
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmItem As New SqlParameter
            Dim _prmExists As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure
                    _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Value = CustomerNumber
                    _prmCustomerNumber.Direction = ParameterDirection.Input

                    _prmItem = .Parameters.Add("@Item", System.Data.SqlDbType.VarChar, 5)
                    _prmItem.Value = Item
                    _prmItem.Direction = ParameterDirection.Input


                    _prmExists = .Parameters.Add("@Exists", System.Data.SqlDbType.Bit, 10)
                    _prmExists.Direction = ParameterDirection.Output
                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bExists = .Parameters("@Exists").Value

                Catch ex As Exception
                    Throw ex

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bExists

        End Function
        Public Function CheckShipDateInCart(ByVal CustomerNumber As String) As Boolean
            Dim sSP As String = "CheckShipDateInCart_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bDateOK As Boolean = False
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmDateOK As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure
                    _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Value = CustomerNumber
                    _prmCustomerNumber.Direction = ParameterDirection.Input


                    _prmDateOK = .Parameters.Add("@DateOK", System.Data.SqlDbType.Bit, 10)
                    _prmDateOK.Direction = ParameterDirection.Output
                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bDateOK = .Parameters("@DateOK").Value

                Catch ex As Exception
                    Throw

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bDateOK

        End Function
        Public Function OrderHasSpirits(ByVal CustomerNumber As String) As Boolean
            Dim sSP As String = "OrderHasSpirits_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bExists As Boolean = False
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmExists As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure
                    _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Value = CustomerNumber
                    _prmCustomerNumber.Direction = ParameterDirection.Input

                    _prmExists = .Parameters.Add("@Exists", System.Data.SqlDbType.Bit, 1)
                    _prmExists.Direction = ParameterDirection.Output
                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bExists = CType(.Parameters("@Exists").Value, Boolean)

                Catch ex As Exception
                    Throw

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bExists

        End Function
        Public Function OrderHasSpiritsAstorTruckOnly(ByVal CustomerNumber As String, ByVal ZipCode As String) As Boolean
            Dim sSP As String = "OrderHasSpiritsAstorTruckOnly_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bExists As Boolean = False
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmZipCode As New SqlParameter
            Dim _prmExists As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure
                    _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Value = CustomerNumber
                    _prmCustomerNumber.Direction = ParameterDirection.Input

                    _prmZipCode = .Parameters.Add("@ZipCode", System.Data.SqlDbType.VarChar, 5)
                    _prmZipCode.Value = ZipCode
                    _prmZipCode.Direction = ParameterDirection.Input

                    _prmExists = .Parameters.Add("@Exists", System.Data.SqlDbType.Bit, 1)
                    _prmExists.Direction = ParameterDirection.Output
                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bExists = CType(.Parameters("@Exists").Value, Boolean)

                Catch ex As Exception
                    Throw

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bExists

        End Function
        Public Function OrderHasSpiritsAndNonDeliveryZone(ByVal CustomerNumber As String, ByVal ZipCode As String) As Boolean
            Dim sSP As String = "OrderHasSpiritsAndNonDeliveryZone_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bExists As Boolean = False
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmZipCode As New SqlParameter
            Dim _prmExists As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure
                    _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Value = CustomerNumber
                    _prmCustomerNumber.Direction = ParameterDirection.Input

                    _prmZipCode = .Parameters.Add("@ZipCode", System.Data.SqlDbType.VarChar, 5)
                    _prmZipCode.Value = ZipCode
                    _prmZipCode.Direction = ParameterDirection.Input

                    _prmExists = .Parameters.Add("@Exists", System.Data.SqlDbType.Bit, 1)
                    _prmExists.Direction = ParameterDirection.Output
                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bExists = .Parameters("@Exists").Value

                Catch ex As Exception
                    Throw

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bExists

        End Function
        Public Function CheckCartForPreviousItems(ByVal CustomerNumber As String) As Boolean
            Dim sSP As String = "CheckCartForPreviousItems_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _bExists As Boolean = False
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmItem As New SqlParameter
            Dim _prmExists As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure
                    _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Value = CustomerNumber
                    _prmCustomerNumber.Direction = ParameterDirection.Input


                    _prmExists = .Parameters.Add("@Exists", System.Data.SqlDbType.Bit, 10)
                    _prmExists.Direction = ParameterDirection.Output
                    .Connection.Open()
                    .ExecuteNonQuery()

                    _bExists = .Parameters("@Exists").Value

                Catch ex As Exception
                    Throw ex

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _bExists

        End Function
        Public Function GetShoppingCartItems(ByVal customerNumber As String, ByVal AOStype As String) As DataSet

            Dim sSP As String = "GetShoppingCartItems_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                    .Add(New SqlParameter("@AOStype", SqlDbType.VarChar, 2, ParameterDirection.Input)).Value = AOStype
                End With

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
        Public Function GetShoppingCartAOSItems(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartAOSItems_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                End With

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
        Public Function GetShoppingCartMergeItems(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartMergeItems_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function ShoppingCartItemsCount(ByVal customerNumber As String) As Int16

            Dim sSP As String = "ShoppingCartItemsCount_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _iItemCount As Int16 = 0
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmItemCount As New SqlParameter

            With _scSC
                Try


                    .CommandType = CommandType.StoredProcedure
                    _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Value = customerNumber
                    _prmCustomerNumber.Direction = ParameterDirection.Input

                    _prmItemCount = .Parameters.Add("@ItemCount", System.Data.SqlDbType.Int, 10)
                    _prmItemCount.Direction = ParameterDirection.Output
                    .Connection.Open()
                    .ExecuteNonQuery()

                    _iItemCount = .Parameters("@ItemCount").Value

                Catch ex As Exception
                    Throw ex

                Finally

                End Try
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End With

            Return _iItemCount

        End Function
        Public Function GetShoppingCartCustInfo(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartCustInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function GetShoppingCartCustInfoFormatted(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartCustInfoFormatted062014_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function GetShoppingCartCustShippingInfoFormatted(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartCustShippingInfoFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function GetShoppingCartCustBillingInfoFormatted(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartCustBillingInfoFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function GetShoppingCartCcInfo(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartCcInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function GetShoppingCartCcInfoFormatted(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartCcInfoFormatted_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function GetShoppingCartGiftCardInfo(ByVal customerNumber As String) As DataSet

            Dim sSP As String = "GetShoppingCartGiftCardInfo_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
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
        Public Function GetOrderValueForCart(ByVal customerNumber As String) As Double

            Dim sSP As String = "GetOrderValueForCart_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim totalvalue As Decimal

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@customerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                    .Add(New SqlParameter("@totalvalue", SqlDbType.Decimal, 10, ParameterDirection.Output)).Value = totalvalue
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()
                    totalvalue = _scSC.Parameters("@totalvalue").Value

                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With

            Return totalvalue

        End Function
        Public Function GetPromoValueForCart(ByVal CustomerNumber As String, ByVal PromoCode As String) As Double

            Dim sSP As String = "CalcPromoCode_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim Promovalue As Double
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmPromoCode As New SqlParameter
            Dim _prmPromoValue As New SqlParameter


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters

                    _prmCustomerNumber = .Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                    _prmCustomerNumber.Direction = ParameterDirection.Input
                    _prmCustomerNumber.Value = CustomerNumber
                    _prmPromoCode = .Add("@PromoCode", System.Data.SqlDbType.VarChar, 50)
                    _prmPromoCode.Direction = ParameterDirection.Input
                    _prmPromoCode.Value = PromoCode
                    _prmPromoValue = .Add("@PromoValue", System.Data.SqlDbType.Float, 9)
                    _prmPromoValue.Direction = ParameterDirection.Output

                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()
                    Promovalue = _scSC.Parameters("@promovalue").Value

                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With

            Return Promovalue

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


    End Class

End Namespace


