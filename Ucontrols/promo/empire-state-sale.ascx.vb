
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/email/images/130710-empire-state-sale.jpg"
        imgHero.Width = 526
        litIntro.Text = "<p class='fancy'>Taste local vermouths for free in the store tonight<br/>from 6-8:00 p.m.</p><p class='fancy'>Grab a ticket for tonight’s gigantic<br/><a href='http://www.slowfoodnyc.org/event/2nd_annual_spirits_new_york_event'>Spirits of New York tasting</a></p> <p class='fancy'>- or -</p> <p class='fancy'>Just click below to save on the tastiest bottles New York has to offer.</p>"
        litRestrictions.Text = "While current supplies last. Does not apply to special orders. No further discounts. "
    End Sub
End Class
