<%@ Page Language="VB" MasterPageFile="~/remoteStorefront.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SearchResultsSingle.aspx.vb" Inherits="SearchResultsSingle" title="Astor Wines & Spirits - Search Results Single Item" %>

<%@ Register Src="~/Ucontrols/WUCMoreLikeThis.ascx" TagName="WUCMoreLikeThis" TagPrefix="uc11" %>
<%@ Register Src="~/Ucontrols/WUCDefinitions.ascx" TagName="WUCDefinitions" TagPrefix="uc9" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCVideoTout.ascx" TagName="videoTout" TagPrefix="Vid" %>

<asp:Content ID="Content5" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="productPage">
    <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
    <div class="itemDetailImages clearfix">
    
        <div style="padding: 10px 0px;">
            <asp:Image ID="imgItemPic" runat="server" CssClass="centerImg" />
        </div>
      
        <div id="thumbnails" class="clearfix">
        
        <asp:PlaceHolder runat="server" ID="thumb1Holder">
            <div class="thumbnailHolder">
                <asp:Label ID="thumb1Lnk" runat="server" Text="" />
                    <asp:Image runat="server" ID="thumb1" CssClass="thumbnail" />
                <asp:Label ID="thumb1LnkEnd" runat="server" /><br />
                <span> label</span>                
            </div>
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="thumb2Holder">
            <div class="thumbnailHolder">
                <asp:Label ID="thumb2Lnk" runat="server" Text="" />
                    <asp:Image runat="server" ID="thumb2" CssClass="thumbnail" />
                <asp:Label ID="thumb2LnkEnd" runat="server" Text="" /><br />
                <span> bottle</span>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="thumb3Holder">
            <div class="thumbnailHolder clearfix">
                <asp:Label ID="thumb3Lnk" runat="server" Text="" />
                    <asp:Image runat="server" ID="thumb3" CssClass="thumbnail" />
                <asp:Label ID="thumb3LnkEnd" runat="server" Text="" /><br />
                <span> packaging</span>            
            </div>
        </asp:PlaceHolder>
                
      </div> <!-- #thumbnails -->
        
        <asp:PlaceHolder runat="server" ID="phStaffPick">
            <h3 class="block">Staff Pick</h3>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="kosherPassover" runat="Server">
            <h3 class="block">Kosher for Passover</h3>
        </asp:PlaceHolder>        
            
    </div> <!-- .itemDetailImages -->
 
    <div class="itemDetailMeta clearfix">
    
      <h1><asp:Literal ID="lblItemName" runat="server" /></h1>
    
      <div class="productTagLinks clearfix">
        Item # <asp:Literal ID="lblItem" runat="server" /> <asp:Literal ID="lblSize" runat="server" />
        <br /><br />
        
        <!--<asp:Literal ID="lblInfo" runat="server"></asp:Literal>-->
         <div id="itemSpecs" class="clearfix">
            <div class="leftColumn">
                <asp:PlaceHolder ID="phColor" runat="server">Color:
                <asp:LinkButton ID="lnkbColor" runat="server" Text="color" /><br /></asp:PlaceHolder>
                <asp:PlaceHolder ID="phVintage" runat="server">Vintage:
                <asp:LinkButton ID="lnkbVintage" runat="server" Text="vintage" /><br /></asp:PlaceHolder>
                <asp:PlaceHolder ID="phCountry" runat="server">Country:
                <asp:LinkButton ID="lnkbCountry" runat="server" Text="Country" /><br /></asp:PlaceHolder>  
            </div>
            <div class="rightColumn">
              
              <asp:PlaceHolder ID="phRegion" runat="server">
                  <asp:Label ID="lblLRegion" runat="server" Text="Region:" />
                  <asp:LinkButton ID="lnkbRegion" runat="server" Text="Region" /><br />
              </asp:PlaceHolder>
              
              <asp:PlaceHolder ID="phSubRegion" runat="server">
                  <asp:Label ID="lblSubRegion" runat="server" Text="Sub-Region:" />
                  <asp:LinkButton ID="lnkbSubRegion" runat="server" Text="Sub-Region" /><br />
              </asp:PlaceHolder>                
              
              <asp:PlaceHolder ID="phVineyard" runat="server">
                <asp:Label ID="lblVineyard" runat="server" Text="" /><br />
              </asp:PlaceHolder>
              
              <asp:PlaceHolder ID="phProducer" runat="server">
                  <asp:Label ID="lblProducer" runat="server" Text="Producer:" />
                  <asp:LinkButton ID="lnkbProducer" runat="server" Text="Producer" /><br />
              </asp:PlaceHolder>
              
              <asp:PlaceHolder ID="phGrape" runat="server">
                  Grape Variety:&nbsp
                  <asp:LinkButton ID="lnkbGrape1" runat="server" Text="" Visible="false" />&nbsp;
                  <asp:LinkButton ID="lnkbGrape2" runat="server" Text="" Visible="false" />&nbsp;
                  <asp:LinkButton ID="lnkbGrape3" runat="server" Text="" Visible="false" />&nbsp;
                  <asp:LinkButton ID="lnkbGrape4" runat="server" Text="" Visible="false" />&nbsp;
                  <asp:LinkButton ID="lnkbGrape5" runat="server" Text="" Visible="false" />
              </asp:PlaceHolder>
            </div>
            <asp:Label runat="server" ID="blTagsHead" />
         </div>
      </div> <!-- .productTagLinks -->
      <div style="clear: left;"></div>
       
      
      <div class="productPrice">
      
        <div class="itemDetailShare">
            <!--<asp:Image ID="imgOnSale" runat="server" ImageUrl="~/images/misc/icon_sale.gif" Visible="False" />      
            <br /><br />
            <asp:ImageButton ID="imgbAddWishList" runat="server" ImageUrl="~/images/general/btnAddToWishListSm.gif" />
            <br />-->
            <asp:imagebutton ID="imgbTellFriend" runat="server" ImageUrl="~/images/general/btnEmailToAFriendSm.gif" 
            OnClientClick="javascript:window.open('../AstorWinesEmailToFriend.aspx', 'EmailToAFriend', 'menubar=1,resizable=1,width=350,height=250');" CausesValidation="False" EnableViewState="False"/>
         </div>      
      
          <strong><asp:Literal ID="lblBottlepriceLabel" runat="server">Bottle Price: </asp:Literal></strong>
          <asp:Label ID="lblOldBottlePrice" CssClass="wrongPrice" runat="server" Visible="False" />
          <asp:Label ID="lblNewBottlePrice" runat="server" /> 
          
        <br />
          <strong><asp:Literal ID="lblYouSaveLabel" runat="server">You Save: </asp:Literal></strong>
          <asp:Label ID="lblYouSave" runat="server" />
        
          <strong><asp:Literal ID="lblCaseLabel" runat="server" /></strong>
          <asp:Label ID="lblOldCasePrice" CssClass="wrongPrice" runat="server" Visible="False" />
          <asp:Label ID="lblNewCasePrice" runat="server" />
        
          <br />
          <br />
          <asp:label ID="lblQty" runat="server" CssClass="lblQty">QTY: </asp:label>
          <igtxt:WebNumericEdit ID="wneQty" runat="server" DataMode="Int" MaxLength="3" MaxValue="999" MinValue="1" ValueText="1" Width="50px" Height="25px" CssClass="qty-picker">
            <SpinButtons Display="OnRight" LowerButtonTooltip="Decrease Qty" UpperButtonTooltip="Increase Qty" />
          </igtxt:WebNumericEdit>
          <asp:DropDownList ID="ddlType" runat="server" Width="90px" Height="25px" class="dd-item-type">
            <asp:ListItem Value="Bottle">Bottle(s)</asp:ListItem>
            <asp:ListItem Value="Case">Case(s)</asp:ListItem>
          </asp:DropDownList>
        <br />
        <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/general/btnAddToCartLg.gif" CssClass="addToCartBtn" />
                 
          <div>
              <br />
          </div>
      </div> <!-- .productPrice -->
      <div class="clearfix">
        <asp:Label ID="lblLimitedQty" runat="server" Text="Limited Production:  Only X bottle(s) per customer" Visible="False" />
        <asp:Label ID="lblInStoreOnly" runat="server" Text="Available For In Store Purchase Only" Visible="False" Width="227" />
        <asp:PlaceHolder ID="phTasting" runat="server">This item is being featured in a tasting on:
            <asp:LinkButton ID="lnkbTasting" runat="server" Text="tasting date" OnClientClick="window.document.forms[0].target='_self';" /><br />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phWineClub" runat="server">This item is featured in:
            <asp:LinkButton ID="lnkbWineClub" runat="server" Text="WineClub" OnClientClick="window.document.forms[0].target='_self';" /><br />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phClass" runat="server">This item is featured in 
            <asp:LinkButton ID="lnkbClass" runat="server" Text="AstorCenterClass" OnClientClick="window.document.forms[0].target='_blank';" /> at Astor Center
        </asp:PlaceHolder>
      </div>
    </div> <!-- .itemDetailMeta -->
  
