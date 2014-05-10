<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SakeSearchResult.aspx.vb" Inherits="SakeSearchResult" title="Sak&#233; Search | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCSearchResultsTop.ascx" TagName="WUCSearchResultsTop" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc2" %>
<%@ Register src="Ucontrols/WUCRefineSearch.ascx" tagname="WUCRefineSearch" tagprefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCTabbedSearchSake.ascx" TagName="tabbedSearchSake" TagPrefix="awTab" %>

<asp:Content id="Content4" ContentPlaceHolderID="searchContent" Runat="Server">

    <awTab:tabbedSearchSake id="tabbedSearchSake" runat="server" />
    <uc1:WUCRefineSearch id="WUCRefineSearch1" runat="server" />
    
</asp:Content>
<asp:Content id="Content5" ContentPlaceHolderID="middleContent" Runat="Server">
  <img src="images/general/middleContentTop.gif" />
  <div id="searchResult">
    <uc3:WUCSearchResultsTop id="WUCSearchResultsTop1" runat="server" />
    <uc2:WUCSearchResults id="WUCSearchResults1" runat="server" />
  </div>
</asp:Content>