<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCDailyFeatures.ascx.vb" Inherits="Ucontrols_WUCDailyFeatures" %>

<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<div class="dailyFeature clearfix">
  <h3>- <asp:Literal ID="featureTab" runat="server" /> -</h3>
    <div class="item-name"><asp:Literal ID="featureTitle" runat="server" /></div>
      <div>
        <asp:Literal ID="featureImageLink" runat="server" />
      </div>
      <div class="dailyFeaturesCopy">
        <asp:Literal ID="featureDescription" runat="server" />
        <br />
        <br />
        <span class="read-more"><asp:HyperLink ID="featureLink" runat="server">read more &raquo;</asp:HyperLink></span>
        <!-- Item #<asp:Literal ID="featureItemNr" runat="Server" /></span> -->
        <!-- <asp:LinkButton ID="seemore" runat="server"></asp:LinkButton> -->
      </div>
        <div class="dailyFeaturesPrice">
        Bottle Price: <asp:Literal ID="ltrBottlePrice" runat="server" /><br />
        Case of <asp:Literal ID="packInteger" runat="server" />: <asp:Literal ID="ltrCasePrice" runat="server" />
        </div>
      <!--
      <div>Qty:&nbsp;</div>
      <div style="float: left; padding-right: 8px;">
        <igtxt:WebNumericEdit ID="wneQty" runat="server" BorderStyle="Solid" DataMode="Int" MaxLength="3" MaxValue="999" MinValue="1" ValueText="1" Width="40px" >
          <SpinButtons Display="OnRight" LowerButtonTooltip="Decrease Qty" UpperButtonTooltip="Increase Qty" />
        </igtxt:WebNumericEdit>
      </div>
 
      <div>
        <asp:DropDownList ID="ddlType" runat="server" Width="84px">
          <asp:ListItem Value="Bottle">Bottle(s)</asp:ListItem>
          <asp:ListItem Value="Case">Case(s)</asp:ListItem>
        </asp:DropDownList>
      </div>
      
      <div style="position: relative; left: 113px;"><asp:ImageButton ID="btnAddToCart" runat="server" ImageUrl="~/images/general/btnAddToCart.gif" /></div>
    </div>
     -->
</div> <!-- .dailyFeature -->