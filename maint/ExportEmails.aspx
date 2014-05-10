<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ExportEmails.aspx.vb" Inherits="maint_ExportEmails" %>

<%@ Register TagPrefix="igsch" Namespace="Infragistics.WebUI.WebSchedule" Assembly="Infragistics35.WebUI.WebDateChooser.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Astor Wines/Astor Center Email append file download</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="Astor Wines/Astor Center email append list downloader"></asp:Label><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Date Start (default loaded with last export datetime)" ForeColor="Blue"></asp:Label>
        <igsch:WebDateChooser ID="wdcStartDate" runat="server" Value="2008-01-01">
        </igsch:WebDateChooser>
        <asp:Label ID="Label2" runat="server" Text="End Date (leave 12/31/9998 unless specific date needed)" ForeColor="Blue"></asp:Label>
        <igsch:WebDateChooser ID="wdcEndDate" runat="server" Value="9998-12-31">
        </igsch:WebDateChooser>
        <asp:Label ID="Label4" runat="server" Text="List Selection" ForeColor="Blue"></asp:Label><br />
        <asp:DropDownList ID="ddlType" runat="server" Width="192px" AutoPostBack="True">
            <asp:ListItem Value="AWS">Astor Wines &amp; Spirits</asp:ListItem>
            <asp:ListItem Value="AC">Astor Center</asp:ListItem>
        </asp:DropDownList><br />
        <br />
    <asp:button id="cmdExportFile" 
				runat="server" ForeColor="White" Font-Names="Arial" Height="48px" Width="120px" Text="Export Email List" BackColor="Blue" BorderStyle="Outset" BorderColor="#400040"></asp:button>
        <br />
        <asp:label id="lblExportMessage" 
				runat="server" Visible="False" Font-Bold="True" ForeColor="#0000C0" Font-Names="Arial"
				Height="24px" Width="248px" Font-Size="Large">Exported 0 email addresses</asp:label></div>
    </form>
</body>
</html>