<div class="col-notes">
        
    <asp:PlaceHolder ID="tastingNotes" runat="Server">
        <div class="section">
            <h2>Tasting Notes</h2>
            <div class="itemDescriptionBox">
                <asp:Label ID="lblDescr" runat="server" Text="Label" />
            </div>
        </div>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder ID="staffPick" runat="Server">
      <div class="section">
        <h2>Staff Pick Notes</h2>
        <div class="itemDescriptionBox">
            <strong><asp:Label ID="lblStaffPickTitle" runat="server" Text="" /></strong><br />
            <asp:Label ID="lblStaffPickNote" runat="server" Text="" /><br />
            <em><asp:Label ID="lblStaffName" runat="server" Text="" /></em>
        </div>
      </div>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder ID="embedVideo" runat="Server">
        <div class="section">
            <h2>Video Tasting Notes</h2>
            <div style="padding: 0px 20px 5px 5px; font-size: 11px; color: #563E23;">
             <!--<%-- <asp:Literal ID="litEmbedVideo" runat="server"></asp:Literal> --%>
         	        <div id="moogaloop" style="width: 315px; height: 225px;"></div>-->
         	        <!-- Video Tasting Section -->
                    <Vid:videoTout ID="videoTout1" runat="server" />
            </div>
        </div>
    </asp:PlaceHolder>
    
    <asp:PlaceHolder ID="pairingAdvice" runat="Server">
         <div class="section">
            <h2>Pairing Advice</h2>
            <div class="itemDescriptionBox">
                <asp:Label ID="lblPairingAdvice" runat="server" Text="Label" />
            </div>
         </div>
    </asp:PlaceHolder>
    
    <%--
    <asp:PlaceHolder ID="staffPick" runat="Server">
      <div class="notesTermsItemDetail">
        <h2><img src="images/general/staffPick.gif" alt="Astor Wines Staff Pick" /> Staff Pick</h2>
        <div class="itemDescriptionBox">
          <asp:Label ID="lblStaffPick" runat="server" Text="Label"></asp:Label>
          <br />
          <br />
        </div>
      </div>
    </asp:PlaceHolder>
     --%>
     
    <asp:PlaceHolder ID="glossary" runat="Server">
      <div class="section">
        <h2>Astor's Glossary of Terms</h2>
        <div class="itemDescriptionBox">
            <uc9:WUCDefinitions ID="WUCDefinitions1" runat="server" />
            <div style="float:right; padding:10px 0px 10px 0px;"> <asp:HyperLink ID="glossaryLink" runat="server" NavigateUrl="~/AstorGlossary.aspx">Check out the Astor Glossary</asp:HyperLink></div>
            <br /><br />
        </div>
      </div> <!-- .notesTermsItemDetail -->
    </asp:PlaceHolder>
    </div>
    
    <div class="moreLikeThisRightProductPage">
    
        <asp:PlaceHolder ID="UBCExtraordinary" runat="Server">
            <div class="section">
                <img src="images/general/img_ubc-label-extraordinary.jpg" alt="Ultimate Beverage Challenge Extraordinary" />
            </div>
        </asp:PlaceHolder>
        
        <asp:PlaceHolder ID="UBCExcellent" runat="Server">
            <div class="section">
                <img src="images/general/img_ubc-label-excellent.jpg" alt="Ultimate Beverage Challenge Excellent" />
            </div>
        </asp:PlaceHolder>
        
        <asp:Panel runat="server" ID="pnlUBC">
            <div id="ubc-container" class="section clearfix">
                <h3><img src="images/general/img_dot.jpg" class="dots" />UBC Awards<img src="images/general/img_dot.jpg" class="dots" /></h3>
                <asp:PlaceHolder ID="phUBCAwards" runat="Server" />
            </div>
        </asp:Panel>
    
        <asp:PlaceHolder ID="moreLikeThis" runat="Server">
            <h3><img src="images/general/img_dot.jpg" class="dots" />You May Also Enjoy<img src="images/general/img_dot.jpg" class="dots" /></h3>
            <div class="suggested-items">
                <uc11:WUCMoreLikeThis ID="WUCMoreLikeThis" runat="server" />
            </div> <!-- .notesYouMayEnjoy -->
        </asp:PlaceHolder>
    </div> <!-- moreLikeThisRightProductPage -->
  </div> <!-- #productPage -->
     
 
</asp:Content>