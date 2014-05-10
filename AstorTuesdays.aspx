<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorTuesdays.aspx.vb" Inherits="AstorTuesdays" title="Astor Wines & Spirits - Astor Tuesdays" %>

<%@ Register Src="Ucontrols/WUCSearchResultsTop.ascx" TagName="WUCSearchResultsTop" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc2" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<div id="astorTuesdays" class="page">
    <div id="mainContentHeader">
        <h1>15% Off Tuesdays</h1>
        <asp:Literal ID="lblResultTop" runat="server"><p>We pick the region...YOU pick the wine!</p></asp:Literal>
        <asp:Literal ID="lblResultBottom" runat="server"><p>Every Tuesday, our buyers pick a region or type of wine, spirit, or saké and mark it down 15%. Check out these sales:</p></asp:Literal>
    </div>

    <div>
        <uc2:WUCSearchResults ID="WUCSearchResults1" runat="server" />
    </div>
</div>
</asp:Content>