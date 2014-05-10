<%@ Page Language="VB" MasterPageFile="~/search-only.master" AutoEventWireup="false" CodeFile="AstorErrorFileNotFound.aspx.vb" Inherits="AstorErrorFileNotFound" title="Astor Wines & Spirits - Error"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

<div id="errorPage">
    <div id="mainImageContainer">
        <img src="images/general/img_404-poem.jpg" alt="" />
    </div>
    
    <h1>"The 404"</h1>
    
     <div class="halfPageColumn">
        <h2>We're sorry!</h2>
        
        <p>The page you are looking for is not found or has been moved!</p>
       
        <p><a href="/Default.aspx">Go to our Homepage</a></p>
        
        <p>If it keeps happening please email us at online@astorwines.com and report the error.</p>
    </div>
    
    <div class="halfPageColumn" id="reasons">
        <h3>Reasons For This Error</h3>
        <ul>
            <li>The page has been moved</li>
            <li>The page has been deleted</li>
            <li>The URL you requested might have been entered incorrectly. Please check to be sure.</li>
        </ul>
    </div>    
    
    <br style="clear: both;" />
</div>

</asp:Content>

