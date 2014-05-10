<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCGiftCardEdit.ascx.vb" Inherits="Ucontrols_WUCGiftCardEdit" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<div>
    Please enter your credit card information to use your Gift Card.<br />
    <a href="../giftcardhelp.htm?keepThis=true&TB_iframe=true&height=300&width=500" class="thickbox">Why do we need your credit card information?</a>
</div>

<br />

<asp:Label runat="server" ID="lblGiftCardNumber" Text="Gift Card Number:" /><br />
<asp:TextBox ID="txtGiftCardNumber" runat="server" Width="271px" MaxLength="19" CssClass="grey" />&nbsp;
<asp:Button ID="btnGetBalance" runat="server" Text="Check Balance" CssClass="btn" /><br />
<p class="help">Enter with no dashes or spaces then click &quot;Check Balance&quot; to use card for this order</p>

<igmisc:WebAsyncRefreshPanel ID="warp1" runat="server" TriggerControlIDs="*$btnGetBalance">

    <asp:Label ID="lblLGiftCardBalance" runat="server" Text="Current Gift Card Balance:&nbsp" />
    <asp:Label ID="lblGiftCardBalance" runat="server" Text="" />
    &nbsp
    <asp:Label ID="Label1" runat="server" Text="" />
    <br /><br />

</igmisc:WebAsyncRefreshPanel>

