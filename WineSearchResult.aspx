<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="WineSearchResult.aspx.vb" Inherits="WineSearchResult" title="Astor Wines & Spirits - Wines Search" %>

<%@ Register Src="Ucontrols/WUCSearchResultsTop.ascx" TagName="WUCSearchResultsTop" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc2" %>
<%@ Register Src="~/Ucontrols/WUCWineSearch.ascx" TagName="wineSearch" TagPrefix="awWSr" %>
<%@ Register src="~/Ucontrols/WUCRefineSearch.ascx" tagname="WUCRefineSearch" tagprefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">

    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
    <uc1:WUCRefineSearch ID="WUCRefineSearch1" runat="server" />
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="searchResult" class="results-page">
    <uc3:WUCSearchResultsTop ID="WUCSearchResultsTop1" runat="server" />
    <uc2:WUCSearchResults ID="WUCSearchResults1" runat="server" />
  </div>
</asp:Content>