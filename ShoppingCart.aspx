<%@ Page Language="VB" MasterPageFile="~/noColumns.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="ShoppingCart.aspx.vb" Inherits="ShoppingCart" title="Astor Wines & Spirits - My Shopping Cart" %>

<%@ Register Src="~/Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc2" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="~/Ucontrols/deliveryAlert.ascx" TagName="DeliveryAlert" TagPrefix="alert" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  
<div id="shoppingcart" class="clearfix">

<div class="no-column-page">
       <alert:DeliveryAlert runat="server" ID="deliveryAlert" Visible="true" />           

        <div id="alertcontainer" class="clearfix">
        <ul class="inline" style="float:right;">
            <li>        
                <div class="clearfix">
                    <img src="images/general/img_free_shipping_sticker_300x75.png" alt="Free Shipping on First-Time Orders!" style="float:right;margin-bottom: 12px;" />   
                </div>
            </li>

            <asp:Placeholder ID="pnlSignIn" runat="server">
            <li>
            <div class="clearfix">
                <div id="save-cart" style="margin-bottom: 12px;">
                    <img src="images/general/save-cart-elephant.png" alt="Save Your Cart!" class="elephant" />
                    <span>Want to save your cart? </span>
                    <asp:LinkButton ID="lnkbSignInNow" runat="server" Text="Sign In Now!"><img src="images/buttons/btn_save-cart-sign-in.png" alt="Sign In or Sign Up Here" class="sign-in" /></asp:LinkButton>
                </div>
            </div>
            </li>
            </asp:Placeholder>        
        </ul>         
        </div> <!-- #alertContainer -->


       <asp:Label ID="status" runat="server" Visible="true" CssClass="noItems" />

        <a id="top"></a>

        <br />

        <asp:DataList ID="datMyList" runat="server">
        <HeaderTemplate>
            <table class="cart-table" id="header-row">
               <tr valign="top">
		            <td class="cartItemName"><asp:Label ID="Label2" runat="server" Text="Item" CssClass=ShoppingCarthead />
		            </td>
		            <td class="cartUnitPrice"><asp:Label ID="Label5" runat="server" Text="Unit Price" CssClass=ShoppingCarthead />
		            </td>
		            <td class="cartQty"><asp:Label ID="Label3" runat="server" Text="Qty" CssClass=ShoppingCarthead />
		            </td>
		            <td class="cartUnitTot"><asp:Label ID="Label6" runat="server" Text="Unit Total" CssClass=ShoppingCarthead />
		            </td>
		            <td class="cartRem"><asp:Label ID="lblRemoveHd" runat="server" Text="Remove" CssClass=ShoppingCarthead />
		            </td>
	            </tr>
	         </table>
        </HeaderTemplate>

        <ItemTemplate>
            <table class="cart-table">
                <tr>
                    <td class="cartItemName">
                        <input id="ShoppingCartID" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "ShoppingCartID", "{0:g}") %>'
                            runat="server" name="ShoppingCartID" />
                        <input id="OrigQuantity" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>'
                            runat="server" name="OrigQuantity" />
                        <div class="item-image">
                            <asp:HyperLink ID="hyplItemPic" runat="server" />
                        </div>
                        <!-- .item-image -->
                        <asp:HyperLink ID="hyplItemName" runat="server"><%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
                        <asp:Label ID="lblLimitedQty" runat="server" Text="Limited Production:  Only X bottle(s) per customer"
                            Visible="False"></asp:Label>
                        <div class="item-meta">
                            Item #:<asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' />
                            | Unit Type:<asp:Label ID="lblUnitType" runat="server" />
                        </div>
                        <!-- .item-meta -->
                    </td>
                   
	               <td class="cartUnitPrice">
	                    <asp:label id="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' />
                   </td>
        			
		           <td class="cartQty">
		                <igtxt:WebNumericEdit id=wneQuantity runat="server" BackColor="White" Font-Bold="False" 
					        ReadOnly="false" Value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' DataMode="Int" MinValue="1" MaxValue="999" Nullable="False" CssClass="qty wneQty" HorizontalAlign="Center">
				        </igtxt:WebNumericEdit>			
		           </td>
        			
			        <td class="cartUnitTot">				
		                <asp:label id="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' />
		            </td>
    		        
			        <td class="cartRem">
				        <asp:checkbox id="Remove" runat="server" />
			        </td>
		        </tr>
	        </table>
        </ItemTemplate>

        <AlternatingItemTemplate>
        <table class="cart-table alt-row">
           <tr>

	        <td class="cartItemName">
	            <input id="ShoppingCartID" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "ShoppingCartID", "{0:g}") %>' runat="server" NAME="ShoppingCartID" style="width: 13px">
		        <input id="OrigQuantity" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' runat="server" NAME="OrigQuantity" style="width: 6px">			
        	    
	            <div class="item-image"><asp:HyperLink ID="hyplItemPic" runat="server" /></div>
	            <asp:HyperLink ID="hyplItemName" runat="server"><%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
                <asp:Label ID="lblLimitedQty" runat="server" Text="Limited Production:  Only X bottle(s) per customer" Visible="False" />
                <div class="item-meta">
                Item #:<asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' /> | Unit Type: <asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' />		
                </div> <!-- .item-meta -->
            </td>
        			
	        <td class="cartUnitPrice">
	            <asp:label id="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size"></asp:label>		
	        </td>

	        <td class="cartQty">			
	            <igtxt:WebNumericEdit id=wneQuantity runat="server" BackColor="White" Font-Bold="False" ReadOnly=false Value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' DataMode="Int"  MinValue="1" MaxValue="999" Nullable="False" CssClass="qty wneQty" HorizontalAlign="Center">
	            </igtxt:WebNumericEdit> 							
	        </td>

            <td class="cartUnitTot">
		        <asp:label id="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size"></asp:label>			
	        </td>
            
            <td class="cartRem">
		        <asp:checkbox id="Remove" runat="server" />
	        </td>
        </tr> 
        </table>
        </AlternatingItemTemplate>
        </asp:DataList>

        <asp:Panel ID="pnlShipping_Totals" runat="server">

        <table class="cart-table">    
            <tr class="update-row">
                <td colspan="3">
                    <asp:ImageButton ID="imgbUpdateCart" runat="server" ImageUrl="~/images/buttons/btn_update-cart.gif" />           
                </td>
            </tr>
            <tr class="subtotal">
                <td class="extra">
                </td>
                <td class="label">
                    <asp:Label ID="Label7" runat="server" Text="Subtotal:" />
                </td>
                <td class="cost">
                    <asp:Label id="lblSubTotal" runat="server"> <%=String.Format("{0:C}", fSubTotal)%> </asp:Label>
                </td>
            </tr>
            <tr class="calculate-shipping">
                <td class="extra">
                    <h4 class="blue"><asp:Label runat="server" Text="Calculate Shipping" /></h4>
             
                    <asp:Label runat="server" Text="ZIP CODE" />&nbsp
                    <asp:TextBox runat="server" ID="txtzipcode" Width="60" CssClass="white" MaxLength="5" />&nbsp&nbsp
                        
                    <asp:Button runat="server" Text="CALCULATE" ID="calculateShipping" CssClass="btn" />

                    <asp:DropDownList ID="ddlshippingMethod" runat="server" Width="260px" 
                       AutoPostBack="True" CssClass="shipping-method">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="lblInvalidZip" CssClass="errorMessage" runat="server" Text="Invalid Zipcode For Shipping!<br />"
                        Visible="False" />

                </td>
                <td class="label">
                Shipping:
                </td>
                <td class="cost">
                    <asp:Label runat="server" ID="lblShipping"> <%=String.Format("{0:C}", fShipping)%> </asp:Label>
                </td>
            </tr>
            <tr class="total">
                <td class="extra">
                    <span class="shipping-msg"><asp:Literal ID="lblShippingMsg" runat="server" Visible="False" /></span>
                </td>
                <td class="label">
                     <asp:Label ID="Label1" runat="server" Text="Total: <br /><span class='item-meta'>before taxes<br/>(if applicable)</span>" />
                </td>
                <td class="cost">
                    <asp:Label runat="server" ID="lblTotal"> <%=String.Format("{0:C}", fTotal)%> </asp:Label>
                </td>
            </tr>

        </table>

        <br />
        
        <div class="shipping-restrictions-list" style="display:none;">
            <ul>
            <li style="margin-bottom:24px;"><a href="#njinfo" class="mod-launch" rel="modal:open" style="color:#fefefe;padding:10px 20px;background:#333333;text-decoration:none;">Shipping to New Jersey?</a></li>
            <asp:PlaceHolder runat="server" ID="phMsgSpiritsOnlyDelivery" Visible="false"><li style="margin-bottom:24px;"><span style="color:#fefefe;padding:10px 20px;background:#333333;text-decoration:none;"><i class="icon-exclamation-sign icon-large"></i> Currently spirits are only available for shipment within New York State.</span></li></asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phMsgSpiritsNoAirShipping" Visible="false"><li style="margin-bottom:24px;"><span style="color:#fefefe;padding:10px 20px;background:#333333;text-decoration:none;"><i class="icon-exclamation-sign icon-large"></i> Currently spirits cannot be shipped via UPS of FedEx.</span></li></asp:PlaceHolder>
            </ul>
        </div>

        <div id="njinfo" style="display:none;">
            <h4>Please Note:</h4>
            <p>
            Your purchase is being made in New York so we are required to collect New York sales tax. Once you complete your purchase, the items you own will be transferred at your direction to a third party shipping company – Royal Express Shipping – which will contact you directly within two business days with your shipping, tracking number, shipping date and anticipated delivery date. Because of this transfer, delivery may take approximately 3-5 days. There is an optional 1 percent charge for insurance against breakage and loss, which you can decline at checkout.
            </p>
            <div><a href="#" rel="modal:close"><i class="icon-remove-sign"></i> close</a></div>
        </div>
        
        <div class="checkout-button-container clearfix"> 
            <input id="ReturnUrl" runat="server" name="ReturnUrl" style="width: 72px; height: 22px" type="hidden" value="~/Default.aspx" />
            <asp:HyperLink ID="hyplReturnToShopping" runat="server" ToolTip="Return to Shopping At Astor" TabIndex="2" ImageUrl="~/images/buttons/btn_return-to-shopping.gif" CssClass="checkout-button" />                 
        </div>
        <div class="checkout-button-container clearfix">
            <asp:ImageButton ID="imgbCheckOut" runat="server" ImageUrl="~/images/buttons/btn_proceed-to-checkout.gif" CssClass="checkout-button" />
            <br />
        </div>
                        
        <br /> 
            
        </asp:Panel>  
    </div>

     <div class="delivery-info-wrapper clearfix">
        <div class="delivery-info-container">
            <h4><br/>Prohibited States</h4>
            <p>
            Due to restrictive regulations, we cannot accept orders for shipment to the following locations:
            </p>    
            <asp:Literal ID="lblShipToStatesCodes" runat="server" />   
            <p>We do not ship internationally. Sorry!</p>        
        </div> <!-- .delivery-info-container -->

        <div class="delivery-info-container">
            <h4>Free Shipping<br/>Available in New York</h4>
                <p>
                <%= cAstorMessaging.getMsg_FreeShippingInNY() %>
                </p>          
        </div> <!-- .delivery-info-container -->

        <div class="delivery-info-container">
            <h4><br/>Signature Required!</h4>
            <p>
            A person 21 years of age or older must sign for your delivery, so please be sure someone of age will be available to welcome your bottles home!
            </p>          
        </div> <!-- .delivery-info-container -->
    </div> <!-- .delivery-info-wrapper -->   
</div>
</asp:Content>