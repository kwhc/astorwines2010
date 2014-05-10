
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/promo/2014-02-mammothSale/img_mammothSale-emailHeader.jpg"
        imgHero.Width = 526
        litTitle.Text = "20% Off* All Wines"
        litIntro.Text = "<p class='fancy'>Today Only!<br/>Monday, February 24th</p>"
        litRestrictions.Text = "*" & _
        "Sale prices valid 2/24/14 only, while current supplies last. For wines already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No special orders; no further discounts. In-store discounts will be taken at the register."
        Page.Title = "20% Off All Wines Today"
    End Sub
End Class
