<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorLandmarkStore.aspx.vb" Inherits="AstorLandmarkStore" title="Astor Wines & Spirits - Landmark Store" %>

<%@ Register Src="Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc2" %>
<%@ Register Src="Ucontrols/WUCTouts1.ascx" TagName="WUCTouts1" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCEmailSignUp.ascx" TagName="WUCEmailSignUp" TagPrefix="uc4" %>
<%@ Register Src="~/Ucontrols/WUCEmailSignUpNew.ascx" TagName="WUCEmailSignUpNew" TagPrefix="uc8" %>
<%@ Register Src="~/Ucontrols/WUCAstorCenter.ascx" TagName="WUCAstorCenter" TagPrefix="uc10" %>
<%@ Register Src="~/Ucontrols/WUCExpandableSearch.ascx" TagName="WUCSearchNew" TagPrefix="uc11" %>
<%@ Register Src="~/Ucontrols/WUCLastItems.ascx" TagName="WUCLastItems" TagPrefix="uc12" %>
<%@ Register Src="~/Ucontrols/WUCSuggest.ascx" TagName="WUCSuggest" TagPrefix="uc13" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
<h1 class="mainHeader" style="width: 600px;">Our Landmark Store</h1>
  <div id="landmarkStore">
    <div class="pictureFrame" style="float: right;"><img src="images/store/store.jpg" alt="our landmark store" style="width: 250px;" /> </div>
    <div class="landmarkStoreDirection">
      <span>Astor Wines &amp; Spirits</span><br />
      De Vinne Press Building<br />
      399 Lafayette (at East 4th St.)<br />
      New York, NY 10003<br />
      <br />
      Phone: 212-674-7500<br />
      Fax: 212-673-1210<br />
      <a href="mailto:customer-service1@astorwines.com">Email Us</a>
    </div>
    <div class="landmarkStoreHours">
      <span>Store Hours</span><br />
      Monday - Saturday<br />
      9:00am - 9:00pm<br />
      <br />
      Sunday<br />
      12:00pm - 6:00pm
    </div>

    <div style="clear: left; height: 15px;"></div>
    <div>
      <h2>The De Vinne Press Building</h2>
      <div class="pictureFrame" style="float: left;"><img src="images/store/building.jpg" alt="" width="200px" /></div>
      <p class="indent">
        Astor Wines & Spirits has been a Greenwich Village fixture since 1946. When we decided to move to bigger
        digs recently, we thought it was only fitting that we’d end up in a New York City Landmark, the De Vinne
        Press Building. A charming and formidable structure, it has stood on the corner of Fourth and Lafayette
        Streets in Manhattan since 1885. Its façade has been carefully maintained, leaving its charming
        period-specific features intact. We aren’t just interested in preserving great wines; we want to keep the
        rich history of our neighborhood alive as well, so the building is a perfect home for our new space.
        Whether you’re a longtime Village denizen or just a passer-by, you’ll appreciate the 50% larger sales
        floor and incredible new amenities at our new location, which is just a two-minute walk south of our old 
        one.
      </p>
    </div>
    <div class="landmarkStoreTab">
      <h2 class="greenTitle">Our Green Effort</h2>
      <div class="landmarkStoreSubTitle">Co-Gen</div>
      <div class="pictureFrame" style="float: right;"><img src="images/store/cogen.jpg" alt="" width="200px" /></div>
      <p>
        After we built our Cool Room, saké chillers, and controlled environment for basement storage, we had more 
        wines and sakés on site in temperature-controlled areas than any other retailer. We’d also begun consuming
        an impressive amount of electricity, which didn’t sit so well with us. For a time it seemed that our
        commitment to proper wine storage was at odds with our green environmental policies. But then it occurred
        to us: why not just make and recycle our own electricity? Now, deep in our cellars, two natural 
        gas-powered Micro-Turbines (some of the cleanest-burning engines on earth) quietly keep our wines and
        sakés at the perfect temperature for you. Any heat the generators produce is recycled into even more 
        energy, so that nothing is wasted. We are proud to be the greenest wine store in the world, proving that
        taking care of our wines doesn't have to mean forgetting about our planet.
      </p><br />
      <span class="landmarkStoreSubTitle">Organics</span>
      <div class="pictureFrame" style="float: right;"><img src="images/store/organics.jpg" alt="" width="200px" /></div>
      <p>
        Organic, Biodynamic, and Natural winemakers are on a mission. It’s something that’s close to our hearts,
        so we're thrilled to see that they're only getting more popular. They strive to bring you wines that
        represent the purest possible expressions of grapes, vintage, and soil, and to do so with a minimal impact
        on the environment. Since this, in a nutshell, is our philosophy, these fanatical grape farmers are some
        of our favorites. As you know, we too tend to go a little overboard in ensuring the quality of our wines,
        so those deemed the most delicate by our buyers won't be found in the Organic section: they're kept safe
        and sound at a constant 57º in our Cool Room.
      </p>
      <%--<div style="float: right; font-size: 12px;  margin-right: 5px;"><a href="">See our organic wines</a></div>--%>
      <div style="clear: right; height: 10px;"></div>
    </div>
    <div class="landmarkStoreTab">
      <h2>The Astor Difference</h2>
      <div class="landmarkStoreSubTitle">Saké</div>
      <div class="pictureFrame" style="float: right;"><img src="images/store/sake.jpg" alt="" width="200px" /></div>
      <p>
        If you’ve got no more patience than the average New Yorker, you probably shouldn’t try making saké. In
        case you don’t believe us: the first step in the process is "rice polishing" (just as time-consuming as it
        sounds). Luckily for you, we’ve got nearly 200 of the world’s finest artisanal sakés right here, resting
        comfortably in temperature-controlled units. In fact, we’re the only store that preserves these delicate
        brews at 40 degrees at all times, both in our display chillers and in our cellars. We know you’re busy.
        But trust us: you’ll want to make a little time to explore our truly stellar selection.
      </p>
