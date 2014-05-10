<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCShoppingCart.ascx.vb" Inherits="Ucontrols_WUCShoppingCart" %>

<%--<div id="shoppingCart" style="border: solid 1px #50340C;  width: 160px; height: 160px; background-color: #FFFFFF;">--%>
  <!-- <asp:Literal ID="signInOutMsg1" runat="server"></asp:Literal> -->

<div id="userControlPanel">
    <asp:LinkButton ID="imgbShoppingCart" CssClass="viewCart" runat="server">My Cart <!--<img src="/images/general/shoppingCart.gif" alt="" style="position:relative; top: 4px;" />--> </asp:LinkButton>
    <span class="userControlPanelItems">(<asp:Literal ID="lblNumItems" runat="server">0</asp:Literal>
    Items) </span>

    <br />
    <asp:linkbutton id="signInOutMsg" onClick="SignInOut" runat="server"></asp:linkbutton> | 
    <asp:linkbutton id="lnkbCreateAccount" onClick="CreateAccount" runat="server"></asp:linkbutton> |
    <asp:LinkButton ID="lnkMyAccount" runat="server">my account</asp:LinkButton>
    <br />
    <asp:Literal ID="CustMsg1" runat="server"></asp:Literal>     

</div> <!-- #userControlPanel -->

<asp:PlaceHolder ID="phSavedShoppingCart" runat="server">
    <div id="savedCartMsg">
        <asp:LinkButton ID="imgbSavedShoppingCart" runat="server">&#9733; View My Saved Items</asp:LinkButton>
    </div>
</asp:PlaceHolder>




  <div>
    <!-- <span><asp:Literal ID="lblCartSubTotal" runat="server">0.00</asp:Literal></span><br /> -->
    
 <!--<asp:LinkButton ID="btnWishList" CssClass="homeSCButton" runat="Server">View Wish List <img src="/images/general/wishList.gif" alt="" style="position:relative; top: 4px;" /></asp:LinkButton><br />-->
 <!--<asp:PlaceHolder ID="pnlSignIn" runat="server">
      <div style="height: 1px;"></div>
      Want to save your cart?
      <div style="text-align:right"><asp:LinkButton ID="lnkbSignInNow" runat="server">Sign In</asp:LinkButton></div>
    </asp:PlaceHolder>-->
  </div>