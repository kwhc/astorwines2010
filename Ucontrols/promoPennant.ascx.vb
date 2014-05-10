
Partial Class Ucontrols_promoPennant
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim promoEnd As DateTime
        Dim promoBegin As DateTime

        'hypPromo.NavigateUrl = "../m.aspx?p=italian-wine-sale" & "&ref=pennant"
        hypPromo.NavigateUrl = "../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&color=Rosé&" & "ref=pennant"
        imgPromo.ImageUrl = "../images/promo/201405-roseDaySale/img_roseDaySale_pennant.png"
        imgPromo.AlternateText = "Rose Day Sale"
        promoBegin = #5/10/2014#
        promoEnd = #5/11/2014#.AddDays(1)

        If Date.Now < promoBegin Or Date.Now >= promoEnd Then
            pnlPromoPennant.Visible = False
        End If

    End Sub
End Class
