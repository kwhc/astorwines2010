<%@ Control Language="VB" AutoEventWireup="false" CodeFile="red-sale.ascx.vb" Inherits="Ucontrols_promo_made_in_usa" %>
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
        .red
        {
            background: #8c3535;
            color: #fefefe;
        }
        .red:hover
        {
            background: #612424;
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
        <h1 style="text-transform:uppercase;font-size:3rem;border-bottom:#222 solid 5px;padding-bottom:20px;line-height:1em;margin-bottom:20px;">20% Off* All Red Wines</h1>
        <asp:Literal runat="server" ID="litIntro" />
    </div>
        
    <div style="border-bottom: solid 1px #ccc; text-align: center; padding: 30px 0;margin-bottom:20px;">
        <div>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&color=Red&ref=clp" class="header-blox red">All Red Wines</a>        
        </div>
        <div style="width:100%;display:inline-block;">
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&style=1&color=Red&ref=clp" class="header-blox red">Still Reds</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&style=2&sparkling=True&color=Red&ref=clp" class="header-blox red">Sparkling Reds</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=1&style=1&color=Red&ref=clp" class="header-blox red">Under $10</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=2&style=1&color=Red&ref=clp" class="header-blox red">$10-$20</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=3&style=1&color=Red&ref=clp" class="header-blox red">$21-$50</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=4&style=1&color=Red&ref=clp" class="header-blox red">$51-$100</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&pricerange=5&style=1&color=Red&ref=clp" class="header-blox red">Above $100</a>
        </div>
        <div style="width:45%;display:inline-block;">
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=USA&color=Red&ref=clp" class="second-blox red">USA</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Argentina&color=Red&ref=clp" class="second-blox red">Argentina</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Austria&color=Red&ref=clp" class="second-blox red">Austria</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Chile&color=Red&ref=clp" class="second-blox red">Chile</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=France&color=Red&ref=clp" class="second-blox red">France</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Greece&color=Red&ref=clp" class="second-blox red">Greece</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Italy&color=Red&ref=clp" class="second-blox red">Italy</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Portugal&color=Red&ref=clp" class="second-blox red">Portugal</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=Spain&color=Red&ref=clp" class="second-blox red">Spain</a>
        </div>
        <div style="width:45%;display:inline-block;vertical-align:top;">
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Cabernet+Sauvignon&color=Red&ref=clp" class="second-blox red">Cabernet Sauvignon</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Merlot&color=Red&ref=clp" class="second-blox red">Merlot</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Nebbiolo&color=Red&ref=clp" class="second-blox red">Nebbiolo</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Pinot+Noir&color=Red&ref=clp" class="second-blox red">Pinot Noir</a>
            <a href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Syrah&color=Red&ref=clp" class="second-blox red">Syrah</a>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Tempranillo&color=Red&ref=clp" CssClass="second-blox red" Text="Tempranillo" />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Grenache&color=Red&ref=clp" CssClass="second-blox red" Text="Grenache" />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Cabernet+Franc&color=Red&ref=clp" CssClass="second-blox red" Text="Cabernet Franc" />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Malbec&color=Red&ref=clp" CssClass="second-blox red" Text="Malbec" />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&grape=Zinfandel&color=Red&ref=clp" CssClass="second-blox red" Text="Zinfandel" />
        </div>
    </div>
    
    <div class="note"><asp:Literal runat="server" ID="litRestrictions" /></div>
</div>
</asp:PlaceHolder>


