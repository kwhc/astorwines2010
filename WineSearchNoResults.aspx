<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="WineSearchNoResults.aspx.vb" Inherits="WineSearchNoResults" title="Astor Wines & Spirits - Wines Search" %>

<%@ Register Src="~/Ucontrols/WUCNoResultTop.ascx" TagName="WUCNoResultTop" TagPrefix="uc7" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="wineSearchNoResult" class="no-results page clearfix">
      <uc7:WUCNoResultTop ID="WUCNoResultTop2" runat="server" />
      
      <div class="row">     
          <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="4" />
          </div>
          
          <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="5" />
          </div>
          
          <div style="height: 290px; float: left;">
            <uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="6" />
          </div>
      </div>
  </div>

</asp:Content>