<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SakeSearch.aspx.vb" Inherits="SakeSearch" title="Sak&#233; Search | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCBasePageTop.ascx" TagName="WUCBasePageTop" TagPrefix="uc4" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>
<%@ Register Src="~/Ucontrols/WUCTabbedSearchSake.ascx" TagName="tabbedSearchSake" TagPrefix="awTab" %>

<asp:Content ID="Content4" ContentPlaceHolderID="searchContent" Runat="Server">
        <awTab:tabbedSearchSake runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="sakeSearch" class="mainContent hub page">
        <h1>Sak&#233;</h1>

        <ul class="dailyFeaturesContainer clearfix container">
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="7" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="8" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="9" /></li>
        </ul> <!-- .dailyFeaturesContainer -->

    </div> <!-- sakeSearch -->
  
</asp:Content>