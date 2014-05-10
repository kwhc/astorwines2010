<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="thanksgiving-favorites.aspx.vb" Inherits="giftcards" title="Thanksgiving Favorites | Astor Wines & Spirits" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadSupplement">
    <style type="text/css">
        
        #thanksgivingFavorites {
        }
        
            #thanksgivingFavorites #showContainer {
                display: inline-block;
                width: 538px;
                color: #333333;
                /* border: solid 1px #dddddd; */
                margin: 10px;
                text-align: center;
                position: relative;
                z-index: 0;
            }
            
            #thanksgivingFavorites .slide{
                height: 1100px;
                width: 488px;
                padding: 20px;
                border: solid 10px #ffffff;
                text-align: left;
                position: relative;
                z-index: 0;
            } 
            
            #thanksgivingFavorites .featuredItemsContainer{
                background-color: #ffffff;
                width: 390px;
                margin: 0 auto;
                padding: 5px;
                border: solid 1px #eeeeee;
                text-align: center;
            }
            
                #thanksgivingFavorites .featuredItemsContainer h3{
                    text-align: center;
                    margin-top: 6px;
                    font-size: 1.6em;
                    text-transform: uppercase;
                    font-weight: normal;
                    letter-spacing: .1em;
                    color: #333333;
                    border-bottom: solid 1px #eeeeee;
                    padding-bottom: 4px;
                }
            
            #thanksgivingFavorites .itemContainer{
                width: 340px;
                margin-bottom: 20px;
                clear: left;
                height: 150px;
                vertical-align: middle;
                padding: 10px 20px;
                text-align: left;
                color: #aaaaaa;
            }
            
                #thanksgivingFavorites .itemContainer a{
                    font-size: 1.2em;
                    text-transform: uppercase;
                    letter-spacing: .1em;
                }
                
                #thanksgivingFavorites .itemContainer a:hover{
                    /* background-color: #eeeeee; */
                    text-decoration: none;
                }
                
                #thanksgivingFavorites .itemContainer img{
                    margin-right: 10px;
                    float: left;
                }
            
                #thanksgivingFavorites #showContainer #turkey{
                    /* background-color: #aceace; */
                    background-image: url(images/thanksgiving/slideBackground1.jpg);
                    background-repeat: repeat;
                }
                
                #thanksgivingFavorites #showContainer #cooking{
                    /* background-color: #6f2534; */
                    background-image: url(images/thanksgiving/slideBackground2.jpg);
                    background-repeat: repeat;
                }
                
                #thanksgivingFavorites #showContainer #someoneelse{
                    /* background-color: #6f894e; */
                    background-image: url(images/thanksgiving/slideBackground3.jpg);
                    background-repeat: repeat;
                }
                
                #thanksgivingFavorites #showContainer #tradition{
                    /* background-color: #ede36e; */
                    background-image: url(images/thanksgiving/slideBackground4.jpg);
                    background-repeat: repeat;                    
                }
                
                #thanksgivingFavorites #showContainer #family{
                    /* background-color: #ae2f2c; */
                    background-image: url(images/thanksgiving/slideBackground5.jpg);
                    background-repeat: repeat;  
                }
                
                #thanksgivingFavorites #showContainer #friends{
                    /* background-color: #be791f; */
                    background-image: url(images/thanksgiving/slideBackground6.jpg);
                    background-repeat: repeat;
                }
                
                #thanksgivingFavorites .slide p{
                    color: #ffffff;
                    font-size: 1.2em;
                    line-height: 1.4em;
                    margin-top: 10px;
                    margin-bottom: 20px;
                }
                
                #thanksgivingFavorites .slide .slideImgContainer{
                    text-align: center;
                }
                
                #thanksgivingFavorites .slide .slideImg{
                    display: inline;
                }
    
            #thanksgivingFavorites #controlsContainer {
                display: inline-block;
                width: 200px;
                height: 390px;
                vertical-align: top;
                padding-top: 10px;
                background-color: #be411f;
            }
            
               #thanksgivingFavorites #controlsContainer div {
                    margin-bottom: 2px;
                    line-height: 1.6em;
                    border-bottom: solid 1px #ffffff;
                    color: #ffffff;
                    padding: 10px;
                    text-align: center;
                }
                
                #thanksgivingFavorites #controlsContainer a {
                    text-decoration: none;
                    letter-spacing: .1em;
                    font-weight: bold;
                    text-transform: uppercase;
                }
            
                #thanksgivingFavorites #controlsContainer a:hover {
                    text-decoration: none;
                }
            
            #thanksgivingFavorites h1{
                text-transform: uppercase;
                margin-top: -150px;
                font-weight: normal;
                font-size: 2em;
                position: relative;
                z-index: 8;
                color: #ffffff;
                letter-spacing: .04em;
                line-height: 1.6em;
            }
            
                #thanksgivingFavorites h1 span{
                    font-size: 2.6em;
                    font-weight: bold;
                }
            
            #thanksgivingFavorites h2{
                font-size: 1.8em;
                font-weight: bold;
                color: #fefefe;
            }
            
            #thanksgivingFavorites #leftButton, #thanksgivingFavorites #rightButton {
                /* display: none; */
                display: inline-block;
                vertical-align: top;
                position: relative;
                top: -1100px;
            }
            
             #thanksgivingFavorites #leftButton {
                float: left;
             }
             
             #thanksgivingFavorites #rightButton { 
                 float: right;
              }
            
    #mainContentHeader { 
        background-image: none;
    }
    
        #thanksgivingFavorites #leafImage {
            margin-left: -20px;
            margin-top: -40px;
            position: relative;
            z-index: 5;
        }
    
    #thanksgivingFavorites{
        background-image: url(../images/thanksgiving/middleContentBackground-thanksgiving.gif);
    }
    
    #thanksgivingFavorites #subSlideContainer{
        margin-left: 10px;
    }
    
        #thanksgivingFavorites #subSlideContainer img{
            display: inline;
        }
    
    </style>
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <img src="images/thanksgiving/header.png" />
    
    <div class="customPage" id="thanksgivingFavorites">

        <img src="images/thanksgiving/favorites.png" alt="leaf" id="leafImage" />
        <h1>What's Your Favorite Part of <br /> <span>Thanksgiving?</span></h1>
        
        <div id="showContainer">
            <div class="simpleSlide-window" rel="1">
                <div class="simpleSlide-tray" rel="1">
 
                    <div class="simpleSlide-slide" rel="1" alt="1">
                        <div id="turkey" class="slide">
                            <div class="slideImgContainer">
                                <img class="slideImg" src="images/thanksgiving/slideImg-turkey.png" alt="The Turkey" />
                            </div>
                            <h2>Turkey Time</h2>
                            <p>
                            A Thanksgiving feast can take days to prepare, so don’t let the wine be an afterthought! These wines are perfect with turkey and all the classic sides, and they’re lively enough not to weigh you down during your marathon eating-and-drinking session.                                        </p>

                            <div class="featuredItemsContainer">
                                <h3>Terrific Turkey Wines</h3>
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/62584_sm.jpg" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=62584&searchtype=Contains&term=&p=1">Saintsbury Pinot Noir "Garnet", Carneros</a><br />
                                    California, USA
                                </div>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/18161_sm.jpg" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=18161&searchtype=Contains&term=&p=1">Klinker Brick, Old Vine Zinfandel</a><br />
                                    California, USA
                                </div>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/20466_sm.jpg" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=20466&searchtype=Contains&term=&p=1">Moscato Giallo "Vigna Giere", Vivallis</a><br />
                                    Trentino-Alto-Adige, Italy
                                </div>
                            
                            </div>


                        </div>
                    </div>
                    
                    <div class="simpleSlide-slide" rel="1" alt="2">
                            <div id="cooking" class="slide">
                                <div class="slideImgContainer">
                                    <img class="slideImg" src="images/thanksgiving/slideImg-cooking.png" alt="Cooking Up A Storm" />
                                </div>
                                <h2>Cooking Up a Storm</h2>
                                <p>
                                If you’re hosting the feast this year, most of your budget is probably devoted to food – but that doesn’t mean you should settle for mediocre wine. Try these excellent and wallet-friendly bottles: They’ll make your culinary creations taste better, and they’re low in alcohol, so your guests can sip them all day long.
                                </p>

                                <div class="featuredItemsContainer">
                                    <h3>Perfect for Holiday Hosts</h3>
                                    <div class="itemContainer">
                                        <img src="images/itemimages/sm/23516_sm.jpg" alt="Dom. de l'Enclos Blanc, VdP Côtes de Gascogne" />
                                        <br /><br /><br /><a href="SearchResultsSingle.aspx?search=23516&searchtype=Contains&term=&p=1">Dom. de l'Enclos Blanc, VdP Côtes de Gascogne</a><br />
                                        Gascogne, France
                                    </div>
                                    
                                    <div class="itemContainer">
                                        <img src="images/itemimages/sm/21847_sm.jpg" alt="Klinker Brick, Old Vine Zinfandel" />
                                        <br /><br /><br /><a href="SearchResultsSingle.aspx?search=21847&searchtype=Contains&term=&p=1">Salice Salentino Riserva, Sigillus Primus</a><br />
                                        Apulia, Italy
                                    </div>
                                
                                </div>

                            </div>
                    </div>
                    
                    <div class="simpleSlide-slide" rel="1" alt="3">
                        <div id="someoneelse" class="slide">
                            <div class="slideImgContainer">
                                <img class="slideImg" src="images/thanksgiving/slideImg-someoneElse.png" alt="Letting Someone Else Cook" />
                            </div>
                            <h2>Letting Someone Else Do the Cooking</h2>
                            <p>
                            Even if you don’t set foot in a kitchen this season, you can still bring something amazing to the table. Being a great guest is easy: Give your host a truly special bottle when you arrive, and for the rest of the night you can do no wrong!                                        </p>

                            <div class="featuredItemsContainer">
                                <h3>Great Guests Give Great Gifts</h3>
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/12375_sm.jpg" alt="Tulocay Pinot Noir, Haynes Vineyard" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=12375&searchtype=Contains&term=&p=1">Tulocay Pinot Noir, Haynes Vineyard</a><br />
                                    California, USA
                                </div>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/22818_sm.jpg" alt="Bourgogne Chardonnay, Chavy-Martin" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=22818&searchtype=Contains&term=&p=1">Bourgogne Chardonnay, Chavy-Martin</a><br />
                                    Burgundy, France
                                </div>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/17704_sm.jpg" alt="Schramsberg, Brut Rosé" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=17704&searchtype=Contains&term=&p=1">Schramsberg, Brut Rosé</a><br />
                                    California, USA
                                </div>
                            
                            </div>


                        </div>
                    </div>
                    
                    <div class="simpleSlide-slide" rel="1" alt="4">
                        <div id="tradition" class="slide">
                            <div class="slideImgContainer">
                                <img class="slideImg" src="images/thanksgiving/slideImg-tradition.png" alt="Keeping Traditions Alive" />
                            </div>
                            <h2>Keeping Traditions Alive</h2>
                            <p>
                            Thanksgiving has some uniquely American traditions: watching way too much football, drinking American wine with dinner, and cramming all the leftovers into one giant sandwich the next day. As long as you’re buying American, make sure your wines are tasty, elegant, and Thanksgiving-appropriate – like these.
                            </p>

                            <div class="featuredItemsContainer">
                                <h3>All-American Flavors</h3>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/23730_sm.jpg" alt="Palmer Vineyards Pinot Blanc" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=23730&searchtype=Contains&term=&p=1">Palmer Vineyards Pinot Blanc</a><br />
                                    New York, USA
                                </div>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/19250_sm.jpg" alt="Ponzi ""Tavola"" Pinot Noir" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=19250&searchtype=Contains&term=&p=1">Ponzi "Tavola" Pinot Noir</a><br />
                                    Oregon, USA
                                </div>
                            
                            </div>


                        </div>
                    </div>
                    
                    <div class="simpleSlide-slide" rel="1" alt="5">
                        <div id="family" class="slide">
                            <div class="slideImgContainer">
                                <img class="slideImg" src="images/thanksgiving/slideImg-family.png" alt="Celebrating With Family" />
                            </div>
                            <h2>Visiting the Family</h2>
                            <p>
                            Picture the characters in your extended family. Now try to picture all of them agreeing on something (anything!) this Thanksgiving. If you’re choosing wine for a diverse mix of palates and personalities, it’s best to go with surefire crowd-pleasers. These bottles are juicy, easy to love, and perfect for large parties.
                            </p>
                            
                            <div class="featuredItemsContainer">
                                <h3>Wines Everyone Will Love</h3>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/23682_sm.jpg" alt="Bacchus Pinot Noir, Ginger's Cuvée" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=23682&searchtype=Contains&term=&p=1">Bacchus Pinot Noir, Ginger's Cuvée</a><br />
                                    California, USA
                                </div>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/22156_sm.jpg" alt="Substance ""Re"" Riesling" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=22156&searchtype=Contains&term=&p=1">Substance "Re" Riesling</a><br />
                                    Washington, USA
                                </div>
                            
                            </div>
                        </div>
                    </div>
                    
                    <div class="simpleSlide-slide" rel="1" alt="6">
                        <div id="friends" class="slide">
                            <div class="slideImgContainer">
                                <img class="slideImg" src="images/thanksgiving/slideImg-nyc.png" alt="Celebrating With Friends In NYC" />
                            </div>
                            <h2>Celebrating With Friends in NYC</h2>
                            <p>
                            You wanted to go back to Skokie for Thanksgiving with the family, but something came up and you’re stuck in New York. Adventurous city folk: Seize this opportunity! This year you can share exciting tastes with your like-minded foodie friends, without worrying about what Aunt Mabel thinks of your bold choices (or your fancy big-city ideas in general). Open one of these deliciously daring bottles, then raise a glass to friends and the city you love.
                            </p>
                            
                            <div class="featuredItemsContainer">
                                <h3>For Your Foodie Friends</h3>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/23777_sm.jpg" alt="l'Affranchi Rouge, Zéro Pointé" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=23777&searchtype=Contains&term=&p=1">l'Affranchi Rouge, Zéro Pointé</a><br />
                                    Loire, France
                                </div>
                                
                                <div class="itemContainer">
                                    <img src="images/itemimages/sm/22456_sm.jpg" alt="Cyril Zangs Sparkling Cider" />
                                    <br /><br /><br /><a href="SearchResultsSingle.aspx?search=22456&searchtype=Contains&term=&p=1">Cyril Zangs Sparkling Cider</a><br />
                                    Normandy, France
                                </div>
                            
                            </div>
                            
                        </div>
                    </div>
                    
                </div>
            </div> 
        </div>
        
        <div id="subSlideContainer">
            <a href="emails.aspx"><img src="images/thanksgiving/banner_email.jpg" /></a>
            <a href="DeliveryInformation.aspx"><img src="images/thanksgiving/banner_freeDelivery.jpg" alt="Free Delivery" /></a>        
        </div>
         
        <a href="javascript:"><div id="leftButton" class="left-button" rel="1"><img src="../images/thanksgiving/slideshowControlsLeft.png" alt="Back" /></div></a>
        <a href="javascript:"><div id="rightButton" class="right-button" rel="1"><img src="../images/thanksgiving/slideshowControlsRight.png" alt="Next" /></div></a>     

        
        <!--    
        <div id="controlsContainer">
    
            <a href="javascript:"><div class="jump-to" rel="1" alt="1">Turkey</div></a>
            <a href="javascript:"><div class="jump-to" rel="1" alt="2">Your Cooking</div></a>
            <a href="javascript:"><div class="jump-to" rel="1" alt="3">Someone Else's Cooking</div></a>
            <a href="javascript:"><div class="jump-to" rel="1" alt="4">Tradition</div></a>
            <a href="javascript:"><div class="jump-to" rel="1" alt="5">Family</div></a>
            <a href="javascript:"><div class="jump-to" rel="1" alt="6">Friends</div></a>
               
        </div>
        -->

        <br style="clear: both;" />
        
        <asp:Button ID="addToCart" runat="server" Text="Button" Visible="false"  />

     </div>
</asp:Content>