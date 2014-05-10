<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="thanksgiving.aspx.vb" Inherits="giftcards" title="Astor Wines & Spirits | Thanksgiving 2009" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
          <div id="giftCards" >
          <!-- <h1 class="mainHeader" style="padding: 5px; width: 590px; margin-bottom: 0px;">Astor Wines Gift Cards</h1> -->
                 <img src="images/thanksgiving/thanksgivingHeader.gif" alt="Thanksgiving Staff Picks" style="padding: 0px; margin: 0px; width: 605px; margin-bottom: -5px;"  />
                <div style="width: 605px;">
                <div class="thanksgivingContainer">
                        <div class="thanksgivingItemVideo">
                        <div class="thanksgivingBottle" style="float: left;"><a href="SearchResultsSingle.aspx?p=1&search=22391&searchtype=Contains"><img src="/images/itemimages/lg/22391_lg.jpg" alt="Thanksgiving 3-Pack" /></a></div>
                        <div style="float: left;">
                            
                            <div style="background-color: #b30175; padding: 5px; margin: 10px; text-align: center; width: 90px;">
                            <div style="background-color: #b30175; border: dotted 2px #ffffff; padding: 5px; color: #ffffff; height: 80px; line-height: 18px;"><a style="color: #ffffff;" href="SearchResultsSingle.aspx?p=1&search=22391&searchtype=Contains">SAVE<br /> MORE THAN</a><br /> <span style="font-family: Georgia, Times New Roman, Serif; font-weight: bold; font-size: 22pt; line-height: normal;"><a style="color: #ffffff;" href="SearchResultsSingle.aspx?p=1&search=22391&searchtype=Contains">25%</a></span></div>
                            </div>
                            
                            
                            <h3 style="font-size: 18pt;">THE THANKSGIVING PACKAGE</h3>
                                <div style="color: #555555; font-size: 10pt; line-height: 20px; margin-bottom: 20px;">
                                2008 Montinore Pinot Noir, Willamette Valley<br />
                                2007 Cline Zinfandel, California<br />
                                2007 Alsace Blanc, Kuentz-Bas
                                </div>
                            <span class="thanksgivingPriceOld">$40.97</span><br />
                            <span class="thanksgivingPrice">$29.99</span><br /><br />
                            <span><asp:ImageButton ID="add22391" runat="server" CommandArgument="22391" ImageUrl="~/images/as_addtocart.gif" /></span>
                            </div>
                        </div>

                        <div class="thanksgivingItemA">
                        <div class="thanksgivingBottle" style="float: left;"><a href="SearchResultsSingle.aspx?p=1&search=21898&searchtype=Contains"><img src="/images/itemimages/lg/21898_lg.jpg" alt="2007 Kuentz-Bas" /></a></div>
                        <h3>ALSACE BLANC</h3>
                        <h4>2007 Kuentz-Bas</h4>
                        <div class="thanksgivingQuote">"white flowers, peaches, and pears"</div>
                        <span class="thanksgivingPrice">$11.99</span><br /><br />
                        <span><asp:ImageButton ID="add21898" runat="server" CommandArgument="21898" ImageUrl="~/images/as_addtocart.gif" /></span>                          </div>
                        
                        <div class="thanksgivingItemB">
                        <div class="thanksgivingBottle" style="float: left;"><a href="SearchResultsSingle.aspx?p=1&search=21750&searchtype=Contains"><img src="/images/itemimages/lg/21750_lg.jpg" alt="2008 Wellies, New Zealand" /></a></div>
                        <h3>PINOT NOIR</h3>
                        <h4>2008 Wellies, New Zealand</h4>
                        <div class="thanksgivingQuote">"light veggie-friendly red"</div>
                        <span class="thanksgivingPriceOld">$16.99</span><br />
                        <span class="thanksgivingPrice">$13.99</span><br /><br />
                        <span><asp:ImageButton ID="add21750" runat="server" CommandArgument="21750" ImageUrl="~/images/as_addtocart.gif" /></span>                          </div>
                        
                        <div class="thanksgivingItemVideo">
                        <div class="thanksgivingVideo" style="float: left;"><embed src="http://blip.tv/play/g9Q2ga2eEwA" type="application/x-shockwave-flash" width="350" height="250" allowscriptaccess="always" allowfullscreen="true"></embed></div>
                        <h3>PINOT NOIR</h3>
                        <h4>2006 Radog, California</h4>
                        <div class="thanksgivingQuote">"notes of cranberry & orange zest"</div>
                        <span class="thanksgivingPriceOld">$26.99</span><br />
                        <span class="thanksgivingPrice">$22.99</span><br /><br />
                        <span><asp:ImageButton ID="add20820" runat="server" CommandArgument="20820" ImageUrl="~/images/as_addtocart.gif" /></span>
                        </div>
                        
                        <div class="thanksgivingItemB">
                        <div class="thanksgivingBottle" style="float: left;"><a href="SearchResultsSingle.aspx?p=1&search=24064&searchtype=Contains"><img src="/images/itemimages/lg/24064_lg.jpg" alt="2008 Vignerons de Samur, Loire" /></a></div>
                        <h3>SAUMUR BLANC</h3>
                        <h4>2008 Vignerons de Saumur, Loire</h4>
                        <div class="thanksgivingQuote">"honeyed, dry French white"</div>
                        <span class="thanksgivingPrice">$7.99</span><br /><br />
                        <span><asp:ImageButton ID="add24064" runat="server" CommandArgument="24064" ImageUrl="~/images/as_addtocart.gif" /></span>                          </div>
                       
                        
                        <div class="thanksgivingItemA">
                        <div class="thanksgivingBottle" style="float: left;"><a href="SearchResultsSingle.aspx?p=1&search=22025&searchtype=Contains"><img src="/images/itemimages/lg/22025_lg.jpg" alt="2008 Signargues SVP, Rhone" /></a></div>
                        <h3>C&#212TES DU RH&#212NE-VILLAGES</h3>
                        <h4>2008 Signargues SVP, Rh&#244ne</h4>
                        <div class="thanksgivingQuote">"dark, fruity, spicy"</div>
                        <span class="thanksgivingPriceOld">$11.99</span><br />
                        <span class="thanksgivingPrice">$8.99</span><br /><br />
                        <span><asp:ImageButton ID="add22025" runat="server" CommandArgument="22025" ImageUrl="~/images/as_addtocart.gif" /></span>
                        </div>
                        
                        <div class="thanksgivingItemVideo">
                        <div class="thanksgivingVideo" style="float: left;"><embed src="http://blip.tv/play/g9Q2ga2cWgA" type="application/x-shockwave-flash" width="350" height="250" allowscriptaccess="always" allowfullscreen="true"></embed></div>
                        <h3>RIESLING</h3>
                        <h4>2007 Substance "Re", Washington</h4>
                        <div class="thanksgivingQuote">"great with stuffing (and pie)"</div>
                        <span class="thanksgivingPrice">$17.99</span><br /><br />
                        <span><asp:ImageButton ID="add22156" runat="server" CommandArgument="22156" ImageUrl="~/images/as_addtocart.gif" /></span>
                        </div>
                        
                        <div class="thanksgivingItemA">
                        <div class="thanksgivingBottle" style="float: left;"><a href="SearchResultsSingle.aspx?p=1&search=20671&searchtype=Contains"><img src="/images/itemimages/lg/20671_lg.jpg" alt="2008 Poudou, Languedoc-Roussillon" /></a></div>
                        <h3>CARIGNAN</h3>
                        <h4>2008 Poudou, Languedoc-Roussillon</h4>
                        <div class="thanksgivingQuote">"bold, rustic red"</div>
                        <span class="thanksgivingPriceOld">$8.99</span><br />
                        <span class="thanksgivingPrice">$6.99</span><br /><br />
                        <span><asp:ImageButton ID="add20671" runat="server" CommandArgument="20671" ImageUrl="~/images/as_addtocart.gif" /></span>
                        </div>
                        
                        <div class="thanksgivingItemB">
                        <div class="thanksgivingBottle" style="float: left;"><a href="SearchResultsSingle.aspx?p=1&search=22183&searchtype=Contains"><img src="/images/itemimages/lg/22183_lg.jpg" alt="2007 McKinley Springs, Horse Heaven Hills, Washington" /></a></div>
                        <h3>CHENIN BLANC</h3>
                        <h4>2007 McKinley Springs, Horse Heaven Hills, Washington</h4>
                        <div class="thanksgivingQuote">"cuts through richness"</div>
                        <span class="thanksgivingPrice">$16.99</span><br /><br />
                        <span><asp:ImageButton ID="add22183" runat="server" CommandArgument="22183" ImageUrl="~/images/as_addtocart.gif" /></span>                          </div>
                        
                        <div class="thanksgivingItemVideo">
                        <div class="thanksgivingVideo" style="float: left;"><embed src="http://blip.tv/play/g9Q2ga2eegA" type="application/x-shockwave-flash" width="350" height="250" allowscriptaccess="always" allowfullscreen="true"></embed></div>
                        <h3>BEAUJOLAIS-VILLAGES</h3>
                        <h4>Granger 2007</h4>
                        <div class="thanksgivingQuote">"bold, rustic red"</div>
                        <span class="thanksgivingPriceOld">$15.99</span><br />
                        <span class="thanksgivingPrice">$12.99</span><br /><br />
                        <span><asp:ImageButton ID="add13601" runat="server" CommandArgument="13601" ImageUrl="~/images/as_addtocart.gif" /></span>
                        </div>                   
                        
                        <div class="thanksgivingItemB">
                            <div class="thanksgivingBottle" style="float: left;">
                            <a href="SearchResultsSingle.aspx?p=1&search=21997&searchtype=Contains">
                            <img src="/images/itemimages/lg/21997_lg.jpg" alt="2008 Vinicola Negri,""Rigoletto"", Emilia-Romagna" /></a>
                            </div>
                        <h3>LAMBRUSCO</h3>
                        <h4>2008 Vinicola Negri "Rigoletto", Emilia-Romagna</h4>
                        <div class="thanksgivingQuote">"off-dry, fizzy, fun"</div>
                        <span class="thanksgivingPriceOld">$15.99</span><br />
                        <span class="thanksgivingPrice">$12.99</span><br /><br />
                        <span><asp:ImageButton ID="add21997" runat="server" CommandArgument="21997" ImageUrl="~/images/as_addtocart.gif" /></span>                          </div>
                        
                        <div class="thanksgivingItemA">
                            <div class="thanksgivingBottle" style="float: left;">
                                <a href="/SearchResultsSingle.aspx?p=1&search=17007&searchtype=Contains">
                                <img src="/images/itemimages/lg/22142_lg.jpg" alt="2007 Amala, California" />
                                </a>
                            </div>
                            <h3>CHARDONNAY</h3>
                            <h4>2007 Amala, California</h4>
                            <div class="thanksgivingQuote">"a great deal any time of year"</div>
                            <span class="thanksgivingPriceOld">$8.99</span><br />
                            <span class="thanksgivingPrice">$6.99</span><br /><br />
                            <span><asp:ImageButton ID="add22142" runat="server" CommandArgument="22142" ImageUrl="~/images/as_addtocart.gif" /></span>
                        </div>
                        
                        <br style="clear: both;" />
                    </div>
                <br /> 
                
            </div>
        </div>
</asp:Content>