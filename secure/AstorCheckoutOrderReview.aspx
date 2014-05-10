<%@ Page Language="VB" MasterPageFile="~/as_checkout.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorCheckoutOrderReview.aspx.vb" Inherits="secure_AstorCheckoutOrderReview" title="Order Review | Astor Wines & Spirits" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<%@ Register Src="~/Ucontrols/WUCCheckOutHeader.ascx" TagName="checkOutHeader" TagPrefix="awCOH" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="orderReview">
    <div style="padding: 5px;">
      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />
      
      <br style="clear: right;" />
      
      <div>
        <h2 class="checkout">Billing Information</h2>
        <div style="padding: 5px;">
          <div style="float: left; width: 280px;">
            Name: <asp:Literal ID="lblName" runat="server"></asp:Literal><br />
            Company: <asp:Literal ID="lblCompany" runat="server"></asp:Literal><br />
            Address: <asp:Literal ID="lblAddressApt" runat="server"></asp:Literal><br />
            City/State/Zip: <asp:Literal ID="lblCityStateZipcode" runat="server"></asp:Literal><br />
            Day Phone: <asp:Literal ID="lblDayPhone" runat="server"></asp:Literal><br />
            Evening Phone: <asp:Literal ID="lblEveningPhone" runat="server"></asp:Literal><br />
            Email Address: <asp:Literal ID="lblEmail" runat="server"></asp:Literal><br /><br />
            <asp:LinkButton ID="imgbEditBillingAddress" runat="server" Text="Edit Billing Address" />
          </div>
          <div style="float: right; width: 280px;">
            Credit Card: <asp:Literal ID="lblccType" runat="server"></asp:Literal><br />
            Credit Card #: <asp:Literal ID="lblccNum" runat="server"></asp:Literal><br />
            Expires: <asp:Literal ID="lblccExpDate" runat="server"></asp:Literal><br /><br />
           
              <asp:Panel ID="pnlGiftCard" runat="server">
              <h3 class="checkout">Gift Card</h3>
               Gift Card #: <asp:Literal ID="litGiftCardNumber" runat="server"></asp:Literal><br />
               * Current Gift Card Amount: <asp:Literal ID="litGiftCardAmount" runat="server"></asp:Literal>
               <br /><br />
               <span class="note">
               * Your credit card WILL NOT BE CHARGED unless the amount of your invoice exceeds the balance on your Gift Card. In that case, the amount of the difference will be charged to your credit card so that we can fulfill your entire order.
               </span>
              </asp:Panel><br />
               <asp:LinkButton ID="imgbEditCreditCardInfo" runat="server" Text="Edit Billing Method" />
          </div>
          <div style="clear: both;"></div>
        </div>
      </div>
      <div class="break"></div>
      <div>
        <h2 class="checkout">Shipping Information</h2>
        <div style="padding: 5px;">
          <div style="float: left; width: 280px;">
            Name: <asp:Literal ID="lblShipName" runat="server"></asp:Literal><br />
            Company: <asp:Literal ID="lblShipCompany" runat="server"></asp:Literal><br />
            Address: <asp:Literal ID="lblShipAddressApt" runat="server"></asp:Literal><br />
            City/State/Zip: <asp:Literal ID="lblShipCityStateZipcode" runat="server"></asp:Literal><br />
            <asp:Literal ID="lblScross" runat="server"></asp:Literal><br />
            Shipping Email: <asp:Literal ID="lblShipEmail" runat="server"></asp:Literal><br />
            Day Phone: <asp:Literal ID="lblShipDayPhone" runat="server"></asp:Literal><br />
            Evening Phone: <asp:Literal ID="lblShipEveningPhone" runat="server"></asp:Literal><br /><br />
            <asp:LinkButton ID="imgbEditShippingAddress" runat="server" Text="Edit Shipping Info" />
          </div>
          <div style="float: right; width: 280px;">
            Shipping Method: <asp:Literal ID="lblShippingMethod" runat="server"></asp:Literal><br />
            <asp:Literal ID="litShipDelDate" runat="server"></asp:Literal><br />
            <asp:Literal ID="lblShipInst" runat="server"></asp:Literal><br />
            <asp:Literal ID="lblPromoCode" runat="server"></asp:Literal><br />
            <asp:LinkButton ID="imgbEditShippingMethod" runat="server" Text="Edit Shipping Method" />
          </div>
          <div style="clear: both;"></div>
        </div>
      </div>
      <asp:PlaceHolder ID="SpecialInfoPlace" runat="server">
        <div class="break"></div>
        <div style="border: solid 1px #50340C;">
          <h2 class="signIn">Gift Message</h2>
          <div style="padding: 5px;">
            <asp:Literal ID="lblGiftNote" runat="server"></asp:Literal>
          </div>
        </div>
      </asp:PlaceHolder>
      <div class="break"></div>
      <div>
        <h2 class="checkout">My Order</h2>
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
			   <tr><td colspan="6"><div style="border-bottom: dotted 1px #bbbbbb;"><br /></div> </td></tr> 
			   
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
				  <td>
			        <input id="ShoppingCartID" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "ShoppingCartID", "{0:g}") %>' runat="server" name="ShoppingCartID" />
					<input id="OrigQuantity" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' runat="server" name="OrigQuantity" />
					<asp:Literal ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>'></asp:Literal>
				  </td>
				  <td>
				    <asp:Literal ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>'></asp:Literal>
 				  </td>
				  <td>
				    <asp:Literal ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>'></asp:Literal>
				  </td>
			      <td>
					<asp:Literal ID="lblUnitType" runat="server" />
				  </td>
				  <td>
					<asp:Literal id="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>'></asp:Literal>
				  </td>
				  <td style="text-align: right;">
					<asp:Literal id="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>'></asp:Literal>
				  </td>
				</tr>
            </ItemTemplate>
            <FooterTemplate>
              </table>
            </FooterTemplate>
          </asp:DataList>
         <br /> 
          <div style="float: right; width: 320px; padding-right: 3px; border-top: dotted 1px #bbbbbb;">
            <div style="float: left; text-align: right;">
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
          <asp:LinkButton ID="imgbEditShoppingCart" runat="server" Text="Edit Shopping Cart" />
        </div>
      </div>
      <div style="float: right;">
        <asp:ImageButton ID="imgbSubmitB" runat="server" ImageUrl="~/images/general/btn_placeOrder.gif" ValidationGroup="vgReview" />
      </div>
      <div style="clear: right;"></div>
    </div>
  </div>
</asp:Content>