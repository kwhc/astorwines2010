<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="SearchResultsSingle.aspx.vb" Inherits="SearchResultsSingle" title="Astor Wines & Spirits - Search Results Single Item" %>

<%@ Register Src="Ucontrols/WUCMoreLikeThis.ascx" TagName="WUCMoreLikeThis" TagPrefix="uc11" %>
<%@ Register Src="Ucontrols/WUCDefinitions.ascx" TagName="WUCDefinitions" TagPrefix="uc9" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCVideoTout.ascx" TagName="videoTout" TagPrefix="Vid" %>
<%@ Register Src="~/Ucontrols/modalResponseWaitList.ascx" TagName="waitList" TagPrefix="modal" %>

<asp:Content ContentPlaceHolderID="HeadSupplement" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="searchContent" Runat="Server">
   <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="middleContent" Runat="Server">
 
<script type="text/javascript">
    var addToCart;
    $(function() {
        $("#confirmDialog").dialog({
            autoOpen: false,
            dialogClass: "no-close",
            modal: true,
            buttons: {
                'OK': function() {
                    $(this).dialog('close');
                    __doPostBack(addToCart, 'true');
                },
                'Cancel': function() {
                    $(this).dialog('close');
                    callback(false);
                }
            }
        });
    });
    function confirmation() {
        addToCart = '<%= imgbAddToCart.ClientID %>';
        $('#confirmDialog').dialog('open');
    }

</script>

