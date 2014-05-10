Imports AstorDataClass
Imports WebCommon
'Imports SslTools

Partial Class Ucontrols_WUCSakeAccessories
    Inherits System.Web.UI.UserControl

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub sakeAccessories_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sakeAccessoriesLink.Click
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

        sNameLookup_value = "sake"
        sWord1 = "sake"
        iLevel1Type = 4
        bAllwords = True

        hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
        Dim dsLocal As New System.Data.DataSet
        dsLocal = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))

        If dsLocal.Tables.Count > 0 Then
            Session("DSMulti") = dsLocal
            Session("queryType") = Nothing
            Session("queryValue") = Nothing
        Else
            'Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
        End If

        'Redirect("~/sakeAccessories.aspx", RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
        Response.Redirect("~/sakeAccessories.aspx")
    End Sub
End Class
