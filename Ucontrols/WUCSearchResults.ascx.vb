Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
Imports Infragistics.WebUI.WebDataInput
'Imports SslTools
Partial Class Ucontrols_WUCSearchResults
    Inherits System.Web.UI.UserControl
    Private intTxt As Int16
    Private sOrderType As String
    Private sItem As String
    Private iResultCount As Int16
    Private email As String = String.Empty
    Public Property CurrentPage() As Integer
        Get
            ' look for current page in ViewState
            Dim o As Object = Me.ViewState("_CurrentPage")
            If o Is Nothing Then
                Return 0 ' default page index of 0
            Else
                Return CInt(o)
            End If
        End Get
        Set(ByVal Value As Integer)
            Me.ViewState("_CurrentPage") = value
        End Set
    End Property
    Public Property ResultCount() As Int16
        Get
            Return iResultCount
        End Get
        Set(ByVal value As Int16)
            iResultCount = value
        End Set
    End Property
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        'TextBox1.Text = CStr(Session.Item("queryValue"))

        Session("ReturnUrlModal") = Request.Url.AbsolutePath & Request.Url.Query

        If Not IsPostBack Then
            Dim dsn As String = WebAppConfig.ConnectString
            Dim _oAstorCommon As New cAstorCommon
            Dim _odata As New cAstorWebData(dsn)
            Dim _oWebCommon As New WebPageBase
            'Dim dsLocal As DataSet
            Dim hstQuery As New Hashtable
            Dim mstrPageName As String = String.Empty
            mstrPageName = Replace(Page.ToString.ToLower, "_aspx", ".aspx")

            If mstrPageName = "asp.specialpacks.aspx" Then
                phSearchHelp.Visible = False
            Else
                phSearchHelp.Visible = True
            End If
            ' tuesday page sets dataset on its own
            If mstrPageName <> "asp.astortuesdays.aspx" And mstrPageName <> "asp.tuesdaysale.aspx" And mstrPageName <> "asp.winesonsale.aspx" And mstrPageName <> "asp.newarrivals.aspx" And mstrPageName <> "asp.features.aspx" And mstrPageName <> "asp.specialpacks.aspx" Then


                ' removed ekm
                'If Not Session("SearchParms") Is Nothing Then
                hstQuery = _oAstorCommon.ProcessQueryStrings(Request.QueryString)

                Session("SearchParms") = hstQuery
                Session("DSMulti") = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))

                Dim searchTermWhole As String = String.Empty
                With hstQuery
                    If RTrim(.Item("Word1")) <> "" Then
                        searchTermWhole &= RTrim(.Item("Word1"))
                    End If
                    If RTrim(.Item("Word2")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word2"))
                    End If
                    If RTrim(.Item("Word3")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word3"))
                    End If
                    If RTrim(.Item("Word4")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word4"))
                    End If
                    If RTrim(.Item("Word5")) <> "" Then
                        searchTermWhole &= " " & RTrim(.Item("Word5"))
                    End If
                End With
                Session("wholeString") = searchTermWhole
            End If
            'Else
            '    Redirect("~/default.aspx", RedirectOptions.AbsoluteHttp)
            'End If
            BindResultDataList()
            Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = strUrl

            If Context.User.Identity.Name <> "" Then
                email = Context.User.Identity.Name
            Else
                email = ""
            End If

        End If
        searchHelp.wholestring = Session("wholeString")
    End Sub

    Private Sub BindResultDataList()
        Try
            'Dim objPds As New PagedDataSource
            Dim oDS As New DataSet
            Dim oDV As New DataView

            If Not Session("DSMulti") Is Nothing Then


                oDS = Session("DSMulti")
                oDV.Table = oDS.Tables(0)
                'iResultCount = oDV.Count
                If Not Session("sort") Is Nothing Then
                    ddlSearchSort.SelectedIndex = Session("sort")
                End If
                Select Case ddlSearchSort.SelectedIndex

                    Case 0 'price(ascending)
                        'oDV.Sort = "botprc asc"
                    Case 1 '   name(alphabetical)
                        oDV.Sort = "name"
                        'Case 2 'price(ascending)
                        '    oDV.Sort = "botprc asc"
                    Case 2  'price(descending)
                        oDV.Sort = "botprc desc"
                    Case 3   'vintage()
                        oDV.Sort = "vintage"
                    Case 4   'popularity (i.e. 30 day usage)
                        oDV.Sort = "IsItemAvailable asc, usage30 desc"
                End Select

                colpagSearchResults.DataSource = oDV
                colpagSearchResults2.DataSource = oDV
                colpagSearchResults3.DataSource = oDV
                colpagSearchResults4.DataSource = oDV

                If Not Session("pagesize") Is Nothing Then
                    ddlPageSize.SelectedIndex = Session("pagesize")
                End If

                colpagSearchResults.PageSize = ddlPageSize.SelectedValue
                colpagSearchResults2.PageSize = ddlPageSize.SelectedValue
                colpagSearchResults3.PageSize = ddlPageSize.SelectedValue
                colpagSearchResults4.PageSize = ddlPageSize.SelectedValue
                'Let the Pager know what Control it needs to DataBind during the PreRender.

                colpagSearchResults.BindToControl = datResults
                'The Control now takes the object you are binding to,
                'instead of the name of it (as a string) 

                'Set the DataSource of the Repeater to the PagedData coming from the Pager. 
                datResults.DataSource = colpagSearchResults.DataSourcePaged


                'datResults.DataSource = Session("DS")
                datResults.DataBind()
                'lblSearchValues.Text = " " & Session.Item("SS").ToString & " "
                'lblSearchValues.Text = " " & RTrim(CStr(Session.Item("queryValue"))) & " "
            Else
                'Redirect("~/default.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/default.aspx")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Protected Sub datResults_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datResults.ItemCommand
        Dim qty As WebNumericEdit
        Dim cart As New AstorwinesCommerce.CartDB(WebAppConfig.ConnectString)
        Dim _oWebCommon As New WebPageBase

        Try
            Select Case e.CommandSource.id
                Case "imgbWaitList"
                    'Dim item As ImageButton
                    'item = CType(e.Item.FindControl("imgbAddToCart"), ImageButton)
                    'sItem = item.CommandArgument
                    'e.Item.FindControl("txtWaitEmail").Visible = True
                    'cart.AddShoppingCartAOSItem(_oWebCommon.GetCustomerID(Request, Response), sItem)
                    'Dim strUrl As String = Request.Url.ToString()
                    ''Session("ReturnUrl") = strUrl
                    ''Response.Redirect("~/ShoppingCart.aspx")

                    'Dim sPage As String = Page.Request.RawUrl.ToString()
                    'Response.Redirect(sPage)

                Case "imgbAddToCart"
                    qty = e.Item.FindControl("wneQty")
                    intTxt = qty.Value

                    Dim type As DropDownList
                    type = CType(e.Item.FindControl("ddltype"), DropDownList)
                    sOrderType = type.SelectedValue

                    Dim item As ImageButton
                    item = CType(e.Item.FindControl("imgbAddToCart"), ImageButton)
                    sItem = item.CommandArgument
                    'Dim strUrl As String = Request.Url.ToString()
                    'Session("ReturnUrl") = strUrl
                    'Response.Redirect("/ShoppingCart.aspx?Item=" & RTrim(sItem) & "&Type=" & RTrim(sOrderType) & "&Quantity=" + RTrim(intTxt.ToString))

                    If cart.CheckCartForWineClub(_oWebCommon.GetCustomerID(Request, Response), sItem) Then
                        Dim strUrl As String = Request.Url.ToString()
                        Session("ReturnUrl") = strUrl
                        Session("ShoppingCartAddError") = "Add Error"
                        'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                        Response.Redirect("~/ShoppingCart.aspx")
                    Else
                        cart.AddShoppingCartItem(_oWebCommon.GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
                        Dim strUrl As String = Request.Url.ToString()
                        Session("ReturnUrl") = strUrl
                        'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                        Response.Redirect("~/ShoppingCart.aspx")
                    End If

            End Select

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Protected Sub datResults_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datResults.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow
            Dim iLevel1Type As Int16
            Dim sInfo As String = String.Empty
            'Out of Stock Messages
            Dim outOfStockMsg As String = "This item is currently out of stock."
            Dim preOrderMsg As String = "This item is expected to arrive soon."
            Dim reorderMsg As String = "This is expected to be back in stock soon."

            myRowView = e.Item.DataItem
            myRow = myRowView.Row
            iLevel1Type = myRow("iLevel1Type")

            'Pricing
            Dim bottlePriceOriginal As String = String.Empty
            Dim bottlePriceSale As String = String.Empty
            Dim casePriceOriginal As String = String.Empty
            Dim casePriceSale As String = String.Empty
            Dim caseCount As String = String.Empty
            Dim caseDiscount As String = String.Empty

            bottlePriceOriginal = myRow("botprcfl").ToString
            bottlePriceSale = myRow("botprc").ToString
            caseCount = Convert.ToInt16(myRow("pack")).ToString
            casePriceOriginal = bottlePriceOriginal * caseCount
            casePriceSale = myRow("casprc")
            caseDiscount = Convert.ToString(Convert.ToInt16(((casePriceOriginal - casePriceSale) / casePriceOriginal) * 100))

            '<%# "$"&rtrim(databinder.eval(container.dataitem, "casprcfl")) %>

            If myRow("OnSale").ToString = "On Sale" Then
                ' e.Item.FindControl("imgOnSale").Visible = True
                e.Item.FindControl("lblOldBottlePrice").Visible = True
                e.Item.FindControl("lblOldCasePrice").Visible = True
                CType(e.Item.FindControl("lblNewCasePrice"), Label).CssClass = "dealPrice"
                CType(e.Item.FindControl("lblNewBottlePrice"), Label).CssClass = "dealPrice"
                CType(e.Item.FindControl("lblYouSave"), Label).Text = "You Save: " & Convert.ToString(Convert.ToInt16(((myRow("botprcfl") - myRow("botprc")) / myRow("botprcfl")) * 100)) & "%"
                e.Item.FindControl("lblYouSave").Visible = True
            ElseIf caseDiscount = "0" Then
                e.Item.FindControl("litCaseDiscount").Visible = False
                e.Item.FindControl("lblOldCasePrice").Visible = False
            Else
                e.Item.FindControl("lblOldBottlePrice").Visible = False
                e.Item.FindControl("lblYouSave").Visible = False
            End If

            CType(e.Item.FindControl("lblOldCasePrice"), Label).Text = "$" & casePriceOriginal
            CType(e.Item.FindControl("lblCaseLabel"), Literal).Text = "Case of " & caseCount & ":"
            CType(e.Item.FindControl("litCaseDiscount"), Literal).Text = "You Save: " & caseDiscount & "%"


            'In-Stock/Out of Stock
            If myRow("IsItemAvailable").ToString() = "AIS" Then
                e.Item.FindControl("pnlInStock").Visible = True
                e.Item.FindControl("pnlOutOfStock").Visible = False
                CType(e.Item.FindControl("litOutOfStockMsg"), Literal).Text = ""
            Else
                e.Item.FindControl("pnlInStock").Visible = False
                e.Item.FindControl("pnlOutOfStock").Visible = True
                CType(e.Item.FindControl("litOutOfStockMsg"), Literal).Text = outOfStockMsg
                CType(e.Item.FindControl("WaitLink"), Literal).Text = "<a href='AstorWaitList.aspx?item=" + myRow("item") + "&email=" + email + "&height=300&width=200' rel='modal:open' >Notify Me</a>"
            End If

            CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage")

            'ITEM SIZE

            Dim itmSize As String = String.Empty
            Dim itmTitle As String = String.Empty

            If myRow("size").ToString = "" Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage")
            ElseIf myRow("size").ToString.Contains("SGL") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage") & " " & myRow("size")
                itmSize = " | " & myRow("size")
            ElseIf myRow("size").ToString.Contains("50") Then
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("150") Then
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("180") Then
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("200") Then
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("250") Then
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("300") Then
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("375") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage")
                itmSize = " | " & myRow("size") & "mL"
                itmTitle = "Half-Bottle of "
            ElseIf myRow("size").ToString.Contains("187") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage")
                itmSize = " | " & myRow("size") & "mL"
                itmTitle = "Split-Bottle of "
            ElseIf myRow("size").ToString.Contains("500") Then
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("720") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage") & " " & myRow("size") & "mL"
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("750") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage") & " " & myRow("size") & "mL"
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("900") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage") & " " & myRow("size") & "mL"
                itmSize = " | " & myRow("size") & "mL"
            ElseIf myRow("size").ToString.Contains("LTR") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage") & " 1L"
                itmSize = " | " & "1L"
            ElseIf myRow("size").ToString.Contains("1.5") Then
                'CType(e.Item.FindControl("itemName"), Literal).Text = myRow("name") & " - " & myRow("vintage") & " " & myRow("size") & "L"
                itmSize = " | " & myRow("size") & "L"
            ElseIf myRow("size").ToString.Contains("1.75") Then
                itmSize = " | " & myRow("size") & "L"
            ElseIf myRow("size").ToString.Contains("1.8") Then
                itmSize = " | " & myRow("size") & "L"
            ElseIf myRow("size").ToString.Contains("2L") Then
                itmSize = " | " & "(2)L"
            ElseIf myRow("size").ToString.Contains("3L") Then
                itmSize = " | " & "(3)L"
            ElseIf myRow("size").ToString.Contains("4L") Then
                itmSize = " | " & "(4)L"
            ElseIf myRow("size").ToString.Contains("5L") Then
                itmSize = " | " & "(5)L"
            Else
                CType(e.Item.FindControl("itemName"), Literal).Text = itmTitle & myRow("name") & " - " & myRow("vintage")
            End If

            CType(e.Item.FindControl("itemName"), Literal).Text = itmTitle & myRow("name") & " - " & myRow("vintage")

            'VIDEO ICON
            If myRow("Video").ToString = "1" Then
                e.Item.FindControl("imgVideo").Visible = True
            Else
                e.Item.FindControl("imgVideo").Visible = False
            End If

            'PAIRING ICON
            If myRow("Pairing").ToString = "1" Then
                e.Item.FindControl("imgPairing").Visible = True
            Else
                e.Item.FindControl("imgPairing").Visible = False
            End If

            'STAFF PICK ICON
            If myRow("sStaffPick").ToString = "/" Then
                e.Item.FindControl("imgStaffPick").Visible = False
            Else
                e.Item.FindControl("imgStaffPick").Visible = True
            End If

            If CInt(myRow("incart")) > 0 Then
                If CBool(myRow("composite")) = True Then
                    CType(e.Item.FindControl("lblInCart"), Literal).Text = "You currently have " & myRow("incart").ToString & " pack(s) in your cart"
                Else
                    CType(e.Item.FindControl("lblInCart"), Literal).Text = "You currently have " & myRow("incart").ToString & " bottle(s) in your cart"
                End If
                e.Item.FindControl("imgInCart").Visible = True
                e.Item.FindControl("lblInCart").Visible = True
            Else
                e.Item.FindControl("imgInCart").Visible = False
                e.Item.FindControl("lblInCart").Visible = False
            End If

            'Limited Production:  Only X bottle(s) per customer
            If CInt(myRow("Allocated")) > 0 Then
                e.Item.FindControl("lblLimitedQty").Visible = True
                CType(e.Item.FindControl("lblLimitedQty"), Label).Text = "Limited Production:  Only " & myRow("Allocated").ToString & " bottle(s) per customer"
                e.Item.FindControl("lblCaseLabel").Visible = False
                '    e.Item.FindControl("lblOldCasePrice").Visible = False
                e.Item.FindControl("lblNewCasePrice").Visible = False
                CType(e.Item.FindControl("wneQty"), WebNumericEdit).MaxValue = Convert.ToInt16(myRow("Allocated"))
                CType(e.Item.FindControl("ddlType"), DropDownList).Items.Clear()
                CType(e.Item.FindControl("ddlType"), DropDownList).Items.Add("Bottle(s)")
                CType(e.Item.FindControl("ddlType"), DropDownList).Items(0).Value = "Bottle"
            Else
                e.Item.FindControl("lblLimitedQty").Visible = False
            End If

            If iLevel1Type = 4 Then
                CType(e.Item.FindControl("lblBottlePriceLabel"), Literal).Text = "Item Price:"
                e.Item.FindControl("lblCaseLabel").Visible = False
                '   e.Item.FindControl("lblOldCasePrice").Visible = False
                e.Item.FindControl("lblNewCasePrice").Visible = False
                CType(e.Item.FindControl("ddlType"), DropDownList).Items.Clear()
                CType(e.Item.FindControl("ddlType"), DropDownList).Items.Add("Item(s)")
                CType(e.Item.FindControl("ddlType"), DropDownList).Items(0).Value = "Item"
                If CInt(myRow("iBooksAndAccessoriesType")) = 44 Or CInt(myRow("iBooksAndAccessoriesType")) = 46 Then
                    e.Item.FindControl("imgbAddToCart").Visible = False
                    e.Item.FindControl("lblInStoreOnly").Visible = True
                    e.Item.FindControl("ddlType").Visible = False
                    'e.Item.FindControl("lblQty").Visible = False
                    e.Item.FindControl("wneQty").Visible = False
                End If
            End If
            If CBool(myRow("composite")) = True Then
                CType(e.Item.FindControl("lblBottlePriceLabel"), Literal).Text = "Pack Price:"
                e.Item.FindControl("lblCaseLabel").Visible = False
                '    e.Item.FindControl("lblOldCasePrice").Visible = False
                e.Item.FindControl("lblNewCasePrice").Visible = False
                CType(e.Item.FindControl("ddlType"), DropDownList).Items.Clear()
                CType(e.Item.FindControl("ddlType"), DropDownList).Items.Add("Pack(s)")
                CType(e.Item.FindControl("ddlType"), DropDownList).Items(0).Value = "Pack"
                CType(e.Item.FindControl("hyplItemPic"), HyperLink).NavigateUrl = "~/SpecialPacks.aspx?packitem=" + myRow("Item").ToString()
                CType(e.Item.FindControl("hyplItemName"), HyperLink).NavigateUrl = "~/SpecialPacks.aspx?packitem=" + myRow("Item").ToString()
            Else
                CType(e.Item.FindControl("hyplItemPic"), HyperLink).NavigateUrl = "~/SearchResultsSingle.aspx?p=" + iLevel1Type.ToString + "&search=" + myRow("Item").ToString() + "&searchtype=Contains"
                CType(e.Item.FindControl("hyplItemName"), HyperLink).NavigateUrl = "~/SearchResultsSingle.aspx?p=" + iLevel1Type.ToString + "&search=" + myRow("Item").ToString() + "&searchtype=Contains"

            End If

            ' set info label
            If iLevel1Type = 1 Then
                sInfo = RTrim(myRow("sColor").ToString) & "  | "
            End If
            If RTrim(myRow("sCountry").ToString) <> "" Then
                If Len(RTrim(sInfo)) > 1 Then
                    sInfo = sInfo & RTrim(myRow("sCountry").ToString)
                Else
                    sInfo = RTrim(myRow("sCountry").ToString)
                End If
            End If
            If RTrim(myRow("sRegion").ToString) <> "" Then
                If Len(RTrim(sInfo)) > 1 Then
                    sInfo = sInfo & ", " & RTrim(myRow("sRegion").ToString)
                Else
                    sInfo = RTrim(myRow("sRegion").ToString)
                End If
            End If
            If RTrim(myRow("sSubRegion").ToString) <> "" Then
                If Len(RTrim(sInfo)) > 1 Then
                    sInfo = sInfo & ", " & RTrim(myRow("sSubRegion").ToString)
                Else
                    sInfo = RTrim(myRow("sSubRegion").ToString)
                End If
            End If
            CType(e.Item.FindControl("lblMisc"), Literal).Text = sInfo & itmSize

            Dim sFilePath As String
            sFilePath = System.Web.HttpContext.Current.Server.MapPath("~/images/itemimages/sm/")

            If File.Exists(sFilePath & myRow("item").ToString & "_sm.jpg") Then
                CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/" & myRow("item").ToString & "_sm.jpg"
            ElseIf File.Exists(sFilePath & myRow("item").ToString & "_sm.gif") Then
                CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/" & myRow("Item").ToString() & "_sm.gif"
            Else
                If iLevel1Type = 1 Then


                    'WHITE WINE GENERIC
                    If myRow("scolor") = "White" And myRow("bsparkling") = False And myRow("ifortified") = 0 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/whitewinegeneric_sm.gif"

                        'RED WINE GENERIC
                    ElseIf myRow("scolor") = "Red" And myRow("bsparkling") = False And myRow("ifortified") = 0 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/redwinegeneric_sm.gif"

                        'AMBER WINE GENERIC
                    ElseIf myRow("scolor") = "Amber" And myRow("bsparkling") = False And myRow("ifortified") = 0 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/fortifiedgeneric_sm.gif"

                        'ROSE WINE GENERIC
                    ElseIf myRow("scolor") = "Rosé" And myRow("bsparkling") = False And myRow("ifortified") = 0 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/rosewinegeneric_sm.gif"

                        'CHAMPANGE GENERIC
                    ElseIf RTrim(myRow("scountry")) = "France" And RTrim(myRow("sregion")) = "Champagne" And myRow("bsparkling") = True Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/champagnegeneric_sm.gif"

                        'SPARKLING WINE GENERIC
                    ElseIf RTrim(myRow("scountry")) <> "France" And RTrim(myRow("sregion")) <> "Champagne" And myRow("bsparkling") = True And myRow("scolor") = "White" Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/sparklingwinegeneric_sm.gif"

                        'SPARKLING RED GENERIC
                    ElseIf RTrim(myRow("scountry")) <> "France" And RTrim(myRow("sregion")) <> "Champagne" And myRow("bsparkling") = True And myRow("scolor") = "Red" Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/sparklingredgeneric_sm.gif"

                        'SPARKLING ROSE GENERIC
                    ElseIf myRow("scolor") = "Rosé" And myRow("bsparkling") = True And myRow("ifortified") = 0 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/sparklingrosegeneric_sm.gif"

                    ElseIf myRow("scolor") = "White" And myRow("ifortified") = 6 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/whitewinegeneric_sm.gif"
                        'FORTIFIED GENERIC
                    ElseIf myRow("ifortified") > 0 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/fortifiedgeneric_sm.gif"
                    Else
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/NoImageAvailable.gif"
                    End If

                    'for the spirits, it's all just based on type (level 1 or 2) and should be self explanatory.
                ElseIf iLevel1Type = 2 Then
                    If myRow("iLiquorLevel2Type") = 25 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/armagnacgeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel2Type") = 27 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/cognacgeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel2Type") = 30 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/piscogeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel2Type") = 26 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/calvadosgeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel2Type") = 28 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/eaudevie_sm.gif"
                    ElseIf myRow("iLiquorLevel2Type") = 29 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/grappa_sm.gif"
                    ElseIf myRow("iLiquorLevel1Type") = 17 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/brandydejerezgeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel1Type") = 50 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/vermouthsaperitifsdigestifsgeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel1Type") = 22 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/rumgeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel1Type") = 18 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/whiskeygeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel1Type") = 19 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/gingeneric_sm.gif"
                    ElseIf myRow("iLiquorLevel1Type") = 20 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/vodkageneric_sm.gif"
                    ElseIf myRow("iLiquorLevel1Type") = 21 Then
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/tequilagenereic_sm.gif"
                    Else
                        CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/liqueursgeneric_sm.gif"
                    End If

                ElseIf iLevel1Type = 3 Then
                    CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/sakegeneric_sm.gif"
                Else
                    CType(e.Item.FindControl("hyplItemPic"), HyperLink).ImageUrl = "~/images/itemimages/sm/NoImageAvailable.gif"
                End If
            End If

            'CType(e.Item.FindControl("imgbtAddBottle"), ImageButton).CommandArgument = myRow("Item").ToString()
            CType(e.Item.FindControl("hyplItemPic"), HyperLink).ToolTip = "Click to view detailed information on " + myRow("Name")
            Session("ItemName") = myRow("Name").ToString()

            CType(e.Item.FindControl("imgbAddToCart"), ImageButton).CommandArgument = myRow("Item").ToString()
            CType(e.Item.FindControl("imgbAddToCart"), ImageButton).ToolTip = "Click to Add " + RTrim(myRow("Name")) + " to your Shopping Cart"
        End If

    End Sub
   
    Protected Sub ddlSearchSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSearchSort.SelectedIndexChanged
        Session("sort") = ddlSearchSort.SelectedIndex
        'Session("pagesize") = ddlPageSize.SelectedIndex
        BindResultDataList()
    End Sub

    Protected Sub ddlPageSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPageSize.SelectedIndexChanged
        Session("pagesize") = ddlPageSize.SelectedIndex
        'Session("sort") = ddlSearchSort.SelectedIndex
        BindResultDataList()
    End Sub
End Class
