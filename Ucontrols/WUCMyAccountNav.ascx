<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCMyAccountNav.ascx.vb" Inherits="Ucontrols_WUCMyAccountNav" %>

<%@ Register TagPrefix="ignavbar" Namespace="Infragistics.WebUI.WebNavBar" Assembly="Infragistics35.WebUI.WebNavBar.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbar" Namespace="Infragistics.WebUI.UltraWebToolbar" Assembly="Infragistics35.WebUI.UltraWebToolbar.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igtbl" Namespace="Infragistics.WebUI.UltraWebGrid" Assembly="Infragistics35.WebUI.UltraWebGrid.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="ignav" Namespace="Infragistics.WebUI.UltraWebNavigator" Assembly="Infragistics35.WebUI.UltraWebNavigator.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<div id="accountNav">
                <asp:Menu ID="mnuMyAccount" runat="server" >
                    <Items>
                        <asp:MenuItem Text="Summary" Value="summary"></asp:MenuItem>
                        <asp:MenuItem Text="My Login Info" Value="email"></asp:MenuItem>
                        <asp:MenuItem Text="My Billing Info" Value="billing"></asp:MenuItem>
                        <asp:MenuItem Text="My Shipping Addresses" Value="shipping"></asp:MenuItem>
                        <asp:MenuItem Text="My Order History" Value="history"></asp:MenuItem>
                    </Items>
                </asp:Menu>
</div>