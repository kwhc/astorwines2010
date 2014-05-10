<%@ Control Language="VB" AutoEventWireup="false" CodeFile="after-hours-courier-service.ascx.vb" Inherits="Ucontrols_promo_after_hours_courier_service" %>
<%@ Register Src="~/Ucontrols/afterHoursCourierDetail.ascx" TagName="afterHours" TagPrefix="p" %>

<div>
    <asp:Image runat="server" ID="imgAfterHoursHeader" />
</div>

<div class="info-page">
    <h1 style="text-transform:uppercase;">No Doorman?<br/>No Problem!</h1>
    <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" /> 
    <h3 style="text-transform:uppercase;">Now at Astor:</h3>
    <p:afterHours runat="server" ID="ucAfterHoursDetail" />
</div>