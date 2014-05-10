<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCAstorCenter.ascx.vb" Inherits="Ucontrols_WUCAstorCenter" %>

<h3>Events at<br/>Astor Center</h3>
<div id="astorCenterEvents" style="text-align: center;">
    <br />
  <div>
    <asp:Repeater ID="classes" runat="server">
      <HeaderTemplate>
        <ul>
      </HeaderTemplate>
      <ItemTemplate>
        <div id="astorCenterEvent">
            <div id="astorCenterEventsImageContainer">
                <asp:Image ID="imgClassPic" runat="server" Width="65px" />
            </div>
            <div id="astorCenterEventsLinkContainer">
                <a href="<%#makelink(Container.DataItem("sSubjectTitle"))%>" target="_blank" onclick="exitTracker._trackEvent('Event','Right Column Tout')" ><%#htmlEncode(Container.DataItem("sSubjectTitle"))%></a>
                <br />
                <span class="astorCenterEventsDate"><asp:Literal ID="litDate" runat="server" /></span>
            </div>
            
            <div style="clear: both; height: 20px;">&nbsp;</div>
       </div>
      </ItemTemplate>
      <FooterTemplate>
        </ul>
      </FooterTemplate>
    </asp:Repeater>

    <asp:Panel runat="server" ID="pnlCustom">
        <div class="astorCenterEvent">   
          <div class="astorCenterEventsImageContainer">
            <img src="http://www.astorcenternyc.com/images/classes/thumbs/10798.jpg" alt="The Ninth Annual Natural Wine Event" />
          </div>
          <div class="astorCenterEventsLinkContainer">
            <a href="http://www.astorcenternyc.com/class-.aspx?class=the-ninth-annual-natural-wine-event&utm_source=astorwines.com&utm_medium=referral&utm_campaign=treatment&utm_content=sidebarevents">The Ninth Annual Natural Wine Event</a>
          </div>  
        </div> 

        <div class="astorCenterEvent">   
          <div class="astorCenterEventsImageContainer">
            <img src="http://www.astorcenternyc.com/images/classes/thumbs/10800.jpg" alt="The Ninth Annual Natural Winemaker Event VIP: Tasting with Montebruno" />
          </div>
          <div class="astorCenterEventsLinkContainer">
            <a href="http://www.astorcenternyc.com/class-.aspx?class=the-ninth-annual-natural-winemaker-event-vip-tasting-with-montebruno&utm_source=astorwines.com&utm_medium=referral&utm_campaign=treatment&utm_content=sidebarevents">The Ninth Annual Natural Winemaker Event VIP: Tasting with Montebruno</a>
          </div>  
        </div> 

        <div class="astorCenterEvent">   
          <div class="astorCenterEventsImageContainer">
            <img src="http://www.astorcenternyc.com/images/classes/thumbs/10797.jpg" alt="The Ninth Annual Natural Winemaker Event VIP: Tasting with Astor President Andy Fisher" />
          </div>
          <div class="astorCenterEventsLinkContainer">
            <a href="http://www.astorcenternyc.com/class-.aspx?class=the-ninth-annual-natural-winemaker-event-vip-tasting-with-astor-president-andy-fisher&utm_source=astorwines.com&utm_medium=referral&utm_campaign=treatment&utm_content=sidebarevents">The Ninth Annual Natural Winemaker Event VIP: Tasting with Astor President Andy Fisher</a>
          </div>  
        </div> 

        <div class="astorCenterEvent">   
          <div class="astorCenterEventsImageContainer">
            <img src="http://www.astorcenternyc.com/images/classes/thumbs/10801.jpg" alt="The Ninth Annual Natural Winemaker Event VIP: Tasting with Bosco Falconeria
    " />
          </div>
          <div class="astorCenterEventsLinkContainer">
            <a href="http://www.astorcenternyc.com/class-.aspx?class=the-ninth-annual-natural-winemaker-event-vip-tasting-with-bosco-falconeria&utm_source=astorwines.com&utm_medium=referral&utm_campaign=treatment&utm_content=sidebarevents">The Ninth Annual Natural Winemaker Event VIP: Tasting with Bosco Falconeria
    </a>
          </div>  
        </div> 
    </asp:Panel>
   
  </div>
  <div>
    <a href="http://www.astorcenternyc.com" target="_blank" onclick="exitTracker._trackEvent('General Info','Right Column Tout')" class="muted">Visit the Astor Center site <i class="icon-external-link"></i></a>
  </div>
</div>