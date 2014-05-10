Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_AstorCheckOutConfirmation
    Inherits WebPageBase
    Public fTotal As Double = 0
    Public fSubTotal As Double = 0
    Public fTax As Double = 0
    Public fShipping As Double = 0
    Public fPromo As Double = 0
    Public f3rdPartyInsurance As Double = 0

    Public b3rdPartyInsurance As Boolean = False

    Private Orders As New AstorwinesCommerce.OrdersDB(getConnStr())
    Private dsOrder As New DataSet
    Private _sInum As String
    Private dTaxRate As Decimal '= Convert.ToDouble(Application("DefaultTaxRate"))
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If page is not being loaded in response to postback
        If Not Page.IsPostBack Then
            Try
                If Not IsNothing(Request.QueryString("inum")) Then
                    _sInum = Request.QueryString("inum")
                End If
                dsOrder = Orders.GetOrderForCustomerFormatted(GetCustomerID(Request, Response), _sInum)

                If dsOrder.Tables.Count > 0 Then
                    If dsOrder.Tables(0).Rows.Count > 0 Then
                        PopulateCustomerBillingShipping()
                        PopulateOrderDetail()

                    Else
                        'Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                        Response.Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                    End If
                Else
                    'Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                    Response.Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                End If
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End If

    End Sub
    Private Sub PopulateOrderDetail()

        datMyList.DataSource = dsOrder.Tables(1)
        datMyList.DataBind()


    End Sub
    Private Sub PopulateCustomerBillingShipping()
        With dsOrder.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    lblConfirm.Text = "Your order has been placed.  Your order number is: " & .Item("OrderNumber")
                    lblName.Text = .Item("Name")
                    lblCompany.Text = .Item("Company")
                    lblAddressApt.Text = .Item("AddressApt")
                    lblCityStateZipcode.Text = .Item("CityStateZipcode")
                    lblDayPhone.Text = .Item("DayPhone")
                    lblEveningPhone.Text = .Item("EveningPhone")
                    lblEmail.Text = GetCustomerID(Request, Response)

                    lblShipName.Text = .Item("ShipName")
                    lblShipCompany.Text = .Item("ShipCompany")
                    lblShipAddressApt.Text = .Item("ShipAddressApt")
                    lblShipCityStateZipcode.Text = .Item("ShipCityStateZipcode")
                    lblScross.Text = .Item("Scross")
                    lblShipEmail.Text = .Item("ShipEmail")
                    lblShipDayPhone.Text = .Item("ShipDayPhone")
                    lblShipEveningPhone.Text = .Item("ShipEveningPhone")

                    fTotal = .Item("TotalValue")
                    fSubTotal = .Item("SubTotalValue")
                    fTax = .Item("TaxValue")
                    fShipping = .Item("ShippingValue")
                    fPromo = .Item("PromoValue")
                    f3rdPartyInsurance = .Item("n3rdPartyAmountInsAmount")


                    lblLTax.Text = "Tax Rate (" & (.Item("TaxRate") * 100).ToString & "%):"
                    lblLShipping.Text = "Shipping/Handling (" & .Item("ShipType") & "):"
                    lblShippingMethod.Text = .Item("ShipType")

                    If .Item("ShipType") = "Astor Delivery" Then
                        litShipDelDateL.Text = "Astor Truck Delivery Date:"
                        litShipDelDate.Text = "<b>" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</b>"
                    ElseIf .Item("ShipType") = "After Hours Courier" Then

                        litShipDelDateL.Text = "After Hours Courier Delivery Date:"
                        litShipDelDate.Text = "<b>" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & " in the time range " & .Item("sPMCourier") & "</b>"
                    Else
                        If .Item("b3rdPartyShipInsAgreement") = True Then
                            litShipDelDateL.Text = "3rd Party shipment will TRANSFER from Astor Wines &amp; Spirits on:"
                        Else
                            litShipDelDateL.Text = "UPS shipment will DEPART Astor Wines &amp; Spirits on:"
                        End If


                        litShipDelDate.Text = "<b>" & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & "</b>"
                    End If

                    lblShipInst.Text = .Item("ShipInst")

                    '   lblGiftNote.Text = .Item("GiftNote")
                    If RTrim(.Item("Promo")) = "" Then
                        'lblPromoCode.Text = ""
                        lblLPromo.Text = ""
                        lblPromo.Visible = False
                        lblLPromo.Visible = False
                    Else
                        'lblPromoCode.Text = .Item("Promo")
                        lblLPromo.Text = "Promo Code: " & .Item("Promo")
                        If fPromo <> 0 Then
                            fPromo = fPromo * (-1)
                        End If
                        lblPromo.Visible = True
                        lblLPromo.Visible = True
                    End If

                    '3rd party insurance
                    If .Item("n3rdPartyAmountInsAmount") = 0.0 Then
                        lbl3rdPartyIns.Text = ""
                        lblL3rdPartyIns.Text = ""
                        lbl3rdPartyIns.Visible = False
                        lblL3rdPartyIns.Visible = False
                    Else
                        lblL3rdPartyIns.Text = "3rtd Party Insurance"
                        lbl3rdPartyIns.Visible = True
                        lblL3rdPartyIns.Visible = True
                    End If

                    lblccType.Text = .Item("ccType")
                    lblccNum.Text = .Item("ccnum")
                    lblccExpDate.Text = .Item("ccExpDate")
                    litCreditCardAmount.Text = .Item("CreditCardValue")

                    ' gift card
                    pnlGiftCard.Visible = False
                    If .Item("GiftCardNumber") <> "" Then
                        pnlGiftCard.Visible = True

                        'litGiftCardNumber.Text = "XXXXXXXXXXXX" & Mid(.Item("GiftCardNumber"), 13, 4)
                        litGiftCardNumber.Text = .Item("GiftCardNumber")

                        litGiftCardAmount.Text = .Item("GiftCardValue")

                    End If

                    'If .Item("Gift") = True Then
                    '    lblGift.Text = "Gift Order"
                    '    lblGiftNote.Text = .Item("GiftNote")
                    'Else
                    '    lblGift.Text = "NOT a Gift Order"
                    '    lblGiftNote.Text = String.Empty
                    'End If

                    Dim tracker As String = String.Empty
                    Dim town As String = String.Empty
                    Dim state As String = String.Empty
                    Dim townzipstate() As String = .Item("ShipCityStateZipcode").ToString.Split(",")
                    town = townzipstate(0)
                    state = townzipstate(1).Substring(1, 2)

                    tracker &= "<script type=""text/javascript"">var pageTracker = _gat._getTracker(""UA-2355059-3"");pageTracker._initData();pageTracker._trackPageview();"
                    tracker &= " pageTracker._addTrans(""" & .Item("OrderNumber") & """, """", """ & .Item("SubTotalValue") & """, """ & .Item("TaxValue") & """, """ & .Item("ShippingValue") & """, """ & town & """, """ & state & """, ""USA"");"
                    For Each itemRow As DataRow In dsOrder.Tables(1).Rows
                        'tracker &= " pageTracker._addItem(""" & .Item("OrderNumber") & """, """ & itemRow.Item("Item") & """, """ & Replace(Trim(itemRow.Item("Name")), """", "'") & """, """", """ & itemRow.Item("UnitPrice") & """, """ & itemRow.Item("Quantity") & """);"
                        tracker &= " pageTracker._addItem(""" & .Item("OrderNumber") & """, """ & itemRow.Item("Item") & """, """ & Replace(Trim(itemRow.Item("Name")), """", "'") & """, """ & itemRow.Item("NewType") & """, """ & itemRow.Item("UnitPrice") & """, """ & itemRow.Item("Quantity") & """);"
                    Next
                    tracker &= " pageTracker._trackTrans();</script>"
                    trackerScript.Text = tracker
                    Dim trackSQLAdapter As New astorWinesTableAdapters.tblTrackingTableAdapter
                    trackSQLAdapter.Insert(Now, tracker)
                End With
            End If
        End With
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

    Protected Sub imgbReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbReturnTP.Click

        'Redirect("~/default.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
        Response.Redirect("~/default.aspx")
    End Sub
End Class
