Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_AstorCheckoutBilling
    Inherits WebPageBase
    Private Cust As New AstorwinesCommerce.Customer(getConnStr())
    Private Cart As New AstorwinesCommerce.CartDB(getConnStr())
    Private dsCust As New DataSet
    Private dsCC As New DataSet
    Private dsGiftCard As New DataSet
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Cart.CheckCartForPreviousItems(GetCustomerID(Request, Response)) Then
                Response.Redirect("~/secure/ShoppingCartMerge.aspx")
            End If


            dsCust = Cart.GetShoppingCartCustBillingInfoFormatted(GetCustomerID(Request, Response))
            If dsCust.Tables.Count > 0 Then
                If dsCust.Tables(0).Rows.Count > 0 Then
                    WUCBillingName1.Visible = True
                    WUCBillingNameEdit1.Visible = False
                    lnkbEditBilling.Visible = True
                    PopulateCustomerBillingCurrent()
                Else
                    dsCust = Cust.GetCustomerInfoFormatted(GetCustomerID(Request, Response), String.Empty)
                    If dsCust.Tables.Count > 0 Then
                        If dsCust.Tables(0).Rows.Count > 0 Then
                            WUCBillingName1.Visible = True
                            WUCBillingNameEdit1.Visible = False
                            lnkbEditBilling.Visible = True
                            PopulateCustomerBillingCurrent()
                        Else
                            WUCBillingName1.Visible = False
                            WUCBillingNameEdit1.Visible = True
                            lnkbEditBilling.Visible = False
                        End If
                    Else
                        WUCBillingName1.Visible = False
                        WUCBillingNameEdit1.Visible = True
                        lnkbEditBilling.Visible = False
                    End If
                End If
            Else
                dsCust = Cust.GetCustomerInfoFormatted(GetCustomerID(Request, Response), String.Empty)
                If dsCust.Tables.Count > 0 Then
                    If dsCust.Tables(0).Rows.Count > 0 Then
                        WUCBillingName1.Visible = True
                        WUCBillingNameEdit1.Visible = False
                        lnkbEditBilling.Visible = True
                        PopulateCustomerBillingCurrent()
                    Else
                        WUCBillingName1.Visible = False
                        WUCBillingNameEdit1.Visible = True
                        lnkbEditBilling.Visible = False
                    End If
                Else
                    WUCBillingName1.Visible = False
                    WUCBillingNameEdit1.Visible = True
                    lnkbEditBilling.Visible = False
                End If
            End If

            dsCC = Cart.GetShoppingCartCcInfoFormatted(GetCustomerID(Request, Response))
            If dsCC.Tables.Count > 0 Then
                If dsCC.Tables(0).Rows.Count > 0 Then
                    WUCCreditCard1.Visible = True
                    WUCCreditCardEdit1.Visible = False
                    PopulateCustomerCreditCardCurrent()
                    ddlCreditCard.Visible = True
                    lblLCC.Visible = True
                    lnkbAddCreditCard.Visible = True
                    lnkbDeleteCreditCard.Visible = True
                    LoadCCCombo()
                Else
                    dsCC = Cust.GetCCInfoFormatted(GetCustomerID(Request, Response), String.Empty, 0, "", True)
                    If dsCC.Tables.Count > 0 Then
                        If dsCC.Tables(0).Rows.Count > 0 Then

                            WUCCreditCard1.Visible = True
                            WUCCreditCardEdit1.Visible = False
                            PopulateCustomerCreditCardCurrent()
                            ddlCreditCard.Visible = True
                            lblLCC.Visible = True
                            lnkbAddCreditCard.Visible = True
                            lnkbDeleteCreditCard.Visible = True
                            LoadCCCombo()
                        Else
                            WUCCreditCard1.Visible = False
                            WUCCreditCardEdit1.Visible = True
                            ddlCreditCard.Visible = False
                            lblLCC.Visible = False
                            lnkbAddCreditCard.Visible = False
                            lnkbDeleteCreditCard.Visible = False
                        End If
                    Else
                        WUCCreditCard1.Visible = False
                        WUCCreditCardEdit1.Visible = True
                        ddlCreditCard.Visible = False
                        lblLCC.Visible = False
                        lnkbAddCreditCard.Visible = False
                        lnkbDeleteCreditCard.Visible = False
                    End If
                End If
            Else
                dsCC = Cust.GetCCInfoFormatted(GetCustomerID(Request, Response), String.Empty, 0, "", True)
                If dsCC.Tables.Count > 0 Then
                    If dsCC.Tables(0).Rows.Count > 0 Then

                        WUCCreditCard1.Visible = True
                        WUCCreditCardEdit1.Visible = False
                        PopulateCustomerCreditCardCurrent()
                        ddlCreditCard.Visible = True
                        lblLCC.Visible = True
                        lnkbAddCreditCard.Visible = True
                        lnkbDeleteCreditCard.Visible = True
                        LoadCCCombo()
                    Else
                        WUCCreditCard1.Visible = False
                        WUCCreditCardEdit1.Visible = True
                        ddlCreditCard.Visible = False
                        lblLCC.Visible = False
                        lnkbAddCreditCard.Visible = False
                        lnkbDeleteCreditCard.Visible = False
                    End If
                Else
                    WUCCreditCard1.Visible = False
                    WUCCreditCardEdit1.Visible = True
                    ddlCreditCard.Visible = False
                    lblLCC.Visible = False
                    lnkbAddCreditCard.Visible = False
                    lnkbDeleteCreditCard.Visible = False
                End If

            End If


            dsGiftCard = Cart.GetShoppingCartGiftCardInfo(GetCustomerID(Request, Response))
            If dsGiftCard.Tables.Count > 0 Then
                If dsGiftCard.Tables(0).Rows.Count > 0 Then
                    With dsGiftCard.Tables(0).Rows(0)
                        WUCGiftCardEdit1.GiftCardNumber = .Item("GiftCardNumber")
                    End With
                End If
            End If

        End If

    End Sub
    Private Sub Confirm_Order()
        Try
            Dim sMsgBill As String = "Please correct errors on form! "
            If WUCBillingNameEdit1.Visible = True Then
                If WUCBillingNameEdit1.bValidateBillingInfo() Then
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    _webutils.CreateMessageAlert(Me, t, sMsgBill, "strKey2")
                    Exit Sub
                End If
            End If

            If WUCCreditCard1.Visible = True Then
                If WUCCreditCard1.bValidateCC Then
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    _webutils.CreateMessageAlert(Me, t, "Please correct errors on form!", "strKey2")
                    Exit Sub
                End If
            ElseIf WUCCreditCardEdit1.Visible = True Then
                Dim sMsg As String = "Please correct errors on form! "
                If WUCCreditCardEdit1.bValidateCC(sMsg) Then
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    _webutils.CreateMessageAlert(Me, t, sMsg, "strKey2")
                    Exit Sub
                End If
            End If

            'If WUCGiftCardEdit1.GiftCardNumber <> "" And WUCGiftCardEdit1.GiftCardPresentValue = "Not Retreived" Then
            '    Dim sMsg As String = "Please retreive gift card balance! " & vbCrLf & ""

            '    Dim _webutils As New WebUtils
            '    Dim t As Type = Me.GetType

            '    _webutils.CreateMessageAlert(Me, t, sMsg, "strKey2")
            '    Exit Sub

            'End If

            If WUCBillingNameEdit1.Visible = True Then
                SaveCustomerCartBilling()
            Else
                SaveCustomerCartBillingCurrent()

            End If
            If WUCCreditCardEdit1.Visible = True Then
                SaveCustomerCartCC()
            Else
                SaveCustomerCartCCCurrent()
            End If

            If WUCGiftCardEdit1.GiftCardNumber <> "" And (WUCGiftCardEdit1.GiftCardNumber.Length = 16 Or WUCGiftCardEdit1.GiftCardNumber.Length = 19) And IsNumeric(WUCGiftCardEdit1.GiftCardPresentValue) Then

                SaveCustomerGiftCard()
            Else
                DeleteCustomerGiftCard()
            End If

            Dim cust As New AstorwinesCommerce.Customer(getConnStr())
            If cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then
                'Redirect("~/secure/AstorCheckoutShipping.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
                Response.Redirect("~/secure/AstorCheckoutShipping.aspx")
            Else
                'Redirect("~/secure/AstorCheckoutShippingNewCustomer.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
                Response.Redirect("~/secure/AstorCheckoutShippingNewCustomer.aspx")
            End If


        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Sub


    Private Sub PopulateCustomerBillingCurrent()
        With dsCust.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    WUCBillingName1.BillingName = .Item("Name")
                    WUCBillingName1.BillingEmail = GetCustomerID(Request, Response)
                    If .Item("Company") Is DBNull.Value Then
                        WUCBillingName1.BillingCompany = String.Empty
                    Else
                        WUCBillingName1.BillingCompany = .Item("Company")
                    End If
                    If .Item("AddressApt") Is DBNull.Value Then
                        WUCBillingName1.BillingAddressApt = String.Empty
                    Else
                        WUCBillingName1.BillingAddressApt = .Item("AddressApt")
                    End If

                    If .Item("CityStateZipcode") Is DBNull.Value Then
                        WUCBillingName1.BillingCityStateZipcode = String.Empty
                    Else
                        WUCBillingName1.BillingCityStateZipcode = .Item("CityStateZipcode")
                    End If
                    If .Item("DayPhone") Is DBNull.Value Then
                        WUCBillingName1.BillingDayPhone = String.Empty
                    Else
                        WUCBillingName1.BillingDayPhone = .Item("DayPhone")
                    End If
                    If .Item("EveningPhone") Is DBNull.Value Then
                        WUCBillingName1.BillingEveningPhone = String.Empty
                    Else
                        WUCBillingName1.BillingEveningPhone = .Item("EveningPhone")
                    End If
                    '  WUCBillingName1.MailingList = .Item("bMailingList")
                End With
            End If
        End With

    End Sub
    Private Sub PopulateCustomerCreditCardCurrent()
        With dsCC.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    WUCCreditCard1.CCNameValue = .Item("ccName")
                    WUCCreditCard1.CCRowIDValue = .Item("ccrowid")
                    WUCCreditCard1.CCTypeValue = .Item("cctype")
                    WUCCreditCard1.CreditCardNumValue = .Item("ccnum")
                    WUCCreditCard1.CCYYYYValue = .Item("ccdateyy")
                    WUCCreditCard1.CCMMValue = .Item("ccdatemm")
                    WUCCreditCard1.CVVValue = String.Empty
                    WUCCreditCard1.CCRowIDUValue = .Item("ccRowIDU").ToString

                    WUCCreditCard1.CreditCardDefault = .Item("bDefault")


                End With
            End If
        End With

    End Sub

    Private Sub LoadCCCombo()

        Dim dsCustCC As New DataSet
        'load cc
        dsCustCC = Cust.GetAllCustomersCCInfo(GetCustomerID(Request, Response), String.Empty)
        With dsCustCC
            If .Tables.Count > 0 Then
                With .Tables(0)
                    If .Rows.Count > 0 Then
                        With ddlCreditCard
                            .DataSource = dsCustCC.Tables(0)
                            .DataMember = ""
                            .DataValueField = "ccrowid"
                            .DataTextField = "cctypeDesc"
                            .DataBind()
                        End With
                    End If
                End With
            End If
        End With
    End Sub
    Private Sub SaveCustomerCartBillingCurrent()

        Cart.UpdateShoppingCartCustInfoBilling(GetCustomerID(Request, Response), String.Empty)

    End Sub
    Private Sub SaveCustomerCartCCCurrent()
        Dim ccRowID As Int32 = WUCCreditCard1.CCRowIDValue
        Dim ccRowIDU As String = WUCCreditCard1.CCRowIDUValue
        Dim ccCVV As String = WUCCreditCard1.CVVValue

        Cart.UpdateShoppingCartCCInfo(GetCustomerID(Request, Response), String.Empty, ccRowID, ccRowIDU, ccCVV)

    End Sub
    Private Sub SaveCustomerCartBilling()
        Dim hstCustomerInfo As New Hashtable
        Dim sIdtNew As String

        sIdtNew = WUCBillingNameEdit1.BillingIdtNew

        With hstCustomerInfo
            .Item("CustomerNumber") = GetCustomerID(Request, Response)
            .Item("NewIdt") = String.Empty
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
            .Item("ccDefault") = WUCCreditCardEdit1.CreditCardDefault
        End With

        Cart.UpdateShoppingCartCCInfo(hstCustomerCCInfo)

    End Sub
    Private Sub SaveCustomerGiftCard()
        Dim GiftCardPresentValue As String
        ' Dim _cAstorCommon As New cAstorCommon

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
    Private Sub DeleteCustomerGiftCard()

        Cart.DeleteShoppingCartGiftCardInfo(GetCustomerID(Request, Response))


    End Sub
    Private Sub ChangeToEditBilling()
        dsCust = Cust.GetCustomerInfoFormatted(GetCustomerID(Request, Response), String.Empty)
        If dsCust.Tables.Count > 0 Then
            WUCBillingName1.Visible = False
            WUCBillingNameEdit1.Visible = True
            lnkbEditBilling.Visible = False
            PopulateCustomerBilling()
            'Else
            '    WUCBillingName1.Visible = False
            '    WUCBillingNameEdit1.Visible = True
        End If

    End Sub
    Private Sub DeleteCreditCard()
        Dim ccRowID As Int32 = WUCCreditCard1.CCRowIDValue
        Dim ccRowIDU As String = WUCCreditCard1.CCRowIDUValue

        Cust.DeleteCustomerCCInfo(GetCustomerID(Request, Response), String.Empty, ccRowID, ccRowIDU)
    End Sub
    Private Sub ChangeCreditCard()
        Dim iCardID As Int32

        iCardID = ddlCreditCard.SelectedValue

        dsCC = Cust.GetCCInfoFormatted(GetCustomerID(Request, Response), String.Empty, iCardID, "", False)
        If dsCC.Tables.Count > 0 Then
            If dsCC.Tables(0).Rows.Count > 0 Then

                WUCCreditCard1.Visible = True
                WUCCreditCardEdit1.Visible = False
                PopulateCustomerCreditCardCurrent()
                ddlCreditCard.Visible = True
                lblLCC.Visible = True
                lnkbAddCreditCard.Visible = True
                lnkbDeleteCreditCard.Visible = True
            Else
                WUCCreditCard1.Visible = False
                WUCCreditCardEdit1.Visible = True
                ddlCreditCard.Visible = False
                lblLCC.Visible = False
                lnkbAddCreditCard.Visible = False
                lnkbDeleteCreditCard.Visible = False
            End If
        Else
            WUCCreditCard1.Visible = False
            WUCCreditCardEdit1.Visible = True
            ddlCreditCard.Visible = False
            lblLCC.Visible = False
            lnkbAddCreditCard.Visible = False
            lnkbDeleteCreditCard.Visible = False
        End If
    End Sub
    Private Sub PopulateCustomerBilling()

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
                        WUCBillingNameEdit1.LoadCity(.Item("ZipCode"), String.Empty)
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
                    'WUCBillingNameEdit1.MailingList = .Item("bMailingList")
                End With
            End If
        End With

    End Sub

    'Protected Sub imgbContinueCheckoutTop_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbContinueCheckoutTop.Click, imgbContinueCheckoutBottom.Click
    '    Confirm_Order()
    'End Sub

    Protected Sub lnkbEditBilling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbEditBilling.Click
        dsCust = Cust.GetCustomerInfo(GetCustomerID(Request, Response), String.Empty)
        If dsCust.Tables.Count > 0 Then
            WUCBillingName1.Visible = False
            WUCBillingNameEdit1.Visible = True
            lnkbEditBilling.Visible = False
            PopulateCustomerBilling()
            'Else
            '    WUCBillingName1.Visible = True
            '    WUCBillingNameEdit1.Visible = False
        End If
    End Sub


    Protected Sub ddlCreditCard_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCreditCard.SelectedIndexChanged
        ChangeCreditCard()
    End Sub

    Protected Sub lnkbAddCreditCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbAddCreditCard.Click
        WUCCreditCard1.Visible = False
        WUCCreditCardEdit1.Visible = True
        ddlCreditCard.Visible = False
        lblLCC.Visible = False
        lnkbAddCreditCard.Visible = False
        lnkbDeleteCreditCard.Visible = False
    End Sub

    Protected Sub lnkbDeleteCreditCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbDeleteCreditCard.Click
        DeleteCreditCard()
        dsCC = Cust.GetCCInfoFormatted(GetCustomerID(Request, Response), String.Empty, 0, "", True)
        If dsCC.Tables.Count > 0 Then
            If dsCC.Tables(0).Rows.Count > 0 Then

                WUCCreditCard1.Visible = True
                WUCCreditCardEdit1.Visible = False
                PopulateCustomerCreditCardCurrent()
                ddlCreditCard.Visible = True
                lblLCC.Visible = True
                lnkbAddCreditCard.Visible = True
                lnkbDeleteCreditCard.Visible = True
                LoadCCCombo()
            Else
                WUCCreditCard1.Visible = False
                WUCCreditCardEdit1.Visible = True
                ddlCreditCard.Visible = False
                lblLCC.Visible = False
                lnkbAddCreditCard.Visible = False
                lnkbDeleteCreditCard.Visible = False
            End If
        Else
            WUCCreditCard1.Visible = False
            WUCCreditCardEdit1.Visible = True
            ddlCreditCard.Visible = False
            lblLCC.Visible = False
            lnkbAddCreditCard.Visible = False
            lnkbDeleteCreditCard.Visible = False
        End If
    End Sub

    Protected Sub imgbContinueCheckoutBottom_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbContinueCheckoutBottom.Click
        Confirm_Order()
    End Sub

End Class
