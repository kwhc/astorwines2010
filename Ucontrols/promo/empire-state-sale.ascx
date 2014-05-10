<%@ Control Language="VB" AutoEventWireup="false" CodeFile="empire-state-sale.ascx.vb" Inherits="Ucontrols_promo_made_in_usa" %>
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
            font-size: 1.2rem;
            line-height: 1em;
            text-align: center !important;
            color: #666;
        }
    </style>
<div style="text-align:center;">
    <div style="margin-bottom: 20px;"><asp:Image runat="server" ID="imgHero" /></div>
    <div style="border-bottom: solid 1px #ccc;">
        <h1 style="text-transform:uppercase;font-size:3rem;border-bottom:#222 solid 5px;padding-bottom:20px;line-height:1em;margin-bottom:20px;">All New York<br/>wines and spirits<br/>are<br/>15% off!</h1>
        <asp:Literal runat="server" ID="litIntro" />
    </div>
        
    <div style="border-bottom: solid 1px #ccc; text-align: center; padding: 30px 0;margin-bottom:20px;">
        <div>
            <a class="header-blox tiffany" href="../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&cat=1&country=USA&region=New+York&ref=clp">New York Wines</a>
        </div>
        <div>
            <a href="../SpiritsSearchResult.aspx?p=2&search=Advanced&searchtype=Contains&cat=2&country=USA&region=New+York&ref=clp" class="header-blox tiffany">New York Spirits</a>
        </div>
    </div>
    
    <div class="note"><asp:Literal runat="server" ID="litRestrictions" /></div>
</div>
</asp:PlaceHolder>