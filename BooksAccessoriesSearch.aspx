<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="BooksAccessoriesSearch.aspx.vb" Inherits="BooksAccessoriesSearch" title="Astor Wines & Spirits - Books and Accessories Search" %>

<%@ Register Src="Ucontrols/WUCBasePageTop.ascx" TagName="WUCBasePageTop" TagPrefix="uc4" %>
<%@ Register Src="Ucontrols/WUCBooksAssocSearch.ascx" TagName="WUCBooksAssocSearch" TagPrefix="uc6" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content4" ContentPlaceHolderID="searchContent" Runat="Server">
  <div class="searchResultsSearch">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
  </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="middleContent" Runat="Server">
      <img src="images/general/middleContentTop.gif" />
    <div id="mainContentHeader">
        <h1>Books & Accessories</h1>
    </div>
  <div id="booksSearch">
    <div class="pictureFrame" style="float: right; margin: 5px 15px 5px 15px;"><img src="images/library.jpg" alt="" width="250px" /></div>
    <uc4:WUCBasePageTop ID="WUCBasePageTop1" runat="server" />
    <div style="clear: right;"></div>
  <br />
        <ul class="dailyFeaturesContainer clearfix">
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="13" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="14" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="15" /></li>
        </ul>
 
  <div style="clear: both;"></div>
  </div>    
</asp:Content>