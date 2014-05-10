<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SpiritsSearchNoResults.aspx.vb" Inherits="SpiritsSearchNoResults" title="Spirits Search | Astor Wines & Spirits"%>

<%@ Register Src="~/Ucontrols/WUCNoResultTop.ascx" TagName="WUCNoResultTop" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCTabbedSearchSpirits.ascx" TagName="tabbedSearchSpirits" TagPrefix="awTab" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="searchContent">
    <awTab:tabbedSearchSpirits id="tabbedSearchSpirits" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="spiritSearchNoResults" class="no-results page clearfix">
        <uc1:WUCNoResultTop ID="WUCNoResultTop2" runat="server" />
       
        <div class="row">
            <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="10" />
            </div>
            <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="11" />
            </div>
            <div style="height: 290px; float: left">
            <uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="12" />
            </div>
        </div>   
    </div>
     
</asp:Content>