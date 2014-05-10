<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCSpiritsSearch.ascx.vb" Inherits="Ucontrols_WUCSpiritsSearch" %>

<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<asp:PlaceHolder ID="plcShowHeader" runat="server">
  <div class="expandedSearchHeader" style="font-weight: bold;">
    Spirits Search
  </div>
</asp:PlaceHolder>

<div class="searchPanel">
  <asp:Panel runat="server" DefaultButton="imbbSearch" ID="pnlSearch">
    <asp:DropDownList ID="ddlStyle" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Spirit Type</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlPriceRange" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Price Range</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlSize" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Size</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlProducer" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Producer</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlCountrySp" runat="server" Width="185px" AppendDataBoundItems="True" AutoPostBack="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Country</asp:ListItem>
    </asp:DropDownList>
    <igmisc:WebAsyncRefreshPanel ID="warpSpirits" runat="server" TriggerControlIDs="*ddlCountrySp" TriggerPostBackIDs="*$ddlRegion">
      <asp:DropDownList ID="ddlRegion" runat="server" Width="185px" CssClass="search-dropdown">
        <asp:ListItem>Choose a Region</asp:ListItem>
      </asp:DropDownList>
    </igmisc:WebAsyncRefreshPanel>
    <br />
    <br />
    <asp:CheckBox ID="chkOrganic" runat="server" Text=" Organic" CssClass="checkbox" />
    <br />
    <br />
    <asp:CheckBox ID="chkKosher" runat="server" Text=" Kosher" CssClass="checkbox" />
    <br />
    <br />
    <span class="note">Enter Up To 5 Keywords <br /> (Item #s, Distilleries, Producers, Etc.)</span>
    <asp:TextBox ID="txtName" runat="server" Width="184px" AutoCompleteType="Search" MaxLength="100" />
    <div class="btnSearch"><asp:ImageButton ID="imbbSearch" runat="server" ImageUrl="~/images/general/btn_advSearchSpirits.png" ToolTip="Click to Submit Spirit Search"/></div>
    <br />
      <asp:LinkButton ID="lbutReset" runat="server" Text="Click Here To Reset Search" CssClass="reset" />
  </asp:Panel>
</div>