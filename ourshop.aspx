<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="ourshop.aspx.vb" Inherits="AstorLandmarkStore" title="Our Landmark Shop | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

    <div id="landmark-shop" class="info-page">        
        <span class="muted" style="letter-spacing:.05rem;text-transform:uppercase;">Information</span>
        <h1 style="margin-bottom:1rem;">Our Shop</h1>
        <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" />         
        <div class="shop-info row">
          <section>
              <h2>Our Landmark Location</h2>
              <p class="indent">
                Astor Wines &amp; Spirits has been a Greenwich Village fixture since 1946. When we decided to move to bigger
                digs recently, we thought it was only fitting that we’d end up in a New York City Landmark, the De Vinne
                Press Building. A charming and formidable structure, it has stood on the corner of Fourth and Lafayette
                Streets in Manhattan since 1885. Its façade has been carefully maintained, leaving its charming
                period-specific features intact. We aren’t just interested in preserving great wines; we want to keep the
                rich history of our neighborhood alive as well, so the building is a perfect home for our new space.
                Whether you’re a longtime Village denizen or just a passer-by, you’ll appreciate the 50% larger sales
                floor and incredible new amenities at our new location, which is just a two-minute walk south of our old 
                one.
              </p>
          </section>
        </div>
    <div class="landmarkStoreTab shop-info row">
        <h2 class="greenTitle">Our Green Effort</h2>
        <section>
        <h3>Co-Gen</h3>
          <p>
            After we built our Cool Room, saké chillers, and controlled environment for basement storage, we had more 
            wines and sakés on site in temperature-controlled areas than any other retailer. We’d also begun consuming
            an impressive amount of electricity, which didn’t sit so well with us. For a time it seemed that our
            commitment to proper wine storage was at odds with our green environmental policies. But then it occurred
            to us: why not just make and recycle our own electricity? Now, deep in our cellars, two natural 
            gas-powered Micro-Turbines (some of the cleanest-burning engines on earth) quietly keep our wines and
            sakés at the perfect temperature for you. Any heat the generators produce is recycled into even more 
            energy, so that nothing is wasted. We are proud to be the greenest wine shop in the world, proving that
            taking care of our wines doesn't have to mean forgetting about our planet.
          </p>
       </section>
       <section>   
          <h3>Organics</h3>
          <p>
            Organic, Biodynamic, and Natural winemakers are on a mission. It’s something that’s close to our hearts,
            so we're thrilled to see that they're only getting more popular. They strive to bring you wines that
            represent the purest possible expressions of grapes, vintage, and soil, and to do so with a minimal impact
            on the environment. Since this, in a nutshell, is our philosophy, these fanatical grape farmers are some
            of our favorites. As you know, we too tend to go a little overboard in ensuring the quality of our wines,
            so those deemed the most delicate by our buyers won't be found in the Organic section: they're kept safe
            and sound at a constant 57º in our Cool Room.
          </p>
        </section>     
    </div>
    <div class="landmarkStoreTab shop-info row clearfix">
      <h2>The Astor Difference</h2>
      
      <section>
        <h3>Saké</h3>
          <p>
            If you’ve got no more patience than the average New Yorker, you probably shouldn’t try making saké. In
            case you don’t believe us: the first step in the process is "rice polishing" (just as time-consuming as it  
            sounds). Luckily for you, we’ve got nearly 200 of the world’s finest artisanal sakés right here, resting
            comfortably in temperature-controlled units. In fact, we’re the only shop that preserves these delicate
            brews at 40 degrees at all times, both in our display chillers and in our cellars. We know you’re busy.
            But trust us: you’ll want to make a little time to explore our truly stellar selection.
          </p>
      </section>
      
      <section>
        <h3>Cool Room</h3>
          <p>
            We adore our wine buyers. They’re really good at what they do, and we’d like to keep them around. But we
            know (because they told us) that they would leave in a heartbeat if we ever ruined their delicious
            selections by storing them improperly. So whenever they decide that a wine is especially delicate, we take
            it straight to our Cool Room. Unlike other stores, at Astor this decision is based solely on the wine’s
            sensitivity to large swings in temperature – not its price. From inexpensive biodynamic wines to delicious
            bottles of Moscato d’Asti to 1982 Bordeaux, anything requiring gentler handling is stored at 57º in the
            Cool Room. Our buyers stay happy, and you end up with better-tasting wines.
          </p>
      </section>
      
      <section>
          <h3>Free Tastings</h3>
          <p>
            Curious about Bavarian plum wines? So are we, actually. And if we ever come across a great one, we’ll make
            sure you get a chance to try it at one of our free tastings. Each week, we pour some of our favorite wines,
            spirits and sakés so you can taste and learn in a casual, relaxed, and – did we mention free? – environment.
            If you happen to like a particular wine or saké that’s poured, purchase it the day of the tasting and we’ll
            take 15% off the price. Tastings are held most weekdays from 6 to 8 p.m. and Saturdays from 3 to 5 p.m.
            Sync up your busy schedule with ours by signing up for our weekly email alerts, or check out the calendar
            to find out what we’re pouring next.
          </p>
            <p><a href="TastingEvents.aspx">Check out what's pouring at Astor</a></p>
    </section>
    </div>
  </div>
</asp:Content>