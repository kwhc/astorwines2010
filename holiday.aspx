<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="holiday.aspx.vb" Inherits="holiday" title="Astor Wines & Spirits | Holiday 2009" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="Ucontrols/WUCTouts1.ascx" TagName="WUCTouts1" TagPrefix="uc3" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  
  <div id="holiday" class="mainContent">
    <div class="holidayTop">
        <!-- <h1>HOLIDAY 2009</h1> -->
        <div class="holidayTopCopyContainer"><div class="holidayTopCopy"><br />Click on the bars below to see our gift ideas:</div></div>
        <img src="../images/holiday/giftBow.png" alt="Astor's 2009 Holiday Gift Guide" style="position: relative; left: 300px; top: -240px;" />
    </div>
    
    <!-- <div style="clear: both; line-height: 0px;">&nbsp;</div> -->
    
  <div class="holidayListContainer">
    <div class="holidayList">
        <a class="submenuheader" href=""><div class="partyinaboxHeader">&nbsp;</div></a>
    </div>
    <div class="submenu">
        <div class="holidayListCopy">
            <p>How many people are coming over? Whether you need 5 bottles or a case of 12, we’ve got two perfect package deals this month. 
            </p>
        </div>
    <div class="holidayListItem">
        <div class="holidayListItemImg">
            <a href="SpecialPacks.aspx?packitem=22420&rel=holiday"><img src="../images/holiday/22420.jpg" alt="Take Five Pack" width="162px"/></a>
        </div>

        <div class="holidayListItemDesc">
            <h2>Take Five Pack</h2>
            <p>
            Overwhelmed by holiday shopping? Take Five! The Take Five Pack features five of our best-selling wines of 2009, plus a free canvas tote bag, for just $24.99.
            </p>
            <div class="holidaySalePrice">Sale Price $24.99</div>
            <div class="holidayRegPrice">was <span>$57.94</span></div>
            <span class="note"><a href="SpecialPacks.aspx?packitem=22420&rel=holiday">shop take five pack>> </a> </span>
        </div>
        <br style="clear: both;" />
    </div>
    <div class="holidayListItem">
        <div class="holidayListItemImg">
            <a href="SpecialPacks.aspx?packitem=22425&rel=holiday"><img src="../images/features/TopTenUnder10FeaturePage.jpg" alt="Top Ten Under $10" width="162px" /></a>
        </div>

        <div class="holidayListItemDesc">
            <h2>Top Ten Under $10</h2>
            <p>
            10 of our favorite wines, plus 2 bonus bottles — a grand total of 12 wines for well under $100! Our December Top 10 is full of hearty reds and fuller-bodied whites — perfect for rich holiday meals, for cold holiday weather, and for maximizing holiday cheer. 
            </p>
            <div class="holidaySalePrice">Sale Price $87.99</div>
            <div class="holidayRegPrice">was <span>$130.88</span></div>
            <span class="note"><a href="SpecialPacks.aspx?packitem=22425&rel=holiday">shop top ten under $10>></a></span>
        </div>
        <br style="clear: both;" />
    </div>

    </div>
    
    <div style="clear: both; line-height: 0px;">&nbsp;</div>
    
    <div class="holidayList">
        <a class="submenuheader" href=""><div class="lastminuteHeader">&nbsp;</div></a>
    </div>
    <div class="submenu">
        <div class="holidayListCopy">
            <p>It isn’t too late to give great wine — you don’t even have to pick it out yourself!  These options will make your shopping much simpler: just decide how much you want to spend, and you’re done. 
            </p>
        </div>
    <div class="holidayListItem">
        <div class="holidayListItemImg">
            <a href="/giftcards.aspx?rel=holidayCards"><img src="../images/general/giftCard.jpg" alt="Astor Wines Gift Cards" width="165px"/></a>
        </div>

        <div class="holidayListItemDesc">
            <h2>GIFT CARDS</h2>
            <p>
            Our Gift Cards are valid for any purchase from Astor Wines & Spirits, and may be used online, in-store, or over the phone.
            </p>
            <span class="note"><a href="/giftcards.aspx?rel=holidayCards">shop gift cards >></a></span>
        </div>
        <br style="clear: both;" />
    </div>
    <div class="holidayListItem">
        <div class="holidayListItemImg">
            <a href="/wineclubs?rel=holidayClubs"><img src="../images/logo_wineClub.png" width="165px" /></a>
        </div>

        <div class="holidayListItemDesc">
            <h2>ASTOR'S WINE CLUBS</h2>
            <p>
            Choose a theme and we’ll send two bottles every month for up to a year! The 6-month Italian Wine Club is our most popular choice, but you can also opt for the Discovery, World Passport, Grand Cru, or Platinum Elite Clubs — any of them would make an incredible gift.
            </p>
            <span class="note"><a href="/wineclubs?rel=holidayClubs">shop wine clubs>></a></span>
        </div>
        <br style="clear: both;" />
    </div>

    </div>
    
    <div style="clear: both; line-height: 0px;">&nbsp;</div>
    
    <div class="holidayList">
        <a class="submenuheader" href=""><div class="oenephileHeader">&nbsp;</div></a>
    </div>
    <div class="submenu">
        <div class="holidayListCopy">
        <p>... but you’re on a budget! <br />
        Small-production, hard-to-find, outrageously good bottles of wine at reasonable prices.
        </p>
        </div>
        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=12629&searchtype=Contains&rel=holiday12629"><img src="../images/itemimages/sm/12629_sm.jpg" alt="St. Aubin Blanc 'Le Ban', Prudhon 2005" /></a>
            </div>

            <div class="holidayListItemDesc">
                <h2>St. Aubin Blanc "Le Ban", Prudhon 2005</h2>
                <p>
                Brilliant white Burgundy from a stellar vintage.
                </p>
                <div class="holidaySalePrice">Sale Price $22.99</div>
                <div class="holidayRegPrice">was <span>$25.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=12629&searchtype=Contains&rel=holiday12629">view St. Aubin Blanc "Le Ban", Prudhon 2005 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=15289&searchtype=Contains&rel=holiday15289"><img src="../images/itemimages/sm/15289_sm.jpg" alt="St. Aubin Blanc 'Le Ban', Prudhon 2005" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Pernand-Vergelesses Blanc, Rollin 2004</h2>
                <p>
                Sometimes the best Chardonnay comes from villages that you’ve never heard of. Case in point: Pernand-Vergelesses. 
                </p>
                <div class="holidaySalePrice">Sale Price $29.99</div>
                <div class="holidayRegPrice">was <span>$32.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=15289&searchtype=Contains&rel=holiday15289">view Pernand-Vergelesses Blanc, Rollin 2004 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=00109&searchtype=Contains&rel=holiday00109"><img src="../images/itemimages/sm/00109_sm.jpg" alt="St. Aubin Blanc 'Le Ban', Prudhon 2005" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Ch. Moulin de Tricot, Haut Médoc 2005</h2>
                <p>
                This Bordeaux will please anyone looking for a robust, full-bodied French red.
                </p>
                <div class="holidaySalePrice">Sale Price $21.97</div>
                <div class="holidayRegPrice">was <span>$28.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=00109&searchtype=Contains&rel=holiday00109">view Ch. Moulin de Tricot, Haut Médoc 2005 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=43004&searchtype=Contains&rel=holiday43004"><img src="../images/itemimages/sm/43004_sm.jpg" alt="St. Aubin Blanc 'Le Ban', Prudhon 2005" /></a>
            </div>     
            <div class="holidayListItemDesc">
                <h2>Chianti Colli Senesi, Villa Sant’Anna 2005</h2>
                <p>
                Smooth texture, excellent balance; a classic Chianti from the beautiful Villa Sant’Anna estate. 
                </p>
                <div class="holidaySalePrice">Sale Price $18.99</div>
                <div class="holidayRegPrice">was <span>$21.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=43004&searchtype=Contains&rel=holiday43004">view Chianti Colli Senesi, Villa Sant’Anna 2005 >></a> </span>
            </div>
            <br style="clear: both;" />
      </div>
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=40019&searchtype=Contains&rel=holiday40019"><img src="../images/itemimages/sm/40019_sm.jpg" alt="St. Aubin Blanc 'Le Ban', Prudhon 2005" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Nebbiolo d’Alba Valmaggione, Brovia 2005</h2>
                <p>
                A baby Nebbiolo from Brovia, the estate known best for its elegant Barolo.
                </p>
                <div class="holidaySalePrice">Sale Price $28.99</div>
                <div class="holidayRegPrice">was <span>$31.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=40019&searchtype=Contains&rel=holiday40019">view Nebbiolo d’Alba Valmaggione, Brovia 2005 >></a></span>
            </div>
            <br style="clear: both;" />
      </div>
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=18226&searchtype=Contains&rel=holiday18226"><img src="../images/itemimages/sm/12629_sm.jpg" alt="Coenobium, Bianco 2007" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Coenobium, Bianco 2007</h2>
                <p>
                How often do you get a chance to try a wine made by nuns? This heavenly white is full of exotic fruit character.
                </p>
                <div class="holidaySalePrice">Sale Price $19.99</div>
                <div class="holidayRegPrice">was <span>$24.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=18226&searchtype=Contains&rel=holiday18226">view Coenobium, Bianco 2007 >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>

    </div>
    
    <div style="clear: both; line-height: 0px;">&nbsp;</div>
    
    <div class="holidayList">
        <a class="submenuheader" href=""><div class="bartenderHeader">&nbsp;</div></a>
    </div>
    <div class="submenu">
        <div class="holidayListCopy">
            <p>These uncommon spirits will appeal to anyone who has ever handled a cocktail shaker.
            </p>
        </div>
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=21520&searchtype=Contains&rel=holiday21520"><img src="../images/itemimages/sm/21520_sm.jpg" alt="Delaware Phoenix Meadow of Love Absinthe" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Delaware Phoenix Meadow of Love Absinthe</h2>
                <p>A small-batch absinthe created with local herbs and Catskill water. Dry, floral, and elegant, this has exceptional depth and balance.
