
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/email/images/130701-made-in-the-usa.jpg"
        imgHero.Width = 526
        litIntro.Text = "<p>There’s a lot to love about wines and spirits that are made in the U.S.A. Not only are they tastier than ever – they’re all on sale at Astor right now:</p><p>Get 20% off American wines and 15% off American spirits!</p><p>The sale lasts through July 3, 2013. Happy Independence Day from all of us here at Astor!</p><p class=""note"">Sale applies to American wines and spirits from 7/1/13 through 7/3/13 while current supplies last. Sale prices do not apply to special orders. No further discounts.</p>"

    End Sub
End Class
