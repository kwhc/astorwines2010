Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class Ucontrols_WUCBooksAssocSearch
    Inherits System.Web.UI.UserControl

    Private _showheader As Boolean

    Public Property showheader() As Boolean
        Get
            Return _showheader
        End Get
        Set(ByVal value As Boolean)
            _showheader = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        plcShowHeader.Visible = showheader
        If Not IsPostBack Then
            'If Session("Country") Is Nothing Then
            '    GetCodeTables()
            'End If
            LoadUcombo()
            If Not Session("SearchParms") Is Nothing Then
                Dim hstQuery As New Hashtable
                hstQuery = Session("SearchParms")
                With hstQuery

                    If .Item("PriceRange") <> 0 Then
                        ddlPriceRange.SelectedValue = RTrim(.Item("PriceRange"))
                    End If

                    If .Item("BA") <> "" Then
                        ddlCat.SelectedValue = RTrim(.Item("BA"))
                    End If
                    If .Item("NameLookup_value") <> "" Then
                        txtName.Text = RTrim(.Item("NameLookup_value"))
                    End If
                End With
            End If

        End If
    End Sub

    Private Sub LoadUcombo()

        Dim _dvPriceRange As New DataView
        Dim _dtPriceRange As DataTable = Application("PriceRange")
        _dvPriceRange.Table = _dtPriceRange
        _dvPriceRange.RowFilter = "sType = 'regular'"
        'load price range
        With ddlPriceRange
            .DataSource = _dvPriceRange
            .DataMember = ""
            .DataValueField = "iOrder"
            .DataTextField = "sPriceRangeDesc"
            .DataBind()
        End With

       
        ' load BA
        Dim _dtBooksAndAccessoriesType As DataTable = Application("TypeCodes")
        Dim _dvBooksAndAccessoriesType As New DataView
        _dvBooksAndAccessoriesType.Table = _dtBooksAndAccessoriesType
        _dvBooksAndAccessoriesType.RowFilter = "sColumnName = 'iBooksAndAccessoriesType'"
        With ddlCat
            .DataSource = _dvBooksAndAccessoriesType
            .DataMember = ""
            .DataValueField = "iType"
            .DataTextField = "sTypeDescription"
            .DataBind()
        End With


    End Sub



    Private Sub Reset()

        txtName.Text = String.Empty

        ddlPriceRange.SelectedIndex = -1
        ddlCat.SelectedIndex = -1

    End Sub
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbutReset.Click
        'LoadUcombo()
        'Reset()
        Session("SearchParms") = Nothing
        Dim sPage As String = Page.Request.Url.ToString
        'Redirect(sPage) https_transfer_6/18/08
        Response.Redirect(sPage)
    End Sub

    Protected Sub imbbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbbSearch.Click
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _oWebCommon As New WebPageBase
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim sItemUPCLookup_value As String = String.Empty
        Dim sNameLookup_value As String = String.Empty
        Dim bAllwords As Boolean = False
        Dim sWord1 As String = String.Empty
        Dim sWord2 As String = String.Empty
        Dim sWord3 As String = String.Empty
        Dim sWord4 As String = String.Empty
        Dim sWord5 As String = String.Empty
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
        Dim queryParam As String()

        iLevel1Type = 4
        sNameLookup_value = RTrim(txtName.Text)

        Dim updateSearch As Boolean = True

        If ddlPriceRange.SelectedIndex <> 0 Then
            iPriceRange = Convert.ToInt16(ddlPriceRange.SelectedValue)
            updateSearch = False
        Else
            iPriceRange = 0
        End If
        If ddlCat.SelectedIndex <> 0 Then
            sBA = ddlCat.SelectedValue
            updateSearch = False
        Else
            sBA = String.Empty
        End If
        ' runsmartsearch set up for up to 5 words only
        If sNameLookup_value <> "" Then
            queryParam = _odata.RunSmartSearch(sNameLookup_value)

            bAllwords = True
            sWord1 = queryParam(0)
            sWord2 = queryParam(1)
            sWord3 = queryParam(2)
            sWord4 = queryParam(3)
            sWord5 = queryParam(4)


        End If

        If sItemUPCLookup_value = "" And sNameLookup_value = "" And sCountry = "" And sRegion = "" And sSubRegion _
            = "" And sGrape = "" And sColor = "" And sVintageLow = "" And iPriceRange = 0 And sStyle = "" And sSize = "" And iPolishingGrade = 0 And sBA = "" Then
            'Exit Sub
            'Redirect("BooksAccessoriesSearchNoResults.aspx?term=none", RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("BooksAccessoriesSearchNoResults.aspx?term=none")
            'lblSearchErrorMsg.Visible = True
        Else
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
            ' termQueryString = Server.UrlEncode(termQueryString)

            Dim searchSQLAdapter As New astorWinesTableAdapters.tblSearchResultsTableAdapter
            Dim searchSQLDatatable As astorWines.tblSearchResultsDataTable = searchSQLAdapter.GetSearchResultsByTerm(Trim(sNameLookup_value))
            If searchSQLDatatable.Rows.Count > 0 Then
                Dim searchRow As astorWines.tblSearchResultsRow = searchSQLDatatable.Rows(0)
                If updateSearch Then
                    searchSQLAdapter.Update(Trim(sNameLookup_value), amountTerms, dsLocal.Tables(0).Rows.Count, Now, searchRow.searchTermID, searchRow.searchTermID)
                End If
            Else
                searchSQLAdapter.Insert(Trim(sNameLookup_value), amountTerms, dsLocal.Tables(0).Rows.Count, Now)
            End If

            If dsLocal.Tables(0).Rows.Count = 0 Then
                Session("SearchParms") = hstQuery
                'Redirect("BooksAccessoriesSearchNoResults.aspx?term=" & termQueryString, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/BooksAccessoriesSearchNoResults.aspx?term=" & termQueryString)
            ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
                Session("DSSingle") = dsLocal
                Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
                Session("SearchParms") = hstQuery
                Dim sSearchString As String = dsLocal.Tables(0).Rows(0).Item("item").ToString
                'Redirect("SearchResultsSingle.aspx?p=4&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/SearchResultsSingle.aspx?p=4&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString)

            Else
                Session("DSMulti") = dsLocal
                Session("SearchParms") = hstQuery
                'Redirect("BooksAccessoriesSearchResult.aspx?p=4&search=Advanced&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/BooksAccessoriesSearchResult.aspx?p=4&search=Advanced&searchtype=Contains&term=" & termQueryString)
            End If
            End If
    End Sub

End Class
