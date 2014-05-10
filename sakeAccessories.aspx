<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="sakeAccessories.aspx.vb" Inherits="sakeAccessories" %>

<%@ Register Src="~/Ucontrols/WUCSearchResults.ascx" TagName="WUCSearchResults" TagPrefix="uc4" %>
<%@ Register Src="Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc2" %>
<%@ Register Src="~/Ucontrols/WUCEmailSignUpNew.ascx" TagName="WUCEmailSignUpNew" TagPrefix="uc8" %>
<%@ Register Src="~/Ucontrols/WUCAstorCenter.ascx" TagName="WUCAstorCenter" TagPrefix="uc10" %>
<%@ Register Src="~/Ucontrols/WUCSuggest.ascx" TagName="WUCSuggest" TagPrefix="uc11" %>
<%@ Register Src="~/Ucontrols/WUCLastItems.ascx" TagName="WUCLastItems" TagPrefix="uc12" %>
<%@ Register Src="~/Ucontrols/WUCGlossary.ascx" TagName="WUCGlossary" TagPrefix="uc15" %>
<%@ Register Src="~/Ucontrols/WUCSakeAccessories.ascx" TagName="WUCSakeAcc" TagPrefix="uc16" %>
<%@ Register Src="Ucontrols/WUCSakeSearch.ascx" TagName="WUCSakeSearch" TagPrefix="uc6" %>

<asp:Content ID="Content4" ContentPlaceHolderID="searchContent" Runat="Server">
  <div style="border: solid 1px #50340C; width: 205px;">
    <uc6:WUCSakeSearch ID="WUCSakeSearch1" runat="server" showheader="true" />
  </div>
  <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="middleContent" Runat="Server">
<div id="sakeAccessories">
  <h1 class="mainHeader">Saké Accessories</h1>
  <div style="padding: 5px;">
    Accessories text...
    <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
  </div>
  <div>
    <uc4:WUCSearchResults ID="WUCSearchResults1" runat="server" />  
  </div>
</div>
</asp:Content>