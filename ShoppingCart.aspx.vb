Imports WebCommon
Imports System.Data
Imports Infragistics.WebUI.WebDataInput
Imports System.IO
Imports AstorDataClass

'Imports SslTools
Partial Class ShoppingCart
    Inherits WebPageBase

    ' Total for shopping basket
    Public fTotal As Double = 0
    Public fShipping As Double = 0
    Public fSubTotal As Double = 0
    Public AOSType As String = String.Empty
    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Store Return Url in Page State
        'ReturnUrl.Value = ""
        'If Not Request.QueryString("ReturnUrl") Is Nothing Then
        'ReturnUrl.Value = Request.QueryString("ReturnUrl")
        'End If

        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())

        'If page is not being loaded in response to postback
        If Not Page.IsPostBack Then
            If Request.QueryString("aos") = "co" Then
                AOSType = Request.QueryString("aos")
            Else
                AOSType = "no"
            End If
            lblShipToStatesCodes.Text = Application("NotShipToStatesDesc")

            If Not Session("ShippingZipCode") Is Nothing Then
                txtzipcode.Text = Session("ShippingZipCode")
            End If
            ' If a new product to add is specified, add it to the shopping cart
            If Request.Params("Item") <> "" Then
                If cart.CheckCartForWineClub(GetCustomerID(Request, Response), Request.Params("Item")) = False Then
                    cart.AddShoppingCartItem(GetCustomerID(Request, Response), Request.Params("Item"), Request.Params("Type"), Request.Params("Quantity"))
                End If
            End If
            PopulateShoppingCartList()
            UpdateSelectedItemStatus()
            updateSignInOutMessage()
            LoadShippingCombo()
            CalcTotals()

            'Store Return Url in Page State

            'If Not Session("ReturnUrl") Is Nothing Then
            '    ReturnUrl.Value = Session("ReturnUrl")
            '    Session("ReturnUrl") = Nothing
            'End If
        End If

        If Not Session("ReturnUrl") Is Nothing Then
            ReturnUrl.Value = Session("ReturnUrl")
            Session("ReturnUrl") = Nothing
        Else
            ReturnUrl.Value = "~/default.aspx"
        End If
        hyplReturnToShopping.NavigateUrl = ReturnUrl.Value

        'If Context.User.Identity.Name <> "" Then
        '    hyplBeginCheckout.NavigateUrl = "~/secure/AstorCheckoutBilling.aspx"
        'Else
        '    hyplBeginCheckout.NavigateUrl = "~/AstorCheckoutSignin.aspx"
        'End If

        'Remote Storefront
        If Not IsNothing(Request.QueryString("remote")) = True Then
            Dim remoteStorefrontSyles As New HtmlLink
            remoteStorefrontSyles.Href = "styles/remote-storefront.css"
            remoteStorefrontSyles.Attributes("rel") = "stylesheet"
            remoteStorefrontSyles.Attributes("text") = "text/css"
            Page.Controls.Add(remoteStorefrontSyles)
        End If


    End Sub

    Private Sub UpdateSelectedItemStatus()

        'If MyList.Items <> "" Then
        If datMyList.Items.Count <> 0 Then
            'status.Text = "You have selected " & datMyList.Items.Count & " items " & "so far"
            pnlShipping_Totals.Visible = True
            datMyList.Visible = True
            '      status2.Text = "You have selected " & datMyList.Items.Count & " items " & "so far"
        Else
            status.Text = "<br />You have selected no items so far"
            pnlShipping_Totals.Visible = False
            datMyList.Visible = False
            '     status2.Text = "<b>You have selected no items so far<b/>"
        End If
        If Not Session("ShoppingCartAddError") Is Nothing Then
            If RTrim(Session("ShoppingCartAddError")) <> "" Then
                status.Text = "Wine Club orders must be purchased separately and cannot contain other items."
                status.ForeColor = Drawing.Color.Red
                Session.Remove("ShoppingCartAddError")
            End If
        End If
    End Sub

    Private Sub UpdateShoppingCartDatabase()

        Dim inventory As New AstorwinesCommerce.ProductsDB(getConnStr())
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())

        ' Iterate through all rows within shopping cart list
        Dim i As Integer
        For i = 0 To datMyList.Items.Count - 1

            ' Obtain references to row's controls
            Dim quantityTxt As WebNumericEdit = datMyList.Items(i).FindControl("wneQuantity")
            Dim remove As CheckBox = datMyList.Items(i).FindControl("Remove")
            'Dim itemTxt As TextBox = repMyList.Items(i).FindControl("Item")
            Dim shoppingCartIDTxt As HtmlInputHidden = datMyList.Items(i).FindControl("ShoppingCartID")
            Dim OrigQuantityTxt As HtmlInputHidden = datMyList.Items(i).FindControl("OrigQuantity")

            ' If removed checkbox selected, delete the item.  Otherwise, update its
            ' quantity (todo: a product quality app should only update if value was been changed)
            ' Convert quantity to a number
            Dim Quantity As Integer = Int32.Parse(quantityTxt.Text)
            Dim OrigQuantity As Integer = Int32.Parse(OrigQuantityTxt.Value)

            If remove.Checked = True Or Quantity = 0 Then
                cart.DeleteShoppingCartItem(Int32.Parse(shoppingCartIDTxt.Value))
            Else
                If OrigQuantity <> Quantity Then
                    cart.UpdateShoppingCartItem(Int32.Parse(shoppingCartIDTxt.Value), Quantity)
                End If
            End If
        Next

    End Sub

    Private Sub PopulateShoppingCartList()

        'Popoulate list with updated shopping cart data
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim ds As DataSet = cart.GetShoppingCartItems(GetCustomerID(Request, Response), AOSType)

        datMyList.DataSource = ds
        datMyList.DataBind()

        'Walk through table and calculate the total value
        Dim dt As DataTable = ds.Tables(0)
        Dim lIndex, Quantity As Integer
        Dim UnitPrice As Double

        For lIndex = 0 To dt.Rows.Count - 1
            UnitPrice = dt.Rows(lIndex)("UnitPrice")
            Quantity = dt.Rows(lIndex)("Quantity")
            If Quantity > 0 Then
                fSubTotal += UnitPrice * Quantity
            End If
        Next

        'Check for Wine Clubs
        Dim arrWineClubs As Double() = {27022, 27025, 27026, 27027, 27031, 27033, 27035, 27036, 22618, 22619, 22620, 22621, 22646, 22647, 22648, 22649, 19157, 19158, 19159, 22180, 29323, 29324, 29325, 29326, 19160, 19161, 19162, 22185, 19163, 19164, 19165, 22186, 19166, 19167, 19168, 22187, 19169, 19170, 19171, 29321, 29327, 29328, 29329, 29385, 29334, 29335, 29336, 29383, 29330, 29332, 29333}
        Dim wineClubCount As Integer = 0

        For lIndex = 0 To dt.Rows.Count - 1
            For Each club As Integer In arrWineClubs
                If club = dt.Rows(lIndex)("item") Then
                    wineClubCount = wineClubCount + 1
                End If
            Next
        Next

        If wineClubCount > 0 Then
            Session("hasWineClub") = True
        Else
            Session("hasWineClub") = False
        End If

    End Sub
    'Protected Sub datResults_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datMyList.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
    '        Dim myRowView As DataRowView
    '        Dim myRow As DataRow
    '        'Dim iLevel1Type As Int16
    '        Dim sInfo As String = String.Empty

    '        myRowView = e.Item.DataItem
    '        myRow = myRowView.Row

    '        Dim sFilePath As String
    '        sFilePath = System.Web.HttpContext.Current.Server.MapPath("~/images/itemimages/sm/")

    '        If File.Exists(sFilePath & myRow("item").ToString & "_sm.jpg") Then
    '            CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/" & myRow("item").ToString & "_sm.jpg"
    '        ElseIf File.Exists(sFilePath & myRow("item").ToString & "_sm.gif") Then
    '            CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/" & myRow("Item").ToString() & "_sm.gif"
    '        Else
    '            CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/NoImageAvailable.gif"
    '        End If
    '    End If
    'End Sub

    Private Function CheckShoppingCartListHasItems() As Boolean
        ' 
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim iItemsCount As Int16 = cart.ShoppingCartItemsCount(GetCustomerID(Request, Response))

        If iItemsCount > 0 Then
            CheckShoppingCartListHasItems = True
        Else
            CheckShoppingCartListHasItems = False
        End If

    End Function
    Private Sub updateSignInOutMessage()

        If Context.User.Identity.Name <> "" Then
            pnlSignIn.Visible = False
        Else
            pnlSignIn.Visible = True
        End If

    End Sub
    Public Sub LoadShippingCombo()
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        'load sshiptype
        Dim _dslocal As New DataSet
        Dim _dsDelDates As New DataSet
        Dim dAmountNeeded As Decimal = 0
        Dim dAmountNeededForFreeShipping As Decimal = 0
        Dim dMinAmount As Decimal = 0
        Dim Type As Int16 = 0
        Dim iSelectedIndex As Int16 = 0
        Dim _sDeliveryType As String = String.Empty
        Dim _sZipCode As String = txtzipcode.Text
        'Dim dvDatarow As DataRow
        Dim sShippingText As String = String.Empty

        If Not Session("ShippingSelectedIndex") Is Nothing Then
            iSelectedIndex = Session("ShippingSelectedIndex")
        End If

        If Len(RTrim(_sZipCode)) >= 5 Then
            Dim sCity As String = String.Empty
            Dim sState As String = String.Empty
            GetCityStateData(_sZipCode, sCity, sState)

            If RTrim(sCity) = "" Or RTrim(sState) = "" Then
                lblInvalidZip.Visible = True
                _sZipCode = ""
            Else
                lblInvalidZip.Visible = False
            End If
        ElseIf Len(RTrim(_sZipCode)) > 0 Then
            lblInvalidZip.Visible = True
            _sZipCode = ""
        Else
            lblInvalidZip.Visible = False
        End If

        _dslocal = cart.WebCalcAllShipping(GetCustomerID(Request, Response), String.Empty, _sZipCode)
        With ddlshippingMethod
            .DataSource = _dslocal.Tables(0)
            .DataMember = ""
            .DataValueField = "iShipType"
            .DataTextField = "sShipType"
            .DataBind()
        End With

        If ddlshippingMethod.Items.Count > 1 Then
            ddlshippingMethod.SelectedIndex = iSelectedIndex
        Else
            ddlshippingMethod.SelectedIndex = 0
            iSelectedIndex = 0
        End If

        cart.CheckAmountNeededShippingFree(GetCustomerID(Request, Response), String.Empty, _sZipCode, dAmountNeeded, dMinAmount, Type, dAmountNeededForFreeShipping)

        If Not Session("hasWineClub") Then
            If dAmountNeededForFreeShipping > 0 And dAmountNeededForFreeShipping < 100.0 Then
                lblShippingMsg.Visible = True
                lblShippingMsg.Text = "Your total is only <strong>$" & dAmountNeededForFreeShipping.ToString & "</strong> away for one time free shipping!"
            ElseIf dAmountNeeded >= 1 And dAmountNeeded < 99999.99 Then
                lblShippingMsg.Visible = True
                lblShippingMsg.Text = "Your total is only <strong>$" & dAmountNeeded.ToString & "</strong> away from free shipping!"
            ElseIf Type = 1 And dAmountNeeded < 1 Then
                lblShippingMsg.Visible = True
                lblShippingMsg.Text = "<b>Your order meets our minimum for free delivery!</b>"
            ElseIf Type = 2 And dAmountNeeded < 1 Then
                lblShippingMsg.Visible = True
                lblShippingMsg.Text = "<b>Your order meets our $150 minimum for free ground shipping within New York State!</b>"
            ElseIf Type = 3 And dAmountNeeded < 1 Then
                lblShippingMsg.Visible = True
                lblShippingMsg.Text = "<b>Your order is eligiable for first order free shipping!</b>"
            ElseIf Type = 4 And dAmountNeeded < 1 Then
                lblShippingMsg.Visible = True
                lblShippingMsg.Text = "<b>Your order is eligiable for first order free shipping!</b>"
            Else
                lblShippingMsg.Visible = False
            End If
        End If

        Session("ShippingZipCode") = txtzipcode.Text
        Session("ShippingSelectedIndex") = iSelectedIndex
        CalcTotals()
        'End If
    End Sub
    Private Sub GetCityStateData(ByVal sZipCode As String, ByRef sCity As String, ByRef sState As String)

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)

        Try
            _odata.GetCityStateForZipCode(sZipCode, sCity, sState, 1)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function CalcShipping() As Decimal
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim Shipping As Decimal = 0.0
        If Len(txtzipcode.Text) > 4 Then
            Shipping = cart.WebCalcShippingUsingZipCode(GetCustomerID(Request, Response), String.Empty, txtzipcode.Text, ddlshippingMethod.SelectedValue)
        Else
            Shipping = 0
        End If
        CalcShipping = Shipping
    End Function
    Private Sub CalcTotals()
        If lblInvalidZip.Visible = True Then
            fShipping = 0.0
        Else
            fShipping = CalcShipping()
        End If


        fTotal = fSubTotal + fShipping
    End Sub

    Protected Sub imgbCheckOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbCheckOut.Click
        ' Update Shopping Cart
        Dim cust As New AstorwinesCommerce.Customer(getConnStr())

        UpdateShoppingCartDatabase()
        If CheckShoppingCartListHasItems() Then
            If Context.User.Identity.Name <> "" Then
                Response.Redirect("~/secure/AstorCheckoutShoppingCart.aspx")
                'If cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then
                '    'Redirect("~/secure/AstorCheckoutBilling.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
                '    If Not IsNothing(Request.QueryString("remote")) = True Then
                '        Response.Redirect("~/secure/AstorCheckoutBilling.aspx?remote=true")
                '    Else
                '        Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
                '    End If

                'Else
                '    'Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
                '    If Not IsNothing(Request.QueryString("remote")) = True Then
                '        Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx?remote=true")
                '    Else
                '        Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")

                '    End If
                'End If
            Else
                'Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut, RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
                If Not IsNothing(Request.QueryString("remote")) = True Then
                    Response.Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut & "&remote=true")
                Else
                    Response.Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut)
                End If
            End If
        End If

    End Sub

    Protected Sub imgbUpdateCart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbUpdateCart.Click

        ' Update Shopping Cart
        UpdateShoppingCartDatabase()

        ' Repopulate ShoppingCart List
        PopulateShoppingCartList()
        UpdateSelectedItemStatus()
        LoadShippingCombo()
        CalcTotals()
    End Sub

    Protected Sub datMyList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datMyList.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row

            Dim sFilePath As String
            sFilePath = System.Web.HttpContext.Current.Server.MapPath("~/images/itemimages/sm/")

            If File.Exists(sFilePath & myRow("item").ToString & "_sm.jpg") Then
                CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/" & myRow("item").ToString & "_sm.jpg"
            ElseIf File.Exists(sFilePath & myRow("item").ToString & "_sm.gif") Then
                CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/" & myRow("Item").ToString() & "_sm.gif"
            Else
                CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/NoImageAvailable.gif"
            End If

            CType(e.Item.FindControl("hyplItemName"), HyperLink).NavigateUrl = "~/SearchResultsSingle.aspx?p=" + myRow("iLevel1Type").ToString + "&search=" + myRow("Item").ToString() + "&searchtype=Contains"
            If RTrim(myRow("UnitType")) = "Case" Then
                CType(e.Item.FindControl("lblUnitType"), Label).Text = "Case of " & myRow("pack").ToString
            Else
                CType(e.Item.FindControl("lblUnitType"), Label).Text = myRow("UnitType")
            End If

            'Limited Production:  Only X bottle(s) per customer
            If CInt(myRow("Allocated")) > 0 Then
                e.Item.FindControl("lblLimitedQty").Visible = True
                CType(e.Item.FindControl("lblLimitedQty"), Label).Text = "Limited Production:  Only " & myRow("Allocated").ToString & " bottle(s) per customer"
                CType(e.Item.FindControl("lblLimitedQty"), Label).CssClass = "muted"
                CType(e.Item.FindControl("wneQuantity"), WebNumericEdit).MaxValue = Convert.ToInt16(myRow("Allocated"))
            Else
                e.Item.FindControl("lblLimitedQty").Visible = False
            End If

            'Spirits Item Check
            If CInt(myRow("iLevel1Type")).ToString = 2 Then
                spiritMessages()
            End If

            'Common Carrier Restricted
            If myRow("bAstorTruckOnly") = True Then
                CType(e.Item.FindControl("litCommonCarrierRestricted"), Literal).Visible = True
            Else
                CType(e.Item.FindControl("litCommonCarrierRestricted"), Literal).Visible = False
            End If

        End If

    End Sub

    Protected Sub lnkbSignInNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbSignInNow.Click
        'Redirect("~/secure/AstorSignIn.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
        Response.Redirect("~/secure/AstorSignIn.aspx")
    End Sub

    Protected Sub calculateShipping_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles calculateShipping.Click

        ' Repopulate ShoppingCart List
        PopulateShoppingCartList()
        UpdateSelectedItemStatus()
        LoadShippingCombo()
        CalcTotals()

    End Sub

    Protected Sub ddlshippingMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlshippingMethod.SelectedIndexChanged

        ' Repopulate ShoppingCart List
        PopulateShoppingCartList()
        UpdateSelectedItemStatus()
        'LoadShippingCombo()
        CalcTotals()
        Session("ShippingSelectedIndex") = ddlshippingMethod.SelectedIndex
    End Sub

    Sub spiritMessages()
        'phMsgSpiritsNoAirShipping.Visible = True
        phMsgSpiritsOnlyDelivery.Visible = True
    End Sub

End Class
