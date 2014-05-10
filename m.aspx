<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="m.aspx.vb" Inherits="m" title="Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/promo/empire-state-sale.ascx" TagName="empire" TagPrefix="p" %>
<%@ Register Src="~/Ucontrols/promo/italian-sale.ascx" TagName="italianSale" TagPrefix="p" %>
<%@ Register Src="~/Ucontrols/promo/after-hours-courier-service.ascx" TagName="afterHours" TagPrefix="p" %>
<%@ Register Src="~/Ucontrols/promo/free-shipping-first-order.ascx" TagName="freeShipping" TagPrefix="p" %>
<%@ Register Src="~/Ucontrols/promo/customer-survey.ascx" TagName="customerSurvey" TagPrefix="p" %>


<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

<div id="modular" style="width:606px;">        

    <asp:Panel runat="server" ID="pnlPMDelivery" Visible="false">
        <p:afterHours runat="server" ID="ucPMDelivery" />
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlFreeShipping" Visible="false">
        <p:freeShipping runat="server" ID="ucFreeSHipping" />
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlCustomerSurvey" Visible="false">
        <p:customerSurvey runat="server" ID="ucCustomerSurvey" />
    </asp:Panel>
    
</div>
  
</asp:Content>