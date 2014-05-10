<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorWinesWineClubs.aspx.vb" Inherits="AstorWinesWineClubs" title="Wine Clubs | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    
  <div id="wineClubPage" class="info-page">
  
    <h1>Wine Clubs</h1>
  
    <div class="img-copy-row clearfix">
        <div class="imgContainer">
            <img src="images/logo_wineClub.png" alt=""/>
        </div>
        
        <div class="copyContainer gutter">
            <p>
            Running out of gift ideas?<br />
            Join the Club!
            </p>
            <p>
            Choose a theme below, and each month - for 3, 6, 9, or 12 months at a time - Astor will send a package of delicious wines to you or a lucky friend. Every delivery includes extensive tasting notes for the wines we've selected.</p>
        </div>
    </div>
    
    <div id="deliveryNote" class="clearfix">
        <h3>Giving a Wine Club as a gift?</h3>
        <p> 
        An adult 21 years of age or older must be present to sign for each Wine Club delivery. Please provide a shipping address at which an adult will be available to receive the package during UPS delivery times: business hours, Monday through Friday. For many customers, the easiest option is to send Wine Club shipments to the giftee’s work address. If you have any questions about Astor’s Wine Clubs, please call us at (212) 674-7500.
        </p>
    </div>       

    <ul>
        <li id="Div1" class="img-copy-row clearfix">
                
            <div class="imgContainer">
                <img src="images/wineclubs/img_wc_just_reds.jpg" alt="Just Reds Wine Club" />
                <img src="images/general/img_new.png" alt="Just Reds Wine Club" width="60" style="position: relative; width: 100px;"/>
            </div>
                
            <div class="copyContainer gutter" >
                <h2>Just Reds<br />$79.99 per month</h2>

                <ul>
                  <li><p>Six bottles per month! Wines will range from light to full-bodied and may include California Cabernet, Sangiovese blends, Cru Beaujolais</p></li>  
                  <li><p>Perfect for anyone who loves red wine</p></li>
                  <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
                </ul>
                <br />
                <p>Just Reds Wine Club Prices:</p>
                <asp:DropDownList runat="server" ID="justRedsDD" CssClass="wineClubDD">
                    <asp:ListItem Value="27022">$239.97 for 3 Months</asp:ListItem>
                    <asp:ListItem Value="27025">$479.94 for 6 Months</asp:ListItem>
                    <asp:ListItem Value="27026">$719.91 for 9 Months</asp:ListItem>
                    <asp:ListItem Value="27027">$959.88 for 12 Months</asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="addToCartJustReds" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" NavigateLink="htmlcontent" />
                <br />
                <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div>
            </div>            
        </li> <!-- #just-reds -->    

        <asp:PlaceHolder runat="server" ID="pnlInternationalExplorerWineCLub" >
        <li id="wine-club-international-explorer" class="img-copy-row clearfix">
                
            <div class="imgContainer">
                <img src="images/wineclubs/img_wc_international_explorer.jpg" alt="International Explorer Wine Club"/>
                <img src="images/general/img_new.png" alt="International Explorer Wine Club" width="60" style="position: relative; width: 100px;"/>
            </div>
                
            <div class="copyContainer gutter" >
                <h2>International Explorer Wine Club<br />$49.99 per month</h2>

                <ul>
                  <li><p>Try two unique and fascinating new wines each month! Shipments may include sparkling Grignolino from Piedmont, natural Cabernet Franc or sweet Chenin Blanc from the Loire, Nerello Mascalese from Sicily, Pinot Noir from Oregon</p></li>  
                  <li><p>Focus is on variety, independent producers, and high-quality, expressive wines</p></li>
                  <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
                </ul>
                <br />
                <p>International Explorer Wine Club Prices:</p>
                <asp:DropDownList runat="server" ID="internationalExplorerDD" CssClass="wineClubDD">
                    <asp:ListItem Value="27031">$149.97 for 3 Months</asp:ListItem>
                    <asp:ListItem Value="27033">$299.94 for 6 Months</asp:ListItem>
                    <asp:ListItem Value="27035">$499.91 for 9 Months</asp:ListItem>
                    <asp:ListItem Value="27036">$599.88 for 12 Months</asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="addToCartInterationalExplorer" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" NavigateLink="htmlcontent" />
                <br />
                <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div>
            </div>            
        </li> <!-- #international-explorer -->    
        </asp:PlaceHolder>

        <li id="top-ten-wine-club" class="img-copy-row clearfix">
                
            <div class="imgContainer">
                <img src="images/icons/img_top12_300x300.png" width="160" alt="Top 12 Under $12 Club"/>
            </div>
                
            <div class="copyContainer gutter">
                <h2>Top 12 Under $12 Club<br />$99.99 per month</h2>
                <ul>
                  <li><p>Get a new mixed case each month containing 12 of our most delicious wine finds</p></li>  
                  <li><p>Lots of variety: With any Top 12 Club membership, you’ll taste dozens of wines</p></li>
                  <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
                </ul>
                <br />
                <p>Top 12 Wine Club Prices:</p>
                <asp:DropDownList runat="server" ID="top10DD" CssClass="wineClubDD">
                    <asp:ListItem Value="22618">$299.97 for 3 Months</asp:ListItem>
                    <asp:ListItem Value="22619">$599.94 for 6 Months</asp:ListItem>
                    <asp:ListItem Value="22620">$899.91 for 9 Months</asp:ListItem>
                    <asp:ListItem Value="22621">$1199.88 for 12 Months</asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="addToCartTop10" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" NavigateLink="htmlcontent" />
                <br />
                <div class="note"><p>Please note that Wine Clubs must be purchased separately from other items.</p></div>
                <div style="border-top: solid 1px #ddd; border-bottom: solid 1px #ddd; padding: 12px 0px; margin-top: 20px;">
                <b class="red">A note about the old Top 10 Under $10:</b>
                <p>We’ve found that wine quality and variety get exponentially better with a ceiling of $12 (versus $10) per bottle, so we changed the pack. We hope you love all the exciting, amazing, delicious wines in the new Top 12 Under $12!</p>
                </div>
            </div>            
        </li>
        
        <asp:PlaceHolder runat="server" ID="pnlOrganicWineClub" Visible="false">
        <li id="organic-wine-club" class="img-copy-row clearfix">
            <h2>Organic Wine Club – $49.99 per month</h2>
                
                    <div class="imgContainer">
                        <img src="images/wineclubs/organic.jpg" alt=""/>
                        <img src="images/general/newStarburst.png" alt="New!" style="position: relative; top: -100px; "/>
                    </div>
                
                <div class="copyContainer gutter">
                    <ul>
                      <li><p>Try two incredible bottles of wine each month, and support these talented, earth-friendly producers</p></li>
	                  <li><p>The most delicious wines from organic, natural, and Biodynamic winemakers</p></li>
	                  <li><p>Wines may include: Biodynamic Oregon Pinot Noir, Loire Valley Sauvignon Blanc from natural winemakers, organic red wine from Rioja</p></li>
	                  <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
                    </ul>
                    <br />
                    <p>Organic Wine Club Prices:</p>
                    <asp:DropDownList runat="server" ID="organicDD" CssClass="wineClubDD">
                        <asp:ListItem Value="22646">3 Months for $149.97</asp:ListItem>
                        <asp:ListItem Value="22647">6 Months for $299.94</asp:ListItem>
                        <asp:ListItem Value="22648">9 Months for $449.91</asp:ListItem>
                        <asp:ListItem Value="22649">12 Months for $599.88</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ImageButton ID="addToCartOrganic" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" />
                    <br />
                    <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div>
                </div>            
        </li>
        </asp:PlaceHolder>
               
        <li id="discovery-wine-club" class="img-copy-row clearfix">
            <div class="imgContainer">
              <img src="images/wineclubs/img_wc_discovery.jpg" alt="" />
            </div>

            <div class="copyContainer gutter">
            <h2>Discovery Wine Club<br />$24.99 per month</h2>
            <ul>
              <li><p>Your two bottles per month may include: Argentine Malbec, New York Riesling, South African Shiraz</p></li>
	          <li><p>Perfect for novices searching for new “everyday” wines</p></li>
	          <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
            </ul>
            <br />
            <p>Discovery Wine Club Prices:</p>
            <asp:DropDownList runat="server" ID="discoveryDD" CssClass="wineClubDD">
                <asp:ListItem Value="19157">$74.97 for 3 Months</asp:ListItem>
                <asp:ListItem Value="19158">$149.94 for 6 Months</asp:ListItem>
                <asp:ListItem Value="19159">$224.90 for 9 Months</asp:ListItem>
                <asp:ListItem Value="22180">$299.88 for 12 Months</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="addToCartDiscovery" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" />
            <br />
            <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div>
            </div>            
        </li>
 
        <li id="italian-wine-club" class="img-copy-row clearfix">
              <div class="imgContainer">
                <img src="images/wineclubs/img_wc_italian.jpg" alt=""/>
              </div>
              <div class="copyContainer gutter">             
                  <h2>Italian Wine Club<br />$54.99 per month</h2>
                  <ul>
                    <li><p>Your two bottles may include: Aglianico, Erbaluce, Ruch&#233;</p></li>
	                <li><p>Get a thoroughly tasty overview of Italian wine</p></li>
	                <li><p>Explore Italy’s indigenous grapes and varied regions in depth</p></li>
	                <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
                  </ul>	
                  <br />
                <p>Italian Wine Club Prices:</p>
                <asp:DropDownList runat="server" ID="italianDD" CssClass="wineClubDD">
                    <asp:ListItem Value="19160">$164.97 for 3 Months</asp:ListItem>
                    <asp:ListItem Value="19161">$329.94 for 6 Months</asp:ListItem>
                    <asp:ListItem Value="19162">$494.90 for 9 Months</asp:ListItem>
                    <asp:ListItem Value="22185">$659.88 for 12 Months</asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="addToCartItalian" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" />
                <br />
                <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div>
            </div>
        </li>
        
        <li id="world-passport-wine-club" class="img-copy-row clearfix">   
           
            <div class="imgContainer">
              <img src="images/wineclubs/img_wc_world_passport.jpg" alt=""/>
            </div>
            
            <div class="copyContainer gutter">     
                <h2>World Passport Wine Club<br />$99.99 per month</h2>
                <ul>
                  <li><p>Your two bottles per month may include: Alsatian Pinot Noir, Loire Valley Sauvignon Blanc, Oregon Chardonnay</p></li>
	              <li><p>A crash course in wine on a sophisticated level</li></p>
	              <li><p>You’ll taste the difference between Old World and New World wines, traditional and modern wines, established wineries and hot new producers</p></li>
	              <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
                </ul>	
                <br />
                <p>World Passport Wine Club Prices:</p>
                <asp:DropDownList runat="server" ID="passportDD" CssClass="wineClubDD">
                    <asp:ListItem Value="19163">$299.97 for 3 Months</asp:ListItem>
                    <asp:ListItem Value="19164">$599.94 for 6 Months</asp:ListItem>
                    <asp:ListItem Value="19165">$899.90 for 9 Months</asp:ListItem>
                    <asp:ListItem Value="22186">$1199.88 for 12 Months</asp:ListItem>
                </asp:DropDownList>
                <asp:ImageButton ID="addToCartPassport" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" />
                <br />
                <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div>
            </div>
        </li>
   
        <li id="grand-cru-wine-club" class="img-copy-row clearfix">
           <div class="imgContainer">
              <img src="images/wineclubs/img_wc_grand_cru.jpg" alt=""/>
           </div>
          <div class="copyContainer gutter">    
              <h2>Grand Cru Wine Club<br />$254.99 per month</h2> 
              <ul>
                <li><p>Your two bottles per month may include: Bordeaux, Burgundy, California Cabernet Sauvignon</p></li>
	            <li><p>For experienced wine connoisseurs</p></li>
	            <li><p>The best wines from time-tested producers and regions</p></li>
	            <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
              </ul>	
              <br />
            <p>Grand Cru Wine Club Prices:</p>
            <asp:DropDownList runat="server" ID="grandDD" CssClass="wineClubDD">
                <asp:ListItem Value="19166">$764.97 for 3 Months</asp:ListItem>
                <asp:ListItem Value="19167">$1529.94 for 6 Months</asp:ListItem>
                <asp:ListItem Value="19168">$2294.90 for 9 Months</asp:ListItem>
                <asp:ListItem Value="22187">$3059.88 for 12 Months</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="addToCartGrand" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" />
            <br />
            <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div>
         </div> 
        </li>

        <asp:PlaceHolder runat="server" ID="pnlPlatinum" Visible="false">
        <li id="platinum-elite-wine-club" class="img-copy-row clearfix">
            <h2>Platinum Elite Wine Club – $599.99 per month</h2>
           <div class="imgContainer">
              <img src="images/wineclubs/platinum.jpg" alt=""/></div>
            <div class="copyContainer gutter">     
                <ul>
                  <li><p>Your two bottles per month may include wines such as: Grand Cru Bordeaux, Grand Cru Burgundy, cult California Cabernet Sauvignons, Tête de Cuvée Champagnes</p></li>
	              <li><p>The most sophisticated wines for the most discerning palates</p></li>
	              <li><p>Free shipping* for deliveries in New York State (elsewhere, regular shipping charges apply)</p></li>
                </ul>	
                <br />
            <p>Platinum Elite Wine Club Prices:</p>
            <asp:DropDownList runat="server" ID="platinumDD" CssClass="wineClubDD">
                <asp:ListItem Value="19169">3 Months for $1799.97</asp:ListItem>
                <asp:ListItem Value="19170">6 Months for $3599.94</asp:ListItem>
                <asp:ListItem Value="19171">9 Months for $5399.90</asp:ListItem>
            </asp:DropDownList>
            <asp:ImageButton ID="addToCartPlatinum" runat="server" ImageUrl="~/images/buttons/btn_addToCart.png" /> 
            <div class="note">Please note that Wine Clubs must be purchased separately from other items.</div> 
            </div>
       </li>
       </asp:PlaceHolder> 
   </ul>
   
    <div id="policy">
      <b>Astor Wine Club Policy:</b>
      <p>No cancellations. Astor’s Wine Clubs are available for nationwide delivery.<br /> 
      *Shipping in New York State is free for Wine Club purchases only: to purchase additional items, please place a separate order, to which regular shipping charges will apply. An adult 21 years of age or older must sign for each delivery. Sorry, no substitutions.</p>
    </div>
</div>
</asp:Content>