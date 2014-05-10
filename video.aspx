<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="video.aspx.vb" Inherits="video" title="Video Gallery | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<img src="images/general/middleContentTop.gif" alt="" />
<div id="mainContentHeader">
    <h1>Video Gallery</h1>
</div>

<div id="videoGallery">  
    
    <div class="videoHolder">
      <div style="text-align: center; border: 1px #eeeeee solid; padding-top: 15px;">
        <embed src="http://blip.tv/play/hfsVgeuMJQA" type="application/x-shockwave-flash" width="530" height="328" allowscriptaccess="always" allowfullscreen="true"></embed>
      </div>
      <div class="videoCopy">
        <h2><a href="/SearchResultsSingle.aspx?p=1&search=20820&searchtype=Contains">Radog Pinot Noir - 2007</a></h2>
        <span class="noteSerif">Item # 20820</span>
        <p>
        This brambly Pinot from Monterey is full of dark fruit and black currants with a light mouthfeel and balanced toasty notes from barrel ageing. It’s soft enough to drink alone, yet it can hold its own with food as well. 
       </p>
       
      </div>
      <br style="clear:both;" />
    </div>
    
    <div class="emailHolder">
      <div class="pictureFrame" style="float: left;"><img src="images/pageEmails/tuesdays.jpg" alt="" width="200px" /></div>
      <div class="emailCopy">
        <h2>15% Off Tuesdays</h2>
        <span class="noteSerif">Sent Tuesdays</span>
        <p>
            Every Tuesday we put an entire section of the store on sale – Bordeaux, the Rhône, Austria, you name it. Each email gives you a brief overview of the region on sale, along with our Top 11 wine picks of the week (that’s right: our lists go up to 11).
       </p>
       <a href="http://visitor.constantcontact.com/d.jsp?m=1101613886315&p=oi" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-Email','email page')" class="noteSerif">sign up&#187; </a>
      </div>
      <br style="clear:both;" />
    </div>

    <div class="emailHolder">
      <div class="pictureFrame" style="float: left;"><img src="images/pageEmails/freeTastings.jpg" alt="" width="200px" /></div>
      <div class="emailCopy">
        <h2>Free Tastings</h2>
        <span class="noteSerif">Sent Thursdays</span>
        <p>
        Find out what’s pouring at Astor Wines & Spirits! Our in-store tastings are a great way to learn and mingle – or just taste our favorites for free. At least four days a week (usually more), we pour wines, spirits, sakés, cocktails... and if there’s anything else that’s tasty and fits in a glass, you’ll probably see it soon at our Tasting Bar. 
       </p>
       <a href="http://visitor.constantcontact.com/d.jsp?m=1101613886315&p=oi" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-Email','email page')" class="noteSerif"> sign up&#187; </a>
      </div>
      <br style="clear:both;" />
    </div>
    
    <div class="emailHolder">
      <div class="pictureFrame" style="float: left;"><img src="images/pageEmails/quickPicks.jpg" alt="" width="200px" /></div>
      <div class="emailCopy">
        <h2>Quick Picks</h2>
        <span class="noteSerif">Sent Saturdays</span>
        <p>
        When we’ve got a new item, or a bottle we’re especially excited about, or something you haven’t tried yet but we’re sure you’ll like, we’ll tell you all about it in this Saturday email series.
       </p>
       <a href="http://visitor.constantcontact.com/d.jsp?m=1101613886315&p=oi" target="_blank" onclick="subscribeTracker._trackEvent('Subscribe-Email','email page')" class="noteSerif">sign up&#187;</a>
      </div>
      <br style="clear:both;" />
      <a href="july4.htm" rel="clearbox[width=540,,height=360]">TRY THIS!</a>
    </div>    

  </div>
</asp:Content>