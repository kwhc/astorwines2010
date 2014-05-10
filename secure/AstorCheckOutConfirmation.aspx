<%@ Page Language="VB" MasterPageFile="~/as_checkout.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorCheckOutConfirmation.aspx.vb" Inherits="secure_AstorCheckOutConfirmation" title="Order Confirmation | Astor Wines & Spirits"%>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="WUCMyAccountNav" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCheckOutHeader.ascx" TagName="checkOutHeader" TagPrefix="awCOH" %>



<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="orderConfirmation">

      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />       
      <div style="clear: both;"></div>
      <br />
      <div style="float: left; width: 600px;">
        <asp:Literal ID="lblConfirm" runat="server" /><br />
        <br />
        You will receive a confirmation email shortly detailing your order. Within
        24 hours your order should be approved and you will receive an email informing you
        of the ship date from our shop.<br />
        <br />
      </div>
      <div style="float: left; border-left: #dddddd 1px dotted; border-bottom: #dddddd 1px dotted; padding: 5px;">
            <a style="cursor: pointer;" onclick="javascript:window.print()" id="imgPrintT">Print this page</a>
            <br />
            <asp:LinkButton ID="imgbReturnTP" runat="server" Text="Return to Astor Wines Home Page" />
        </div>
      
      <br style="clear: both;" />
      
      <div>
        <h2>Billing Information</h2>
        <div style="padding: 5px;">
          <div style="float: left; width: 300px;">
          <table>
            <tr>
                <td>
                Name:
                </td>
                <td>
                <asp:Literal ID="lblName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                Company:
                </td>
                <td>
                <asp:Literal ID="lblCompany" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                Address:
                </td>
                <td>
                <asp:Literal ID="lblAddressApt" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                City/State/Zip:
                </td>
                <td>
                <asp:Literal ID="lblCityStateZipcode" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                Day Phone:
                </td>
                <td>
                <asp:Literal ID="lblDayPhone" runat="server" />
                </td>
            </tr>            
            <tr>
                <td>
                Evening Phone:
                </td>
                <td>
                <asp:Literal ID="lblEveningPhone" runat="server" />
                </td>
            </tr>             
            <tr>
                <td>
                Email:
                </td>
                <td>
                <asp:Literal ID="lblEmail" runat="server" />
                </td>
            </tr> 
          </table>
          </div>
          
          <div style="float: left; width: 300px;">
          <h3>Credit Card</h3>
          <table>
            <tr>
                <td>
                Credit Card:
                </td>
                <td>
                <asp:Literal ID="lblccType" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                Credit Card #:
                </td>
                <td>
                <asp:Literal ID="lblccNum" runat="server" />
                </td>
            </tr>          
            <tr>
                <td>
                Expiration Date:
                </td>
                <td>
                <asp:Literal ID="lblccExpDate" runat="server" />
                </td>
            </tr> 
            <tr>
                <td>
                Credit Card Amount:
                </td>
                <td>
                <asp:Literal ID="litCreditCardAmount" runat="server" />
                </td>
            </tr>                     
          </table>

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
      <div class="break"></div>
      <div>
        <h2 class="signIn">Shipping Information</h2>
        <div style="padding: 5px;">
          <div style="float: left; width: 300px;">
            <table>
                <tr>
                    <td>
                    Name:
                    </td>
                    <td>
                    <asp:Literal ID="lblShipName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    Company:
                    </td>
                    <td>
                    <asp:Literal ID="lblShipCompany" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    Address:
                    </td>
                    <td>
                    <asp:Literal ID="lblShipAddressApt" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    City/State/Zip:
                    </td>
                    <td>
                    <asp:Literal ID="lblShipCityStateZipcode" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    
                    </td>
                    <td>
                    <asp:Literal ID="lblScross" runat="server" />
                    </td>
                </tr>
                 <tr>
                    <td>
                    Shipping Email:
                    </td>
                    <td>
                    <asp:Literal ID="lblShipEmail" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    Day Phone:
                    </td>
                    <td>
                    <asp:Literal ID="lblShipDayPhone" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    Evening Phone:
                    </td>
                    <td>
                    <asp:Literal ID="lblShipEveningPhone" runat="server" />
                    </td>
                </tr>
            </table>
          </div>
          <div style="float: left; width: 300px;">
          <table>
              <tr>
                <td>
                Shipping Method:
                </td>
                <td>
                <asp:Literal ID="lblShippingMethod" runat="server" />    
                </td>
              </tr>
               <tr>
                <td>
                 <asp:Literal ID="litShipDelDateL" runat="server" />
                </td>
                <td>
                <asp:Literal ID="litShipDelDate" runat="server" />    
                </td>
              </tr>
              <tr>
                <td>
                </td>
                <td>
                <asp:Literal ID="lblShipInst" runat="server" />
                </td>
              </tr>
          </table>
            
          </div>
          <div style="clear: both;"></div>
        </div>
      </div>
      <div class="break"></div>
      <div>
        <h2 class="signIn">Shopping Cart</h2>
        <div style="padding: 5px;">
          <asp:DataList ID="datMyList" runat="server">
            <HeaderTemplate>
              <table style="width: 100%; border-style: none;">
                <tr>
    	          <td style="width: 50px;">Item #</td>
			      <td style="width: 345px;">Item Name</td>
    		      <td style="width: 60px;">Quantity</td>
			      <td style="width: 100px;">Unit Type</td>
				  <td style="width: 75px;">Unit Price</td>
				  <td style="width: 75px; text-align: right;">Item Total</td>
			    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                  <td>
       			    <asp:Literal ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' />
				  </td>
				  <td>
				    <asp:Literal ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>' />
 				  </td>
				  <td>
				    <asp:Literal ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' />
				  </td>
			      <td>
				    <asp:Literal ID="lblUnitType" runat="server" />
				  </td>
				  <td>
				    <asp:Literal id="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' />
				  </td>
				  <td style="text-align: right;">
				    <asp:Literal id="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' />
				  </td>
				</tr>
            </ItemTemplate>
            <FooterTemplate>
              </table>
            </FooterTemplate>
          </asp:DataList>
          <div style="float: right; width: 320px; padding-right: 3px;">
            <div style="float: left;text-align: right;">
              Subtotal:<br />
              <asp:Literal ID="lblLShipping" runat="server" /><br />
              <asp:Literal ID="lblL3rdPartyIns" runat="server" /><br />
              <asp:Literal ID="lblLTax" runat="server" /><br />
              <asp:Literal ID="lblLPromo" runat="server" /><br />
              
              <strong>Total:</strong>
            </div>
            <div style="float: right; width: 100px; text-align: right;">
              <asp:Label ID="lblSubTotal" runat="server"><%=String.Format("{0:C}", fSubTotal)%></asp:Label><br />
              <asp:Label ID="lblShipping" runat="server"><%=String.Format("{0:C}", fShipping)%></asp:Label><br />
              <asp:Label ID="lbl3rdPartyIns" runat="server"><%=String.Format("{0:C}", f3rdPartyInsurance)%></asp:Label><br />
              <asp:Label ID="lblTax" runat="server"><%=String.Format("{0:C}", fTax)%></asp:Label><br />
              <asp:Label ID="lblPromo" runat="server"><%=String.Format("{0:C}", fPromo)%></asp:Label><br />
              
              <strong><asp:Label ID="lblTotal" runat="server"><%=String.Format("{0:C}", fTotal)%></asp:Label></strong>
            </div>
            <div style="clear: left;"></div>
          </div>
          <div style="clear: right;"></div>
        </div>
      </div>
      <div class="break"></div>
      <div style="float: right;">
        <a style="cursor: pointer;" onclick="javascript:window.print()">Print this page</a>
      </div>
      <div style="clear: right;"></div>

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