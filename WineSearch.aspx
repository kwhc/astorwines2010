<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="WineSearch.aspx.vb" Inherits="WineSearch" title="Astor Wines &amp; Spirits - Wines Search" %>

<%@ Register Src="Ucontrols/WUCBasePageTop.ascx" TagName="WUCBasePageTop" TagPrefix="uc6" %>
<%@ Register Src="~/Ucontrols/WUCWineSearch.ascx" TagName="wineSearch" TagPrefix="awWSr" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>
<%@ Register Src="~/Ucontrols/WUCWineClub.ascx" TagName="WUCWineClub" TagPrefix="uc14" %>
<%@ Register Src="~/Ucontrols/WUCGlossary.ascx" TagName="WUCGlossary" TagPrefix="uc15" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <div class="searchResultsSearch">
    <awCmb:combinedSearch runat="server" />
  </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="wineSearch" class="hub page">
        <h1>Wines</h1> 

        <ul class="dailyFeaturesContainer row clearfix">
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="4" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="5" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="6" /></li>
        </ul> <!-- .dailyFeaturesContainer -->

        <div class="productBrowse row">
            <h2>Browse Wines By...</h2>
            
            <div class="container">
                <h3>Country</h3>
                <ul class="inline grid">
                    <li>
                    <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=france">France</a>
                    </li>
                    <li>
                        <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=italy">Italy</a>
                    </li>
                    <li>
                        <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=spain">Spain</a>                    
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=usa">United States</a>                    
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=portugal">Portugal</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=chile">Chile</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=germany">Germany</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=austria">Austria</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=greece">Greece</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;country=new+zealand">New Zealand</a>
                    </li>
                </ul>
                <div>                  
                    <span class="note">Explore more countries in our advanced search on the left!</span>
                </div>
            </div> <!-- .container --> 
            
            <div class="container">
                <h3>Region</h3>

                <ul class="grid inline">
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=bordeaux">Bordeaux</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=piedmont">Piedmont</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=burgundy">Burgundy</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=california">California</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=champagne">Champagne</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=tuscany">Tuscany</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=loire">Loire</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=oregon">Oregon</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=veneto">Veneto</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=victoria">Victoria</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=rhone">Rhone</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;region=bordeaux">Bordeaux</a>
                    </li>
                </ul>

                <div>                  
                    <span class="note">Explore more regions in our advanced search on the left!</span>
                </div>
            </div> <!-- .container -->

            <div class="container">            
                <h3>Sub-Region</h3>
                
                <ul class="grid inline">
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;subregion=sauternes">Sauternes</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;subregion=chianti">Chianti</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;subregion=napa">Napa</a>
                    </li>
                    <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;subregion=beaujolais">Beaujolais</a>
                    </li>
                    <li>
                       <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;subregion=chablis">Chablis</a>
                   </li>
                   <li>
                      <a href="WineSearchResult.aspx?p=1&amp;search=Advanced&amp;searchtype=Contains&amp;term=&amp;cat=1&amp;subregion=mendocino">Mendocino</a>
                   </li>
                </ul>
                
                <div>                  
                    <span class="note">Explore more sub-regions in our advandced search on the left!</span>
                </div>
            </div> <!-- .container -->                
        </div> <!-- .productBrowse -->
        
        <div class="container clearfix">
            <h2>How We Buy Our Wines</h2>
                <img src="images/shop/img_coolRoom1.jpg" alt="Cool Room" style="margin-bottom: 12px;" />           
            <uc6:WUCBasePageTop ID="WUCBasePageTop1" runat="server" />
        </div>  <!-- .container -->

    </div>
  <!--<div style="border: 0; float: left; height: 217px; margin-right: 15px;">
    <uc14:WUCWineClub ID="WUCWineClub" runat="server" /> </div>
  <div style="border: 0; float: right; height: 217px; width: 294px; margin-right: 10px;">
    <uc15:WUCGlossary ID="WUCGlossary" runat="server" />
  </div>-->
  
</asp:Content>