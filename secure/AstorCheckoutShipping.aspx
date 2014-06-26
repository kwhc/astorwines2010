<%@ Page Language="VB" MasterPageFile="~/as_checkout.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorCheckoutShipping.aspx.vb" Inherits="secure_AstorCheckoutShipping" title="Shipping | Checkout | Astor Wines & Spirits" %>

<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="WUCMyAccountNav" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCCheckOutHeader.ascx" TagName="checkOutHeader" TagPrefix="awCOH" %>
<%@ Register Src="~/Ucontrols/WUCShippingName.ascx" TagName="shippingNameFilled" TagPrefix="awSNF" %>
<%@ Register Src="~/Ucontrols/WUCShippingNameEdit.ascx" TagName="shippingNameEdit" TagPrefix="awSNE" %>
<%@ Register Src="~/Ucontrols/WUCShipDates.ascx" TagName="shippingDates" TagPrefix="awShD" %>
<%@ Register Src="~/Ucontrols/deliveryAlert.ascx" TagPrefix="alert" TagName="shipping" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="shipping" class="checkout clearfix">

      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />
      <asp:Panel runat="server" DefaultButton="imgbContinueCheckoutBottom" ID="pnlChkout" Width="100%">

        <div id="shipping-addresses" class="container clearfix">
            <h2>Shipping Address</h2>

            <asp:ValidationSummary ID="vsShipping" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgShipping" style="margin-bottom:20px;" />    
                
            <aside>  
                <ul class="grid">
                    <li class="head">
                        <h3 class="checkout">Eligible Delivery States</h3>             
                    </li>
                    <li>        
                        <div>
                            At this time we ONLY ship to the following states:<br /><br />
                            <asp:Literal ID="lblShipToStatesCodes" runat="server" />
                        </div>
                    </li>
                </ul>
            </aside>

            <asp:PlaceHolder runat="server" ID="phSavedShippingAddresses">
                <div id="saved-shipping-addresses" class="container">
                    <asp:Literal ID="lblLShipping" runat="server" Text="Saved Shipping Addresses:" /><br />
                    <asp:DropDownList ID="ddlShipping" runat="server" AutoPostBack="True" Width="283px" />
                    <asp:Button ID="lnkbAddShipping" runat="server" Text="+ Add New Address" CssClass="btn" />
                </div> 
            </asp:PlaceHolder>

            <div style="float: left; width: 450px;">
                <awSNF:shippingNameFilled ID="WUCShippingName1" runat="server" /><br />
                <asp:Button ID="lnkbEditShipping" runat="server" Text="Edit Shipping Address" CssClass="btn" />
                <asp:Button ID="lnkbDeleteShipping" runat="server" Text="Delete Shipping Address" OnClientClick="return confirm('Are you sure you want to delete this shipping address?');" CssClass="btn" />

                <awSNE:shippingNameEdit ID="WUCShippingNameEdit1" runat="server" />
                
                <asp:Panel ID="pnlRoyalShipping" runat="server">
                    <asp:Literal runat="server" ID="litErrorShippingAgreement" Text="<span id='saError' style='color:red;'>You must agree to the Shipping Agreement</span>" Visible="false" />
                    <asp:PlaceHolder ID="phShippingAgreement" runat="server" Visible="True">
                        <div style="margin:10px 0px;background:#eee; padding:20px;">
                            <h4>Please Note:</h4>
                            <p>
                            <asp:Literal runat="server" ID="litThirdPartyNote" />
                            </p>
                        </div>
                        <div id="shippingAgreementContainer" style="background: #eee; padding: 20px;" runat="server">
                            <h4>
                                <asp:CheckBox runat="server" ID="chk3rdPartyShipInsAgreement" TextAlign="Right" />
                                I agree to the <a href="#modal" class="mod-launch" rel="modal:open">Shipping Agreement</a>
                            </h4>
                            <h4>
                                <asp:CheckBox runat="server" ID="chk3rdPartyShipIns" Checked="true" TextAlign="Right" />
                                I would like to add shipping insurance for 1%</h4>
                        </div>
                        <div id="modal" style="display: none;">
                            <h3>Shipping Agreement</h3>
                            As your agent, we can assist in selecting a common carrier for the shipment of wine
                            that you have purchased and own. The majority of states maintain laws and regulations
                            that control or restrict the importation of alcohol. In all cases, the purchaser
                            is responsible for complying with the laws and regulations, including in particular
                            those relating to the import of alcohol, in effect in the state to which the purchaser
                            is shipping alcohol.
                            <div>
                                <a href="#" rel="modal:close"><i class="icon-remove-sign"></i> close</a></div>
                        </div>
                    </asp:PlaceHolder>
                </asp:Panel>
                <br />
            </div>
        </div>
        
        <div id="shipping-method" class="container clearfix">
        
            <h2>Shipping Method</h2>

            <alert:shipping runat="server" ID="ucShippingAlert" />

            <div style="float: left; width: 450px;">
                <asp:Panel ID="pnlShippingMethod" runat="server">
                    <igmisc:webasyncrefreshpanel id="warpDelivery" runat="server" triggercontrolids="rblShippingMethod" triggerpostbackids="rblDeliveryDates" Width="450px" >
                    <div style="margin-bottom:2rem;">
                        <h4>Select Your Shipping Method</h4>
                        <asp:RadioButtonList ID="rblShippingMethod" runat="server" Width="250px" RepeatLayout="Flow" AutoPostBack="True" />
                        <asp:RegularExpressionValidator ID="revShippingMethod" runat="server" ControlToValidate="rblShippingMethod"
                            ErrorMessage="Shipping Method Required!" ValidationExpression="^[0-9][0-9]*$" ValidationGroup="vgShipping">
                            <asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
                        </asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtzipcode" runat="server" Visible="False" />
                    </div>
                    
                    <div id="ShipDates" style="margin-bottom:2rem;">
                        <asp:Panel ID="pnlDelDate" runat="server" Visible="False">
                            <h4>Select Your Delivery Date<br /></h4>
                            <asp:RadioButtonList ID="rblDeliveryDates" runat="server" Width="250px" RepeatLayout="Flow" />
                        </asp:Panel>
                    </div>
                    
                    <asp:Panel runat="server" ID="pnlAfterHoursCourierTimes">
                        <div style="margin-bottom:2rem;">
                            <h4>Select Your Delivery Time</h4>
                            <asp:RadioButtonList runat="server" ID="rblAfterHoursCourierTimes" RepeatLayout="Flow" RepeatDirection="Horizontal" />
                        </div>
                    </asp:Panel>
                    </igmisc:webasyncrefreshpanel>
                </asp:Panel>
                
                <asp:Panel ID="pnlSpiritsPresent" runat="server">
                    <div style="margin-bottom:2rem;">
                    <h3 class="checkout">Currently orders that contain <b>spirits</b> can only be shipped to <b>New York State</b> and must also <b>meet our delivery minimum</b>.</h3>
                    <h3 class="checkout">Use the link below to add some items to your order or remove the spirits items if you wish to continue.</h3>
                    <asp:LinkButton ID="imgbEditShoppingCart" runat="server" Text="Edit Shopping Cart" />
                    </div>
                </asp:Panel>
                <asp:Literal ID="lblShippingMsg" runat="server" Visible="False" />
                <br />
                             
                <asp:Label runat="server" ID="lblShipInst" text="Delivery Notes:" AssociatedControlID="txtShipInst" /><br />
                <div class="help">(E.g., "buzz #34" or "do not deliver until May 1st.")</div>
                <asp:TextBox ID="txtShipInst" runat="server" MaxLength="70" Width="500px" CssClass="grey" />
                <br />
                <br />
                <img ID="free-shipping-sticker" src="../images/general/img_free_ship_circle_180.png" alt="Free Shipping on First-Time Orders!" width="160" height="160" />
              
            </div>
    
            <aside>
                <awShD:shippingDates ID="WUCShipDates1" runat="server" />
            </aside>

