Imports WebCommon
Imports AstorDataClass

Partial Class product
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim hstQuery As New Hashtable
        Dim _oAstorCommon As New cAstorCommon

        hstQuery = _oAstorCommon.ProcessQueryStrings(Request.QueryString)

        'Dim sItemUPCLookup_value As String = String.Empty
        'Dim sNameLookup_value As String = String.Empty
        'Dim bAllwords As Boolean = False
        'Dim sWord1 As String = String.Empty
        'Dim sWord2 As String = String.Empty
        'Dim sWord3 As String = String.Empty
        'Dim sWord4 As String = String.Empty
        'Dim sWord5 As String = String.Empty
        'Dim bSaleItemsOnly As Boolean = False
        'Dim bCoolRoom As Boolean = False
        'Dim iQty As Int16 = 1
        'Dim sDryness As String = String.Empty
        'Dim sColor As String = String.Empty
        'Dim sStyle As String = String.Empty
        'Dim sType As String = String.Empty
        'Dim sSize As String = String.Empty
        'Dim sGrape As String = String.Empty
        'Dim sCountry As String = String.Empty
        'Dim sDiscriminator As String = String.Empty
        'Dim dPriceLow As Decimal = 0
        'Dim dPriceHigh As Decimal = 0
        'Dim sVintageLow As String = String.Empty
        'Dim sVintageHigh As String = String.Empty
        'Dim sQuickSearch As String = String.Empty
        'Dim sRegion As String = String.Empty
        'Dim sSubRegion As String = String.Empty
        'Dim sVineyard As String = String.Empty
        'Dim sFortified As String = String.Empty
        'Dim bFortifiedAll As Boolean = False
        'Dim bOrganicall As Boolean = False
        'Dim bDessert As Boolean = False
        'Dim bGrowerProduce As Boolean = False
        'Dim bJugWall As Boolean = False
        'Dim bKosher As Boolean = False
        'Dim bSparkling As Boolean = False
        'Dim bVermouth As Boolean = False
        'Dim bWineGiftSet As Boolean = False
        'Dim bLiquorGiftSet As Boolean = False
        'Dim iLiquorLevel1Type As Int16 = 0
        'Dim iLiquorLevel2Type As Int16 = 0
        'Dim iLiquorLevel3Type As Int16 = 0
        'Dim iLevel1Type As Int16 = 0
        'Dim iPolishingGrade As Int16 = 0
        'Dim sSakeDiscriminator As String = String.Empty
        'Dim iPriceRange As Int16 = 0
        'Dim sSakeDiscriminatorSave As String = String.Empty
        'Dim sBA As String = String.Empty

        'Dim category As String = Request.QueryString("cat")
        'If Request.QueryString("cat") <> "" Then
        '    iLevel1Type = category
        'End If
        'Dim grape As String = Request.QueryString("grape")
        'If Request.QueryString("grape") <> "" Then
        '    sGrape = grape
        'End If
        'Dim type As String = Request.QueryString("type")
        'If type <> "" Then
        '    Dim sStylePrefix As String = String.Empty
        '    Dim needLiquorLevel As Boolean = True
        '    Select Case type
        '        Case 5, 6, 7, 8, 9
        '            sFortified = type
        '            needLiquorLevel = False
        '        Case 11 To 16, 40 To 41, 51
        '            sStylePrefix = "3_"
        '            iLiquorLevel3Type = type
        '        Case 17 To 24, 50
        '            sStylePrefix = "1_"
        '            iLiquorLevel1Type = type
        '        Case 25 To 39
        '            sStylePrefix = "2_"
        '            iLiquorLevel2Type = type
        '        Case 42 To 49
        '            sStylePrefix = "4_"
        '        Case 52
        '            sStylePrefix = "2_"
        '            iLiquorLevel2Type = type
        '    End Select
        '    If needLiquorLevel Then
        '        sStyle = sStylePrefix & type
        '    End If

        'End If
        'Dim country As String = Request.QueryString("country")
        'If Request.QueryString("country") <> "" Then
        '    sCountry = country
        'End If
        'Dim region As String = Request.QueryString("region")
        'If Request.QueryString("region") <> "" Then
        '    sRegion = region
        'End If
        'Dim subregion As String = Request.QueryString("subregion")
        'If Request.QueryString("subregion") <> "" Then
        '    sSubRegion = subregion
        'End If
        'Dim vintage As String = Request.QueryString("vintage")
        'If Request.QueryString("vintage") <> "" Then
        '    sVintageLow = vintage
        'End If
        'Dim sakestyle As String = Request.QueryString("sake")
        'If Request.QueryString("sake") <> "" Then
        '    sSakeDiscriminator = "(price.item in (select item from tblitemsakediscriminator where isakediscriminator = " & sakestyle &  "))"
        'End If
        'Dim polishingGrade As String = Request.QueryString("polish")
        'If Request.QueryString("polish") <> "" Then
        '    iPolishingGrade = polishingGrade
        'End If
        'If Request.QueryString("organic") <> "" Then
        '    bOrganicall = True
        'End If
        'If Request.QueryString("sparkling") <> "" Then
        '    bSparkling = True
        'End If
        'Dim color As String = Request.QueryString("color")
        'If Request.QueryString("color") <> "" Then
        '    sColor = color
        '    If sColor = "rose" Then
        '        sColor = "rosé"
        '    End If
        'End If
        'Dim searchTerm As String = Request.QueryString("term")
        'If Request.QueryString("term") <> "" Then
        '    Dim _odata As New cAstorWebData(WebAppConfig.ConnectString)
        '    Dim queryparam() As String
        '    sNameLookup_value = searchTerm
        '    bAllwords = True
        '    queryparam = _odata.RunSmartSearch(sNameLookup_value)
        '    sWord1 = queryparam(0)
        '    sWord2 = queryparam(1)
        '    sWord3 = queryparam(2)
        '    sWord4 = queryparam(3)
        '    sWord5 = queryparam(4)
        'End If

        'hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
        'bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
        'sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, iLiquorLevel1Type, _
        'iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

        Session("SearchParms") = hstQuery

    End Sub
End Class
