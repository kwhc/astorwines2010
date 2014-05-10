<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCGiftCardBalance.ascx.vb" Inherits="Ucontrols_WUCGiftCardBalance" %>
<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
   
 <div id="giftCardBalanceCheck">   
     <h3>Check Your Gift Card Balance</h3> 

        <asp:Label ID="Label1" runat="server" Text="Label">Card Number: &nbsp</asp:Label>
            <asp:TextBox ID="txtCardNumber" runat="server" MaxLength="19" Width="172px" Font-Size="14px"></asp:TextBox>    
        <asp:Button ID="btnPost" runat="server" Text="Check Balance" Width="110px" />&nbsp&nbsp
        <br />
        <br />
         <igmisc:WebAsyncRefreshPanel ID="warpGiftCard" runat="server" TriggerControlIDs="*$btnPost">
            <b>
            <asp:Label ID="Label2" runat="server" Text="Label">Your Balance: &nbsp</asp:Label>
            <asp:Label ID="lblResponse" Runat="server" />
            </b>
        </igmisc:WebAsyncRefreshPanel>

 </div>

