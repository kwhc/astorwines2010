<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AstorWinesEmailToFriend.aspx.vb" Inherits="AstorWinesEmailToFriend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Astor Wines & Spirits - Email to a Friend</title>
    <link rel="stylesheet" type="text/css" href="/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="/css/astorwines.css" />
</head>
<body>
    <form id="form1" runat="server">
    <!--<asp:PlaceHolder ID="EmailToFriend" runat="Server">-->
      <div class="notesTermsItemDetail">
        <h2><i class="icon-envelope"></i> Email to a Friend</h2>
        <asp:Literal runat="server" ID="litTest" />
        <p>Please fill in your email address, your friends email address and any additional comments</p>
          <asp:Label ID="lblFriendsEmail" runat="server" Text="Friend's Email:" style="padding:0px 20px 0px 20px" />
          <asp:TextBox ID="txtFriendsEmail" Width="200px" runat="server" ValidationGroup="vgEmailMessage" />
            <asp:RegularExpressionValidator ID="revFromEmailAddress" runat="server" ControlToValidate="txtFriendsEmail"
                CssClass="errorMessage" ErrorMessage="Invaild Email Address" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"
                ValidationGroup="vgEmailMessage">
                <asp:Image ID="imgrevFromEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvFromEmailAddress" runat="server" ControlToValidate="txtFriendsEmail"
                CssClass="errorMessage" ErrorMessage="Missing Email Address" ValidationGroup="vgEmailMessage">
                <asp:Image ID="imgrfvFromEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
            </asp:RequiredFieldValidator><br />
          <asp:Label ID="lblYourEmail" runat="server" style="padding:0px 35px 0px 20px" Text="Your Email:" />
          <asp:TextBox ID="txtYourEmail" Width="200px" runat="server" ValidationGroup="vgEmailMessage" />
            <asp:RegularExpressionValidator ID="revToEmailAddress" runat="server" ControlToValidate="txtYourEmail"
                CssClass="errorMessage" ErrorMessage="Invaild Email Address" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"
                ValidationGroup="vgEmailMessage">
                <asp:Image ID="imgrevToEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvToEmailAddress" runat="server" ControlToValidate="txtYourEmail"
                CssClass="errorMessage" ErrorMessage="Missing Email Address" ValidationGroup="vgEmailMessage">
                <asp:Image ID="imgrfvToEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
            </asp:RequiredFieldValidator><br />
          <br />
              <strong>Personal Message:</strong> <span style="font-size: 10px;">(Maximum characters 400)</span><br />
              <asp:TextBox id="txtEmailNote" runat="server" Width="371px" MaxLength="400" TextMode="MultiLine" Height="200px" />
          <br />
 </div>
    <!--</asp:PlaceHolder>-->
    <asp:Label ID="lblError" runat="server" Text="Invalid Email Address" CssClass="errorMessage" Visible="False" />
    <div style="text-align:right; padding:20px 20px 100px 0px"><asp:Button ID="cmdSend" runat="server" ValidationGroup="vgEmailMessage" OnClientClick="" Text="Send" /></div>
    <div style="text-align:center;"><a href="#close" rel="modal:close"><i class="icon-remove-sign"></i> Close window</a></div>
    <div style="font-size: 12px"><asp:ValidationSummary ID="vsEmailMessage" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgEmailMessage" />
    </div>
    </form>    
</body>
</html>
