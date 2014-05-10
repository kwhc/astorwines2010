<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="SearchNoResults.aspx.vb" Inherits="SearchNoResults" title="Astor Wines & Spirits - Search"%>

<%@ Register Src="~/Ucontrols/WUCNoResultTop.ascx" TagName="WUCNoResultTop" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="noResultsFound" class="info-page clearfix">

        <uc1:WUCNoResultTop ID="WUCNoResultTop2" runat="server" />

        <div style="margin-top: 20px;" class="clearfix">
            <div style="float: left; margin-right: 0px;">
                <uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="1" />
            </div>
            <div style="float: left; margin-right: 0px;">
                <uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="2" />
            </div>
            <div style="float: left;">
                <uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="3" />
            </div>
        </div>

    </div>
</asp:Content>