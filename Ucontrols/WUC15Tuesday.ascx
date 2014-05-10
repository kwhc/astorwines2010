<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUC15Tuesday.ascx.vb" Inherits="Ucontrols_WUC15Tuesday_old" %>

<div style="margin-bottom:20px;">
    <asp:HyperLink ID="tuesdayLink" runat="server" CssClass="block-hover-burgundy tuesday-sale-promo">
            <img src="../images/general/img_15tuesdays.png" style="width:160px;" alt="15% Off Tuesday" />
            <span style="font-family:georgia;font-style:italic;color:#eee;font-size:1.2rem;display:block;margin-bottom:8px;">today's sale:</span>
            <span style="font-family: 'Open Sans Condensed', Arial, Helvetica, Sans-Serif;color:#eee;font-size:2rem;display:block;line-height:1.6rem;"><asp:Literal runat="server" ID="litSaleTitle" /></span>
    </asp:HyperLink>
    <a href="emails.aspx" class="block-hover-gray" style="padding:6px 12px;text-align:center;">15% Off Every Tuesday<br/><i class="icon-envelope"></i>  Get Tuesday sale alerts!</a>
</div>