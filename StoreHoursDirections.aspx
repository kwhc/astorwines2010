<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="StoreHoursDirections.aspx.vb" Inherits="StoreHoursDirections" title="Astor Wines & Spirits - Store Hours & Directions" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/shopHours.ascx" TagName="shopHours" TagPrefix="awSh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="shopHours" class="info-page mainContent">

    <h1>Shop Hours &amp; Directions</h1>
        <ul>
        <asp:PlaceHolder runat="server" ID="pnlHolidayHours">
    
            <li id="shop-holiday-hours" class="img-copy-row shop-info clearfix">
                <div class="imgContainer">
                    <img src="images/icons/ic_snowflake.gif" alt="Our Holiday Hours" />        
               </div> 
                <div class="copyContainer">
                    <h2>Our <asp:Literal runat="server" ID="litYearHeader" /> Extended Holiday Hours</h2>
                    <table>
                        <tr>
                            <td>Thursday, December 19</td>
                            <td> 9AM - 10PM</td>
                        </tr>
                        <tr>
                            <td>Friday, December 20</td>
                            <td> 9AM - 10PM</td>
                        </tr>
                        <tr>
                            <td>Saturday, December 21</td>
                            <td> 9AM - 10PM</td>
                        </tr>
                        <tr>
                            <td>Sunday, December 22</td>
                            <td>12PM - 7PM</td>
                        </tr>
                        <tr>
                            <td>Monday, December 23</td>
                            <td> 9AM - 10PM</td>
                        </tr>
                        <tr>
                            <td>Tuesday, December 24<br />(Christmas Eve)</td>
                            <td> 9AM - 7PM</td>
                        </tr>
                        <tr>
                            <td>Wednesday, December 25<br />(Christmas Day)</td>
                            <td>Closed</td>
                        </tr>
                        <tr>
                            <td>Thursday, December 26</td>
                            <td> 9AM - 9PM</td>
                        </tr>
                        <tr>
                            <td>Friday, December 27</td>
                            <td> 9AM - 9PM</td>
                        </tr>
                        <tr>
                            <td>Saturday, December 28</td>
                            <td> 9AM - 9PM</td>
                        </tr>
                        <tr>
                            <td>Sunday, December 29</td>
                            <td>12PM - 7PM</td>
                        </tr>
                        <tr>
                            <td>Monday, December 30</td>
                            <td> 9AM - 10PM</td>
                        </tr>
                        <tr>
                            <td>Tuesday, December 31<br />(New Years Eve)</td>
                            <td> 9AM - 8PM</td>
                        </tr>
                        <tr>
                            <td>Wednesday, January 1<br />(New Years Day)</td>
                            <td>Closed</td>
                        </tr>
                    </table>
                </div>      
            </li>
    
        </asp:PlaceHolder>
           
        <li id="shop-hours" class="img-copy-row shop-info clearfix">
            <div class="imgContainer">
                <img src="images/icons/ic_open.gif" alt="Our Shop's Hours" />
            </div>
            <div class="copyContainer">
                <awSh:shopHours runat="server" ID="ucShopHours" />
                <asp:Label runat="server"  ID="lblOpen" Visible="false" />   
                <h2>Our Shop Hours</h2>
                Monday - Saturday<br />
                9:00am - 9:00pm<br />
                <br />
                Sunday<br />
                12:00pm - 6:00pm
            </div>
        </li> <!-- #shop-hours -->
          
        <li id="shop-contact" class="img-copy-row shop-info clearfix">
            <div class="imgContainer">
                <img src="images/icons/ic_bubble.gif" alt="Our Contact" />
            </div>
            <div class="copyContainer">
                <h2>Contact Us</h2>
                Phone: 212-674-7500<br />
                Fax: 212-673-1210<br />
                <a href="mailto:customer-service1@astorwines.com">Email Us</a><br />
                <a href="http://www.twitter.com/astorwines">@astorwines</a>        
            </div>
        </li> <!-- #shop-contact -->

          <li id="shop-location" class="img-copy-row shop-info clearfix">
            <div class="imgContainer">
                <img src="images/icons/ic_compass.gif" alt="Our Location" />
           </div> 
            <div class="copyContainer">
                <h2>Our Address</h2>
                Astor Wines &amp; Spirits<br />
                De Vinne Press Building<br />
                399 Lafayette<br /> 
                (at East 4th St.)<br />
                New York, NY 10003<br />
            </div>

        <div id="googleMapContainer">
            <iframe class="google-map" width="524" height="300" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://www.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=399+Lafayette+St,+New+York,+NY+10003&amp;sll=37.0625,-95.677068&amp;sspn=38.502405,79.013672&amp;ie=UTF8&amp;hq=&amp;hnear=399+Lafayette+St,+New+York,+10003&amp;z=16&amp;ll=40.728148,-73.992887&amp;output=embed"></iframe>
            <!--<small>
            <a href="http://www.google.com/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=399+Lafayette+St,+New+York,+NY+10003&amp;sll=37.0625,-95.677068&amp;sspn=38.502405,79.013672&amp;ie=UTF8&amp;hq=&amp;hnear=399+Lafayette+St,+New+York,+10003&amp;z=16&amp;ll=40.728148,-73.992887" style="color:#0000FF;text-align:left">View Larger Map</a> </small> -->
        </div>
        
        <p>Astor Wines &amp; Spirits is located in New York City at the corner of Lafayette Street and East 4th Street,
        just down the block from Astor Place.
        </p>

        </li> <!-- #shop-location -->      
        </ul>
        
                                     
        <div id="subwayDirectionsContainer" class="contentContainer clearfix">
          <h2>To get to our shop by Subway</h2><br />
            <div class="subway section">
                <img src="images/directions/img_6train.jpg" alt="6 Train" />
                <h3>Astor Place Station</h3>
                <p>Walk south on Lafayette to East 4th Street.</p>
            </div>
            
            <div class="subway section">
                  <img src="images/directions/img_Rtrain.jpg" alt="R Train" />
                  <h3>8th Street Station</h3> 
                  <p>Walk east to Lafayette and then south to East 4th Street.</p>
            </div>  
            
            <div class="subway section">
              <img src="images/directions/img_Btrain.jpg" alt="B Train" /><img src="images/directions/img_Dtrain.jpg" alt="D Train" /><img src="images/directions/img_Ftrain.jpg" alt="F Train" /><img src="images/directions/img_Vtrain.jpg" alt="V Train" /><br />
              <h3>Broadway-Lafayette station</h3> 
              <p>Walk north on Lafayette to East 4th Street.</p>
            </div>
            
        </div> <!-- #subwayDirectionsContainer -->
    
  </div>
</asp:Content>