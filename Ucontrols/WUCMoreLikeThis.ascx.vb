Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO

Partial Class Ucontrols_WUCMoreLikeThis
    Inherits System.Web.UI.UserControl

    Private _item As String
    Private intTxt As Int16
    Private sOrderType As String
    Private sItem As String
    Private iResultCount As Int16

    Public Property item() As String
        Get
            Return _item
        End Get
        Set(ByVal value As String)
            _item = value
        End Set
    End Property
    Public ReadOnly Property showMe() As Boolean
        Get
            Return Me.Visible
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

    Public Sub BindResultDataList()
        Try

            Dim dsn As String = WebAppConfig.ConnectString
            Dim _oAstorCommon As New cAstorCommon
            Dim _odata As New cAstorWebData(dsn)
            Dim _oWebCommon As New WebPageBase
            Dim dsLocal As New DataSet

            dsLocal = _odata.GetMoreLikeThisItem(_item)
            Dim dsTable As DataTable = dsLocal.Tables(0)

            datResults.DataSource = dsTable
            datResults.DataBind()
            If dsTable.Rows.Count = 0 Then
                Me.Visible = False
            Else
                Me.Visible = True
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub datResults_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datResults.ItemCommand

        Dim cart As New AstorwinesCommerce.CartDB(WebAppConfig.ConnectString)
        Dim _oWebCommon As New WebPageBase

        Dim item As ImageButton
        item = e.Item.FindControl("imgbAddToCart")
        sItem = item.CommandArgument
        Try

            If cart.CheckCartForWineClub(_oWebCommon.GetCustomerID(Request, Response), sItem) Then
                Dim strUrl As String = Request.Url.ToString()
                Session("ReturnUrl") = strUrl
                Session("ShoppingCartAddError") = "Add Error"
                'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/ShoppingCart.aspx")
            Else
                cart.AddShoppingCartItem(_oWebCommon.GetCustomerID(Request, Response), sItem, "Bottle", 1)
                Dim strUrl As String = Request.Url.ToString()
                Session("ReturnUrl") = strUrl
                'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/ShoppingCart.aspx")
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Protected Sub datResults_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datResults.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow
            Dim iLevel1Type As Int16
            Dim sInfo As String = String.Empty

            myRowView = e.Item.DataItem
            myRow = myRowView.Row
            iLevel1Type = myRow("iLevel1Type")

            If myRow("botprcfl") <> myRow("botprc") Then
                e.Item.FindControl("lblOldBottlePrice").Visible = True
                'e.Item.FindControl("lblOldCasePrice").Visible = True
                'CType(e.Item.FindControl("lblNewCasePrice"), Label).CssClass = "dealPrice"
                CType(e.Item.FindControl("lblNewBottlePrice"), Label).CssClass = "dealPrice"
            Else
                e.Item.FindControl("lblOldBottlePrice").Visible = False
                'e.Item.FindControl("lblOldCasePrice").Visible = False
            End If
            CType(e.Item.FindControl("hyplItemPic"), HyperLink).NavigateUrl = "~/SearchResultsSingle.aspx?p=" + iLevel1Type.ToString + "&search=" + myRow("Item").ToString() + "&searchtype=Contains"
            CType(e.Item.FindControl("hyplItemName"), HyperLink).NavigateUrl = "~/SearchResultsSingle.aspx?p=" + iLevel1Type.ToString + "&search=" + myRow("Item").ToString() + "&searchtype=Contains"


            'If iLevel1Type = 4 Then
            '    CType(e.Item.FindControl("lblBottlePriceLabel"), Literal).Text = "Item Price:"
            '    e.Item.FindControl("lblCaseLabel").Visible = False
            '    '   e.Item.FindControl("lblOldCasePrice").Visible = False
            '    e.Item.FindControl("lblNewCasePrice").Visible = False
            '    CType(e.Item.FindControl("ddlType"), DropDownList).Items.Clear()
            '    CType(e.Item.FindControl("ddlType"), DropDownList).Items.Add("Item(s)")
            '    CType(e.Item.FindControl("ddlType"), DropDownList).Items(0).Value = "Item"
            '    If CInt(myRow("iBooksAndAccessoriesType")) = 44 Or CInt(myRow("iBooksAndAccessoriesType")) = 46 Then
            '        e.Item.FindControl("imgbAddToCart").Visible = False
            '        e.Item.FindControl("lblInStoreOnly").Visible = True
            '        e.Item.FindControl("ddlType").Visible = False
            '        'e.Item.FindControl("lblQty").Visible = False
            '        e.Item.FindControl("wneQty").Visible = False
            '    End If
            'End If
           

            ' set info label
          
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
            'Session("ItemName") = myRow("Name").ToString()

            'CType(e.Item.FindControl("lblCaseLabel"), Literal).Text = "Case of " & Convert.ToInt16(myRow("pack")).ToString & ":"

            CType(e.Item.FindControl("imgbAddToCart"), ImageButton).CommandArgument = myRow("Item").ToString()
            CType(e.Item.FindControl("imgbAddToCart"), ImageButton).ToolTip = "Click to Add " + RTrim(myRow("Name")) + " to your Shopping Cart"
        End If
    End Sub
    
End Class
