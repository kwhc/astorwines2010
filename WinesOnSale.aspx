<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="WinesOnSale.aspx.vb" Inherits="WinesOnSale" title="Astor Wines & Spirits - Wines On Sale" %>

<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc4" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

<div id="winesOnSale" class="page">
    <h1>Wines On Sale</h1>
    <div>
        <p>Great wines with even tastier price tags...</p>
        <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
    </div>
  <div>
    <uc4:WUCSearchResults ID="WUCSearchResults1" runat="server" />  
  </div>
</div>
</asp:Content>