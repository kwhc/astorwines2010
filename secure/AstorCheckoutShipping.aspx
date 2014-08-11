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
  <div id="shipping" class="checkout clearfix text-muted">

      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />
      <asp:Panel runat="server" DefaultButton="imgbContinueCheckoutBottom" ID="pnlChkout" Width="100%">

        <div id="shipping-addresses" class="container clearfix">
            <h2>Shipping Address</h2>

            <asp:ValidationSummary ID="vsShipping" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgShipping" style="margin-bottom:20px;" />    
                
            <aside>  
                <ul class="grid">
                    <li class="head">
                        <h3 class="checkout">Prohibited States</h3>             
                    </li>
                    <li>        
                        <div>
                            At this time we cannot ship to the following states:<br /><br />
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
                    <asp:PlaceHolder ID="phShippingAgreement" runat="server" Visible="True">
                        <div style="margin:10px 0px;background:#eee; padding:20px;">
                            <h4>Please Note:</h4>
                            <asp:Literal runat="server" ID="litThirdPartyNote" />
                        </div>
                        <asp:Literal runat="server" ID="litErrorShippingAgreement" Text="<div id='saError' class='callout-danger'>You must agree to the Shipping Agreement</div>" Visible="false" />
                        <div id="shippingAgreementContainer" style="background: #eee; padding: 20px;" runat="server">
                            <h4>
                                <asp:CheckBox runat="server" ID="chk3rdPartyShippingAgreement" TextAlign="Right" />
                                I agree to the <a href="#modal" class="mod-launch" rel="modal:open">Shipping Agreement</a>
                            </h4>
                            
                        </div>
                        <div id="modal" style="display: none;">
                            <h3>Shipping Agreement</h3>
                            <span class="text-muted"><%=cAstorMessaging.getMsg_ThirdPartyShippingAgreement()%></span>
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
                        <div style="margin-bottom:1rem;">
                            <h4>Select Your Shipping Method</h4>
                            <asp:RadioButtonList ID="rblShippingMethod" runat="server" Width="450px" RepeatLayout="Flow" AutoPostBack="True" />
                            <asp:RegularExpressionValidator ID="revShippingMethod" runat="server" ControlToValidate="rblShippingMethod"
                                ErrorMessage="Shipping Method Required!" ValidationExpression="^[0-9][0-9]*$" ValidationGroup="vgShipping">
                                <asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
                            </asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtzipcode" runat="server" Visible="False" />
                        </div>
                        
                        <asp:Panel ID="pnlDelDate" runat="server" Visible="False">
                            <div id="ShipDates" style="margin-bottom:1rem;">
                                <h4>Select Your Delivery Date<br /></h4>
                                <asp:RadioButtonList ID="rblDeliveryDates" runat="server" Width="450px" RepeatLayout="Flow" />
                            </div>
                        </asp:Panel>
                        
                        <asp:Panel runat="server" ID="pnlAfterHoursCourierTimes">
                            <div style="margin-bottom:1rem;">
                                <h4>Select Your Delivery Time</h4>
                                <asp:RadioButtonList runat="server" ID="rblAfterHoursCourierTimes" RepeatLayout="Flow" RepeatDirection="Horizontal" />
                            </div>
                    </asp:Panel>
                    </igmisc:webasyncrefreshpanel>
                </asp:Panel>
                
                <asp:Panel ID="pnlSpiritsPresent" runat="server">
                    <div class="callout-danger" style="margin-bottom:2rem;">
                        <h3 class="checkout" style="font-weight:bold;">Currently orders that contain spirits can only be shipped to New York State.</h3>
                        <p class="text-muted">Use the link below to remove these items if you wish to continue.</p>
                        <asp:LinkButton ID="imgbEditShoppingCart" runat="server" Text="View My Shopping Cart &raquo;" />
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlCommonCarrierRestricted">
                    <div class="callout-danger" style="margin-bottom:2rem;">
                        <h3 class="checkout" style="font-weight:bold;">There are items in this order that can only be shipped to Manhattan, Queens & Brooklyn.</h3>
                        <p class="text-muted">Use the link below to remove these items if you wish to continue.</p>
                        <asp:LinkButton ID="imgbEditShoppingCartCommonCarrierRestricted" runat="server" Text="View My Shopping Cart &raquo;" />
                    </div>
                        
                </asp:Panel>
                
                <asp:PlaceHolder runat="server" ID="phShippingMsg">
                    <div class="callout-info">
                        <asp:Literal ID="lblShippingMsg" runat="server" />
                    </div>
                </asp:PlaceHolder>
                
                <asp:PlaceHolder runat="server" ID="phMsgFreeDelivery">
                    <div class="callout-success">
                        <i class="icon-star"></i> <b>Your order meets our minimum for free delivery!</b>
                    </div>
                </asp:PlaceHolder>
                
                <asp:PlaceHolder runat="server" ID="phMsgFreeShippingNYS">
                    <div class="callout-success">
                        <i class="icon-star"></i> <b>Your order meets our $150 minimum for free ground shipping within New York State!</b>
                    </div>
                </asp:PlaceHolder>
                
                <asp:PlaceHolder runat="server" ID="phInsurance">
                    <div style="padding:1rem 0;">      
                        <h4>Shipping Insurance</h4>  
                        <div style="margin-bottom:1rem;"><asp:CheckBox runat="server" ID="chkShippingInsurance" Checked="true" TextAlign="Right" /> I would like to add shipping insurance for 1%</div>
                        <span><a href="#msg-insurance" rel="modal:open" class="mod-launch">What's this?</a></span>
                        <div id="msg-insurance" style="display:none;">                            
                            <%=cAstorMessaging.getMsg_ShippingInsurance %>
                            <p>You may decline insurance against loss or breakage by unchecking this box.</p>
                            <div><a href="#" rel="modal:close"><i class="icon-remove-sign"></i> close</a></div>
                        </div>
                    </div>
                </asp:PlaceHolder>   
            </div>
    
            <aside>
                <awShD:shippingDates ID="WUCShipDates1" runat="server" />
            </aside>

        </div> <!-- #shipping-method -->
        
        <div id="shippingNotes" class="" style="margin-bottom:2rem;">
            <h2><asp:Label runat="server" ID="lblShipInst" text="Delivery Notes" AssociatedControlID="txtShipInst" /></h2>
            <asp:TextBox ID="txtShipInst" runat="server" MaxLength="70" Width="500px" CssClass="grey" />
            <div class="help">(E.g., "buzz #34" or "do not deliver until May 1st.")</div>
        </div>
        
        <asp:Panel runat="server" ID="pnlPromoCode" Visible="false">
             <div ID="promo-code-container">
                  <h2 class="checkout">Promo Code</h2>
                  <div style="padding: 0px 10px 20px 10px;">
                  If you have a promotional code, enter it below and it will be applied to your order.<br /><br />
                  <asp:TextBox ID="txtPromo" runat="server" MaxLength="50" Width="261px" Wrap="False" CssClass="grey" />
                  </div>
              </div>
        </asp:Panel> 
        
        <div style="margin-bottom:2rem;">
          <h2 class="checkout">Gift Options</h2>
          <div style="padding: 10px;">
            <igmisc:webasyncrefreshpanel id="warpGift" runat="server" triggercontrolids="chkGift" triggerpostbackids="txtGiftNote" Width="375px" Height="220px">
              <asp:CheckBox ID="chkGift" runat="server" Text="Please check this box if you are sending a gift." AutoPostBack="True" />
              <br /><br />
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