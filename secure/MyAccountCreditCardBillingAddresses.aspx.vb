Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_MyAccountCreditCardBillingAddresses
    Inherits WebPageBase
    Private Cust As New AstorwinesCommerce.Customer(getConnStr())
    Private dsCust As New DataSet
    Private dsCC As New DataSet
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dsCust = Cust.GetCustomerInfoFormatted(GetCustomerID(Request, Response), String.Empty)
            If dsCust.Tables.Count > 0 Then
                If dsCust.Tables(0).Rows.Count > 0 And Not dsCust.Tables(0).Rows(0).Item("Name") Is DBNull.Value Then
                    WUCBillingName1.Visible = True
                    WUCBillingNameEdit1.Visible = False
                    lnkbEditBilling.Visible = True
                    imgbSaveChangesBottom.Visible = False
                    imgbSaveChangesTop.Visible = False
                    PopulateCustomerBillingCurrent()
                Else
                    WUCBillingName1.Visible = False
                    WUCBillingNameEdit1.Visible = True
                    imgbSaveChangesBottom.Visible = True
                    imgbSaveChangesTop.Visible = True
                    lnkbEditBilling.Visible = False
                End If
            Else
                WUCBillingName1.Visible = False
                WUCBillingNameEdit1.Visible = True
                imgbSaveChangesBottom.Visible = True
                imgbSaveChangesTop.Visible = True
                lnkbEditBilling.Visible = False
            End If

            dsCC = Cust.GetCCInfoFormatted(GetCustomerID(Request, Response), String.Empty, 0, "", True)
            If dsCC.Tables.Count > 0 Then
                If dsCC.Tables(0).Rows.Count > 0 Then

                    WUCCreditCardNoCVV1.Visible = True
                    WUCCreditCardEdit1.Visible = False
                    PopulateCustomerCreditCardCurrent()
                    ddlCreditCard.Visible = True
                    lblLCC.Visible = True
                    lnkbAddCreditCard.Visible = True
                    lnkbDeleteCreditCard.Visible = True
                    imgbSaveChangesBottom.Visible = False
                    imgbSaveChangesTop.Visible = False
                    LoadCCCombo()
                Else
                    WUCCreditCardNoCVV1.Visible = False
                    WUCCreditCardEdit1.Visible = True
                    ddlCreditCard.Visible = False
                    lblLCC.Visible = False
                    lnkbAddCreditCard.Visible = False
                    lnkbDeleteCreditCard.Visible = False
                    imgbSaveChangesBottom.Visible = True
                    imgbSaveChangesTop.Visible = True
                End If
            Else
                WUCCreditCardNoCVV1.Visible = False
                WUCCreditCardEdit1.Visible = True
                ddlCreditCard.Visible = False
                lblLCC.Visible = False
                lnkbAddCreditCard.Visible = False
                lnkbDeleteCreditCard.Visible = False
                imgbSaveChangesBottom.Visible = True
                imgbSaveChangesTop.Visible = True
            End If

        End If
    End Sub
    Private Sub SaveChanges()
        Try
            Dim sMsgBill As String = "Please correct errors on form! "
            If WUCBillingNameEdit1.Visible = True Then
                If WUCBillingNameEdit1.bValidateBillingInfo() Then
                    Dim _webutils As New WebUtils
                    Dim t As Type = Me.GetType

                    _webutils.CreateMessageAlert(Me, t, sMsgBill, "strKey2")
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

            If WUCBillingNameEdit1.Visible = True Then
                SaveCustomerBilling()

            End If
            If WUCCreditCardEdit1.Visible = True Then
                SaveCustomerCC()
            End If
            'Redirect("~/secure/MyAccountCreditCardBillingAddresses.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
            Response.Redirect("~/secure/MyAccountCreditCardBillingAddresses.aspx")

        Catch ex As Exception
            Throw ex
        Finally

        End Try

    End Sub


    Private Sub PopulateCustomerBillingCurrent()
        With dsCust.Tables(0)
            If .Rows.Count > 0 Then
                With .Rows(0)
                    WUCBillingName1.BillingEmail = GetCustomerID(Request, Response)
                    If .Item("Name") Is DBNull.Value Then
                        WUCBillingName1.BillingName = String.Empty
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
        With dsCC.Tables(0)
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
    Private Sub ChangeToEditBilling()
        dsCust = Cust.GetCustomerInfoFormatted(GetCustomerID(Request, Response), String.Empty)
        If dsCust.Tables.Count > 0 Then
            WUCBillingName1.Visible = False
            WUCBillingNameEdit1.Visible = True
            lnkbEditBilling.Visible = False
            imgbSaveChangesBottom.Visible = True
            imgbSaveChangesTop.Visible = True
            PopulateCustomerBilling()
            'Else
            '    WUCBillingName1.Visible = False
            '    WUCBillingNameEdit1.Visible = True
        End If

    End Sub
    Private Sub ChangeCreditCard()
        Dim iCardID As Int16

        iCardID = ddlCreditCard.SelectedValue

        dsCC = Cust.GetCCInfoFormatted(GetCustomerID(Request, Response), String.Empty, iCardID, "", False)
        If dsCC.Tables.Count > 0 Then
            If dsCC.Tables(0).Rows.Count > 0 Then

                WUCCreditCardNoCVV1.Visible = True
                WUCCreditCardEdit1.Visible = False
                PopulateCustomerCreditCardCurrent()
                ddlCreditCard.Visible = True
                lblLCC.Visible = True
                lnkbAddCreditCard.Visible = True
                lnkbDeleteCreditCard.Visible = True
            Else
                WUCCreditCardNoCVV1.Visible = False
                WUCCreditCardEdit1.Visible = True
                ddlCreditCard.Visible = False
                lblLCC.Visible = False
                lnkbAddCreditCard.Visible = False
                lnkbDeleteCreditCard.Visible = False
            End If
        Else
            WUCCreditCardNoCVV1.Visible = False
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
                    '                    WUCBillingNameEdit1.MailingList = .Item("bMailingList")
                End With
            End If
        End With

    End Sub
    Private Sub SaveCustomerCC()
        Dim hstCustomerCCInfo As New Hashtable
        Dim sIdtNew As String

        sIdtNew = WUCBillingNameEdit1.BillingIdtNew

        With hstCustomerCCInfo
            .Item("CustomerNumber") = GetCustomerID(Request, Response)
            .Item("Idt") = String.Empty
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

        Cust.UpdateCustomerCCInfo(hstCustomerCCInfo)

    End Sub
    Private Sub SaveCustomerBilling()
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

        Cust.UpdateCustomer(hstCustomerInfo)

    End Sub
    Private Sub DeleteCreditCard()
        Dim ccRowID As Int32 = WUCCreditCardNoCVV1.CCRowIDValue
        Dim ccRowIDU As String = WUCCreditCardNoCVV1.CCRowIDUValue

        Cust.DeleteCustomerCCInfo(GetCustomerID(Request, Response), String.Empty, ccRowID, ccRowIDU)
    End Sub
    Protected Sub lnkbEditBilling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbEditBilling.Click
        dsCust = Cust.GetCustomerInfo(GetCustomerID(Request, Response), String.Empty)
        If dsCust.Tables.Count > 0 Then
            WUCBillingName1.Visible = False
            WUCBillingNameEdit1.Visible = True
            lnkbEditBilling.Visible = False
            imgbSaveChangesBottom.Visible = True
            imgbSaveChangesTop.Visible = True
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
        WUCCreditCardNoCVV1.Visible = False
        WUCCreditCardEdit1.Visible = True
        ddlCreditCard.Visible = False
        lblLCC.Visible = False
        lnkbAddCreditCard.Visible = False
        lnkbDeleteCreditCard.Visible = False
        imgbSaveChangesBottom.Visible = True
        imgbSaveChangesTop.Visible = True
    End Sub

    Protected Sub imgbSaveChangesBottom_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbSaveChangesBottom.Click, imgbSaveChangesTop.Click
        SaveChanges()
    End Sub

    Protected Sub lnkbDeleteCreditCard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbDeleteCreditCard.Click
        DeleteCreditCard()
        dsCC = Cust.GetCCInfoFormatted(GetCustomerID(Request, Response), String.Empty, 0, "", True)
        If dsCC.Tables.Count > 0 Then
            If dsCC.Tables(0).Rows.Count > 0 Then

                WUCCreditCardNoCVV1.Visible = True
                WUCCreditCardEdit1.Visible = False
                PopulateCustomerCreditCardCurrent()
                ddlCreditCard.Visible = True
                lblLCC.Visible = True
                lnkbAddCreditCard.Visible = True
                lnkbDeleteCreditCard.Visible = True
                LoadCCCombo()
            Else
                WUCCreditCardNoCVV1.Visible = False
                WUCCreditCardEdit1.Visible = True
                ddlCreditCard.Visible = False
                lblLCC.Visible = False
                lnkbAddCreditCard.Visible = False
                lnkbDeleteCreditCard.Visible = False
            End If
        Else
            WUCCreditCardNoCVV1.Visible = False
            WUCCreditCardEdit1.Visible = True
            ddlCreditCard.Visible = False
            lblLCC.Visible = False
            lnkbAddCreditCard.Visible = False
            lnkbDeleteCreditCard.Visible = False
        End If
    End Sub
End Class
