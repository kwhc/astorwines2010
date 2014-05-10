<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCSearchResults.ascx.vb" Inherits="Ucontrols_WUCSearchResults" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="~/Ucontrols/WUCSearchNoResultsHelp.ascx" TagName="searchHelp" TagPrefix="awSrc" %>
<%@ Register Src="~/Ucontrols/modalResponseWaitList.ascx" TagName="waitList" TagPrefix="modal" %>
<div>
    <asp:PlaceHolder ID="phSearchHelp" runat="server"><awSrc:searchHelp ID="searchHelp" runat="server" /></asp:PlaceHolder>
</div>
<div id="searchResultsContainer">
  <div class="searchResultsControls clearfix">
      <div class="searchResultsViewdd">View:&nbsp;
        <asp:DropDownList ID="ddlPageSize" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Width="68px">
          <asp:ListItem Selected="True">10</asp:ListItem>
          <asp:ListItem>15</asp:ListItem>
          <asp:ListItem>25</asp:ListItem>
          <asp:ListItem Value="100">100</asp:ListItem>
        </asp:DropDownList>
      </div>
      Sort By: &nbsp;
      <asp:DropDownList ID="ddlSearchSort" runat="server" AppendDataBoundItems="True" AutoPostBack="True" Width="150px">
       <asp:ListItem>Price (ascending)</asp:ListItem>
        <asp:ListItem>Name (alphabetical)</asp:ListItem>
        <asp:ListItem>Price (descending)</asp:ListItem>
        <asp:ListItem>Vintage</asp:ListItem>
        <asp:ListItem Selected="True">Popularity</asp:ListItem>
      </asp:DropDownList>
  </div>
