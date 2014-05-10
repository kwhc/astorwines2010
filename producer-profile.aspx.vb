Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO

Partial Class ProducerProfile
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ProducerID As String = String.Empty

        lblTypes.Text = "Produces:"
        'lblEst.Text = "Established:"

        ProducerID = Request.QueryString("id")
        SetProducerInfoForItem(ProducerID)

    End Sub
    Private Sub SetProducerInfoForItem(ByRef sProducer As String)
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim title As String = String.Empty
        Dim country As String = String.Empty
        Dim region As String = String.Empty
        Dim subregion As String = String.Empty
        Dim imgURL As String = String.Empty
        Dim types As String = String.Empty
        Dim bio As String = String.Empty
        Dim producerID As String = String.Empty
        'Dim est As String = String.Empty

        Try
            dsLocal = _odata.GetProducer(sProducer)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    Dim drRow As DataRow
                    For Each drRow In dsLocal.Tables(0).Rows
                        title = drRow.Item("sProducer").ToString
                        If drRow.Item("sCountry").ToString <> "" Then
                            If InStr(1, Trim(country), drRow.Item("sCountry").ToString) = 0 Then
                                country = drRow.Item("sCountry").ToString & country
                            End If
                        End If
                        If drRow.Item("sRegion").ToString <> "" Then
                            If InStr(1, Trim(region), drRow.Item("sRegion").ToString) = 0 Then
                                region = drRow.Item("sRegion").ToString & ", " & region
                            End If
                        End If
                        If drRow.Item("sSubRegion").ToString <> "" Then
                            If InStr(1, Trim(subregion), drRow.Item("sSubRegion").ToString) = 0 Then
                                subregion = drRow.Item("sSubRegion").ToString & ", " & subregion
                            End If
                        End If
                        'If drRow.Item("typec").ToString <> "" Then
                        '    If InStr(1, Trim(types), drRow.Item("typec").ToString) = 0 Then
                        '        types = drRow.Item("typec").ToString & ", " & types 
                        '    End If
                        'End If

                        producerID = drRow.Item("iProducerID").ToString

                        'imgURL = "~/images/producers/1234.jpg"
                        imgURL = "~/images/producers/" & producerID & ".jpg"

                        bio = drRow.Item("txtProducerNotes").ToString
                        'est = "2010"

                    Next
              
                End If
            Else

            End If

            litTitle.Text = title
            litCountry.Text = Trim(country)
            litRegion.Text = Trim(region)
            litSubRegion.Text = Trim(subregion)
            imgProfile.ImageUrl = imgURL
            litTypes.Text = types
            litBio.Text = "<p>" & bio & "</p>"
            'litEst.Text = est
            'lnkProducts.Text = "View all our products from " & title & " &raquo;"
            lnkProducts.Text = "View all our products from " & title & "&raquo;"
            lnkProducts.PostBackUrl = "SearchResult.aspx?p=1&ref=pprofile&searchtype=Contains&term=&cat=1&producer=" & title

            If String.IsNullOrEmpty(types) = True Then
                phProducerMeta.Visible = False
            Else
                phProducerMeta.Visible = True
            End If

            If File.Exists(imgURL) Then
                imgProfile.ImageUrl = imgURL
            Else
                imgProfile.Visible = False
            End If


        Catch ex As Exception
            Throw
        End Try

    End Sub
    Private Sub ProcessTagClick(ByVal sTag As String, ByVal sValue As String)
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
        Select Case sTag
            'Case "Color"
            '    sColor = sValue
            'Case "Vintage"
            '    sVintageLow = sValue
            'Case "Grape"
            '    sGrape = sValue
            'Case "Country"
            '    sCountry = sValue
            'Case "Region"
            '    sCountry = lnkbCountry.Text
            '    sRegion = sValue
            'Case "SubRegion"
            '    sCountry = lnkbCountry.Text
            '    sRegion = lnkbRegion.Text
            '    sSubRegion = sValue
            Case "Producer"
                sProducer = sValue

        End Select

        If Not IsNothing(Request.QueryString("p")) Then

            iLevel1Type = Convert.ToInt16(Request.QueryString("p"))
        Else

            iLevel1Type = 0
        End If


        hstQuery = _oAstorCommon.ProcessHashTable(iLevel1Type, sItemUPCLookup_value, bAllwords, sWord1, sWord2, sWord3, sWord4, sWord5, bSaleItemsOnly, bCoolRoom, bDessert, bGrowerProduce, _
        bJugWall, bKosher, bSparkling, bVermouth, bLiquorGiftSet, bWineGiftSet, sDryness, sColor, sStyle, iPolishingGrade, sSize, _
        sNameLookup_value, dPriceLow, dPriceHigh, iQty, sVintageLow, sVintageHigh, sCountry, sRegion, sSubRegion, sVineyard, sProducer, iLiquorLevel1Type, _
        iLiquorLevel2Type, iLiquorLevel3Type, sType, sGrape, sQuickSearch, sFortified, bFortifiedAll, bOrganicall, sSakeDiscriminator, sSakeDiscriminatorSave, sBA, iPriceRange)

        Dim sbSearchQuery As New StringBuilder
        sbSearchQuery = _oAstorCommon.SetQueryStrings(hstQuery)

        dsLocal = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))


        If dsLocal.Tables(0).Rows.Count = 0 Then
            Session("SearchParms") = hstQuery
            'Redirect("./WineSearchNoResults.aspx?term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            If iLevel1Type = 1 Then
                Response.Redirect("./WineSearchNoResults.aspx?term=" & sbSearchQuery.ToString)
            ElseIf iLevel1Type = 2 Then
                Response.Redirect("./SpiritsSearchNoResults.aspx?term=" & sbSearchQuery.ToString)
            ElseIf iLevel1Type = 3 Then
                Response.Redirect("./SakeSearchNoResults.aspx?term=" & sbSearchQuery.ToString)
            ElseIf iLevel1Type = 4 Then
                Response.Redirect("./BooksAccessoriesSearchNoResults.aspx?term=" & sbSearchQuery.ToString)
            Else
                Response.Redirect("./SearchNoResults.aspx?term=" & sbSearchQuery.ToString)
            End If
        ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
            Session("DSSingle") = dsLocal
            Session("SearchParms") = hstQuery
            Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
            Dim sSearchString As String = dsLocal.Tables(0).Rows(0).Item("item").ToString
            'Redirect("SearchResultsSingle.aspx?p=1&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("SearchResultsSingle.aspx?p=" + iLevel1Type.ToString + "&search=" + sSearchString + "&searchtype=Contains")

        Else
            Session("DSMulti") = dsLocal
            Session("SearchParms") = hstQuery
            'Redirect("./WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp)  https_transfer_6/18/08

            If iLevel1Type = 1 Then
                Response.Redirect("./WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains" & sbSearchQuery.ToString)
            ElseIf iLevel1Type = 2 Then
                Response.Redirect("./SpiritsSearchResult.aspx?p=2&search=Advanced&searchtype=Contains" & sbSearchQuery.ToString)
            ElseIf iLevel1Type = 3 Then
                Response.Redirect("./SakeSearchResult.aspx?p=3&search=Advanced&searchtype=Contains" & sbSearchQuery.ToString)
            ElseIf iLevel1Type = 4 Then
                Response.Redirect("./BooksAccessoriesSearchResult.aspx?p=4&search=Advanced&searchtype=Contains" & sbSearchQuery.ToString)
            Else
                Response.Redirect("./SearchResult.aspx?search=Advanced&searchtype=Contains" & sbSearchQuery.ToString)
            End If
        End If

    End Sub

    Protected Sub lnkProducts_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProducts.Click
        ProcessTagClick("Producer", CType(sender.text, String))
    End Sub
End Class
