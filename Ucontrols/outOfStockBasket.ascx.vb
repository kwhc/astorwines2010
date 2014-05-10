
Partial Class Ucontrols_outOfStockBasket
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        pageCheck()

    End Sub

    Sub pageCheck()
        Dim pageFile As String

        pageFile = Request.Url.ToString

        If pageFile.Contains("ShoppingCart") OrElse pageFile.Contains("merge") Then
            litIntroMsg.Text = "These items will be added to your saved cart unless you choose to remove them."
        ElseIf pageFile.Contains("shoppingCartSaved") Then
            litIntroMsg.Text = ""
        End If

    End Sub

End Class
