Imports WebCommon
Imports AstorDataClass
'Imports SslTools

Partial Class Ucontrols_WUCNoResultTop
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ocData As New cAstorCommon
        If Not IsPostBack Then
            If Not Session("SearchParms") Is Nothing Then
                Dim hstQuery As New Hashtable
                Dim sSearchItems As String
                hstQuery = Session("SearchParms")
                sSearchItems = ocData.SearchHashTableDecode(hstQuery)
                lblSearchString.Text = sSearchItems

                Dim searchTermWhole As String = String.Empty
                With hstQuery
                    If RTrim(.Item("Word1")) <> "" Then
                        searchTermWhole &= RTrim(.Item("Word1"))
                    End If
                    If RTrim(.Item("Word2")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word2"))
                    End If
                    If RTrim(.Item("Word3")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word3"))
                    End If
                    If RTrim(.Item("Word4")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word4"))
                    End If
                    If RTrim(.Item("Word5")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word5"))
                    End If
                End With
                Session("wholeString") = searchTermWhole
                Dim dictionarySQLAdapter As New astorWinesTableAdapters.spReadDictionaryTableAdapter
                Dim dictionarySQLDatatable As astorWines.spReadDictionaryDataTable = dictionarySQLAdapter.GetDictionaryTerm(searchTermWhole)
                If dictionarySQLDatatable.Rows.Count > 0 Then
                    Dim dictionaryRow As astorWines.spReadDictionaryRow = dictionarySQLDatatable.Rows(0)
                    didYouMean.Visible = True

                    suggestTerm.Text = dictionaryRow.searchTermCorrect
                    If Not IsDBNull(dictionaryRow.Item("searchResults")) Then
                        If dictionaryRow.searchResults > 0 Then
                            amountResults.Text &= " (" & dictionaryRow.searchResults & ")"
                        Else
                            didYouMean.Visible = False
                        End If
                    End If
                Else
                    didYouMean.Visible = False
                End If
            Else
                lblSearchString.Text = "Nothing set"
                didYouMean.Visible = False
            End If

        End If
        searchHelp.wholestring = Session("wholeString")
    End Sub

    Protected Sub suggestTerm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles suggestTerm.Click
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
        Dim dsLocal As System.Data.DataSet
        Dim hstQuery As New Hashtable
        '        Dim sSearchItems As String
        hstQuery = Session("SearchParms")


        Dim sNameLookup_value As String = suggestTerm.Text
        Dim sWord1 As String = String.Empty
        Dim sWord2 As String = String.Empty
        Dim sWord3 As String = String.Empty
        Dim sWord4 As String = String.Empty
        Dim sWord5 As String = String.Empty
        Dim queryParam As String()

        ' runsmartsearch set up for up to 5 words only
        If sNameLookup_value <> "" Then
            queryParam = _odata.RunSmartSearch(sNameLookup_value)
            sWord1 = queryParam(0)
            sWord2 = queryParam(1)
            sWord3 = queryParam(2)
            sWord4 = queryParam(3)
            sWord5 = queryParam(4)
        End If
        hstQuery.Item("Word1") = sWord1
        hstQuery.Item("Word2") = sWord2
        hstQuery.Item("Word3") = sWord3
        hstQuery.Item("Word4") = sWord4
        hstQuery.Item("Word5") = sWord5

        Dim sItemUPCLookup_value As String = String.Empty
        Dim bAllwords As Boolean = True
        Dim bSaleItemsOnly As Boolean = False
        Dim bCoolRoom As Boolean = False
        Dim iQty As Int16 = 1
        Dim sDryness As String = String.Empty
        Dim sColor As String = String.Empty
        Dim sStyle As String = String.Empty
        Dim sType As String = String.Empty
        Dim sSize As String = String.Empty
        Dim sGrape As String = String.Empty
        Dim sCountry As String = String.Empty
        Dim sDiscriminator As String = String.Empty
        Dim dPriceLow As Decimal = 0
        Dim dPriceHigh As Decimal = 0
        Dim sVintageLow As String = String.Empty
        Dim sVintageHigh As String = String.Empty
        Dim sQuickSearch As String = String.Empty
        Dim sRegion As String = String.Empty
        Dim sSubRegion As String = String.Empty
        Dim sVineyard As String = String.Empty
        Dim sProducer As String = String.Empty
        Dim sFortified As String = String.Empty
        Dim bFortifiedAll As Boolean = False

        Dim bOrganicall As Boolean = False

        Dim bDessert As Boolean = False
        Dim bGrowerProduce As Boolean = False
        Dim bJugWall As Boolean = False
        Dim bKosher As Boolean = False
        Dim bSparkling As Boolean = False
        Dim bVermouth As Boolean = False
        Dim bWineGiftSet As Boolean = False
        Dim bLiquorGiftSet As Boolean = False
        Dim iLiquorLevel1Type As Int16 = 0
        Dim iLiquorLevel2Type As Int16 = 0
        Dim iLiquorLevel3Type As Int16 = 0
        Dim iLevel1Type As Int16 = hstQuery.Item("Level1Type")
        Dim iPolishingGrade As Int16 = 0
        Dim sSakeDiscriminator As String = String.Empty
        Dim iPriceRange As Int16 = 0

        Dim sSakeDiscriminatorSave As String = String.Empty
        Dim sBA As String = String.Empty


        hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

        dsLocal = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))

        Dim termQueryString As String = String.Empty
        Dim amountTerms As Integer = 0
        If Trim(sWord1).Length > 0 Then
            termQueryString &= Trim(sWord1)
            amountTerms += 1
        End If
        If Trim(sWord2).Length > 0 Then
            termQueryString &= "," & Trim(sWord2)
            amountTerms += 1
        End If
        If Trim(sWord3).Length > 0 Then
            termQueryString &= "," & Trim(sWord3)
            amountTerms += 1
        End If
        If Trim(sWord4).Length > 0 Then
            termQueryString &= "," & Trim(sWord4)
            amountTerms += 1
        End If
        If Trim(sWord5).Length > 0 Then
            termQueryString &= "," & Trim(sWord5)
            amountTerms += 1
        End If

        Dim searchSQLAdapter As New astorWinesTableAdapters.tblSearchResultsTableAdapter
        Dim searchSQLDatatable As astorWines.tblSearchResultsDataTable = searchSQLAdapter.GetSearchResultsByTerm(Trim(sNameLookup_value))
        If searchSQLDatatable.Rows.Count > 0 Then
            Dim searchRow As astorWines.tblSearchResultsRow = searchSQLDatatable.Rows(0)
            searchSQLAdapter.Update(Trim(sNameLookup_value), amountTerms, dsLocal.Tables(0).Rows.Count, Now, searchRow.searchTermID, searchRow.searchTermID)
        Else
            searchSQLAdapter.Insert(Trim(sNameLookup_value), amountTerms, dsLocal.Tables(0).Rows.Count, Now)
        End If

        If dsLocal.Tables(0).Rows.Count = 0 Then
            Session("SearchParms") = hstQuery
            'Redirect("SearchNoResults.aspx?term=" & termQueryString, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("SearchNoResults.aspx?term=" & termQueryString)
        ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
            Session("DSSingle") = dsLocal
            Session("SearchParms") = hstQuery
            Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
            Dim sSearchString As String = dsLocal.Tables(0).Rows(0).Item("item").ToString
            'Redirect("SearchResultsSingle.aspx?p=1&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("SearchResultsSingle.aspx?p=1&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString)

        Else
            Session("DSMulti") = dsLocal
            Session("SearchParms") = hstQuery
            'Redirect("SearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("SearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=" & termQueryString)
        End If

    End Sub
End Class
