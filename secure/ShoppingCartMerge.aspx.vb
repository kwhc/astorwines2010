Imports WebCommon
Imports System.Data
Imports Infragistics.WebUI.WebDataInput
Imports System.IO
Imports AstorDataClass
Partial Class ShoppingCartMerge
    Inherits WebPageBase

    Private intTxt As Int16
    Private sOrderType As String
    Private sItem As String
    Private iResultCount As Int16
    Private dsn As String = WebAppConfig.ConnectString
    Private email As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        ' If page is not being loaded in response to postback
        If Not Page.IsPostBack Then
            lblShipToStatesCodes.Text = Application("NotShipToStatesDesc")

            If Context.User.Identity.Name <> "" Then
                email = Context.User.Identity.Name
            Else
                email = ""
            End If

            PopulateShoppingCartList()
        End If

        'If Not Session("ReturnUrl") Is Nothing Then
        '    ReturnUrl.Value = Session("ReturnUrl")
        '    Session("ReturnUrl") = Nothing

        'Else
        '    ReturnUrl.Value = "~/default.aspx"
        'End If
        'hyplReturnToShopping.NavigateUrl = ReturnUrl.Value

    End Sub
    Private Sub PopulateShoppingCartList()

        ' Popoulate list with updated shopping cart data
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim ds As DataSet = cart.GetShoppingCartMergeItems(GetCustomerID(Request, Response))

        If ds.Tables(0).Rows.Count = 0 Then
            If Context.User.Identity.Name <> "" Then
                Dim cust As New AstorwinesCommerce.Customer(getConnStr())
                If cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then
                    Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
                Else
                    Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")
                End If
            Else
                Response.Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut)
            End If
        Else
            datMyList.DataSource = ds
            datMyList.DataBind()

        End If

    End Sub
    Protected Sub UpdateShoppingCartDatabase()

        Dim inventory As New AstorwinesCommerce.ProductsDB(getConnStr())
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())

        ' Iterate through all rows within shopping cart list
        Dim i As Integer
        For i = 0 To datMyList.Items.Count - 1

            ' Obtain references to row's controls
            Dim quantityTxt As WebNumericEdit = datMyList.Items(i).FindControl("wneQuantity")
            Dim shoppingCartIDTxt As HtmlInputHidden = datMyList.Items(i).FindControl("ShoppingCartID")
            Dim OrigQuantityTxt As HtmlInputHidden = datMyList.Items(i).FindControl("OrigQuantity")

            ' Convert quantity to a number
            Dim Quantity As Integer = Int32.Parse(quantityTxt.Text)
            Dim OrigQuantity As Integer = Int32.Parse(OrigQuantityTxt.Value)


            If OrigQuantity <> Quantity Then
                cart.UpdateShoppingCartMergeItem(Int32.Parse(shoppingCartIDTxt.Value), Quantity)
            End If

        Next

    End Sub
    Protected Sub ResetShoppingCartMerge()

        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())

        cart.ResetShoppingCartMerge(GetCustomerID(Request, Response))

    End Sub
    Protected Sub UpdateCart()

        ' Update Shopping Cart
        UpdateShoppingCartDatabase()

        ' Repopulate ShoppingCart List
        PopulateShoppingCartList()

    End Sub
    Private Sub AddAllMergeItems()

        Dim cart As New AstorwinesCommerce.CartDB(WebAppConfig.ConnectString)
        Dim ds As DataSet = cart.GetShoppingCartMergeItems(GetCustomerID(Request, Response))
        Dim _oWebCommon As New WebPageBase
        Dim _drRow As DataRow
       

        Dim sOrderType As String = String.Empty
        Dim sItem As String = String.Empty
        Dim iQty As Integer = 0


        Try
            For Each _drRow In ds.Tables(0).Rows
                With _drRow

                    sItem = .Item("item")
                    iQty = .Item("Quantity")
                    sOrderType = .Item("UnitType")

                End With

                If cart.CheckCartForWineClub(_oWebCommon.GetCustomerID(Request, Response), sItem) Then
                    Dim strUrl As String = Request.Url.ToString()
                    'Session("ReturnUrl") = strUrl
                    'Session("ShoppingCartAddError") = "Add Error"
                    'Response.Redirect("~/secure/ShoppingCartMerge.aspx")
                Else
                    cart.AddShoppingCartItem(_oWebCommon.GetCustomerID(Request, Response), sItem, sOrderType, iQty)
                    cart.RemoveShoppingCartMergeItem(_oWebCommon.GetCustomerID(Request, Response), sItem, sOrderType, iQty)
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Protected Sub datMyList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datMyList.ItemCommand

        Dim qty As WebNumericEdit
        Dim cart As New AstorwinesCommerce.CartDB(WebAppConfig.ConnectString)
        Dim _oWebCommon As New WebPageBase
        qty = e.Item.FindControl("wneQuantity")
        intTxt = qty.Value

        Dim type As String
        type = CType(e.Item.FindControl("lblUnitType"), Label).Text
        sOrderType = type

        Dim item As ImageButton
        item = e.Item.FindControl("imgbAddToCart")
        sItem = item.CommandArgument
        Try

            UpdateShoppingCartDatabase()

            If cart.CheckCartForWineClub(_oWebCommon.GetCustomerID(Request, Response), sItem) Then
                Dim strUrl As String = Request.Url.ToString()
                Session("ReturnUrl") = strUrl
                Session("ShoppingCartAddError") = "Add Error"
                'Response.Redirect("~/secure/ShoppingCartMerge.aspx")
                PopulateShoppingCartList()
            Else
                cart.AddShoppingCartItem(_oWebCommon.GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
                cart.RemoveShoppingCartMergeItem(_oWebCommon.GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
                Dim strUrl As String = Request.Url.ToString()
                Session("ReturnUrl") = strUrl
                'Response.Redirect("~/secure/ShoppingCartMerge.aspx")
                PopulateShoppingCartList()
            End If


        Catch ex As Exception
            Throw ex
        End Try


    End Sub
    Protected Sub datMyList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datMyList.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow
            'Out of Stock Messages
            Dim outOfStockMsg As String = "This item is currently out of stock."
            Dim preOrderMsg As String = "This item is expected to arrive soon."
            Dim reorderMsg As String = "This is expected to be back in stock soon."

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
                CType(e.Item.FindControl("wneQuantity"), WebNumericEdit).MaxValue = Convert.ToInt16(myRow("Allocated"))
            Else
                e.Item.FindControl("lblLimitedQty").Visible = False
            End If

            CType(e.Item.FindControl("imgbAddToCart"), ImageButton).CommandArgument = myRow("Item").ToString()
            CType(e.Item.FindControl("imgbAddToCart"), ImageButton).ToolTip = "Click to Add " + RTrim(myRow("Name")) + " to your Shopping Cart"

            Dim unitTotal As Decimal

            unitTotal = myRow("UnitPrice") * Convert.ToDecimal(myRow("Quantity"))

            CType(e.Item.FindControl("imgbAddToCart"), ImageButton).OnClientClick = "_gaq.push(['_trackEvent', 'Add to Cart', 'Add Item', 'Merge Cart', '" + String.Format("{0:c}", unitTotal) + "']);"

            If myRow("IsItemAvailable").ToString() = "AIS" Then
                e.Item.FindControl("pnlInStock").Visible = True
                e.Item.FindControl("pnlOutOfStock").Visible = False
                CType(e.Item.FindControl("litOutOfStockMsg"), Literal).Text = ""
            Else
                e.Item.FindControl("pnlInStock").Visible = False
                e.Item.FindControl("pnlOutOfStock").Visible = True
                CType(e.Item.FindControl("litOutOfStockMsg"), Literal).Text = outOfStockMsg
                CType(e.Item.FindControl("WaitLink"), Literal).Text = "<a href='/AstorWaitList.aspx?item=" + myRow("item") + "&email=" + email + "&height=300&width=200' rel='clearbox[width=300,,height=200]' >Notify Me</a>"
            End If

        End If

    End Sub
    Protected Sub imgbCheckOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbCheckOut.Click
        ' Update Shopping Cart
        Dim cust As New AstorwinesCommerce.Customer(getConnStr())

        ResetShoppingCartMerge()
        'If CheckShoppingCartListHasItems() Then
        If Context.User.Identity.Name <> "" Then
            If cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then
                Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
            Else
                Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")
            End If
        Else
            Response.Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut)
        End If
        'End If

    End Sub

    Protected Sub imgbAddAllCheckOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbAddAllCheckOut.Click

        ' Update Shopping Cart
        Dim cust As New AstorwinesCommerce.Customer(getConnStr())

        UpdateShoppingCartDatabase()

        AddAllMergeItems()
        'If CheckShoppingCartListHasItems() Then
        If Context.User.Identity.Name <> "" Then
            If cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then
                Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
            Else
                Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")
            End If
        Else
            Response.Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut)
        End If
        'End If

    End Sub

    Protected Function GetGoogleAnalyticsEventTracking(ByVal category As String, ByVal action As String, ByVal label As String, ByVal value As Integer) As String
        Return String.Format(" _gaq.push(['_trackEvent', '{0}', '{1}', '{2}', '{3}']);", category, action, label, value)
    End Function

End Class
