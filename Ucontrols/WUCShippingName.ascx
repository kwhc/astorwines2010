<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCShippingName.ascx.vb" Inherits="Ucontrols_WUCShippingName" %>
<br />
<asp:Panel runat="server" ID="pnlDefaultShippingAddress">
    <span class="help"><i class="icon-asterisk"></i> This is your default shipping address</span>
</asp:Panel>
<table>
    <tr>
        <td>Name:</td>
        <td><asp:Label ID="lblName" runat="server" Text="Full Name" CssClass="pt12blsize" /><asp:Label ID="lblIdt" runat="server" Text="000000"  Visible=false />
        <asp:Label ID="lblIds" runat="server" Text="00"  Visible=false /></td>
    </tr>
    <tr>
        <td>Company:</td>
        <td><asp:Label ID="lblCompany" runat="server" Text="Company" CssClass="pt12blsize" /></td>
    </tr>
    <tr>
        <td>Address:</td>
        <td><asp:Label ID="lblAddressApt" runat="server" Text="Address" CssClass="pt12size" /></td>
    </tr>
    <tr>
        <td>City/State/Zip</td>
        <td><asp:Label ID="lblCityStateZipcode" runat="server" Text="City, St Zip" CssClass="pt12size" /></td>
    </tr>
     <tr>
        <td>Shipping Email:</td>
        <td><asp:Label ID="lblEmail" runat="server" Text="ShipEmail" CssClass="pt12size" /></td>
    </tr>
    <tr>
        <td>Daytime Phone:</td>
        <td><asp:Label ID="lblDayPhone" runat="server" Text="(212) 555-5555" CssClass="pt12size" /></td>
    </tr>
    <tr>
        <td>Evening Phone:</td>
        <td><asp:Label ID="lblEveningPhone" runat="server" Text="(212) 555-5555" CssClass="pt12size" /></td>
    </tr>
    <tr>
        <td>Cross Streets:</td>
        <td><asp:Label ID="lblScross" runat="server" Text="5th & 4th" CssClass="pt12size" /></td>
    </tr>
</table>
<br />