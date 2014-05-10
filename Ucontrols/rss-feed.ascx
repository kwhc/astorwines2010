<%@ Control Language="VB" AutoEventWireup="false" CodeFile="rss-feed.ascx.vb" Inherits="Ucontrols_rss_feed" %>

<header>
    <span><asp:Literal runat="Server" ID="litTopic" /></span>
    <h2>Latest from Tasting Notes</h2>
</header>
<asp:Repeater runat="server" ID="rptRssFeed">
    <ItemTemplate>
        <div class="teaser-post">
        <h3><asp:HyperLink runat="server" ID="lnkTitle" Target="_blank" ><asp:Literal runat="server" ID="litTitle" /> </asp:HyperLink></h3>
            <div class="rss-description">
                <asp:Image runat="server" ID="imgPicture" />
                <asp:Literal runat="server" ID="litDescription" />
            </div>
            <asp:HiddenField Value="<%# Container.ItemIndex + 1 %>" runat="server" ID="idNum" />

            <div class="hide">
                <asp:Panel runat="server" ID="cContainer" CssClass="rssContentContainer">
                    <asp:Literal runat="server" ID="litContent" />
                </asp:Panel>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
