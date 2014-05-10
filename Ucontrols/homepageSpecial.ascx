<%@ Control Language="VB" AutoEventWireup="false" CodeFile="homepageSpecial.ascx.vb" Inherits="Ucontrols_homepageSpecial" %>

<asp:Panel ID="pnlSpecial" runat="server">            
    <div class="homepage-special clearfix">
        <asp:ImageButton runat="server" ID="imgBottle" />
        <div class="copy">
            <h3><asp:Image runat="server" ID="imgIcon" /><asp:Literal runat="server" ID="litSubHead" /></h3>            
            <h4><asp:Literal runat="server" ID="litTitle" /></h4>
            <p><asp:Literal runat="server" ID="litDescription" /></p>
            <asp:LinkButton runat="server" ID="lnkGet" />
        </div>
    </div>
</asp:Panel>