<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_cDefault" EnableEventValidation="false" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Src="Ucontrols/WUC15Tuesday.ascx" TagName="WUC15Tuesday" TagPrefix="uc5" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc2" %>
<%@ Register Src="Ucontrols/WUCEmailSignUp.ascx" TagName="WUCEmailSignUp" TagPrefix="uc4" %>
<%@ Register Src="~/Ucontrols/WUCFeatures.ascx" TagName="WUCFeatures" TagPrefix="uc7" %>
<%@ Register Src="~/Ucontrols/WUCEmailSignUpNew.ascx" TagName="WUCEmailSignUpNew" TagPrefix="uc8" %>
<%@ Register Src="~/Ucontrols/WUCWineClub.ascx" TagName="WUCWineClub" TagPrefix="uc9" %>
<%@ Register Src="~/Ucontrols/WUCAstorCenter.ascx" TagName="WUCAstorCenter" TagPrefix="uc10" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc11" %>
<%@ Register Src="~/Ucontrols/WUCTasting.ascx" TagName="WUCFreeTastings" TagPrefix="uc12" %>
<%@ Register Src="~/Ucontrols/WUCSuggest.ascx" TagName="WUCSuggest" TagPrefix="uc14" %>
<%@ Register Src="~/Ucontrols/WUCLastItems.ascx" TagName="WUCLastItems" TagPrefix="uc15" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCVideoTout.ascx" TagName="videoTout" TagPrefix="Vid" %>
<%@ Register Src="~/Ucontrols/WUCACEventTout.ascx" TagName="ACEventTout" TagPrefix="ACEvent" %>
<%@ Register Src="~/Ucontrols/homepageSpecial.ascx" TagName="special" TagPrefix="HP" %>
<%@ Register Src="~/Ucontrols/tastingNotesHomepageFeature.ascx" TagName="tastingNotes" TagPrefix="HP" %>
<%@ Register Src="~/Ucontrols/whatsHot.ascx" TagName="whatsHot" TagPrefix="HP" %>
<%@ Register Src="~/Ucontrols/shopHours.ascx" TagName="shopHours" TagPrefix="HP" %>
<%@ Register Src="~/Ucontrols/deliveryAlert.ascx" TagName="deliveryAlert" TagPrefix="HP" %>

<asp:Content ContentPlaceHolderID="HeadSupplement" runat="server" ID="defaultHeadSupplement">
    <script type="text/javascript">
    $(window).load(
        function() {
            //toast alert
            $("#masthead").animate({ "top": "+=200px"
                  }, "slow");
            });
    </script>
</asp:Content>

<asp:Content id="Content1" ContentPlaceHolderid="searchContent" Runat="Server">
  <asp:Label id="labelAcceptsCookies" runat="server" />
  <awCmb:combinedSearch runat="server" />
</asp:Content>

<asp:Content id="Content2" ContentPlaceHolderid="middleContent" Runat="Server">
<div id="homeContent">
    <div id="homepageFeatures">
        <uc7:WUCFeatures runat="server" />
    </div>
    <div style="background-color:#fefefe;padding-top:8px;">       
        <HP:deliveryAlert runat="server" ID="ucDeliveryAlert" Visible="false" />

        <HP:whatsHot runat="server" ID="ucWhatsHot" />
                
        <HP:shopHours runat="server" ID="ucShopHours" />
        
        <HP:special runat="server" ID="ucHomepageSpecial" />
        
        <ul class="dailyFeaturesContainer clearfix">
            <li><uc11:WUCDailyFeatures runat="server" feature="1" /></li>
            <li><uc11:WUCDailyFeatures runat="server" feature="2" /></li>
            <li><uc11:WUCDailyFeatures runat="server" feature="3" /></li>
        </ul>

        <HP:tastingNotes runat="server" ID="ucTastingNotesHomepageFeature" />

        <br />
        <div id="map"></div>            

        <!-- Video Tasting Section -->
        <asp:Panel runat="server" ID="pnlVideoTout" Visible="false">
            <div id="homepageVideoTout" class="clearfix section">  
                <div style="float: left; width: 315px;">
                    <Vid:videoTout ID="videoTout1" runat="server" />
                </div>
                
                <div style="float: left; width: 260px; padding: 10px;">
                   <h3>Video Tasting Series</h3>
                   <div id="state"></div>
                    <!-- <b>Featured Video:</b><br /> -->
                    <a href="/SearchResultsSingle.aspx?search=20469&amp;searchtype=Contains&amp;term=&amp;p=1&amp;rel=homepageVideoToutFeature">Lacrima di Morro d'Alba, Luciano Landi - 2010</a>
                    
                    <p>Taste a lacrima with a beautifully unique bouquet with David.</p>
                        More from our Video Tasting Series:
                        
                        <ul>
                        <li><a href="/SearchResultsSingle.aspx?search=43232&amp;searchtype=Contains&amp;term=&amp;p=1&amp;rel=homepageVideoTout">Erbaluce di Caluso "La Torrazza", Ferrando - 2009</a></li>
                        <li><a href="/SearchResultsSingle.aspx?search=23777&amp;searchtype=Contains&amp;term=&amp;p=1&amp;rel=homepageVideoTout">l'Affranchi Rouge, Zéro Pointé - 2005</a></li>
                        <li><a href="/SearchResultsSingle.aspx?search=23731&amp;searchtype=Contains&amp;term=&amp;p=1&amp;rel=homepageVideoTout">Palmer Vineyards Sauvignon Blanc - 2010</a></li>
                        </ul>
                </div> <!-- .more-videos -->    
            </div> <!-- #homepageVideoTout .clearfix -->
        </asp:Panel>
