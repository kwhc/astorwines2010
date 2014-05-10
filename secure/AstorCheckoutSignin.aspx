<%@ Page Language="VB" MasterPageFile="~/as_checkout_master.master" AutoEventWireup="false" CodeFile="AstorCheckoutSignin.aspx.vb" Inherits="as_checkout_signin" title="Astor Wines & Spirits - Checkout - Sign In" EnableEventValidation="false" %>

<%@ Register Src="~/Ucontrols/WUCSignIn.ascx" TagName="WUCSignIn" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:WUCSignIn ID="WUCSignIn1" runat="server" />
    <table>
    <tr>
                <td style="height: 15px">
                    <p>If you would prefer to finish your order by phone, please call &nbsp;<b><asp:Label ID="lblAstorPhone"
                        runat="server" Text="1-212-674-7500"></asp:Label></b></p></td>
                        <td style="height: 15px"></td>
            </tr>
</table>
</asp:Content>


