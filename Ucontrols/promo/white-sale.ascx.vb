
Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/email/20130821-whiteSale/whiteSaleHeader.jpg"
        imgHero.Width = 526
        litIntro.Text = "<p class='fancy'>Today Only!<br/>Wednesday, August 21st</p>" & _
            "<p class='fancy'>Still and sparkling – <br/>all styles! all prices! all delicious!</p>"
        litRestrictions.Text = "While current supplies last. Does not apply to special orders. No further discounts.<br/>8/21/13 only."
    End Sub
End Class
