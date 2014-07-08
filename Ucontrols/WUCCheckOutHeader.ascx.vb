'Imports SslTools
Partial Class Ucontrols_WUCCheckOutHeader
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mstrPageName As String = String.Empty
        mstrPageName = Page.ToString

        mstrPageName = Replace(mstrPageName, "ASP.", "")
        mstrPageName = Replace(mstrPageName, "_aspx", ".aspx")
        mstrPageName = mstrPageName.ToLower

        Select Case mstrPageName
            Case "secure_astorcheckoutbillingnewcustomer.aspx"
                imgCheckOut.ImageUrl = "~/images/general/billing.gif"
            Case "secure_astorcheckoutbilling.aspx"
                imgCheckOut.ImageUrl = "~/images/general/billing.gif"
            Case "secure_astorcheckoutshippingnewcustomer.aspx"
                imgCheckOut.ImageUrl = "~/images/general/shipping.gif"
            Case "secure_astorcheckoutshipping.aspx"
                imgCheckOut.ImageUrl = "~/images/general/shipping.gif"
            Case "secure_astorcheckoutorderreview.aspx"
                imgCheckOut.ImageUrl = "~/images/general/review.gif"
            Case "secure_astorcheckoutconfirmation.aspx"
                imgCheckOut.ImageUrl = "~/images/general/confirmation.gif"
                phRequiredField.Visible = False
            Case "secure_astorcheckoutconfirmation.aspx"
                imgCheckOut.ImageUrl = "~/images/general/as_checkout_hd5r.gif"
        End Select
    End Sub
End Class
