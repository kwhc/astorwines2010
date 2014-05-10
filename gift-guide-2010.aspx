<%@ Page Language="VB" AutoEventWireup="false" CodeFile="gift-guide-2010.aspx.vb" Inherits="gift_guide_2010" MasterPageFile="~/as_master_1.master" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadSupplement">
<style type="text/css">

#giftGuide{

}

    #giftGuide .simpleSlide-slide{
        width: 500px;
        height: 2800px;
    }

    #giftGuideHeaderContainer{
        width: 566px;
        height: 187px;
        overflow: hidden;
        background-image: url(images/holiday/hdr_giftGuide.gif);
        background-repeat: no-repeat;
        text-indent: -9999px
    }

        #giftGuideHeaderContainer h1{
            text-transform: uppercase;
            text-align: center;
            font-size: 8em;
            font-family: Arial Narrow, Helvetica, Sans-Serif;
            font-weight: normal;
            line-height: .9em;
        }
        
        #giftGuideHeaderContainer #preheader{
            text-align: center;
            font-size: 1.4em;
            margin-top: 20px;
        }
    
    #slideContainer{
        text-align: center;    
        margin-left: 20px;
        margin-top: 10px;
    }
    
        #slideContainer .left-button, #slideContainer .right-button{
            display: inline;
            margin: 0px 20px;
            font-family: Times New Roman, Times, Serif;
            font-style: italic;
            font-size: 2em;
        }
                
        #slideContainer a:hover{
            text-decoration: none;
        }
        
        #slideContainer .slide{
            width: 500px;
            height: 2800px;
            text-align: center;
            padding: 10px;
            margin-top: 10px;
            border: #eeeeee solid 1px;
        }
        
        #slideContainer .slideOverlay{
            width: 520px;
            height: 2820px;
            background-image: url(../images/holiday/slide-overlay.png);
            /* background-color: Aqua; */
            background-repeat: repeat-y;
            position: absolute;
            z-index: 10;
        }

            .slide .titleContainer{
                border-bottom: solid 1px #dddddd;
                line-height: 3em;
            }
            
                .titleContainer .title{
                    font-family: Times New Roman, Times, Serif;
                    text-align: left;
                    margin-bottom: 20px;
                    float: left;
                    width: 250px;
                    font-size: 1.6em;
                    letter-spacing: 1px;
                }
                
                .titleContainer .nextTitle{
                    font-family: Times New Roman, Times, Serif;
                    font-style: italic;
                    text-align: right;
                    font-weight: normal;
                    margin-bottom: 20px;
                    float: right;
                    width: 210px;           
                }
        
        .slide .slideContent{
            width: 460px;
            padding: 0px 20px;
            text-align: left;
        }
        
            .slideContent .intro{
                    font-size: 1.2em;
                    line-height: 1.6em;
                    text-align: center;
            }
            
            .slideContent .item{
                margin-top: 20px;
                clear: both;
                height: 260px;
                border-bottom: solid 1px #eeeeee;
                padding-bottom: 20px;
            }
                
                .item .copyContainer{
                    padding-top: 40px;
                }
                
                    .copyContainer b{
                        font-size: 1.4em;
                    }
                
                .item .imageContainer{
                    float: left;
                    padding-right: 20px;
                    width: 170px;
                    text-align: center;
                }
                
                .item h3{
                    color: #411e75;
                    text-transform: uppercase;
                    font-size: 1.4em;
                    font-weight: bold;
                    line-height: 1.2em;
                }
                
                .item .staffPick{
                    margin-top: 10px;
                    line-height: 1.6em;
                }
                
                .item .price{
                    line-height: 1.6em;
                }
                
                .item .itemNum{
                    color: #cccccc;
                    font-size: .8em;
                }
                
                .item .ubcTitle{
                    margin-top: 10px;
                    color: #e6c75a;
                }
                
                .item .ubcSubTitle{
                    text-transform: uppercase;
                    font-size: .8em;
                }
                
                
                
