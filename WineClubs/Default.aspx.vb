Imports WebCommon
Partial Class WineClubs_Default
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Redirect("/WineClubs.aspx")
    End Sub

End Class
