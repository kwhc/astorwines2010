Imports WebCommon
'Imports System.Data
'Imports SslTools
Partial Class giftcards
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString


    Protected Sub add21750_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles add21750.Click, add24064.Click, add13601.Click, add20671.Click, add20820.Click, add21898.Click, add21997.Click, add22025.Click, add22142.Click, add22156.Click, add22183.Click, add22391.Click

        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        sItem = sender.CommandArgument
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

End Class
