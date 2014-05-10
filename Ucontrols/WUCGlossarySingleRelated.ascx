<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCGlossarySingleRelated.ascx.vb" Inherits="Ucontrols_WUCGlossarySingleRelated" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<div id="dailyFeatures" style="width: 185px;">
  <div style="position:relative; top: -1px; font-size:10px; background-color: #FFFFFF; padding-right:2px;">
    <div class="dailyFeatureTitle">
   <asp:Literal ID="featureTitle" runat="server" />
   </div>
    <div style="float:left; font-size:10px; line-height: 16px;">
      <asp:Image runat="server" ID="featureImage" CssClass="featureImage" ImageAlign="left" Width="72px" Height="142px" AlternateText="" />
      <asp:Literal ID="featureDescription" runat="server"></asp:Literal>
      <br />
      <asp:HyperLink ID="featureLink" runat="server">read more</asp:HyperLink>
      <br />
      Item #<asp:Literal ID="featureItemNr" runat="Server"></asp:Literal>
      <!-- <div style="line-height: 15px;"><asp:Literal ID="featurePrice" runat="server"></asp:Literal></div> -->
    </div>
    <div style="clear:left; padding-left: 10px;"></div>
    
  <!--  <div style="position: absolute; bottom: 3px;">
      
       <div style="height: 2px;"></div>
       <div style="padding-left: 10px; padding-top: 3px; float: left;">Qty:&nbsp;</div>
      
      
      <div style="float: left; padding-right: 8px;">
        <igtxt:WebNumericEdit ID="wneQty" runat="server" BorderStyle="Solid" DataMode="Int" MaxLength="3" MaxValue="999" MinValue="1" ValueText="1" Width="40px">
          <SpinButtons Display="OnRight" LowerButtonTooltip="Decrease Qty" UpperButtonTooltip="Increase Qty" />
        </igtxt:WebNumericEdit>
      </div>
      <div style="float: left;">
        <asp:DropDownList ID="ddlType" runat="server" Width="84px">
          <asp:ListItem Value="Bottle">Bottle(s)</asp:ListItem>
          <asp:ListItem Value="Case">Case(s)</asp:ListItem>
        </asp:DropDownList>
      </div>
      <div style="clear: left;"></div>
      <div style="position: relative; left: 108px;"><asp:ImageButton ID="btnAddToCart" runat="server" ImageUrl="~/images/general/btnAddToCart.gif" /></div> 
    </div> -->
    
  </div>
  <br />
</div>