<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test-food-pairing.aspx.vb" Inherits="food_pairing" MasterPageFile="~/as_master_1.master" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadSupplement">

    <script type="text/javascript" src="/js/jquery.scrollTo-1.4.2-min.js"></script>
    <script type="text/javascript" src="/js/jquery.localscroll-1.2.7-min.js"></script>

<script type="text/javascript">

    $(document).ready(function(){
	    
	    $('#links').localScroll({
            target: '#slideWindow',
            axis: 'xy',
            queue: true,
            hash: false   
        });

    });

</script>

<style type="text/css">

/* BEGIN FOOD PAIRING PAGE STYLES */

#foodPairingPage{
    background-color: #ffffff;
    padding: 20px;
}

    #foodPairingPage a{
        text-decoration: none;
    }
    
    #foodPairingPage #slideWindow{
        width: 574px;
        height: 500px;
        overflow: hidden;
        margin-top: -5px;
        margin-left: -9px;
        background-color: #555555;
        border: solid 5px #555555;
        background-image: url(../images/foodPairing/pinstripe.gif);
        background-repeat: repeat;
    }
    
    #foodPairingPage .slide{
        width: 560px;
        height: 500px;
        background-color: #eeeeee;
        border: solid 1px #dddddd;
        margin: 5px;
        display: inline-block;
        padding: 10px;
        vertical-align: top;
    }
    
    #start{
        text-align: center;
    }
    
        #start h2{
            text-transform: uppercase;
            font-weight: normal;
            margin-bottom: 20px;
            margin-top: 20px;
            font-size: 2em;
        }
    
        #start .pairingChoice{
            background-color: #dddddd;
            text-align: center;
            display: inline-block;
            width: 200px;
            margin: 5px;
            padding: 5px; 
        }
        
        #start .copy{
            text-align: left;
            margin-top: 20px;
            padding: 20px;
        }
        
        #foodPairingPage .slide .navigation{
            width: 155px;
            display: inline-block;
            background-color: #555555;
            color: #eeeeee;
        }
            .slide .navigation span, .slide .mainTitleContainer span{
                font-family: Georgia, Times New Roman, Times, Serif;
                font-size: .8em;
            }
            
            .slide .navigation .tab{
                padding: 6px;
            }

        #foodPairingPage .slide .contentContainer{
            width: 400px;
            display: inline-block;
            vertical-align: top;
        }
        
            .slide .contentContainer .slideMainImgContainer{
                width: 390px;
                background-color: #333333;
                margin-bottom: 10px;
                height: 140px;
            }
            
            .slide .contentContainer .mainTitleContainer{
                display: inline-block;
                width: 120px;
            }
            
                .mainTitleContainer .returnLinks{
                    margin-top: 10px;
                    font-family: Georgia, Times New Roman, Times, Serif;
                    font-size: .8em; 
                }
            
                .mainTitleContainer h2{
                    font-family: Georgia, Times New Roman, Times, Serif;
                    text-transform: uppercase;
                    font-size: 1.2em;
                    font-weight: normal;
                }
            
            .slide .contentContainer .slideMainDescriptionContainer{
                display: inline-block;
                width: 256px;
                /* background-color: Fuchsia; */
                padding: 5px;
            }
            
            .slide .contentContainer .slideItemSectionContainer{
                margin-top: 10px;
                width: 350px;
                border: solid 1px #dddddd;
                padding: 20px;
            }
            
                .slideItemSectionContainer .item{
                    
                }
        
    .slideRow{
        width: 2000px;
    }    
        
    /*    .slideRow #pork, .slideRow #chicken, .slideRow #beef, .slideRow #pork1, .slideRow #pork2, .slideRow #pork3, .slideRow #pork4, .slideRow #chicken1, .slideRow #chicken2, .slideRow #chicken3, .slideRow #chicken4, .slideRow #beef1{
            display: inline-block;
        }
    */    

/* END FOOD PAIRING PAGE STYLES */

</style>

</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="middleContent">

