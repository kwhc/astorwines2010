
Partial Class Ucontrols_promoPennant
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim isSingleDaySale As Boolean
        Dim promoEnd As DateTime
        Dim promoBegin As DateTime
        Dim promoDate As Date

        promoBegin = #8/6/2014#
        promoEnd = #8/6/2014#.AddDays(1)

        promoDate = #10/1/2014#
        isSingleDaySale = True

        hypPromo.NavigateUrl = "../m.aspx?p=rose-wine-sale&" & "ref=pennant"
        hypPromo.NavigateUrl = "../Features.aspx?featurepage=10_1_2_243&" & "ref=pennant"
        imgPromo.ImageUrl = "../images/promo/2014-10-italian-wine-case-sale/2014-10-italian-wine-case-sale-pennant.png"
        imgPromo.AlternateText = "Italian Wine Case Sale"

        If isSingleDaySale Then
            If Date.Today = promoDate Then 'day of sale
                pnlPromoPennant.Visible = True
                'ElseIf Date.Today = promoDate.AddDays(-1) Then 'test check
                ' pnlPromoPennant.Visible = True
            Else
                pnlPromoPennant.Visible = False
            End If
        Else
            pnlPromoPennant.Visible = False
        End If

    End Sub



End Class