<%--      <div style="float: right; font-size: 12px;  margin-right: 5px;"><a href="">See our Saké Selection</a></div>--%>
      <div style="clear: right; height: 10px;"></div>
      <div class="landmarkStoreSubTitle">Cool Room</div>
      <div class="pictureFrame" style="float: right;"><img src="images/store/coolroom.jpg" alt="" width="200px" /></div>
      <p>
        We adore our wine buyers. They’re really good at what they do, and we’d like to keep them around. But we
        know (because they told us) that they would leave in a heartbeat if we ever ruined their delicious
        selections by storing them improperly. So whenever they decide that a wine is especially delicate, we take
        it straight to our Cool Room. Unlike other stores, at Astor this decision is based solely on the wine’s
        sensitivity to large swings in temperature – not its price. From inexpensive biodynamic wines to delicious
        bottles of Moscato d’Asti to 1982 Bordeaux, anything requiring gentler handling is stored at 57º in the
        Cool Room. Our buyers stay happy, and you end up with better-tasting wines.
      </p>
      <div class="landmarkStoreSubTitle">Free Tastings</div>
      <div class="pictureFrame" style="float: right;"><img src="images/store/tasting.jpg" alt="" width="200px" /></div>
      <p>
        Curious about Bavarian plum wines? So are we, actually. And if we ever come across a great one, we’ll make
        sure you get a chance to try it at one of our free tastings. Each week, we pour some of our favorite wines,
        spirits and sakés so you can taste and learn in a casual, relaxed, and – did we mention free? – environment.
        If you happen to like a particular wine or saké that’s poured, purchase it the day of the tasting and we’ll
        take 15% off the price. Tastings are held most weekdays from 6 to 8 p.m. and Saturdays from 3 to 5 p.m.
        Sync up your busy schedule with ours by signing up for our weekly email alerts, or check out the calendar
        to find out what we’re pouring next.
      </p>
      <div style="float: right; font-size: 12px;  margin-right: 5px;"><a href="TastingEvents.aspx">Check out what's pouring at Astor</a></div>
      <div style="clear: right; height: 10px;"></div>
    </div>
  </div>
</asp:Content>