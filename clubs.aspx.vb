Imports WebCommon
'Imports System.Data
'Imports SslTools
Partial Class Clubs
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub addToCartJustReds_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartJustReds.Click
        addClubToCart(justRedsDD)
    End Sub

    Protected Sub addToCartDiscovery_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartDiscovery.Click
        addClubToCart(discoveryDD)
    End Sub

    Protected Sub addToCartPassport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartPassport.Click
        addClubToCart(passportDD)
    End Sub

    Protected Sub addToCartItalian_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartItalian.Click
        addClubToCart(italianDD)
    End Sub

    Protected Sub addToCartGrand_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartGrand.Click
        addClubToCart(grandDD)
    End Sub

    Protected Sub addToCartPlatinum_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartPlatinum.Click
        addClubToCart(platinumDD)
    End Sub

    Protected Sub addToCartTop10_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartTop10.Click
        addClubToCart(top10DD)
    End Sub

    Protected Sub addToCartOrganic_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartOrganic.Click
        addClubToCart(organicDD)
    End Sub

    Protected Sub addToCartInterationalExplorer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartInterationalExplorer.Click
        addClubToCart(internationalExplorerDD)
    End Sub


    Public Function spiritsClubNote() As String
        Return "Please note that Spirits Clubs must be purchased separately from other items."
    End Function

    Public Function wineClubNote() As String
        Return "Please note that Wine Clubs must be purchased separately from other items."
    End Function

    Protected Sub ibAddToCartAmericanCraft_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddToCartAmericanCraft.Click
        addClubToCart(ddlAmericanCraft)
    End Sub

    Protected Sub ibAddToCartATasteOfScotland_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibAddToCartATasteOfScotland.Click
        addClubToCart(ddlATasteOfScotland)
    End Sub

    Protected Sub ibaddToCartSmoky_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibaddToCartSmoky.Click
        addClubToCart(ddlSmoky)
    End Sub

    Sub addClubToCart(ByVal drop As DropDownList)
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = drop.SelectedValue()

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/clubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/clubs.aspx"
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub addToCartFrench_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCartFrench.Click
        addClubToCart(frenchDD)
    End Sub
End Class