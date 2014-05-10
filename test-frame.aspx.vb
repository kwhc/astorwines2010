
Partial Class frame_test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim url As String
        url = Request.QueryString("url")

        iframetag.Attributes.Add("src", url)
        permalink.NavigateUrl = url

    End Sub

End Class
