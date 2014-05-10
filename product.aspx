<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" CodeFile="Product.aspx.vb" Inherits="product" EnableEventValidation="false" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCSearchResults.ascx" TagName="searchResults" TagPrefix="awSrs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="searchResult">
    <awSrs:searchResults ID="WUCSearchResults1" runat="server" />
  </div>
</asp:Content>

