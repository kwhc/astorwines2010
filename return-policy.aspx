<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="return-policy.aspx.vb" Inherits="PrivacyPolicy" title="Return Policy | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="return-policy" class="info-page">
        <span class="muted" style="letter-spacing:.05rem;text-transform:uppercase;">Information</span>
        <h1 style="margin-bottom:1rem;">Our Return Policy</h1>
        <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" />  
        <p>
          Unopened spirits may be returned for a full refund. Defective wines, spirits, and sak&#233;s may be exchanged for items of equal or greater value. (Subject to the restrictions below.)
        </p>
      
        <h3>If You Bought Too Much:</h3>
        <p>
        To make event planning easier, Astor accepts returns on unopened bottles of spirits. If you have
    spirits left over after an event, you may return them, along with your original sales receipt, for a
    full refund within 30 days of purchase.
        </p>
        <p>
        We believe that proper storage is crucial to the quality of wines and sak&#233;s, and since we cannot
    control how items are stored after they leave our store, <strong>we do not issue refunds for wines or
    sak&#233;s.</strong>
        </p>
    
        <h2>If You Bought a Defective Item:</h2>
        <p>
        Astor stands behind all the wines, spirits, and sakés we sell. If you open a bottle and find that it is defective, we will gladly <strong>exchange</strong> it for a bottle of equal or greater value. If you exchange an item for one of greater value, you will be asked to provide the retail price difference, along with any applicable taxes, at the time of the exchange. We do not issue store credit. 
        </p>
        <p>
        Since we cannot control how bottles are stored once they leave our possession, we will only accept bottles for exchange within 30 days of purchase. Items to be returned are subject to evaluation by our staff, and must be accompanied by your original sales receipt. 
        </p>
        
        <h2>How to Return Items:</h2>
        <p>
        Bring your items back to Astor Wines & Spirits within 30 days of purchase, along with your original sales receipt. If your items were shipped or delivered, please call us at (212) 674-7500 to discuss your options. 
        </p>
        
        <h2>How We Issue Refunds and Exchanges:</h2>
        <p>
        Defective items may be exchanged for items of equal or greater value. Refunds on returned spirits will be issued in the original form of payment. 
        </p>
        
  </div>
</asp:Content>