</p>
                <div class="holidaySalePrice">Price $74.99</div>
                <!-- <div class="holidayRegPrice">was <span>$11.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=21520&searchtype=Contains&rel=holiday21520">view Delaware Phoenix Meadow of Love Absinthe >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>
        
        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=21472&searchtype=Contains&rel=holiday21472"><img src="../images/itemimages/sm/21472_sm.jpg" alt="Boudier Saffron Infused Gin" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Boudier Saffron Infused Gin</h2>
                <p>The saffron flavor is subtle, but the color is not! Elegant, mild, and a great choice for your next cocktail innovation.
</p>
                <div class="holidaySalePrice">Price $31.99</div>
                <!-- <div class="holidayRegPrice">was <span>$18.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=21472&searchtype=Contains&rel=holiday21472">view Boudier Saffron Infused Gin >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>

        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=09144&searchtype=Contains&rel=holiday09144"><img src="../images/itemimages/sm/09144_sm.jpg" alt="Clear Creek Pear In Bottle" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Clear Creek Pear In Bottle</h2>
                <p>How do they do it? Simple: place bottles over pear buds on the trees, pick when pears are ripe, add phenomenal eau-de-vie.</p>
                <div class="holidaySalePrice">Price $74.99</div>
                <!-- <div class="holidayRegPrice">was <span>$15.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=09144&searchtype=Contains&rel=holiday09144">view Clear Creek Pear In Bottle >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>
        
        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=21770&searchtype=Contains&rel=holiday21770"><img src="../images/itemimages/sm/21770_sm.jpg" alt="Rhum J.M Blanc Martinique" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Rhum J.M Blanc Martinique</h2>
                <p>Notes of banana, grass, white pepper, and cinnamon. This is definitely not your ordinary white rum.</p>
                <div class="holidaySalePrice">Price $36.99</div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=21770&searchtype=Contains&rel=holiday21770">view Rhum J.M Blanc Martinique  >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>
        
        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=08406&searchtype=Contains&rel=holiday08406"><img src="../images/itemimages/sm/08406_sm.jpg" alt="Chartreuse VEP Green" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Chartreuse VEP Green</h2>
                <p>
                For a complex and elegant after-dinner drink, try Vieillissement Prolong&#233; ("aged extra long") Chartreuse.
                </p>
                <div class="holidaySalePrice">Price $129.99</div>
                <!-- <div class="holidayRegPrice">was <span>$10.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=08406&searchtype=Contains&rel=holiday08406">view Chartreuse VEP Green >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>
        
        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=12545&searchtype=Contains&rel=holiday12545"><img src="../images/itemimages/sm/12545_sm.jpg" alt="Compass Box Orangerie" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Compass Box Orangerie</h2>
                <p>Handcrafted small-batch whisky made with oranges and spices. This is Scotland’s only whisky infusion! Try it after dinner with chocolate.</p>
                <div class="holidaySalePrice">Price $41.99</div>
                <!-- <div class="holidayRegPrice">was <span>$13.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=12545&searchtype=Contains&rel=holiday12545">view Compass Box Orangerie >></a> </span>
            </div>
            <br style="clear: both;" />
        </div> 

    </div>
    
    <div style="clear: both; line-height: 0px;">&nbsp;</div>
    
    <div class="holidayList">
        <a class="submenuheader" href=""><div class="holidayInsuranceHeader">&nbsp;</div></a>
    </div>
    <div class="submenu">
        <div class="holidayListCopy">
            <p>
            Keep these bottles handy for unexpected guests, or grab one when you need a last-minute party gift. 
            </p>
        </div>
        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=20680&searchtype=Contains&rel=holiday20680"><img src="../images/itemimages/sm/20680_sm.jpg" alt="Sauvignon Blanc, Dom. de la Rablais 2008" /></a>
            </div>

            <div class="holidayListItemDesc">
                <h2>Sauvignon Blanc, Dom. de la Rablais 2008</h2>
                <!-- <p>
                Brilliant white Burgundy from a stellar vintage.
                </p> -->
                <div class="holidaySalePrice">Sale Price $8.99</div>
                <div class="holidayRegPrice">was <span>$11.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=20680&searchtype=Contains&rel=holiday20680">view Sauvignon Blanc, Dom. de la Rablais 2008 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=21988&searchtype=Contains&rel=holiday21988"><img src="../images/itemimages/sm/21988_sm.jpg" alt="Langhe Rosso 'Superboum', Az. Agr. Bricco del Cucu 2007" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Langhe Rosso “Superboum”, Az. Agr. Bricco del Cucu 2007</h2>
                <!-- <p>
                Sometimes the best Chardonnay comes from villages that you’ve never heard of. Case in point: Pernand-Vergelesses. 
                </p> -->
                <div class="holidaySalePrice">Sale Price $14.99</div>
                <div class="holidayRegPrice">was <span>$18.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=21988&searchtype=Contains&rel=holiday21988">view Langhe Rosso “Superboum”, Az. Agr. Bricco del Cucu 2007 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=21487&searchtype=Contains&rel=holiday21487"><img src="../images/itemimages/sm/21487_sm.jpg" alt="Ch. La Rame, Bordeaux Blanc 2008" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Ch. La Rame, Bordeaux Blanc 2008</h2>
                <!-- <p>
                This Bordeaux will please anyone looking for a robust, full-bodied French red.
                </p> -->
                <div class="holidaySalePrice">Sale Price $12.99</div>
                <div class="holidayRegPrice">was <span>$15.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=21487&searchtype=Contains&rel=holiday21487">view Ch. La Rame, Bordeaux Blanc 2008 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=10675&searchtype=Contains&rel=holiday10675"><img src="../images/itemimages/sm/10675_sm.jpg" alt="Côtes du Rhône, Dom. des Bacchantes 2007" /></a>
            </div>     
            <div class="holidayListItemDesc">
                <h2>Côtes du Rhône, Dom. des Bacchantes 2007</h2>
                <p>
                Smooth texture, excellent balance; a classic Chianti from the beautiful Villa Sant’Anna estate. 
                </p>
                <div class="holidaySalePrice">Price $13.99</div>
                <!-- <div class="holidayRegPrice">was <span>$21.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=10675&searchtype=Contains&rel=holiday10675">view Côtes du Rhône, Dom. des Bacchantes 2007 >></a> </span>
            </div>
            <br style="clear: both;" />
      </div>
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=21508&searchtype=Contains&rel=holiday21508"><img src="../images/itemimages/sm/21508_sm.jpg" alt="Grüner Veltliner, Dürnberg Falkensteiner Rieden NV (LTR)" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Grüner Veltliner, Dürnberg Falkensteiner Rieden NV (LTR)</h2>
                <!-- <p>
                A baby Nebbiolo from Brovia, the estate known best for its elegant Barolo.
                </p> -->
                <div class="holidaySalePrice">Sale Price $8.99</div>
                <div class="holidayRegPrice">was <span>$10.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=21508&searchtype=Contains&rel=holiday21508">view Grüner Veltliner, Dürnberg Falkensteiner Rieden NV (LTR) >></a> </span>
            </div>
            <br style="clear: both;" />
      </div>
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=20790&searchtype=Contains&rel=holiday20790"><img src="../images/itemimages/sm/20790_sm.jpg" alt="Milcampos Tempranillo, Ribera del Duero 2006" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Milcampos Tempranillo, Ribera del Duero 2006</h2>
                <!-- <p>
                How often do you get a chance to try a wine made by nuns? This heavenly white is full of exotic fruit character.
                </p> -->
                <div class="holidaySalePrice">Sale Price $11.99</div>
                <div class="holidayRegPrice">was <span>$13.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=20790&searchtype=Contains&rel=holiday20790">view Milcampos Tempranillo, Ribera del Duero 2006 >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>

      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=12080&searchtype=Contains&rel=holiday12080"><img src="../images/itemimages/sm/12080_sm.jpg" alt="Ch. Belregard 'Tellus Vinea' Bordeaux 2006" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Ch. Belregard “Tellus Vinea” Bordeaux 2006</h2>
                <!-- <p>
                How often do you get a chance to try a wine made by nuns? This heavenly white is full of exotic fruit character.
                </p> -->
                <div class="holidaySalePrice">Sale Price $13.99</div>
                <div class="holidayRegPrice">was <span>$16.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=12080&searchtype=Contains&rel=holiday12080">view Ch. Belregard “Tellus Vinea” Bordeaux 2006 >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>
        
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=21914&searchtype=Contains&rel=holiday21914"><img src="../images/itemimages/sm/21914_sm.jpg" alt="Mâcon-Pierreclos, Thevenet 2007" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Mâcon-Pierreclos, Thevenet 2007</h2>
                <!-- <p>
                How often do you get a chance to try a wine made by nuns? This heavenly white is full of exotic fruit character.
                </p> -->
                <div class="holidaySalePrice">Sale Price $15.99</div>
                <div class="holidayRegPrice">was <span>$18.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=21914&searchtype=Contains&rel=holiday21914">view Mâcon-Pierreclos, Thevenet 2007 >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>        

    </div>
    
    <div style="clear: both; line-height: 0px;">&nbsp;</div>
    
    <div class="holidayList">
        <a class="submenuheader" href=""><!--<div class="howtoimpressHeader">&nbsp;</div>--><img src="images/holiday/impressanyoneHeader.gif" /></a>
    </div>
    <div class="submenu">
        <div class="holidayListCopy">
            <p>Cellar-worthy wines and precious single malts.  
            </p>
        </div>
        <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=17870&searchtype=Contains&rel=holiday17870"><img src="../images/itemimages/sm/17870_sm.jpg" alt="Dunn Cabernet Sauvignon, Howell Mountain 2004" /></a>
            </div>

            <div class="holidayListItemDesc">
                <h2>Dunn Cabernet Sauvignon, Howell Mountain 2004</h2>
                <p>
                A hearty, full-bodied red wine to cherish in its youth. 
                </p>
                <div class="holidaySalePrice">Price $109.99</div>
                <!-- <div class="holidayRegPrice">was <span>$25.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=17870&searchtype=Contains&rel=holiday17870">view Dunn Cabernet Sauvignon, Howell Mountain 2004 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <!-- <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=11356&searchtype=Contains&rel=holiday11356"><img src="../images/itemimages/sm/11356_sm.jpg" alt="Glendronach 1968 Highland Malt" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Glendronach 1968 Highland Malt</h2>
                <p>
                Aged in sherry casks and redolent of toasted walnut, pine nut, dried cranberries, chocolate-covered raspberries, and cinnamon. 
                </p>
                <div class="holidaySalePrice">Sale Price $129.99</div>
                <div class="holidayRegPrice">was <span>$199.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=11356&searchtype=Contains&rel=holiday11356">view Glendronach 1968 Highland Malt  >></a> </span>
            </div>
            <br style="clear: both;" />
       </div> -->
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=21719&searchtype=Contains&rel=holiday21719"><img src="../images/itemimages/sm/21719_sm.jpg" alt="Lombard Jewels of Scotland Springbank 13 Yr. 1991" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Lombard Jewels of Scotland Springbank 13 Yr. 1991</h2>
                <p>
                Lightly peated, with honey, pear, and salt notes.
                </p>
                <div class="holidaySalePrice">Sale Price $109.99</div>
                <div class="holidayRegPrice">was <span>$89.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=21719&searchtype=Contains&rel=holiday21719">view Lombard Jewels of Scotland Springbank 13 Yr. 1991 >></a> </span>
            </div>
            <br style="clear: both;" />
       </div>
       <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=20286&searchtype=Contains&rel=holiday20286"><img src="../images/itemimages/sm/20286_sm.jpg" alt="Barolo 'Villero', Oddero 2004" /></a>
            </div>     
            <div class="holidayListItemDesc">
                <h2>Barolo “Villero”, Oddero 2004</h2>
                <p>
                Cocoa and violets. Cellaring is strongly advised, and will be richly rewarded. 
                </p>
                <div class="holidaySalePrice">Price $59.99</div>
                <!-- <div class="holidayRegPrice">was <span>$21.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=20286&searchtype=Contains&rel=holiday20286">view Barolo “Villero”, Oddero 2004 >></a> </span>
            </div>
            <br style="clear: both;" />
      </div>
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=2&search=18477&searchtype=Contains&rel=holiday18477"><img src="../images/itemimages/sm/18477_sm.jpg" alt="Gordon & MacPhail Macallan 37 Yr. 1970" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Gordon & MacPhail Macallan 37 Yr. 1970</h2>
                <p>
                Extremely rare Scotch, sold exclusively at Astor: this won’t last long. Extended barrel aging gives toffee/caramel sweetness 
