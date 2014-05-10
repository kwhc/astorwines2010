
Partial Class delivery_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad
        Response.Redirect("/DeliveryInformation.aspx")
    End Sub
End Class
