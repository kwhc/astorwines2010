
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/promo/201403-italianWineSale/201403-italianWineSale-header.jpg"
        imgHero.Width = 526
        litHeadline.Text = "20% Off* All Italian Wines"
        litIntro.Text = "<p class='fancy'>Today Only!<br/>Thursday, March 13th</p>"
        '"<p class='fancy'>Dry, sweet, still, sparkling… <br/>ALL red wines are on sale today.</p>" & _
        '"<p class='fancy'>You’ll find some of the most<br/>popular styles below.</p>"
        litRestrictions.Text = "*Sale prices valid 3/13/14 only, while current supplies last. For wines already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No special orders; no case discounts; no further discounts."
        Page.Title = "20% Off All Italian Wines Today"
    End Sub
End Class
