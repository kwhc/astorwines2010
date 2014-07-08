<%@ Page Language="VB" MasterPageFile="~/as_checkout.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorCheckOutConfirmation.aspx.vb" Inherits="secure_AstorCheckOutConfirmation" title="Order Confirmation | Astor Wines & Spirits"%>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="WUCMyAccountNav" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCheckOutHeader.ascx" TagName="checkOutHeader" TagPrefix="awCOH" %>



<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="orderConfirmation" class="checkout-page">

      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />       
      <div style="clear: both;"></div>
        <div class="clearfix" style="margin-bottom:2rem;text-align:center;">
            <div style="margin-bottom:1rem;">
                <span style="display:block;font-size:2rem;margin-bottom:1rem;font-weight:bold;">Your order has been placed!</span>
                <asp:Literal ID="lblConfirm" runat="server" />
            </div>
            <ul class="inline" style="width:100%;display:block;margin-bottom:1rem;">
                <li><a class="icon-btn icon-btn-black" onclick="javascript:window.print()" id="imgPrintT"><span class="icon-stack icon-4x"><i class="icon-circle icon-stack-base"></i><i class="icon-print icon-light"></i></span></a><span class="serif muted" style="font-style:italic;">Print this page</span></li>
                <li><asp:LinkButton ID="imgbReturnTP" runat="server" CssClass="icon-btn icon-btn-black"><span class="icon-stack icon-4x"><i class="icon-circle icon-stack-base"></i><i class="icon-home icon-light"></i></span></asp:LinkButton><span class="serif muted" style="font-style:italic;">Return to Homepage</span></li>
            </ul>  
        </div>
    
        <div id="oc-email-map" style="margin-bottom:2rem;width:660px;margin-right:auto;margin-left:auto;">
            <h2>What to Expect Next</h2>
            <ul id="oc-email-list" class="inline" style="text-align:center;">
                <li>
                    <h4 class="email hider">Order Confirmation<br/>Email</h4>
                    <div style="font-style:italic;margin-bottom:1rem;">You'll receive this immediately from us.</div>
                    <div>This email details your order and verifies that it has been received and is currently being processed.</div>                
                </li>
                <asp:PlaceHolder runat="server" ID="phPaymentConfirmationEmail">
                <li>
                    <h4 class="email hider">Payment Confirmation<br/>Email</h4>
                    <div style="font-style:italic;margin-bottom:1rem;">You'll receive this within 24 hours from us.</div>
                    <div>This email tells you that your order has been approved, your payment has been processed and is packed and shipped. It will also contain your invoice.</div>
                </li>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phShippingConfirmationEmail">
                <li>
                    <h4 class="email hider">Shipping Confirmation<br/>Email</h4>
                    <div style="font-style:italic;margin-bottom:1rem;">You'll receive this within 24 hours from us.</div>
                    <div><p><asp:Literal runat="server" ID="litShippingConfirmationEmailDetail"/></p></div>                
                </li>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phTransferConfirmationEmail">
                <li>
                    <h4 class="email hider">Transfer Confirmation<br/>Email</h4>
                    <div style="font-style:italic;margin-bottom:1rem;">You'll receive this in 2-3 days from us.</div>
                    <div>This email tells you your order is packed and has been transfered to a third party. It will also contain your invoice</div>                
                </li>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phTrackingNumberEmail">
                <li>
                    <h4 class="email hider">Tracking Number<br/>Email</h4>
                    <div style="font-style:italic;margin-bottom:1rem;">You'll receive this in 3-4 days from <%=shipMethodTitle%>.</div>                
                    <div>
                        <asp:Literal runat="server" ID="litTrackingNumberEmailDetail"/>
                    </div>
                </li>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phAstorTruckDeliveryEmail">
                <li>
                    <h4 class="email hider">Delivery<br/>Email</h4>
                    <div style="font-style:italic;margin-bottom:1rem;">You'll receive this on your chosen delivery date from us.</div>                
                    <div>
                        <p>This email tells you that your order is on its way to you! It includes the delivery window you will receive your order.</p>
                    </div>
                </li>
                </asp:PlaceHolder>
            </ul>
      </div>
      
      <div id="oc-billing-information" style="margin-bottom:2rem;width:660px;margin-right:auto;margin-left:auto;">
        <h2>Billing Information</h2>
        <div>
          <div style="float: left; width:50%;">
            <div class="muted" style="text-transform:uppercase;">Bill To</div>          
            <div><asp:Literal ID="lblName" runat="server" /></div>
            <div><asp:Literal ID="lblCompany" runat="server" /></div>
            <div><asp:Literal ID="lblAddressApt" runat="server" /></div>
            <div><asp:Literal ID="lblCityStateZipcode" runat="server" /></div>
            <div><asp:Literal ID="lblDayPhone" runat="server" /></div>
            <div><asp:Literal ID="lblEveningPhone" runat="server" /></div>
            <div><asp:Literal ID="lblEmail" runat="server" /></div>
          </div>
          
          <div style="float: left; width:50%;">
            <div class="muted" style="text-transform:uppercase;">Payment Method</div>
            <div><asp:Literal ID="lblccType" runat="server" /></div>
            <div><asp:Literal ID="lblccNum" runat="server" /></div>
            <div>Exp: <asp:Literal ID="lblccExpDate" runat="server" /></div>
            <div><asp:Literal ID="litCreditCardAmount" runat="server" Visible="false" /></div>

             <asp:Panel ID="pnlGiftCard" runat="server">
              <h3>Gift Card</h3>
               Gift Card #: <asp:Literal ID="litGiftCardNumber" runat="server" /><br />
               * Anticipated Gift Card Amount: <asp:Literal ID="litGiftCardAmount" runat="server" /><br /><br />
                * Your credit card WILL NOT BE CHARGED unless the amount of your invoice exceeds the balance on your Gift Card. 
                  In that case, the amount of the difference will be charged to your credit card so that we can fulfill your entire order.
               
              </asp:Panel><br />
          </div>
          <div style="clear: both;"></div>
        </div>
      </div>
      
      <div id="oc-shipping-information" style="margin-bottom:2rem;width:660px;margin-right:auto;margin-left:auto;">
        <h2 class="signIn">Shipping Information</h2>
        <div class="clearfix">
          <div style="float: left; width:50%;">
            <div class="muted" style="text-transform:uppercase;">Ship To</div>          
            <div><asp:Literal ID="lblShipName" runat="server" /></div>
            <div><asp:Literal ID="lblShipCompany" runat="server" /></div>
            <div><asp:Literal ID="lblShipAddressApt" runat="server" /></div>
            <div><asp:Literal ID="lblShipCityStateZipcode" runat="server" /></div>
            <div><asp:Literal ID="lblScross" runat="server" /></div>
            <div><asp:Literal ID="lblShipEmail" runat="server" /></div>
            <div><asp:Literal ID="lblShipDayPhone" runat="server" /></div>
            <div><asp:Literal ID="lblShipEveningPhone" runat="server" /></div>
          </div>
          <div style="float: left; width:50%;">
            <div style="margin-bottom:1rem;">
                <div style="text-transform:uppercase;color:#aaa;">Shipping Method</div>
                <div><asp:Literal ID="lblShippingMethod" runat="server" /></div>
            </div>
            <div style="margin-bottom:1rem;">
                <div><asp:Literal ID="litShipDelDateL" runat="server" /></div>
                <div><asp:Literal ID="litShipDelDate" runat="server" /></div>
            </div>
            <div><asp:Literal ID="lblShipInst" runat="server" /></div>
          </div>
        </div>
      </div>
     
      <div id="oc-shipping-cart" style="margin-bottom:2rem;">
        <h2 class="signIn">Shopping Cart</h2>
        <div>
          <asp:DataList ID="datMyList" runat="server">
            <HeaderTemplate>
              <table style="width:100%; border-style: none;">
                <tr>
			      <td style="width:520px;">Item Name</td>
    		      <td style="width:40px;">Qty</td>
			      <td style="width:100px;">Unit Type</td>
				  <td style="width:75px;">Unit Price</td>
				  <td style="width:120px; text-align: right;">Item Total</td>
			    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
				  <td>
				    <div style="float:left;margin-right:12px;"><asp:Image runat="server" ID="litItemImg" ImageUrl='<%# "/images/itemimages/sm/"&rtrim(databinder.eval(container.dataitem, "Item"))&"_sm.jpg" %>' /></div>
				    <div style="padding-top:1rem;">
				        <asp:Literal ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>' />
 				        <div class="muted">Item#: <asp:Literal ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' /></div>
 				    </div>
 				  </td>
				  <td style="vertical-align:top;padding-top:1rem;">
				    <asp:Literal ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' />
				  </td>
			      <td style="vertical-align:top;padding-top:1rem;">
				    <asp:Literal ID="lblUnitType" runat="server" />
				  </td>
				  <td style="vertical-align:top;padding-top:1rem;">
				    <asp:Literal id="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' />
				  </td>
				  <td style="vertical-align:top;padding-top:1rem;text-align: right;">
				    <asp:Literal id="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' />
				  </td>
				</tr>
            </ItemTemplate>
            <FooterTemplate>
              </table>
            </FooterTemplate>
          </asp:DataList>
          <div class="clearfix" style="width:100%;border-top:solid 1px #ddd;padding-top:1rem;">
            <div style="float:left;text-align:right;width:85%;">
              Subtotal:<br />
              <asp:Literal ID="lblLShipping" runat="server" />
              <asp:Literal ID="lblL3rdPartyIns" runat="server" />
              <asp:Literal ID="lblLTax" runat="server" />
              <asp:Literal ID="lblLPromo" runat="server" />
              <strong>Total:</strong>
            </div>
            <div style="float:left;width:15%;text-align:right;">
              <asp:Label ID="lblSubTotal" runat="server" CssClass="muted"><%=String.Format("{0:C}", fSubTotal)%><br/></asp:Label>
              <asp:Label ID="lblShipping" runat="server" CssClass="muted"><%=String.Format("{0:C}", fShipping)%><br/></asp:Label>
              <asp:Label ID="lbl3rdPartyIns" runat="server" CssClass="muted"><%=String.Format("{0:C}", f3rdPartyInsurance)%><br/></asp:Label>
              <asp:Label ID="lblTax" runat="server" CssClass="muted"><%=String.Format("{0:C}", fTax)%><br/></asp:Label>
              <asp:Label ID="lblPromo" runat="server" CssClass="muted"><%=String.Format("{0:C}", fPromo)%><br/></asp:Label>
              <strong><asp:Label ID="lblTotal" runat="server"><%=String.Format("{0:C}", fTotal)%></asp:Label></strong>
            </div>
          </div>
        </div>
      </div>

<!-- Google Code for Order Confirmation Conversion Page -->
<script language="JavaScript" type="text/javascript">
<!--
var google_conversion_id = 1041725161;
var google_conversion_language = "en_US";
var google_conversion_format = "2";
var google_conversion_color = "ffffff";
var google_conversion_label = "Tl9rCPHBVBDp7d3wAw";
//-->
</script>
<script language="JavaScript" src="https://www.googleadservices.com/pagead/conversion.js">
</script>
<noscript>
<img height="1" width="1" border="0" src="https://www.googleadservices.com/pagead/conversion/1041725161/?label=Tl9rCPHBVBDp7d3wAw&amp;script=0"/>
</noscript>    
  </div>
</asp:Content>
<asp:Content contentplaceholderid="GAtracker" runat="Server" ID="content3">
  <asp:Literal ID="trackerScript" runat="server" />
</asp:Content>