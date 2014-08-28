<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="MyAccountShippingAddresses.aspx.vb" Inherits="secure_MyAccountShippingAddresses" title="Astor Wines & Spirits - My Account - Shipping Addresses" %>

<%@ Register Src="../Ucontrols/WUCShippingNameEdit.ascx" TagName="WUCShippingNameEdit" TagPrefix="uc19" %>
<%@ Register Src="../Ucontrols/WUCCreditCardEdit.ascx" TagName="WUCCreditCardEdit" TagPrefix="uc17" %>
<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc18" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc6" %>
<%@ Register Src="../Ucontrols/WUCBillingName.ascx" TagName="WUCBillingName" TagPrefix="uc2" %>
<%@ Register Src="../Ucontrols/WUCShippingName.ascx" TagName="WUCShippingName" TagPrefix="uc3" %>
<%@ Register Src="../Ucontrols/WUCCreditCard.ascx" TagName="WUCCreditCard" TagPrefix="uc4" %>
<%@ Register Src="../Ucontrols/WUCCreditCardNoCVV.ascx" TagName="WUCCreditCardNoCVV" TagPrefix="uc5" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="WUCMyAccountNav" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="AccountNavigation" TagPrefix="awNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="mainContentHeader" class="pageRow background-white">
    <h1>My Shipping Addresses</h1>
    </div>  
  <div id="myShippingAddresses">
    <awNav:AccountNavigation ID="AccountNavigation1" runat="server" />
    <div class="accountMaintenanceIntro">
    <br />
    Here you can add, edit, delete or change your default your shipping addresses.
    <br /><br /><br />
    </div>
    
    <asp:ImageButton id="imgbSaveChangesTop" runat="server" ImageUrl="~/images/as_savechanges.icon.gif" AlternateText="Save Changes" ToolTip="Save Changes" ValidationGroup="vgShipping" Visible="False" />
    
    <asp:ValidationSummary ID="vsShipping" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgShipping" />
    <br />
    <br />        
    
    <div class="margin-bottom-md">
        <asp:Label id="lblLShipping" runat="server" Text="Shipping Address(s):" Width="120px" />
        <asp:DropDownList id="ddlShipping" runat="server" AutoPostBack="True" CssClass="dropdown margin-bottom-sm" Width="283px"></asp:DropDownList>
        <asp:LinkButton ID="lnkbAddShipping" runat="server" CssClass="btn-stroke-black" Width="200px">+ Add Another Shipping Address</asp:LinkButton>
    </div>
    
    
    <div class="addressInfoMyAccount" style="">
        <uc3:WUCShippingName id="WUCShippingName1" runat="server" />
        <uc19:WUCShippingNameEdit ID="WUCShippingNameEdit1" runat="server" />
    </div>
      
    <br style="clear: both;" />
    
    <div class="myAccountEditButtons margin-bottom-md">        
        <asp:LinkButton ID="lnkbEditShipping" runat="server" Width="150px" CssClass="btn-stroke-black">Edit This Address &raquo;</asp:LinkButton>
        <asp:LinkButton ID="lnkbDeleteShipping" runat="server" Width="150px" CssClass="btn-stroke-black" OnClientClick="return confirm('Are you sure you want to delete this shipping address?');">Delete This Address &raquo;</asp:LinkButton>
        <br />
    </div>       
   
    <asp:ImageButton ID="imgbSaveChangesBottom" runat="server" ImageUrl="~/images/as_savechanges.icon.gif" AlternateText="Save Changes" ToolTip="Save Changes"  ValidationGroup="vgShipping" Visible="False" />

    <div class="background-red" style="padding:1rem;">
        <p>Due to restrictive regulations, we cannot accept orders for shipment to the following locations:</p> 
        <asp:Label ID="lblShipToStatesCodes" runat="server" Text="AZ, CA" />
    </div>

    </div>
</asp:Content>