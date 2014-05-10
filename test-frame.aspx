<%@ Page Language="VB" MasterPageFile="~/master-iframe.master" CodeFile="~/test-frame.aspx.vb" Inherits="frame_test" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <div style="width: 100%; height: 100%; position: absolute; top: 0; left: 0; overflow: hidden;">
    <frameset frameborder="0" style="display: block;" rows="40,*">
        <div style="height: 20px; padding: 10px;">
        &#171; Back to AstorWines.com
        <asp:HyperLink ID="permalink" runat="server">Permalink</asp:HyperLink>
        </div>

        <iframe runat="server" id="iframetag" src="http://www.google.com" height="100%" width="100%" frameborder="0" style="display: block;">Return to site</iframe> 
    </frameset>
    </div>
</asp:Content>