and nutty sherry notes.
                </p>
                <div class="holidaySalePrice">Sale Price $299.99</div>
                <div class="holidayRegPrice">was <span>$351.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=2&search=18477&searchtype=Contains&rel=holiday8477">view Gordon & MacPhail Macallan 37 Yr. 1970 >></a> </span>
            </div>
            <br style="clear: both;" />
      </div>
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=18299&searchtype=Contains&rel=holiday18299"><img src="../images/itemimages/sm/18299_sm.jpg" alt="Ch. d’Yquem, Sauternes 2005 (375 mL)" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Ch. d’Yquem, Sauternes 2005 (375 mL)</h2>
                <p>
                This has spicy notes from both the botrytis and the wood, with almond shells, coconut, and honeysuckle. Still quite young, it has the structure to hold for decades. 
                </p>
                <div class="holidaySalePrice">Sale Price $349.99</div>
                <!-- <div class="holidayRegPrice">was <span>$24.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=18299&searchtype=Contains&rel=holiday18299">view Ch. d’Yquem, Sauternes 2005 >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>

      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=22362&searchtype=Contains&rel=holiday22362"><img src="../images/itemimages/sm/22362_sm.jpg" alt="St. Laurent 'Zagersdorf', Hannes Schuster 2006" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>St. Laurent “Zagersdorf”, Hannes Schuster 2006</h2>
                <p>
                Forty-year old vines make this a rich, opulent, and splendid red. 
                </p>
                <div class="holidaySalePrice">Price $53.99</div>
                <!-- <div class="holidayRegPrice">was <span>$24.99</span></div> -->
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=22362&searchtype=Contains&rel=holiday22362">view St. Laurent “Zagersdorf”, Hannes Schuster 2006 >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>
        
      <div class="holidayListItem">
            <div class="holidayListItemImg">
                <a href="SearchResultsSingle.aspx?p=1&search=39496&searchtype=Contains&rel=holiday39496"><img src="../images/itemimages/sm/39496_sm.jpg" alt="Dom. de Jaugaret, St-Julien 2004" /></a>
            </div>
            <div class="holidayListItemDesc">
                <h2>Dom. de Jaugaret, St-Julien 2004</h2>
                <p> 
                From a tiny plot of old vines, this Bordeaux will improve for many years to come. 
                </p>
                <div class="holidaySalePrice">Sale Price $59.99</div>
                <div class="holidayRegPrice">was <span>$69.99</span></div>
                <span class="note"><a href="SearchResultsSingle.aspx?p=1&search=39496&searchtype=Contains&rel=holiday39496">view Dom. de Jaugaret, St-Julien 2004 >></a> </span>
            </div>
            <br style="clear: both;" />
        </div>        

    </div>
    
    <br style="clear: both;" />
 
    </div>
  </div>
</asp:Content>