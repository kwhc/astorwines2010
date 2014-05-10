<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="BooksAccessoriesSearchNoResults.aspx.vb" Inherits="BooksAccessoriesSearchNoResults" title="Astor Wines & Spirits - Books & Accessories Search" %>

<%@ Register Src="~/Ucontrols/WUCNoResultTop.ascx" TagName="WUCNoResultTop" TagPrefix="uc7" %>
<%@ Register Src="~/Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCEmailSignUpNew.ascx" TagName="WUCEmailSignUp" TagPrefix="uc3" %>
<%@ Register Src="~/Ucontrols/WUCLastItems.ascx" TagName="WUCLastItems" TagPrefix="uc11" %>
<%@ Register Src="~/Ucontrols/WUCSuggest.ascx" TagName="WUCSuggest" TagPrefix="uc12" %>
<%@ Register Src="~/Ucontrols/WUCAstorCenter.ascx" TagName="WUCAstorCenter" TagPrefix="uc14" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>
<%@ Register Src="~/Ucontrols/WUCWineClub.ascx" TagName="WUCWineClub" TagPrefix="uc15" %>
<%@ Register Src="~/Ucontrols/WUCGlossary.ascx" TagName="WUCGlossary" TagPrefix="uc16" %>
<%@ Register Src="~/Ucontrols/WUCTasting.ascx" TagName="WUCTastings" TagPrefix="uc17" %>
<%@ Register Src="~/Ucontrols/WUCBooksAssocSearch.ascx" TagName="WUCBookSearch" TagPrefix="uc20" %>
<%@ Register Src="~/Ucontrols/WUCQuickSearch.ascx" TagName="quickSearch" TagPrefix="awQck" %>

<asp:Content ID="Content4" ContentPlaceHolderID="searchContent" Runat="Server">
<div class="searchResultsSearch">
     <uc20:WUCBookSearch ID="WUCBookSearch1" runat="Server" showheader="true" />
  </div>
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="booksSearch">
    <h1 class="mainHeader">Books &amp; Accessories</h1>
    <div style="padding: 5px;">
      <uc7:WUCNoResultTop ID="WUCNoResultTop2" runat="server" />
    </div>
  </div>
  <br />
  <div style="height: 290px; float: left; margin-right: 18px;">
    <uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="13" />
  </div>
  <div style="height: 290px; float: left; margin-right: 18px;">
    <uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="14" />
  </div>
  <div style="height: 290px; float: left">
    <uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="15" />
  </div>
  <br style="clear: left;" />
  <br />
  <div style="border: 0; float: left; height: 217px; margin-right: 15px;">
    <uc17:WUCTastings runat="Server" />
  </div>
  <div style="border: 0; float: right; height: 217px; width: 294px; margin-right: 10px;">
    <uc16:WUCGlossary ID="WUCGlossary1" runat="server" />
  </div>
  <div style="clear: both;"></div>
</asp:Content>