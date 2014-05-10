<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SpiritsSearch.aspx.vb" Inherits="SpiritsSearch" title="Spirits Search | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCBasePageTop.ascx" TagName="WUCBasePageTop" TagPrefix="uc6" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>
<%@ Register Src="~/Ucontrols/WUCTabbedSearchSpirits.ascx" TagName="tabbedSearchSpirits" TagPrefix="awTab" %>
<%@ Register Src="~/Ucontrols/rss-feed.ascx" TagName="rssFeed" TagPrefix="rss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awTab:tabbedSearchSpirits id="tabbedSearchSpirits" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="spiritSearch" class="hub page">

        <h1>Spirits</h1>
               
        <asp:Panel ID="pnlSpecial" runat="server" Visible="false">            
            <div class="homepage-special container clearfix">
                <a href="../SearchResultsSingle.aspx?search=26623&p=2&ref=hp"><img src="../images/itemimages/lg/26623_lg.jpg" alt="Karlsson's Vodka Batch 2008" class="bottle" /></a>
                <div class="copy">
                    <h3>Special Feature</h3>
                    <h4><a href="../SearchResultsSingle.aspx?search=26623&p=2&ref=hp">Karlsson's Vodka Batch 2008</a></h4>
                    <p>Only 1,980 bottles of this vodka made from the 2008 vintage of the Gammel Svensk Röd potato. A hotter year resulted in a more robust flavored potato which yielded a bold, earthy and peppery vodka. Delicious neat or on the rocks.</p>
                </div>
            </div>
        </asp:Panel>
        
        <div class="row clearfix">        
            <ul class="dailyFeaturesContainer">
                <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="10" /></li>
                <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="11" /></li>
                <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="12" /></li>
            </ul>
        </div> <!-- .container -->
        
        <asp:Panel runat="server" ID="pnlNewArrivals">
            <div class="new-arrivals-container row">
                <h2>New Arrivals</h2>
                <table class="new-arrivals-table">
                    <tr>
                        <td class="itm">
                            <asp:HyperLink runat="server" ID="newSpirit1" />
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="litNewSpirit1Status" />
                        </td>
                    </tr>
                    <tr>
                        <td class="itm">
                            <asp:HyperLink runat="server" ID="newSpirit2" />
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="litNewSpirit2Status" />
                        </td>
                    </tr>

                </table>
            </div>
        </asp:Panel>
        
        <div class="rss-feed-container row">
            <rss:rssFeed runat="server" ID="rssfeed" FeedUrl="http://feeds.feedburner.com/tastingnotesnyc/JRPG" />    
        </div>
        
        <div class="browseLine row">
            <asp:HyperLink runat="server" Text="Free Tastings at Our Shop in the East Village 4 Days a Week" NavigateUrl="/TastingEvents.aspx" />
        </div>
        
        <asp:Panel runat="server" ID="pnlAskDan">
            <div class="row">
                <h2>Ask Dan</h2>
                <p>Got a question about spirits? Get an answer from Daniel Fisher, Senior Vice President of Astor’s Spirits Portfolio. Daniel's got a Master of Science in Brewing and Distilling, and he frequents distilleries all over the world.</p>
            </div>
        </asp:Panel>
        
        <div id="about" class="container hide">                 
            <div class="pictureFrame clearfix" style="float: right; margin: 5px 15px 5px 15px;"><img src="images/store/spirits.jpg" alt="" width="250px" /></div>
            <uc6:WUCBasePageTop ID="WUCBasePageTop1" runat="server" />
        </div>    
 
    </div>
</asp:Content>