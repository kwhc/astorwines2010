<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCCheckOutHeader.ascx.vb" Inherits="Ucontrols_WUCCheckOutHeader" %>

<div style="text-align:center;padding-top:2rem;padding-bottom:1rem;">
  <asp:Image ID="imgCheckOut" runat="server" Width="583" />
</div>
<div class="checkout-header-notes container clearfix" style="margin-bottom:2rem;text-align:center;">
    <p>Please do not use your browser's BACK button during checkout.</p>
    <asp:PlaceHolder runat="server" ID="phRequiredField"><p class="muted" style="float:right;">*Required Field</p></asp:PlaceHolder>
</div>