
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/promo/2013-11-blackFriday/img_emailHeader_blackFriday.jpg"
        imgHero.Width = 526
        litTitle.Text = "20% Off* All Wines"
        litIntro.Text = "<p class='fancy'>Today Only!<br/>Friday, November 29th</p>"
        litRestrictions.Text = "*" & _
        "Sale prices valid 11/29/13 only, while current supplies last. For items already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No special orders, no further discounts."
        Page.Title = "20% Off All Wines Today"
    End Sub
End Class
