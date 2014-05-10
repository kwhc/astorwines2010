<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCCreditCardNoCVV.ascx.vb" Inherits="Ucontrols_WUCCreditCardNoCVV" %>
 
 <table border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td><asp:Label ID="Label18" runat="server" CssClass="pt12blsize" Text="Name On Card"></asp:Label></td>
        <td><asp:Label ID="lblCCName" runat="server" Text="John M Smith"></asp:Label>
    <asp:Label ID="lblCCRowID" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="lblccRowIDU" runat="server" Text="Label" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label15" runat="server" CssClass="pt12blsize" Text="Credit Card Type"></asp:Label></td>
            <td><asp:Label ID="lblCCType" runat="server" CssClass="pt12size" Text="VISA"></asp:Label>
                <asp:Label ID="ID" runat="server" Text="12345" Visible="False"></asp:Label></td>
        </tr>
         <tr>
            <td><asp:Label ID="Label4" runat="server" CssClass="pt12blsize" Text="Credit Card #"></asp:Label></td>
            <td><asp:Label ID="lblCreditCard" runat="server" Text="XXXX-XXXX-XXXX-1234"></asp:Label></td>   
        </tr>
         <tr>
            <td><asp:Label ID="Label16" runat="server" CssClass="pt12blsize" Text="Exp. Date"></asp:Label></td>
            <td><asp:Label ID="lblCCExpDateMM" runat="server" Text="10"></asp:Label>/<asp:Label ID="lblCCExpDateYYYY" runat="server" Text="2007"></asp:Label></td> 
        </tr>
    </table>
    <br />
    <strong><asp:Label ID="lblDefault" runat="server" CssClass="pt12blsize" Text="Default Credit Card"></asp:Label></strong>
