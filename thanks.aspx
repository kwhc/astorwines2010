<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="thanks.aspx.vb" Inherits="Emails" title="Thanks For Signing Up! | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<div id="post-emails" class="customPage">  

    <h1></h1>
    
    <div id="sign-up-form" class="clearfix">
        
        <div>
            <h3>You're Awesome!</h3>
            <p>Thank you for signing up for our emails. Be sure to check us out on:</p>
            <a href="http://www.twitter.com/astorwines" onclick="subscribeTracker._trackEvent('Subscribe-Twitter','Post Email Sign Up')"><img src="images/buttons/btn_post-twitter.png" /></a>
            <a href="http://www.facebook.com/astorwines" onclick="subscribeTracker._trackEvent('Subscribe-Facebook','Post Email Sign Up')"><img src="images/buttons/btn_post-facebook.png" /></a>
        </div>
        
    </div> <!-- #sign-up-form -->
    
    <a href="TastingEvents.aspx">
    <div class="section orange">
        <span class="pre-head">View our upcoming</span>
        <h4>Free tastings</h4>
    </div>
    <a>
    
    <a href="../Top12.aspx">
        <div class="section purple">
            <span class="pre-head">Check out our monthly</span>
            <h4>Top Twelve Under $12</h4>
        </div>
    </a>
        
  </div>
</asp:Content>