</div>
<div class="clearfix">
<%--    <div style="padding: 16px; margin-left: 24px;  margin-bottom: 30px;">
        <img src="../images/general/img_new.png" alt="New" style="float: left; margin-right: 12px; margin-top: 6px;" />
        <img src="../images/home/img_bubble_bkdelivery.png" alt="We Now Deliver to Brooklyn on Tuesdays" />
    </div>--%>
    <asp:HyperLink runat="server" NavigateUrl="m.aspx?p=pm-courier-service" ImageUrl="../images/promo/2014-pmDeliveryService/img_pmDeliveryServiceBanner.png" />
</div>
<div style="background-color:#fefefe;padding:2rem 0;">            
    <ul class="nl clearfix">
        <li class="section clearfix">             
            <a href="/top12.aspx"><img src="../images/icons/img_top12_300x300.png" alt="Top 12 Under $12 Monthly Wine Pack" width="130" /></a>
            <h3>Top 12<br/>Under $12</h3>
            <p>A different mix every month: 12 outstanding wines for under $100.</p><br /> <a href="/top12.aspx"> See what's in the pack this month&raquo;</a>
        </li>  
        
        <li class="section clearfix">
            <a href="DeliveryInformation.aspx?rel=homeToutImg"><img src="../images/icons/img_freeDelivery_300x300.png" alt="Free Shipping" width="130" /></a>  
            <h3>Free<br/>Shipping</h3>
            <p>We offer free shipping on most orders in New York State!</p><br /><br /> <a href="DeliveryInformation.aspx?rel=homeTout">Click here for details&raquo;</a>
        </li>
        
        <li class="section clearfix">
            <a href="clubs.aspx?rel=homeToutImg"><img src="../images/icons/img_wineClubs_300x300.png" alt="Monthly Wine Clubs" width="130" /></a> 
            <h3>Monthly<br/>Wine Clubs</h3>
            <p>Join a club to try some of our best bottles, or sign up a friend: it’s the ultimate gift for wine and spirits lovers.</p><br /> <a href="clubs.aspx?rel=homeToutTxt">Find the perfect club &raquo;</a>
        </li>
    </ul>

    <div class="browseLine">Browse: <a href="Winesearch.aspx?rel=homeBrowseBot">Wines</a>        |        <a href="Sakesearch.aspx?rel=homeBrowseBot">Sak&#233;s</a>        |        <a href="Spiritssearch.aspx?rel=homeBrowseBot">Spirits</a> </div>
                        
        <div id="freeTastingsContainer" class="clearfix section">
            <a href="../TastingEvents.aspx?rel=homeToutImg"><img src="../images/icons/img_freeTastings_300x300.png" alt="Free Tastings at Astor Wines & Spirits" width="80" /></a>
            <h3>&bull; Free Tastings at Astor Wines &amp; Spirits &bull;</h3>
            <p class="copyContainer clearfix">
                Drop in for one of our <b>FREE</b> tastings and pick up a few bottles of a <br />new favorite.
            </p> <!-- .copyContainer .clearfix --> 
            <br />
            <uc12:WUCFreeTastings id="WUCFreeTastings1" runat="server" /> 
            <a href="../TastingEvents.aspx?rel=homeToutTxt">See Our Full Tasting Schedule &#187;</a>
        </div> <!-- #freeTastingsContainer .clearfix -->
                                
        <br />
        <div class="section green browseLine"><a href="ourshop.aspx?rel=homeTout">Our Green Effort&raquo;</a></div>
</div>
</div> <!-- #homeContent -->
</asp:Content>