
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/email/2013-11-13-redSale/2013-11-13-redSale-header.jpg"
        imgHero.Width = 526
        litIntro.Text = "<p class='fancy'>Today Only!<br/>Wednesday, November 13th</p>" & _
            "<p class='fancy'>Dry, sweet, still, sparkling… <br/>ALL red wines are on sale today.</p>" & _
            "<p class='fancy'>You’ll find some of the most<br/>popular styles below.</p>"
        litRestrictions.Text = "*While current supplies last. For items already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price applies. Case discounts do not apply to sale items. Sale does not apply to special orders. No further discounts. 11/13/13 only."
        Page.Title = "20% Off All Red Wines Today"
    End Sub
End Class
