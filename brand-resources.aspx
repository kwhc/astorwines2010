<%@ Page Language="VB" AutoEventWireup="false" CodeFile="brand-resources.aspx.vb" Inherits="brand_resources" MasterPageFile="~/noColumns.master" %>

<asp:Content runat="server" ContentPlaceHolderID="middleContent">
<div class="no-column-page">
    <h1><asp:Literal runat="server" ID="litPageTitle" /></h1>
    <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" /> 
    <div class="row clearfix">
        <div class="logo-option">
            <img src="images/resources/aws-logo-light-bkgr.jpg" alt="Astor Wines & Spirits logo for light backgrounds" />
            <strong>For Light Backgrounds</strong>
            <ul class="inline">
                <li><a href="images/resources/aws_nyc_light_bkgr.eps">EPS</a></li>
                <li><a href="images/resources/aws_nyc_light_bkgr.png">PNG</a></li>
            </ul>
        </div>
        
        <div class="logo-option">
            <img src="images/resources/aws-logo-dark-bkgr.jpg" alt="Astor Wines & Spirits logo for dark backgrounds" />
            <strong>For Dark Backgrounds</strong>
            <ul class="inline">
                <li><a href="images/resources/aws_nyc_dark_bkgr.eps">EPS</a></li>
                <li><a href="images/resources/aws_nyc_dark_bkgr.png">PNG</a></li>
            </ul>
        </div>
            
        <div class="logo-option">
            <img src="images/resources/aws-logo-burg-on-white.jpg" alt="Astor Wines & Spirits logo burgundy on white" />
            <strong>Burgundy on white</strong>
            <ul class="inline">
                <li><a href="images/resources/aws_nyc_burg_on_white.eps">EPS</a></li>
                <li><a href="images/resources/aws_nyc_burg_on_white.png">PNG</a></li>
            </ul>
        </div>
        
        <div class="logo-option">
            <img src="images/resources/aws-logo-white-on-burg.jpg" alt="Astor Wines & Spirits logo white on burgundy" />
            <strong>White on burgundy</strong>
            <ul class="inline" >
                <li><a href="images/resources/aws_nyc_white_on_burg.eps">EPS</a></li>
                <li><a href="images/resources/aws_nyc_white_on_burg.png">PNG</a></li>
            </ul>
        </div>
    </div>
    
    <div class="row">
        <h4>PNG</h4>
        <ul>
            <li>For use in web applications</li>
        </ul>
        
        <h4>EPS</h4>
        <ul>
            <li>For use in print applications</li>
            <li>Vector Format</li>
            <li>Use with Adobe Illustrator, Adobe Photoshop</li>
        </ul>
            
    </div>
    
    <div class="row">
        <p>If you are looking for another format. <a href="mailto:online@astorwines.com">Please email us.</a></p>    
    </div>

</div>
</asp:Content>