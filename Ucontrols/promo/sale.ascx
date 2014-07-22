<%@ Control Language="VB" AutoEventWireup="false" CodeFile="sale.ascx.vb" Inherits="Ucontrols_promo_made_in_usa" %>
<div class="info-page" style="text-align:center;">
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
        .c-red-background
        {
            background: rgb(195,70,57);
            color: #fefefe;
        }
        .c-red-background:hover
        {
            background: rgb(232,88,77);
        }
        .banana-background{
            background-color: rgba(253,232,125,1);
            color:#333333;
        }
        .banana-background:hover{
            background-color: rgba(253,232,125,0.5);
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
        .c-stone{
            color:rgb(84,84,84);
        }
        .c-stone-background{
            background-color:rgb(84,84,84);
        }
        a.c-stone-background:hover{
            background-color:rgb(103,103,103);
        }
        a.block-link{
            background-color:#ffffff;
            display:block;
            text-decoration:none;
        }
        a.block-link:hover{
            background-color:#f5f5f5;
        }
    </style>
<asp:PlaceHolder runat="server" ID="phPromo">
    
    <div style="margin-bottom: 20px;"><asp:Image runat="server" ID="imgHero" /></div>
    <asp:Literal runat="server" ID="litTest" />
    <div style="border-bottom: solid 1px #ccc;">
        <h1 style="text-transform:uppercase;font-size:3rem;border-bottom:#222 solid 5px;padding-bottom:20px;line-height:1em;margin-bottom:20px;"><asp:Literal runat="server" ID="litHeadline" /></h1>
        <asp:Literal runat="server" ID="litIntro" />
    </div>
        
    <div style="border-bottom: solid 1px #ccc; text-align: center; padding: 30px 0;margin-bottom:20px;">
        <div>
            <asp:PlaceHolder runat="server" ID="phLinksLarge" />
            <!--
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&term=&cat=1&color=White&ref=clp" class="header-blox banana-background">All White Wines</a>        
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&term=&cat=1&color=White&ref=clp" class="header-blox banana-background">Still White Wines</a>        
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&term=&cat=1&color=White&ref=clp" class="header-blox banana-background">Sparkling White Wines</a>      
            -->              
        </div>
        <div style="width:48%;display:inline-block;vertical-align:top;">
        <!--
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=1&color=White&ref=clp" class="second-blox c-red-background">Under $10</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=2&color=White&ref=clp" class="second-blox c-red-background">$10-$20</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=3&color=White&ref=clp" class="second-blox c-red-background">$21-$50</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=4&color=White&ref=clp" class="second-blox c-red-background">$51-$100</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&pricerange=5&color=White&ref=clp" class="second-blox c-red-background">Above $100</a>
            -->
            <asp:PlaceHolder runat="server" ID="phPriceLinks" />
        </div>
        <div id="column2" runat="server" style="width:48%;display:inline-block;">
            <!-- 
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&grape=Chardonnay&country=USA&region=California&ref=clp" class="second-blox c-red-background">California Chardonnay</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&country=France&region=Burgundy&color=White&ref=clp" class="second-blox c-red-background">White Burgundys</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&country=France&region=Champagne&ref=clp" class="second-blox c-red-background">Champagne</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&country=France&grape=Riesling&ref=clp" class="second-blox c-red-background">Riesling</a>
            <a href="../WineSearchResult.aspx?p=1&searchtype=Contains&cat=1&grape=Prosecco+(Glera)&ref=clp" class="second-blox c-red-background">Prosecco</a> 
            -->
            <asp:PlaceHolder runat="server" ID="phCategoryLinks" />
        </div>
    </div>
    
    <div class="note"><asp:Literal runat="server" ID="litRestrictions" /></div>
</asp:PlaceHolder>
<asp:PlaceHolder runat="server" ID="phPromoEnded">
    <div style="text-transform:uppercase;font-weight:bold;font-size:2rem;padding-top:2rem;">This Sale Has Ended</div>
    <hr style="width:6rem;border-color:#f5f5f5;border-style:solid;border-width:2px;margin-top:2rem;margin-bottom:2rem;text-align:center;" align="center"/>
</asp:PlaceHolder>
</div>
<asp:PlaceHolder runat="server" ID="phOther">
    <div class="clearfix" style="width:100%;">
        <div style="width:50%;float:left;">
            <a href="/WinesOnSale.aspx" class="block-link">
                <div style="border:solid 1px #ededed;padding:2rem;text-align:center;">
                   <div style="font-weight:bold;font-size:1.4rem;margin-bottom:1rem;border:solid 3px #555555;padding-top:1rem;padding-bottom:1rem;wodth:100%;color:#555555;">Wines on Sale</div>
                   <hr style="width:6rem;border-color:#f5f5f5;border-style:solid;border-width:2px;margin-top:2rem;margin-bottom:1rem;text-align:center;" align="center"/>
                </div>
            </a>
        </div>
        <div style="width:50%;float:left;">
            <a href="/Top12.aspx" class="block-link">
                <div style="border:solid 1px #ededed;padding:2rem;text-align:center;">       
                    <%--<img src="../../images/icons/img_top12_300x300.png" alt="Top 12 Under $12" width="100" />--%>
                    <div style="font-weight:bold;font-size:1.4rem;margin-bottom:1rem;border:solid 3px #555555;padding-top:1rem;padding-bottom:1rem;wodth:100%;color:#555555;">Top 12 Under $12</div>
                    <hr style="width:6rem;border-color:#f5f5f5;border-style:solid;border-width:2px;margin-top:2rem;margin-bottom:1rem;text-align:center;" align="center"/>
                </div>
            </a>
        </div>
    </div>
    <div class="clearfix" style="width:100%;">
        <div style="width:50%;float:left;">
            <a href="/WinesOnSale.aspx" class="block-link">
                <div style="border:solid 1px #ededed;padding:2rem;text-align:center;">
                    <span class="icon-stack" style="display:inline-block;font-size:2.4rem;">
                      <i class="icon-circle icon-stack-base" style="color:#222222;"></i>
                      <i class="icon-tags icon-light" style="font-size:1.4rem;"></i>
                    </span>
                   <div style="font-weight:bold;font-size:1.4rem;margin-bottom:1rem;padding-top:1rem;padding-bottom:1rem;wodth:100%;color:#555555;">Wines on Sale</div>
                   <hr style="width:6rem;border-color:#f5f5f5;border-style:solid;border-width:2px;margin-top:2rem;margin-bottom:1rem;text-align:center;" align="center"/>
                </div>
            </a>
        </div>
        <div style="width:50%;float:left;">
            <a href="/Top12.aspx" class="block-link">
                <div style="border:solid 1px #ededed;padding:2rem;text-align:center;">       
                    <%--<span class="icon-stack" style="display:inline-block;font-size:2.4rem;">
                      <i class="icon-circle icon-stack-base" style="color:#555555;"></i>
                      <i class="icon-tag icon-light" style="font-size:1.4rem;"></i>
                    </span>--%>
                    <img src="../../images/icons/img_top12_300x300.png" alt="Top 12 Under $12" width="75" />
                    <div style="font-weight:bold;font-size:1.4rem;margin-bottom:1rem;padding-top:1rem;padding-bottom:1rem;wodth:100%;color:#555555;">Top 12 Under $12</div>
                    <hr style="width:6rem;border-color:#f5f5f5;border-style:solid;border-width:2px;margin-top:2rem;margin-bottom:1rem;text-align:center;" align="center"/>
                </div>
            </a>
        </div>
    </div>
</asp:PlaceHolder>


