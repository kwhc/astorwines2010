Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_AstorCheckoutOrderReview
    Inherits WebPageBase
    ' Total for shopping basket
    Public fTotal As Double = 0
    Public fSubTotal As Double = 0
    Public fSubTotalTax As Double = 0
    Public fTax As Double = 0
    Public fShipping As Double = 0
    Public fPromo As Double = 0
    Public f3rdPartyInsurance As Double = 0

    Public b3rdPartyInsurance As Boolean = False

    Private Cart As New AstorwinesCommerce.CartDB(getConnStr())
    Private dsCust As New DataSet
    Private dsCC As New DataSet
    Private dsGiftCard As New DataSet

    Private dsShoppingCart As DataSet '= Cart.GetShoppingCartItems(GetCustomerID(Request, Response))
    Private dsn As String = WebAppConfig.ConnectString

    Private dTaxRate As Decimal '= Convert.ToDouble(Application("DefaultTaxRate"))
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If page is not being loaded in response to postback
        If Not Page.IsPostBack Then
            Try
                dsCust = Cart.GetShoppingCartCustInfoFormatted(GetCustomerID(Request, Response))

                If dsCust.Tables.Count > 0 Then
                    If dsCust.Tables(0).Rows.Count > 0 Then
                        PopulateCustomerBillingShipping()
                    End If
                End If

                dsCC = Cart.GetShoppingCartCcInfoFormatted(GetCustomerID(Request, Response))
                If dsCC.Tables.Count > 0 Then
                    If dsCC.Tables(0).Rows.Count > 0 Then
                        PopulateCustomerCC()
                    End If
                End If

                pnlGiftCard.Visible = False
                dsGiftCard = Cart.GetShoppingCartGiftCardInfo(GetCustomerID(Request, Response))
                If dsGiftCard.Tables.Count > 0 Then
                    If dsGiftCard.Tables(0).Rows.Count > 0 Then
                        With dsGiftCard.Tables(0).Rows(0)
                            PopulateCustomerGiftCard()
                        End With
                    End If
                End If

                dsShoppingCart = Cart.GetShoppingCartItems(GetCustomerID(Request, Response), "co")
                If dsShoppingCart.Tables.Count > 0 Then
                    If dsShoppingCart.Tables(0).Rows.Count > 0 Then
                        PopulateShoppingCartList()
                        CalcTotals()
                        lblLTax.Text = "Tax (" & (dTaxRate * 100).ToString & "%):" & "<br/>"
                    Else
                        'Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                        Response.Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                    End If
                Else
                    'Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                    Response.Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                End If
            Catch ex As Exception
                Throw
            Finally

            End Try
        End If

    End Sub
    Private Sub PopulateShoppingCartList()

        ' Popoulate list with updated shopping cart data
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())

        datMyList.DataSource = dsShoppingCart
        datMyList.DataBind()

        ' Walk through table and calculate the total value
        Dim dt As DataTable = dsShoppingCart.Tables(0)
        Dim lIndex, Quantity As Integer
        Dim UnitPrice As Double

        For lIndex = 0 To dt.Rows.Count - 1
            UnitPrice = dt.Rows(lIndex)("UnitPrice")
            Quantity = dt.Rows(lIndex)("Quantity")
            If Quantity > 0 Then
                fSubTotal += UnitPrice * Quantity
                If dt.Rows(lIndex)("tax") = "Y" Then
                    fSubTotalTax += UnitPrice * Quantity
                End If
            End If
        Next

    End Sub
    Private Sub PopulateCustomerBillingShipping()
        With dsCust.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    lblName.Text = "<div class="""">" & .Item("Name") & "</div>"
                    lblCompany.Text = "<div>" & .Item("Company") & "</div>"
                    lblAddressApt.Text = "<div>" & .Item("AddressApt") & "</div>"
                    lblCityStateZipcode.Text = "<div>" & .Item("CityStateZipcode") & "</div>"
                    lblDayPhone.Text = "<div>" & .Item("DayPhone") & "</div>"
                    IIf(.Item("EveningPhone") <> Nothing, lblEveningPhone.Text = "<div style=""font-weight:bold;"">Evening Phone</div><div>" & .Item("EveningPhone") & "</div>", "")
                    lblEmail.Text = "<div>" & GetCustomerID(Request, Response) & "</div>"

                    lblShipName.Text = "<div class="""">" & .Item("ShipName") & "</div>"
                    lblShipCompany.Text = "<div class="""">" & .Item("ShipCompany") & "</div>"
                    lblShipAddressApt.Text = "<div class="""">" & .Item("ShipAddressApt") & "</div>"
                    lblShipCityStateZipcode.Text = "<div class="""">" & .Item("ShipCityStateZipcode") & "</div>"
                    lblShipDayPhone.Text = "<div style=""text-transform:uppercase;color:#aaa;"">Day Phone</div><div class="""">" & .Item("ShipDayPhone") & "</div>"
                    IIf(.Item("ShipEveningPhone") <> Nothing, lblShipEveningPhone.Text = "<div style=""text-transform:uppercase;color:#aaa;"">Evening Phone</div><div class="""">" & .Item("ShipEveningPhone") & "</div>", "")

                    'If .Item("Scross").ToString <> "" Then
                    ' lblScross.Text = "<div class="""">at " & .Item("Scross") & "</div>"
                    ' End If

                    IIf(.Item("Scross").ToString <> Nothing, lblScross.Text = "<div class="""">at " & .Item("Scross") & "</div>", "")

                    IIf(.Item("ShipEmail").ToString <> Nothing, lblShipEmail.Text = "<div style=""text-transform:uppercase;color:#aaa;"">Shipping Email</div><div class="""">" & .Item("ShipEmail") & "</div>", "")

                    lblLShipping.Text = "Shipping/Handling (" & .Item("ShipType") & "):" & "<br/>"
                    lblShippingMethod.Text = "<div class=""shipping-method"" style=""margin-bottom:1rem;""><span style=""text-transform:uppercase;color:#aaa;"">Shipping Method</span>" & "<p>" & .Item("ShipType") & "</p></div>"

                    IIf(.Item("ShipInst") <> Nothing, lblShipInst.Text = "<div class=""shipping-instrutions"" style=""margin-bottom:1rem;""><span style=""text-transform:uppercase;color:#aaa;"">Shipping Instructions</span>" & "<p>" & .Item("ShipInst") & "</p></div>", "")

                    'If .Item("ShipType") = "Astor Delivery" Then
                    '    litShipDelDate.Text = "Astor Delivery Date: <br /><b>" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</b>"
                    'ElseIf .Item("ShipType") = "After Hours Courier" Then
                    '    litShipDelDate.Text = "After Hours Courier Delivery Date: <br /><b>" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & " in the time range " & .Item("sPMCourier") & "</b>"
                    'Else
                    '    If .Item("b3rdPartyShipInsAgreement") = True Then
                    '        litShipDelDate.Text = "3rd Party shipment will TRANSFER from our shop on: <br /><b>" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</b>"
                    '    Else
                    '        litShipDelDate.Text = "UPS Shipment will DEPART from our shop on: <br /><b>" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</b>"
                    '    End If
                    'End If
                    Select Case .Item("ShipMethod")
                        Case 1 'Astor Truck
                            litShipDelDate.Text = "<p>" & "Tentative Delivery Date: <br />" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</p>"
                        Case 2 'Astor PM Messenger
                            litShipDelDate.Text = "<p>" & "Tentative Delivery Date: <br />" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & " in the time range " & .Item("sPMCourier") & "</p>"
                        Case 3 'Astor Messenger
                            litShipDelDate.Text = "<p>" & "Tentative Delivery Date: <br />" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & " in the time range " & .Item("sPMCourier") & "</p>"
                        Case 4, 5, 8, 9, 10, 11 'Astor Common Carrier
                            litShipDelDate.Text = "<p>" & "Shipment will tentatively depart on:<br />" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</p>"
                        Case 6, 7 'Third Party
                            litShipDelDate.Text = "<p>" & "Third Party shipment will transfer from our shop on: <br />" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</p>"
                    End Select

                    If .Item("GiftNote") <> "" Then
                        lblGiftNote.Text = "Gift Note: " & .Item("GiftNote")
                    Else
                        SpecialInfoPlace.Visible = False
                    End If

                    'If RTrim(.Item("Promo")) = "" Then
                    '    lblPromoCode.Text = ""
                    '    lblLPromo.Text = ""
                    '    lblPromo.Visible = False
                    '    lblLPromo.Visible = False
                    'Else
                    '    lblPromoCode.Text = .Item("Promo")
                    '    lblLPromo.Text = .Item("Promo")
                    '    lblPromo.Visible = True
                    '    lblLPromo.Visible = True
                    'End If

                    If RTrim(.Item("Promo")) = "" Then
                        lblPromoCode.Text = ""
                        lblLPromo.Text = ""
                        lblPromo.Visible = False
                        lblLPromo.Visible = False
                    Else

                        fPromo = CalcPromoCode(.Item("Promo"))
                        'fPromo = 0
                        If fPromo <> 0 Then
                            fPromo = fPromo * (-1)
                        End If
                        'lblPromoCode.Text = 0
                        lblLPromo.Text = "Promo Code: " & .Item("Promo") & "<br/>"
                        lblPromo.Visible = True
                        lblLPromo.Visible = True
                    End If

                    '3rd party insurance
                    If RTrim(.Item("b3rdPartyShipIns")) = False Then
                        b3rdPartyInsurance = False
                        lbl3rdPartyIns.Text = ""
                        lblL3rdPartyIns.Text = ""
                        lbl3rdPartyIns.Visible = False
                        lblL3rdPartyIns.Visible = False
                    Else
                        b3rdPartyInsurance = True
                        lblL3rdPartyIns.Text = "Shipping Insurance<br/>"
                        lbl3rdPartyIns.Visible = True
                        lblL3rdPartyIns.Visible = True
                    End If
                End With
            End If
        End With
    End Sub
    Private Sub PopulateCustomerCC()
        With dsCC.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    lblccType.Text = .Item("ccType")
                    lblccNum.Text = .Item("ccnum")
                    lblccExpDate.Text = .Item("ccExpDate")
                End With
            End If
        End With

    End Sub
    Private Sub PopulateCustomerGiftCard()
        With dsGiftCard.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    'litGiftCardNumber.Text = "XXXXXXXXXXXX" & Mid(.Item("GiftCardNumber"), 13, 4)
                    litGiftCardNumber.Text = .Item("GiftCardNumber")
                    litGiftCardAmount.Text = .Item("GiftCardPresentValue")
                End With
                pnlGiftCard.Visible = True
            End If
        End With

    End Sub
    Private Sub CalcTotals()
        'fShipping = CalcShipping()
        'dTaxRate = GetTaxRate()
        'fTax = dTaxRate * (fSubTotal + fShipping)
        'fTotal = fSubTotal + fShipping + fTax
        ''TODO: promotional code
        'fPromo = 0
        'fTotal = fSubTotal + fTax + fShipping + fPromo
        If b3rdPartyInsurance = False Then
            f3rdPartyInsurance = 0
        Else

            f3rdPartyInsurance = fSubTotal * 0.01

        End If
        fShipping = CalcShipping()
        dTaxRate = GetTaxRate()
        fTax = dTaxRate * ((fSubTotalTax + fPromo) + fShipping + f3rdPartyInsurance)

        'fTotal = fSubTotal + fShipping + fTax
        'promotional code calced in PopulateCustomerBillingShipping above
        'fPromo = 0
        fTotal = fSubTotal + fTax + fShipping + fPromo + f3rdPartyInsurance
    End Sub
    Private Sub Confirm_Order()

        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        ' Dim totalOrderValue As Double = cart.GetOrderValueForCart(GetCustomerID(Request, Response))
        Dim orders As New AstorwinesCommerce.OrdersDB(getConnStr())
        ' Dim sShipType As String = ddlShipType.SelectedValue
        Dim Inum As String = String.Empty

        Inum = orders.AddNewOrder(GetCustomerID(Request, Response), DateTime.Now)
        EmailConfirmation(Inum)
        cart.ResetShoppingCart(GetCustomerID(Request, Response))

        'Redirect("~/secure/AstorCheckoutConfirmation.aspx?inum=" & Inum, RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
        Response.Redirect("~/secure/AstorCheckoutConfirmation.aspx?inum=" & Inum)
        'Redirect("~/secure/AstorCheckoutConfirmation.aspx?inum=" & Inum, RedirectOptions.AbsoluteHttps)

    End Sub
    Private Sub EmailConfirmation(ByVal Inum As String)
        Dim sPassword As String = String.Empty
        Dim _semailServer As String = Application("MailServer")
        Dim _semailUserID As String = Application("MailUserIDOrders")
        Dim _semailPassword As String = Application("MailPasswordOrders")
        Dim users As New AstorwinesCommerce.UsersDB(getConnStr())
        Dim custID As String = GetCustomerID(Request, Response)

        users.EmailServer = _semailServer
        users.EmailUserIDOrders = _semailUserID
        users.EmailPasswordOrders = _semailPassword
        users.EmailOrderConfirmationMessage(Inum, custID)

    End Sub
    Private Function CalcShipping() As Decimal
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        CalcShipping = cart.WebCalcShipping(GetCustomerID(Request, Response), String.Empty)
    End Function
    Private Function CalcPromoCode(ByVal PromoCode As String) As Decimal
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        CalcPromoCode = cart.GetPromoValueForCart(GetCustomerID(Request, Response), PromoCode)
    End Function
    Private Function GetTaxRate() As Decimal
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        GetTaxRate = cart.WebGetTaxRate(GetCustomerID(Request, Response), String.Empty)
    End Function

    Protected Sub imgbSubmitT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbSubmitB.Click
        If cbSignature.Checked Then
            Confirm_Order()
        Else
            litSignatureErrorTop.Visible = True
            litSignatureErrorBottom.Visible = True
        End If

    End Sub

    Protected Sub imgbEditShoppingCart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbEditShoppingCart.Click
        'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
        Response.Redirect("~/ShoppingCart.aspx")
    End Sub

    Protected Sub imgbEditBillingAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbEditBillingAddress.Click, imgbEditCreditCardInfo.Click
        'Redirect("~/secure/AstorCheckoutBilling.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
        Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
    End Sub

    Protected Sub imgbEditShippingAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbEditShippingAddress.Click, imgbEditShippingMethod.Click
        'Redirect("~/secure/AstorCheckoutShipping.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
        Response.Redirect("~/secure/AstorCheckoutShipping.aspx")
    End Sub

    Protected Sub datMyList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datMyList.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row

            If RTrim(myRow("UnitType")) = "Case" Then
                CType(e.Item.FindControl("lblUnitType"), Literal).Text = "Case of " & myRow("pack").ToString
            Else
                CType(e.Item.FindControl("lblUnitType"), Literal).Text = myRow("UnitType")
            End If

        End If
    End Sub

End Class
