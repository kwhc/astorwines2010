<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="test-cocktail-library.aspx.vb" Inherits="AstorLandmarkStore" title="Our Landmark Shop | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

<img src="images/general/middleContentTop.gif" />

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="astorwebdatabase20ConnectionString"></asp:SqlDataSource>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate></HeaderTemplate>
        <ItemTemplate>
            <asp:Literal runat="server" ID="title" />
            <asp:Literal runat="server" ID="creator" />
            <asp:Literal runat="server" ID="creatorBar" />
            <asp:Literal runat="server" ID="ing1Amt" />
            <asp:Literal runat="server" ID="ing1Unit" />
            <asp:LinkButton runat="server" ID="ing1Name" />
            
        </ItemTemplate>
        <FooterTemplate></FooterTemplate>
    </asp:Repeater>
  
</asp:Content>