<div id="foodPairingPage">
    <h1>Food and Wine Pairing</h1>
    
    <div id="slideWindow">
    <div id="links">
        <div class="slideRow">
        
            <div class="slide" id="start">
                
                <h2>What's for dinner?</h2>
                
                <a href="#pork">
                <div class="pairingChoice">
                    <img /><br />
                    PORK
                </div>
                </a>
                
                <a href="#chicken">
                    <div class="pairingChoice">
                        <img /><br />
                        CHICKEN
                    </div> 
                </a>
                
                <a href="#beef">
                    <div class="pairingChoice">
                        <img /><br />
                        BEEF
                    </div> 
                </a>
                
                <a href="#pasta">
                    <div class="pairingChoice">
                        <img /><br />
                        PASTA
                    </div> 
                </a>
                
                <div class="copy">    
                    <p>Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.</p>
                </div>
                    
            </div>
        </div>
        
        <div class="slideRow">
            <div class="slide" id="pork">
                
                <div class="contentContainer">
                    
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slidePork.jpg" />
                    </div>
                    
                    <div class="mainTitleContainer">
                        <h2>Pork</h2>
                        <div class="returnLinks">
                            <a href="#start">return to start</a>
                        </div>
                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>Easy, fail-safe pairings that will work with a broad range of pork dishes.</p>
                    </div>
                    
                    <div class="slideItemSectionContainer">
                        ITEMS
                    </div>
                    
                </div>
                
                <div class="navigation">
                    <div class="tab">
                        <a href="#pork1">Straightforward</a><br />
                        <span>Roasted, grilled, pan-seared. Served without a sauce.</span>
                    </div>
                    <div class="tab">
                        <a href="#pork2">with a rich sauce</a><br />
                        <span>Anything buttery, creamy, reduced or braised.</span>
                    </div>
                    <div class="tab">
                        <a href="#pork3">with a sweet sauce</a><br />
                        <span>Think baby-back ribs, sweet & sour, honey-glazed pork chops.</span>
                    </div>
                    <div class="tab">
                        <a href="#pork4">with a tart sauce</a><br />
                        <span>Think lemon, tomato, or vinegar-based sauces.</span>
                    </div>
                </div>
            </div>
            
            <div class="slide" id="chicken">
                <div class="contentContainer">
                    
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slideChicken.jpg" />
                    </div>
                    
                    <div class="mainTitleContainer">
                        <h2>Chicken</h2>
                        <div class="returnLinks">
                            <a href="#start">return to start</a>
                        </div>                    
                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.</p>
                    </div>
                    
                    <div class="slideItemSectionContainer">
                    </div>
                    
                </div>
                <div class="navigation">
                    <div class="tab">
                        <a href="#chicken1">straightforward</a><br />
                        <span>Roasted, grilled, pan-seared. Served without a sauce.</span>
                    </div>
                    <div class="tab">
                        <a href="#chicken2">with a rich sauce</a><br />
                        <span>Anything buttery, creamy, reduced or braised.</span>
                    </div>
                    <div class="tab">
                        <a href="#chicken3">with a sweet sauce</a><br />
                        <span>Think BBQ, honey-glazed, sweet & sour chicken.</span>
                    </div>
                    <div class="tab">
                        <a href="#chicken4">with a tart sauce</a><br />
                        <span>Think lemon, tomato, or vinegar-based sauces.</span>
                    </div>
                </div>
            </div>

            <div class="slide" id="beef">
                <div class="contentContainer">
                
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slideBeef.jpg" />
                    </div>
                    
                    <div class="mainTitleContainer">
                        <h2>Beef</h2>
                        <div class="returnLinks">
                            <a href="#start">return to start</a>
                        </div>
                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.</p>
                    </div>
                    
                    <div class="slideItemSectionContainer">
                        ITEMS
                    </div>
                    
                </div>
                <div class="navigation">
                    <div class="tab">
                        <a href="#beef1">Straightforward</a>
                    </div>
                    <div class="tab">
                        <a href="#beef2">with a rich sauce</a>
                    </div>
                    <div class="tab">
                        <a href="#beef3">with a sweet sauce</a>
                    </div>
                    <div class="tab">
                        <a href="#beef4">with a tart sauce</a>
                    </div>
                </div>
            </div>

        </div>
        
        <div class="slideRow">
 
            <div class="slide" id="pork1">
                <div class="contentContainer">
                    
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slidePork.jpg" />
                    </div>
                    
                    <div class="mainTitleContainer">
                        <h2>Pork</h2>
                        Straightforward<br />
                        <span>Roasted, grilled, pan-seared. Served without a sauce.</span>
                        <div class="returnLinks">
                            <a href="#pork">return to pork</a><br />
                            <a href="#start">return to start</a>
                        </div>
                    </div>

                    <div class="slideMainDescriptionContainer">    
                        <p>A medium-bodied wine with a bit of richness will stand up to simple pork dishes without overpowering them. Rich whites & light reds work equally well here.</p>
                    </div>

                    <div class="slideItemSectionContainer">
                    </div>

                </div>
            </div>

            <div class="slide" id="pork2">
                <div class="contentContainer">

                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slidePork.jpg" />
                    </div>

                    <div class="mainTitleContainer">
                        <h2>Pork</h2>
                        with a rich sauce<br />
                        <span>Anything buttery, creamy, reduced or braised.</span>                    
                        <div class="returnLinks">
                            <a href="#pork">return to pork</a><br />
                            <a href="#start">return to start</a>
                        </div>
                    </div>

                    <div class="slideMainDescriptionContainer">    
                        <p>Richness is the key here. If it's a lighter dish (pork braised with apples & bacon, perhaps) go with a rich white. If it's a heavier dish (pork braised with redwine) a medium red would work.</p>
                    </div>

                    <div class="slideItemSectionContainer">
                    </div>

                </div>
            </div>

            <div class="slide" id="pork3">
                <div class="contentContainer">
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slidePork.jpg" />
                    </div>
                    
                    <div class="mainTitleContainer">
                        <h2>Pork</h2>
                        with a sweet sauce<br />
                        <span>Think baby-back ribs, sweet & sour, honey-glazed pork chops.</span>
                        <div>
                            <a href="#pork">return to pork</a><br />
                            <a href="#start">return to start</a>
                        </div>                    
                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>A fun, fruity wine (either white or red) will balance the sweetness of the sauce.</p>
                    </div>
                    
                    <div class="slideItemSectionContainer">
                    ITEMS
                    </div>
                </div>
            </div>

            <div class="slide" id="pork4">
                <div class="contentContainer">
                    
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slidePork.jpg" />
                    </div>

                    <div class="mainTitleContainer">
                        <h2>Pork</h2>
                        with a tart sauce<br />
                        <span>Think lemon, tomato, or vinegar-based sauces.</span>                    
                        <div class="returnLinks">
                            <a href="#pork">return to pork</a><br />
                            <a href="#start">return to start</a>
                        </div>
                    </div>
                                        
                    <div class="slideMainDescriptionContainer">    
                        <p>Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.</p>
                    </div>
                    
                    <div class="slideItemSectionContainer">
                        ITEMS
                    </div>

                </div>
            </div>

            <div class="slide" id="chicken1">
                <div class="contentContainer">
                
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slideChicken.jpg" />
                    </div>
                    
                    <div class="mainTitleContainer">
                        <h2>Chicken</h2>
                        straight-forward
                        <span>Roasted, grilled, pan-seared. Served without sauce.</span>
                        <div class="returnLinks">
                            <a href="#chicken">return to chicken</a><br />
                            <a href="#start">return to start</a>
                        </div>

                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>A medium-bodied white or very light red would work to stand up to these simple chicken dishes without overpowering them.</p>
                    </div>

                    <div class="slideItemSectionContainer">
                    </div>

                </div>
            </div>

            <div class="slide" id="chicken2">
                <div class="contentContainer">
                                    
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slideChicken.jpg" />
                    </div>

                    <div class="mainTitleContainer">
                        <h2>Chicken</h2>
                        with a rich sauce
                        <span>Anything buttery, creamy, reduced or braised.</span>                    
                        <div class="returnLinks">
                            <a href="#chicken">return to chicken</a><br />
                            <a href="#start">return to start</a>
                        </div>
                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>A rich white or medium-bodied red will stand up to more intense chicken dishes.</p>
                    </div>

                    <div class="slideItemSectionContainer">
                    </div>

                </div>
            </div>

            <div class="slide" id="chicken3">
                <div class="contentContainer">

                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slideChicken.jpg" />
                    </div>
                
                    <div class="mainTitleContainer">
                        <h2>Chicken</h2>
                        with a sweet sauce
                        <span>Think BBQ, honey-glazed, sweet & sour chicken.</span>                        
                        <div class="returnLinks">
                            <a href="#chicken">return to chicken</a><br />
                            <a href="#start">return to start</a>
                        </div>
                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>A fun, fruity wine (either white or light to medium-bodied red) will balance the sweetness of the sauce.</p>
                    </div>

                    <div class="slideItemSectionContainer">
                    </div>

                </div>
            </div>

            <div class="slide" id="chicken4">
                <div class="contentContainer">

                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slideChicken.jpg" />
                    </div>
                    
                    <div class="mainTitleContainer">
                        <h2>Chicken</h2>
                        with a tart sauce
                        <span>Think Lemon, tomato, or vinegar-based sauces.</span>                    
                        <div class="returnLinks">
                            <a href="#chicken">return to chicken</a><br />
                            <a href="#start">return to start</a>
                        </div>
                    </div>
                
                    <div class="slideMainDescriptionContainer">    
                        <p>A medium-bodied white or very light red with a good dose of acidity will stand up to tart sauces, balancing the flavors of the dish.</p>
                    </div>
                    
                    <div class="slideItemSectionContainer">
                    </div>
                    
                </div>
            </div>

            <div class="slide" id="beef1">
                <div class="contentContainer">
                                
                    <div class="slideMainImgContainer">
                        <img src="images/foodPairing/img_slideBeef.jpg" />
                    </div>
                
                    <div class="mainTitleContainer">
                        <h2>Beef</h2>
                        straightforward
                        <div class="returnLinks">
                            <a href="#beef">return to beef</a><br />
                            <a href="#start">return to start</a>
                        </div>                         
                    </div>
                    
                    <div class="slideMainDescriptionContainer">    
                        <p>Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet.</p>
                    </div>
                    
                    <div class="slideItemSectionContainer">
                    ITEMS
                    </div>
                    
                    <div>
                    
                    </div>
                </div>
            </div>

        
        </div>
    
    </div>    
    </div>
</div>

</asp:Content>