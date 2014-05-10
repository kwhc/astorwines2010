<%@ Page Language="VB" MasterPageFile="~/as_checkout.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorCheckoutBillingNewCustomer.aspx.vb" Inherits="AstorCheckoutBillingNewCustomer" title="Astor Wines & Spirits - Checkout - Billing" %>

<%@ Register Src="~/Ucontrols/WUCCheckOutHeader.ascx" TagName="checkOutHeader" TagPrefix="awCOH" %>
<%@ Register Src="~/Ucontrols/WUCBillingNameEdit.ascx" TagName="billingNameEdit" TagPrefix="awBNE" %>
<%@ Register Src="~/Ucontrols/WUCCreditCardEdit.ascx" TagName="creditCardEdit" TagPrefix="awCCE" %>
<%@ Register src="~/Ucontrols/WUCGiftCardEdit.ascx" tagname="WUCGiftCardEdit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="newCustBilling" class="checkout clearfix">
      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />
      <br />
      <asp:ValidationSummary ID="vsBilling" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgBilling" />
     
      <!-- BEGIN BILLING ADDRESS SECTION -->
      <div id="billing-address" class="container clearfix">
        <h2>Billing Address</h2>
        
          <!-- BEGIN MATCH ME BOX -->
          <aside>
            <h3 class="checkout">Been to our store before?</h3>
            <div>
              <p>
              Enter your last name and the last 4 digits of your phone number and click "MATCH ME" 
              to bring up your account.</p>
              <p>If the match is wrong, click NOT ME to clear.</p>
              
              <asp:Panel runat="server" DefaultButton="imgbMatchMe" ID="Panel1">
                <div style="float: left; width: 170px;">
                    <asp:Label runat="server" ID="lblMatchMeLastname" AssociatedControlID="txtMatchMeLastname" Text="<br/>Last Name:" />
                    <asp:TextBox ID="txtMatchMeLastname" runat="server" TabIndex="1" Width="160px" MaxLength="100" CssClass="grey" />
                </div>
                <div style="float: right; width: 100px;">
                    <asp:Label runat="server" ID="lblMatchMePhone" AssociatedControlID="txtMatchMeLastname" Text="Last 4 digits of phone number:" />
                    <asp:TextBox ID="txtMatchMePhone" runat="server" TabIndex="2" MaxLength="4" Width="40px" CssClass="grey" />
                </div>
                
                <asp:Button ID="imgbMatchMe" runat="server" Text="Match Me" />
                <asp:Button ID="imgbNotMe" runat="server" Text="Not Me" />
              </asp:Panel>
            </div>
          </aside>
          <!-- END MATCH ME BOX -->
        
          <div>
            <awBNE:billingNameEdit ID="WUCBillingNameEdit1" runat="server" />
          </div>
                  
      </div> <!-- #billing-address -->
      <!-- END BILLING ADDRESS SECTION -->
            
      <div id="credit-card-info" class="container clearfix">
          <h2>Credit Card</h2>
          <asp:Panel runat="server" DefaultButton="imgbContinueCheckoutB" ID="pnlChkout">
            <awCCE:creditCardEdit ID="WUCCreditCardEdit1" runat="server" />
          </asp:Panel>
      </div>

        <div id="gift-card-info" class="container clearfix">
            <h2>Gift Card</h2>
            <uc1:WUCGiftCardEdit ID="WUCGiftCardEdit1" runat="server" />
        </div>
      
      <asp:ImageButton ID="imgbContinueCheckoutB" runat="server" TabIndex="18" ImageUrl="~/images/general/continue_button.gif" ValidationGroup="vgBilling" />

  </div> <!-- #newCustBilling -->
</asp:Content>