<%@ Control Language="VB" AutoEventWireup="false" CodeFile="italian-sale.ascx.vb" Inherits="Ucontrols_promo_made_in_usa" %>
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
            margin-bottom: 20px;            
        }
        
        .header-blox
        {
            width: 500px; 
            padding: 20px 0; 
            background: #333; 
            display: inline-block; 
            font-size: 3em; 
        }
        
        .second-blox
        {
           width: 242px; 
           padding: 16px 0; 
           display: inline-block; 
           font-size: 2em; 
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
        .tiffany
        {
            background: #5e8c83;
            color: #fefefe;
        }
        a.tiffany:hover
        {
            background: #80bfb3;
        }
        .red
        {
            background: #341919;
            color: #fefefe;
        }
        .red:hover
        {
            background: #5d2d2d;
        }
        .fancy
        {
            font-family: Times New Roman, Times, Serif;
            font-style: italic;
            font-size: 1.6rem;
            line-height: 1em;
            text-align: center !important;
            color: #444;
        }
    </style>
<div style="text-align:center;">
    <div style="margin-bottom: 20px;"><asp:Image runat="server" ID="imgHero" /></div>
    <div style="border-bottom: solid 1px #ccc;">
        <h1 style="text-transform:uppercase;font-size:3rem;border-bottom:#222 solid 5px;padding-bottom:20px;line-height:1em;margin-bottom:20px;"><asp:Literal runat="server" ID="litHeadline" /></h1>
        <asp:Literal runat="server" ID="litIntro" />
    </div>
        
    <div style="border-bottom: solid 1px #ccc; text-align: center; padding: 30px 0;margin-bottom:20px;">
        <div>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&ref=clp" class="header-blox red">All Italian Wines</a>        
        </div>
        <div style="width:48%;display:inline-block;vertical-align:top;">
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=1&style=1&country=Italy&ref=clp" class="second-blox red">Under $10</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=2&style=1&country=Italy&ref=clp" class="second-blox red">$10-$20</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=3&style=1&country=Italy&ref=clp" class="second-blox red">$21-$50</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=4&style=1&country=Italy&ref=clp" class="second-blox red">$51-$100</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=5&style=1&country=Italy&ref=clp" class="second-blox red">Above $100</a>
        </div>
        <div style="width:48%;display:inline-block;">
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Piedmont&subregion=Barolo&ref=clp" class="second-blox red">Barolo</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Piedmont&subregion=Barbaresco&ref=clp" class="second-blox red">Barbaresco</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Piedmont&ref=clp" class="second-blox red">All Piedmont</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Abruzzi&ref=clp" class="second-blox red">Abruzzi</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Apulia&ref=clp" class="second-blox red">Apulia</a>      
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Campania&ref=clp" class="second-blox red">Campania</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Emilia-Romagna&ref=clp" class="second-blox red">Emilia-Romagna</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Friuli-Venezia+Giulia&ref=clp" class="second-blox red">Friuil-Venezia Giulia</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Lombardy&ref=clp" class="second-blox red">Lombardy</a>           
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&grape=Prosecco+(Glera)&ref=clp" class="second-blox red">Prosecco</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Sicily&ref=clp" class="second-blox red">Sicily</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Trentino-Alto+Adige&ref=clp" class="second-blox red">Trentino-Alto Adige</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Tuscany&ref=clp" class="second-blox red">Tuscany</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&region=Veneto&ref=clp" class="second-blox red">Veneto</a>
        </div>
    </div>
    
    <div class="note"><asp:Literal runat="server" ID="litRestrictions" /></div>
</div>
</asp:PlaceHolder>


