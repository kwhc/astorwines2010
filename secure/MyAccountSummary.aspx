<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="MyAccountSummary.aspx.vb" Inherits="MyAccountSummary" title="Astor Wines & Spirits - My Account - Summary" %>

<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc6" %>
<%@ Register Src="../Ucontrols/WUCBillingName.ascx" TagName="WUCBillingName" TagPrefix="uc2" %>
<%@ Register Src="../Ucontrols/WUCShippingName.ascx" TagName="WUCShippingName" TagPrefix="uc3" %>
<%@ Register Src="../Ucontrols/WUCCreditCard.ascx" TagName="WUCCreditCard" TagPrefix="uc4" %>
<%@ Register Src="../Ucontrols/WUCCreditCardNoCVV.ascx" TagName="WUCCreditCardNoCVV" TagPrefix="uc5" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="WUCMyAccountNav" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCMyAccountNav.ascx" TagName="AccountNavigation" TagPrefix="awNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="myAccountPage">
    <div id="mainContentHeader">
        <h1>My Account</h1>
    </div>
    <div>
    <awNav:AccountNavigation ID="AccountNavigation1" runat="server" />
    </div>
    <div class="accountMaintenanceSection">
        <h2>Billing Address/Email Address</h2>
        <br />
        <asp:Label ID="lblBillingNone" runat="server" CssClass="pt14blsize" Text="None" />
        <uc2:WUCBillingName ID="WUCBillingName1" runat="server" />
        <br />
        <asp:ImageButton ID="imgbEditBillingAddress" runat="server" ImageUrl="~/images/as_editbillingaddress.icon.gif" />
        <asp:ImageButton ID="imgbEditEmailAddress" runat="server" ImageUrl="~/images/as_myaccount_changeemailaddress.icon.gif" />
    </div>
           
           <div class="accountMaintenanceSection">
                <h2>Primary Shipping Address</h2>
            <br />
                <asp:Label ID="lblShippingNone" runat="server" CssClass="pt14blsize" Text="None" />
                <uc3:WUCShippingName ID="WUCShippingName1" runat="server" />
                <br />
                <asp:ImageButton ID="imgbEditShippingAddress" runat="server" ImageUrl="~/images/as_editshippingaddress.icon.gif" />
           </div>
            
            <div class="accountMaintenanceSection">
                <h2>Primary Credit Card</h2>
                <br />
                <asp:Label ID="lblCreditCardNone" runat="server" CssClass="pt14blsize" Text="None" />
                <uc5:WUCCreditCardNoCVV ID="WUCCreditCardNoCVV1" runat="server" /> <br />
                <asp:ImageButton ID="imgbEditCreditCardInfo" runat="server" ImageUrl="~/images/as_editcreditcardinfo.icon.gif" />
            </div>
            
            <div class="accountMaintenanceSection">
                <h2>Most Recent Order</h2>
                <br />
                <asp:Label ID="lblMostRecentOrder" runat="server" CssClass="pt14blsize" Text="None" />
                <table>
                <tr>
                <td><asp:Label ID="lblLInum" runat="server" Text="Order Number:" /></td>
                <td><asp:Label ID="lblInum" runat="server" Text="123456" /></td>
                </tr>
                <tr>
                <td><asp:Label ID="lblLPlacedOn" runat="server" Text="Placed on:" /></td>
                <td><asp:Label ID="lblPlacedOn" runat="server" Text="4/1/2007" /></td>
                </tr>
                <tr>
                <td><asp:Label ID="lblLOrderTotal" runat="server" Text="Order Total:" /></td>
                <td><asp:Label ID="lblOrderTotal" runat="server" Text="$10.00" /></td>
                </tr>
                <tr>
                <td><asp:Label ID="lblLOrderStatus" runat="server" Text="Order Status:"></asp:Label></td>
                <td><asp:Label ID="lblOrderStatus" runat="server" Text="approved"></asp:Label></td>
                </tr>
                </table>
            </div>
    </div>
</asp:Content>