<div id="confirmDialog" style="display:none;">
Currently this item is only available for shipment to Manhattan, Brooklyn and Queens.
</div> 
  
  <div id="productPage">
    <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
    <div class="itemDetailImages clearfix">
    
        <div style="padding: 10px 0px;">
            <asp:Image ID="imgItemPic" runat="server" CssClass="centerImg" />
        </div>
        <div id="thumbnails" class="clearfix">
        
        <asp:PlaceHolder runat="server" ID="thumb1Holder">
            <div class="thumbnailHolder">
                <asp:Literal ID="thumb1Lnk" runat="server" Text="" />
                    <asp:Image runat="server" ID="thumb1" CssClass="thumbnail" />
                <asp:Literal ID="thumb1LnkEnd" runat="server" /><br />
                <span> label</span>                
            </div>
            <asp:Literal runat="server" ID="litThumb1Img" />
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="thumb2Holder">
            <div class="thumbnailHolder">
                <asp:Literal ID="thumb2Lnk" runat="server" Text="" />
                    <asp:Image runat="server" ID="thumb2" CssClass="thumbnail" />
                <asp:Literal ID="thumb2LnkEnd" runat="server" Text="" /><br />
                <span> bottle</span>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="thumb3Holder">
            <div class="thumbnailHolder clearfix">
                <asp:Literal ID="thumb3Lnk" runat="server" Text="" />
                    <asp:Image runat="server" ID="thumb3" CssClass="thumbnail" />
                <asp:Literal ID="thumb3LnkEnd" runat="server" Text="" /><br />
                <span> packaging</span>            
            </div>
            <asp:Literal runat="server" ID="litThumb3Img" />
        </asp:PlaceHolder>
                
      </div> <!-- #thumbnails -->
        
        <asp:Image runat="server" ID="imgEasterEgg" Style="margin: 20px 0px;" Visible="False" />    
        
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
                    <asp:LinkButton ID="lnkbColor" runat="server" Text="color" /><br />
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phVintage" runat="server">Vintage:
                    <asp:LinkButton ID="lnkbVintage" runat="server" Text="vintage" /><br />
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phCountry" runat="server">Country:
                    <asp:LinkButton ID="lnkbCountry" runat="server" Text="Country" /><br />
                </asp:PlaceHolder>  
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
              
               <asp:PlaceHolder ID="phABV" runat="server">
                <asp:Label ID="lblAbv" runat="server" Text="" /><br />
              </asp:PlaceHolder>
              
              <asp:PlaceHolder ID="phSakeMeterValue" runat="server">
                <asp:Label ID="lblSakeMeterValue" runat="server" Text="" /><br />
              </asp:PlaceHolder>
              
              <asp:PlaceHolder ID="phProducer" runat="server">
                  <asp:Label ID="lblProducer" runat="server" Text="Producer:" />
                  <asp:LinkButton ID="lnkbProducer" runat="server" Text="Producer" /><br />
              </asp:PlaceHolder>
              
              <asp:PlaceHolder ID="phGrape" runat="server">
                  Grape Variety:&nbsp
                  <asp:LinkButton ID="lnkbGrape1" runat="server" Text="" Visible="false" />
                  <asp:LinkButton ID="lnkbGrape2" runat="server" Text="" Visible="false" />
                  <asp:LinkButton ID="lnkbGrape3" runat="server" Text="" Visible="false" />
                  <asp:LinkButton ID="lnkbGrape4" runat="server" Text="" Visible="false" />
                  <asp:LinkButton ID="lnkbGrape5" runat="server" Text="" Visible="false" />
              </asp:PlaceHolder>
            </div>
            <asp:Label runat="server" ID="blTagsHead" />
         </div>
      </div> <!-- .productTagLinks -->
       
    <div class="productPrice">

        <asp:Panel runat="server" ID="pnlInStock">
            <ul class="pricing">
                <li>    
                    <div style="line-height:2.6em;display:block;width:inherit;"><strong><asp:Literal ID="litBottlepriceLabel" runat="server" Text="Single Bottle:" /></strong></div>
                    <asp:Literal ID="litOldBottlePrice" runat="server" Visible="False"/>
                    <asp:Literal ID="litNewBottlePrice" runat="server" />
                    <asp:Literal runat="server" ID="litBottleDiscount" />
                </li>
                <li>    
                    <div style="line-height:2.6em;display:block;"><strong><asp:Literal ID="litCaseLabel" runat="server" /></strong></div>
                    <asp:Literal ID="litOldCasePrice" runat="server" />
                    <asp:Literal ID="litNewCasePrice" runat="server" />
                    <asp:Literal runat="server" ID="litCaseDiscount" />
                </li>
            </ul>

            <igtxt:WebNumericEdit ID="wneQty" runat="server" DataMode="Int" MaxLength="3" MaxValue="999" MinValue="1" ValueText="1" Height="34px" CssClass="qty wneQty" HorizontalAlign="Center">
            </igtxt:WebNumericEdit>
            <asp:DropDownList ID="ddlType" runat="server" class="dd ddType" Height="40px">
                <asp:ListItem Value="Bottle">Bottle(s)</asp:ListItem>
                <asp:ListItem Value="Case">Case(s)</asp:ListItem>
            </asp:DropDownList>
            <br style="clear: both;" />
            <br />
            
            <asp:ImageButton ID="imgbAddToCart" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" CssClass="addToCartBtn" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlOutOfStock">
           <%-- <asp:ImageButton ID="imgNotifyMe" runat="server" ImageUrl="~/images/buttons/btn_notifyMe.png" CssClass="addToCartBtn">  
            </asp:ImageButton>--%>
            <div class="outOfStockMsg">
              <asp:Literal runat="server" ID="litOutOfStockMsg" />
              <%-- <asp:ImageButton runat="server" ID="imgbWaitList" ImageUrl="~/images/as_checkout_notify_icon.gif"></asp:ImageButton>--%>
              <asp:Literal ID="WaitLink" runat="server" Visible="true">*YES Notify Me*</asp:Literal>
            </div>
        </asp:Panel>

    </div> <!-- .productPrice -->

      <div class="clearfix">
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

    <asp:PlaceHolder ID="phAboutProducer" runat="Server" Visible="false">
      <div class="section">
        <h2>About the Producer</h2>
        <div class="itemDescriptionBox">
            <asp:Literal ID="litAboutProducer" runat="server" /><br/><br/>
            <asp:HyperLink ID="entryLink" runat="server" Text="Read More &raquo;" Visible="false" />
        </div>
      </div>
    </asp:PlaceHolder>
 
    <asp:PlaceHolder ID="glossary" runat="Server">
      <div class="section">
        <h2>Astor's Glossary of Terms</h2>
        <div class="itemDescriptionBox">
            <uc9:WUCDefinitions ID="WUCDefinitions1" runat="server" />
            <asp:HyperLink ID="glossaryLink" runat="server" NavigateUrl="~/AstorGlossary.aspx" Text="Check out the Astor Glossary" />
        </div>
      </div> <!-- .notesTermsItemDetail -->
    </asp:PlaceHolder>
    </div>
    
    <div class="moreLikeThisRightProductPage">
        <asp:PlaceHolder runat="server" ID="phItemNotes">
            <div style="border:solid 1px #dddddd;padding:12px;margin-bottom:30px;color:#555555;">
            <h4>Item Notes</h4>
            <ul style="line-height:1.6em;">
                <asp:Literal ID="lblLimitedQty" runat="server" Text="Limited Production:  Only X bottle(s) per customer" Visible="False" />
                <asp:Literal ID="litInStoreOnly" runat="server" Text="<li>Available For In Store Purchase Only</li>" Visible="False" />
                <li style="margin-bottom:1em;">Currently this item is only available for shipment to Manhattan, Brooklyn and Queens.</li>
                <li style="margin-bottom:1em;">Currently this item cannot be shipped via UPS or FedEx.</li>
            </ul>
            </div>
        </asp:PlaceHolder>
        <div class="share-container row round clearfix">
            <!--<asp:Image ID="imgOnSale" runat="server" ImageUrl="~/images/misc/icon_sale.gif" Visible="False" />      
            <br /><br />
            <asp:ImageButton ID="imgbAddWishList" runat="server" ImageUrl="~/images/general/btnAddToWishListSm.gif" />
            <br />-->
            <h4>Share this bottle</h4>
            <span class="count email">
                <span class="label">
                    <asp:HyperLink ID="hlTellFriend" runat="server" Text="Email" rel="modal:open" />
                </span>
            </span>
            
            <div id="sharePage"></div>
            
            <script src="js/jquery-socialButtons.min.js" type="text/javascript" charset="utf-8"></script>
            <script type="text/javascript" charset="utf-8">
                function getUrlVars() {
                    var vars = [], hash;
                    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                    for (var i = 0; i < hashes.length; i++) {
                        hash = hashes[i].split('=');
                        vars.push(hash[0]);
                        vars[hash[0]] = hash[1];
                    }
                    return vars;
                }

                var type = getUrlVars()["p"];
                var item = getUrlVars()["search"];

                $('#sharePage').socialButtons({
                    url: 'http://www.astorwines.com/SearchResultsSingle.aspx?p=' + type + '&search=' + item + '&searchtype=Contains'
                });        

              </script>
         </div> <!-- .share-container -->
          
        <asp:Panel runat="server" ID="pnlUBC">
            <div id="ubc-container" class="section clearfix">
                <h3><img src="images/general/img_dot.jpg" class="dots" />UBC Awards<img src="images/general/img_dot.jpg" class="dots" /></h3>
                <asp:PlaceHolder ID="phUBCAwards" runat="Server" />
            </div>
        </asp:Panel>
    
        <asp:PlaceHolder ID="moreLikeThis" runat="Server">
            <h3 class="dots"><img src="images/general/img_dot.jpg" class="dots" />You May Also Enjoy<img src="images/general/img_dot.jpg" class="dots" /></h3>
            <div class="suggested-items">
                <uc11:WUCMoreLikeThis ID="WUCMoreLikeThis" runat="server" />
            </div> <!-- .notesYouMayEnjoy -->
        </asp:PlaceHolder>
    </div> <!-- moreLikeThisRightProductPage -->
  </div> <!-- #productPage -->
  
 
 <asp:Literal runat="server" ID="litThumb2Img" />

 <asp:Panel runat="server" ID="pnlEmailShareSucccess" Visible="false">
      <div id="emailShareSuccess" style="display: none;">
        <p style="text-align:center;">Thanks for sharing!</p>
      </div>

     <script type="text/javascript">
         $(document).ready(function() {
             $('#emailShareSuccess').modal({
                 opacity: 0
             });
         });
     </script>
 </asp:Panel>

<modal:waitList runat="server" ID="ucModalResponseWaitList" />


</asp:Content>