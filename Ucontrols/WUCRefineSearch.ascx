<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCRefineSearch.ascx.vb" Inherits="Ucontrols_WUCRefineSearch" %>

<div class="refineSearch">
<h3>~ Refine Your Results ~</h3>
    <br style="line-height: 2px;" />
    
    <!--<div class="expandedSearchHeader" style="font-weight: bold;">Additional keywords</div>
    <span>Enter up to 5 keywords, item #s, specific producers, vineyards, etc.</span>
        <asp:TextBox ID="txtName" runat="server" Width="185px" AutoCompleteType="Search" MaxLength="100"></asp:TextBox>
        <div style="position: relative; left: 87px;"><asp:ImageButton ID="imbbSearch" runat="server" ImageUrl="~/images/as_submitSearch.gif" ToolTip="Click to Submit Wine Search" /></div>
        <br />-->
    
    <h4>Price</h4>
    
    <asp:DataList ID="datPrice" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkbPrice" runat="server" CommandName="price" Text='<%# rtrim(databinder.eval(container.dataitem, "sPriceRangeDesc")) %>'></asp:LinkButton>&nbsp
            <asp:Label ID="lblPriceAmount" runat="server" Text="PriceAmt" Font-Size="10px"></asp:Label>       
        </ItemTemplate>
    </asp:DataList>
    <asp:PlaceHolder ID="phRemovePrice" runat="server">
    <asp:ImageButton ID="imgbRemovePrice" runat="server" ImageUrl="/images/general/removeButton.gif" ToolTip="Click to Remove Price Limit" /><span class="remove">remove</span></asp:PlaceHolder>
     
    <h4>Country</h4>

    <asp:DataList ID="datCountry" runat="server">
        <ItemTemplate>
            <asp:LinkButton ID="lnkbCountry" runat="server" CommandName="country" Text='<%# rtrim(databinder.eval(container.dataitem, "sCountry")) %>'></asp:LinkButton>&nbsp
            <asp:Label ID="lblCountryNameCount" runat="server" Text="CntyNameCount" Font-Size="10px"></asp:Label>
        </ItemTemplate>
       
    </asp:DataList>
    <asp:PlaceHolder ID="phRemoveCountry" runat="server">
    <asp:ImageButton ID="imgbRemoveCountry" runat="server" ImageUrl="/images/general/removeButton.gif" ToolTip="Click to Remove Country Limit"/>Remove</asp:PlaceHolder>

    <h4>Region</h4>

    <asp:DataList ID="datRegion" runat="server">
        <ItemTemplate>
        
            <asp:LinkButton ID="lnkbRegion" runat="server" CommandName="region" Text='<%# rtrim(databinder.eval(container.dataitem, "sRegion")) %>'></asp:LinkButton>&nbsp
            <asp:Label ID="lblRegionNameCount" runat="server" Text="RegionNameCount" Font-Size="10px"></asp:Label>
        
            
            
        </ItemTemplate>
       
    </asp:DataList><asp:PlaceHolder ID="phRemoveRegion" runat="server">
     <asp:ImageButton ID="imgbRemoveRegion" runat="server" ImageUrl="/images/general/removeButton.gif" ToolTip="Click to Remove Region Limit"/>Remove</asp:PlaceHolder>

     <h4>Varietal</h4>

    <asp:DataList ID="datVarietal" runat="server">
        <ItemTemplate>
        
            <asp:LinkButton ID="lnkbVarietal" runat="server" CommandName="varietal" Text='<%# rtrim(databinder.eval(container.dataitem, "sVarietal")) %>'></asp:LinkButton>&nbsp
            <asp:Label ID="lblVarietalCount" runat="server" Text="VarietalCount" Font-Size="10px"></asp:Label>
        
            
            
        </ItemTemplate>
       
    </asp:DataList><asp:PlaceHolder ID="phRemoveVarietal" runat="server">
      <asp:ImageButton ID="imgbVarietal" runat="server" ImageUrl="/images/general/removeButton.gif" ToolTip="Click to Remove Varietal Limit"/>
      Remove</asp:PlaceHolder>

     <br />
 </div>
