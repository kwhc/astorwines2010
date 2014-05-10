<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="newArrivals.aspx.vb" Inherits="newArrivals" Title="New Arrivals | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCLastItems.ascx" TagName="WUCLastItems" TagPrefix="uc15" %>
<%@ Register Src="~/Ucontrols/WUCSuggest.ascx" TagName="WUCSuggest" TagPrefix="uc14" %>
<%@ Register Src="~/Ucontrols/WUCEmailSignUpNew.ascx" TagName="WUCEmailSignUpNew" TagPrefix="uc8" %>
<%@ Register Src="~/Ucontrols/WUCAstorCenter.ascx" TagName="WUCAstorCenter" TagPrefix="uc10" %>
<%@ Register Src="~/Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc5" %>
<%@ Register Src="~/Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc4" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<div id="winesOnSale" class="page">
    <h1>New Arrivals</h1>
  <div>
    <p>Astor’s buyers taste hundreds of wines and spirits each month, and then choose only the best to go on our
    shelves. The following are some of the latest bottles to make it past their discerning palates,
    so if you’re craving something new, interesting, and extremely tasty, read on for their newest finds.
    </p>
    <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
  </div>
  <div>
    <uc4:WUCSearchResults ID="WUCSearchResults1" runat="server" />  
  </div>
</div>
</asp:Content>