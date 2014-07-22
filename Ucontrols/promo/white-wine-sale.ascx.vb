Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Promo
    Public title As String
    Public link As String
End Class

Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim saleDate As String = #8/6/2014#.ToString("dddd MMMM dd, yyyy")
        imgHero.ImageUrl = "~/images/promo/2014-08-white-wine-sale/2014-08-white-wine-sale-email-header.jpg"
        imgHero.Width = 526
        litHeadline.Text = "20% Off*<br/>All White Wines"
        litIntro.Text = "<p class='fancy'>" & saleDate & "</p>"
        '"<p class='fancy'>Dry, sweet, still, sparkling… <br/>ALL red wines are on sale today.</p>" & _
        '"<p class='fancy'>You’ll find some of the most<br/>popular styles below.</p>"
        litRestrictions.Text = "*" & _
"August 6, 2014 only, while current supplies last. For wines already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No special orders; no case discounts; no further discounts."
        'Date specific messages
        'If Date.Now < #7/2/2014# Then
        '    litRestrictions.Text = litRestrictions.Text & "<p style=""text-align:center;margin-top:1rem;"">Orders placed by 10 a.m. on Tuesday, July 1 containing wine only and being delivered to New York State will be out for delivery by Thursday, July 3. Orders containing spirits and wine being shipped to New York State will take 3 to 5 business days for delivery.</p>"
        'Else
        '    litRestrictions.Text = litRestrictions.Text & "<p style=""text-align:center;margin-top:1rem;"">Orders placed on July 2 will not arrive until after July 4.</p>"
        'End If

        Page.Title = "20% Off All White Wines Today"

        'Dim link As New HyperLink
        'link.Text = "This is a test"

        'column2.Controls.Add(link)

        whiteWineSaleJson()

    End Sub

    Sub whiteWineSaleJson()
        Dim showText As String = String.Empty
        Dim jsonString As String = "[" & _
        "{""title"":""Under $10"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=1&color=White"",""type"":""price""}," & _
        "{""title"":""$10-$20"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=2&color=White"",""type"":""price""}," & _
        "{""title"":""$21-$50"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=3&color=White"",""type"":""price""}," & _
        "{""title"":""$51-$100"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=4&color=White"",""type"":""price""}," & _
        "{""title"":""Above $100"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=5&color=White"",""type"":""price""}," & _
        "{""title"":""California Chardonnay"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&grape=Chardonnay&country=USA&region=California"",""type"":""category""}," & _
        "{""title"":""White Burgundy"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&country=France&region=Burgundy&color=White"",""type"":""category""}," & _
        "{""title"":""Champagne"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&country=France&region=Champagne"",""type"":""category""}," & _
        "{""title"":""Riesling"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&country=France&grape=Riesling"",""type"":""category""}," & _
        "{""title"":""Prosecco"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&grape=Prosecco+(Glera)"",""type"":""category""}" & _
        "]"
        Dim jsonArray As JArray = JArray.Parse(jsonString)

        showText = showText & "<br/>" & "results: " & jsonArray.Count

        For Each jsonToken As JToken In jsonArray

            Dim link As New HyperLink
            link.Text = jsonToken.Item("title").ToString
            link.NavigateUrl = jsonToken.Item("link").ToString & "&ref=clp"
            link.CssClass = "second-blox banana-background"

            Select Case jsonToken.Item("type").ToString
                Case "price"
                    phPriceLinks.Controls.Add(link)
                Case "category"
                    phCategoryLinks.Controls.Add(link)
            End Select

        Next

    End Sub

    Sub jsonTest2()
        Dim showText As String = String.Empty
        Dim jsonStringShort As String = "{""title"":""Red"",""link"":""http://www.astorwines.com""}"
        Dim readingJson = JObject.Parse(jsonStringShort)
        showText = readingJson.Item("title").ToString
        litTest.Text = showText
    End Sub

End Class
