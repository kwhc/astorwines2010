<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SpiritsSearchResult.aspx.vb" Inherits="SpiritsSearchResult" title="Spirits Search | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCSearchResultsTop.ascx" TagName="WUCSearchResultsTop" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc2" %>
<%@ Register Src="~/Ucontrols/WUCTabbedSearchSpirits.ascx" TagName="tabbedSearchSpirits" TagPrefix="awTab" %>
<%@ Register src="Ucontrols/WUCRefineSearch.ascx" tagname="WUCRefineSearch" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">

    <awTab:tabbedSearchSpirits id="tabbedSearchSpirits" runat="server" />
    <uc1:WUCRefineSearch ID="WUCRefineSearch1" runat="server" />

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="middleContent" Runat="Server">
  <img src="images/general/middleContentTop.gif" />
  <div id="searchResult">
    <uc3:WUCSearchResultsTop ID="WUCSearchResultsTop1" runat="server" />
    <uc2:WUCSearchResults ID="WUCSearchResults1" runat="server" />
  </div>
</asp:Content>