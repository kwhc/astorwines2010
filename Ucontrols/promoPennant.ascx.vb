
Partial Class Ucontrols_promoPennant
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim isSingleDaySale As Boolean
        Dim promoEnd As DateTime
        Dim promoBegin As DateTime
        Dim promoDate As Date

        promoBegin = #8/6/2014#
        promoEnd = #8/6/2014#.AddDays(1)
        promoDate = #8/16/2014#
        isSingleDaySale = True

<<<<<<< HEAD
        'hypPromo.NavigateUrl = "../m.aspx?p=italian-wine-sale" & "&ref=pennant"
        hypPromo.NavigateUrl = "../m.aspx?p=rose-wine-sale&" & "ref=pennant"
        imgPromo.ImageUrl = "../images/promo/2014-08-rose-wine-sale/2014-08-16-Rose-Wine-Clearance-Sale-PENNANT.png"
        imgPromo.AlternateText = "Ros&eacute; Wine Sale"
=======
        hypPromo.NavigateUrl = "../m.aspx?p=bastille-day-sale" & "&ref=pennant"
        'hypPromo.NavigateUrl = "../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&color=Rosé&" & "ref=pennant"
        imgPromo.ImageUrl = "../images/promo/2014-07-bastille-day-sale/2014-07-Bastille-Day-Pennant.png"
        imgPromo.AlternateText = "All-American Sale"
        promoBegin = #7/14/2014#
        promoEnd = #7/14/2014#.AddDays(1)
>>>>>>> shipping-updates

        If isSingleDaySale Then
            If Date.Today = promoDate Then 'day of sale
                pnlPromoPennant.Visible = True
            ElseIf Date.Today = promoDate.AddDays(-1) Then 'test check
                pnlPromoPennant.Visible = True
            Else
                pnlPromoPennant.Visible = False
            End If
        Else
            pnlPromoPennant.Visible = False
        End If

    End Sub



End Class
