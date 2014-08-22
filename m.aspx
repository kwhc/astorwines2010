<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="m.aspx.vb" Inherits="m" title="Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/promo/after-hours-courier-service.ascx" TagName="afterHours" TagPrefix="p" %>
<%@ Register Src="~/Ucontrols/promo/free-shipping-first-order.ascx" TagName="freeShipping" TagPrefix="p" %>
<%@ Register Src="~/Ucontrols/promo/customer-survey.ascx" TagName="customerSurvey" TagPrefix="p" %>
<%@ Register Src="~/Ucontrols/promo/sale.ascx" TagName="sale" TagPrefix="p" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

<div id="modular" runat="server" style="width:606px;">        

    <p:sale runat="server" ID="ucSale" />

    <asp:PlaceHolder runat="server" ID="phPromo" />
   
</div>
  
</asp:Content>