
Partial Class Ucontrols_homepageSpecial
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        pnlSpecial.Visible = False

        Dim itemNum As String
        Dim itemTitle As String
        Dim itemDesc As String
        Dim subHead As String
        Dim iconSrc As String

        itemNum = "27335"
        itemTitle = "Vinho Verde White, Este - 2011"
        subHead = "Wines of the <span style=""font-style: italic;"">Times</span>"
        itemDesc = """Let me get this straight: a bottle of wine, an enjoyable bottle of wine, for just $4? A mistake? Nope. An anomaly, perhaps, as this bottle is apparently available in the United States only at Astor Wines and Spirits in Greenwich Village.""<br/><span style=""color:#ccc;"">- Eric Asimov (June 27, 2013) in <span style=""font-style: italic;"">The New York Times</span></span>"
        iconSrc = "../images/general/img_nytimes_aqua.png"

        Dim itemLink As String = "../SearchResultsSingle.aspx?search=" & itemNum & "&searchtype=Contains&p=2&ref=hp"

        imgIcon.Height = 30
        imgIcon.Style("margin-right") = "10px"
        imgIcon.Style("vertical-align") = "middle"
        imgIcon.ImageUrl = iconSrc
        litSubHead.Text = subHead
        litDescription.Text = itemDesc
        litTitle.Text = itemTitle
        imgBottle.AlternateText = itemTitle
        imgBottle.CssClass = "bottle"
        imgBottle.ImageUrl = ""
        imgBottle.ImageUrl = "../images/itemimages/lg/" & itemNum & "_lg.jpg"
        imgBottle.PostBackUrl = itemLink
        lnkGet.PostBackUrl = itemLink
        lnkGet.Text = "Get it here &#187;"


    End Sub
End Class
