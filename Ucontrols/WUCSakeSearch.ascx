<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCSakeSearch.ascx.vb" Inherits="Ucontrols_WUCSakeSearch" %>

<asp:PlaceHolder ID="plcShowHeader" runat="server">
  <div class="expandedSearchHeader" style="font-weight: bold;">
    Sak&#233; Search
  </div>
</asp:PlaceHolder>
<div class="searchPanel">
  <asp:Panel runat="server" DefaultButton="imbbSearch" ID="pnlSearch">
    <asp:DropDownList ID="ddlPriceRange" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Price Range</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlSize" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Size</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlPolishingGrade" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem>Choose a Polishing Grade</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlSakeDiscriminator" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Sak&#233; Style</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlPrefecture" runat="server" Width="185px" AppendDataBoundItems="true" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Prefecture</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlProducer" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Producer</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:CheckBox ID="chkOrganic" runat="server" Text=" Organic" CssClass="checkbox" />
    <br />
    <br />
    <span class="note">Enter Up To 5 Keywords <br /> (Item #s, Breweries, Producers, Etc.)</span>
    <asp:TextBox ID="txtName" runat="server" Width="184px" AutoCompleteType="Search" MaxLength="100" />
    <div class="btnSearch"><asp:ImageButton ID="imbbSearch" runat="server" ImageUrl="~/images/general/btn_advSearchSake.png" ToolTip="Click to Submit Sake Search"/></div>
    <br />
      <asp:LinkButton ID="lbutReset" runat="server" Text="Click Here To Reset Search" CssClass="reset" />
  </asp:Panel>
</div>