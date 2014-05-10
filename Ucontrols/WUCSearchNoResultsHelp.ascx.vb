Imports WebCommon
Imports AstorDataClass
'Imports SslTools

Partial Class Ucontrols_WUCSearchNoResultsHelp
    Inherits System.Web.UI.UserControl

    Private _wholeString As String

    Public Property wholestring() As String
        Get
            Return _wholeString
        End Get
        Set(ByVal value As String)
            _wholeString = Trim(value)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim counter As Integer = 0
        If wholestring <> "" Then
            Dim words As String() = wholestring.Split(" ")
            If words.Length > 1 Then
                For Each word As String In words
                    Dim searchDictionarySQLAdapter As New astorWinesTableAdapters.spReadDictionaryTableAdapter
                    Dim searchDictionarySQLDatatable As astorWines.spReadDictionaryDataTable = searchDictionarySQLAdapter.GetDictionaryTerm(Trim(word))
                    If searchDictionarySQLDatatable.Rows.Count > 0 Then
                        Dim searchDictionaryRow As astorWines.spReadDictionaryRow = searchDictionarySQLDatatable.Rows(0)
                        word = searchDictionaryRow.searchTermCorrect
                    End If

                    Dim searchTermSQLAdapter As New astorWinesTableAdapters.tblSearchResultsTableAdapter
                    Dim searchTermSQLDatatable As astorWines.tblSearchResultsDataTable = searchTermSQLAdapter.GetSearchResultsByTerm(word)
                    If searchTermSQLDatatable.Rows.Count > 0 Then
                        Dim searchTermRow As astorWines.tblSearchResultsRow = searchTermSQLDatatable.Rows(0)
                        If searchTermRow.searchResults > 0 Then
                            counter += 1
                            If counter > 1 Then
                                Dim seperator As New Literal
                                seperator.Text = ", "
                                searchHelp.Controls.Add(seperator)
                            End If
                            Dim termButton As New LinkButton
                            termButton.ID = "btnTerm_" & counter
                            termButton.CommandArgument = word
                            termButton.Text = word & " "
                            AddHandler termButton.Click, AddressOf onClick
                            searchHelp.Controls.Add(termButton)
                            Dim resultCount As New Literal
                            resultCount.Text = " (" & searchTermRow.searchResults & ")"
                            searchHelp.Controls.Add(resultCount)
                        End If
                    End If
                Next
            End If
        End If
        Me.Visible = (counter > 0)
    End Sub

    Protected Sub onClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
        Dim dsLocal As System.Data.DataSet
        Dim hstQuery As New Hashtable
        '        Dim sSearchItems As String
        hstQuery = Session("SearchParms")

        Dim sItemUPCLookup_value As String = String.Empty
        Dim bAllwords As Boolean = True
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
        'Dim iLevel1Type As Int16 = hstQuery.Item("Level1Type")
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
        Dim iQty As Int16 = 1
        Dim iLiquorLevel1Type As Int16 = 0
        Dim iLiquorLevel2Type As Int16 = 0
        Dim iLiquorLevel3Type As Int16 = 0
        Dim sQuickSearch As String = String.Empty
        Dim sFortified As String = String.Empty
        Dim bFortifiedAll As Boolean = False
        Dim sSakeDiscriminator As String = String.Empty
        Dim sSakeDiscriminatorSave As String = String.Empty
        Dim sBA As String = String.Empty

        Dim sNameLookup_value As String = CType(sender, LinkButton).Text
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
            'Redirect("SearchNoResults.aspx?term=" & termQueryString, RedirectOptions.AbsoluteHttp)  https_transfer_6/18/08
            Response.Redirect("SearchNoResults.aspx?term=" & termQueryString)
        ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
            Session("DSSingle") = dsLocal
            Session("SearchParms") = hstQuery
            Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
            Dim sSearchString As String = dsLocal.Tables(0).Rows(0).Item("item").ToString
            'Redirect("SearchResultsSingle.aspx?p=1&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("SearchResultsSingle.aspx?p=1&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString)

        Else
            Session("DSMulti") = dsLocal
            Session("SearchParms") = hstQuery
            'Redirect("SearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("SearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=" & termQueryString)
        End If

    End Sub

End Class
