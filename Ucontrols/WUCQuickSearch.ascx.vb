'Imports SslTools
Imports WebCommon
Imports AstorDataClass

Partial Class Ucontrols_WUCQuickSearch
    Inherits System.Web.UI.UserControl

    Private _showExplanation As Boolean
    Private _showheader As Boolean

    Public Property showExplanation() As Boolean
        Get
            Return _showExplanation
        End Get
        Set(ByVal value As Boolean)
            _showExplanation = value
        End Set
    End Property

    Public Property showheader() As Boolean
        Get
            Return _showheader
        End Get
        Set(ByVal value As Boolean)
            _showheader = value
        End Set
    End Property

    Protected Sub imgbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbbSearchQS.Click
        Dim sRedirect As String
        'Dim assearch() As String
        Dim sSearch As String = txt_Search.Text 'Request.Form.Item("txt_search")

        If Len(RTrim(sSearch)) < 3 Then
            lblError.Text = "Search must contain at least 3 characters/numbers"
            lblError.Visible = True
        Else
            '   Session.Remove("queryValue")
            '  Session.Remove("queryType")
            ' Session.Remove("txt_search")
            'assearch = .Split(Chr(9))
            Session.Add("queryValue", sSearch)
            Session.Add("queryType", "Contains")
            lblError.Visible = False
            sRedirect = LoadResultSimpleDataList()
            'Redirect(sRedirect, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect(sRedirect)
        End If

    End Sub

    Private Function LoadResultSimpleDataList() As String
        'Dim _odata As New cAstorWebData(getConnStr())
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
        Dim dsLocal As System.Data.DataSet
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

            Dim sRedirect As String = String.Empty

            If dsLocal.Tables(0).Rows.Count = 0 Then
                sRedirect = "~/SearchNoResults.aspx?term=" & termQueryString
            ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
                Dim sSearchControls As String
                sSearchControls = _oAstorCommon.SearchControls(dsLocal)
                Session("DSSingle") = dsLocal
                Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
                sSearchString = dsLocal.Tables(0).Rows(0).Item("item").ToString
                sRedirect = "~/SearchResultsSingle.aspx?search=" & sSearchString & "&searchtype=Contains&term=" & termQueryString & "&p=" & sSearchControls
            Else
                Dim sSearchControls As String
                sSearchControls = _oAstorCommon.SearchControls(dsLocal)
                Session.Add("DSMulti", dsLocal)
                sRedirect = "~/SearchResult.aspx?search=" & sSearch & "&searchtype=Contains&term=" & termQueryString & "&p=" & sSearchControls
            End If

            'Redirect(sRedirect, RedirectOptions.AbsoluteHttp)
            Return sRedirect

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'plcShowHeader.Visible = showheader
        ''advancedSearch.Visible = Not showExplanation
        ''explanation.Visible = showExplanation
        ''advancedSearch.NavigateUrl = Request.ServerVariables("URL") & "?" & Request.ServerVariables("QUERY_STRING") & "&sb=1"
        'aceLookUp.ServicePath = "http://" & Request.ServerVariables("SERVER_NAME") & "/WSLookUp.asmx"
    End Sub
   

End Class