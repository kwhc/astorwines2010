Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_MyAccountShippingAddresses
    Inherits WebPageBase
    Private Cust As New AstorwinesCommerce.Customer(getConnStr())
    Private dsCust As New DataSet
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblShipToStatesCodes.Text = Application("ShipToStatesCodes")
            dsCust = Cust.GetCustomerShippingInfoFormatted(GetCustomerID(Request, Response), String.Empty, "0000")
            If dsCust.Tables.Count > 0 Then
                If dsCust.Tables(0).Rows.Count > 0 Then
                    WUCShippingName1.Visible = True
                    WUCShippingNameEdit1.Visible = False
                    lnkbEditShipping.Visible = True
                    PopulateCustomerShipToCurrent()
                    ddlShipping.Visible = True
                    lblLShipping.Visible = True
                    lnkbAddShipping.Visible = True
                    lnkbDeleteShipping.Visible = True
                    imgbSaveChangesBottom.Visible = False
                    imgbSaveChangesTop.Visible = False
                    LoadShippingCombo()
                Else
                    WUCShippingName1.Visible = False
                    WUCShippingNameEdit1.Visible = True
                    lnkbEditShipping.Visible = False
                    lnkbAddShipping.Visible = False
                    lnkbDeleteShipping.Visible = False
                    ddlShipping.Visible = False
                    lblLShipping.Visible = False
                    imgbSaveChangesBottom.Visible = True
                    imgbSaveChangesTop.Visible = True
                End If
            Else
                WUCShippingName1.Visible = False
                WUCShippingNameEdit1.Visible = True
                lnkbEditShipping.Visible = False
                lnkbAddShipping.Visible = False
                lnkbDeleteShipping.Visible = False
                ddlShipping.Visible = False
                lblLShipping.Visible = False
                imgbSaveChangesBottom.Visible = True
                imgbSaveChangesTop.Visible = True
            End If
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
    Private Sub SaveChanges()
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
            If WUCShippingNameEdit1.Visible = True Then
                SaveCustomerShipping()
            End If

            'Redirect("~/secure/MyAccountShippingAddresses.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
            Response.Redirect("~/secure/MyAccountShippingAddresses.aspx")


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
                        Else
                            WUCShippingNameEdit1.ShippingZipCode = .Item("ShipZipCode")
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
                ddlShipping.Visible = True
                lblLShipping.Visible = True
                lnkbAddShipping.Visible = True
                lnkbDeleteShipping.Visible = True
                imgbSaveChangesBottom.Visible = False
                imgbSaveChangesTop.Visible = False
            Else
                WUCShippingName1.Visible = False
                WUCShippingNameEdit1.Visible = True
                lnkbEditShipping.Visible = False
                lnkbAddShipping.Visible = False
                lnkbDeleteShipping.Visible = False
                ddlShipping.Visible = False
                lblLShipping.Visible = False
                imgbSaveChangesBottom.Visible = True
                imgbSaveChangesTop.Visible = True
            End If

        Else
            WUCShippingName1.Visible = False
            WUCShippingNameEdit1.Visible = True
            lnkbEditShipping.Visible = False
            lnkbAddShipping.Visible = False
            lnkbDeleteShipping.Visible = False
            ddlShipping.Visible = False
            lblLShipping.Visible = False
            imgbSaveChangesBottom.Visible = True
            imgbSaveChangesTop.Visible = True
        End If
    End Sub
    Private Sub SaveCustomerShipping()
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


        End With


        Cust.UpdateCustomerShipTo(hstCustomerInfo)

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
    Private Sub DeleteShippingAddress()
        Dim Ids As String = WUCShippingName1.ShippingIds

        Cust.DeleteCustomerShippingInfo(GetCustomerID(Request, Response), String.Empty, Ids)
    End Sub

    Protected Sub imgbSaveChangesTB_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbSaveChangesBottom.Click, imgbSaveChangesTop.Click
        SaveChanges()
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
                lnkbAddShipping.Visible = False
                lnkbDeleteShipping.Visible = False
                ddlShipping.Visible = False
                lblLShipping.Visible = False
                imgbSaveChangesBottom.Visible = True
                imgbSaveChangesTop.Visible = True
                PopulateCustomerShipTo()
            End If
        End If

    End Sub

    Protected Sub lnkbAddShipping_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbAddShipping.Click
        WUCShippingName1.Visible = False
        WUCShippingNameEdit1.Visible = True
        lnkbEditShipping.Visible = False
        lnkbAddShipping.Visible = False
        lnkbDeleteShipping.Visible = False
        ddlShipping.Visible = False
        lblLShipping.Visible = False
        imgbSaveChangesBottom.Visible = True
        imgbSaveChangesTop.Visible = True
    End Sub

    Protected Sub ddlShipping_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlShipping.SelectedIndexChanged
        ChangeShipping()
    End Sub
    Protected Sub lnkbDeleteShipping_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbDeleteShipping.Click
        DeleteShippingAddress()

        dsCust = Cust.GetCustomerShippingInfoFormatted(GetCustomerID(Request, Response), String.Empty, "00")
        If dsCust.Tables.Count > 0 Then
            If dsCust.Tables(0).Rows.Count > 0 Then
                WUCShippingName1.Visible = True
                WUCShippingNameEdit1.Visible = False
                lnkbEditShipping.Visible = True
                PopulateCustomerShipToCurrent()
                ddlShipping.Visible = True
                lblLShipping.Visible = True
                lnkbAddShipping.Visible = True
                lnkbDeleteShipping.Visible = True
                LoadShippingCombo()
            Else
                WUCShippingName1.Visible = False
                WUCShippingNameEdit1.Visible = True
                lnkbEditShipping.Visible = False
                lnkbAddShipping.Visible = False
                lnkbDeleteShipping.Visible = False
                ddlShipping.Visible = False
                lblLShipping.Visible = False
            End If
        Else
            WUCShippingName1.Visible = False
            WUCShippingNameEdit1.Visible = True
            lnkbEditShipping.Visible = False
            lnkbAddShipping.Visible = False
            lnkbDeleteShipping.Visible = False
            ddlShipping.Visible = False
            lblLShipping.Visible = False
        End If
    End Sub
End Class
