<%@ Page Language="VB" MasterPageFile="~/as_featuresmaster_1.master" AutoEventWireup="false" CodeFile="AstorSiteMap.aspx.vb" Inherits="AstorSiteMap" title="Astor Wines & Spirits - Site Map" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMainMiddle" Runat="Server">
    <asp:TreeView ID="tvSiteMap" runat="server" DataSourceID="SiteMapDataSource1" Height="100%"
        Width="100%">
    </asp:TreeView>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
</asp:Content>

