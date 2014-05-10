<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCCreditCard.ascx.vb" Inherits="Ucontrols_WUCCreditCard" %>

<asp:Label ID="lblDefault" runat="server" CssClass="pt12blsize" Text="Default Credit Card"></asp:Label>
<div>
    <table>
        <tr>
            <td class="checkoutLeft">
            <span class="formLabel">Credit Card Type:</span>
            </td>
            <td>
            <asp:Literal ID="lblCCType" runat="server"></asp:Literal>
            <asp:Literal ID="ID" runat="server" Visible="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
            <span class="formLabel">Expiration Date:</span>
            </td>
            <td>
            <asp:Literal ID="lblCCExpDateMM" runat="server"></asp:Literal>/<asp:Literal ID="lblCCExpDateYYYY" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
            <span class="formLabel">Name:</span>
            </td>
            <td>
            <asp:Literal ID="lblCCName" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
            <span class="formLabel">Credit Card #:</span>
            </td>
            <td>
            <asp:Literal ID="lblCreditCard" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
            <span class="formLabel">Security Code: *</span>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="rfvCVV" runat="server" ControlToValidate="CVV" CssClass="errorMessage" ErrorMessage="Security Code Required!" ValidationGroup="vgBilling" Display="dynamic"><asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
            <asp:TextBox ID="CVV" runat="server" MaxLength="5" Width="50px"></asp:TextBox>
            <asp:LinkButton ID="lnkbCVVHelp" runat="server" OnClientClick="javascript:window.open('../help/SecurityCodeHelp.htm', 'CVV_Help', 'width=600,height=700,scrollbars=yes,screenX=400')"><i>Security Code Help</i></asp:LinkButton>
            </td>
        </tr>
    </table>

  <asp:Literal ID="lblCCRowID" runat="server" Visible="False"></asp:Literal>
  <asp:Literal ID="lblccRowIDU" runat="server" Visible="False"></asp:Literal>
  <div style="clear: both;"></div>
</div>

<div class="break"></div>