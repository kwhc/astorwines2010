<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCQuickSearchNoAutoComplete.ascx.vb" Inherits="Ucontrols_WUCQuickSearchNoAutoComplete" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="quickSearch">
  <div>
       
      <cc1:TextBoxWatermarkExtender ID="tbwmeSearch" runat="server" TargetControlID="txt_Search" 
      WatermarkText="Search by keywords or item #" WatermarkCssClass="watermark">
      </cc1:TextBoxWatermarkExtender>
      
      <asp:TextBox ID="txt_Search" runat="server" MaxLength="100" TabIndex="1" Width="320px" />
      
      <asp:ImageButton ID="imbbSearch" runat="server" ImageUrl="../images/general/btn_quickSearchGo.png" ToolTip="Click to Submit Search" ImageAlign="Top" CssClass="searchButton" /> <br />
    <asp:Label ID="lblError" runat="server" Visible="False" CssClass="lblError"></asp:Label>
  </div>
  <div>
    <asp:HyperLink ID="advancedSearch" runat="Server"></asp:HyperLink>
    <asp:Label CssClass="searchExpl" ID="explanation" runat="server" />
  </div>
 

   

  
</div>
<asp:PlaceHolder ID="plcShowHeader" runat="server">
</asp:PlaceHolder>