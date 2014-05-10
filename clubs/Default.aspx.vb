Imports WebCommon

Partial Class newsletter_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("/clubs.aspx")
    End Sub
End Class