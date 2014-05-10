<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="ContactUs.aspx.vb" Inherits="ContactUs" title="Astor Wines & Spirits - Contact Us" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="contactUs" class="info-page">

        <span class="muted" style="letter-spacing:.05rem;text-transform:uppercase;">Information</span>
        <h1 style="margin-bottom:1rem;">Contact Us</h1>
        <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" />  

    <div style="padding:1rem 0rem;">
      <h2><i class="icon-inbox"></i> Email</h2>
      <p>
        Got a suggestion? Need to air a complaint? Want to shower us with praise?
        Send us an email and tell us your thoughts!
      </p>
        <p>
        <a href="mailto:Customer-Service1@Astorwines.com">Send Astor an Email Message</a></p>
      <p>
        <strong>NOTE:</strong> Orders cannot be placed via email. If you'd like to place an order with us, please
        order online or call us at the phone number below.
      </p>
    </div>
    <div style="padding:1rem 0rem;">  
      <h2><i class="icon-phone"></i> Phone & Fax</h2>
      <ul>
          <li>212-674-7500 Phone</li>
          <li>212-673-1210 Fax</li>
      </ul>
    </div>
    <div style="padding:1rem 0rem;">  
      <h2><i class="icon-envelope-alt"></i> Mail</h2>
      <p>
        Astor Wines & Spirits<br />
        De Vinne Press Building<br />
        399 Lafayette Street at East 4th Street<br />
        New York, NY 10003
      </p>
      </div>
      <div style="padding:1rem 0rem;">
      <h2><i class="icon-user"></i> Social Networks</h2>
      <ul>
          <li><i class="icon-twitter"></i> <a href="http://www.twitter.com/astorwines" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-Twitter','Contact Us Page'">Tweet us @astorwines</a></li>
          <li><i class="icon-facebook"></i> <a href="http://www.facebook.com/astorwines" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-Facebook','Contact Us Page'">Follow us on Facebook</a></li>
          <li><i class="icon-google-plus-sign"></i> <a href="https://plus.google.com/109176288418314344764/posts" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-GooglePlus','Contact Us Page'">Add us to your circles on Google+</a></li>
      </ul>
      
    </div>
  </div>
</asp:Content>