<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SakeSearchNoResults.aspx.vb" Inherits="SakeSearchNoResults" title="Sak&#233; Search | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCNoResultTop.ascx" TagName="WUCNoResultTop" TagPrefix="uc7" %>
<%@ Register Src="~/Ucontrols/WUCTabbedSearchSake.ascx" TagName="tabbedSearchSake" TagPrefix="awTab" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>

<asp:Content id="Content4" ContentPlaceHolderID="searchContent" Runat="Server">
  <awTab:tabbedSearchSake id="TabbedSearchSake1" runat="server" />
</asp:Content>
<asp:Content id="Content5" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="sakeSearchNoResults" class="no-results page clearfix">
        <uc7:WUCNoResultTop id="WUCNoResultTop2" runat="server" />
        <div class="row">
            <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures id="WUCDailyFeatures1" runat="server" feature="7" />
            </div>
            <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures id="WUCDailyFeatures2" runat="server" feature="8" />
            </div>
            <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures id="WUCDailyFeatures3" runat="server" feature="9" />
            </div>
        </div> 
    </div>
</asp:Content>