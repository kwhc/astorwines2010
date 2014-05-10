<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCAOSShoppingCart.ascx.vb" Inherits="Ucontrols_WUCAOSShoppingCart" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<h2>Out of Stock</h2>
<p>The following items are currently out of stock</p>
<asp:DataList ID="datMyList" runat="server">
        <HeaderTemplate>
            <table class="cart-table">
                <tr>
                    <td style="width: 345px;">
                        Item Name
                    </td>

                    <td style="width: 100px; text-align: right;">
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
                <td>
                    <asp:Literal ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>'></asp:Literal>
                    <div class="item-meta">
                        Item#: <asp:Literal ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' />
                    </div>
                </td>
                
                <td style="vertical-align: top;">
                <div class="itemPriceContainer">
                   <%-- <asp:Panel runat="server" ID="pnlInStock">
                        <asp:Literal ID="lblBottlePriceLabel" runat="server" Text="Bottle Price:" />
                        <asp:Label ID="lblOldBottlePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "botprcfl")) %>'
                            CssClass="wrongPrice" Visible="False"></asp:Label>
                        <asp:Label ID="lblNewBottlePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "botprc")) %>'></asp:Label>
                        <em>
                            <asp:Literal ID="lblYouSaveLabel" runat="server"><br />You Save: </asp:Literal></em>
                        <asp:Label ID="lblYouSave" runat="server" />
                        <br />
                        <asp:Literal ID="lblCaseLabel" runat="server" Text="Case of 9:" />
                        <asp:Label ID="lblOldCasePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "casprcfl")) %>'
                            CssClass="wrongPrice" Visible="False"></asp:Label>
                        <asp:Label ID="lblNewCasePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "casprc")) %>'></asp:Label>
                        <br />
                        <div>
                            <asp:Image ID="imgOnSale" runat="server" ImageUrl="~/images/misc/icon_sale.gif" Visible="False" />
                        </div>
                        <igtxt:WebNumericEdit CssClass="qty wneQty" DataMode="Int" Font-Bold="False" ID="wneQty"
                            MaxLength="3" MaxValue="999" MinValue="1" runat="server" ValueText="1">
                        </igtxt:WebNumericEdit>
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="ddType dd">
                            <asp:ListItem Value="Bottle">Bottle(s)</asp:ListItem>
                            <asp:ListItem Value="Case">Case(s)</asp:ListItem>
                        </asp:DropDownList>
                        <div style="clear: left;">
                        </div>
                        <br />
                        <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/as_addtocart.gif" />
                        <br />
                        <div style="float: right;">
                            <asp:Image ID="imgVideo" runat="server" ImageUrl="~/images/general/searchVideo.gif"
                                Visible="True" alt="Video Available" />
                            <asp:Image ID="ImgPairing" runat="server" ImageUrl="~/images/general/searchPairing.gif"
                                Visible="True" Alt="Paring Avaliable" />
                            <asp:Image ID="ImgStaffPick" runat="server" ImageUrl="~/images/general/searchStaffPick.gif"
                                Visible="True" Alt="Staff Pick" />
                        </div>
                        <div style="clear: both;">
                        </div>
                        <asp:Label ID="lblLimitedQty" runat="server" CssClass="limitedQty" Text="Limited Production: Only X bottle(s) per customer"
                            Visible="False"></asp:Label>
                        <asp:Literal ID="lblInStoreOnly" runat="server" Text="Available For In Store Purchase Only"
                            Visible="False" />
                    </asp:Panel>--%>
                    <asp:Panel runat="server" ID="pnlOutOfStock">
                        <asp:Literal runat="server" ID="litOutOfStockMsg" />
                               <%-- <asp:ImageButton runat="server" ID="imgbWaitList" ImageUrl="~/images/as_checkout_notify_icon.gif"></asp:ImageButton>--%>
                        <asp:Literal ID="WaitLink" runat="server">*Notify Me*</asp:Literal>
                    </asp:Panel>
                </div>
            </td>
            </tr>
        </ItemTemplate>
        <SeparatorTemplate>
            <br />
        </SeparatorTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:DataList>