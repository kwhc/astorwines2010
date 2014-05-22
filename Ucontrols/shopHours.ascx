<%@ Control Language="VB" AutoEventWireup="false" CodeFile="shopHours.ascx.vb" Inherits="Ucontrols_shopHours" %>

<asp:Panel runat="server" ID="pnlShopHours">    
    <div id="holidayshophours" style="text-align: center; text-transform: uppercase; font-size: 1.4rem; margin-top: 40px; margin-bottom: 30px;color:rgb(90,90,90);font-family: 'Open Sans Condensed', Arial, Helvetica, Sans-Serif;">
        Our shop will be open <asp:literal runat="server" ID="lblToday" /> from <asp:literal runat="server" ID="lblHours" />
    </div>
</asp:Panel>

<asp:Placeholder runat="server" ID="phCustomerSurvey" Visible="false">
    <div style="text-align:center;margin-top:3rem;margin-bottom:3rem;">
        <h3 style="">Enter to win a $250 Astor Center gift card! </h3>
        <hr style="background:rgb(90,90,90);width:60px;border:0;height:3px;margin-bottom:1rem;" align="center" /> 
        <a href="m.aspx?p=customer-survey" style="padding:.5rem 2rem;border:solid #E54800 4px;background-color:#e54800;text-transform:uppercase;display:inline-block;text-decoration:none;color:#efefef;border-radius:4px;letter-spacing:2px;">Click here for details</a>
    </div>
</asp:Placeholder>