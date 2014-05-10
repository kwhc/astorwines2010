Imports AstorDataClass
Imports WebCommon
'Imports SslTools

Partial Class Ucontrols_WUCGlossarySingleRelated
    Inherits System.Web.UI.UserControl

    Private dsn As String = WebAppConfig.ConnectString
    Private _item As String

    Public Property item() As String
        Get
            Return _item
        End Get
        Set(ByVal value As String)
            _item = value
        End Set
    End Property

    Public Sub loadRelated()
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As System.Data.DataSet
        dsLocal = _odata.FindItem(item, "", False, "", "", "", "", "", 0, "R", "")
        If dsLocal.Tables(0).Rows.Count = 0 Then
            'Redirect("SearchError.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("SearchError.aspx")
        End If
        Dim featureRow As Data.DataRow
        featureRow = dsLocal.Tables(0).Rows(0)
        Dim relItem, relName, relVintage, relSize, relLabelNotes As String
        Dim relBottlePrice, relCasePrice, relDealPrice As Double
        relItem = featureRow.Item("item")
        btnAddToCart.CommandArgument = relItem
        relName = featureRow.Item("name")
        relVintage = featureRow.Item("vintage")
        relSize = featureRow.Item("size")
        relLabelNotes = featureRow.Item("sDescr")
        relBottlePrice = featureRow.Item("botprcfl")
        relCasePrice = featureRow.Item("casprcfl")
        relDealPrice = featureRow.Item("botprc")
        Dim productURL As String = "../SearchResultsSingle.aspx?p=1&search=" & relItem & "&searchtype=Contains"
        featureTitle.Text = "<a href=""" & productURL & """>" & relName & " - " & relVintage & " " & relSize & "</a>"
        Dim imageLocation As String = "./images/itemimages/sm/" & relItem & "_sm.jpg"
        Dim imageFile As New IO.FileInfo(Server.MapPath(imageLocation))
        If Not imageFile.Exists Then
            imageLocation = "./images/itemimages/sm/redwinegeneric_sm.gif"
        End If
        featureImage.ImageUrl = "." & imageLocation
        featureDescription.Text = breakAtHyphen(cutOff(relLabelNotes, 124))
        featureLink.NavigateUrl = "../SearchResultsSingle.aspx?p=1&search=" & relItem & "&searchtype=Contains"
        featureItemNr.Text = relItem
        featurePrice.Text = "Bottle Price: $" & relBottlePrice & "<br />Case of 12: $" & relCasePrice & "<br />"

    End Sub

    Private Function breakAtHyphen(ByVal givenString As String) As String
        If givenString.Contains("-") Then
            Dim placeOfHyphen As Integer = givenString.IndexOf("-")
            Dim stringUntilHyphen As String = givenString.Substring(0, placeOfHyphen + 1)
            Dim placeOfSpaceBeforeHyphen As Integer = stringUntilHyphen.LastIndexOf(" ")
            Dim stringAfterHyphen As String = givenString.Substring(placeOfHyphen + 1)
            Dim placeOfSpaceAfterHyphen As Integer = stringAfterHyphen.IndexOf(" ")
            Dim placeOfSpaceAfterHyphenWord As Integer = stringUntilHyphen.Length + placeOfSpaceAfterHyphen
            Dim lengthOfHyphenWord As Integer = placeOfSpaceAfterHyphenWord - placeOfSpaceBeforeHyphen
            If lengthOfHyphenWord > 15 Then
                Return stringUntilHyphen + "<br />" + stringAfterHyphen
            Else
                Return givenString
            End If
        Else
            Return givenString
        End If
    End Function

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
        Dim thisItem As String = btnAddToCart.CommandArgument.ToString

        If cart.CheckCartForWineClub(_oWebCommon.GetCustomerID(Request, Response), thisItem) Then
            Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = strUrl
            Session("ShoppingCartAddError") = "Add Error"
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        Else
            cart.AddShoppingCartItem(_oWebCommon.GetCustomerID, thisItem, orderType, intTxt)
            'Dim strUrl As String = Request.Url.ToString()
            ' Session("ReturnUrl") = hyplReturnToShopping.NavigateUrl
            'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
            Response.Redirect("~/ShoppingCart.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
