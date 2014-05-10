
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/email/2013-10-spookySpirits/2013-10-20-spookySpirits_header.jpg"
        imgHero.Width = 526
        litIntro.Text = "<p class='fancy'>They’re so good, it’s scary… </p>" & _
                        "<p class='fancy'>To see our terrifyingly huge assortment of sale bottles, click on your favorite spirits below!</p>"
        litRestrictions.Text = "*Sale prices valid 10/23/13 only, while current supplies last. For items already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No further discounts. Selected items only."
    End Sub
End Class
