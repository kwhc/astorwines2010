
Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
Imports System.Windows.Forms

'Imports SslTools
Partial Class SearchResultsSingle
    Inherits WebPageBase
    Private sSearchTypeShow As String = String.Empty
    Private sItem As String = String.Empty
    Private dsn As String = WebAppConfig.ConnectString

    Private VideoID As String = String.Empty
    Private Email As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsNothing(Request.QueryString("sb")) Then
        '    searchBig.Visible = True
        '    searchSmall.Visible = False
        'Else
        '    searchBig.Visible = False
        '    searchSmall.Visible = True
        'End If

        If Not IsNothing(Request.QueryString("search")) Then
            sItem = Request.QueryString("search")
            hlTellFriend.NavigateUrl = "AstorWinesEmailToFriend.aspx?item=" & sItem
            Session("ReturnUrlModal") = Request.Url.AbsolutePath & Request.Url.Query
        End If
        If Not IsPostBack Then
            If Not IsNothing(Request.QueryString("search")) Then
                sItem = Request.QueryString("search")
                Session.Item("queryValue") = sItem

            End If
            If Not IsNothing(Request.QueryString("searchtype")) Then
                Session.Item("queryType") = Request.QueryString("searchtype")
            End If

            If Not IsNothing(Request.QueryString("rd")) Then
                Dim qsRd As String

                qsRd = Request.QueryString("rd")

            End If
            If Not Session("ReturnUrl") Is Nothing Then
                ReturnUrl.Value = Session("ReturnUrl")
                Session("ReturnUrl") = Nothing

            Else
                ReturnUrl.Value = "~/default.aspx"
            End If

            'hyplReturnToShopping.NavigateUrl = ReturnUrl.Value
            If Context.User.Identity.Name <> "" Then
                Email = Context.User.Identity.Name
            Else
                Email = ""
            End If

            'Email to a friend success message
            If Session("emailSuccess") = True Then
                pnlEmailShareSucccess.Visible = True
                Session("emailSuccess") = False
            End If

            LoadResultSimpleDataList()
            BindControls()
            SetUpGlossary()

            WUCMoreLikeThis.item = sItem
            WUCMoreLikeThis.BindResultDataList()
            moreLikeThis.Visible = WUCMoreLikeThis.showMe

            'Select Case sSearchTypeShow
            '    Case 0

            '    Case 1
            '        Me.WUCWineSearch1.Visible = True
            '        Me.WUCSakeSearch1.Visible = False
            '        Me.WUCSpiritsSearch1.Visible = False
            '        Me.WUCBooksAssocSearch1.Visible = False

            '    Case 2
            '        Me.WUCWineSearch1.Visible = False
            '        Me.WUCSakeSearch1.Visible = False
            '        Me.WUCSpiritsSearch1.Visible = True
            '        Me.WUCBooksAssocSearch1.Visible = False
            '    Case 3
            '        Me.WUCWineSearch1.Visible = False
            '        Me.WUCSakeSearch1.Visible = True
            '        Me.WUCSpiritsSearch1.Visible = False
            '        Me.WUCBooksAssocSearch1.Visible = False
            '    Case 4
            '        Me.WUCWineSearch1.Visible = False
            '        Me.WUCSakeSearch1.Visible = False
            '        Me.WUCSpiritsSearch1.Visible = False
            '        Me.WUCBooksAssocSearch1.Visible = True

            'End Select
            'videoTout1.VideoID = VideoID

            'VimeoScript()

            If Not Session("ItemName") Is Nothing Then
                Page.Title = Session("ItemName") & " | AstorWines.com"
            End If

        End If

        'Dim iLevel1Type As String
        'iLevel1Type = Convert.ToInt16(Request.QueryString("p"))
        '        If iLevel1Type = 2 Then
        '            imgbAddToCart.OnClientClick = "launchSpiritsShippingModal(); return false;"
        '        End If

        'ChoosePricingDisplay()

        Dim parameter As String = Request("__EVENTARGUMENT")
        If parameter = "true" Then
            addToCart()
        End If

    End Sub

    Private Sub GetTastingForItem(ByVal sItem As String)
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim sTastingDate As String = String.Empty
        Try
            sTastingDate = _odata.GetTastingsForItem(sItem)
            If RTrim(sTastingDate) <> "" Then
                phTasting.Visible = True
                lnkbTasting.Text = RTrim(sTastingDate)
                lnkbTasting.PostBackUrl = "~/TastingEvents.aspx"
            Else
                phTasting.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub GetWineClubForItem(ByVal sItem As String)
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim sWineClub As String = String.Empty
        Try
            sWineClub = _odata.GetWineClubForItem(sItem)
            If RTrim(sWineClub) <> "" Then
                phWineClub.Visible = True
                lnkbWineClub.Text = RTrim(sWineClub)
                lnkbWineClub.PostBackUrl = "~/AstorWinesWineClubs.aspx"
            Else
                phWineClub.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub GetAstorCenterClassForItem(ByVal sItem As String)
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim sAstorCenterClass As String = String.Empty
        Try
            sAstorCenterClass = _odata.GetAstorCenterClassForItem(sItem)
            If RTrim(sAstorCenterClass) <> "" Then
                Dim ACclass() As String = Split(sAstorCenterClass, "|")
                phClass.Visible = True
                lnkbClass.Text = RTrim(ACclass(1))
                lnkbClass.PostBackUrl = RTrim(ACclass(0))
            Else
                phClass.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetGrapesForItem(ByVal sItem As String) As String
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim sGrapes As String = String.Empty
        Try
            dsLocal = _odata.GetGrapesForItem(sItem)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    Dim drRow As DataRow
                    For Each drRow In dsLocal.Tables(0).Rows
                        sGrapes = sGrapes & " " & drRow.Item("grpname")
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return sGrapes
    End Function
    Private Function SetUpGrapesLinkForItem(ByVal sItem As String) As String
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim sGrapes As String = String.Empty
        Try
            dsLocal = _odata.GetGrapesForItem(sItem)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    phGrape.Visible = True
                    Dim drRow As DataRow
                    Dim iCount As Int16 = 1
                    For Each drRow In dsLocal.Tables(0).Rows
                        Select Case iCount
                            Case 1
                                lnkbGrape1.Text = RTrim(drRow.Item("grpname").ToString) & "&nbsp;"
                                lnkbGrape1.Visible = True
                            Case 2
                                lnkbGrape2.Text = RTrim(drRow.Item("grpname").ToString) & "&nbsp;"
                                lnkbGrape2.Visible = True
                            Case 3
                                lnkbGrape3.Text = RTrim(drRow.Item("grpname").ToString) & "&nbsp;"
                                lnkbGrape3.Visible = True
                            Case 4
                                lnkbGrape4.Text = RTrim(drRow.Item("grpname").ToString) & "&nbsp;"
                                lnkbGrape4.Visible = True
                            Case 5
                                lnkbGrape5.Text = RTrim(drRow.Item("grpname").ToString) & "&nbsp;"
                                lnkbGrape5.Visible = True
                        End Select

                        iCount = iCount + 1
                        If iCount > 5 Then
                            Exit For
                        End If
                    Next
                Else
                    phGrape.Visible = False
                End If
            Else
                phGrape.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return sGrapes
    End Function
    Private Function GetOrganicsForItem(ByVal sItem As String) As String
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim sGrapes As String = String.Empty
        Try
            dsLocal = _odata.GetOrganicsForItem(sItem)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    Dim drRow As DataRow
                    For Each drRow In dsLocal.Tables(0).Rows
                        sGrapes = sGrapes & " " & drRow.Item("sorganicDesc")
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return sGrapes
    End Function
    Private Function GetSakeDiscriminatorsForItem(ByVal sItem As String) As String
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim sSakedesc As String = String.Empty
        Try
            dsLocal = _odata.GetSakeDiscriminatorsForItem(sItem)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    Dim drRow As DataRow
                    For Each drRow In dsLocal.Tables(0).Rows
                        sSakedesc = sSakedesc & " " & drRow.Item("sakedesc")
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return sSakedesc
    End Function
    Private Sub SetStaffPickInfoForItem(ByRef bHasNotes As Boolean)
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Try
            dsLocal = _odata.GetStaffPickItemInfo(sItem)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    Dim drRow As DataRow
                    For Each drRow In dsLocal.Tables(0).Rows

                        lblStaffPickTitle.Text = drRow.Item("sTitle").ToString
                        lblStaffPickNote.Text = drRow.Item("txtStaffPickNote").ToString
                        lblStaffName.Text = " - " & drRow.Item("sSls").ToString
                        If lblStaffPickTitle.Text = "" Then
                            lblStaffPickTitle.Visible = False
                        End If
                        If lblStaffName.Text = "" Then
                            lblStaffName.Visible = False

                        End If
                    Next
                Else
                    staffPick.Visible = False
                End If
            Else
                staffPick.Visible = False
            End If
            bHasNotes = staffPick.Visible
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub SetProducerInfoForItem(ByRef sProducer As String)
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim cutOffInteger As Int16 = 400
        Try
            dsLocal = _odata.GetProducer(sProducer)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then
                    Dim drRow As DataRow
                    For Each drRow In dsLocal.Tables(0).Rows
                        'lblStaffPickTitle.Text = drRow.Item("sTitle").ToString
                        If Len(drRow.Item("txtProducerNotes").ToString) > cutOffInteger Then
                            litAboutProducer.Text = Utility.cutOff(drRow.Item("txtProducerNotes").ToString, cutOffInteger)
                            entryLink.Visible = True
                            entryLink.NavigateUrl = "~/producer-profile.aspx?id=" & drRow.Item("sProducer").ToString

                        Else
                            litAboutProducer.Text = drRow.Item("txtProducerNotes").ToString
                            entryLink.Visible = True
                            entryLink.NavigateUrl = "~/producer-profile.aspx?id=" & drRow.Item("sProducer").ToString
                        End If

                        If litAboutProducer.Text = "" Then
                            phAboutProducer.Visible = False
                        End If
                    Next
                Else

                    phAboutProducer.Visible = False
                End If
            Else

                phAboutProducer.Visible = False
            End If

        Catch ex As Exception
            Throw
        End Try

    End Sub
    Private Sub SetUBCAwardsForItem()
        Dim product As New AstorwinesCommerce.ProductsDB(getConnStr())
        Dim dsLocal As DataSet
        Dim sAward As String = String.Empty
        Dim sAwardYear As String = String.Empty
        Dim sAwardImg As String = String.Empty
        Dim alt As String = String.Empty

        pnlUBC.Visible = False

        Try
            dsLocal = product.GetUBCAwardsForItem(sItem)
            If dsLocal.Tables.Count > 0 Then
                If dsLocal.Tables(0).Rows.Count > 0 Then

                    pnlUBC.Visible = True

                    Dim drRow As DataRow
                    For Each drRow In dsLocal.Tables(0).Rows
                        sAward = drRow.Item("iAward").ToString()
                        sAwardYear = drRow.Item("iAwardYear").ToString()
                        Select Case sAwardYear
                            Case 4 '2011
                                Select Case sAward
                                    'Case 1 'Extraordinary, Ultimate Recommendation
                                    '    sAwardImg = "images/UBC/2011_ubc_.jpg"
                                    'Case 2 'Excellent, Highly Recommended
                                    '    sAwardImg = "images/UBC/2011_img_ubc.jpg"
                                    Case 3 'Chairmans Trophy
                                        sAwardImg = "../images/UBC/2011_ubc_ct.jpg"
                                        alt = "2011 Chairman's Trophy"
                                    Case 4 'Finalist
                                        sAwardImg = "../images/UBC/2011_ubc_fin.jpg"
                                        alt = "2011 Finalist"
                                    Case 5 'Great Value
                                        sAwardImg = "../images/UBC/2011_ubc_gv.jpg"
                                        alt = "2011 Great Value"
                                End Select
                            Case 5 '2012
                                Select Case sAward
                                    'Case 1 'Extraordinary, Ultimate Recommendation
                                    '    sAwardImg = "images/UBC/2012_ubc_.jpg"
                                    'Case 2 'Excellent, Highly Recommended
                                    '    sAwardImg = "images/UBC/2012_img_ubc.jpg"
                                    Case 3 'Chairmans Trophy
                                        sAwardImg = "../images/UBC/2012_ubc_ct.jpg"
                                        alt = "2012 Chairman's Trophy"
                                    Case 4 'Finalist
                                        sAwardImg = "../images/UBC/2012_ubc_fin.jpg"
                                        alt = "2012 Finalist"
                                    Case 5 'Great Value
                                        sAwardImg = "../images/UBC/2012_ubc_gv.jpg"
                                        alt = "2012 Great Value"
                                End Select
                        End Select

                        Dim img As Image = New Image
                        Dim spacer As LiteralControl = New LiteralControl("<br />")

                        img.ImageUrl = sAwardImg
                        img.CssClass = "ubc-award"

                        phUBCAwards.Controls.Add(img)

                    Next
                Else
                    phUBCAwards.Visible = False
                End If
            Else
                phUBCAwards.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub SetUpGlossary()
        Try
            Dim sItem As String
            Dim oDS As DataSet = Session("DSSingle")
            If oDS.Tables.Count > 0 Then
                If oDS.Tables(0).Rows.Count > 0 Then
                    With oDS.Tables(0).Rows(0)
                        sItem = .Item("item").ToString
                        WUCDefinitions1.Country = .Item("sCountry")
                        WUCDefinitions1.Region = .Item("sRegion")
                        WUCDefinitions1.SubRegion = .Item("sSubRegion")
                        WUCDefinitions1.Vineyard = .Item("sVineyard")
                        WUCDefinitions1.GrapeVariety = GetGrapesForItem(sItem)
                        WUCDefinitions1.MiscTerms = .Item("MiscWords") & " " & GetOrganicsForItem(sItem) & " " & GetSakeDiscriminatorsForItem(sItem)
                        WUCDefinitions1.BindResultDataList()

                    End With
                End If
            Else
                glossary.Visible = False
            End If
            glossary.Visible = WUCDefinitions1.showMe
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BindControls()
        Try

            Dim oDS As DataSet = Session("DSSingle")
            Dim iUBC As Int16 = 0

            If oDS.Tables.Count > 0 Then
                If oDS.Tables(0).Rows.Count > 0 Then
                    With oDS.Tables(0).Rows(0)
                        If .Item("composite") = True Then
                            Response.Redirect("~/SpecialPacks.aspx?packitem=" & .Item("item").ToString, True)
                            'Server.Transfer("~/SpecialPacks.aspx?packitem=" & .Item("item").ToString, False)
                        End If

                        'Out of Stock Messages
                        'Dim outOfStockMsg As String = "We'll send you an email when this item is back in stock"
                        Dim outOfStockMsg As String = "This item is currently out of stock - would you like to receive an email when it is back in stock?"
                        Dim preOrderMsg As String = "This item is expected to arrive soon."
                        Dim reorderMsg As String = "This is expected to be back in stock soon."
                        Dim sName As String
                        'Dim sInfo As String = String.Empty

                        sName = .Item("name").ToString
                        If RTrim(.Item("vintage")) <> "" Then
                            sName = sName & " - " & RTrim(.Item("vintage"))
                        End If

                        'BOTTLE SIZE 
                        Dim itmSize As String
                        Dim itmSizeTitle As String
                        itmSize = ""
                        itmSizeTitle = ""

                        If .Item("iLevel1Type") = 1 Then
                            If .Item("size").Contains("LTR") Then
                                itmSize = "1L"
                            ElseIf .Item("size").Contains("SGL") Then
                                itmSize = RTrim(.Item("size"))
                            ElseIf .Item("size").Contains("L") Then
                                itmSize = RTrim(.Item("size"))
                            ElseIf .Item("size").Contains("375") Then
                                itmSize = RTrim(.Item("size")) & "mL"
                                itmSizeTitle = "Half-Bottle of"
                            ElseIf .Item("size").Contains("187") Then
                                itmSize = RTrim(.Item("size")) & "mL"
                                itmSizeTitle = "Split-Bottle of"
                            ElseIf .Item("size").Contains("500") Then
                                itmSize = RTrim(.Item("size")) & "mL"
                            ElseIf .Item("size").Contains("750") Then
                                itmSize = RTrim(.Item("size")) & "mL"
                            ElseIf .Item("size").Contains("1.5") Then
                                itmSize = RTrim(.Item("size")) & "L"
                            Else
                                itmSize = ""
                            End If

                        Else
                            If .Item("size").Contains("LTR") Then
                                itmSize = "1L"
                            ElseIf .Item("size").Contains("SGL") Then
                                itmSize = RTrim(.Item("size"))
                            ElseIf .Item("size").Contains("L") Then
                                itmSize = RTrim(.Item("size"))
                            ElseIf .Item("size").Contains("300") Then
                                itmSize = "300mL"
                            ElseIf .Item("size").Contains("375") Then
                                itmSize = "375mL"
                            ElseIf .Item("size").Contains("187") Then
                                itmSize = "187mL"
                            ElseIf .Item("size").Contains("500") Then
                                itmSize = "500mL"
                            ElseIf .Item("size").Contains("720") Then
                                itmSize = "720mL"
                            ElseIf .Item("size").Contains("750") Then
                                itmSize = "750mL"
                            ElseIf .Item("size").Contains("1.5") Then
                                itmSize = "1.5L"
                            ElseIf .Item("size").Contains("1.75") Then
                                itmSize = "1.75L"
                            ElseIf .Item("size").Contains("1.8") Then
                                itmSize = "1.8L"
                            Else
                                itmSize = ""
                            End If

                        End If

                        If itmSizeTitle <> "" Then
                            sName = itmSizeTitle & " " & sName
                        Else
                            sName = sName
                        End If

                        lblItemName.Text = sName
                        lblItem.Text = .Item("item").ToString

                        If itmSize <> "" Then
                            lblSize.Text = "| " & itmSize
                        Else
                            lblSize.Text = ""
                        End If


                        ' *******set info label******************************************************
                        If .Item("iLevel1Type") = 1 Then
                            'sInfo = RTrim(.Item("sColor").ToString) & ", "
                            phColor.Visible = True
                            lnkbColor.Text = RTrim(.Item("sColor").ToString)
                        Else
                            phColor.Visible = False
                        End If
                        If RTrim(.Item("vintage")) <> "" Then
                            'sInfo = RTrim(.Item("vintage").ToString) & ", "
                            phVintage.Visible = True
                            lnkbVintage.Text = RTrim(.Item("vintage").ToString)
                        Else
                            phVintage.Visible = False
                        End If


                        SetUpGrapesLinkForItem(lblItem.Text)
                        If lnkbGrape1.Visible = True Then
                            phGrape.Visible = True
                        Else
                            phGrape.Visible = False
                        End If


                        If RTrim(.Item("sCountry").ToString) <> "" Then
                            'If Len(RTrim(sInfo)) > 1 Then
                            '    sInfo = sInfo & RTrim(.Item("sCountry").ToString)
                            'Else
                            '    sInfo = RTrim(.Item("sCountry").ToString)
                            'End If
                            phCountry.Visible = True
                            lnkbCountry.Text = RTrim(.Item("scountry").ToString)
                        Else
                            phCountry.Visible = False
                        End If

                        If RTrim(.Item("sRegion").ToString) <> "" Then
                            'If Len(RTrim(sInfo)) > 1 Then
                            '    sInfo = sInfo & ", " & RTrim(.Item("sRegion").ToString)
                            'Else
                            '    sInfo = RTrim(.Item("sRegion").ToString)
                            'End If
                            phRegion.Visible = True
                            lnkbRegion.Text = RTrim(.Item("sregion").ToString)
                            If .Item("iLevel1Type") = 3 Then
                                lblLRegion.Text = "Prefecture: "
                            Else
                                lblLRegion.Text = "Region: "
                            End If
                        Else
                            phRegion.Visible = False
                        End If

                        If RTrim(.Item("sSubRegion").ToString) <> "" Then
                            'If Len(RTrim(sInfo)) > 1 Then
                            '    sInfo = sInfo & ", " & RTrim(.Item("sSubRegion").ToString)
                            'Else
                            '    sInfo = RTrim(.Item("sSubRegion").ToString)
                            'End If
                            phSubRegion.Visible = True
                            lnkbSubRegion.Text = RTrim(.Item("ssubregion").ToString)

                        Else
                            phSubRegion.Visible = False
                        End If

                        'Vinyard
                        If RTrim(.Item("sVineyard").ToString) <> "" And RTrim(.Item("newtype").ToString) = "140" Then
                            phVineyard.Visible = True
                            lblVineyard.Text = RTrim(.Item("sVineyard").ToString)

                        Else
                            phVineyard.Visible = False
                        End If

                        'ABV
                        If RTrim(.Item("iAbv").ToString) <> "0.00" Then
                            phABV.Visible = True
                            lblAbv.Text = "ABV: " & RTrim(.Item("iAbv").ToString) & "%"

                        Else
                            phABV.Visible = False
                        End If

                        'Sake Meter Value
                        If .Item("iLevel1Type") = 3 Then
                            phSakeMeterValue.Visible = True
                            lblSakeMeterValue.Text = "Sake Meter Value: " & RTrim(.Item("iSakeMeterValue").ToString)

                        Else
                            phSakeMeterValue.Visible = False
                        End If

                        If RTrim(.Item("sProducer").ToString) <> "" Then
                            phProducer.Visible = True
                            phAboutProducer.Visible = True
                            lnkbProducer.Text = RTrim(.Item("sproducer").ToString)
                            SetProducerInfoForItem(.Item("sProducer").ToString)
                        Else
                            phProducer.Visible = False
                            phAboutProducer.Visible = False
                        End If
                        'lblInfo.Text = sInfo
                        '****************************************************************************************

                        'tasting notes
                        lblDescr.Text = .Item("sdescr").ToString
                        If RTrim(lblDescr.Text) = "" Then
                            tastingNotes.Visible = False
                        End If

                        Dim _bHasNotes As Boolean = False
                        'staff pick notes
                        SetStaffPickInfoForItem(_bHasNotes)



                        If _bHasNotes And Date.Now > #3/30/2013# And Date.Now < #4/1/2013# Then
                            If .Item("iLevel1Type") = 1 Then
                                If Convert.ToString(Convert.ToInt16(((.Item("botprcfl") - .Item("botprc")) / .Item("botprcfl")) * 100)) > 11 Then
                                    If .Item("item").ToString = "27435" Or .Item("item").ToString = "27566" Or .Item("item").ToString = "27365" Or .Item("item").ToString = "25960" Or .Item("item").ToString = "27558" Then
                                        SetEasterEgg(3)
                                    ElseIf .Item("item").ToString = "15931" Or .Item("item").ToString = "27501" Or .Item("item").ToString = "27715" Or .Item("item").ToString = "25369" Or .Item("item").ToString = "15952" Then
                                        SetEasterEgg(2)
                                    Else
                                        SetEasterEgg(1)
                                    End If

                                End If
                            ElseIf .Item("iLevel1Type") = 2 Then
                                If Convert.ToString(Convert.ToInt16(((.Item("botprcfl") - .Item("botprc")) / .Item("botprcfl")) * 100)) > 9 Then
                                    SetEasterEgg(0)
                                End If
                            End If
                        End If

                        'new video embed - Kent 1/21/11
                        'VideoID = "18304599"
                        'VideoID = ""
                        VideoID = .Item("sVideoEmbedContent").ToString()
                        If RTrim(VideoID) = "" Then
                            embedVideo.Visible = False
                        Else
                            vimeoEmbed.Attributes.Add("src", "https://player.vimeo.com/video/" & VideoID & "?title=0&amp;byline=0&amp;portrait=0")
                        End If
                        'GetVideoID("18304599")
                        ' pairing advice
                        lblPairingAdvice.Text = .Item("spairingadvice").ToString
                        If RTrim(lblPairingAdvice.Text) = "" Then
                            pairingAdvice.Visible = False
                        End If

                        '' kosher
                        'If .Item("iLevel1Type") = 1 And .Item("bKosher") = True Then
                        '    kosher.Visible = True
                        'Else
                        '    kosher.Visible = False
                        'End If
                        ' kosher for passover
                        If .Item("iLevel1Type") = 1 And .Item("bKosher") = True Then
                            kosherPassover.Visible = True
                        Else
                            kosherPassover.Visible = False
                        End If

                        'UBC image

                        'iUBC = .Item("sty_cateo")
                        'Select Case iUBC
                        '   Case 0
                        'UBCExcellent.Visible = False
                        'UBCExtraordinary.Visible = False
                        '    Case 1
                        'UBCExcellent.Visible = False
                        'UBCExtraordinary.Visible = True
                        '    Case 2
                        'UBCExcellent.Visible = True
                        'UBCExtraordinary.Visible = False
                        '    Case Else
                        'UBCExcellent.Visible = False
                        'UBCExtraordinary.Visible = False
                        'End Select

                        SetUBCAwardsForItem()

                        'Spirits Check
                        spiritsCheck(.Item("iLevel1Type").ToString)
                        If .Item("iLevel1Type").ToString = 2 Or isCommonCarrierRestricted(.Item("bAstorTruckOnly")) Then
                            imgbAddToCart.OnClientClick = "confirmation(); return false;"
                        End If

                        If isCommonCarrierRestricted(.Item("bAstorTruckOnly")) Then
                            phCommonCarrierRestrictionMsg.Visible = True
                            phCommonCarrierRestrictionModal.Visible = True
                            phSpiritsRestrictionMsg.Visible = False
                            phNYSRestrictionModal.Visible = False
                        Else
                            phCommonCarrierRestrictionMsg.Visible = False
                            phCommonCarrierRestrictionModal.Visible = False
                        End If

                        'Staff Pick
                        'lblStaffPick.Text = .Item("sStaffPick").ToString
                        'If RTrim(lblStaffPick.Text) = "" Then
                        ' staffPick.Visible = False
                        'End If

                        'staff pick
                        'Dim sStaffPickMMYYYY As String
                        'sStaffPickMMYYYY = Date.Now.Month
                        'If Len(sStaffPickMMYYYY) = 1 Then
                        '    sStaffPickMMYYYY = "0" & sStaffPickMMYYYY
                        'End If
                        'sStaffPickMMYYYY = sStaffPickMMYYYY & "/" & Date.Now.Year

                        If Trim(.Item("sstaffpick").ToString) <> "/" Then '= sStaffPickMMYYYY Then
                            phStaffPick.Visible = False
                        Else
                            phStaffPick.Visible = False

                        End If

                        Dim casePriceOriginal As String = String.Empty
                        Dim casePriceSale As String = String.Empty
                        Dim bottlePriceOriginal As String = String.Empty
                        Dim bottlePriceSale As String = String.Empty
                        Dim caseCount As String = String.Empty
                        Dim caseDiscount As String = String.Empty

                        bottlePriceOriginal = .Item("botprcfl").ToString
                        bottlePriceSale = .Item("botprc").ToString
                        caseCount = Convert.ToInt16(.Item("pack")).ToString
                        casePriceOriginal = bottlePriceOriginal * caseCount
                        casePriceSale = .Item("casprc")
                        caseDiscount = Convert.ToString(Convert.ToInt16(((casePriceOriginal - casePriceSale) / casePriceOriginal) * 100))


                        tastingNotes.Visible = Trim(.Item("sdescr")) <> ""

                        litNewBottlePrice.Text = "<div class=""price"">" & "$" & bottlePriceSale & "</div>"
                        litBottleDiscount.Text = "<div class=""save price""><em>You Save: " & Convert.ToString(Convert.ToInt16(((.Item("botprcfl") - .Item("botprc")) / .Item("botprcfl")) * 100)) & "%</em></div>"
                        litNewCasePrice.Text = "<div class=""price dealPrice"">" & "$" & .Item("casprc").ToString & "</div>"
                        litOldCasePrice.Text = "<div class=""wrongPrice price"">" & "$" & casePriceOriginal & "</div>"
                        litCaseLabel.Text = "Case of " & caseCount & ":"
                        litCaseDiscount.Text = "<div class=""save price""><em>You Save: " & caseDiscount & "%</em></div>"

                        If .Item("OnSale").ToString = "On Sale" Then
                            litOldBottlePrice.Visible = True
                            litOldCasePrice.Visible = True
                            'imgOnSale.Visible = True
                            litBottleDiscount.Visible = True
                            litOldBottlePrice.Text = "<div class=""price wrongPrice"">" & "$" & bottlePriceOriginal & "</div>"
                            litNewBottlePrice.Text = "<div class=""price dealPrice"">" & "$" & bottlePriceSale & "</div>"
                        ElseIf caseDiscount = "0" Then
                            litBottleDiscount.Visible = False
                            litCaseDiscount.Visible = False
                            litNewCasePrice.Visible = False
                            litOldCasePrice.Text = "<div class=""price"">" & "$" & casePriceOriginal & "</div>"
                        Else
                            litOldBottlePrice.Visible = False
                            litBottleDiscount.Visible = False
                            litOldBottlePrice.Text = "<div class=""price"">" & "$" & bottlePriceOriginal & "</div>"
                        End If

                        ' special for books and accessories
                        If .Item("iLevel1Type") = 4 Then
                            litBottlepriceLabel.Text = "Item Price:"
                            litCaseLabel.Visible = False
                            litOldCasePrice.Visible = False
                            litNewCasePrice.Visible = False
                            With ddlType
                                .Items.Clear()
                                .Items.Add("Item(s)")
                                .Items(0).Value = "Item"
                            End With
                            If CInt(.Item("iBooksAndAccessoriesType")) = 44 Or CInt(.Item("iBooksAndAccessoriesType")) = 46 Then
                                imgbAddToCart.Visible = False
                                litInStoreOnly.Visible = True
                                ddlType.Visible = False
                                'wneQty.Visible = False
                            End If
                        End If

                        ' special for packs
                        If CBool(.Item("composite")) = True Then
                            litBottlepriceLabel.Text = "Pack Price:"
                            litCaseLabel.Visible = False
                            litOldCasePrice.Visible = False
                            litNewCasePrice.Visible = False
                            With ddlType
                                .Items.Clear()
                                .Items.Add("Pack(s)")
                                .Items(0).Value = "Pack"
                            End With
                        End If

                        ' out of stock/ instock logic
                        If .Item("IsItemAvailable") = "AIS" Then
                            pnlInStock.Visible = True
                            pnlOutOfStock.Visible = False
                            litOutOfStockMsg.Text = ""
                        Else
                            pnlInStock.Visible = False
                            pnlOutOfStock.Visible = True
                            litOutOfStockMsg.Text = outOfStockMsg
                            WaitLink.Text = "<a href='AstorWaitList.aspx?item=" + .Item("item") + "&email=" + Email + "&height=300&width=400' rel='modal:open' >YES, Notify Me</a>"

                        End If

                        'Limited Production:  Only X bottle(s) per customer
                        If Convert.ToInt16(.Item("Allocated")) > 0 Then
                            lblLimitedQty.Visible = True
                            lblLimitedQty.Text = "<li>" & "Limited Production:  Only " & .Item("Allocated").ToString & " bottle(s) per customer" & "</li>"
                            litCaseLabel.Visible = False
                            litOldCasePrice.Visible = False
                            litNewCasePrice.Visible = False
                            With ddlType
                                .Items.Clear()
                                .Items.Add("Bottle(s)")
                                .Items(0).Value = "Bottle"
                            End With
                            'wneQty.MaxValue = Convert.ToInt16(.Item("Allocated"))

                        Else
                            lblLimitedQty.Visible = False
                        End If

                        'wine tasting link set up
                        GetTastingForItem(.Item("item").ToString)
                        'wine club link set up
                        GetWineClubForItem(.Item("item").ToString)
                        'astor center link set up
                        GetAstorCenterClassForItem(.Item("item").ToString)

                        Dim sFilePath As String
                        sFilePath = System.Web.HttpContext.Current.Server.MapPath("~/images/itemimages/")

                        'Share & Social
                        'litShare.Text = .Item("item").ToString

                        'thumbnails

                        If File.Exists(sFilePath & "lbl/" & .Item("item").ToString & "_lbl.jpg") Then
                            thumb1.ImageUrl = "~/images/itemimages/lbl/" & .Item("item").ToString & "_lbl.jpg"
                            thumb1.Style("border") = "1px solid #dddddd"
                            thumb1.Style("padding") = "2px"
                            thumb1.Style("margin-left") = "0px"
                            'thumb1Lnk.Text = "<a rel=""modal:open"" href=""images/itemimages/lbl/" & .Item("item").ToString & "_lbl.jpg"" >"
                            thumb1Lnk.Text = "<a rel=""modal:open"" href=""#thumb1box"" >"
                            thumb1LnkEnd.Text = "</a>"
                            litThumb1Img.Text = "<img src=""images/itemimages/lbl/" & .Item("item").ToString & "_lbl.jpg"" style=""display:none;z-index:500;"" id=""thumb1box"" />"
                        Else
                            thumb1Holder.Visible = False
                        End If

                        If File.Exists(sFilePath & "hr/" & .Item("item").ToString & "_hr.jpg") Then
                            thumb2.ImageUrl = "~/images/itemimages/hr/" & .Item("item").ToString & "_hr.jpg"
                            thumb2.Style("border") = "1px solid #dddddd"
                            thumb2.Style("padding") = "2px"
                            thumb2Lnk.Text = "<a rel=""modal:open"" href=""#thumb2box"">"
                            thumb2LnkEnd.Text = "</a>"
                            litThumb2Img.Text = "<img src=""images/itemimages/hr/" & .Item("item").ToString & "_hr.jpg"" style=""display:none;z-index:500;"" id=""thumb2box"" />"
                        Else
                            thumb2Holder.Visible = False
                        End If

                        If File.Exists(sFilePath & "alt/" & .Item("item").ToString & "_alt.jpg") Then
                            thumb3.ImageUrl = "~/images/itemimages/alt/" & .Item("item").ToString & "_alt.jpg"
                            thumb3.Style("border") = "1px solid #dddddd"
                            thumb3.Style("padding") = "2px"
                            thumb3Lnk.Text = "<a rel=""modal:open"" href=""thumb3box"" >"
                            thumb3LnkEnd.Text = "</a>"
                            litThumb3Img.Text = "<img src=""images/itemimages/alt/" & .Item("item").ToString & "_alt.jpg"" style=""display:none;z-index:500;"" id=""thumb3box"" />"
                        Else
                            thumb3Holder.Visible = False
                        End If

                        If File.Exists(sFilePath & "lg/" & .Item("item").ToString & "_lg.jpg") Then
                            imgItemPic.ImageUrl = "~/images/itemimages/lg/" & .Item("item").ToString & "_lg.jpg"
                        ElseIf File.Exists(sFilePath & "lg/" & .Item("item").ToString & "_lg.gif") Then
                            imgItemPic.ImageUrl = "~/images/itemimages/lg/" & .Item("item").ToString & "_lg.gif"
                        Else
                            If .Item("iLevel1Type") = 1 Then


                                'WHITE WINE GENERIC
                                If .Item("scolor") = "White" And .Item("bsparkling") = False And .Item("ifortified") = 0 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/whitewinegeneric_lg.gif"

                                    'RED WINE GENERIC
                                ElseIf .Item("scolor") = "Red" And .Item("bsparkling") = False And .Item("ifortified") = 0 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/redwinegeneric_lg.gif"
                                    ' amber wine generic
                                ElseIf .Item("scolor") = "Amber" And .Item("bsparkling") = False And .Item("ifortified") = 0 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/fortifiedgeneric_lg.gif"

                                    'ROSE WINE GENERIC
                                ElseIf .Item("scolor") = "Rosé" And .Item("bsparkling") = False And .Item("ifortified") = 0 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/rosewinegeneric_lg.gif"

                                    'CHAMPANGE GENERIC
                                ElseIf RTrim(.Item("scountry")) = "France" And RTrim(.Item("sregion")) = "Champagne" And .Item("bsparkling") = True Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/champagnegeneric_lg.gif"

                                    'SPARKLING WINE GENERIC
                                ElseIf RTrim(.Item("scountry")) <> "France" And RTrim(.Item("sregion")) <> "Champagne" And .Item("bsparkling") = True And .Item("scolor") = "White" Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/sparklingwinegeneric_lg.gif"
                                    'SPARKLING RED GENERIC
                                ElseIf RTrim(.Item("scountry")) <> "France" And RTrim(.Item("sregion")) <> "Champagne" And .Item("bsparkling") = True And .Item("scolor") = "Red" Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/sparklingredgeneric_lg.gif"

                                    'SPARKLING ROSE GENERIC
                                ElseIf .Item("scolor") = "Rosé" And .Item("bsparkling") = True And .Item("ifortified") = 0 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/sparklingrosegeneric_lg.gif"

                                ElseIf .Item("scolor") = "White" And .Item("ifortified") = 6 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/whitewinegeneric_lg.gif"
                                    'FORTIFIED GENERIC
                                ElseIf .Item("ifortified") > 0 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/fortifiedgeneric_lg.gif"
                                Else
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/NoImageAvailable.gif"
                                End If

                                'for the spirits, it's all just based on type (level 1 or 2) and should be self explanatory.
                            ElseIf .Item("iLevel1Type") = 2 Then
                                If .Item("iLiquorLevel2Type") = 25 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/armagnacgeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel2Type") = 27 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/cognacgeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel2Type") = 30 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/piscogeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel2Type") = 26 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/calvadosgeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel2Type") = 28 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/eaudevie_lg.gif"
                                ElseIf .Item("iLiquorLevel2Type") = 29 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/grappa_lg.gif"
                                ElseIf .Item("iLiquorLevel1Type") = 17 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/brandydejerezgeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel1Type") = 50 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/vermouthsaperitifsdigestifsgeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel1Type") = 22 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/rumgeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel1Type") = 18 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/whiskeygeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel1Type") = 19 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/gingeneric_lg.gif"
                                ElseIf .Item("iLiquorLevel1Type") = 20 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/vodkageneric_lg.gif"
                                ElseIf .Item("iLiquorLevel1Type") = 21 Then
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/tequilagenereic_lg.gif"
                                Else
                                    imgItemPic.ImageUrl = "~/images/itemimages/lg/liqueursgeneric_lg.gif"
                                End If
                            ElseIf .Item("iLevel1Type") = 3 Then
                                imgItemPic.ImageUrl = "~/images/itemimages/lg/sakegeneric_lg.gif"
                            Else

                                imgItemPic.ImageUrl = "~/images/itemimages/lg/NoImageAvailable.gif"
                            End If

                        End If
                    End With
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadResultSimpleDataList()

        'Dim _odata As New cAstorWebData(getConnStr())
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _oAstorCommon As New cAstorCommon
        Dim _oWebCommon As New WebPageBase
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim sSearchString As String = RTrim(CStr(Session.Item("queryValue")))
        Dim sSearchType As String = RTrim(CStr(Session.Item("queryType")))
        Dim bAllwords As Boolean = False
        Dim sWord1 As String = String.Empty
        Dim sWord2 As String = String.Empty
        Dim sWord3 As String = String.Empty
        Dim sWord4 As String = String.Empty
        Dim sWord5 As String = String.Empty
        Dim queryParam As String()
        Dim iQty As Int16 = 1

        Try

            Session.Add("SS", sSearchString)
            If Len(sSearchString) = 5 And IsNumeric(sSearchString) Then
                '_oAstorCommon.ProcessDirectHashtable(sSearchString, "", "", "", "", "", "", 1, "", "")
                dsLocal = _odata.FindItem(sSearchString, "", False, "", "", "", "", "", iQty, "R", _oWebCommon.GetCustomerID(Request, Response))
            Else
                ' runsmartsearch set up for up to 5 words only
                If sSearchString <> "" Then
                    queryParam = _odata.RunSmartSearch(sSearchString)

                    bAllwords = True
                    sWord1 = queryParam(0)
                    sWord2 = queryParam(1)
                    sWord3 = queryParam(2)
                    sWord4 = queryParam(3)
                    sWord5 = queryParam(4)

                End If

                Select Case sSearchType
                    Case "Contains"
                        sSearchString = "%" & sSearchString & "%"
                    Case "Starts with"
                        sSearchString = sSearchString & "%"
                End Select


                dsLocal = _odata.FindItem("", sSearchString, True, sWord1, sWord2, sWord3, sWord4, sWord5, iQty, "R", _oWebCommon.GetCustomerID(Request, Response))
            End If
            Session("DSSingle") = dsLocal
            Session("queryType") = Nothing
            Session("queryValue") = Nothing

            If dsLocal.Tables(0).Rows.Count <> 1 Then
                'Redirect("SearchError.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/SearchError.aspx?item=" & sSearchString)
            End If
            Dim prvItem1 As String = Session("prvItem1")
            Dim prvItem2 As String = Session("prvItem2")
            Dim prvItem3 As String = Session("prvItem3")

            If Request.QueryString("search") <> prvItem1 Then
                If prvItem2 <> Nothing Then
                    Session("prvItem3") = prvItem2
                    Session("prvItem2") = prvItem1
                Else
                    If prvItem1 <> Nothing Then
                        Session("prvItem2") = prvItem1
                    End If
                End If
                If IsNumeric(Request.QueryString("search")) Then
                    Session("prvItem1") = dsLocal.Tables(0).Rows(0).Item("item").ToString
                End If
            End If

            Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
            sSearchTypeShow = dsLocal.Tables(0).Rows(0).Item("iLevel1Type").ToString

        Catch ex As Exception
            Throw ex
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
            Case "Color"
                sColor = sValue
            Case "Vintage"
                sVintageLow = sValue
            Case "Grape"
                sGrape = sValue
            Case "Country"
                sCountry = sValue
            Case "Region"
                sCountry = lnkbCountry.Text
                sRegion = sValue
            Case "SubRegion"
                sCountry = lnkbCountry.Text
                sRegion = lnkbRegion.Text
                sSubRegion = sValue
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

    Protected Sub imgbAddToCart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbAddToCart.Click
        'Dim intTxt As Integer
        'Dim sOrderType As String
        'Dim sItem As String
        'Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        'Dim iLevel1Type As String

        'intTxt = wneQty.Value
        'sOrderType = ddlType.SelectedValue
        'sItem = lblItem.Text

        'Dim strUrl As String = Request.Url.ToString()
        'Session("ReturnUrl") = strUrl
        'Response.Redirect("/ShoppingCart.aspx?Item=" & RTrim(sItem) & "&Type=" & RTrim(sOrderType) & "&Quantity=" + RTrim(intTxt.ToString))

        'iLevel1Type = Convert.ToInt16(Request.QueryString("p"))

        'If iLevel1Type = 2 Then
        '    Dim confirm As DialogResult
        '    confirm = MessageBox.Show("At this time this item can only be shipped to Brooklyn, Queens, Manhattan.", "Item Notes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        '    If confirm = MsgBoxResult.Ok Then
        '        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
        '            'Dim strUrl As String = Request.Url.ToString()
        '            Session("ReturnUrl") = ReturnUrl.Value
        '            Session("ShoppingCartAddError") = "Add Error"
        '            Response.Redirect("~/ShoppingCart.aspx")
        '        Else
        '            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
        '            Session("ReturnUrl") = ReturnUrl.Value
        '            Response.Redirect("~/ShoppingCart.aspx")
        '        End If
        '    End If
        'Else
        '    If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
        '        'Dim strUrl As String = Request.Url.ToString()
        '        Session("ReturnUrl") = ReturnUrl.Value
        '        Session("ShoppingCartAddError") = "Add Error"
        '        Response.Redirect("~/ShoppingCart.aspx")
        '    Else
        '        cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
        '        Session("ReturnUrl") = ReturnUrl.Value
        '        Response.Redirect("~/ShoppingCart.aspx")
        '    End If
        'End If

        addToCart()

    End Sub

    Protected Sub lnkbColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbColor.Click
        ProcessTagClick("Color", sender.text)
    End Sub

    Protected Sub lnkbVintage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbVintage.Click
        ProcessTagClick("Vintage", sender.text)
    End Sub

    Protected Sub lnkbGrape1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbGrape1.Click, lnkbGrape2.Click, lnkbGrape3.Click, lnkbGrape4.Click, lnkbGrape5.Click
        ProcessTagClick("Grape", sender.text)
    End Sub

    Protected Sub lnkbCountry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbCountry.Click
        ProcessTagClick("Country", sender.text)
    End Sub

    Protected Sub lnkbRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbRegion.Click
        ProcessTagClick("Region", sender.text)
    End Sub

    Protected Sub lnkbSubRegion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbSubRegion.Click
        ProcessTagClick("SubRegion", sender.text)
    End Sub

    Protected Sub lnkbProducer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbProducer.Click
        ProcessTagClick("Producer", sender.text)
    End Sub

    'Sub ChoosePricingDisplay()

    '    pnlInStock.Visible = True
    '    pnlOutOfStock.Visible = True

    '    'Out of Stock Messages
    '    Dim outOfStockMsg As String = "This item is currently out of stock."
    '    Dim preOrderMsg As String = "This item is expected to arrive soon."
    '    Dim reorderMsg As String = "This is expected to be back in stock soon."

    '    litOutOfStockMsg.Text = outOfStockMsg

    'End Sub

    Sub SetShareParams()

    End Sub

    Sub SetEasterEgg(ByVal easterEgg As Integer)
        Select Case easterEgg
            Case 0
                imgEasterEgg.ImageUrl = "../images/holiday/egg10.jpg"
            Case 1
                imgEasterEgg.ImageUrl = "../images/holiday/egg20.jpg"
            Case 2
                imgEasterEgg.ImageUrl = "../images/holiday/egg30.jpg"
            Case 3
                imgEasterEgg.ImageUrl = "../images/holiday/egg40.jpg"
        End Select
        imgEasterEgg.Visible = True
    End Sub

    Sub spiritsCheck(ByVal iLevel1Type As String)

        Dim shippingFlag As Boolean

        If iLevel1Type = "2" Then
            shippingFlag = True
            imgbAddToCart.OnClientClick = "confirmation(); return false;"
        Else
            shippingFlag = False
        End If

        If shippingFlag Then
            phItemNotes.Visible = True
        Else
            phItemNotes.Visible = False
        End If

    End Sub

    Public Function isCommonCarrierRestricted(ByVal flag As Boolean) As Boolean
        If flag Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub addToCart()
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim sItem As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())

        intTxt = wneQty.Value
        sOrderType = ddlType.SelectedValue
        sItem = lblItem.Text

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            'Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = ReturnUrl.Value
            Session("ShoppingCartAddError") = "Add Error"
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = ReturnUrl.Value
            Response.Redirect("~/ShoppingCart.aspx")
        End If

    End Sub

End Class
