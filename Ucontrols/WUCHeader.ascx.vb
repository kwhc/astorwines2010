Imports System.Collections.Specialized
Imports System.Web.Security
Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
'Imports SslTools


Partial Class Ucontrols_WUCHeader
    Inherits System.Web.UI.UserControl

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here


        Dim mstrPageName As String = String.Empty
        mstrPageName = Page.ToString
        'mstrPageName &= Page.ClientQueryString.ToString

        mstrPageName = Replace(mstrPageName, "ASP.", "")
        mstrPageName = Replace(mstrPageName, "_aspx", ".aspx")
        mstrPageName = mstrPageName.ToLower

        If Not IsPostBack Then
            If Not Session("ItemName") Is Nothing And mstrPageName = "searchresultssingle.aspx" Then
                'lblBCItem.Text = Session("ItemName")
                'lblBCItem.Visible = True
                'ElseIf Not Session("FeatureName") Is Nothing And mstrPageName = "features.aspx" Then
                '    lblBCItem.Text = Session("FeatureName")
                '    lblBCItem.Visible = True
            Else
                'lblBCItem.Visible = False
            End If
            If InStr(mstrPageName, "secure") Then
                WUCQuickSearchNoAutoComplete.Visible = True
                WUCQuickSearch1.Visible = False
            Else
                WUCQuickSearchNoAutoComplete.Visible = False
                WUCQuickSearch1.Visible = True
            End If
        End If

        ' removed - try some other time
        'AddHandler SiteMap.SiteMapResolve, AddressOf Me.ExpandForumPaths

        'Hide Free Shipping Tout in checkout
        'groundShippingVisibility()

    End Sub
    'Private Function ExpandForumPaths(ByVal sender As Object, ByVal e As SiteMapResolveEventArgs) As SiteMapNode
    '    Dim currentNode As SiteMapNode = SiteMap.CurrentNode.Clone(True)
    '    Dim tempNode As SiteMapNode = currentNode

    '    If Mid(currentNode.Title, 1, 7) = "Feature" Then
    '        currentNode.Title = "Features: Hart"
    '    End If
    '    If Mid(currentNode.Title, 1, 4) = "Item" Then
    '        currentNode.Title = "Item " & Session("ItemName")
    '    End If
    '    'If Not Session("ItemName") Is Nothing Then
    '    '    currentNode.Title = Session("ItemName")
    '    '    Session("ItemName") = Nothing
    '    'End If

    '    'tempNode = tempNode.ParentNode
    '    'If Not (0 = forumID) And Not (Nothing = tempNode) Then
    '    '    tempNode.Url = tempNode.Url & "?ForumID=" & forumID.ToString()
    '    'End If

    '    'tempNode = tempNode.ParentNode
    '    'If Not (0 = forumGroupID) And Not (Nothing = tempNode) Then
    '    '    tempNode.Url = tempNode.Url & "?ForumGroupID=" & forumGroupID.ToString()
    '    'End If
    '    Return currentNode
    'End Function

    'Protected Sub imgbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbSearch.Click
    '    Dim sRedirect As String
    '    Dim sSearch As String = Request.Form.Item("txt_search")

    '    If Len(RTrim(sSearch)) < 3 Or RTrim(sSearch) = "Enter keyword, item number" Then
    '        'Session.Add("Error", "Search must contain at least 3 characters/numbers")
    '        lblError.Text = "Search must contain at least 3 characters/numbers"
    '        lblError.Visible = True
    '        'RaiseBubbleEvent(sender, e)
    '        'Response.Redirect("SearchError.aspx")
    '    Else
    '        Session.Add("queryValue", sSearch)
    '        Session.Add("queryType", "Contains")
    '        lblError.Visible = False
    '        sRedirect = LoadResultSimpleDataList()
    '        Redirect(sRedirect, RedirectOptions.AbsoluteHttp)
    '        'Session.Remove("Error")
    '        'Response.Redirect("SearchResult.aspx?search=" + wteSearch.Text + "&searchtype=Contains")
    '    End If

    'End Sub
    Private Function LoadResultSimpleDataList() As String

        'Dim _odata As New cAstorWebData(getConnStr())
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
        Dim dsLocal As DataSet
        Dim sSearchString As String = RTrim(CStr(Session.Item("queryValue")))
        Dim sSearchType As String = RTrim(CStr(Session.Item("queryType")))
        Dim sSearch As String = Request.Form.Item("txt_search")
        Dim bAllwords As Boolean = False
        Dim sWord1 As String = String.Empty
        Dim sWord2 As String = String.Empty
        Dim sWord3 As String = String.Empty
        Dim sWord4 As String = String.Empty
        Dim sWord5 As String = String.Empty
        Dim queryParam As String()
        Dim iQty As Int16 = 1
        Dim sItemUPCLookup_value As String = String.Empty
        Dim sNameLookup_value As String = String.Empty
        Dim sCountry As String = String.Empty
        Dim sRegion As String = String.Empty
        Dim sSubRegion As String = String.Empty
        Dim sVineyard As String = String.Empty
        Dim sProducer As String = String.Empty
        Dim sGrape As String = String.Empty
        Dim sColor As String = String.Empty
        Dim sSize As String = String.Empty
        Dim sVintageLow As String = String.Empty
        Dim sVintageHigh As String = String.Empty
        Dim iPriceRange As Int16 = 0
        Dim sDryness As String = String.Empty
        Dim sType As String = String.Empty
        Dim sStyle As String = String.Empty
        Dim sDiscriminator As String = String.Empty
        Dim bKosher As Boolean = False
        Dim bOrganicall As Boolean = False
        Dim hstQuery As New Hashtable
        Dim iLevel1Type As Int16 = 0
        Dim bSaleItemsOnly As Boolean = False
        Dim bCoolRoom As Boolean = False
        Dim bDessert As Boolean = False
        Dim bGrowerProduce As Boolean = False
        Dim bJugWall As Boolean = False
        Dim bSparkling As Boolean = False
        Dim bVermouth As Boolean = False
        Dim bLiquorGiftSet As Boolean = False
        Dim bWineGiftSet As Boolean = False
        Dim iPolishingGrade As Int16 = 0
        Dim dPriceLow As Decimal = 0
        Dim dPriceHigh As Decimal = 0
        Dim iLiquorLevel1Type As Int16 = 0
        Dim iLiquorLevel2Type As Int16 = 0
        Dim iLiquorLevel3Type As Int16 = 0
        Dim sQuickSearch As String = String.Empty
        Dim sFortified As String = String.Empty
        Dim bFortifiedAll As Boolean = False
        Dim sSakeDiscriminator As String = String.Empty
        Dim sSakeDiscriminatorSave As String = String.Empty
        Dim sBA As String = String.Empty

        Try


            Session.Add("SS", sSearchString)
            If Len(sSearchString) = 5 And IsNumeric(sSearchString) Then
                sItemUPCLookup_value = sSearchString
                sNameLookup_value = String.Empty
                dsLocal = _odata.FindItem(sSearchString, "", False, "", "", "", "", "", iQty, "R", _oWebCommon.GetCustomerID(Request, Response))
            Else
                sItemUPCLookup_value = String.Empty
                sNameLookup_value = sSearchString

                If sSearchString <> "" Then
                    queryParam = _odata.RunSmartSearch(sSearchString)

                    bAllwords = True
                    sWord1 = queryParam(0)
                    sWord2 = queryParam(1)
                    sWord3 = queryParam(2)
                    sWord4 = queryParam(3)
                    sWord5 = queryParam(4)


                End If

                'Select Case sSearchType
                '    Case "Contains"
                '        sSearchString = "%" & sSearchString & "%"
                '    Case "Starts with"
                '        sSearchString = sSearchString & "%"
                'End Select
                ' runsmartsearch set up for up to 5 words only



                dsLocal = _odata.FindItem("", sSearchString, True, sWord1, sWord2, sWord3, sWord4, sWord5, iQty, "R", _oWebCommon.GetCustomerID(Request, Response))
            End If
            hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
                        bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
                        sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
                        iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

            Session("SearchParms") = hstQuery
            Session("queryType") = Nothing
            Session("queryValue") = Nothing
            Dim sRedirect As String = String.Empty

            If dsLocal.Tables(0).Rows.Count = 0 Then
                sRedirect = "~/SearchNoResults.aspx"
            ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
                Session("DSSingle") = dsLocal
                Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
                sRedirect = "~/SearchResultsSingle.aspx?search=" & sSearchString & "&searchtype=Contains"
            Else
                Dim sSearchControls As String
                sSearchControls = _oAstorCommon.SearchControls(dsLocal)
                Session.Add("DSMulti", dsLocal)
                sRedirect = "~/SearchResult.aspx?search=" & sSearch & "&searchtype=Contains&p=" & sSearchControls
            End If

            'Redirect(sRedirect, RedirectOptions.AbsoluteHttp)
            Return sRedirect

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    
  
    'Protected Sub uwebMain_MenuItemClicked(ByVal sender As Object, ByVal e As Infragistics.WebUI.UltraWebNavigator.WebMenuItemEventArgs) Handles uwebMain.MenuItemClicked
    '    If e.Item.Tag.Contains("/secure/") Then
    '        Redirect(e.Item.Tag.ToString, RedirectOptions.AbsoluteHttps)
    '    Else
    '        Redirect(e.Item.Tag.ToString, RedirectOptions.AbsoluteHttp)
    '    End If
    'End Sub

    'Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles headMenu.MenuItemClick
    '    Select Case e.Item.Value
    '        Case "Wines"
    '            Redirect("~/WineSearch.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "Home"
    '            Redirect("~/Default.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "Sakes"
    '            Redirect("~/SakeSearch.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "Spirits"
    '            Redirect("~/SpiritsSearch.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "BA"
    '            Redirect("~/BooksAccessoriesSearch.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "Tastings"
    '            Redirect("~/TastingEvents.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "Gift"
    '            Redirect("~/GiftIdeasSearchBlank.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "Landmark"
    '            Redirect("~/AstorLandmarkStore.aspx", RedirectOptions.AbsoluteHttp)
    '        Case "MyAccount"
    '            Redirect("~/secure/MyAccountSummary.aspx", RedirectOptions.AbsoluteHttps)
    '    End Select

    'End Sub

    'Hide Free Shipping sticker on masterpage in checkout
    'Private Sub groundShippingVisibility()

    '    Dim pageName As String
    '    pageName = Request.Url.AbsoluteUri

    '    If pageName.Contains("Shopping") = True Then
    '        imgShippingSticker.Visible = False
    '    ElseIf pageName.Contains("AstorCheckoutShipping") = True Then
    '        imgShippingSticker.Visible = False
    '    End If
    'End Sub

End Class