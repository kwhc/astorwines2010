Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Promo
    Public title As String
    Public link As String
End Class

Partial Class Ucontrols_promo_made_in_usa
    Inherits System.Web.UI.UserControl

    Public saleDate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgHero.Width = 526

        Dim sale = Request.QueryString("p")

        Select Case sale
            Case "white-wine-sale"
                jsonWhiteWineSale()
            Case "rose-wine-sale"
                jsonRoseSale()
        End Select

    End Sub

    Sub jsonWhiteWineSale()

        saleDate = #8/6/2014#

        If Date.Today = saleDate Then

            promoActive()

            imgHero.ImageUrl = "~/images/promo/2014-08-white-wine-sale/2014-08-white-wine-sale-email-header.jpg"
            litHeadline.Text = "20% Off*<br/>All White Wines"
            litIntro.Text = "<p class='fancy'>" & saleDate.ToString("dddd MMMM dd, yyyy") & "</p>"
            Page.Title = "20% Off All White Wines Today"
            litRestrictions.Text = "*" & _
    "August 6, 2014 only, while current supplies last. For wines already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No special orders; no case discounts; no further discounts."

            Dim showText As String = String.Empty
            Dim jsonString As String = "[" & _
            "{""title"":""All White Wines"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&term=&cat=1&color=White"",""type"":""large""}," & _
            "{""title"":""Still White Wines"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&term=&cat=1&color=White&style=1"",""type"":""large""}," & _
            "{""title"":""Sparkling White Wines"",""link"":""/WineSearchResult.aspx?p=1&searchtype=Contains&term=&cat=1&color=White&style=2&sparkling=True"",""type"":""large""}," & _
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
                    Case "large"
                        link.CssClass = "header-blox banana-background"
                        phLinksLarge.Controls.Add(link)
                End Select
            Next
        Else
            promoEnded()
        End If

    End Sub

    Sub jsonTest2()
        Dim showText As String = String.Empty
        Dim jsonStringShort As String = "{""title"":""Red"",""link"":""http://www.astorwines.com""}"
        Dim readingJson = JObject.Parse(jsonStringShort)
        showText = readingJson.Item("title").ToString
        litTest.Text = showText
    End Sub

    Sub jsonRoseWineSale()

    End Sub

    Sub promoActive()
        phPromoEnded.Visible = False
        phOther.Visible = False
    End Sub

    Sub promoEnded()
        phPromo.Visible = False
        Page.Title = "Sale Has Ended"
    End Sub

    Sub jsonRoseSale()
        'saleDate = #8/20/2014#
        saleDate = #7/31/2014#
        If Date.Today = saleDate Then
            promoActive()

            imgHero.ImageUrl = "~/images/promo/2014-08-white-wine-sale/2014-08-white-wine-sale-email-header.jpg"
            litHeadline.Text = "20% Off*<br/>All Ros&eacute; Wines"
            litIntro.Text = "<p class='fancy'>" & saleDate.ToString("dddd MMMM dd, yyyy") & "</p>"
            Page.Title = "20% Off All White Wines Today"
            litRestrictions.Text = "*" & _
            "August 20, 2014 only, while current supplies last. For wines already on sale, the greater of (a) the pre-existing discount or (b) a discount of 20% off the full retail price will apply. No special orders; no case discounts; no further discounts."

            Dim jsonString As String = "[" & _
            "{""title"":""All Ros&eacute; Wines"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&color=Rosé"",""type"":""large""}," & _
            "{""title"":""Still Ros&eacute; Wines"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&style=1&color=Rosé"",""type"":""price""}," & _
            "{""title"":""Sparkling Ros&eacute; Wines"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&style=2&sparkling=True&color=Rosé"",""type"":""category""}," & _
            "{""title"":""Under $10"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=1&style=1&color=Rosé"",""type"":""price""}," & _
            "{""title"":""$10-$20"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=2&style=1&color=Rosé"",""type"":""price""}," & _
            "{""title"":""$21-$50"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=3&style=1&color=Rosé"",""type"":""price""}," & _
            "{""title"":""$51-$100"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=4&style=1&color=Rosé"",""type"":""price""}," & _
            "{""title"":""Above $100"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=5&style=1&color=Rosé"",""type"":""price""}," & _
            "{""title"":""Under $10"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=1&style=2&sparkling=True&color=Rosé"",""type"":""category""}," & _
            "{""title"":""$10-$20"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=2&style=2&sparkling=True&color=Rosé"",""type"":""category""}," & _
            "{""title"":""$21-$50"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=3&style=2&sparkling=True&color=Rosé"",""type"":""category""}," & _
            "{""title"":""$51-$100"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=4&style=2&sparkling=True&color=Rosé"",""type"":""category""}," & _
            "{""title"":""Above $100"",""link"":""/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=5&style=2&sparkling=True&color=Rosé"",""type"":""category""}" & _
            "]"
            Dim jsonArray As JArray = JArray.Parse(jsonString)

            For Each jsonToken As JToken In jsonArray
                Dim link As New HyperLink
                link.Text = jsonToken.Item("title").ToString
                link.NavigateUrl = jsonToken.Item("link").ToString & "&ref=clp"
                link.CssClass = "second-blox rose-background"

                Select Case jsonToken.Item("type").ToString
                    Case "price"
                        phPriceLinks.Controls.Add(link)
                    Case "category"
                        phCategoryLinks.Controls.Add(link)
                    Case "large"
                        link.CssClass = "header-blox rose-background"
                        phLinksLarge.Controls.Add(link)
                End Select
            Next

        Else
            promoEnded()
        End If

    End Sub

End Class
