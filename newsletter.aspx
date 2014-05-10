<%@ Page Language="VB" AutoEventWireup="false" CodeFile="newsletter.aspx.vb" Inherits="newsletter" MasterPageFile="~/as_master_1.master" Title="Monthly Newsletter | Astor Wines & Spirits"%>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ContentPlaceHolderID="middleContent" runat="server" ID="Content2">
    <img src="../images/general/middleContentTop.gif" />
    <div id="newsletter">
        <div class="newsletterContent">
            <img src="images/newsletter/newsletterOpen.jpg" />
            
            <!--
            <div id="newsletterLauncher">
                <a href="images/newsletter/1.jpg" rel="clearbox[gallery=Tasting Notes]" title="Having trouble reading? Go back and download the newsletter to your computer"><img src="images/newsletter/newsletterOpen.jpg" /></a>
                <a href="images/newsletter/2.jpg" rel="clearbox[gallery=Tasting Notes]" title="Having trouble reading? Go back and download the newsletter to your computer"></a>
                <a href="images/newsletter/3.jpg" rel="clearbox[gallery=Tasting Notes]" title="Having trouble reading? Go back and download the newsletter to your computer"></a>
                <a href="images/newsletter/4.jpg" rel="clearbox[gallery=Tasting Notes]" title="Having trouble reading? Go back and download the newsletter to your computer"></a>
                <a href="images/newsletter/5.jpg" rel="clearbox[gallery=Tasting Notes]" title="Having trouble reading? Go back and download the newsletter to your computer"></a>
                <a href="images/newsletter/6.jpg" rel="clearbox[gallery=Tasting Notes]" title="Having trouble reading? Go back and download the newsletter to your computer"></a>
            </div>
            -->
            
            <div id="newsletterCopyContainer">
                <p>
                As part of our green effort, we've decided to take advantage of the alleged popularity of this "internet" and offer you our monthly newsletter in digital format. Now you can read all our great content, browse our newest bottles, and shop sale items without killing a single tree.
                </p>
                <br />
                <p>
                 Printed copies will still be available in the store, but if you can't live without having our newsletter in your mailbox each month, call us at 212-763-7500 or email customer-service1@astorwines.com and ask to remain on the mailing list.
                </p>
            </div>
            
            <div id="newsletterDownloadContainer">
                
                <!--
                <div style="border: #dddddd solid 1px; padding: 5px; ">
                    <img src="images/newsletter/newsletterTout.gif" />
                </div>
                -->

                <a href="images/newsletters/newsletter.pdf" onclick="downloadTracker._trackEvent('Download-Newsletter','Newsletter Page')"><img src="images/newsletter/downloadNewsletter.gif" alt="Download our newsletter" /></a>
                
                
                <p>
                Having trouble viewing?</p>
                <a href="http://get.adobe.com/reader/"><img src="http://www.adobe.com/images/shared/download_buttons/get_adobe_reader.gif" alt="Get Adobe Reader" /></a>
                
            </div>
        </div>
     <br style="clear: both;" />   
    </div>

</asp:Content>