Imports System.Xml
Imports System.Xml.XPath

Partial Class Ucontrols_rss_feed
    Inherits System.Web.UI.UserControl

    Private _feedUrl As String

    Public Property FeedUrl() As String
        Get
            Return _feedUrl
        End Get
        Set(ByVal value As String)
            _feedUrl = value
        End Set
    End Property

    Private _xmlnsm As XmlNamespaceManager

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Dim xpn As XPathNavigator
        xpn = New XPathDocument(_feedUrl).CreateNavigator()

        '_xmlnsm = XmlHelper.GetXmlNameSpaceManager(xpn)

        rptRssFeed.DataSource = xpn.Select("rss/channel/item[category = 'Spirits & Cocktails'][category = 'New & Approved' or category = 'Sip On This'][position() <= 5]", _xmlnsm)
        'rptRssFeed.DataSource = xpn.Select("rss/channel/item[title = 'What’s In Store For Spring']", _xmlnsm)
        rptRssFeed.DataBind()

    End Sub

    Protected Sub rptRssFeed_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptRssFeed.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim xpn As XPathNavigator = DirectCast(e.Item.DataItem, XPathNavigator)
            Dim litTitle As Literal = DirectCast(e.Item.FindControl("litTitle"), Literal)
            Dim litDescription As Literal = DirectCast(e.Item.FindControl("litDescription"), Literal)
            Dim litContent As Literal = DirectCast(e.Item.FindControl("litContent"), Literal)
            Dim lnkTitle As HyperLink = DirectCast(e.Item.FindControl("lnkTitle"), HyperLink)
            Dim idNum As HiddenField = DirectCast(e.Item.FindControl("idNum"), HiddenField)
            Dim cContainer As Panel = DirectCast(e.Item.FindControl("cContainer"), Panel)

            Dim _xmlnsm As New XmlNamespaceManager(xpn.NameTable)
            _xmlnsm.AddNamespace("dc", "http://purl.org/dc/elements/1.1/")
            _xmlnsm.AddNamespace("content", "http://purl.org/rss/1.0/modules/content/")
            _xmlnsm.AddNamespace("rss", "http://purl.org/rss/1.0/")

            litTitle.Text = xpn.SelectSingleNode("title").Value
            litDescription.Text = xpn.SelectSingleNode("description").Value
            litContent.Text = xpn.SelectSingleNode("content:encoded", _xmlnsm).Value
            lnkTitle.NavigateUrl = xpn.SelectSingleNode("link").Value

            Dim cIndex As String
            cIndex = idNum.Value

            'Launch article in a clearbox
            'lnkTitle.Attributes.Add("rel", "clearbox[height=600,,width=600]")
            'lnkTitle.NavigateUrl = "inner#" + cContainer.ClientID

            'Dim cContainer As HtmlGenericControl
            'cContainer = DirectCast(e.Item.FindControl("yes"), HtmlGenericControl)
            'cContainer.Attributes("id") = cContainer.ClientID + cIndex


        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        getHeader()

    End Sub

    Sub getHeader()
        Dim topic As String = String.Empty
        Dim hub As String

        hub = Request.Path.ToString()

        If hub.Contains("Spirits") = True Then
            topic = "spirits and cocktails"
        ElseIf hub.Contains("WineSearch.aspx") Then
            topic = "wine"
        End If

        litTopic.Text = topic

    End Sub
End Class
