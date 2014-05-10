Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports System.Data
Imports System.Collections
Imports WebCommon
Imports AstorDataClass
Imports Net.valutec.ws

Public Class cAstorCommon
   
    Public Function ProcessDirectHashtable(ByVal sItem As String, ByVal sCountry As String, ByVal sRegion As String, ByVal sColor As String, ByVal sGrape As String, ByVal sCat As String, _
     ByVal sVintage As String, ByVal sDiscriminator As String, ByVal sName As String, ByVal sType As String) As Hashtable
        'Dim sItem As String = String.Empty
        'Dim sDescription As String = String.Empty
        'Dim sCountry As String = String.Empty
        'Dim sRegion As String = String.Empty
        Dim sArea As String = String.Empty
        Dim sAppelation As String = String.Empty
        'Dim sGrape As String = String.Empty
        'Dim sColor As String = String.Empty
        Dim sSize As String = String.Empty
        'Dim sVintage As String = String.Empty
        Dim sPrice As String = String.Empty
        Dim sDryness As String = String.Empty
        'Dim sType As String = String.Empty
        Dim sStyle As String = String.Empty
        Dim hstQuery As New Hashtable

        Try
            With hstQuery
                .Add("ItemUPCLookup_value", sItem)
                .Add("NameLookup_value", sName)
                .Add("Country", sCountry)
                .Add("Region", sRegion)
                .Add("Area", sArea)
                .Add("Appelation", sAppelation)
                .Add("Grape", sGrape)
                .Add("Color", sColor)
                .Add("Size", sSize)
                .Add("Vintage", sVintage)
                .Add("PriceRange", sPrice)
                .Add("Dryness", sDryness)
                If sType = "000" Then
                    .Add("Type", String.Empty)
                Else
                    .Add("Type", sType)
                End If
                .Add("Discriminator", sDiscriminator)
                .Add("Cat", sCat)
                .Add("Style", sStyle)
                .Add("Active", 1)
                .Add("PriceType", "R")
                .Add("SaleItemsOnly", 0)
                .Add("Qty", 1)
                .Add("SearchType", "Top")
                .Add("SearchParam", "100")
            End With

            'Session.Add("AdvancedQueryValue", hstQuery)
        Catch ex As Exception
            Throw ex
        Finally

        End Try

        Return hstQuery
    End Function
    Public Function ProcessHashTable(ByVal iLevel1Type As Int16, ByVal sItemUPCLookup_value As String, ByVal bAllwords As Boolean, ByVal sWord1 As String, ByVal sWord2 As String, _
    ByVal sWord3 As String, ByVal sWord4 As String, ByVal sWord5 As String, ByVal bSaleItemsOnly As Boolean, ByVal bCoolRoom As Boolean, ByVal bDessert As Boolean, _
    ByVal bGrowerProduce As Boolean, ByVal bJugWall As Boolean, ByVal bKosher As Boolean, ByVal bSparkling As Boolean, ByVal bVermouth As Boolean, ByVal bLiquorGiftSet As Boolean, _
    ByVal bWineGiftSet As Boolean, ByVal sDryness As String, ByVal sColor As String, ByVal sStyle As String, ByVal iPolishingGrade As Int16, ByVal sSize As String, _
    ByVal sNameLookup_value As String, ByVal dPriceLow As Decimal, ByVal dPriceHigh As Decimal, ByVal iQty As Int16, ByVal sVintageLow As String, ByVal sVintageHigh As String, _
    ByVal sCountry As String, ByVal sRegion As String, ByVal sSubRegion As String, ByVal sVineyard As String, ByVal sProducer As String, ByVal iLiquorLevel1Type As Int16, ByVal iLiquorLevel2Type As Int16, _
    ByVal iLiquorLevel3Type As Int16, ByVal sType As String, ByVal sGrape As String, ByVal sQuickSearch As String, ByVal sFortified As String, ByVal bFortifiedAll As Boolean, ByVal bOrganicAll As Boolean, _
    ByVal sSakeDiscriminator As String, ByVal sSakeDiscriminatorSave As String, ByVal sBA As String, ByVal iPriceRange As Int16) As Hashtable
        Dim hstQuery As New Hashtable

        Try
            With hstQuery

                .Item("Level1Type") = iLevel1Type
                .Item("SearchType") = "Top"
                .Item("SearchParam") = "100"
                .Item("ItemUPCLookup_value") = sItemUPCLookup_value
                .Item("Allwords") = bAllwords
                .Item("Word1") = sWord1
                .Item("Word2") = sWord2
                .Item("Word3") = sWord3
                .Item("Word4") = sWord4
                .Item("Word5") = sWord5
                .Item("Active") = True
                ' sale items only
                .Item("SaleItemsOnly") = bSaleItemsOnly
                ' cool room
                .Item("CoolRoom") = bCoolRoom
                ' chkDessert
                .Item("Dessert") = bDessert
                ' GrowerProducer
                .Item("GrowerProducer") = bGrowerProduce
                ' JugWall
                .Item("JugWall") = bJugWall
                ' Kosher
                .Item("Kosher") = bKosher
                ' Sparkling
                .Item("Sparkling") = bSparkling
                ' Vermouth
                .Item("Vermouth") = bVermouth
                ' liquor gift set
                .Item("LiquorGiftSet") = bLiquorGiftSet
                ' WineGiftSet
                .Item("WineGiftSet") = bWineGiftSet
                ' dryness
                .Item("Dryness") = sDryness
                ' color
                .Item("Color") = sColor
                ' Style 
                .Item("Style") = sStyle
                ' PolishingGrade
                .Item("PolishingGrade") = iPolishingGrade
                ' Size Filter
                .Item("Size") = sSize
                ' name 
                .Item("NameLookup_value") = sNameLookup_value
                'price low
                .Item("PriceLow") = dPriceLow
                'price high
                .Item("PriceHigh") = dPriceHigh
                'qty
                .Item("Qty") = iQty
                ' Vintage Selection
                .Item("VintageBegin") = sVintageLow
                .Item("VintageEnd") = sVintageHigh
                ' country
                .Item("Country") = sCountry
                ' region
                .Item("Region") = sRegion
                ' subregion
                .Item("SubRegion") = sSubRegion
                ' vineyard
                .Item("Vineyard") = sVineyard
                'producer
                .Item("Producer") = sProducer
                ' liquorlevel1type
                .Item("LiquorLevel1Type") = iLiquorLevel1Type
                ' liquorlevel2type
                .Item("LiquorLevel2Type") = iLiquorLevel2Type
                ' liquorlevel3type 
                .Item("LiquorLevel3Type") = iLiquorLevel3Type
                '' type
                .Item("Type") = sType
                .Item("Grape") = sGrape
                'parse QuickSearch
                .Item("QuickSearch") = sQuickSearch
                ' fortified 
                .Item("Fortified") = sFortified
                ' fortifiedAll 
                .Item("FortifiedAll") = bFortifiedAll
                ' organic
                .Item("OrganicAll") = bOrganicAll
                ' sake discriminator    
                .Item("SakeDiscriminator") = sSakeDiscriminator
                ' sake discriminator    
                .Item("SakeDiscriminatorSave") = sSakeDiscriminatorSave
                ' BA
                .Item("BA") = sBA
                'Price range
                .Item("PriceRange") = iPriceRange

            End With

        Catch ex As Exception
            Throw ex
        Finally

        End Try

        Return hstQuery
    End Function
    Public Function SearchHashTableDecode(ByVal hstQuery As Hashtable) As String
        Dim sSearchString As String = "0 items found"

        Try
            With hstQuery

                'If RTrim(.Item("ItemUPCLookup_value")) <> "" Then
                '    sSearchString = sSearchString & "Item/UPC = " & RTrim(.Item("ItemUPCLookup_value")) & " ~ "
                'End If
                '.Item("Allwords") = bAllwords
                If RTrim(.Item("Word1")) <> "" Then
                    sSearchString = "0 items found for " & RTrim(.Item("Word1"))
                End If
                If RTrim(.Item("Word2")) <> "" Then
                    sSearchString &= " " & RTrim(.Item("Word2"))
                End If
                If RTrim(.Item("Word3")) <> "" Then
                    sSearchString &= " " & RTrim(.Item("Word3"))
                End If
                If RTrim(.Item("Word4")) <> "" Then
                    sSearchString &= " " & RTrim(.Item("Word4"))
                End If
                If RTrim(.Item("Word5")) <> "" Then
                    sSearchString &= " " & RTrim(.Item("Word5"))
                End If
                sSearchString &= "."
                '.Item("Active") = True
                '' sale items only
                '.Item("SaleItemsOnly") = bSaleItemsOnly
                '' cool room
                '.Item("CoolRoom") = bCoolRoom
                '' chkDessert
                'If .Item("Dessert") = True Then
                '    sSearchString = sSearchString & "Dessert" & " ~ "
                'End If
                '' GrowerProducer
                '.Item("GrowerProducer") = bGrowerProduce
                '' JugWall
                '.Item("JugWall") = bJugWall
                ' Kosher
                'If .Item("Kosher") = True Then
                '    sSearchString = sSearchString & "Kosher" & " ~ "
                'End If

                '' Sparkling
                'If .Item("Sparkling") = True Then
                '    sSearchString = sSearchString & "Sparkling" & " ~ "
                'End If
                '' Vermouth
                'If .Item("Vermouth") = True Then
                '    sSearchString = sSearchString & "Vermouth" & " ~ "
                'End If
                '.Item("") = bVermouth
                '' liquor gift set
                '.Item("LiquorGiftSet") = bLiquorGiftSet
                '' WineGiftSet
                '.Item("WineGiftSet") = bWineGiftSet
                '' dryness
                '.Item("Dryness") = sDryness
                '' color
                'If .Item("Color") <> "" Then
                '    sSearchString = sSearchString & "Color" & " ~ "
                'End If
                '.Item("Color") = sColor
                '' Style
                'If .Item("Style") <> "" Then
                '    sSearchString = sSearchString & "Style" & " ~ "
                'End If

                '' PolishingGrade
                '.Item("PolishingGrade") = iPolishingGrade
                '' Size Filter
                'If .Item("Size") <> "" Then
                '    sSearchString = sSearchString & "Size" & " ~ "
                'End If
                ''.Item("Size") = sSize
                ' '' name 
                ''.Item("NameLookup_value") = sNameLookup_value
                ' ''price low
                'If .Item("PriceRange") <> 0 Then
                '    sSearchString = sSearchString & "Price Range" & " ~ "
                'End If
                ''.Item("PriceLow") = dPriceLow
                ' ''price high
                ''.Item("PriceHigh") = dPriceHigh
                ' ''qty
                ''.Item("Qty") = iQty
                ' '' Vintage Selection
                'If .Item("VintageBegin") <> "" Then
                '    sSearchString = sSearchString & "Vintage" & " ~ "
                'End If
                ''.Item("VintageBegin") = sVintageLow
                ''.Item("VintageEnd") = sVintageHigh
                ' '' country
                'If .Item("Country") <> "" Then
                '    sSearchString = sSearchString & "Country" & " ~ "
                'End If
                ''.Item("Country") = sCountry
                ' '' region
                'If .Item("Region") <> "" Then
                '    sSearchString = sSearchString & "Region" & " ~ "
                'End If
                ''.Item("Region") = sRegion
                ' '' subregion
                'If .Item("SubRegion") <> "" Then
                '    sSearchString = sSearchString & "SubRegion" & " ~ "
                'End If
                ''.Item("SubRegion") = sSubRegion
                ' '' vineyard
                ''.Item("Vineyard") = sVineyard
                ' '' liquorlevel1type
                ''.Item("LiquorLevel1Type") = iLiquorLevel1Type
                ' '' liquorlevel2type
                ''.Item("LiquorLevel2Type") = iLiquorLevel2Type
                ' '' liquorlevel3type 
                ''.Item("LiquorLevel3Type") = iLiquorLevel3Type
                '' '' type
                ''.Item("Type") = sType
                'If .Item("Grape") <> "" Then
                '    sSearchString = sSearchString & "Grape" & " ~ "
                'End If
                ''.Item("Grape") = sGrape
                ' ''parse QuickSearch
                ''.Item("QuickSearch") = sQuickSearch
                ' '' fortified 
                ''.Item("Fortified") = sFortified
                ' '' fortifiedAll
                'If .Item("Vermouth") = True Then
                '    sSearchString = sSearchString & "Vermouth" & " ~ "
                'End If
                ''.Item("FortifiedAll") = bFortifiedAll
                ' '' organic
                'If .Item("FortifiedAll") = True Then
                '    sSearchString = sSearchString & "Fortified" & " ~ "
                'End If
                ''.Item("OrganicAll") = bOrganicAll
                'If .Item("OrganicAll") = True Then
                '    sSearchString = sSearchString & "Organic" & " ~ "
                'End If
                ' '' sake discriminator

                ''.Item("SakeDiscriminator") = sSakeDiscriminator
                ' '' sake discriminator 
                'If .Item("SakeDiscriminator") <> "" Then
                '    sSearchString = sSearchString & "Sake Discriminator" & " ~ "
                'End If
                ''.Item("SakeDiscriminatorSave") = sSakeDiscriminatorSave
                ' '' BA
                'If .Item("BA") <> "" Then
                '    sSearchString = sSearchString & "Books & Accessories Type" & " ~ "
                'End If
                '.Item("BA") = sBA
                ''Price range
                '.Item("PriceRange") = iPriceRange

            End With

        Catch ex As Exception
            Throw ex
        Finally

        End Try

        Return sSearchString
    End Function
    Public Function ProcessQueryStrings(ByVal sRequestQueryString As Specialized.NameValueCollection) As Hashtable

        Dim hstQuery As New Hashtable
        Dim _oAstorCommon As New cAstorCommon

        Dim sItemUPCLookup_value As String = String.Empty
        Dim sNameLookup_value As String = String.Empty
        Dim bAllwords As Boolean = False
        Dim sWord1 As String = String.Empty
        Dim sWord2 As String = String.Empty
        Dim sWord3 As String = String.Empty
        Dim sWord4 As String = String.Empty
        Dim sWord5 As String = String.Empty
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
        Dim iLevel1Type As Int16 = 0
        Dim iPolishingGrade As Int16 = 0
        Dim sSakeDiscriminator As String = String.Empty
        Dim iPriceRange As Int16 = 0
        Dim sSakeDiscriminatorSave As String = String.Empty
        Dim sBA As String = String.Empty

        'cat
        Dim category As String = sRequestQueryString("cat")
        If sRequestQueryString("cat") <> "" Then
            iLevel1Type = category
        End If
        'grape
        Dim grape As String = sRequestQueryString("grape")
        If sRequestQueryString("grape") <> "" Then
            sGrape = grape
        End If
        'type
        Dim type As String = sRequestQueryString("type")
        If type <> "" Then
            Dim sStylePrefix As String = String.Empty
            Dim needLiquorLevel As Boolean = True
            Select Case type
                Case 5, 6, 7, 8, 9
                    sFortified = type
                    needLiquorLevel = False
                Case 11 To 16, 40 To 41, 51
                    sStylePrefix = "3_"
                    iLiquorLevel3Type = type
                Case 17 To 24, 50
                    sStylePrefix = "1_"
                    iLiquorLevel1Type = type
                Case 25 To 39
                    sStylePrefix = "2_"
                    iLiquorLevel2Type = type
                Case 42 To 49
                    sStylePrefix = "4_"
                Case 52
                    sStylePrefix = "2_"
                    iLiquorLevel2Type = type
            End Select
            If needLiquorLevel Then
                sStyle = sStylePrefix & type
            End If

        End If
        'price range
        If sRequestQueryString("pricerange") <> "0" Then
            iPriceRange = Convert.ToInt16(sRequestQueryString("pricerange"))
        End If
        'dessert
        If sRequestQueryString("dessert") <> "" Then
            bDessert = True
        End If
        'kosher
        If sRequestQueryString("kosher") <> "" Then
            bKosher = True
        End If
        'fortified
        If sRequestQueryString("fortified") <> "" Then
            sFortified = sRequestQueryString("fortified")
        End If
        'fortifiedall
        If sRequestQueryString("fortifiedall") <> "" Then
            bFortifiedAll = True
        End If
        'size
        If sRequestQueryString("size") <> "" Then
            sSize = sRequestQueryString("size")
        End If
        'country
        Dim country As String = sRequestQueryString("country")
        If sRequestQueryString("country") <> "" Then
            sCountry = country
        End If
        'region
        Dim region As String = sRequestQueryString("region")
        If sRequestQueryString("region") <> "" Then
            sRegion = region
        End If
        'subregion
        Dim subregion As String = sRequestQueryString("subregion")
        If sRequestQueryString("subregion") <> "" Then
            sSubRegion = subregion
        End If
        'producer
        Dim producer As String = sRequestQueryString("producer")
        If sRequestQueryString("producer") <> "" Then
            sProducer = producer
        End If
        'style
        Dim style As String = sRequestQueryString("style")
        If sRequestQueryString("style") <> "" Then
            sStyle = style
            If iLevel1Type = 2 Then
                Dim arsType() As String

                arsType = Split(sStyle, "_")

                Select Case arsType(0)
                    Case 1
                        iLiquorLevel1Type = arsType(1)
                    Case 2
                        iLiquorLevel2Type = arsType(1)
                    Case 3
                        iLiquorLevel3Type = arsType(1)

                End Select
            End If
        End If

        'vintage
        Dim vintage As String = sRequestQueryString("vintage")
        If sRequestQueryString("vintage") <> "" Then
            sVintageLow = vintage
        End If
        'sake
        Dim sakestyle As String = sRequestQueryString("sake")
        If sRequestQueryString("sake") <> "" Then
            sSakeDiscriminator = "(price.item in (select item from tblitemsakediscriminator where isakediscriminator = " & sakestyle & "))"
            sSakeDiscriminatorSave = sakestyle
        End If
        'polishing grade
        Dim polishingGrade As String = sRequestQueryString("polish")
        If sRequestQueryString("polish") <> "" Then
            iPolishingGrade = polishingGrade
        End If
        'organic all
        If sRequestQueryString("organic") <> "" Then
            bOrganicall = True
        End If
        'sparkling
        If sRequestQueryString("sparkling") <> "" Then
            bSparkling = True
        End If
        'color
        Dim color As String = sRequestQueryString("color")
        If sRequestQueryString("color") <> "" Then
            sColor = color
            If sColor = "rose" Then
                sColor = "rosé"
            End If
        End If

        Dim searchTerm As String = String.Empty
        If sRequestQueryString("tm") <> "" Then
            searchTerm = sRequestQueryString("tm")
        ElseIf sRequestQueryString("term") <> "" Then
            searchTerm = sRequestQueryString("term")
        End If

        If searchTerm <> String.Empty Then
            Dim _odata As New cAstorWebData(WebAppConfig.ConnectString)
            Dim queryparam() As String
            sNameLookup_value = searchTerm
            bAllwords = True
            queryparam = _odata.RunSmartSearch(sNameLookup_value)
            sWord1 = queryparam(0)
            sWord2 = queryparam(1)
            sWord3 = queryparam(2)
            sWord4 = queryparam(3)
            sWord5 = queryparam(4)
        End If

        hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
        bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
        sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
        iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

        Return hstQuery

    End Function
    Public Function SetQueryStrings(ByVal hstQuery As Hashtable) As StringBuilder


        Dim _oAstorCommon As New cAstorCommon
        Dim sbQueryString As New StringBuilder
   
        With hstQuery

            'cat
            If .Item("Level1Type").ToString <> "" Then
                sbQueryString.Append("&cat=" & System.Web.HttpUtility.UrlEncode(.Item("Level1Type").ToString))
            End If
            'grape
            If .Item("Grape") <> "" Then
                sbQueryString.Append("&grape=" & System.Web.HttpUtility.UrlEncode(.Item("Grape")))
            End If
            'price range
            If .Item("PriceRange").ToString <> "0" Then
                sbQueryString.Append("&pricerange=" & System.Web.HttpUtility.UrlEncode(.Item("PriceRange").ToString))
            End If
            'Dessert
            If .Item("Dessert").ToString <> "False" Then
                sbQueryString.Append("&dessert=" & System.Web.HttpUtility.UrlEncode(.Item("Dessert").ToString))
            End If
            'Kosher
            If .Item("Kosher").ToString <> "False" Then
                sbQueryString.Append("&kosher=" & System.Web.HttpUtility.UrlEncode(.Item("Kosher").ToString))
            End If
            'Fortified
            If .Item("Fortified").ToString <> "" Then
                sbQueryString.Append("&fortified=" & System.Web.HttpUtility.UrlEncode(.Item("Fortified").ToString))
            End If
            'FortifiedAll
            If .Item("FortifiedAll").ToString <> "False" Then
                sbQueryString.Append("&fortifiedall=" & System.Web.HttpUtility.UrlEncode(.Item("FortifiedAll").ToString))
            End If
            'size
            If .Item("Size").ToString <> "" Then
                sbQueryString.Append("&size=" & System.Web.HttpUtility.UrlEncode(.Item("Size").ToString))
            End If
            'country
            If .Item("Country").ToString <> "" Then
                sbQueryString.Append("&country=" & System.Web.HttpUtility.UrlEncode(.Item("Country").ToString))
            End If
            'Region
            If .Item("Region").ToString <> "" Then
                sbQueryString.Append("&region=" & System.Web.HttpUtility.UrlEncode(.Item("Region").ToString))
            End If
            'SubRegion
            If .Item("SubRegion").ToString <> "" Then
                sbQueryString.Append("&subregion=" & System.Web.HttpUtility.UrlEncode(.Item("SubRegion").ToString))
            End If
            'Producer
            If .Item("Producer").ToString <> "" Then
                sbQueryString.Append("&producer=" & System.Web.HttpUtility.UrlEncode(.Item("Producer").ToString))
            End If
            'style
            If .Item("Style").ToString <> "" Then
                sbQueryString.Append("&style=" & System.Web.HttpUtility.UrlEncode(.Item("Style").ToString))
            End If
            'vinatge
            If .Item("VintageBegin").ToString <> "" Then
                sbQueryString.Append("&vintage=" & System.Web.HttpUtility.UrlEncode(.Item("VintageBegin").ToString))
            End If

            'Sake
            If .Item("SakeDiscriminatorSave").ToString <> "" Then
                sbQueryString.Append("&sake=" & System.Web.HttpUtility.UrlEncode(.Item("SakeDiscriminatorSave").ToString))
            End If
            'polishing grade
            If .Item("PolishingGrade").ToString <> "0" Then
                sbQueryString.Append("&polish=" & System.Web.HttpUtility.UrlEncode(.Item("PolishingGrade").ToString))
            End If
            'organic all
            If .Item("OrganicAll").ToString <> "False" Then
                sbQueryString.Append("&organic=" & System.Web.HttpUtility.UrlEncode(.Item("OrganicAll").ToString))
            End If
            'sparkling
            If .Item("Sparkling").ToString <> "False" Then
                sbQueryString.Append("&sparkling=" & System.Web.HttpUtility.UrlEncode(.Item("Sparkling").ToString))
            End If
            'color
            If .Item("Color").ToString <> "" Then
                sbQueryString.Append("&color=" & System.Web.HttpUtility.UrlEncode(.Item("Color").ToString))
            End If
            'ba
            If .Item("BA").ToString <> "" Then
                sbQueryString.Append("&ba=" & System.Web.HttpUtility.UrlEncode(.Item("BA").ToString))
            End If
            'search term
            If Not .Item("Word1") Is Nothing Then
                If .Item("Word1").ToString <> "" Then
                    sbQueryString.Append("&tm=" & System.Web.HttpUtility.UrlEncode(.Item("Word1").ToString))
                    If Not .Item("Word2") Is Nothing Then
                        If .Item("Word2").ToString <> "" Then
                            sbQueryString.Append(System.Web.HttpUtility.UrlEncode(" " & .Item("Word2").ToString))
                        End If
                    End If
                    If Not .Item("Word3") Is Nothing Then
                        If .Item("Word3").ToString <> "" Then
                            sbQueryString.Append(System.Web.HttpUtility.UrlEncode(" " & .Item("Word3").ToString))
                        End If
                    End If
                    If Not .Item("Word4") Is Nothing Then
                        If .Item("Word4").ToString <> "" Then
                            sbQueryString.Append(System.Web.HttpUtility.UrlEncode(" " & .Item("Word4").ToString))
                        End If
                    End If
                    If Not .Item("Word5") Is Nothing Then
                        If .Item("Word5").ToString <> "" Then
                            sbQueryString.Append(System.Web.HttpUtility.UrlEncode(" " & .Item("Word5").ToString))
                        End If
                    End If
                End If
            End If



        End With

        Return sbQueryString

    End Function
    Public Function GetPageNumber(ByVal sPageName As String) As Int16
        Dim iPage As Int16

        Select Case sPageName
            Case "default"
                iPage = 1
            Case "winesearch"
                iPage = 2
            Case "spiritssearch"
                iPage = 3
            Case "sakesearch"
                iPage = 4
            Case "booksaccessoriessearch"
                iPage = 5
            Case "winesearchnoresults"
                iPage = 2
            Case "spiritssearchnoresults"
                iPage = 3
            Case "sakesearchnoresults"
                iPage = 4
            Case "booksaccessoriessearchnoresults"
                iPage = 5
            Case "winesearchresults"
                iPage = 2
            Case "spiritssearchresults"
                iPage = 3
            Case "sakesearchresults"
                iPage = 4
            Case "booksaccessoriessearchresults"
                iPage = 5
            Case "searchnoresults"
                iPage = 2
            Case "searchresults"
                iPage = 1
            Case Else
                iPage = 1
        End Select
        Return iPage
    End Function
    Public Function GiftCardBalance(ByVal GiftCardNumber As String) As String


        Dim strURL As String = "http://balances.mellennia.com/asp/balances.asp"
        Dim objWebRequest As System.Net.HttpWebRequest
        Dim streamWriter As System.IO.StreamWriter
        Dim streamReader As System.IO.StreamReader
        Dim strHTML As String = String.Empty
        Dim strPostData As String = String.Empty
        Dim strReturnValue As String = String.Empty

        If Len(GiftCardNumber) = 16 Or Len(GiftCardNumber) = 19 Then
      

            strPostData = "cardnumber=" & GiftCardNumber & "&Submit=Check Balance&action=check_balance"
            objWebRequest = CType(System.Net.WebRequest.Create(strURL), System.Net.HttpWebRequest)
            objWebRequest.Method = "POST"
            objWebRequest.ContentLength = strPostData.Length
            objWebRequest.ContentType = "application/x-www-form-urlencoded"



            streamWriter = New System.IO.StreamWriter(objWebRequest.GetRequestStream)
            streamWriter.Write(strPostData)

            streamWriter.Close()


            Dim objResponse As System.Net.HttpWebResponse = objWebRequest.GetResponse()
            streamReader = New System.IO.StreamReader(objResponse.GetResponseStream)
            strHTML = streamReader.ReadToEnd

            Try

                If strHTML.IndexOf("Current Card Balance: Invalid Card", 0) < 1 Then
                    Dim intPos1, intPos2 As Integer

                    intPos1 = strHTML.IndexOf("Current Card Balance: $", 0)
                    intPos1 += 23

                    'intPos2 = strHTML.IndexOf("<b>", intPos1)
                    intPos2 = strHTML.IndexOf("</b>", intPos1)
                    strReturnValue = strHTML.Substring(intPos1, intPos2 - intPos1)
                Else
                    strReturnValue = "Invalid Card Number"
                End If
            Catch ex As Exception
                Throw
            Finally
                streamReader.Close()
                objResponse.Close()
                objWebRequest.Abort()
            End Try
        Else

            strReturnValue = "Invalid Card Number"

        End If
        Return strReturnValue

    End Function
    Public Function GetGiftCardBalance(ByVal CardNumber As String, ByVal CKey As String, ByVal TID As String, ByVal MID As String, ByVal LID As String) As String
        Dim ValutecService As New ValutecWS
        Dim ValutecResponse As TransactionResponse

        Dim sAstorSID As String = "AstorCenter"
        Dim sBalance As String = String.Empty
        'This generates a number based on the time to use as an identifier,
        'ideally, you may want to use an order number or other tracking number to identify this
        'transaction. 
        Dim sAstorID As String = CardNumber & System.DateTime.Now.ToBinary().ToString().Substring(6, 10)

        ValutecResponse = ValutecService.Transaction_CardBalance(CKey, TID, ProgramType.Gift, CardNumber, "", sAstorID)
        If ValutecResponse.Authorized Then
            sBalance = ValutecResponse.Balance
        Else
            sBalance = ValutecResponse.ErrorMsg
        End If

        Return sBalance


    End Function
    Public Function SearchControls(ByVal dsDataset As DataSet) As String
        Dim drRow As DataRow
        Dim sSearch As String = String.Empty
        For Each drrow In dsdataset.tables(1).rows

            sSearch = sSearch & drRow.Item("iLevel1type").ToString

        Next
        Return sSearch
    End Function
    Public Function VimeoScript(ByVal VideoID As String, ByVal VideoHeight As String, ByVal VideoWidth As String) As StringBuilder

        Dim sb As StringBuilder = New StringBuilder()
        sb.Append("<script type=""text/javascript"" language=""javascript"">")
        sb.Append("var video_id = '" & VideoID & "';")
        sb.Append("var url = 'http://vimeo.com/api/v2/video/' + video_id +'.json?callback=getTitle';")

        sb.Append("function init() {")
        sb.Append("    var js = document.createElement('script');")
        sb.Append("    js.setAttribute('type', 'text/javascript');")
        sb.Append("    js.setAttribute('src', url);")
        sb.Append("    document.getElementsByTagName('head').item(0).appendChild(js); }")


        sb.Append("function getTitle(video) {  ")
        sb.Append("    var vidName = video[0].title;  }")

        sb.Append("window.onload = init;")

        sb.Append("var moogaloop = false;")

        sb.Append("function vimeo_player_loaded(swf_id) {")
        sb.Append("    moogaloop = document.getElementById(swf_id);")

        sb.Append("     moogaloop.api_addEventListener('onFinish', 'vimeo_on_finish');")
        sb.Append("    moogaloop.api_addEventListener('onPlay', 'vimeo_on_play');  }")

        sb.Append("function vimeo_on_play(swf_id) {")
        sb.Append("    videoTracker._trackEvent('Play', vidName, 1);  }")

        sb.Append("function vimeo_on_finish(swf_id) {")
        sb.Append("    videoTracker._trackEvent('Complete', vidName, 1);  }")

        sb.Append("var swf_id = 'moogaloop';")

        sb.Append("var flashvars = {")
        sb.Append("    clip_id: video_id,")
        sb.Append("    show_portrait: 1,")
        sb.Append("    show_byline: 1,")
        sb.Append("    show_title: 1,")
        sb.Append("    js_api: 1,")
        sb.Append("js_onLoad:  'vimeo_player_loaded',")
        sb.Append("js_swf_id:  'moogaloop'  };")
        sb.Append(" var params = {")
        sb.Append("allowscriptaccess:  'always',")
        sb.Append("allowfullscreen:  'true' };")
        sb.Append("var attributes = {};")

        sb.Append("swfobject.embedSWF(""http://vimeo.com/moogaloop.swf"", swf_id, '" & VideoWidth & "', '" & VideoHeight & "', ""9.0.0"", ""expressInstall.swf"", flashvars, params, attributes);")

        sb.Append("</script>")

        Return sb
    End Function
    Private Function SetAvailableFlag(ByVal botprc As Decimal, ByVal ilevel1Type As Int16, ByVal available As Int16, ByVal item As String, ByVal composite As Boolean, ByVal wineclub As Boolean) As Boolean

        SetAvailableFlag = False

        If composite Then
            SetAvailableFlag = True
        ElseIf wineclub Then
            SetAvailableFlag = True
        Else
            Select Case ilevel1Type
                Case 1
                    If botprc < 10 Then
                        If available > 12 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If

                    End If
                    If botprc >= 10 And botprc < 49.01 Then
                        If available > 6 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If

                    End If
                    If botprc > 49 And botprc < 100.01 Then
                        If available > 1 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If
                    End If
                    If botprc > 100 Then
                        If available > 1 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If
                    End If
                Case 2
                    If botprc < 10 Then
                        If available > 12 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If

                    End If
                    If botprc >= 10 And botprc < 49.01 Then
                        If available > 2 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If
                    End If
                    If botprc > 49 And botprc < 100.01 Then
                        If available > 1 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If
                    End If
                    If botprc > 100 Then
                        If available > 0 Then
                            SetAvailableFlag = True
                        Else
                            SetAvailableFlag = False
                        End If
                    End If
                Case 3
                    If available > 2 Then
                        SetAvailableFlag = True
                    Else
                        SetAvailableFlag = False
                    End If
                Case 4
                    If available > 0 Then
                        SetAvailableFlag = True
                    ElseIf item = "99025" Or item = "99050" Or item = "99075" Or item = "99100" Or item = "99150" Or item = "99200" Or item = "99250" Or item = "99300" Or item = "99500" Then
                        SetAvailableFlag = True
                    Else
                        SetAvailableFlag = False
                    End If
            End Select
        End If
       
    End Function

    Public Function getStaffPick(ByVal item As Integer) As String

        Return ""
    End Function

End Class

Public Class ErrorSummary
    Implements IValidator

    Private _message As String

    Public Shared Sub AddError(ByVal message As String, ByVal page As Page)

        Dim errorMsg As ErrorSummary = New ErrorSummary(message)
        page.Validators.Add(errorMsg)

    End Sub

    Private Sub New(ByVal message As String)
        _message = message
    End Sub

    Public Property ErrorMessage() As String Implements System.Web.UI.IValidator.ErrorMessage
        Get
            Return _message
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Property IsValid() As Boolean Implements System.Web.UI.IValidator.IsValid
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
        End Set

    End Property


    Public Sub Validate() Implements System.Web.UI.IValidator.Validate


    End Sub

End Class
