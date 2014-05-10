Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class AstorCheckoutBillingNewCustomer
    Inherits WebPageBase
    Private Cust As New AstorwinesCommerce.Customer(getConnStr())
    Private Cart As New AstorwinesCommerce.CartDB(getConnStr())
    Private dsCust As New DataSet
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Cart.CheckCartForPreviousItems(GetCustomerID(Request, Response)) Then
                Response.Redirect("~/secure/ShoppingCartMerge.aspx")
            End If

            If Cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then
                '                Redirect("~/secure/AstorCheckoutBilling.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
                Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
            End If
        End If
    End Sub

    Private Sub Confirm_Order()

        Dim sMsgBill As String = "Please correct errors on form! "
        If WUCBillingNameEdit1.Visible = True Then
            If WUCBillingNameEdit1.bValidateBillingInfo() Then
                Dim _webutils As New WebUtils
                Dim t As Type = Me.GetType

                _webutils.CreateMessageAlert(Me, t, sMsgBill, "strKey2")
                Exit Sub
            End If
        End If
        If WUCCreditCardEdit1.Visible = True Then
            Dim sMsg As String = "Please correct errors on form! "
            If WUCCreditCardEdit1.bValidateCC(sMsg) Then
                Dim _webutils As New WebUtils
                Dim t As Type = Me.GetType

                _webutils.CreateMessageAlert(Me, t, sMsg, "strKey2")
                Exit Sub
            End If
        End If


        SaveCustomerCartBilling()
        SaveCustomerCartCC()

        If WUCGiftCardEdit1.GiftCardNumber <> "" And (WUCGiftCardEdit1.GiftCardNumber.Length = 16 Or WUCGiftCardEdit1.GiftCardNumber.Length = 19) And IsNumeric(WUCGiftCardEdit1.GiftCardPresentValue) Then

            SaveCustomerGiftCard()
        Else
            DeleteCustomerGiftCard()
        End If

        Dim sIdtNew As String = String.Empty

        sIdtNew = WUCBillingNameEdit1.BillingIdtNew
        If RTrim(sIdtNew) <> "" Then
            'Redirect("~/secure/AstorCheckoutShipping.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
            Response.Redirect("~/secure/AstorCheckoutShipping.aspx")
        Else
            'Redirect("~/secure/AstorCheckoutShippingNewCustomer.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
            'Response.Redirect("~/secure/AstorCheckoutShippingNewCustomer.aspx")
            Response.Redirect("~/secure/AstorCheckoutShipping.aspx")
        End If




    End Sub
    Private Sub DeleteCustomerGiftCard()

        Cart.DeleteShoppingCartGiftCardInfo(GetCustomerID(Request, Response))


    End Sub
    Private Sub SaveCustomerCartBilling()
        Dim hstCustomerInfo As New Hashtable
        Dim sIdtNew As String

        sIdtNew = WUCBillingNameEdit1.BillingIdtNew

        With hstCustomerInfo
            .Item("CustomerNumber") = GetCustomerID(Request, Response)
            .Item("NewIdt") = sIdtNew
            .Item("FirstName") = WUCBillingNameEdit1.BillingFirstName
            .Item("LastName") = WUCBillingNameEdit1.BillingLastName
            .Item("Company") = WUCBillingNameEdit1.BillingCompany
            .Item("Address") = WUCBillingNameEdit1.BillingAddress
            .Item("Apt") = WUCBillingNameEdit1.BillingApt
            .Item("City") = WUCBillingNameEdit1.BillingCity
            .Item("State") = WUCBillingNameEdit1.BillingState
            .Item("ZipCode") = WUCBillingNameEdit1.BillingZipCode
            .Item("Country") = "USA"
            .Item("DayPhone") = WUCBillingNameEdit1.BillingDayPhone
            .Item("EveningPhone") = WUCBillingNameEdit1.BillingEveningPhone
            '            .Item("bMailingList") = WUCBillingNameEdit1.MailingList
            .Item("bMailingList") = False


        End With

        Cart.UpdateShoppingCartCustInfoBilling(hstCustomerInfo)
        'Cust.UpdateCustomerShipTo(hstCustomerInfo)

    End Sub

    Private Sub SaveCustomerCartCC()
        Dim hstCustomerCCInfo As New Hashtable
        Dim sIdtNew As String

        sIdtNew = WUCBillingNameEdit1.BillingIdtNew

        With hstCustomerCCInfo
            .Item("CustomerNumber") = GetCustomerID(Request, Response)
            .Item("cctype") = WUCCreditCardEdit1.CCTypeValue
            .Item("ccnum") = WUCCreditCardEdit1.CreditCardNumValue
            .Item("ccdatemm") = WUCCreditCardEdit1.CCMMValue
            .Item("ccdateyyyy") = WUCCreditCardEdit1.CCYYYYValue
            .Item("cvv") = WUCCreditCardEdit1.CVVValue
            .Item("ccName") = WUCCreditCardEdit1.CCNameValue
            .Item("ccRowid") = 0
            .Item("ccRowIDU") = String.Empty
            .Item("ccDefault") = 1
        End With

        Cart.UpdateShoppingCartCCInfo(hstCustomerCCInfo)

    End Sub
    Private Sub SaveCustomerGiftCard()
        Dim GiftCardPresentValue As String
        'Dim _cAstorCommon As New cAstorCommon

        GiftCardPresentValue = GetGiftCardBalance(WUCGiftCardEdit1.GiftCardNumber)

        If Not IsNumeric(GiftCardPresentValue) Then

        Else
            Cart.UpdateShoppingCartGiftCardInfo(GetCustomerID, WUCGiftCardEdit1.GiftCardNumber, GiftCardPresentValue)
        End If


    End Sub
    Private Function GetGiftCardBalance(ByVal CardNumber As String) As String


        Dim CKey As String = Application("CLIENT_KEY")
        Dim TID As String = Application("TERMINAL_ID")
        Dim MID As String = Application("MERCHANT_ID")
        Dim LID As String = Application("LOCATION_ID")
        Dim _oAstorCommon As New cAstorCommon

        Dim sBalance As String = String.Empty

        sBalance = _oAstorCommon.GetGiftCardBalance(CardNumber, CKey, TID, MID, LID)

        Return sBalance


    End Function
    Private Sub PopulateCustomerMatch()
        Dim _LastnameMatch As String = txtMatchMeLastname.Text
        Dim _PhoneMatch As String = txtMatchMePhone.Text
        dsCust = Cust.MatchCustomerInfo(_LastnameMatch, _PhoneMatch)

        With dsCust.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    WUCBillingNameEdit1.BillingLastName = .Item("LastName")
                    WUCBillingNameEdit1.BillingFirstName = .Item("FirstName")
                    WUCBillingNameEdit1.BillingIdtNew = .Item("Idt")
                    If .Item("Company") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingCompany = String.Empty
                    Else
                        WUCBillingNameEdit1.BillingCompany = .Item("Company")
                    End If
                    If .Item("Address") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingAddress = String.Empty
                    Else
                        WUCBillingNameEdit1.BillingAddress = .Item("Address")
                    End If
                    If .Item("Apt") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingApt = String.Empty
                    Else
                        WUCBillingNameEdit1.BillingApt = .Item("Apt")
                    End If
                    If .Item("City") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingCity = String.Empty
                    Else
                        WUCBillingNameEdit1.BillingCity = .Item("City")
                    End If
                    If .Item("State") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingState = -1
                    Else
                        WUCBillingNameEdit1.BillingState = .Item("State")
                    End If
                    If .Item("ZipCode") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingZipCode = String.Empty
                    Else
                        WUCBillingNameEdit1.BillingZipCode = .Item("ZipCode")
                    End If
                    If .Item("DayPhone") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingDayPhone = String.Empty
                    Else
                        WUCBillingNameEdit1.BillingDayPhone = .Item("DayPhone")
                    End If
                    If .Item("EveningPhone") Is DBNull.Value Then
                        WUCBillingNameEdit1.BillingEveningPhone = String.Empty
                    Else
                        WUCBillingNameEdit1.BillingEveningPhone = .Item("EveningPhone")
                    End If
                    ' WUCBillingNameEdit1.MailingList = .Item("bMailingList")
                End With
            Else
                Dim _webutils As New WebUtils
                Dim t As Type = Me.GetType

                _webutils.CreateMessageAlert(Me, t, "No Match Found!", "strKey2")
            End If
        End With

    End Sub

    Private Sub ResetCustomerMatch()
        With WUCBillingNameEdit1
            .BillingFirstName = String.Empty
            .BillingLastName = String.Empty
            .BillingIdtNew = String.Empty
            .BillingCompany = String.Empty
            .BillingAddress = String.Empty
            .BillingApt = String.Empty
            .BillingCity = String.Empty
            .BillingState = -1
            .BillingZipCode = String.Empty
            .BillingDayPhone = String.Empty
            .BillingEveningPhone = String.Empty
            '    .MailingList = False
        End With

    End Sub

    Protected Sub imgbMatchMe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbMatchMe.Click
        PopulateCustomerMatch()
    End Sub

   
    Protected Sub imgbContinueCheckoutT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbContinueCheckoutB.Click
        Confirm_Order()
    End Sub

    
    Protected Sub imgbNotMe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbNotMe.Click
        ResetCustomerMatch()
    End Sub

    
End Class
