Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_AstorCheckoutShipping
    Inherits WebPageBase
    Private Cust As New AstorwinesCommerce.Customer(getConnStr())
    Private Cart As New AstorwinesCommerce.CartDB(getConnStr())
    Private dsCust As New DataSet
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblShipToStatesCodes.Text = Application("ShipToStatesCodes")
            'LoadUcombo()
            dsCust = Cart.GetShoppingCartCustShippingInfoFormatted(GetCustomerID(Request, Response))
            If dsCust.Tables.Count > 0 Then
                If dsCust.Tables(0).Rows.Count > 0 Then
                    WUCShippingName1.Visible = True
                    WUCShippingNameEdit1.Visible = False
                    lnkbEditShipping.Visible = True
                    PopulateCustomerShipToCurrent()
                    LoadUcombo()

                    phSavedShippingAddresses.Visible = True
                    'ddlShipping.Visible = True
                    'lblLShipping.Visible = True
                    'lnkbAddShipping.Visible = True
                    lnkbDeleteShipping.Visible = True
                    phSavedShippingAddresses.Visible = True
                    LoadShippingCombo()
                Else
                    dsCust = Cust.GetCustomerShippingInfoFormatted(GetCustomerID(Request, Response), String.Empty, "0000")
                    If dsCust.Tables.Count > 0 Then
                        If dsCust.Tables(0).Rows.Count > 0 Then
                            WUCShippingName1.Visible = True
                            WUCShippingNameEdit1.Visible = False
                            lnkbEditShipping.Visible = True
                            PopulateCustomerShipToCurrent()
                            'ddlShipping.Visible = True
                            'lblLShipping.Visible = True
                            'lnkbAddShipping.Visible = True
                            lnkbDeleteShipping.Visible = True
                            phSavedShippingAddresses.Visible = True
                            LoadShippingCombo()
                        Else
                            WUCShippingName1.Visible = False
                            WUCShippingNameEdit1.Visible = True
                            lnkbEditShipping.Visible = False
                            'lnkbAddShipping.Visible = False
                            lnkbDeleteShipping.Visible = False
                            'ddlShipping.Visible = False
                            'lblLShipping.Visible = False
                            phSavedShippingAddresses.Visible = False
                        End If
                    Else
                        WUCShippingName1.Visible = False
                        WUCShippingNameEdit1.Visible = True
                        lnkbEditShipping.Visible = False
                        'lnkbAddShipping.Visible = False
                        lnkbDeleteShipping.Visible = False
                        'ddlShipping.Visible = False
                        'lblLShipping.Visible = False
                        phSavedShippingAddresses.Visible = False
                    End If
                    LoadUcombo()
                End If
            Else
                dsCust = Cust.GetCustomerShippingInfoFormatted(GetCustomerID(Request, Response), String.Empty, "0000")
                If dsCust.Tables.Count > 0 Then
                    If dsCust.Tables(0).Rows.Count > 0 Then
                        WUCShippingName1.Visible = True
                        WUCShippingNameEdit1.Visible = False
                        lnkbEditShipping.Visible = True
                        PopulateCustomerShipToCurrent()
                        'ddlShipping.Visible = True
                        'lblLShipping.Visible = True
                        'lnkbAddShipping.Visible = True
                        lnkbDeleteShipping.Visible = True
                        phSavedShippingAddresses.Visible = True
                        LoadShippingCombo()
                    Else
                        WUCShippingName1.Visible = False
                        WUCShippingNameEdit1.Visible = True
                        lnkbEditShipping.Visible = False
                        'lnkbAddShipping.Visible = False
                        lnkbDeleteShipping.Visible = False
                        'ddlShipping.Visible = False
                        'lblLShipping.Visible = False
                        phSavedShippingAddresses.Visible = False
                    End If
                    LoadUcombo()
                Else
                    WUCShippingName1.Visible = False
                    WUCShippingNameEdit1.Visible = True
                    lnkbEditShipping.Visible = False
                    'lnkbAddShipping.Visible = False
                    lnkbDeleteShipping.Visible = False
                    'ddlShipping.Visible = False
                    'lblLShipping.Visible = False
                    phSavedShippingAddresses.Visible = False
                    LoadUcombo()
                End If
            End If
            PopulateCustomerShippingMiscCurrent()
            LoadShipDates(txtzipcode.Text)
            If chkGift.Checked = True Then
                txtGiftNote.Enabled = True
            Else
                txtGiftNote.Text = ""
                txtGiftNote.Enabled = False
            End If
        End If
        If WUCShippingNameEdit1.Visible = True Then
            txtzipcode.Text = WUCShippingNameEdit1.ShippingZipCode
        End If

        If txtzipcode.Text >= "07001" And txtzipcode.Text <= "08989" Then
            pnlRoyalShipping.Visible = True
            litThirdPartyNote.Text = setThirdPartyNote(0)
        ElseIf (txtzipcode.Text >= "10000" And txtzipcode.Text <= "14999") And Cart.OrderHasSpirits(GetCustomerID(Request, Response)) And Not Cart.IsShipmentInAstorDeliveryZone(txtzipcode.Text) Then
            'NYS ??
            pnlRoyalShipping.Visible = True
            litThirdPartyNote.Text = setThirdPartyNote(1)
        Else
            pnlRoyalShipping.Visible = False
        End If
        'Dim shippingAgreementContainer As HtmlGenericControl
        'shippingAgreementContainer = WUCShippingNameEdit1.FindControl("shippingAgreementContainer")
        'litSAContainer.Text = shippingAgreementContainer.ClientID.ToString

        'Dim litErrorShippingAgreement As New Literal
        'litErrorShippingAgreement = WUCShippingNameEdit1.FindControl("litErrorShippingAgreement")
        'litMessageID.Text = litErrorShippingAgreement.ClientID.ToString

        'Dim cbShippingAgreement As New CheckBox
        'cbShippingAgreement = (WUCShippingNameEdit1.FindControl("cbShippingAgreement"))
        'litCheckboxID.Text = cbShippingAgreement.ClientID.ToString

        WUCShipDates1.FindControl("phAfterHoursCourierService").Visible = False

    End Sub
    Public Sub LoadUcombo()
        'load sshiptype
        Dim _dslocal As New DataSet
        'Dim _dsDelDates As New DataSet
        Dim dAmountNeeded As Decimal = 0
        Dim dAmountNeededForFreeShipping As Decimal = 0
        Dim dMinAmount As Decimal = 0
        Dim Type As Int16 = 0
        'Dim _sDeliveryType As String = String.Empty
        'Dim dvDatarow As DataRow
        Dim sShippingText As String = String.Empty

        If Cart.OrderHasSpiritsAndNonDeliveryZone(GetCustomerID(Request, Response), txtzipcode.Text) Then
            pnlSpiritsPresent.Visible = True
            pnlShippingMethod.Visible = False
            imgbContinueCheckoutBottom.Visible = False
            imgbContinueCheckoutBottom.Enabled = False
            imgbNotContinueCheckoutBottom.Visible = True
            imgbNotContinueCheckoutBottom.Enabled = False
            WUCShipDates1.FindControl("phUPSShipDates").Visible = False
        Else
            pnlSpiritsPresent.Visible = False
            pnlShippingMethod.Visible = True
            imgbContinueCheckoutBottom.Visible = True
            imgbContinueCheckoutBottom.Enabled = True
            imgbNotContinueCheckoutBottom.Visible = False
            imgbNotContinueCheckoutBottom.Enabled = False
        End If

        _dslocal = Cart.WebCalcAllShipping(GetCustomerID(Request, Response), String.Empty, txtzipcode.Text)
        'With ddlShippingMethod
        '    .DataSource = _dslocal.Tables(0)
        '    .DataMember = ""
        '    .DataValueField = "iShipType"
        '    .DataTextField = "sShipType"
        '    .DataBind()
        'End With
        With rblShippingMethod
            .DataSource = _dslocal.Tables(0)
            .DataMember = ""
            .DataValueField = "iShipType"
            .DataTextField = "sShipType"
            .DataBind()
        End With

        rblShippingMethod.SelectedIndex = 0


        'After Hours Courier Times
        If Cart.IsPMCourierAvailable(GetCustomerID(Request, Response), String.Empty, txtzipcode.Text) Then

            rblShippingMethod.Items.Add(New ListItem("*NEW* After-Hours Courier Service - Free", "2"))
            rblAfterHoursCourierTimes.Visible = True

            'After Hours Courier Times
            With rblAfterHoursCourierTimes
                .Attributes.CssStyle.Add("padding", "1rem")
                'r.Attributes.CssStyle.Add("border", "solid 1px #ddd")
                .Attributes.CssStyle.Add("display", "block")
                .Attributes.CssStyle.Add("background-color", "#eee")
                .Attributes.CssStyle.Add("margin-bottom", ".5rem")
            End With


            With rblAfterHoursCourierTimes
                .DataSource = Application("PMCourier")
                .DataMember = ""
                .DataValueField = "iPMCourier"
                .DataTextField = "sPMCourier"
                .DataBind()
            End With

            rblAfterHoursCourierTimes.SelectedIndex = 0

            WUCShipDates1.FindControl("phAfterHoursCourierService").Visible = True

            ' ''Dim afterHoursCourierTimes As String(,) = New String(,) {{"3:00pm - 6:00pm", 0}, {"4:00pm - 7:00pm", 1}, {"5:00pm - 8:00pm", 2}, {"6:00pm - 9:00pm", 3}}

            ' ''For i = 0 To afterHoursCourierTimes.GetUpperBound(0)
            ' ''    For x = 0 To afterHoursCourierTimes.GetUpperBound(1)
            ' ''        Dim r As New ListItem
            ' ''        r.Attributes.CssStyle.Add("padding", "1rem")
            ' ''        'r.Attributes.CssStyle.Add("border", "solid 1px #ddd")
            ' ''        r.Attributes.CssStyle.Add("display", "block")
            ' ''        r.Attributes.CssStyle.Add("background-color", "#eee")
            ' ''        r.Attributes.CssStyle.Add("margin-bottom", ".5rem")
            ' ''        r.Text = afterHoursCourierTimes(i, 0)
            ' ''        r.Value = afterHoursCourierTimes(i, 1)
            ' ''        rblAfterHoursCourierTimes.Items.Add(r)
            ' ''    Next
            ' ''Next

        Else
            rblAfterHoursCourierTimes.Visible = False
        End If

        LoadShipDates(txtzipcode.Text)

        ''If txtzipcode.Text <> "" Then
        ''    _sDeliveryType = Cart.GetShipmentDeliveryType(txtzipcode.Text, GetCustomerID(Request, Response))
        ''    _dsDelDates = Cart.LoadShippingDatesAstorDelivery(_sDeliveryType)

        ''    With rblDeliveryDates
        ''        .DataSource = _dsDelDates.Tables(0)
        ''        .DataMember = ""
        ''        .DataValueField = "dtDeliveryDate"
        ''        .DataTextField = "sDeliveryDate"
        ''        .DataBind()
        ''    End With

        ''    rblDeliveryDates.SelectedIndex = 0

        ''    If _sDeliveryType <> "S" And rblShippingMethod.SelectedValue <> 9 Then
        ''        pnlDelDate.Visible = True
        ''    Else
        ''        pnlDelDate.Visible = False
        ''        WUCShipDates1.FindControl("phAstorTrucks").Visible = False
        ''    End If
        ''Else
        ''    pnlDelDate.Visible = False
        ''    'WUCShipDates1.FindControl("phAstorTrucks").Visible = False
        ''End If

        Cart.CheckAmountNeededShippingFree(GetCustomerID(Request, Response), String.Empty, txtzipcode.Text, dAmountNeeded, dMinAmount, Type, dAmountNeededForFreeShipping)

        If dAmountNeededForFreeShipping > 0 And dAmountNeededForFreeShipping < 100.0 Then
            lblShippingMsg.Visible = True
            lblShippingMsg.Text = "Your total is only <strong>$" & dAmountNeededForFreeShipping.ToString & "</strong> away for free shipping on your first order!"
        ElseIf dAmountNeeded >= 1 And dAmountNeeded < 99999.99 Then
            lblShippingMsg.Visible = True
            'imgbEditShoppingCart.Visible = True
            If Cart.OrderHasSpiritsAndNonDeliveryZone(GetCustomerID(Request, Response), txtzipcode.Text) Then
                lblShippingMsg.Text = "<div style='border-top: dashed 1px #ccc; border-bottom: dashed 1px #ccc; padding: 1em; width: 356px;'><h4>Your order is <b>" & dAmountNeeded.ToString("c") & "</b> away from our delivery minimum.</h4></div>"
            Else
                lblShippingMsg.Text = "<div style='border-top: dashed 1px #ccc; border-bottom: dashed 1px #ccc; padding: 1em; width: 356px;'><h4>You're only <b>" & dAmountNeeded.ToString("c") & "</b> away from free shipping!</h4><h4><a href=""/default.aspx""><b>Click here</b></a> to continue shopping.</h4></div>"
            End If
        ElseIf Type = 1 And dAmountNeeded < 1 Then
            If Not Cart.OrderHasSpiritsAndNonDeliveryZone(GetCustomerID(Request, Response), txtzipcode.Text) Then
                lblShippingMsg.Visible = True
                'imgbEditShoppingCart.Visible = False
                lblShippingMsg.Text = "<p style=""margin-top:1em;""><i class=""icon-star""></i> <b>Your order meets our minimum for free delivery!</b></p><p>You will receive an email once your order has been processed confirming your scheduled delivery date.</p>"
            End If
        ElseIf Type = 2 And dAmountNeeded < 1 Then
            If Not Cart.OrderHasSpiritsAndNonDeliveryZone(GetCustomerID(Request, Response), txtzipcode.Text) Then
                lblShippingMsg.Visible = True
                'imgbEditShoppingCart.Visible = False
                lblShippingMsg.Text = "<p style=""margin-top:1em;""><i class=""icon-star""></i> <b>Your order meets our $150 minimum for free UPS Ground shipping within New York State!</b></p><p>You will receive an email once your order has been processed confirming the date your order will ship from our store, and a follow-up email with your UPS tracking number.</p><p>If you would like to upgrade to 3rd Day Select or Next Day Air shipping, please note that full shipping charges apply.</p>"
            End If

        Else
            lblShippingMsg.Visible = False
            'imgbEditShoppingCart.Visible = False
        End If

    End Sub
    Private Sub LoadShipDates(ByVal ZipCode As String)
        Dim _sDeliveryType As String = String.Empty
        Dim _dsDelDates As New DataSet
        Dim _dvDelDates As New DataView

        If zipcode <> "" Then
            _sDeliveryType = Cart.GetShipmentDeliveryType(txtzipcode.Text, GetCustomerID(Request, Response))
            _dsDelDates = Cart.LoadShippingDatesAstorDelivery(_sDeliveryType)

            _dvDelDates.Table = _dsDelDates.Tables(0)

            If rblShippingMethod.Text = "2" Then
                pnlAfterHoursCourierTimes.Visible = True
                If Date.Now.Hour > "16" Then
                    _dvDelDates.RowFilter = "dtDeliveryDate > '" & Date.Now.AddDays(1).ToString() & "'"
                End If
            Else
                pnlAfterHoursCourierTimes.Visible = False
            End If

            With rblDeliveryDates
                .DataSource = _dvDelDates
                .DataMember = ""
                .DataValueField = "dtDeliveryDate"
                .DataTextField = "sDeliveryDate"
                .DataBind()
            End With

            rblDeliveryDates.SelectedIndex = 0

            If _sDeliveryType <> "S" And rblShippingMethod.SelectedValue <> 9 Then
                pnlDelDate.Visible = True
            Else
                pnlDelDate.Visible = False
                'WUCShipDates1.FindControl("phAstorTrucks").Visible = False
            End If
        Else
            pnlDelDate.Visible = False
            'WUCShipDates1.FindControl("phAstorTrucks").Visible = False
        End If
    End Sub
    Private Sub LoadShippingCombo()
        Dim dsCustShipping As New DataSet
        'load 
        dsCustShipping = Cust.GetAllCustomersShipToInfo(GetCustomerID(Request, Response), String.Empty)
        With dsCustShipping
            If .Tables.Count > 0 Then
                With .Tables(0)
                    If .Rows.Count > 0 Then
                        With ddlShipping
                            .DataSource = dsCustShipping.Tables(0)
                            .DataMember = ""
                            .DataValueField = "ids"
                            .DataTextField = "Desc"
                            .DataBind()
                        End With
                    End If
                End With
            End If
        End With
    End Sub
    Private Sub Confirm_Order()
        Try
            If WUCShippingNameEdit1.Visible = True Then
                Dim sMsg As String = "Please correct errors on form!"
                If WUCShippingNameEdit1.bValidateShippingInfo(sMsg) Then
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    _webutils.CreateMessageAlert(Me, t, sMsg, "strKey2")
                    Exit Sub
                End If

            End If
            If WUCShippingName1.Visible = True Then
                Dim sMsg As String = "Please EDIT Shipping address and correct errors on form!"
                If WUCShippingName1.bValidateShippingInfo(sMsg) Then
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    _webutils.CreateMessageAlert(Me, t, sMsg, "strKey2")
                    Exit Sub
                End If

            End If
            
            If txtzipcode.Text >= "07001" And txtzipcode.Text <= "08989" Then
                If chk3rdPartyShipInsAgreement.Checked = False Then
                    Dim sMsg As String = "You must agree to the shipping agreement!"
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    litErrorShippingAgreement.Visible = True
                    shippingAgreementContainer.Attributes.CssStyle.Add("border", "solid 2px red")

                    _webutils.CreateMessageAlert(Me, t, sMsg, "strKey2")
                    Exit Sub
                End If
            End If

            If (txtzipcode.Text >= "10000" And txtzipcode.Text <= "14999") And Cart.OrderHasSpirits(GetCustomerID(Request, Response)) And Not Cart.IsShipmentInAstorDeliveryZone(txtzipcode.Text) Then
                If chk3rdPartyShipInsAgreement.Checked = False Then
                    Dim sMsg As String = "You must agree to the shipping agreement!"
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    litErrorShippingAgreement.Visible = True
                    shippingAgreementContainer.Attributes.CssStyle.Add("border", "solid 2px red")

                    _webutils.CreateMessageAlert(Me, t, sMsg, "strKey2")
                    Exit Sub
                End If
            End If

            If WUCShippingNameEdit1.Visible = True Then
                SaveCustomerCartShipping()
            Else
                SaveCustomerCartShippingCurrent()

            End If

            'Redirect("~/secure/AstorCheckoutOrderReview.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
            Response.Redirect("~/secure/AstorCheckoutOrderReview.aspx")


        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Sub

    Private Sub PopulateCustomerShipTo()

        If dsCust.Tables.Count > 0 Then
            With dsCust.Tables(0)
                If .Rows.Count > 0 Then
                    With .Rows(0)
                        WUCShippingNameEdit1.ShippingFirstName = .Item("ShipFirstName")
                        WUCShippingNameEdit1.ShippingLastName = .Item("ShipLastName")
                        WUCShippingNameEdit1.ShippingIdt = .Item("Idt")
                        WUCShippingNameEdit1.ShippingIds = .Item("Ids")
                        If .Item("ShipCompany") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingCompany = String.Empty
                        Else
                            WUCShippingNameEdit1.ShippingCompany = .Item("ShipCompany")
                        End If
                        If .Item("ShipAddress") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingAddress = String.Empty
                        Else
                            WUCShippingNameEdit1.ShippingAddress = .Item("ShipAddress")
                        End If
                        If .Item("ShipApt") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingApt = String.Empty
                        Else
                            WUCShippingNameEdit1.ShippingApt = .Item("ShipApt")
                        End If
                        If .Item("ShipCity") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingCity = String.Empty
                        Else
                            WUCShippingNameEdit1.ShippingCity = .Item("ShipCity")

                        End If
                        If .Item("ShipState") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingState = -1
                        Else
                            WUCShippingNameEdit1.ShippingState = .Item("ShipState")
                        End If
                        If .Item("ShipZipCode") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingZipCode = String.Empty
                            txtzipcode.Text = String.Empty

                        Else
                            WUCShippingNameEdit1.ShippingZipCode = .Item("ShipZipCode")
                            txtzipcode.Text = .Item("ShipZipCode")
                            WUCShippingNameEdit1.LoadCity(.Item("ShipZipCode"), String.Empty)
                        End If
                        If .Item("ShipDayPhone") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingDayPhone = String.Empty
                        Else
                            WUCShippingNameEdit1.ShippingDayPhone = .Item("ShipDayPhone")
                        End If
                        If .Item("ShipEveningPhone") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingEveningPhone = String.Empty
                        Else
                            WUCShippingNameEdit1.ShippingEveningPhone = .Item("ShipEveningPhone")
                        End If
                        If .Item("Scross") Is DBNull.Value Then
                            WUCShippingNameEdit1.Scross = String.Empty
                        Else
                            WUCShippingNameEdit1.Scross = .Item("Scross")
                        End If
                        If .Item("ShipEmail") Is DBNull.Value Then
                            WUCShippingNameEdit1.ShippingEmail = String.Empty
                        Else
                            WUCShippingNameEdit1.ShippingEmail = .Item("ShipEmail")
                        End If
                        WUCShippingNameEdit1.ShippingDefault = .Item("ShipDefault")

                    End With
                End If
            End With
        End If

    End Sub

    Private Sub ChangeShipping()
        Dim sShippingID As String

        sShippingID = ddlShipping.SelectedValue

        dsCust = Cust.GetCustomerShippingInfoFormatted(GetCustomerID(Request, Response), String.Empty, sShippingID)
        If dsCust.Tables.Count > 0 Then
            If dsCust.Tables(0).Rows.Count > 0 Then
                WUCShippingName1.Visible = True
                WUCShippingNameEdit1.Visible = False
                lnkbEditShipping.Visible = True
                PopulateCustomerShipToCurrent()
                'ddlShipping.Visible = True
                'lblLShipping.Visible = True
                'lnkbAddShipping.Visible = True
                phSavedShippingAddresses.Visible = True
                lnkbDeleteShipping.Visible = True
            Else
                WUCShippingName1.Visible = False
                WUCShippingNameEdit1.Visible = True
                lnkbEditShipping.Visible = False
                'lnkbAddShipping.Visible = False
                lnkbDeleteShipping.Visible = False
                'ddlShipping.Visible = False
                'lblLShipping.Visible = False
                phSavedShippingAddresses.Visible = False
            End If

        Else
            WUCShippingName1.Visible = False
            WUCShippingNameEdit1.Visible = True
            lnkbEditShipping.Visible = False
            'lnkbAddShipping.Visible = False
            lnkbDeleteShipping.Visible = False
            'ddlShipping.Visible = False
            'lblLShipping.Visible = False
            phSavedShippingAddresses.Visible = False
        End If
        If txtzipcode.Text >= "07001" And txtzipcode.Text <= "08989" Then
            pnlRoyalShipping.Visible = True
            litThirdPartyNote.Text = setThirdPartyNote(0)
        ElseIf (txtzipcode.Text >= "10000" And txtzipcode.Text <= "14999") And Cart.OrderHasSpirits(GetCustomerID(Request, Response)) And Not Cart.IsShipmentInAstorDeliveryZone(txtzipcode.Text) Then
            'NYS ??
            pnlRoyalShipping.Visible = True
            litThirdPartyNote.Text = setThirdPartyNote(1)
        Else
            pnlRoyalShipping.Visible = False
            chk3rdPartyShipInsAgreement.Checked = False
            chk3rdPartyShipIns.Checked = False

        End If
        LoadUcombo()
    End Sub
    Private Sub SaveCustomerCartShippingCurrent()

        Dim sCustomerNumber As String = GetCustomerID(Request, Response)
        Dim sIdt As String = WUCShippingName1.ShippingIdt
        Dim sIds As String = WUCShippingName1.ShippingIds

        Dim sShipType As String = rblShippingMethod.SelectedValue 'ddlShippingMethod.SelectedValue
        Dim dtShipDate As Date = rblDeliveryDates.SelectedValue
        Dim bGift As Boolean = chkGift.Checked
        'Dim bGift As Boolean = False
        Dim sGiftNote As String = txtGiftNote.Text
        Dim sPromo As String = txtPromo.Text
        'Dim sPromo As String = String.Empty
        Dim sShipInst As String = txtShipInst.Text
        Dim b3rdPartyShipInsAgreement As Boolean = chk3rdPartyShipInsAgreement.Checked
        Dim b3rdPartyShipIns As Boolean = chk3rdPartyShipIns.Checked
        Dim iPMCourier As Int16 = 0

        If rblAfterHoursCourierTimes.Visible = True Then
            iPMCourier = rblAfterHoursCourierTimes.SelectedValue
        End If

        Cart.UpdateShoppingCartCustInfoShipping(sCustomerNumber, sIdt, sIds, sShipType, bGift, sGiftNote, sPromo, sShipInst, dtShipDate, b3rdPartyShipInsAgreement, b3rdPartyShipIns, iPMCourier)
        'Cust.UpdateCustomerShipTo(hstCustomerInfo)
    End Sub
    Private Sub SaveCustomerCartShipping()
        Dim hstCustomerInfo As New Hashtable

        With hstCustomerInfo
            .Item("CustomerNumber") = GetCustomerID(Request, Response)
            .Item("Idt") = WUCShippingNameEdit1.ShippingIdt
            .Item("Ids") = WUCShippingNameEdit1.ShippingIds
            .Item("ShipFirstName") = WUCShippingNameEdit1.ShippingFirstName
            .Item("ShipLastName") = WUCShippingNameEdit1.ShippingLastName
            .Item("ShipCompany") = WUCShippingNameEdit1.ShippingCompany
            .Item("ShipAddress") = WUCShippingNameEdit1.ShippingAddress
            .Item("ShipApt") = WUCShippingNameEdit1.ShippingApt
            .Item("ShipCity") = WUCShippingNameEdit1.ShippingCity
            .Item("ShipState") = WUCShippingNameEdit1.ShippingState
            .Item("ShipZipCode") = WUCShippingNameEdit1.ShippingZipCode
            .Item("ShipCountry") = "USA"
            .Item("ShipDayPhone") = WUCShippingNameEdit1.ShippingDayPhone
            .Item("ShipEveningPhone") = WUCShippingNameEdit1.ShippingEveningPhone
            .Item("Scross") = WUCShippingNameEdit1.Scross
            .Item("ShipEmail") = WUCShippingNameEdit1.ShippingEmail
            .Item("ShipDefault") = WUCShippingNameEdit1.ShippingDefault

            '.Item("ShipType") = ddlShippingMethod.SelectedValue
            .Item("ShipType") = rblShippingMethod.SelectedValue
            .Item("ShipDate") = rblDeliveryDates.SelectedValue
            .Item("Gift") = chkGift.Checked
            '.Item("Gift") = False
            .Item("GiftNote") = txtGiftNote.Text
            .Item("Promo") = txtPromo.Text
            '.Item("Promo") = String.Empty
            .Item("ShipInst") = txtShipInst.Text
            If WUCShippingNameEdit1.ShippingZipCode >= "07001" And WUCShippingNameEdit1.ShippingZipCode <= "08989" Then
                .Item("b3rdPartyShipInsAgreement") = chk3rdPartyShipInsAgreement.Checked
                .Item("b3rdPartyShipIns") = chk3rdPartyShipIns.Checked
            ElseIf (WUCShippingNameEdit1.ShippingZipCode >= "10000" And WUCShippingNameEdit1.ShippingZipCode <= "14999") And Cart.OrderHasSpirits(GetCustomerID(Request, Response)) And Not Cart.IsShipmentInAstorDeliveryZone(WUCShippingNameEdit1.ShippingZipCode) Then
                .Item("b3rdPartyShipInsAgreement") = chk3rdPartyShipInsAgreement.Checked
                .Item("b3rdPartyShipIns") = chk3rdPartyShipIns.Checked
            Else

                .Item("b3rdPartyShipInsAgreement") = False
                .Item("b3rdPartyShipIns") = False
            End If

            If rblAfterHoursCourierTimes.Visible = True Then
                .Item("iPMCourier") = rblAfterHoursCourierTimes.SelectedValue
            Else
                .Item("iPMCourier") = 0
            End If


        End With


        Cart.UpdateShoppingCartCustInfoShipping(hstCustomerInfo)

    End Sub
    Private Sub PopulateCustomerShipToCurrent()
        If dsCust.Tables.Count > 0 Then
            With dsCust.Tables(0)
                If .Rows.Count > 0 Then
                    With .Rows(0)
                        WUCShippingName1.ShippingName = .Item("ShipName")

                        WUCShippingName1.ShippingIdt = .Item("Idt")
                        WUCShippingName1.ShippingIds = .Item("Ids")
                        If .Item("ShipCompany") Is DBNull.Value Then
                            WUCShippingName1.ShippingCompany = String.Empty
                        Else
                            WUCShippingName1.ShippingCompany = .Item("ShipCompany")
                        End If
                        If .Item("ShipAddressApt") Is DBNull.Value Then
                            WUCShippingName1.ShippingAddressApt = String.Empty
                        Else
                            WUCShippingName1.ShippingAddressApt = .Item("ShipAddressApt")
                        End If

                        If .Item("ShipCityStateZipcode") Is DBNull.Value Then
                            WUCShippingName1.ShippingCityStateZipcode = String.Empty
                        Else
                            WUCShippingName1.ShippingCityStateZipcode = .Item("ShipCityStateZipcode")
                        End If
                        If .Item("ShipZipCode") Is DBNull.Value Then

                            txtzipcode.Text = String.Empty
                        Else

                            txtzipcode.Text = .Item("ShipZipCode")
                        End If
                        If .Item("ShipDayPhone") Is DBNull.Value Then
                            WUCShippingName1.ShippingDayPhone = String.Empty
                        Else
                            WUCShippingName1.ShippingDayPhone = .Item("ShipDayPhone")
                        End If
                        If .Item("ShipEveningPhone") Is DBNull.Value Then
                            WUCShippingName1.ShippingEveningPhone = String.Empty
                        Else
                            WUCShippingName1.ShippingEveningPhone = .Item("ShipEveningPhone")
                        End If
                        If .Item("Scross") Is DBNull.Value Then
                            WUCShippingName1.Scross = String.Empty
                        Else
                            WUCShippingName1.Scross = .Item("Scross")
                        End If
                        If .Item("ShipEmail") Is DBNull.Value Then
                            WUCShippingName1.ShippingEmail = String.Empty
                        Else
                            WUCShippingName1.ShippingEmail = .Item("ShipEmail")
                        End If
                        WUCShippingName1.ShippingDefault = .Item("ShipDefault")



                    End With
                End If
            End With
        End If

    End Sub
    Private Sub PopulateCustomerShippingMiscCurrent()
        If dsCust.Tables.Count > 0 Then
            With dsCust.Tables(0)
                If .Rows.Count > 0 Then
                    With .Rows(0)
                        If .Item("ShipType") Is DBNull.Value Then
                            rblShippingMethod.SelectedIndex = 0
                        Else
                            If rblShippingMethod.Items.FindByValue(.Item("ShipType")) Is Nothing Then
                                rblShippingMethod.SelectedIndex = 0
                            ElseIf rblShippingMethod.Items.FindByValue(.Item("ShipType")).ToString Is DBNull.Value Then
                                rblShippingMethod.SelectedIndex = 0
                            ElseIf rblShippingMethod.Items.FindByValue(.Item("ShipType")).ToString = "" Then
                                rblShippingMethod.SelectedIndex = 0
                            Else
                                rblShippingMethod.SelectedValue = .Item("ShipType")
                            End If

                        End If
                        Dim _sDeliveryType As String

                        If txtzipcode.Text <> "" Then
                            _sDeliveryType = Cart.GetShipmentDeliveryType(txtzipcode.Text, GetCustomerID(Request, Response))
                            If _sDeliveryType <> "S" And rblShippingMethod.SelectedValue <> 9 Then
                                pnlDelDate.Visible = True
                                If .Item("ShipDate") Is DBNull.Value Then
                                    rblDeliveryDates.SelectedIndex = 0
                                Else
                                    If rblDeliveryDates.Items.FindByValue(.Item("ShipDate").ToString) Is Nothing Then
                                        rblDeliveryDates.SelectedIndex = 0
                                    ElseIf rblDeliveryDates.Items.FindByValue(.Item("ShipDate").ToString).ToString Is DBNull.Value Then
                                        rblDeliveryDates.SelectedIndex = 0
                                    ElseIf rblDeliveryDates.Items.FindByValue(.Item("ShipDate").ToString).ToString = "" Then
                                        rblDeliveryDates.SelectedIndex = 0
                                    Else
                                        rblDeliveryDates.SelectedValue = .Item("ShipDate").ToString
                                    End If
                                End If
                            Else
                                pnlDelDate.Visible = False
                            End If
                        Else
                            pnlDelDate.Visible = False
                        End If

                        If rblAfterHoursCourierTimes.Visible = True Then
                            rblAfterHoursCourierTimes.SelectedValue = .Item("iPMCourier")
                        End If
                        chkGift.Checked = .Item("Gift")
                        txtGiftNote.Text = .Item("GiftNote")
                        txtPromo.Text = .Item("Promo")
                        txtShipInst.Text = .Item("ShipInst")

                        chk3rdPartyShipInsAgreement.Checked = .Item("b3rdPartyShipInsAgreement")
                        chk3rdPartyShipIns.Checked = .Item("b3rdPartyShipIns")

                    End With
                Else
                    rblShippingMethod.SelectedIndex = 0
                    chkGift.Checked = False
                    txtGiftNote.Text = ""
                    txtPromo.Text = ""
                    txtShipInst.Text = ""
                    chk3rdPartyShipInsAgreement.Checked = False
                    chk3rdPartyShipIns.Checked = False
                End If
            End With
        End If

    End Sub
    Private Sub DeleteShippingAddress()
        Dim Ids As String = WUCShippingName1.ShippingIds

        Cust.DeleteCustomerShippingInfo(GetCustomerID(Request, Response), String.Empty, Ids)
    End Sub
    Protected Sub imgbContinueCheckoutTB_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbContinueCheckoutBottom.Click

        'Dim phShippingAgreement As New PlaceHolder
        'phShippingAgreement = WUCShippingNameEdit1.FindControl("phShippingAgreement")

        'Dim litErrorShippingAgreement As New Literal
        'litErrorShippingAgreement = WUCShippingNameEdit1.FindControl("litErrorShippingAgreement")

        'Dim cbShippingAgreement As New CheckBox
        'cbShippingAgreement = (WUCShippingNameEdit1.FindControl("cbShippingAgreement"))

        
        Confirm_Order()


    End Sub

    Protected Sub lnkbEditShipping_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbEditShipping.Click
        Dim sShippingID As String

        sShippingID = ddlShipping.SelectedValue
        dsCust = Cust.GetCustomerShippingInfo(GetCustomerID(Request, Response), String.Empty, sShippingID, False)
        If dsCust.Tables.Count > 0 Then
            If dsCust.Tables(0).Rows.Count > 0 Then
                WUCShippingName1.Visible = False
                WUCShippingNameEdit1.Visible = True
                lnkbEditShipping.Visible = False
                'lnkbAddShipping.Visible = False
                lnkbDeleteShipping.Visible = False
                'ddlShipping.Visible = False
                'lblLShipping.Visible = False
                phSavedShippingAddresses.Visible = False
                PopulateCustomerShipTo()
            End If
        End If

    End Sub

    Protected Sub lnkbAddShipping_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbAddShipping.Click
        WUCShippingName1.Visible = False
        WUCShippingNameEdit1.Visible = True
        lnkbEditShipping.Visible = False
        'lnkbAddShipping.Visible = False
        lnkbDeleteShipping.Visible = False
        'ddlShipping.Visible = False
        'lblLShipping.Visible = False
        phSavedShippingAddresses.Visible = False
    End Sub

    Protected Sub ddlShipping_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlShipping.SelectedIndexChanged
        ChangeShipping()
    End Sub


    Protected Overrides Function OnBubbleEvent(ByVal source As Object, ByVal args As System.EventArgs) As Boolean
        LoadUcombo()
        If txtzipcode.Text >= "07001" And txtzipcode.Text <= "08989" Then
            pnlRoyalShipping.Visible = True
            litThirdPartyNote.Text = setThirdPartyNote(0)
        ElseIf (txtzipcode.Text >= "10000" And txtzipcode.Text <= "14999") And Cart.OrderHasSpirits(GetCustomerID(Request, Response)) And Not Cart.IsShipmentInAstorDeliveryZone(txtzipcode.Text) Then
            'NYS ??
            pnlRoyalShipping.Visible = True
            litThirdPartyNote.Text = setThirdPartyNote(1)
        Else
            pnlRoyalShipping.Visible = False
            chk3rdPartyShipInsAgreement.Checked = False
            chk3rdPartyShipIns.Checked = False
        End If
    End Function

    Protected Sub lnkbDeleteShipping_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbDeleteShipping.Click
        DeleteShippingAddress()

        dsCust = Cust.GetCustomerShippingInfoFormatted(GetCustomerID(Request, Response), String.Empty, "00")
        If dsCust.Tables.Count > 0 Then
            If dsCust.Tables(0).Rows.Count > 0 Then
                WUCShippingName1.Visible = True
                WUCShippingNameEdit1.Visible = False
                lnkbEditShipping.Visible = True
                PopulateCustomerShipToCurrent()
                'ddlShipping.Visible = True
                'lblLShipping.Visible = True
                'lnkbAddShipping.Visible = True
                lnkbDeleteShipping.Visible = True
                phSavedShippingAddresses.Visible = True
                LoadShippingCombo()
            Else
                WUCShippingName1.Visible = False
                WUCShippingNameEdit1.Visible = True
                lnkbEditShipping.Visible = False
                'lnkbAddShipping.Visible = False
                lnkbDeleteShipping.Visible = False
                'ddlShipping.Visible = False
                'lblLShipping.Visible = False
                phSavedShippingAddresses.Visible = False
            End If
            LoadUcombo()
        Else
            WUCShippingName1.Visible = False
            WUCShippingNameEdit1.Visible = True
            lnkbEditShipping.Visible = False
            'lnkbAddShipping.Visible = False
            lnkbDeleteShipping.Visible = False
            'ddlShipping.Visible = False
            'lblLShipping.Visible = False
            phSavedShippingAddresses.Visible = False
            LoadUcombo()
        End If

        If WUCShippingNameEdit1.Visible = True Then
            txtzipcode.Text = WUCShippingNameEdit1.ShippingZipCode
        End If
    End Sub

    Protected Sub chkGift_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkGift.CheckedChanged
        If chkGift.Checked = True Then
            txtGiftNote.Enabled = True
        Else
            txtGiftNote.Text = ""
            txtGiftNote.Enabled = False
        End If
    End Sub


    Protected Sub imgbEditShoppingCart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbEditShoppingCart.Click
        Response.Redirect("~/ShoppingCart.aspx")
    End Sub

    Protected Sub rblShippingMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblShippingMethod.SelectedIndexChanged
        LoadShipDates(txtzipcode.Text)

    End Sub
    Function setThirdPartyNote(ByVal thirdPartyType As Integer) As String
        Select Case thirdPartyType
            Case 0
                'Outside NYS
                Return "Your purchase is being made in New York. Once you complete your purchase, the items you own will be transferred at your direction to a third party shipping company – Royal Express Shipping – which will contact you directly within two business days with your shipping, tracking number, shipping date and anticipated delivery date. Because of this transfer, delivery may take approximately 3-5 days. There is an optional 1 percent charge for insurance against breakage and loss, which you can decline at checkout."
            Case 1
                'Inside NYS
                Return "To expedite your shipment, Astor Wines & Spirits has contracted with a third-party carrier for your delivery. You will receive an email from Royal Express Shipping when it has departed, followed by an email from United Parcel Service with your tracking number. If you have any questions about your order, please contact Astor Wines & Spirits at (212) 674-7500."
            Case Else
                Return ""
        End Select
    End Function

End Class
