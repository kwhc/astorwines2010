Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class Ucontrols_WUCSpiritsSearch
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
                    If .Item("Country") <> "" Then
                        ddlCountrySp.SelectedValue = RTrim(.Item("Country"))
                        SetRegion()
                    End If

                    If .Item("Region") <> "" Then
                        ddlRegion.SelectedValue = RTrim(.Item("Region"))
                    End If
                    If .Item("Producer") <> "" Then
                        ddlProducer.SelectedValue = RTrim(.Item("Producer"))
                    End If
                    If .Item("Size") <> "" Then
                        ddlSize.SelectedValue = RTrim(.Item("Size"))
                    End If

                    If .Item("PriceRange") <> 0 Then
                        ddlPriceRange.SelectedValue = RTrim(.Item("PriceRange"))
                    End If
                    If .Item("Style") <> "" Then
                        ddlStyle.SelectedValue = RTrim(.Item("Style"))
                    End If
                    If .Item("OrganicAll") = True Then
                        chkOrganic.Checked = True
                    End If
                    If .Item("Kosher") = True Then
                        chkKosher.Checked = True
                    End If
                    If .Item("NameLookup_value") <> "" Then
                        txtName.Text = RTrim(.Item("NameLookup_value"))
                    End If

                End With
            End If

        End If
    End Sub

    Private Sub LoadUcombo()

        Dim _dvCountry As New DataView
        Dim _dtCountry As DataTable = Application("Country")
        _dvCountry.Table = _dtCountry
        _dvCountry.RowFilter = "ilevel1type = '2'"

        Dim _dvRegion As New DataView
        Dim _dtRegion As DataTable = Application("Region")
        _dvRegion.Table = _dtRegion
        _dvRegion.RowFilter = "cntryname= ''"

        Dim _dvProducer As New DataView
        Dim _dtProducer As DataTable = Application("Producer")
        _dvProducer.Table = _dtProducer


        Dim _dvSize As New DataView
        Dim _dtSize As DataTable = Application("Size")
        _dvSize.Table = _dtSize

        Dim _dvTypeCode As New DataView
        Dim _dtTypeCode As DataTable = Application("TypeCodes")
        _dvTypeCode.Table = _dtTypeCode
        _dvTypeCode.RowFilter = "sColumnName = 'iLiquorLevel1Type' or sColumnName = 'iLiquorLevel2Type' or sColumnName = 'iLiquorLevel3Type'"

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
        'load country
        With ddlCountrySp

            .DataSource = _dvCountry 'Application("Country")
            .DataMember = ""
            .DataValueField = "scountry"
            .DataTextField = "scountry"
            .DataBind()
            '.CssClass = "dropdown"
        End With
        'load region
        With ddlRegion

            .DataSource = _dvRegion
            .DataMember = ""
            .DataValueField = "regname"
            .DataTextField = "regname"
            .DataBind()
        End With

        _dvProducer.RowFilter = "iLevel1Type = 2"
        'load producer
        With ddlProducer
            .DataSource = _dvProducer
            .DataMember = ""
            .DataValueField = "sProducer"
            .DataTextField = "sProducer"
            .DataBind()
        End With

        _dvSize.RowFilter = "iLevel1Type = 2"
        'load Size
        With ddlSize
            .DataSource = _dvSize
            .DataMember = ""
            .DataValueField = "sSize"
            .DataTextField = "sSize"
            .DataBind()
        End With



        'load style
        With ddlStyle
            .DataSource = _dvTypeCode
            .DataMember = ""
            .DataValueField = "sWebLUValue"
            .DataTextField = "sWebTypeDescription"
            .DataBind()
        End With


    End Sub
    Public Sub SetRegion()
        Dim sCountry As String = RTrim(ddlCountrySp.SelectedValue.ToString)
        If sCountry = "" Then
            Exit Sub
        End If

        Dim _dvRegion As New DataView
        Dim _dtRegion As DataTable
        _dtRegion = Application("Region")
        _dvRegion.Table = _dtRegion

        'If sCountry = "USA" Or sCountry = "Scotland" Then
        _dvRegion.RowFilter = "(iLevel1Type = 2 or iLevel1Type = 0) and (cntryname= '' or cntryname= '" & sCountry & "')"
        'End If

        'load region
        With ddlRegion
            .DataSource = _dvRegion
            .DataMember = ""
            .DataValueField = "regname"
            .DataTextField = "regname"
            .DataBind()
        End With
        ddlRegion.Enabled = True
    End Sub



    Private Sub Reset()

        txtName.Text = String.Empty

        ddlCountrySp.SelectedIndex = -1
        ddlRegion.SelectedIndex = -1
        ddlSize.SelectedIndex = -1
        ddlPriceRange.SelectedIndex = -1
        ddlStyle.SelectedIndex = -1
        ddlProducer.SelectedIndex = -1
        'ddlRegion.Enabled = False
        chkKosher.Checked = False
        chkOrganic.Checked = False

    End Sub
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbutReset.Click
        'LoadUcombo()
        'Reset()
        Session("SearchParms") = Nothing
        Dim sPage As String = Page.Request.Url.ToString
        ' Redirect(sPage) https_transfer_6/18/08
        Response.Redirect(sPage)
    End Sub
    Private Sub ProcessSpiritStyleType(ByVal sType As String, ByRef iLiquorLevel1Type As Int16, ByRef iLiquorLevel2Type As Int16, ByRef iLiquorLevel3Type As Int16)
        Dim arsType() As String

        arsType = Split(sType, "_")

        Select Case arsType(0)
            Case 1
                iLiquorLevel1Type = arsType(1)
            Case 2
                iLiquorLevel2Type = arsType(1)
            Case 3
                iLiquorLevel3Type = arsType(1)

        End Select
    End Sub

    Protected Sub imbbSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbbSearch.Click
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
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

        Dim updatesearch As Boolean = True

        sNameLookup_value = RTrim(txtName.Text)
        iLevel1Type = 2
        bKosher = chkKosher.Checked
        updatesearch = Not chkKosher.Checked
        bOrganicall = chkOrganic.Checked
        If bOrganicall Then
            updatesearch = False
        End If

        If ddlCountrySp.SelectedIndex <> 0 Then
            sCountry = RTrim(ddlCountrySp.SelectedValue.ToString)
            updatesearch = False
        Else
            sCountry = String.Empty
        End If
        If ddlRegion.SelectedIndex <> 0 Then
            sRegion = RTrim(ddlRegion.SelectedValue.ToString)
            updatesearch = False
        Else
            sRegion = String.Empty
        End If
        If ddlProducer.SelectedIndex <> 0 Then
            sProducer = RTrim(ddlProducer.SelectedValue.ToString)
            updatesearch = False
        Else
            sProducer = String.Empty
        End If

        If ddlSize.SelectedIndex <> 0 Then
            updatesearch = False
            sSize = RTrim(ddlSize.SelectedValue.ToString)
        Else
            sSize = String.Empty
        End If

        If ddlPriceRange.SelectedIndex <> 0 Then
            updatesearch = False
            iPriceRange = Convert.ToInt16(ddlPriceRange.SelectedValue)
        Else
            iPriceRange = 0
        End If
        If ddlStyle.SelectedIndex <> 0 Then
            updatesearch = False
            sStyle = RTrim(ddlStyle.SelectedValue.ToString)
            ProcessSpiritStyleType(sStyle, iLiquorLevel1Type, iLiquorLevel2Type, iLiquorLevel3Type)
        Else
            sStyle = String.Empty
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
            = "" And sSize = "" And iPriceRange = 0 And sStyle = "" And bKosher = 0 And bOrganicall = 0 And sProducer = "" Then
            'Exit Sub
            'Redirect("SpiritsSearchNoResults.aspx?term=none", RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("SpiritsSearchNoResults.aspx?term=none")
            'lblSearchErrorMsg.Visible = True
        Else
            hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
             bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
             sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
             iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

            Dim sbSearchQuery As New StringBuilder
            sbSearchQuery = _oAstorCommon.SetQueryStrings(hstQuery)

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
                If updatesearch Then
                    searchSQLAdapter.Update(Trim(sNameLookup_value), amountTerms, dsLocal.Tables(0).Rows.Count, Now, searchRow.searchTermID, searchRow.searchTermID)
                End If
            Else
                searchSQLAdapter.Insert(Trim(sNameLookup_value), amountTerms, dsLocal.Tables(0).Rows.Count, Now)
            End If

            If dsLocal.Tables(0).Rows.Count = 0 Then
                Session("SearchParms") = hstQuery
                'Redirect("SpiritsSearchNoResults.aspx?term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
                Response.Redirect("~/SpiritsSearchNoResults.aspx?term=" & termQueryString & sbSearchQuery.ToString)
            ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
                Session("DSSingle") = dsLocal
                Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
                Session("SearchParms") = hstQuery
                Dim sSearchString As String = dsLocal.Tables(0).Rows(0).Item("item").ToString
                'Redirect("SearchResultsSingle.aspx?p=2&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp)  https_transfer_6/18/08
                Response.Redirect("~/SearchResultsSingle.aspx?p=2&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString & sbSearchQuery.ToString)

            Else
                Session("DSMulti") = dsLocal
                Session("SearchParms") = hstQuery
                'Redirect("SpiritsSearchResult.aspx?p=2&search=Advanced&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
                Response.Redirect("~/SpiritsSearchResult.aspx?p=2&search=Advanced&searchtype=Contains&term=" & termQueryString & sbSearchQuery.ToString)
            End If
        End If
    End Sub
    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountrySp.SelectedIndexChanged
        SetRegion()
    End Sub

End Class
