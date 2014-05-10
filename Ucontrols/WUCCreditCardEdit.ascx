<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCCreditCardEdit.ascx.vb" Inherits="Ucontrols_WUCCreditCardEdit" %>

<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<div>
    <div class="signInTxt">
        <asp:Label runat="server" ID="lblCCType" Text="Credit Card Type: *" AssociatedControlID="ddlCCType" /><br />
        <asp:DropDownList ID="ddlCCType" runat="server" Width="200px" TabIndex="11" AppendDataBoundItems="True" AutoPostBack="True">
            <asp:ListItem>Choose One</asp:ListItem>
        </asp:DropDownList>
        <asp:RegularExpressionValidator ID="revCCType" runat="server" ErrorMessage="Credit Card Type Required!" ValidationGroup="vgBilling" ControlToValidate="ddlCCType" ValidationExpression="^([AVDM])" Display="dynamic"><asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
    </div>

    <div class="signInTxt">
        <asp:Label runat="server" ID="lblCCMM" Text="Expiration Date: *" /><br />
        <asp:DropDownList ID="ddlCCMM" runat="server" Width="98px" TabIndex="13" AppendDataBoundItems="True">
            <asp:ListItem>Month</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlCCYYYY" runat="server" Width="98px" TabIndex="14" AppendDataBoundItems="True">
            <asp:ListItem>Year</asp:ListItem>
        </asp:DropDownList>
        <asp:RegularExpressionValidator ID="revCCMonth" runat="server" ControlToValidate="ddlCCMM" ErrorMessage="Month Required!" ValidationExpression="^\d{2}" ValidationGroup="vgBilling"><asp:Image ID="Image3" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revCCYear" runat="server" ControlToValidate="ddlCCYYYY" ErrorMessage="Year Required!" ValidationExpression="^\d{4}$" ValidationGroup="vgBilling"><asp:Image ID="Image4" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
    </div>

    <asp:Label runat="server" ID="lblCCname" Text="Name: *<div class='help'>(As it appears on the card)</div>" AssociatedControlID="CCName" />
    <div class="signInTxt">
        <asp:TextBox ID="CCName" runat="server" MaxLength="100" TabIndex="16" Width="197px" CssClass="grey" />
        <asp:RequiredFieldValidator ID="rfvCCName" runat="server" ControlToValidate="CCName" ErrorMessage="Credit Card Name Required!" ValidationGroup="vgBilling"><asp:Image ID="Image5" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
    </div>
</div>

<igmisc:WebAsyncRefreshPanel ID="warpCCMask" runat="server" TriggerControlIDs="*$ddlCCType">
    <div class="clearfix">
        <div style="float: left;">
            <asp:Label runat="server" ID="lblCreditCard" Text="Credit Card #: *<div class='help'>(Without dashes,<br />e.g.:1234567890123456)</div>" AssociatedControlID="txtCreditCard" />
            <div class="signInTxt">
                <asp:TextBox ID="txtCreditCard" runat="server" MaxLength="16" TabIndex="12" Width="200px" CssClass="grey" />
                <asp:RequiredFieldValidator ID="rfvCCNum" runat="server" ControlToValidate="txtCreditCard" EnableClientScript="false" ErrorMessage="Credit Card Number Required!" ValidationGroup="vgBilling"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
            </div>
        </div>
        
        <div>
            <asp:Label runat="server" ID="lblCVV" Text="<br/>Security Code: *" AssociatedControlID="CVV" /><br />
            <asp:LinkButton ID="lnkbCVVHelp" runat="server" OnClientClick="javascript:window.open('../help/SecurityCodeHelp.htm', 'CVV_Help', 'width=600,height=700,scrollbars=yes,screenX=400')"
                EnableViewState="False"><i>Security Code Help</i></asp:LinkButton>
            <div class="signInTxt">
                <asp:RequiredFieldValidator ID="rfvCVV" runat="server" ControlToValidate="CVV" CssClass="errorMessage"
                    ErrorMessage="Security Code Required!" ValidationGroup="vgBilling" Display="dynamic">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
                <asp:TextBox ID="CVV" runat="server" MaxLength="5" TabIndex="15" Width="50px" CssClass="grey" /></div>
            <asp:Label ID="lblCVVHelp" runat="server" CssClass="ccHelp" />
        </div>
    </div>            
</igmisc:WebAsyncRefreshPanel>

<asp:CheckBox ID="chkDefault" runat="server" Text="&nbsp; Make Default Credit Card" TabIndex="17" />
