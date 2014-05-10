<%@ Control Language="VB" AutoEventWireup="false" CodeFile="outOfStockBasket.ascx.vb" Inherits="Ucontrols_outOfStockBasket" %>

    <asp:Panel runat="server" ID="pnlOutOfStock">
    
        <h2>Out of Stock Items</h2>
    
        <div><asp:Literal runat="server" ID="litIntroMsg" /></div>
        
        <asp:DataList runat="server" ID="dlOutOfStock">
            <ItemTemplate>
                <table class="cart-table">
                    <tr>
                        <td class="cartItemName">
                            <div class="item-image">
                                <asp:HyperLink ID="hyplItemPic" runat="server" />
                            </div>
                            <!-- .item-image -->
                            <asp:HyperLink ID="hyplItemName" runat="server"><%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
                            <asp:Literal ID="litLimitedQty" runat="server" Text="Limited Production:  Only X bottle(s) per customer"
                                Visible="False" />
                            <div class="item-meta">
                                Item #:<asp:Literal ID="litItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' />
                                | Unit Type:<asp:Literal ID="litUnitType" runat="server" />
                            </div>
                            <!-- .item-meta -->
                        </td>
                                   			            			        		        
			            <td class="cartRem">
				            <asp:checkbox id="cbRemove" runat="server" />
			            </td>
		            </tr>
	            </table>
            </ItemTemplate>

        </asp:DataList>
    </asp:Panel>
