Imports WebCommon
'Imports System.Data
'Imports SslTools
Partial Class AstorWinesWineClubs
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString
    Protected Sub addToCartJustReds_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartJustReds.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = justRedsDD.SelectedValue

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub
    Protected Sub addToCartDiscovery_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartDiscovery.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = discoveryDD.SelectedValue

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartPassport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartPassport.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = passportDD.SelectedValue

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartItalian_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartItalian.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = italianDD.SelectedValue

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartGrand_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartGrand.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = grandDD.SelectedValue

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartPlatinum_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartPlatinum.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = platinumDD.SelectedValue

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartTop10_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartTop10.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String


        intTxt = 1
        sOrderType = "Item"
        sItem = top10DD.SelectedValue()

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartOrganic_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartOrganic.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = organicDD.SelectedValue()

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartInterationalExplorer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartInterationalExplorer.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = internationalExplorerDD.SelectedValue()

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Response.Redirect("~/ShoppingCart.aspx")
        End If

    End Sub
End Class
