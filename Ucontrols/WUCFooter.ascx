<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCFooter.ascx.vb" Inherits="Ucontrols_WUCFooter" %>

<div id="footer">
    
    <!-- HOLIDAY SWITCH <img src="../images/general/footerBackground.jpg" style="position: absolute; bottom: 0; left: 0; z-index: 1; width: 100%; height: 100%;" /> -->
    
          <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/StoreHoursDirections.aspx" Text="Store Hours &amp; Directions" />&nbsp;|&nbsp;
          <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/DeliveryInformation.aspx" Text="Delivery &amp; Shipping Information" />&nbsp;|&nbsp;
          <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/PrivacyPolicy.aspx" Text="Privacy Policy" />&nbsp;|&nbsp;
          <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/return-policy.aspx" Text="Return Policy" />&nbsp;|&nbsp;
          <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/ContactUs.aspx" text="Contact Us" />&nbsp;|&nbsp;
          <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/faq.aspx" Text= "F.A.Q." />&nbsp;|&nbsp;
          <asp:HyperLink ID="hplnkTastingNotes" runat="server" NavigateUrl="http://www.tastingnotesnyc.com" Text="Tasting Notes" />
          <br /><br />
          © 2012 Astor Wines and Spirits. All rights reserved.
          <br />
          <strong>Astor Wines &amp; Spirits | De Vinne Press Building | 399 Lafayette St. (at East 4th St.) | New York, NY 10003 | (212) 674-7500</strong>
          <br />
          Not responsible for typographical errors. Prices subject to change without notice. <br />

        <%--  <asp:LinkButton ID="lnkbSiteMap" runat="server">Astor Site Map</asp:LinkButton>--%>
    
</div>retu