<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCBooksAssocSearch.ascx.vb" Inherits="Ucontrols_WUCBooksAssocSearch" %>

<asp:PlaceHolder ID="plcShowHeader" runat="server">
  <div class="expandedSearchHeader" style="font-weight: bold;">
    Accessories Search
  </div>
</asp:PlaceHolder>
<div class="searchPanel">
  <asp:Panel runat="server" DefaultButton="imbbSearch" ID="pnlSearch">
    <div style="height: 6px;"></div>
    Select one criterion or many.
    <div style="height: 6px;"></div> 
    <asp:DropDownList ID="ddlPriceRange" runat="server" Width="185px" AppendDataBoundItems="True">
      <asp:ListItem Selected="True">Choose a Price Range</asp:ListItem>
    </asp:DropDownList>
    <div style="height: 6px;"></div>
    <asp:DropDownList ID="ddlCat" runat="server" Width="185px" AppendDataBoundItems="True">
      <asp:ListItem Selected="True">Choose a Category</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <span>Enter up to 5 keywords,  item #s, specific names, producers, etc.</span>
    <asp:TextBox ID="txtName" runat="server" Width="185px" AutoCompleteType="Search" MaxLength="100"></asp:TextBox>
    <div style="position: relative; left: 87px;"><asp:ImageButton ID="imbbSearch" runat="server" ImageUrl="~/images/as_submitSearch.gif" ToolTip="Click to Submit Sake Search"/></div>
    <br />
    <span>
      <asp:LinkButton ID="lbutReset" runat="server">Click here</asp:LinkButton> to reset the search bars.
    </span>
  </asp:Panel>
</div>