<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="MyAccountCreditCardBillingAddresses.aspx.vb" Inherits="secure_MyAccountCreditCardBillingAddresses" title="My Billing Info | Astor Wines & Spirits" %>

<%@ Register Src="../Ucontrols/WUCCreditCardEdit.ascx" TagName="WUCCreditCardEdit" TagPrefix="uc17" %>
<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc18" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc6" %>
<%@ Register Src="../Ucontrols/WUCBillingName.ascx" TagName="WUCBillingName" TagPrefix="uc2" %>
<%@ Register Src="../Ucontrols/WUCShippingName.ascx" TagName="WUCShippingName" TagPrefix="uc3" %>
<%@ Register Src="../Ucontrols/WUCCreditCard.ascx" TagName="WUCCreditCard" TagPrefix="uc4" %>
<%@ Register Src="../Ucontrols/WUCCreditCardNoCVV.ascx" TagName="WUCCreditCardNoCVV" TagPrefix="uc5" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="AccountNavigation" TagPrefix="awNav" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">  
  <div id="myBillingInfo">
    <div id="mainContentHeader">
        <h1>My Billing Info</h1>
    </div> 
    <awNav:AccountNavigation ID="AccountNavigation1" runat="server" />
    <div class="accountMaintenanceIntro">
    Here you can edit your billing address, add a credit card or change your credit card info.
    </div>
                                            
    <asp:ImageButton ID="imgbSaveChangesTop" runat="server" ImageUrl="~/images/as_savechanges.icon.gif" AlternateText="Save Changes" ToolTip="Save Changes" ValidationGroup="vgBilling" Visible="False" />

     <div class="accountMaintenanceSection">       
            <div style="margin-left: 30px; margin-bottom: 20px;">
            <asp:ValidationSummary ID="vsBilling" runat="server" HeaderText="Please correct the following errors:"
                ValidationGroup="vgBilling" />
            </div>
                <h2>Billing Address</h2>
                
            <uc2:WUCBillingName ID="WUCBillingName1" runat="server" /><br />
         <asp:LinkButton ID="lnkbEditBilling" runat="server" Width="175px" Height="20px" CssClass="btn-stroke-black">Edit Billing Address &raquo;</asp:LinkButton>
  
        <uc6:WUCBillingNameEdit ID="WUCBillingNameEdit1" runat="server" />
        </div>

        <div class="accountMaintenanceSection">
            <h2>Payment Information</h2>
        
            <asp:Label ID="lblLCC" runat="server" CssClass="pt12blsize" Text="Credit Card(s)" Width="111px" />
            <asp:DropDownList ID="ddlCreditCard" runat="server" CssClass="dropdown" Width="283px" AutoPostBack="True"></asp:DropDownList>
            
            &nbsp;<uc5:WUCCreditCardNoCVV ID="WUCCreditCardNoCVV1" runat="server" />
            
            <br /><br />
            <asp:LinkButton ID="lnkbAddCreditCard" runat="server" Width="175px" CssClass="btn-stroke-black">+ Add New Credit Card</asp:LinkButton>
                        
            <asp:LinkButton ID="lnkbDeleteCreditCard" runat="server" Width="175px" CssClass="btn-stroke-black" OnClientClick="return confirm('Are you sure you want to delete this credit card?');">Delete Credit Card &raquo;</asp:LinkButton>
                        
            <uc17:WUCCreditCardEdit ID="WUCCreditCardEdit1" runat="server" />

            <asp:ImageButton ID="imgbSaveChangesBottom" runat="server" ImageUrl="~/images/as_savechanges.icon.gif" AlternateText="Save Changes" ToolTip="Save Changes"  ValidationGroup="vgBilling" Visible="False" />
        </div>                    
</div>
</asp:Content>