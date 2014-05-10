<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Features.aspx.vb" Inherits="Features" title="Astor Wines & Spirits - Features" %>

<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc4" %>
<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="featurePage" class="page">
    <!-- <h1 class="mainHeader">Featured Items</h1> -->
    <div>
      <h2 class="featureSecondHeader" style="padding-left: 5px;"><asp:Literal ID="featureHeader" runat="server"></asp:Literal></h2>
      <div style="padding: 5px;">
        <div style="float: right; margin: 5px 5px 5px 15px;"><asp:Image ID="imgFeature" runat="server" Width="270" GenerateEmptyAlternateText="true" /></div>
        <asp:Literal ID="litFeature" runat="server"></asp:Literal>
        <span>&nbsp;</span>
        <div style="clear: right;"></div>
      </div>
    </div>
    <div id="searchResultsContainer">
        <uc4:WUCSearchResults ID="WUCSearchResults1" runat="server" />
    </div>
  </div>
</asp:Content>