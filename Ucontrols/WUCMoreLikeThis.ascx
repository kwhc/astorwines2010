<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCMoreLikeThis.ascx.vb" Inherits="Ucontrols_WUCMoreLikeThis" %>
 
<asp:DataList ID="datResults" runat="server" >
    <ItemTemplate>
        <div class="item-teaser clearfix">
            <div class="thumb-container">
                <asp:HyperLink ID="hyplItemPic" runat="server" CssClass="thumb" />
            </div>
            <div style="float: left; width: 105px;">
                <asp:HyperLink ID="hyplItemName" runat="server"><%#Rtrim(RTrim(DataBinder.Eval(Container.DataItem, "Name")) & " " & RTrim(DataBinder.Eval(Container.DataItem, "vintage")))%></asp:HyperLink>
            </div>
            <div style="float: left; width: 105px;">
                <asp:Literal ID="lblBottlePriceLabel" runat="server" Text="Price:" />
                <asp:Label ID="lblOldBottlePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "botprcfl")) %>' cssClass="wrongPrice" Visible="False" /> 
                <asp:Label ID="lblNewBottlePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "botprc")) %>' />
                <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/buttons/btn_addToCart_sm.png" CssClass="addToCart" />
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>

