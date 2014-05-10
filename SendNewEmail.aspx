<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SendNewEmail.aspx.vb" Inherits="secure_SendNewEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Send New Email</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label">Email Address:</asp:Label> 
        <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" Width="128px"></asp:TextBox>
    
    <asp:Image ID="Image1" runat="server" ImageUrl="/images/library.jpg" /></div>
    </form>
</body>
</html>
