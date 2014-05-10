<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AstorWaitList.aspx.vb" Inherits="AstorWaitList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/styles/type.css" />
</head>

<body id="Body" runat="server">
    <form id="form1" runat="server">
        <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
        <div style="text-align: center;">
            <h3><asp:Label ID="lblTitle" runat="server" Text="" /></h3>
            <p><asp:Label ID="lblItem" runat="server" Text="" /></p>
            <p><asp:Label ID="Label1" runat="server" Text="Please enter your email address" /></p>
            <asp:TextBox ID="txtYourEmail" runat="server" Width="250px" MaxLength="100" style="margin-left: 60px;" />
            <asp:RegularExpressionValidator ID="revToEmailAddress" runat="server" ControlToValidate="txtYourEmail"
                    CssClass="errorMessage" ErrorMessage="Invaild Email Address" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"
                    ValidationGroup="vgEmailMessage">
                Invaild Email Address</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvToEmailAddress" runat="server" ControlToValidate="txtYourEmail"
                    CssClass="errorMessage" ErrorMessage="Missing Email Address" ValidationGroup="vgEmailMessage">
                Missing Email Address</asp:RequiredFieldValidator>
            <div style="text-align: center;">
                <asp:ImageButton ID="cmdConfirm" runat="server" AlternateText="Confirm" Height="30px" ImageUrl="~/images/buttons/btn_notifyMe.png" ValidationGroup="vgEmailMessage"/><br />		
		        <br />
		        <a href='#' id='A1' rel="modal:close"><i class="icon-remove-sign"></i> Nevermind</a>
	        </div>
        </div>
    </form>
</body>
</html>
