Imports WebCommon
'Imports SslTools
Partial Class Emails
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Form.Attributes.Add("action", "http://astorwines.createsend.com/t/r/s/yktytuj/")
        Me.Form.Attributes.Add("method", "post")

        'Dim form As HtmlGenericControl = DirectCast(Master.FindControl("form1"), HtmlGenericControl)
        'form.Attributes.Add("action", "http://astorwines.createsend.com/t/r/s/yktytuj/")
        'form.Attributes.Add("method", "post")

    End Sub
End Class
