
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/email/promotions/aws-staff-pick-sale-header.jpg"
        imgHero.Width = 526
        litIntro.Text = "<p class='fancy'>15% off all spirits Staff Picks</p><p class='fancy'>25% off all wine Staff Picks</p><p class='fancy'>On sale today: the bottles we love most!<br/>Click below to see all of our Staff Picks:</p>"
        litRestrictions.Text = "Sale prices apply August 10, 2013 only, while on-hand supplies last. No further discounts."
    End Sub
End Class
