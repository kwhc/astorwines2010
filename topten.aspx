<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="topten.aspx.vb" Inherits="topten" title="Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc4" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="topTen">

    <div style="padding: 5px 5px 5px 10px; font-size: 12px;">
      <div style="float: left; width: 580px;"><asp:Image ID="imgFeature" runat="server" ImageUrl="~/images/features/as_features_astorfavorites_1_1.gif" style="float: left; padding-right: 20px; " />
      <br />
      <h1 class="packHeader"><asp:Literal ID="lblItemName" runat="server"></asp:Literal></h1>      
      Item #&nbsp;<asp:Literal ID="lblItem" runat="server" Text="12345"></asp:Literal><br />
      <asp:Literal ID="lblInfo" runat="server" Text="Label"></asp:Literal><br />
      Pack Price:&nbsp;<asp:Literal ID="lblNewBottlePrice" runat="server"></asp:Literal>
      <asp:Label ID="lblOldBottlePrice" runat="server" Text="botprcfl" CssClass="wrongPrice" Visible="False"></asp:Label><br />
      <div style="padding-top: 7px;">
        <div style="float:left; padding: 2px 10px 0px 0px;">Qty:</div>
        <div style="float:left; padding-right: 10px;">
          <igtxt:WebNumericEdit ID="wneQty" runat="server" DataMode="Int" MaxLength="3" MaxValue="999" MinValue="1" ValueText="1" Width="50px">
            <SpinButtons Display="OnRight" LowerButtonTooltip="Decrease Qty" UpperButtonTooltip="Increase Qty" />
          </igtxt:WebNumericEdit> 
        </div>
        <div style="float: left; padding-top: 2px;">Pack(s)</div>&nbsp&nbsp<asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/as_addtocart.gif" />
        <div style="clear: left; height: 8px;"></div>
        <asp:Literal ID="litFeature" runat="server"></asp:Literal>
      </div>  
      
      <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" /><br />
    </div></div>
    <div style="clear: left; height: 5px;"></div>
    <div style="font-size: 12px;">
      <uc4:WUCSearchResults ID="WUCSearchResults1" runat="server" />
    </div>  
  </div>
</asp:Content>