<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCWineSearch.ascx.vb" Inherits="Ucontrols_WUCWineSearch" %>

<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<asp:PlaceHolder ID="plcShowHeader" runat="server">
  <div class="expandedSearchHeader" style="font-weight: bold;">
    Wine Search
  </div>
</asp:PlaceHolder>

<div class="searchPanel">
  <asp:Panel runat="server" DefaultButton="imbbSearch" ID="pnlSearch">
    <asp:DropDownList ID="ddlColor" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Color</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlStyle" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Style/Type</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlGrape" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Grape Variety</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlVintage" runat="server" Width="185px" AppendDataBoundItems="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Vintage Year</asp:ListItem>
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
    <asp:DropDownList ID="ddlCountry" runat="server" Width="185px" AppendDataBoundItems="True" AutoPostBack="True" CssClass="search-dropdown">
      <asp:ListItem Selected="True">Choose a Country</asp:ListItem>
    </asp:DropDownList>
    <igmisc:WebAsyncRefreshPanel ID="warpRegion" runat="server" TriggerControlIDs="*ddlCountry" TriggerPostBackIDs="*$ddlRegion,*$warpSubRegion" Height="" Width="">
      <asp:DropDownList ID="ddlRegion" runat="server" Width="185px" AutoPostBack="True" CssClass="search-dropdown">
        <asp:ListItem>Choose a Region</asp:ListItem>
      </asp:DropDownList>
    </igmisc:WebAsyncRefreshPanel>
    <igmisc:WebAsyncRefreshPanel ID="warpSubRegion" runat="server" TriggerControlIDs="*ddlRegion" TriggerPostBackIDs="*$ddlSubRegion" Height="">
      <asp:DropDownList ID="ddlSubRegion" runat="server" Width="185px" CssClass="search-dropdown">
        <asp:ListItem>Choose a Sub-Region</asp:ListItem>
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
    <span class="note">Enter Up To 5 Keywords <br /> (Item #s, Producers, Vineyards, Etc.)</span>
    <asp:TextBox ID="txtName" runat="server" Width="184px" AutoCompleteType="Search" MaxLength="100" />
    <div class="btnSearch"><asp:ImageButton ID="imbbSearch" runat="server" ImageUrl="~/images/general/btn_advSearchWine.png" ToolTip="Click to Submit Wine Search" /></div>
    
    <asp:LinkButton ID="lbutReset" runat="server" Text="Click Here To Reset Search" CssClass="reset" />

</asp:Panel>
</div> <!-- .searchPanel -->