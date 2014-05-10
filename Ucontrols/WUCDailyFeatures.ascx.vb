Imports WebCommon
Imports AstorDataClass
'Imports SslTools

Partial Class Ucontrols_WUCDailyFeatures
    Inherits System.Web.UI.UserControl

    Private dsn As String = WebAppConfig.ConnectString
    Private _feature As Integer
    Private _item As String
    Private iLevel1Type As Int16 = 0

    Public Property feature() As Integer
        Get
            Return _feature
        End Get
        Set(ByVal value As Integer)
            _feature = value
        End Set
    End Property

    Public Property item() As String
        Get
            Return _item
        End Get
        Set(ByVal value As String)
            _item = value
        End Set
    End Property

    Protected Function loadHashTable(ByVal type As Integer) As Hashtable
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

        Dim iPolishingGrade As Int16 = 0
        Dim sSakeDiscriminator As String = String.Empty
        Dim iPriceRange As Int16 = 0

        Dim sSakeDiscriminatorSave As String = String.Empty
        Dim sBA As String = String.Empty

        Select Case feature
            Case 1
                featureTab.Text = "Staff Pick"
                seemore.Visible = False
                iLevel1Type = 1
            Case 2
                featureTab.Text = "Daily Deal"
                seemore.Visible = False
                iLevel1Type = 1
            Case 3
                featureTab.Text = "Mr. Popular"
                seemore.Visible = False
                iLevel1Type = 1
            Case 4
                featureTab.Text = "Organic"
                bOrganicall = True
                iLevel1Type = 1
                seemore.Text = "All Organic >"

            Case 5
                featureTab.Text = "Only at Astor"
                seemore.Text = "All Exclusives >"
                iLevel1Type = 1
            Case 6
                featureTab.Text = "Sparkling"
                sStyle = 2
                bSparkling = True
                iLevel1Type = 1
                seemore.Text = "All Sparkling >"
            Case 7
                featureTab.Text = "Sparkling"
                iLevel1Type = 3
                sSakeDiscriminator = "(price.item in (select item from tblitemsakediscriminator where isakediscriminator = 5))"
                seemore.Text = "All Sparkling >"
            Case 8
                featureTab.Text = "Daiginjo"
                iLevel1Type = 3
                iPolishingGrade = 15
                seemore.Text = "All Daiginjo >"
            Case 9
                featureTab.Text = "Nama"
                iLevel1Type = 3
                sSakeDiscriminator = "(price.item in (select item from tblitemsakediscriminator where isakediscriminator = 3))"
                seemore.Text = "All Nama >"
            Case 10
                featureTab.Text = "Absinthe"
                sNameLookup_value = "absinth"
                bAllwords = True
                sWord1 = "absinth"
                iLevel1Type = 2
                seemore.Text = "All Absinthes >"
            Case 11
                featureTab.Text = "Single Malt"
                sStyle = "3_41"
                iLiquorLevel3Type = 41
                iLevel1Type = 2
                seemore.Text = "All Single Malts >"
            Case 12
                featureTab.Text = "Gin"
                sStyle = "1_19"
                iLiquorLevel1Type = 19
                iLevel1Type = 2
                seemore.Text = "All Gins >"
            Case 13
                featureTab.Text = "Wine Racks"
                seemore.Text = "All Racks >"
                sBA = "48"
                iLevel1Type = 4
            Case 14
                featureTab.Text = "Corkscrews"
                seemore.Text = "All Corkscrews >"
                sBA = "43"
                iLevel1Type = 4
            Case 15
                featureTab.Text = "Wine 101"
                seemore.Text = "All Books >"
                sBA = "42"
                iLevel1Type = 4
        End Select

        hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

        Return hstQuery

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim name As String = String.Empty
        Dim vintage As String = String.Empty
        Dim size As String = String.Empty
        Dim labelNotes As String = String.Empty
        Dim bottlePrice As Decimal = 0
        Dim casePrice As Decimal = 0
        Dim dealBottlePrice As Decimal = 0
        Dim dealCasePrice As Decimal = 0
        Dim pack As Integer = 0
        Dim onSale As String = String.Empty
        Dim rowToView As Integer

        Dim strUrl As String = Request.Url.ToString()
        Session("ReturnUrl") = strUrl

        If feature > 3 Then
            rowToView = Now.Day - 1
        Else
            rowToView = 0
        End If
        Dim hstQuery As Hashtable = loadHashTable(feature)

        Select Case feature
            Case 13 To 15
                Dim ddlItem As New ListItem("item(s)", "item")
                ddlType.Items.Clear()
                ddlType.Items.Add(ddlItem)
        End Select

        Select Case feature
            Case 1 To 3
                Dim featureSQLAdapter As New astorWinesTableAdapters.GetWebFeatureItems_spTableAdapter
                Dim featureDatatable As astorWines.GetWebFeatureItems_spDataTable
                featureDatatable = featureSQLAdapter.GetWebFeatureItems(feature, 1)
                If featureDatatable.Rows.Count > rowToView Then
                    Dim featureRow As astorWines.GetWebFeatureItems_spRow = featureDatatable.Rows(0)
                    item = featureRow.Item
                    name = featureRow.sName
                    vintage = featureRow.vintage
                    size = featureRow.Size
                    labelNotes = featureRow.sBinLabelNotes
                    bottlePrice = featureRow.botprcfl
                    casePrice = featureRow.casprcfl
                    dealBottlePrice = featureRow.botprc
                    dealCasePrice = featureRow.casprc
                    onSale = featureRow.OnSale
                    pack = featureRow.Pack

                End If
                'Case 5
                '    Dim featureSQLAdapter As New astorWinesTableAdapters.GetWebFeatureItems_spTableAdapter
                '    Dim featureDatatable As astorWines.GetWebFeatureItems_spDataTable
                '    featureDatatable = featureSQLAdapter.GetExclusiveItems
                '    Dim newRowToView = rowToView
                '    If featureDatatable.Rows.Count <= rowToView Then
                '        newRowToView = (rowToView Mod featureDatatable.Rows.Count)
                '    End If
                '    Dim featurerow As astorWines.GetWebFeatureItems_spRow = featureDatatable.Rows(newRowToView)
                '    item = featurerow.Item
                '    name = featurerow.sName
                '    vintage = featurerow.vintage
                '    size = featurerow.Size
                '    labelNotes = featurerow.sBinLabelNotes
                '    bottlePrice = featurerow.botprcfl
                '    casePrice = featurerow.casprcfl
                '    dealPrice = featurerow.botprc
            Case Else
                Dim _odata As New cAstorWebData(dsn)
                Dim _oWebCommon As New WebPageBase
                Dim dsLocal As New System.Data.DataSet
                If feature = 5 Then
                    Dim featureSQLAdapter As New astorWinesTableAdapters.GetWebFeatureItems_spTableAdapter
                    Dim featureDatatable As astorWines.GetWebFeatureItems_spDataTable
                    featureDatatable = featureSQLAdapter.GetExclusiveItems
                    dsLocal.Tables.Add(featureDatatable)
                Else
                    dsLocal = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))
                End If
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    Dim featureRow As Data.DataRow
                    Dim newRowToView = rowToView
                    If dsLocal.Tables(0).Rows.Count <= rowToView Then
                        newRowToView = (rowToView Mod dsLocal.Tables(0).Rows.Count)
                    End If
                    featureRow = dsLocal.Tables(0).Rows(newRowToView)
                    item = featureRow.Item("item")
                    name = featureRow.Item("name")
                    vintage = featureRow.Item("vintage")
                    size = featureRow.Item("size")
                    labelNotes = featureRow.Item("sDescr")
                    bottlePrice = featureRow.Item("botprcfl")
                    casePrice = featureRow.Item("casprcfl")
                    dealBottlePrice = featureRow.Item("botprc")
                    dealCasePrice = featureRow.Item("casprc")
                    onSale = featureRow.Item("OnSale")
                    pack = featureRow.Item("pack")
                End If
        End Select
        If Trim(vintage) <> "" Then
            vintage = " - " & vintage
        End If
        Dim productURL As String = "../SearchResultsSingle.aspx?p=" & iLevel1Type.ToString & "&search=" & item & "&searchtype=Contains&rel=dailyFeatures"
        featureTitle.Text = "<a href=""" & productURL & """>" & name & vintage & " " & "</a>"
        Dim imageLocation As String = "./images/itemimages/sm/" & item & "_sm.jpg"
        Dim imageFile As New IO.FileInfo(Server.MapPath(imageLocation))
        If Not imageFile.Exists Then
            imageLocation = "./images/itemimages/sm/" & item & "_sm.gif"
            imageFile = New IO.FileInfo(Server.MapPath(imageLocation))
        End If
        If Not imageFile.Exists Then
            Select Case feature
                Case 1 To 6
                    imageLocation = "./images/itemimages/sm/redwinegeneric_sm.gif"
                Case 7 To 9
                    imageLocation = "./images/itemimages/sm/sakegeneric_sm.gif"
                Case 10
                    imageLocation = "./images/itemimages/sm/vermouthsaperitifsdigestifsgeneric_sm.gif"
                Case 11
                    imageLocation = "./images/itemimages/sm/whiskeygeneric_sm.gif"
                Case 12
                    imageLocation = "./images/itemimages/sm/gingeneric_sm.gif"
                Case 13 To 15
                    imageLocation = "./images/itemimages/sm/NoImageAvailable.gif"
            End Select
        End If

        featureImageLink.Text = "<a href=""" & productURL & """><img src=""" & imageLocation & """ class=""featureImage"" alt="""" /></a>"
        'featureImage.ImageUrl = "." & imageLocation
        featureDescription.Text = cutOff(labelNotes, 132)
        featureLink.NavigateUrl = productURL
        featureItemNr.Text = item
        packInteger.text = pack

        If onSale = "On Sale" Then
            ltrBottlePrice.Text = "<span class=""wrongPrice""> $" & bottlePrice & "</span><span class=""dealPrice""> $" & dealBottlePrice & "</span>"
            ltrCasePrice.Text = "<span class=""wrongPrice""> $" & casePrice & "</span><span class=""dealPrice""> $" & dealCasePrice & "</span>"
        Else
            ltrBottlePrice.Text = " $" & bottlePrice
            ltrCasePrice.Text = " $" & casePrice

        End If
    End Sub

    Private Function cutOff(ByVal givenString As String, ByVal givenWidth As Integer) As String
        If givenWidth > givenString.Length Or givenWidth = -1 Then
            Return givenString
        ElseIf givenWidth = 0 Then
            Return ""
        Else
            Return givenString.Substring(0, givenWidth).Substring(0, givenString.Substring(0, givenWidth).LastIndexOf(" ")) & "..."
        End If
    End Function

    Protected Sub btnAddToCart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAddToCart.Click
        Dim cart As New AstorwinesCommerce.CartDB(WebAppConfig.ConnectString)
        Dim _oWebCommon As New WebPageBase
        Dim orderType As String = ddlType.SelectedValue
        Dim intTxt As Integer = wneQty.Value


        If cart.CheckCartForWineClub(_oWebCommon.GetCustomerID(Request, Response), item) Then
            Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = strUrl
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(_oWebCommon.GetCustomerID, item, orderType, intTxt)
            Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = strUrl
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If

        'cart.AddShoppingCartItem(_oWebCommon.GetCustomerID(Request, Response), item, orderType, intTxt)
        'Dim strUrl As String = Request.Url.ToString()
        'Session("ReturnUrl") = strUrl
        'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)
    End Sub

    Protected Sub featureLink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles seemore.Click
        Dim hstQuery As Hashtable = loadHashTable(feature)
        Session("SearchParms") = hstQuery
        Session("queryType") = Nothing
        Session("queryValue") = Nothing
        Dim sRedirect As String = String.Empty

        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim _oWebCommon As New WebPageBase
        Dim dsLocal As New System.Data.DataSet
        If feature = 5 Then
            Dim featureSQLAdapter As New astorWinesTableAdapters.GetWebFeatureItems_spTableAdapter
            Dim featureDatatable As astorWines.GetWebFeatureItems_spDataTable
            featureDatatable = featureSQLAdapter.GetExclusiveItems
            dsLocal.Tables.Add(featureDatatable)
            Session.Remove("SearchParms")
        Else
            dsLocal = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))
        End If

        If dsLocal.Tables(0).Rows.Count = 0 Then
            sRedirect = "~/SearchNoResults.aspx"
        ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
            Session("DSSingle") = dsLocal
            Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
            sRedirect = "~/SearchResultsSingle.aspx?search=" & item & "&amp;searchtype=Contains&amp;rel=dailyFeatures"
        Else
            Dim sSearchControls As String = "1"
            'sSearchControls = _oAstorCommon.SearchControls(dsLocal)
            Session.Add("DSMulti", dsLocal)
            sRedirect = "~/SearchResult.aspx?rel=dailyFeatures&amp;search=Advanced&amp;searchtype=Contains&amp;p=" & sSearchControls
        End If

        'Redirect(sRedirect, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
        Response.Redirect(sRedirect)
    End Sub
End Class
