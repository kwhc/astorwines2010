<%@ Control Language="VB" AutoEventWireup="false" CodeFile="free-shipping-first-order.ascx.vb" Inherits="Ucontrols_promo_after_hours_courier_service" %>
<%@ Register Src="~/Ucontrols/afterHoursCourierDetail.ascx" TagName="afterHours" TagPrefix="p" %>

<div id="first-order-offer" class="info-page">
    <img src="../images/promo/freeDelivery/freeDeliveryTruck.png" alt="Free Shipping on First Time Web Orders" />
    <h1 style="text-transform:uppercase;">Free Ground Shipping On Your First Web Order</h1>
    <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" /> 
    <h2>Terms &amp; Conditions</h2>
    <%=cAstorMessaging.getMsg_FirstOrderFreeShipping() %>
</div>