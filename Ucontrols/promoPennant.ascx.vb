﻿
Partial Class Ucontrols_promoPennant
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim isSingleDaySale As Boolean
        Dim promoEnd As DateTime
        Dim promoBegin As DateTime
        Dim promoDate As Date

        promoBegin = #6/25/2014#
        promoEnd = #6/25/2014#.AddDays(1)

        'hypPromo.NavigateUrl = "../m.aspx?p=italian-wine-sale" & "&ref=pennant"
        hypPromo.NavigateUrl = "../m.aspx?p=spanish-wine-sale&" & "ref=pennant"
        imgPromo.ImageUrl = "../images/promo/2014-06-spanish-wine-sale/2014-06-Spanish-Wine-Sale-Pennant-Img.png"
        imgPromo.AlternateText = "Spanish Wine Sale"

        If isSingleDaySale Then
            If Date.Today = promoDate Then
                pnlPromoPennant.Visible = True
            End If
        Else
            If Date.Now < promoBegin Or Date.Now >= promoEnd Then
                pnlPromoPennant.Visible = False
            End If
        End If

    End Sub



End Class
