Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class MyAccountSummary
    Inherits WebPageBase
    Private Cust As New AstorwinesCommerce.Customer(getConnStr())
    Private dsCust As New DataSet
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dsCust = Cust.GetCustomerSummaryFormatted(GetCustomerID(Request, Response), String.Empty)
        If dsCust.Tables.Count > 0 Then
            If dsCust.Tables(0).Rows.Count > 0 Then
                WUCBillingName1.Visible = True
                lblBillingNone.Visible = False
                PopulateCustomerBillingCurrent()
            Else
                WUCBillingName1.Visible = False
                lblBillingNone.Visible = True
            End If
            If dsCust.Tables(1).Rows.Count > 0 Then
                WUCShippingName1.Visible = True
                lblShippingNone.Visible = False
                PopulateCustomerShipToCurrent()
            Else
                WUCShippingName1.Visible = False
                lblShippingNone.Visible = True
            End If
            If dsCust.Tables(2).Rows.Count > 0 Then
                WUCCreditCardNoCVV1.Visible = True
                lblCreditCardNone.Visible = False
                PopulateCustomerCreditCardCurrent()
            Else
                WUCCreditCardNoCVV1.Visible = False
                lblCreditCardNone.Visible = True
            End If
            If dsCust.Tables(3).Rows.Count > 0 Then
                lblInum.Visible = True
                lblOrderTotal.Visible = True
                lblOrderStatus.Visible = True
                lblPlacedOn.Visible = True
                lblLInum.Visible = True
                lblLOrderTotal.Visible = True
                lblLOrderStatus.Visible = True
                lblLPlacedOn.Visible = True
                lblMostRecentOrder.Visible = False
                PopulateRecentOrder()
            Else
                lblMostRecentOrder.Visible = True
                lblInum.Visible = False
                lblOrderTotal.Visible = False
                lblOrderStatus.Visible = False
                lblPlacedOn.Visible = False
                lblLInum.Visible = False
                lblLOrderTotal.Visible = False
                lblLOrderStatus.Visible = False
                lblLPlacedOn.Visible = False
            End If

        Else
            WUCBillingName1.Visible = False
            lblBillingNone.Visible = True
            WUCShippingName1.Visible = False
            lblShippingNone.Visible = True
            WUCCreditCardNoCVV1.Visible = False
            lblCreditCardNone.Visible = True
        End If

    End Sub
    Private Sub PopulateCustomerBillingCurrent()
        With dsCust.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    WUCBillingName1.BillingEmail = GetCustomerID(Request, Response)
                    If .Item("Name") Is DBNull.Value Then
                        WUCBillingName1.BillingName = String.Empty
                        lblBillingNone.Visible = True
                    Else
                        WUCBillingName1.BillingName = .Item("Name")
                    End If
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
                    '                    WUCBillingName1.MailingList = .Item("bMailingList")
                End With
            End If
        End With
    End Sub
    Private Sub PopulateCustomerCreditCardCurrent()
        With dsCust.Tables(2)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    WUCCreditCardNoCVV1.CCNameValue = .Item("ccName")
                    WUCCreditCardNoCVV1.CCRowIDValue = .Item("ccrowid")
                    WUCCreditCardNoCVV1.CCTypeValue = .Item("cctype")
                    WUCCreditCardNoCVV1.CreditCardNumValue = .Item("ccnum")
                    WUCCreditCardNoCVV1.CCYYYYValue = .Item("ccdateyy")
                    WUCCreditCardNoCVV1.CCMMValue = .Item("ccdatemm")
                    'WUCCreditCardNoCVV1.CVVValue = String.Empty
                    WUCCreditCardNoCVV1.CCRowIDUValue = .Item("ccRowIDU").ToString
                    WUCCreditCardNoCVV1.CreditCardDefault = .Item("bDefault")

                End With
            End If
        End With

    End Sub
    Private Sub PopulateCustomerShipToCurrent()
        If dsCust.Tables.Count > 0 Then
            With dsCust.Tables(1)
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
    Private Sub PopulateRecentOrder()
        If dsCust.Tables.Count > 0 Then
            With dsCust.Tables(3)
                If .Rows.Count > 0 Then
                    With .Rows(0)
                        lblInum.Text = .Item("OrderNumber")
                        lblPlacedOn.Text = .Item("Ordered").ToString
                        lblOrderTotal.Text = String.Format("{0:C}", .Item("TotalValue"))
                        lblOrderStatus.Text = .Item("sOrderStatus")

                    End With
                End If
            End With
        End If
    End Sub

    Protected Sub imgbEditBillingAddress_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbEditBillingAddress.Click, imgbEditCreditCardInfo.Click
        'Redirect("~/secure/MyAccountCreditCardBillingAddresses.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
        Response.Redirect("~/secure/MyAccountCreditCardBillingAddresses.aspx")
    End Sub

    Protected Sub imgbEditEmailAddress_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbEditEmailAddress.Click
        'Redirect("~/secure/MyAccountEmailAddresses.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
        Response.Redirect("~/secure/MyAccountEmailAddresses.aspx")
    End Sub

    Protected Sub imgbEditShippingAddress_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbEditShippingAddress.Click
        'Redirect("~/secure/MyAccountShippingAddresses.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
        Response.Redirect("~/secure/MyAccountShippingAddresses.aspx")
    End Sub
End Class
