<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorGlossary.aspx.vb" Inherits="AstorGlossary" %>

<%@ Register Src="~/Ucontrols/WUCGlossaryMain.ascx" TagName="WUCGlossaryMain" TagPrefix="uc16" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div class="page clearfix">
    <h1>Glossary</h1>
    <uc16:WUCGlossaryMain runat="server" />
  </div>
</asp:Content>
