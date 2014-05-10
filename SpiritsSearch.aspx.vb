Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO

Imports System.Xml
Imports System.Xml.XPath
Imports System.Net

Partial Class SpiritsSearch
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SearchParms") = Nothing

        loadNewArrivals()

        pnlNewArrivals.Visible = False
        pnlAskDan.Visible = False

    End Sub

    Sub loadNewArrivals()

        Dim newSpirit1Title = "Great King Street New York Blend"
        Dim newSpirit1Sku = "27758"
        Dim newSpirit1Status = "Just Arrived"

        Dim newSpirit2Title = "Karlsson's Vodka Batch 2009"
        Dim newSpirit2Sku = "27724"
        Dim newSpirit2Status = "In Stock"

        newSpirit1.Text = newSpirit1Title
        newSpirit1.NavigateUrl = "http://www.astorwines.com/SearchResultsSingle.aspx?p=2&search=" & newSpirit1Sku & "&searchtype=Contains&ref=newarrivals"
        litNewSpirit1Status.Text = newSpirit1Status

        newSpirit2.Text = newSpirit2Title
        newSpirit2.NavigateUrl = "http://www.astorwines.com/SearchResultsSingle.aspx?p=2&search=" & newSpirit2Sku & "&searchtype=Contains&ref=newarrivals"
        litNewSpirit2Status.Text = newSpirit2Status


    End Sub

End Class
