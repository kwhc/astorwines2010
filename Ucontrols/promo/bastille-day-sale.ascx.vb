Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Promo
    Public title As String
    Public link As String
End Class

Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.ImageUrl = "~/images/promo/2014-07-bastille-day-sale/2014-07-Bastille-Day-email-header.jpg"
        imgHero.Width = 526
        litHeadline.Text = "20% Off*<br/>All French Wines"
        litIntro.Text = "<p class='fancy'>Monday, July 14</p>"
        '"<p class='fancy'>Dry, sweet, still, sparkling… <br/>ALL red wines are on sale today.</p>" & _
        '"<p class='fancy'>You’ll find some of the most<br/>popular styles below.</p>"
        litRestrictions.Text = "*" & _
"Monday, July 14 only, while current supplies last. For wines already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No special orders; no case discounts; no further discounts."

        'Date specific messages
        'If Date.Now < #7/2/2014# Then
        '    litRestrictions.Text = litRestrictions.Text & "<p style=""text-align:center;margin-top:1rem;"">Orders placed by 10 a.m. on Tuesday, July 1 containing wine only and being delivered to New York State will be out for delivery by Thursday, July 3. Orders containing spirits and wine being shipped to New York State will take 3 to 5 business days for delivery.</p>"
        'Else
        '    litRestrictions.Text = litRestrictions.Text & "<p style=""text-align:center;margin-top:1rem;"">Orders placed on July 2 will not arrive until after July 4.</p>"
        'End If

        Page.Title = "20% Off All French Wines Today"

        'Dim json As String = "[{""title"":""Red"",""link"":""http://www.astorwines.com""},{""title"":""White"",""link"":null},{""title"":""White"",""link"":null}]"

        'Dim o As JObject = JObject.Parse(json)

        'Dim p As New Promo
        'p = JsonConvert.DeserializeObject(Of Promo)(json)
        'MsgBox(p.title)

        'Dim link As New HyperLink
        'link.Text = "This is a test"

        'column2.Controls.Add(link)

    End Sub
End Class
