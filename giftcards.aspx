<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="giftcards.aspx.vb" Inherits="giftcards" title="Astor Wines & Spirits - Gift Cards" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register src="Ucontrols/WUCGiftCardBalance.ascx" tagname="WUCGiftCardBalance" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="giftCards" class="page">
        <h1>Gift Cards</h1>
      <div class="giftCardContainer">
        <div class="pictureFrame" style="float: left;">
            <img src="images/general/giftCard.jpg" width="240px" alt="Astor Wines &amp; Spirits Gift Cards"/>
        </div>
        <div style="text-align: justify; float: left; width: 260px;">
              <p>
              If you’re not sure what they like, stop guessing and get them a Gift Card! Whether your loved ones shop online, in-store, or over the phone, they can use a Gift Card for any purchase from Astor Wines & Spirits. Save time shopping and give the ideal gift!
              </p>
              <br />
              <span class="boldNote">Astor Wines & Spirits gift cards are now redeemable online!</span>
              <br />
              <br />
              <br />
              <asp:Label runat="server" AssociatedControlID="giftCardAmount" CssClass="boldNote">Gift Card Amount: </asp:Label>
                <asp:DropDownList runat="server" ID="giftCardAmount" CssClass="giftCardAmountDD">
                    <asp:ListItem Value="99025">$25</asp:ListItem>
                    <asp:ListItem Value="99050">$50</asp:ListItem>
                    <asp:ListItem Value="99075">$75</asp:ListItem>
                    <asp:ListItem Value="99100">$100</asp:ListItem>
                    <asp:ListItem Value="99150">$150</asp:ListItem>
                    <asp:ListItem Value="99200">$200</asp:ListItem>
                    <asp:ListItem Value="99250">$250</asp:ListItem>
                    <asp:ListItem Value="99300">$300</asp:ListItem>
                    <asp:ListItem Value="99500">$500</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:ImageButton ID="addToCart" runat="server" ImageUrl="~/images/as_addtocart.gif" />

                <br />

            </div>           
            <br style="clear: both;" />
         </div>
         
         <uc1:WUCGiftCardBalance ID="WUCGiftCardBalance1" runat="server" />
         
         <div id="delivery" style="margin-top: 40px;">
            <p style="font-size: 8pt; line-height: 18px; text-align: center;">Astor Wines & Spirits Gift Cards are not redeemable for Astor Center event purchases.</p>
         </div>
        
     </div>
</asp:Content>