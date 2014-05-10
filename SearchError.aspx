<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SearchError.aspx.vb" Inherits="SearchError" title="Astor Wines & Spirits - Search Error" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="outOfStockPage" class="mainContent">
    <div id="mainImageContainer">
        <img src="../images/general/img_out-of-stock.jpg" alt="Out Of Stock" />
    </div>
    <h1>We're Sorry</h1>
    
    <div class="copyContainer">
        <p>This product doesn't seem to be available. We may just be out of stock at the moment.</p>
        <p>If you want to be notified if/when the product returns to stock please email us at online@astorwines.com</p>
        <p>Be sure to include the item!</p>
    </div>
    
  </div>
</asp:Content>