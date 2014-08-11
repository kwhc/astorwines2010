<%@ Page Title="" Language="VB" MasterPageFile="~/noColumns.master" AutoEventWireup="false" CodeFile="ShoppingCartSaved.aspx.vb" Inherits="ShoppingCartSaved" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadSupplement" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<div id="shoppingcart" class="clearfix">
    <div class="no-column-page">
    <h1>Don't forget these!</h1>
    
    <p>These items were previously saved to your cart. You can add them individually or all together.</p>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
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
		        <td >
		        </td>
	        </tr>
	     </table>
    </HeaderTemplate>

    <ItemTemplate>
        <table class="cart-table">
            <tr>
                <td class="cartItemName">	
                    <input id="ShoppingCartID" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "ShoppingCartID", "{0:g}") %>' runat="server" name="ShoppingCartID" />
                    <input id="OrigQuantity" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' runat="server" name="OrigQuantity" />				
                     
                     <div class="item-image">
                        <asp:HyperLink ID="hyplItemPic" runat="server" />
                     </div> <!-- .item-image -->
                     <asp:HyperLink ID="hyplItemName" runat="server"><%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
                     <asp:Label ID="lblLimitedQty" runat="server" Text="Limited Production:  Only X bottle(s) per customer" Visible="False"></asp:Label>
                     <div class="item-meta">
                        Item #:<asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' /> | Unit Type:<asp:Label ID="lblUnitType" runat="server" />
                     </div> <!-- .item-meta -->             
               </td>
               
	           <td class="cartUnitPrice">
	                <asp:label id="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' />
               </td>
    			
		       <td class="cartQty">
		            <igtxt:WebNumericEdit id="wneQuantity" runat="server" BackColor="White" ReadOnly="false" Value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' DataMode="Int"  MinValue="1" MaxValue="999" Nullable="False" CssClass="qty wneQty">
				    </igtxt:WebNumericEdit>			
		       </td>
    			
			    <td class="cartUnitTot">				
		            <asp:label id="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size"></asp:label>
		        </td>
		        
			    <td class="cartRem">
                    <asp:Panel runat="server" ID="pnlInStock">
                   <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/buttons/btn_add_item.jpg" />
               </asp:Panel>
               <asp:Panel runat="server" ID="pnlOutOfStock">
                   <asp:Literal runat="server" ID="litOutOfStockMsg" />
                   <asp:Literal ID="WaitLink" runat="server">*Notify Me*</asp:Literal>
               </asp:Panel>
			    </td>
		    </tr>
	    </table>
    </ItemTemplate>

    <AlternatingItemTemplate>
    <table class="cart-table alt-row">
       <tr>

	    <td class="cartItemName">
	        <input id="ShoppingCartID" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "ShoppingCartID", "{0:g}") %>' runat="server" name="ShoppingCartID" style="width: 13px">
		    <input id="OrigQuantity" type="hidden" value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' runat="server" name="OrigQuantity" style="width: 6px">			
    	    
	        <div class="item-image"><asp:HyperLink ID="hyplItemPic" runat="server" /></div>
	        <asp:HyperLink ID="hyplItemName" runat="server"><%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
            <asp:Label ID="lblLimitedQty" runat="server" Text="Limited Production:  Only X bottle(s) per customer" Visible="False" />
            <div class="item-meta">
            Item #:<asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' /> | Unit Type: <asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' />		
            </div> <!-- .item-meta -->
        </td>
    			
	    <td class="cartUnitPrice">
	        <asp:label id="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size" />		
	    </td>

	    <td class="cartQty">			
	        <igtxt:WebNumericEdit id=wneQuantity runat="server" BackColor="White" ReadOnly=false Value='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' DataMode="Int"  MinValue="1" MaxValue="999" Nullable="False" CssClass="qty wneQty">
	        </igtxt:WebNumericEdit> 							
	    </td>

        <td class="cartUnitTot">
		    <asp:label id="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size"></asp:label>			
	    </td>
        
           <td class="cartRem">
               <asp:Panel runat="server" ID="pnlInStock">
                   <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/buttons/btn_add_item.jpg" />
               </asp:Panel>
               <asp:Panel runat="server" ID="pnlOutOfStock">
                   <asp:Literal runat="server" ID="litOutOfStockMsg" />
                   <asp:Literal ID="WaitLink" runat="server">*Notify Me*</asp:Literal>
               </asp:Panel>
           </td>
    </tr> 
    </table>
    </AlternatingItemTemplate>
    </asp:DataList>
    </ContentTemplate>
    
    </asp:UpdatePanel>
    <br />
    
    <div id="action-container" class="clearfix">
        <input id="ReturnUrl" runat="server" name="ReturnUrl" style="width: 72px; height: 22px" type="hidden" value="~/Default.aspx" />
            <div class="checkout-button-container clearfix"><asp:ImageButton ID="imgbAddAllCheckOut" runat="server" ImageUrl="~/images/buttons/btn_add_all_items.jpg" OnClientClick="_gaq.push(['_trackEvent', 'Add to Cart', 'Add All', 'Merge Cart', 'value']);" CssClass="checkout-button" /></div>
            <div class="checkout-button-container clearfix"><asp:ImageButton ID="imgbCheckOut" runat="server" ImageUrl="~/images/buttons/btn_return-to-shopping.gif" CssClass="checkout-button" /></div>
            <p>Any items you do not add to your cart will no longer be saved.</p>
    </div>      
              
    </div>  
    </div>
    
</asp:Content>


