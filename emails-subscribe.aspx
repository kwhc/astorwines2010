<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="emails-subscribe.aspx.vb" Inherits="Emails" title="Emails | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<img src="images/general/middleContentTop.gif" alt="" />
<div id="mainContentHeader">
    <h1>Emails</h1>
</div>
<div id="post-emails" class="customPage">  
    
    <div id="sign-up-form" class="clearfix">
        
        <div>
            <h3>You're Awesome!</h3>
            <p>Thank you for signing up for our emails. Be sure to check us out on:</p>
            <a href="http://www.twitter.com/astorwines" onclick="subscribeTracker._trackEvent('Subscribe-Twitter','Post Email Sign Up')"><img src="images/buttons/btn_post-twitter.png" /></a>
            <a href="http://www.facebook.com/astorwines" onclick="subscribeTracker._trackEvent('Subscribe-Facebook','Post Email Sign Up')"><img src="images/buttons/btn_post-facebook.png" /></a>
        </div>
        
    </div> <!-- #sign-up-form -->
    
    <div class="section orange">
        <span class="pre-head">View our upcoming</span>
        <h4><a href="TastingEvents.aspx">Free tastings</a></h4>
    </div>
    
    <div class="section purple">
        <span class="pre-head">Check out our monthly</span>
        <h4><a href="../TopTen.aspx">Top ten Under $10</a></h4>
    </div>
        
  </div>
</asp:Content>