<div style="clear: right; height: 10px;"><br /></div>
  <div style="float: right" class="clearfix">
    <cc1:CollectionPager ID="colpagSearchResults" runat="server" BackNextDisplay="HyperLinks" BackText="<" LabelStyle="" LabelText="Go to Page:" MaxPages="50" NextText=">" PageSize="3" SectionPadding="10" ControlCssClass="pagination" ShowFirstLast="True" ShowLabel="True" SliderSize="6" UseSlider="True" BackNextLocation="Split" BackNextStyle="" FirstText="<<" LastText=">>" PageNumbersSeparator="|" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowPageNumbers="True" BackNextLinkSeparator="|" ResultsLocation="None" HideOnSinglePage="False"></cc1:CollectionPager>
  </div>
  <cc1:CollectionPager ID="colpagSearchResults2" runat="server" BackNextDisplay="HyperLinks" BackText="<" LabelStyle="" LabelText="Go to Page:" MaxPages="50" NextText=">" PageSize="3" SectionPadding="10" ShowFirstLast="False" ShowLabel="False" SliderSize="6" UseSlider="True" BackNextLocation="None" BackNextStyle="" FirstText="<<" LastText=">>" PageNumbersSeparator="|" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;" ShowPageNumbers="False" BackNextLinkSeparator="|" ResultsLocation="Top" HideOnSinglePage="False"></cc1:CollectionPager>
  
  <div id="resultTable">
      <asp:DataList ID="datResults" runat="server" CellPadding="0" ShowFooter="False" ShowHeader="False" CssClass="result">
        <ItemTemplate>
            <div class="itemDetailContainer">
                <div class="itemImageContainer">
                    <asp:HyperLink ID="hyplItemPic" runat="server" />
                </div>
              
                <div class="itemCopyContainer">
                    <h2><asp:HyperLink ID="hyplItemName" runat="server"> <asp:Literal ID="itemName" runat="server" /> </asp:HyperLink></h2>
                    <div class="itemLabels"><asp:Literal ID="lblMisc" runat="server" /></div>
                    <asp:Image ID="imgInCart" runat="server" ImageUrl="~/images/as_InCart.gif" Visible="False" />
                    <asp:Literal ID="lblInCart" runat="server" Text="You currently have 2 bottles in your cart" Visible="False" />
                    <asp:Literal ID="lblDescr" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "sBinLabelNotes")) %>' />
                    <br />
                    <br />
                    <span class="itemNumber"><asp:Literal ID="lblItemNumber" runat="server" Text='<%# "Item #"&rtrim(databinder.eval(container.dataitem, "Item")) %>' /></span>
                    <div style="height: 3px;"></div>
                </div>
              
                <div style="clear: left; width: 0px;"></div>
    	    </div>
            </td>
            
            <td style="vertical-align: top;">
                <div class="itemPriceContainer">
                    <asp:Panel runat="server" ID="pnlInStock">
                        <ul>
                            <li>
                                <strong><asp:Literal ID="lblBottlePriceLabel" runat="server" Text="Single Bottle:" /></strong><br/>
                                <asp:Label ID="lblOldBottlePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "botprcfl")) %>' CssClass="wrongPrice" Visible="False"></asp:Label>
                                <asp:Label ID="lblNewBottlePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "botprc")) %>' /><br/>
                                <em><asp:Label ID="lblYouSave" runat="server" /></em>
                            </li>
                            <li>
                                <strong><asp:Literal ID="lblCaseLabel" runat="server" Text="Case of 9:" /></strong><br/>
                                <asp:Label ID="lblOldCasePrice" runat="server" CssClass="wrongPrice" />
                                <asp:Label ID="lblNewCasePrice" runat="server" Text='<%# "$"&rtrim(databinder.eval(container.dataitem, "casprc")) %>' /><br/>
                                <em><asp:Literal runat="server" ID="litCaseDiscount" /></em>
                            </li>
                        </ul>
                        
                        <div class="clearfix">
                            <igtxt:WebNumericEdit CssClass="qty wneQty" DataMode="Int" Font-Bold="False" ID="wneQty"
                                MaxLength="3" MaxValue="999" MinValue="1" runat="server" ValueText="1" HorizontalAlign="Center">
                            </igtxt:WebNumericEdit>
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="ddType dd">
                                <asp:ListItem Value="Bottle">Bottle(s)</asp:ListItem>
                                <asp:ListItem Value="Case">Case(s)</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/buttons/btn_addToCart_sm.png" />
                        <br />
                        <div class="clearfix" style="float: right;">
                            <asp:Image ID="imgVideo" runat="server" ImageUrl="~/images/general/searchVideo.gif"
                                Visible="True" alt="Video Available" />
                            <asp:Image ID="ImgPairing" runat="server" ImageUrl="~/images/general/searchPairing.gif"
                                Visible="True" Alt="Paring Avaliable" />
                            <asp:Image ID="ImgStaffPick" runat="server" ImageUrl="~/images/general/searchStaffPick.gif"
                                Visible="True" Alt="Staff Pick" />
                        </div>
                        <asp:Label ID="lblLimitedQty" runat="server" CssClass="limitedQty" Text="Limited Production: Only X bottle(s) per customer"
                            Visible="False"></asp:Label>
                        <asp:Literal ID="lblInStoreOnly" runat="server" Text="Available For In Store Purchase Only"
                            Visible="False" />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlOutOfStock">
                        <asp:Literal runat="server" ID="litOutOfStockMsg" />
                       <%-- <asp:ImageButton runat="server" ID="imgbWaitList" ImageUrl="~/images/as_checkout_notify_icon.gif"></asp:ImageButton>--%>
                        <asp:Literal ID="WaitLink" runat="server">*Notify Me*</asp:Literal>
                    </asp:Panel>
                </div>
        </ItemTemplate>
      </asp:DataList>
  </div>
  
  <div style="float: right; padding-top: 4px;">
    <cc1:CollectionPager ID="colpagSearchResults3" runat="server" BackNextDisplay="HyperLinks" BackText="<" LabelStyle="" LabelText="Go to Page:" MaxPages="50" NextText=">" PageSize="5" SectionPadding="10" ShowFirstLast="True" ShowLabel="True" SliderSize="6" UseSlider="True" BackNextLocation="Split" BackNextStyle="" FirstText="<<" LastText=">>" PageNumbersSeparator="|" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" ShowPageNumbers="True" BackNextLinkSeparator="|" ResultsLocation="None" HideOnSinglePage="False"></cc1:CollectionPager>
  </div>
  <cc1:CollectionPager ID="colpagSearchResults4" runat="server" BackNextDisplay="HyperLinks" BackText="<" LabelStyle="" LabelText="Go to Page:" MaxPages="50" NextText=">" PageSize="5" SectionPadding="10" ShowFirstLast="False" ShowLabel="False" SliderSize="6" UseSlider="True" BackNextLocation="None" BackNextStyle="" FirstText="<<" LastText=">>" PageNumbersSeparator="|" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;" ShowPageNumbers="False" BackNextLinkSeparator="|" ResultsLocation="Top" HideOnSinglePage="False"></cc1:CollectionPager>
</div>
<modal:waitList runat="server" ID="ucModalResponseWaitList" />