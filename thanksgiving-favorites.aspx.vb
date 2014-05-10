Imports WebCommon
'Imports System.Data
'Imports SslTools
Partial Class giftcards
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub addToCart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles addToCart.Click

        Dim intTxt As Integer
        Dim sOrderType As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim sItem As String

        intTxt = 1
        sOrderType = "Item"
        'sItem = giftCardAmount.SelectedValue

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/AstorWinesWineClubs.aspx"
            ClientScript.RegisterStartupScript(Me.GetType(), "key", "launchModal();", True)
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            'Response.Redirect("~/ShoppingCart.aspx")
            'ClientScript.RegisterStartupScript(Me.GetType(), "popup", "CB_Open('href=mycontent,,html=<b>test</b>');", True)
        End If
    End Sub

End Class
