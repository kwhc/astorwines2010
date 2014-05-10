<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" CodeFile="AstorGeneralInformation.aspx.vb" Inherits="AstorGeneralInformation" title="Astor Wines & Spirits - General Information" EnableEventValidation="false" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
 <div id="featurePage">
    <h1 class="mainHeader">Astor Information</h1>
    <div style="padding: 5px;">
      <h2 class="featureSecondHeader" style="padding-left: 5px;">
      <asp:Literal ID="featureHeader" runat="server"></asp:Literal></h2>
      <div style="padding: 5px; border: solid 1px #50340C;">
        <div style="float: right; margin: 5px 10px 5px 10px; border: solid 1px #50340C;">
        <!--<asp:Image ID="imgGeneralInfoHeader" runat="server" ImageUrl="~/images/as_generalinformation_hd.gif" GenerateEmptyAlternateText="true" />-->
        <asp:HyperLink ID="hyplFeature" runat="server" ImageUrl="~/images/as_generalinformation_1_1.gif" style="float: right" Target="_blank" ></asp:HyperLink>
                                    </div>
        <asp:Literal ID="litGeneralInfo" runat="server"></asp:Literal>
      </div>
    </div>
    </div>
</asp:Content>


