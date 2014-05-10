
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/email/20130828-roseSale/roseSaleHeader.jpg"
        imgHero.Width = 526
        litIntro.Text = "<p class='fancy'>Today Only!<br/>Wednesday, August 28th</p>" & _
            "<p class='fancy'>Still and sparkling, in every shade of pink. It’s summer in a bottle – stock up today!</p>"
        litRestrictions.Text = "*While current supplies last. For items already on sale, the greater of (a) the pre-existing discount or (b) a discount of 25% off the full retail price will apply. Case discounts will not apply to sale items. Sale does not apply to special orders. No further discounts.<br/>8/28/13 only."
    End Sub
End Class