</style>
</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="middleContent">
<div class="customPage" id="giftGuide">
    
    <div id="giftGuideHeaderContainer">
        <div id="preheader">2010</div>
        <h1>Gift Guide</h1>
    </div>
    
    <div id="slideContainer">
        <div class="left-button" rel="1"><a href="javascript:"><< Back</a></div>
        <div class="right-button" rel="1"><a href="javascript:">Next >></a></div>
        
        <!-- <div class="slideOverlay">&nbsp;</div> -->
        
        <div class="simpleSlide-window" rel="1">
            <div class="simpleSlide-tray" rel="1">

               <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">
                            
                            <div class="title">Under $20 (Reds)</div>
                            <div class="nextTitle">next: great gifts under $20 (whites)</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />
                        
                        <div class="slideContent">
                            <!--
                            <div class="intro">
                                <p>
                                The Astor staff tasted hundreds of wines and spirits this year. Here are the bottles we’re choosing to give to our friends.
                                </p>   
                                <p>~</p>                         
                            </div>
                            -->
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23972" ><img src="images/itemimages/lg/23972_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23972" ><h3>France 2008 La Croix de Pez, St.-Estèphe</h3></a>
                                    <div class="price">$18.96</div>
                                    <div class="itemNum">#23972 </div>
                                    <div class="staffPick">
                                    Tell them to open it tonight: This Bordeaux is ready to go.
                                    </div>
                            
                                </div>
                            </div>                       
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=15116" ><img src="images/itemimages/lg/15116_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=15116" ><h3>Spain 2008 Can Blau, Montsant</h3></a>
                                    <div class="price">$16.96</div>
                                    <div class="itemNum">#15116</div> 
                                    <div class="staffPick">
                                        Pure pleasure for anyone who just loves red wine: dark fruit, velvety texture.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23777"><img src="images/itemimages/lg/23777_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23777"><h3>France 2005 l’Affranchi Rouge Zéro Pointé</h3></a>
                                    <div class="price"><b>Now $13.96</b> Regular Price $14.96</div>
                                    <div class="itemNum">#23777</div> 
                                    <div class="staffPick">
                                        Red-meat-eaters will appreciate the structure of this old-vine Cab Franc.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=84234"><img src="images/itemimages/lg/84234_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=84234"><h3>California 2008 Au Bon Climat Pinot Noir, Santa Barbara</h3></a>
                                    <div class="price"><b>Now $19.96 </b> Regular Price $22.96</div>
                                    <div class="itemNum">#84234</div> 
                                    <div class="staffPick">                                  
                                    Made with hand-selected grapes, this lovingly crafted Pinot Noir is a perfect gift for those you really care about.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=19696"><img src="images/itemimages/lg/19696_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=19696"><h3>Argentina 2008 La Posta Malbec, Pizzella Vineyard</h3></a>
                                    <div class="price">$17.96</div>
                                    <div class="itemNum">#19696</div>
                                    <div class="staffPick">
                                    Vibrant, lively wine made to be shared with friends.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <!--
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=24207"><img src="images/itemimages/lg/24207_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=24207"><h3>Italy 2006 Langhe Rosso “Satiro”, Az. Agr. Bricco del Cucu</h3></a>
                                    <div class="price"><b>Now $12.96</b> Regular Price $15.99</div>
                                    <div class="itemNum">#24207</div> 
                                    <div class="staffPick">
                                    Fans of Italian food will love this dark, ripe red.
                                    </div>
                            
                                </div>
                            </div>
                            -->
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=12617"><img src="images/itemimages/lg/12617_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=12617"><h3>France 2008 Hautes-Côtes de Beaune Rouge Dom. Rollin Père & Fils</h3></a>
                                    <div class="price"><b>Now $17.96</b> Regular Price $23.99</div>
                                    <div class="itemNum">#12617 </div>
                                    <div class="staffPick">
                                    Berries, minerals, elegance. Possibly the best Burgundy value we’ve got.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=22159"><img src="images/itemimages/lg/22159_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=22159"><h3>Washington 2008 Substance “Sy” Syrah</h3></a>
                                    <div class="price">$16.96</div>
                                    <div class="itemNum">#22159</div> 
                                    <div class="staffPick">
                                    For cheese fanatics: a smoky, berry-flavored red that plays well with hard, aged cheeses.
                                    </div>
                            
                                </div>
                            </div>
                            
                        </div>

                    </div>
                </div>
                
               <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">
                            <div class="title">Under $20 (Whites)</div>
                            <div class="nextTitle">next: the best bets</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />   
                        <div class="slideContent">
                           
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=22933"><img src="images/itemimages/lg/22933_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=22933"><h3>Italy 2008 Gavi di Gavi Dei Marchesi</h3></a>
                                    <div class="price"><b>Now $14.96</b> Regular Price $17.99</div>
                                    <div class="itemNum">#22933</div> 
                                    <div class="staffPick">
                                    Vibrant, modern, light on its feet; the sort of wine that pleases any palate on any occasion.
                                    </div>
                            
                                </div>
                            </div>
                                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=21476"><img src="images/itemimages/lg/21476_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=21476"><h3>France 2009 Muscadet, Estelle Sauvion</h3></a>
                                    <div class="price"><b>Now $9.96</b> Regular Price $12.99</div>
                                    <div class="itemNum">#21476</div> 
                                    <div class="staffPick">
                                    People who love oysters and mussels will appreciate this full-bodied, dry white.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23773"><img src="images/itemimages/lg/23773_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23773"><h3>New York 2009 Jamesport Vineyards Estate Sauvignon Blanc</h3></a>
                                    <div class="price">$16.99</div>
                                    <div class="itemNum">#23773</div> 
                                    <div class="staffPick">
                                        Show your New York pride with this impressive and refreshing wine from Long Island’s North Fork.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=21980"><img src="images/itemimages/lg/21980_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=21980"><h3>New Zealand 2009 Russian Jack, Sauvignon Blanc</h3></a>
                                    <div class="price">$14.96</div>
                                    <div class="itemNum">#21980</div> 
                                    <div class="staffPick">                                  
                                    Powerful yet restrained, this is perfect with goat cheese.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=21955"><img src="images/itemimages/lg/21955_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=21955"><h3>Austria 2008 Gr üner Veltliner Messwein Stift Goettweig</h3></a>
                                    <div class="price">$16.99</div>
                                    <div class="itemNum">#21955</div> 
                                    <div class="staffPick">
                                    A sophisticated, bright wine for a sophisticated, bright friend.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23830"><img src="images/itemimages/lg/23830_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23830"><h3>Italy 2009 Malvasia, Alberice</h3></a>
                                    <div class="price"><b>Now $16.96</b> Regular Price $19.96</div>
                                    <div class="itemNum">#23830</div> 
                                    <div class="staffPick">
                                    Elegant and complex, this is for people who like to stop and smell the... gorgeous floral aromas.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=22818"><img src="images/itemimages/lg/22818_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=22818"><h3>France 2007 Bourgogne Chardonnay Chavy-Martin</h3></a>
                                    <div class="price"><b>Now $16.96</b> Regular Price $22.99</div>
                                    <div class="itemNum">#22818</div> 
                                    <div class="staffPick">
                                    Perfect with cheese plates, this is round, fleshy, and full of ripe fruits.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23776"><img src="images/itemimages/lg/23776_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23776"><h3>France 2007 Saumur Blanc “Les Amandiers” Ch. La Tour Gr ise</h3></a>
                                    <div class="price"><b>Now $13.96</b> Regular Price $17.96</div>
                                    <div class="itemNum">#23776</div> 
                                    <div class="staffPick">
                                    Sweet flower and honey scents. This intense Chenin Blanc is perfect all by itself; food would only be a distraction.
                                    </div>
                            
                                </div>
                            </div>
                            
                        </div>

                    </div>
                </div>
              
               <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">      
                            <div class="title">The Best Bets</div>
                            <div class="nextTitle">next: for the collector</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />                       
                        <div class="slideContent">
                            
                            <div class="intro">
                                <p>
                                The Astor staff tasted hundreds of wines and spirits this year. Here are the bottles we’re choosing to give to our friends.
                                </p>   
                                <p>~</p>                         
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=72010"><img src="images/itemimages/lg/72010_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=72010"><h3>Umenishiki saké, junmai daiginjo</h3></a>
                                    <div class="price">$97.99 | 720 mL </div>
                                    <div class="itemNum">#72010</div>
                                    <div class="staffPick">
                                    “This Daiginjo is the perfect gift for a saké connoisseur: intricately complex with flavors of ripe fruit, earth, mineral, and spice all in perfect balance.” –Ali L.
                                    </div>
                            
                                </div>
                            </div>                           
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <img src="images/itemimages/lg/23752_lg.jpg" />
                                </div>
                                
                                <div class="copyContainer">
                                    <h3>Zucca Rabarb aro Amaro</h3>
                                    <div class="price">$27.99 | 1 Liter</div> 
                                    <div class="itemNum">#23752</div>
                                    <div class="staffPick">
                                    “They’ll enjoy this Amaro traditionally (one part Zucca to one part soda on crushed ice), neat, or in a cocktail – I had atransporting one at Mayahuel with reposado tequila, cucumber, ginger, and the Zucca.” –Stephanie M.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=12268"><img src="images/itemimages/lg/12268_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=12268"><h3>Oddero, Barolo</h3></a>
                                    <div class="price">$58.99 | Italy | 1999 | 720 mL </div>
                                    <div class="itemNum">#12268</div>
                                    <div class="staffPick">
                                     “This is highly accessible Nebbiolo from an excellent estate. It’s drinking well in its youth, but will hold up in cellar for several decades. Perfect bottle for the Piemonte-initiate.” –Jon W.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=19498"><img src="images/itemimages/lg/19498_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=19498"><h3>Bushmills 1608 Irish Whiskey</h3></a>
                                    <div class="price"><b>Now $39.99</b> Regular Price $79.99 | 750 mL</div> 
                                    <div class="itemNum">#19498</div>
                                    <div class="staffPick">                                  
                                    “Ounce for ounce, the best whiskey value in our store. I’m giving this to my mechanic – he’ll see the price at his local store and flip out.” –Bill K.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23979"><img src="images/itemimages/lg/23979_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23979"><h3>Tufjano Bianco Colli della Murgia</h3></a>
                                    <div class="price>$11.96 | Italy | 2009</div> 
                                    <div class="itemNum">#23979</div>
                                    <div class="staffPick">
                                    “I was absolutely blown away by this bottle – fresh apple and citrus fruit flavors burst on the palate, followed by clean floral notes and juicy acidity. The perfect lively pick-me-up for the dead of winter!”
                                    –Kimberly K.
                                    </div>
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23311"><img src="images/itemimages/lg/23311_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23311"><h3>P’tit Rouquin “Les Vins Contés” VdT O. Lemasson</h3></a>
                                    <div class="price"><b>Now $29.96</b> Regular Price $36.99 | France | 2009 | 1.5 Liter</div> 
                                    <div class="itemNum">#23311</div>
                                    <div class="staffPick">
                                    “A bottle of wine is always a nice gift, but a largeformat
                                    bottle really makes a statement. This
                                    wine is delicious, accessible, and perfect for a
                                    crowd or a nice dinner party.” –Valerie C.
                                    </div>
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23979"><img src="images/itemimages/lg/23979_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23979"><h3>Tufjano Bianco Colli della Murgia</h3></a>
                                    <div class="price">$11.96 | Italy | 2009</div> 
                                    <div class="itemNum">#23979</div>
                                    <div class="staffPick">
                                    “A bottle of wine is always a nice gift, but a largeformat
                                    bottle really makes a statement. This
                                    wine is delicious, accessible, and perfect for a
                                    crowd or a nice dinner party.” –Valerie C.
                                    </div>
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=22265"><img src="images/itemimages/lg/22265_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=22265"><h3>Heitz “Trailside Vineyard” Cabernet Sauvignon</h3></a>
                                    <div class="price">$89.99 California 2001</div>
                                    <div class="itemNum">#22265</div>
                                    <div class="staffPick">
                                   “If I’m giving a really special gift, it’s the Heitz Trailside 2001! From an incredible year in Napa, this wine has had time to soften up the rich and powerful Trailside Vineyard fruit. Won’t last long!” –Steven B.
                                    </div>
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23829"><img src="images/itemimages/lg/23829_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23829"><h3>Ch. Simard St.-Émilion Bordeaux</h3></a>
                                    <div class="price">$22.99 France 1999</div> 
                                    <div class="itemNum">#23829</div>
                                    <div class="staffPick">
                                   “Drinking perfectly aged wines is a rare treat. This red is at its peak right now, showing secondary characteristics (dry leaves and herbs) over vibrant fruit.” –Lorena A.
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            
               <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">                            
                            <div class="title">For the Collector</div>
                            <div class="nextTitle">next: for the oenephile</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />
                        
                        <div class="slideContent">
                            
                            <div class="intro">
                                <p>
                                Anyone who is truly passionate about wine (and patient enough to wait until it’s ready) will appreciate these cellar-worthy masterpieces.
                                </p>   
                                <p>~</p>                         
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=17956"><img src="images/itemimages/lg/17956_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=17956"><h3>2005 Meursault “Perrieres” Bitouzet-Prieur</h3></a>
                                    <div class="price">$73.99 | France: Burgundy: Côte de Beaune | 750 mL</div>
                                    <div class="itemNum">#17956</div> 
                                    <div class="staffPick">
                                    From a tiny (1/4-hectare) Burgundy estate, this is a gem from a phenomenal vintage: a white wine that will keep improving in the cellar for years to come.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23556"><img src="images/itemimages/lg/23556_LG.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23556"><h3>1996 Barolo, Rocche dei Rivera di Castiglione, Oddero</h3></a>
                                    <div class="price">$99.99 | Italy: Piedmont | 750 mL</div>
                                    <div class="itemNum">#23556</div> 
                                    <div class="staffPick">
                                        This is the real deal: 1996 is widely considered one of the best Barolo vintages of all time, and Oddero is a talented, highly esteemed producer.                                    
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=20957"><img src="images/itemimages/lg/20957_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=20957"><h3>2005 Ch. Palmer, Margaux</h3></a>
                                    <div class="itemNum">#20957</div>
                                    <div class="price"><b>Now $299.99</b> Regular Price $349.99 | France: Bordeaux: Médoc| 750 mL </div>
                                    <div class="staffPick">
                                        Collectors are clamoring for Bordeaux from the spectacular 2005 vintage, and this Left Bank red is no exception. From the venerable Château Palmer, this classed-growth Margaux has a classic, elegant, age-worthy tannic structure, yet it exudes modern, fruit-forward character. Makes an unforgettable gift.
                                    </div>
                            
                                </div>
                            </div>
                                                                                    
                        </div>


                    </div>
                    </div>

                <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">                            
                            <div class="title">For the Oenephile</div>
                            <div class="nextTitle">next: for the whisk(e)y drinker</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />
                        
                        <div class="slideContent">
                            
                            <div class="intro">
                                <p>
                                    The Oenophile – known in some circles as the “wine geek” – is always on the lookout for hard-to-find bottles like these. Any wine-savvy friend will jump at the chance to taste these rare and beautiful wines.
                                </p>   
                                <p>~</p>                         
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23778"><img src="images/itemimages/lg/23778_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23778"><h3>2000 Sparkling Blanc “Ze Bulle”, Saumur Brut, Non Dosé, Ch. La Tour Grise</h3></a>
                                    <div class="price><b>Now $18.96</b> Regular Price $21.96 | France: Loire: Saumur | 750 mL </div>
                                    <div class="itemNum">#23778</div> 
                                    <div class="staffPick">
                                    The stats: dry sparkling Loire Valley Chenin Blanc, lees-aged for 7 years and disgorged in May 2010. The consensus: absolutely astounding wine.
                                    </div>
                            
                                </div>
                            </div>
                                                        
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=22061"><img src="images/itemimages/lg/22061_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=22061"><h3>2005 Arbois Pupillin Pinot Noir “l’Aide Memoire” Bornard</h3></a>
                                    <div class="price">$24.99 | France: Jura: Arbois | 750 mL </div>
                                    <div class="itemNum">#22061</div> 
                                    <div class="staffPick">
                                        Jura wines are geek catnip. From Philippe Bornard (who was literally a rock star in France before he became a winemaker) comes this unconventional, muscular, lively, fascinating Pinot Noir.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=52117"><img src="images/itemimages/lg/52117_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=52117"><h3>2000 Viña Tondonia Reserva Lopez de Heredia</h3></a>
                                    <div class="price">$39.96 | Spain: Rioja | 750 mL </div>
                                    <div class="itemNum">#52117</div> 
                                    <div class="staffPick">
                                        Here’s how traditional this estate is: When it was founded, synthetic pesticides didn’t exist – so Lopez de Heredia just never stopped being organic. They don’t see any reason why they should change, and neither do we.
                                    </div>
                            
                                </div>
                            </div>
                                  
                        </div>

                    </div>
                </div>

                <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">
                            <div class="title">For the Whisk(e)y Drinker</div>
                            <div class="nextTitle">next: for the budding bartender</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />
                        
                        <div class="slideContent">
                            
                            <div class="intro">
                                <p>
                                    As the official retailer of this year’s Ultimate Cocktails, spirits & Wine Blast, Astor Wines & Spirits is proud to feature some of the winners of the 2010 Ultimate Beverage Challenge.
                                </p>
                                <p>    
                                    The UBC’s panel of experts—several of whom are regular contributors to Astor Center seminars—tasted through hundreds of spirits before picking the winners. Opposite, a selection of the top-finishing whiskeys at the competition. Even if you’re not a whiskey drinker yourself, rest assured that your whiskey-loving friend will love these connoisseur’s picks.
                                </p>
                                <p>
                                <span style="color: #e6c75a; text-transform: uppercase;">UBC awards in gold</span>
                                </p>   
                                <p>~</p>                         
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=19469"><img src="images/itemimages/lg/19469_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=19469"><h3>Macallan Fine Oak 21 yr. Single Malt Scotch</h3></a>
                                    <div class="price">$229.99 | 750 mL </div>
                                    <div class="itemNum">#19469</div> 
                                    <div class="ubcTitle">Extraordinary</div>
                                    <div class="ubcSubTitle">Ultimate Recommendation</div>
                                    <div class="staffPick">
                                        This big, robust malt floored the judges with its power, complexity, and assertive fruit flavors. Aged in both Bourbon and Sherry casks.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=02000"><img src="images/itemimages/lg/02000_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=02000"><h3>Woodford Reserve Bourbon</h3></a>
                                    <div class="price">$32.99 | 750 mL</div>
                                    <div class="itemNum">#02000</div>
                                    <div class="ubcTitle">Excellent</div>
                                    <div class="ubcSubTitle">Highly Recommended</div>                                     
                                    <div class="staffPick">
                                        Introduced in 1996 in very limited quantities, Woodford Reserve is made of whiskey from select barrels that have been aged at least six years. Critics love the creamy texture and smooth taste. Get it while you can!                                    
                                    </div>
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=03774"><img src="images/itemimages/lg/03774_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=03774"><h3>Midleton Very Rare Irish Whiskey</h3></a>
                                    <div class="price">$134.99 | 750 mL</div>
                                    <div class="itemNum">#03774</div> 
                                    <div class="ubcTitle">Extraordinary</div>
                                    <div class="ubcSubTitle">Ultimate Recommendation</div>
                                    <div class="staffPick">
                                        Every bottle is dated, numbered, and signed by the chief distiller. This very rare whiskey has an everlasting finish that put it over the top in this competition.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=03594"><img src="images/itemimages/lg/03594_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=03594"><h3>Johnnie Walker Gold, 18 yr. Blended Scotch</h3></a>
                                    <div class="price">$67.99 | 750 mL</div>
                                    <div class="itemNum">#03594</div> 
                                    <div class="ubcTitle">Extraordinary</div>
                                    <div class="ubcSubTitle">Ultimate Recommendation</div>
                                    <div class="staffPick">                                  
                                        A perfect gift for anyone who loves Johnnie Walker Blue, the Gold blend is underrated by the public – but not by the UBC judges, who fell in love with its fudge, fruit, and light spice flavors.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23136"><img src="images/itemimages/lg/23136_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23136"><h3>AnCnoc 16 yr. Single Malt Scotch</h3></a>
                                    <div class="price">$57.99 | 750 mL</div>
                                    <div class="itemNum">#23136</div>
                                    <div class="ubcTitle">Extraordinary</div>
                                    <div class="ubcSubTitle">Ultimate Recommendation</div>                                     
                                    <div class="staffPick">
                                    One of the most fascinating drams in the competition: notes of sea salt, lemon rind, tea, cereal, and orange peel. The Bourbon-barrel aging shows up clearly on the finish; this is perfect for Bourbon drinkers.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=18905"><img src="images/itemimages/lg/18905_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=18905"><h3>Crown Royal Cask #16 Canadian Whisky</h3></a>
                                    <div class="price"><b>Now $39.99 </b> Regular Price $69.99 | 750 mL</div>
                                    <div class="itemNum">#18905</div>
                                    <div class="ubcTitle">Excellent</div>
                                    <div class="ubcSubTitle">Highly Recommended</div>                                     
                                    <div class="staffPick">
                                        A step up from the basic Crown Royal whisky, this special blend of 50 different whiskies was aged in Limousin (Cognac) casks. Smooth, subtle, and approachable.                                    
                                    </div>
                            
                                </div>
                            </div>
            
                        </div>

                    </div>
                </div>

                <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">          
                            <div class="title">For the Budding Bartender</div>
                            <div class="nextTitle">next: for yourself</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />
                        
                        <div class="slideContent">
                            
                            <div class="intro">
                                <p>
                                A friend who makes great cocktails is a blessing, and you can show your appreciation with a unique gift. Mixologists get bored with the basics, so give them one of these fascinating bottles and see what they come up with!
                                </p>   
                                <p>~</p>                         
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=24233"><img src="images/itemimages/lg/24233_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=24233"><h3>Medoyeff Vodka</h3></a>
                                    <div class="price">$32.96 | 750 mL </div>
                                    <div class="itemNum">#24233</div> 
                                    <div class="staffPick">
                                    Rye-based spirit with depth to rival the great Russian vodkas.
                                    </div>
                            
                                </div>
                            </div>                     
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23255"><img src="images/itemimages/lg/23255_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23255"><h3>Absolut Brooklyn</h3></a>
                                    <div class="price">$24.99 | 1 Liter</div>
                                    <div class="itemNum">#23255</div> 
                                    <div class="staffPick">
                                        A Spike Lee joint. Ginger, apple, attitude.
                                    </div>
                            
                                </div>
                            </div>
                           
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=10572"><img src="images/itemimages/lg/10572_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=10572"><h3>Damrak Gin</h3></a>
                                    <div class="price"><b>Now $19.99</b> Regular Price $23.99 | 750 mL </div>
                                    <div class="itemNum">#10572</div> 
                                    <div class="staffPick">
                                        Less juniper-y than most gins – amazing in cocktails.
                                    </div>
                            
                                </div>
                            </div>
                           
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23521"><img src="images/itemimages/lg/23521_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23521"><h3>Maker’s 46 Bourbon</h3></a>
                                    <div class="price">$36.99 | 750 mL </div>
                                    <div class="itemNum">#23521</div> 
                                    <div class="staffPick">                                  
                                    Maker’s Mark squared: higher proof, more oak.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=01716"><img src="images/itemimages/lg/01716_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=017176"><h3>Powers Irish Whiskey</h3></a>
                                    <div class="price">Regular Price $25.99 Now $22.99 | 1 Liter</div>
                                    <div class="itemNum">#01716</div> 
                                    <div class="staffPick">
                                    Fun party game: Powers vs. Jameson in a blind tasting!
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=23508"><img src="images/itemimages/lg/23508_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=23508"><h3>750 mL Denizen Rum</h3></a>
                                    <div class="itemNum">#23508</div> 
                                    <div class="price"><b>Now $14.99</b> Regular Price $17.99</div>
                                    <div class="staffPick">
                                    Vanilla, nutmeg, cloves, and various other dessert-y flavors.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=22325"><img src="images/itemimages/lg/22325_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=22325"><h3>Siete Leguas Reposado Tequila</h3></a>
                                    <div class="price">$42.99 | 750 mL </div>
                                    <div class="itemNum">#22325</div> 
                                    <div class="staffPick">
                                    Heavenly barrel-aged tequila for sitting and sipping.
                                    </div>
                            
                                </div>
                            </div>
                    
                        </div>

                    </div>
                </div>

                <div class="simpleSlide-slide" rel="1">
                    <div class="slide" style="width: 500px; height: 2800px;">
                        <div class="titleContainer">
                            
                            <div class="title">For Yourself</div>
                            <div class="nextTitle">next: last minute gifts</div>
                            &nbsp;
                        </div>
                        <br style="clear: both" />
                        
                        <div class="slideContent">
                            
                            <div class="intro">
                                <p>
                                The Astor staff tasted hundreds of wines and spirits this year. Here are the bottles we’re choosing to give to our friends.
                                </p>   
                                <p>~</p>                         
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=29998"><img src="images/itemimages/lg/29998_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=29998"><h3>FRANCE 2008 Crozes-Hermitage Rouge, Dom. Entrefaux</h3></a>
                                    <div class="price">$21.96</div>
                                    <div class="itemNum">#29998</div>
                                    <div class="staffPick">
                                    An opulent, earthy Rhône red with a nose full of flowers, red fruits, and earth.
                                    </div>
                            
                                </div>
                            </div>
                                               
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=17694"><img src="images/itemimages/lg/17694_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=17694"><h3>FRANCE 2008 Sancerre “Mélodie” Gaudry</h3></a>
                                    <div class="price>$23.99</div>
                                    <div class="itemNum>#17694</div>
                                    <div class="staffPick">
                                        A gorgeous white from a brilliant winemaker. Old vines, complex aromas, powerful fruit.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=18325"><img src="images/itemimages/lg/18325_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=18325"><h3>ITALY 2004 Chianti Classico Riserva Val delle Corti</h3></a>
                                    <div class="price">$30.99</div>
                                    <div class="itemNum">#18325</div>
                                    <div class="staffPick">
                                        The perfect “cellar starter” – incredible now or in 10 years. Dark berries, great structure.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=59024"><img src="images/itemimages/lg/59024_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=59024"><h3>SPAIN 2000 Muga Prado Enea Gran Reserva</h3></a>
                                    <div class="price">$51.99</div>
                                    <div class="itemNum">#59024</div>
                                    <div class="staffPick">                                  
                                       Ultra-traditional Spanish red: velvety tannins, black cherries, earth, and licorice.
                                    </div>
                            
                                </div>
                            </div>
                            
                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=66374"><img src="images/itemimages/lg/66374_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=66374"><h3>OREGON 2008 Ponzi Pinot Noir Willamette Valley</h3></a>
                                    <div class="price">$32.96</div>
                                    <div class="itemNum">#66374</div>                                    
                                    <div class="staffPick">
                                    Another winner from one of Oregon’s best Pinot Noir producers: plum, berries, baking spices.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=66144"><img src="images/itemimages/lg/66144_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=66144"><h3>CALIFORNIA 2007 Groth Cabernet Sauvignon, Napa</h3></a>
                                    <div class="price">$44.96</div>
                                    <div class="itemNum">#66144</div>
                                    <div class="staffPick">
                                    Textbook California Cabernet: a smooth texture with big, bold, complex, lush flavors.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=67704"><img src="images/itemimages/lg/67704_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=67704"><h3>CALIFORNIA 2007 Ch. Montelena Chardonnay, Napa</h3></a>
                                    <div class="price">$49.99</div>
                                    <div class="itemNum">#67704</div>
                                    <div class="staffPick">
                                    From the famed Chateau Montelena, a young Chardonnay that smells like rich apple pie.
                                    </div>
                            
                                </div>
                            </div>

                            <div class="item">
                                <div class="imageContainer">
                                    <a href="SearchResultsSingle.aspx?search=15524"><img src="images/itemimages/lg/15524_lg.jpg" /></a>
                                </div>
                                
                                <div class="copyContainer">
                                    <a href="SearchResultsSingle.aspx?search=15524"><h3>FRANCE MM Krug, Multi-Vintage Brut</h3></a>
                                    <div class="price">$139.97</div>
                                    <div class="itemNum">#15524</div>
                                    <div class="staffPick">
                                    A brilliantly made Champagne with great finesse and power.
                                    </div>
                            
                                </div>
                            </div>
                         
                        </div>

                    </div>
                </div>                
                      
            </div>
        </div>
        
        <div class="left-button" rel="1"><a href="javascript:"><< Back</a></div>
        <div class="right-button" rel="1"><a href="javascript:">Next >></a></div>
        
    </div>
    
</div>
</asp:Content>