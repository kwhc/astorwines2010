<%@ Control Language="VB" AutoEventWireup="false" CodeFile="made-in-usa.ascx.vb" Inherits="Ucontrols_promo_made_in_usa" %>
<asp:PlaceHolder runat="server" ID="phPromo">
    <style>
        a
        {
            text-decoration: none !important;
        }
        
        .header-blox, .second-blox
        {
           font-family: 'Open Sans Condensed', Arial, Helvetica, Sans-Serif;
           color: #fefefe;
           text-transform: uppercase;
            line-height: 1em;
        }
        
        .header-blox
        {
            width: 300px; 
            padding: 20px 0; 
            background: #333; 
            display: inline-block; 
            font-size: 3em; 
           margin-bottom: 20px;            
        }
        
        .second-blox
        {
            width: 200px; 
            padding: 10px 0; 
            display: inline-block; 
            font-size: 2em; 
           margin-bottom: 10px;
        }
        
        .red
        {
            background: #98002e;
        }
        
        a.red:hover
        {
            background: #c83348;
        }
        
        .blue
        {
            background: #1c3c6d;
        }
        
        a.blue:hover
        {
            background: #285498;
        }
        
        a.orange
        {
            background: #e54800;
        }
        
        a.orange:hover
        {
            background: #f37a43;
        }
    </style>

    <div style="margin-bottom: 20px;"><asp:Image runat="server" ID="imgHero" /></div>
    <div style="border-bottom: solid 1px #ccc;">
        <asp:Literal runat="server" ID="litIntro" />
    </div>
        
    <div style="border-bottom: solid 1px #ccc; text-align: center; padding: 30px 0;">
        <div>
            <a class="header-blox orange" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=USA&ref=clp">American Wines</a>
        </div>
        <div style="display: inline-block; width: 250px; vertical-align: top;">
                <ul>
                    <li><a class="second-blox blue" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=USA&color=Red&ref=clp">Red</a></li>
                    <li><a class="second-blox blue" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=USA&color=White&ref=clp">White</a></li>
                    <li><a class="second-blox blue" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=USA&color=Ros%C3%A9&ref=clp">Pink</a></li>
                </ul>
        </div>
        <div style="display: inline-block; width: 250px; vertical-align: top;">
                <ul>
                    <li><a class="second-blox red" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=1&country=USA&ref=clp">Under $10</a></li>
                    <li><a class="second-blox red" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=2&country=USA&ref=clp">$10 - $20</a></li>
                    <li><a class="second-blox red" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=3&country=USA&ref=clp">$21 - $50</a></li>
                    <li><a class="second-blox red" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=4&country=USA&ref=clp">$51 - $100</a></li>
                    <li><a class="second-blox red" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=5&country=USA&ref=clp">Above $100</a></li>
                </ul>
        </div>
        <div>
            <a href="../Features.aspx?featurepage=10_1_5_222&ref=clp" class="header-blox orange">Our Favorites</a>
        </div>
    </div>

    <div style="border-bottom: solid 1px #ccc; text-align: center; padding: 30px 0;">
        <div>
            <a class="header-blox orange" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&ref=clp">American Spirits</a>
        </div>
        <div style="display: inline-block; width: 250px; vertical-align: top;">
                <ul>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=2_32&ref=clp">Bourbon</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=2_36&ref=clp">Rye</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=1_18&ref=clp">All Whiskey</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=1_20&ref=clp">Vodka</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=1_19&ref=clp">Gin</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=2_52&ref=clp">Absinthe</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=1_17&ref=clp">Brandy</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=1_24&ref=clp">Liqueur</a></li>
                    <li><a class="second-blox blue" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&country=USA&style=1_22&ref=clp">Rum</a></li>
                </ul>
        </div>
        <div style="display: inline-block; width: 250px; vertical-align: top;">
                <ul>
                    <li><a class="second-blox red" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&pricerange=1&country=USA&ref=clp">Under $10</a></li>
                    <li><a class="second-blox red" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&pricerange=2&country=USA&ref=clp">$10 - $20</a></li>
                    <li><a class="second-blox red" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&pricerange=3&country=USA&ref=clp">$21 - $50</a></li>
                    <li><a class="second-blox red" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&pricerange=4&country=USA&ref=clp">$51 - $100</a></li>
                    <li><a class="second-blox red" href="../SpiritsSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=2&pricerange=5&country=USA&ref=clp">Above $100</a></li>
                </ul>
        </div>
         <div>
            <a href="../Features.aspx?featurepage=10_1_2_223&ref=clp" class="header-blox orange">Our Favorites</a>
        </div>
   </div>


</asp:PlaceHolder>