</div> <!-- #shipping-method -->
        
        <asp:Panel runat="server" ID="pnlPromoCode" Visible="false">
             <div ID="promo-code-container">
                  <h2 class="checkout">Promo Code</h2>
                  <div style="padding: 0px 10px 20px 10px;">
                  If you have a promotional code, enter it below and it will be applied to your order.<br /><br />
                  <asp:TextBox ID="txtPromo" runat="server" MaxLength="50" Width="261px" Wrap="False" CssClass="grey" />
                  </div>
              </div>
         </asp:Panel> 
          <div class="break"></div>
        <div>
          <h2 class="checkout">Gift Options</h2>
          <div style="padding: 10px;">
            <igmisc:webasyncrefreshpanel id="warpGift" runat="server" triggercontrolids="chkGift" triggerpostbackids="txtGiftNote" Width="375px" Height="220px">
              <asp:CheckBox ID="chkGift" runat="server" Text="Please check this box if you are sending a gift." AutoPostBack="True" /><br /><br />
              <strong>Personal Message:</strong> <span style="font-size: 10px;">(500 characters maximum)</span>
              <asp:TextBox id="txtGiftNote" runat="server" Width="371px" MaxLength="500" TextMode="MultiLine" Height="174px" /><br />
            </igmisc:webasyncrefreshpanel>
          </div>
        </div>
        <div style="float: right;">
            <asp:ImageButton ID="imgbContinueCheckoutBottom" runat="server" ImageUrl="~/images/general/continue_button.gif" AlternateText="Continue Checkout" ToolTip="Continue Astor Checkout" ValidationGroup="vgShipping" />
            <asp:ImageButton ID="imgbNotContinueCheckoutBottom" runat="server" ImageUrl="~/images/general/continue_button_dim.png" AlternateText="Cannot Continue Checkout" ToolTip="Cannot Continue Astor Checkout" />
        </div>

      </asp:Panel>
  </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cphJSAdd" ID="cJSAdd">
    <asp:Literal runat='server' ID='litCheckboxID' Visible="false" />
    <asp:Literal runat="server" ID="litMessageID" Visible="false" />
    <asp:Literal runat="server" ID="litSAContainer" Visible="false" />
   
    <script type="text/javascript">
        var checkbox = "#<%= litCheckboxId.Text %>";
        var litMessageID = "#<%= litMessageID.Text %>";
        var SAContainer = "#<%= litSAContainer.Text %>";

        $(checkbox).change(function() {
            if (this.checked) {
                $('#saError').toggle('slow');
                $(SAContainer).css({ border: 'none' });
            }
            else {
                $('#saError').toggle('slow');
                $(SAContainer).css({ border: 'solid 2px red' });
                
            }
        });
    </script>
</asp:Content>