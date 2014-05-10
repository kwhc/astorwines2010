Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
'Imports SslTools
Partial Class Specialpacks
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SearchParms") = Nothing
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.Cache.SetExpires(Now())
        If Not IsPostBack Then
            Try
                If Not IsNothing(Request.QueryString("search")) Then

                    Session.Item("queryValue") = Request.QueryString("search")

                End If
                If Not IsNothing(Request.QueryString("searchtype")) Then

                    Session.Item("queryType") = Request.QueryString("searchtype")

                End If
                If Not Session("ReturnUrl") Is Nothing Then
                    ReturnUrl.Value = Session("ReturnUrl")
                    Session("ReturnUrl") = Nothing

                Else
                    ReturnUrl.Value = "~/default.aspx"
                End If
                If Not IsNothing(Request.QueryString("packitem")) Then
                    Dim _dslocal As DataSet
                    Dim sQueryString As String = Request.QueryString("packitem")


                    _dslocal = GetPackData(sQueryString)
                    If _dslocal.Tables.Count > 0 Then
                        BindControls(_dslocal)
                        'With _dslocal.Tables(1).Rows(0)

                        'End With

                        Session("DSMulti") = _dslocal
                        Session("queryType") = Nothing
                        Session("queryValue") = Nothing
                    Else
                        'Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                        Response.Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                    End If
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Private Function GetPackData(ByVal sItem As String) As DataSet

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As New DataSet

        Try

            dsLocal = _odata.GetSpecialPack(sItem)


        Catch ex As Exception
            Throw ex
        End Try

        Return dsLocal

    End Function
    Private Sub BindControls(ByVal oDS As DataSet)
        Try
            If oDS.Tables.Count > 0 Then
                If oDS.Tables(1).Rows.Count > 0 Then
                    With oDS.Tables(1).Rows(0)
                        Dim sName As String
                        Dim sInfo As String = String.Empty

                        '   If .Item("sHeaderImageLocation").ToString() <> "" Then
                        'imgFeatureHeader.ImageUrl = .Item("sHeaderImageLocation").ToString()
                        'End If
                        If .Item("sFeatureImageLocation").ToString() <> "" Then
                            imgFeature.ImageUrl = .Item("sFeatureImageLocation").ToString()
                        End If
                        'lblFeature.Text = _dtlocal.Rows(0).Item("sFeatureDescLong").ToString()
                        'litFeature.Text = .Item("sFeatureDescLong").ToString()
                        litFeature.Text = .Item("sDescr").ToString()

                        sName = .Item("name").ToString
                        If RTrim(.Item("vintage")) <> "" Then
                            sName = sName & " - " & RTrim(.Item("vintage"))
                        End If
                        'If RTrim(.Item("size")) <> "" Then
                        '    sName = sName & " " & RTrim(.Item("size"))
                        'End If
                        lblItemName.Text = sName
                        lblItem.Text = .Item("item").ToString

                        ' set info label
                        'sInfo = RTrim(.Item("sColor").ToString)
                        'If RTrim(.Item("sCountry").ToString) <> "" Then
                        '    If Len(RTrim(sInfo)) > 1 Then
                        '        sInfo = sInfo & ", " & RTrim(.Item("sCountry").ToString)
                        '    Else
                        '        sInfo = RTrim(.Item("sCountry").ToString)
                        '    End If
                        'End If
                        'If RTrim(.Item("sRegion").ToString) <> "" Then
                        '    If Len(RTrim(sInfo)) > 1 Then
                        '        sInfo = sInfo & ", " & RTrim(.Item("sRegion").ToString)
                        '    Else
                        '        sInfo = RTrim(.Item("sRegion").ToString)
                        '    End If
                        'End If
                        'If RTrim(.Item("sSubRegion").ToString) <> "" Then
                        '    If Len(RTrim(sInfo)) > 1 Then
                        '        sInfo = sInfo & ", " & RTrim(.Item("sSubRegion").ToString)
                        '    Else
                        '        sInfo = RTrim(.Item("sSubRegion").ToString)
                        '    End If
                        'End If
                        lblInfo.Text = sInfo

                        'lblDescr.Text = .Item("sdescr").ToString
                        lblOldBottlePrice.Text = "$" & .Item("botprcfl").ToString
                        lblNewBottlePrice.Text = "$" & .Item("botprc").ToString
                        'lblNewCasePrice.Text = "$" & .Item("casprc").ToString
                        'lblOldCasePrice.Text = "$" & .Item("casprc").ToString
                        'lblCaseLabel.Text = "Case of " & Convert.ToInt16(.Item("pack")).ToString & ":"

                        If .Item("OnSale").ToString = "On Sale" Then
                            lblOldBottlePrice.Visible = True
                            'lblOldCasePrice.Visible = True
                        Else
                            lblOldBottlePrice.Visible = False
                            'lblOldCasePrice.Visible = False
                        End If

                    End With
                Else
                    'Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                    Response.Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                End If
            Else
                'Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                Response.Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Protected Sub imgbAddToCart_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbAddToCart.Click
        Dim intTxt As Integer
        Dim sOrderType As String
        Dim sItem As String
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())


        intTxt = wneQty.Value
        'sOrderType = ddlType.SelectedValue
        sOrderType = "Pack"
        sItem = lblItem.Text

        If cart.CheckCartForWineClub(GetCustomerID(Request, Response), sItem) Then
            Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = strUrl
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(GetCustomerID(Request, Response), sItem, sOrderType, intTxt)
            Session("ReturnUrl") = "~/default.aspx"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub
End Class
