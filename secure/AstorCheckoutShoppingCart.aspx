<%@ Page Title="" Language="VB" MasterPageFile="~/as_checkout.master" AutoEventWireup="false" CodeFile="AstorCheckoutShoppingCart.aspx.vb" Inherits="secure_AstorCheckoutShoppingCart" %>
<%@ Register Src="~/Ucontrols/WUCCheckOutHeader.ascx" TagName="checkOutHeader" TagPrefix="awCOH" %>
<%@ Register src="../Ucontrols/WUCAOSShoppingCart.ascx" tagname="WUCAOSShoppingCart" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="middleContent" Runat="Server">
    
    <div id="shoppingcart" class="clearfix">
   <%-- <div style="padding: 5px;">
      <awCOH:checkOutHeader ID="WUCCheckOutHeader1" runat="server" />--%>
    <h2>My Cart</h2>
      
    <asp:DataList ID="datMyList" runat="server">
        <HeaderTemplate>
            <table class="cart-table">
                <tr valign="top">
                    <td class="cartItemName">
                        Item Name
                    </td>
                    <td class="cartQty">
                        Quantity
                    </td>
                    <td class="cartUnitPrice">
                        Unit Price
                    </td>
                    <td class="cartUnitTot">
                        Unit Total
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div style="border-bottom: dotted 1px #bbb;">
                            <br />
                        </div>
                    </td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td class="cartItemName">
                    <asp:Literal ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>'></asp:Literal>
                    <div class="item-meta">
                        Item #: <asp:Literal ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' />
                        | Unit Type: <asp:Literal ID="lblUnitType" runat="server" />
                    </div>
                </td>
                <td class="cartQty">
                    <asp:Literal ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' />
                </td>
                <td class="cartUnitPrice">
                    <asp:Literal ID="UnitPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' />
                </td>
                <td class="cartUnitTot">
                    <asp:Literal ID="UnitTotal" runat="server" Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>
    
    <br />
   
    <br/><br/>
    
    <uc1:WUCAOSShoppingCart ID="WUCAOSShoppingCart1" runat="server" />
    
    <br/><br/>
    
    <div style="float: right; width: 370px; padding-right: 20px;">
       <div class="checkout-button-container clearfix" style="padding-bottom: 20px">
        <input id="ReturnUrl" runat="server" name="ReturnUrl" style="width: 72px; height: 22px" type="hidden" value="~/Default.aspx" />
        <asp:HyperLink ID="hyplReturnToShopping" runat="server" ToolTip="Return to Shopping At Astor" TabIndex="2" ImageUrl="~/images/buttons/btn_return-to-shopping.gif" CssClass="checkout-button" />                 
   </div>
        <div class="checkout-button-container clearfix">
            
            <asp:ImageButton ID="imgbCheckOut" runat="server" ImageUrl="~/images/buttons/btn_proceed-to-checkout.gif"
                CssClass="checkout-button" />
            <br />
        </div>
    </div>
    </div> 
    </asp:Content>


