<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="emails.aspx.vb" Inherits="Emails" title="Emails | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<div id="emails" class="info-page">  
    <h1>Emails</h1>
    
    <div id="sign-up-form" class="clearfix">
<%--        <div class="form-column">
            <label for="FirstName">First Name:</label><br /><input type="text" name="cm-f-uyuhf" id="FirstName" class="tan" /><br />
            <label for="LastName">Last Name:</label><br /><input type="text" name="cm-f-uyuha" id="LastName" class="tan" /><br />
            <label for="xkthkl-xkthkl">Email:</label><br /><input type="text" name="cm-xkthkl-xkthkl" id="xkthkl-xkthkl" class="tan" /><br />
            <label for="Zipcode">Zip Code:</label><br /><input type="text" name="cm-f-uyuhz" id="Zipcode" class="tan" /><br />
            <label for="Interests">Interests:</label><br /><input type="checkbox" name="cm-fo-ujurm" id="cm1101056" value="1101056" /> <label for="cm1101056">Learning About Wine & Spirits</label><br />
            <input type="checkbox" name="cm-fo-ujurm" id="cm1101057" value="1101057" /> <label for="cm1101057">Wine & Food Pairings and Recipes</label><br />
            <input type="checkbox" name="cm-fo-ujurm" id="cm1101058" value="1101058" /> <label for="cm1101058">Cocktails & Mixology</label><br />
            <input type="checkbox" name="cm-fo-ujurm" id="cm1101059" value="1101059" /> <label for="cm1101059">In-Store Offers and Events</label><br />
            <asp:Button runat="server" ID="emailSignup" Text="Sign Me Up!" PostBackUrl="http://astorwines.createsend.com/t/r/s/xkthkl/" CssClass="btn" />
        </div> <!-- .form-column -->
--%>        

        <div class="form-column">
            <div>
                <label for="name">Name:</label><br /><input type="text" name="cm-name" id="name" class="tan" /><br />
                <label for="yktytuj-yktytuj">Email:</label><br /><input type="text" name="cm-yktytuj-yktytuj" id="yktytuj-yktytuj" class="tan" /><br />
                <label for="Zip Code">Zip Code:</label><br /><input type="text" name="cm-f-vlrjir" id="ZipCode" class="tan" /><br />

                <input type="submit" value="Subscribe" class="btn" onclick="_gaq.push(['_trackEvent', 'Subscribe', 'Email', 'Form']);" />
            </div>
        </div>
        
        <div class="form-column">
            <h3>3 Reasons to Sign Up</h3>
            <h4>1.</h4>
            <p>
            You’ll be the first to learn about sales, free tastings, and upcoming special events at Astor. Plus, subscribers automatically qualify for incredible email-exclusive discounts.
            </p>
            <h4>2.</h4>
            <p>
            We’ll notify you when great new items come in, and you’ll get access to our expert food-pairing advice and recipes.
            </p>
            <h4>3.</h4>
            <p>
            You can opt out at any time. Just click “unsubscribe” at the bottom of our emails and we’ll take you off the list.
            </p>
        </div> <!-- .form-column -->
        
    </div> <!-- #sign-up-form -->
        
    <ul>    
    <li class="img-copy-row clearfix hide">
        <div class="imgContainer" style="float: left;">
            <img src="images/pageEmails/12days.jpg" alt="" />
        </div>
        <div class="copyContainer gutter">
            <h2>12 DAYS OF ASTOR</h2>
            <span class="noteSerif">Special Holiday Campaign</span>
            <p>
            12 great gift ideas and 12 phenomenal holiday deals, each lasting just 24 hours! The only way to find out about the deals is to get on the list, so make sure you don’t miss anything... 
           </p>
      </div>
    </li>

    <asp:Panel runat="server" CssClass="img-copy-row clearfix">
    <li class="img-copy-row">
          <div class="imgContainer">
            <img src="images/pageEmails/img_email_preview_dog_days.jpg" alt="" />
          </div>
          <div class="copyContainer gutter">
            <header>
                <h2>Dog Days of Astor</h2>
                <span class="noteSerif">Limited Run- Summer</span>
            </header>
            <p>
            For email subscribers only: One month, eight incredible 24-hour deals! The Dog Days of Astor is our summer sale series: huge price reductions on a litter of amazing wines & spirits. Every bottle gets a special unprecedented markdown for 24 hours – because every dog has his day! The only way to find out what’s on sale: Sign Up! 
           </p>
          </div>
    </li>
    </asp:Panel>
    
    <li class="img-copy-row clearfix">
      <div class="imgContainer">
        <img src="images/pageEmails/tuesdays.jpg" alt="" />
      </div>
      <div class="copyContainer gutter">
        <header>
            <h2>15% Off Tuesdays</h2>
            <span class="noteSerif">Sent Tuesdays</span>
        </header>
        <p>
        Every Tuesday we put an entire section of the store on sale – Bordeaux, the Rhône, Austria, you name it. Each email gives you a brief overview of the region on sale, along with our Top 11 wine picks of the week (that’s right: our lists go up to 11).
       </p>
      </div>
    </li>

    <li class="img-copy-row clearfix">
      <div class="imgContainer">
        <img src="images/pageEmails/freeTastings.jpg" alt="" />
      </div>
      <div class="copyContainer gutter">
        <header>
            <h2>Free Tastings</h2>
            <span class="noteSerif">Sent Thursdays</span>
        </header>
        <p>
        Find out what’s pouring at Astor Wines & Spirits! Our in-store tastings are a great way to learn and mingle – or just taste our favorites for free. At least four days a week (usually more), we pour wines, spirits, sakés, cocktails... and if there’s anything else that’s tasty and fits in a glass, you’ll probably see it soon at our Tasting Bar. 
       </p>
      </div>
    </li>
    
    <li class="img-copy-row clearfix">
      <div class="imgContainer">
        <img src="images/pageEmails/quickPicks.jpg" alt="" />
      </div>
      <div class="copyContainer gutter">
        <header>
            <h2>Quick Picks</h2>
            <span class="noteSerif">Sent Saturdays</span>
        </header>
        <p>
        When we’ve got a new item, or a bottle we’re especially excited about, or something you haven’t tried yet but we’re sure you’ll like, we’ll tell you all about it in this Saturday email series.
       </p>
      </div>
    </li>    
    </ul>

  </div>
</asp:Content>