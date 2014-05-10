<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="Specialpacks.aspx.vb" Inherits="Specialpacks" title="Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc4" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="packPage" class="page">
        <div class="clearfix">
            <div class="itemDetailImages">
                <asp:Image ID="imgFeature" runat="server" ImageUrl="~/images/features/as_features_astorfavorites_1_1.gif" style="float: left; padding-right: 8px;" />            
            </div>
            
            <div style="float: left; width: 290px;" class="clearfix">
                <h1><asp:Literal ID="lblItemName" runat="server" /></h1>      
                Item #&nbsp;<asp:Literal ID="lblItem" runat="server" Text="12345" /><br />
                <div style="margin-top: 8px;">
                    <asp:Literal ID="litFeature" runat="server" />
                    <asp:Literal ID="lblInfo" runat="server" Text="Label" />
                </div>
                <div class="productPrice" style="border-top: solid 1px rgb(221,221,221); margin-top: 20px; padding-top: 20px;">
                    Pack Price:&nbsp;<asp:Literal ID="lblNewBottlePrice" runat="server" />
                    <asp:Label ID="lblOldBottlePrice" runat="server" Text="botprcfl" CssClass="wrongPrice" Visible="False" /><br />
                    <div class="clearfix" style="padding-top: 7px; padding-bottom: 20px;">
                        <div>
                            <igtxt:WebNumericEdit ID="wneQty" runat="server" DataMode="Int" MaxLength="3" MaxValue="999" MinValue="1" ValueText="1" HorizontalAlign="Center" CssClass="qty wneQty">
                            </igtxt:WebNumericEdit> 
                        </div>
                        <div style="padding-top: 6px; float: left; font-size: 20px;">Pack(s)</div>
                    </div>  
                    <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" />
                </div>
          
                <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
            </div>
        </div>
        <div>
            <uc4:WUCSearchResults ID="WUCSearchResults1" runat="server" />
        </div>  
    </div>
</asp:Content>