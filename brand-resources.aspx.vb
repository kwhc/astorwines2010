
Partial Class brand_resources
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim pageTitle As String = "Astor Wines & Spirits Trademark Resources"

        litPageTitle.Text = pageTitle
        Page.Title = pageTitle

    End Sub
End Class
