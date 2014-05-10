<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="tuesdaysale.aspx.vb" Inherits="AstorTuesdays" title="15% Off Tuesday Sale | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCSearchResultsTop.ascx" TagName="WUCSearchResultsTop" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc2" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <img src="images/general/middleContentTop.gif" alt="" />
  
  <div id="mainContentHeader">
    <h1>15% Off Tuesdays</h1>
  </div>
  
  <div id="tuesdaySale">
    
    <asp:Panel runat="server" ID="notTuesday">
        <div id="notTuesdayPanel">
            <div id="mainImageContainer">
                <img src="../images/tuesday-sale/img_tuesday-sale-main-image.jpg" alt="15% Off Tuesday Sale at Astor" id="mainImage" />
            </div>

            <div id="leftColumn">
                <div id="upcomingSales">   
                    <h2>Upcoming Sales</h2>
                    <ul>
                        <li><asp:Literal runat="server" ID="sale1" /></li>
                        <li><asp:Literal runat="server" ID="sale2" /></li>
                        <li><asp:Literal runat="server" ID="sale3" /></li>
                    </ul>
                </div>    
                <div id="getReminders">
                    <h2>Get Reminders</h2>
                    <ul>
                        <li><div class="reminderContainer"><a href="emails.aspx"><img src="../images/general/btn_email.gif" alt="Join Astor Wines Email List" /></a><br />E-Mail</div></li>
                        <li><div class="reminderContainer"><a href="http://www.facebook.com/astorwines" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-Facebook','Tuesdays')"><img src="../images/general/btn_facebook.gif" alt="Like us on Facebook!" /></a><br />Facebook</div></li>
                        <li><div class="reminderContainer"><a href="http://www.twitter.com/astorwines" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-Twitter','Tuesdays')"><img src="../images/general/btn_twitter.gif" alt="Follow Us On Twitter" /></a><br />Twitter</div></li>
                    </ul>

                </div>
            </div>
            
            <div id="rightColumn">
                
                <div id="copy">
                    <p>We pick the region... YOU pick the wine!</p>
                    <p>Every Tuesday, our buyers pick a region or type of wine, spirit, or saké and mark it down 15%.</p>
                    Can't wait for a great deal?
                    <ul>
                        <li><a href="WinesOnSale.aspx">What's On Sale</a></li>
                        <li><a href="topten.aspx">Top Ten Under $10</a></li>
                        </ul>
                </div>
                                
            </div>
            <br style="clear: both;" /> 

    </div>
        
    </asp:Panel>
    
    <asp:Panel runat="server" ID="tuesday">
        <div style="padding: 15px; font-size: 12px;">
            <asp:Literal ID="lblResultTop" runat="server">We pick the region...YOU pick the wine!</asp:Literal><br />
            <asp:Literal ID="lblResultBottom" runat="server">Every Tuesday, our buyers pick a region or type of wine, spirit, or saké and mark it down 15%.  Check out these sales:</asp:Literal>
        </div>
        <div>
            <asp:Label runat="server" ID="saleTitle" />
            <uc2:WUCSearchResults ID="WUCSearchResults1" runat="server" />
            <br style="clear: both;" />
        </div>
    </asp:Panel>
  </div>
</asp:Content>