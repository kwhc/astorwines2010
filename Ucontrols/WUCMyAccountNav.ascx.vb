'Imports SslTools
Partial Class Ucontrols_WUCMyAccountNav
    Inherits System.Web.UI.UserControl

    Protected Sub mnuMyAccount_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles mnuMyAccount.MenuItemClick
        Select Case e.Item.Value
            Case "summary"
                'Redirect("~/secure/MyAccountSummary.aspx", RedirectOptions.AbsoluteHttps)  https_transfer_6/18/08
                Response.Redirect("~/secure/MyAccountSummary.aspx")
            Case "email"
                'Redirect("~/secure/MyAccountEmailAddresses.aspx", RedirectOptions.AbsoluteHttps)  https_transfer_6/18/08
                Response.Redirect("~/secure/MyAccountEmailAddresses.aspx")
            Case "billing"
                'Redirect("~/secure/MyAccountCreditCardBillingAddresses.aspx", RedirectOptions.AbsoluteHttps)  https_transfer_6/18/08
                Response.Redirect("~/secure/MyAccountCreditCardBillingAddresses.aspx")
            Case "shipping"
                'Redirect("~/secure/MyAccountShippingAddresses.aspx", RedirectOptions.AbsoluteHttps)  https_transfer_6/18/08
                Response.Redirect("~/secure/MyAccountShippingAddresses.aspx")
            Case "history"
                'Redirect("~/secure/MyAccountOrderHistory.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
                Response.Redirect("~/secure/MyAccountOrderHistory.aspx")
        End Select

    End Sub
End Class
