<%@ Control Language="VB" AutoEventWireup="false" CodeFile="deliveryAlert.ascx.vb" Inherits="Ucontrols_deliveryAlert" %>

<asp:Placeholder runat="server" ID="pnlAlerts">
    <div id="shipping-alert" class="clearfix" style="text-align: center; margin-bottom: 30px;">
 
        <h2 class="alertBoxHeader" style="font-size:12px;letter-spacing:2px;margin-bottom:12px;">Shipping Alerts</h2>
        <asp:Placeholder runat="server" ID="allOrders">
            <div ID="all-order-info" style="text-align: center;color:#737373;">
            <h4 runat="server" id="headerAllOrders" style="text-transform:uppercase;font-weight:bold;">For all orders</h4>
            <asp:Panel runat="server" ID="allNoNextDay"><p>Because of heavy order volume, we cannot currrently guarantee next-day delivery.<br /> Check the "Shipping Info" screen during checkout to see when your order will ship.</p></asp:Panel>
            <asp:Panel runat="server" ID="allNoGuaranteeChristmas"><p>We <b>cannot guarantee</b> your order will arrive by December 25th.</p></asp:Panel>
            <asp:Panel runat="server" ID="allNoChristmas"><p>Orders placed today will not be delivered until after December 25th. <br/>We thank you for your patience, and we wish you a wonderful Holiday!</p></asp:Panel>            
            </div> 
        </asp:Placeholder>
        
        <asp:Placeholder runat="server" ID="shipping">
            <div runat="server" id="shippingPanel" class="shipping-info" style="">
                <h4 style="text-transform:uppercase;font-weight:bold;">For all deliveries outside of Manhattan, Queens, and Brooklyn</h4>
                <asp:Panel runat="server" ID="noNextDayShipping"><p>Because of heavy order volume, we cannot currently guarantee next-day delivery. Check the "Shipping Info" screen during checkout to see when your order will ship.</p></asp:Panel>
                <asp:Panel runat="server" ID="shippingChristmasDeadline"><p>To ensure delivery by December 25th,<br /> <b>please place your orders by noon on <asp:Literal runat="server" ID="litShippingDeadline" />.</b></p></asp:Panel>            
                <asp:Panel runat="server" ID="shippingNoGuaranteeChristmas"><p>We <b>cannot guarantee</b> your order will arrive by December 25th.</p></asp:Panel>
                <asp:Panel runat="server" ID="shippingNoChristmas"><p>Your order will not arrive until <b>after December 25th.</b></p></asp:Panel>
                <asp:Panel runat="server" ID="pnlNoAirShipping"><p style="font-size:1.2em;">We cannot offer Next Day or 3rd Day shipping on any orders containing spirits.</p></asp:Panel>
                <asp:Panel runat="server" ID="heatAlert">
                    <img src="../images/general/heat-icon.gif" alt="Extreme Heat" />
                    <p>
                    To be sure that your items aren't damaged by the excessive heat, we may hold on to your order until temperatures drop to safe levels. 
                    If you have any questions, please call our Sales Associates at (212) 674-7500.</p>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlExtremeCold">
                Due to the extreme weather, your UPS or FedEx shipment may be delayed.
                </asp:Panel>
            </div> <!-- .shipping-info -->
        </asp:Placeholder>
        
        <asp:Placeholder runat="server" ID="delivery">
            <div runat="server" id="deliveryPanel" class="delivery-info" style="">
                <h4 style="text-transform:uppercase;font-weight:bold;">For orders being delivered to Manhattan, Brooklyn and Queens</h4>
                <asp:Panel runat="server" ID="noNextDay"><p>Because of heavy order volume, we cannot currently guarantee next-day delivery. Check the "Shipping Info" screen during checkout to see when your order will ship.</p></asp:Panel>
                <asp:Panel runat="server" ID="deliveryChristmasDeadline"><p>To ensure delivery by December 25th,<br /> <b>please place your orders by noon on December 19.</b></p></asp:Panel>
                <asp:Panel runat="server" ID="deliveryNoGuaranteeChristmas"><p>We <b>cannot guarantee</b> your order will arrive by December 25th.</p></asp:Panel>
                <asp:Panel runat="server" ID="deliveryNoChristmas"><p>Your order will not arrive until <b>after December 25th.</b></p></asp:Panel>
            </div>
        </asp:Placeholder>
        
        <asp:Placeholder runat="server" ID="special">
            <img src="../images/general/alert.gif" alt="Hurricane Sandy Alert" />
            <h3>Hurricane Sandy Update</h3>
            <p>We have resumed our delivery service. We are now working to fulfill the back orders we received during our power outage, so your delivery may take longer than usual. Please be patient as we catch up!</p>
        </asp:Placeholder>
        
    </div> <!-- .delivery-alert -->
</asp:Placeholder>