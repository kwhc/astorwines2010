<%@ Control Language="VB" AutoEventWireup="false" CodeFile="white-sale.ascx.vb" Inherits="Ucontrols_promo_made_in_usa" %>
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
            width: 300px; 
            padding: 20px 0; 
            background: #333; 
            display: inline-block; 
            font-size: 3em; 
        }
        
        .second-blox
        {
           width: 200px; 
           padding: 10px 0; 
           display: inline-block; 
           font-size: 2em; 
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
        .tiffany
        {
            background: #5e8c83;
            color: #fefefe;
        }
        a.tiffany:hover
        {
            background: #80bfb3;
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
        <h1 style="text-transform:uppercase;font-size:3rem;border-bottom:#222 solid 5px;padding-bottom:20px;line-height:1em;margin-bottom:20px;">20% Off All White Wines</h1>
        <asp:Literal runat="server" ID="litIntro" />
    </div>
        
    <div style="border-bottom: solid 1px #ccc; text-align: center; padding: 30px 0;margin-bottom:20px;">
        <div>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&color=White&ref=clp" class="header-blox orange">All White Wines</a>        
        </div>
        <div style="width:49%;display:inline-block;">
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&style=1&color=White&ref=clp" class="second-blox orange">Still Whites</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=1&style=1&color=White&ref=clp" class="second-blox orange">Under $10</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=2&style=1&color=White&ref=clp" class="second-blox orange">$10-$20</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=3&style=1&color=White&ref=clp" class="second-blox orange">$21-$50</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=4&style=1&color=White&ref=clp" class="second-blox orange">$51-$100</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=5&style=1&color=White&ref=clp" class="second-blox orange">Above $100</a>
        </div>
        <div style="width:49%;display:inline-block;">
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&style=2&sparkling=True&color=White&ref=clp" class="second-blox orange">Sparkling Whites</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=1&style=2&sparkling=True&color=White&ref=clp" class="second-blox orange">Under $10</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=2&style=2&sparkling=True&color=White&ref=clp" class="second-blox orange">$10-$20</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=3&style=2&sparkling=True&color=White&ref=clp" class="second-blox orange">$21-$50</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=4&style=2&sparkling=True&color=White&ref=clp" class="second-blox orange">$51-$100</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=5&style=2&sparkling=True&color=White&ref=clp" class="second-blox orange">Above $100</a>
        </div>
    </div>
    
    <div class="note"><asp:Literal runat="server" ID="litRestrictions" /></div>
</div>
</asp:PlaceHolder>


