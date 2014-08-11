<%@ Page Language="VB" MasterPageFile="~/as_checkout.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorCheckoutBilling.aspx.vb" Inherits="secure_AstorCheckoutBilling" title="Astor Wines & Spirits - Checkout - Billing" %>
<%@ Register Src="~/Ucontrols/WUCCheckOutHeader.ascx" TagName="checkOutHeader" TagPrefix="awCOH" %>
<%@ Register Src="~/Ucontrols/WUCBillingName.ascx" TagName="billingNameFilled" TagPrefix="awBNF" %>
<%@ Register Src="~/Ucontrols/WUCBillingNameEdit.ascx" TagName="billingNameEdit" TagPrefix="awBNE" %>
<%@ Register Src="~/Ucontrols/WUCCreditCard.ascx" TagName="creditCardFilled" TagPrefix="awCCF" %>
<%@ Register Src="~/Ucontrols/WUCCreditCardEdit.ascx" TagName="creditCardEdit" TagPrefix="awCCE" %>
<%@ Register src="~/Ucontrols/WUCGiftCardEdit.ascx" tagname="WUCGiftCardEdit" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="checkOutBilling" class="checkout">
    
      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />

      <asp:ValidationSummary ID="vsBilling" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgBilling" />
      
      <asp:Panel runat="server" ID="pnlChkout">
        <div>
          <h2>Billing Address</h2>
          <div style="padding: 5px;">
            <awBNF:billingNameFilled ID="WUCBillingName1" runat="server" />
            <br />
            <asp:Button ID="lnkbEditBilling" runat="server" Text="Edit Billing Address" CssClass="btn" />
            
            <awBNE:billingNameEdit ID="WUCBillingNameEdit1" runat="server" />
          </div>
        </div>
        <br />
        <div>
          <div style="padding: 5px;">
          <h2>Credit Card</h2>
            <span class="formLabel"><asp:Literal ID="lblLCC" runat="server" Text="Saved Cards:" /></span><br />
            <div class="signInTxt">
              <asp:DropDownList ID="ddlCreditCard" runat="server" Width="283px" AutoPostBack="True" />
            </div>
            <div class="break"></div>
            <awCCF:creditCardFilled ID="WUCCreditCard1" runat="server" />
            <br />
              <asp:Button ID="lnkbAddCreditCard" runat="server" Text="Add New Credit Card" CssClass="btn" />
              <asp:Button ID="lnkbDeleteCreditCard" runat="server" Text="Delete Credit Card" OnClientClick="return confirm('Are you sure you want to delete this credit card?');" CssClass="btn" />
            
            <awCCE:creditCardEdit ID="WUCCreditCardEdit1" runat="server" EnableViewState="true" />
            <div class="break"></div>
            
            <h2 ID="gift-card-header">Gift Card</h2>
              <uc1:WUCGiftCardEdit ID="WUCGiftCardEdit1" runat="server" />
          </div>
        </div>
        <br style="clear: both;" />
        <div style="float: right;">
            <asp:ImageButton ID="imgbContinueCheckoutBottom" runat="server" ImageUrl="~/images/general/continue_button.gif" AlternateText="Continue Checkout" ToolTip="Continue Astor Checkout" ValidationGroup="vgBilling" />
        </div>
        <div style="clear: both;"></div>
      </asp:Panel>
  </div>

</asp:Content>