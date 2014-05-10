Imports AstorDataClass
Imports WebCommon

Partial Class Ucontrols_WUCGlossaryRelated
    Inherits System.Web.UI.UserControl

    Private dsn As String = WebAppConfig.ConnectString
    Private _term As String
    Private _type As String
    Public Property term() As String
        Get
            Return _term
        End Get
        Set(ByVal value As String)
            _term = value
        End Set
    End Property

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Public Sub loadRelatedItem()
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

        Select Case type
            Case "Grape Variety"
                sGrape = term
            Case "Region"
            Case "SubRegion"
            Case "Vineyard"
        End Select

        hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
        Dim dsLocal As System.Data.DataSet
        dsLocal = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))
        If dsLocal.Tables(0).Rows.Count >= 3 Then
            WUCSingleRelated3.item = dsLocal.Tables(0).Rows(2).Item("item")
            WUCSingleRelated3.loadRelated()
        Else
            WUCSingleRelated3.Visible = False
        End If
        If dsLocal.Tables(0).Rows.Count >= 2 Then
            WUCSingleRelated2.item = dsLocal.Tables(0).Rows(1).Item("item")
            WUCSingleRelated2.loadRelated()
        Else
            WUCSingleRelated2.Visible = False
        End If
        If dsLocal.Tables(0).Rows.Count >= 1 Then
            WUCSingleRelated1.item = dsLocal.Tables(0).Rows(0).Item("item")
            WUCSingleRelated1.loadRelated()
        Else
            WUCSingleRelated1.Visible = False
        End If
    End Sub

End Class
