<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="DeliveryInformation.aspx.vb" Inherits="DeliveryInformation" title="Delivery & Shipping Information | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register TagName="afterHoursCourierDetail" TagPrefix="uc" Src="~/Ucontrols/afterHoursCourierDetail.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="deliveryInfo" class="info-page">
        <span class="muted" style="letter-spacing:.05rem;text-transform:uppercase;">Information</span>
        <h1 style="margin-bottom:1rem;">Delivery &amp; Shipping Info</h1>
        <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" />  
        <div style="margin-bottom:2rem;">
            <h3></h3>
            <p>
                You must be at least 21 years of age to purchase and receive wine and spirits. 
            </p>
            <p>
            All deliveries require an adult signature.
            </p>
        </div>
        <div style="margin-bottom:2rem;">
            <h3>Restricted States</h3>
            <p>
            <strong>Due to restrictive regulations, we cannot accept orders for shipment to the following locations:</strong><br />
            <asp:Literal ID="lblNotShipToStatesCodes" runat="server" /><br /><br />
            <strong>We do not ship internationally.</strong><br />
            </p>
        </div>

        <div style="border-bottom:solid 1px #dddddd;border-top:solid 1px #dddddd;margin-bottom:2rem;padding:2rem 0rem;">
            <h3 style="text-transform:uppercase;">Spirits</h3>
            <p>If you are purchasing spirits, your order must meet our requirements for free delivery in your area. We are prohibited from sending spirits via common carrier.</p>
        </div>
        
        <div>
          <h3>Within New York State</h3>
          
          <ul>
              <li class="img-copy-row clearfix">
                  <div class="imgContainer">
                    <img src="../images/delivery-shipping/man_125toBatteryParkDelivery.jpg" alt="Manhattan (Battery Park to 125th Street) Wine & Spirits Delivery Map" />
                  </div>
                  <div class="copyContainer gutter">
                      <h3>Lower Manhattan<br />(Battery Park to 125th Street)</h3>
                      <span>Free Delivery On Orders Over $75 (pre-tax)</span>
                      <p>          
                        Astor offers free delivery from Battery Park to 125th Street (Mon. through Sat.) on orders that exceed $75
                        pre-tax. Orders placed before 12 noon will generally be delivered the following business day, barring
                        seasonal peaks in delivery volume and inclement weather.
                        Orders placed on Sundays will be delivered as early as Tuesday, unless otherwise informed. You will
                        receive a confirmation email once your order has been processed confirming your scheduled delivery date.
                      </p>
                  </div>
              </li>
          
              <li class="img-copy-row clearfix">
                  <div class="imgContainer">
                    <img src="../images/delivery-shipping/man_Above125Delivery.jpg" alt="Upper Manhattan (Above 125th Street) Wine & Spirits Delivery Map" />
                  </div>
                  <div class="copyContainer gutter">
                  <h3>Upper Manhattan<br />(above 125th Street)</h3>
                  <span>Free Delivery On Orders Over $100 (pre-tax)</span>
                  <p>    
                    Astor offers free delivery to Upper Manhattan on Wednesdays and Saturdays only on orders that
                    exceed $100 pre-tax. Orders placed before 12 noon on Tuesday or Friday will generally be delivered the
                    following day, barring seasonal peaks in delivery volume and inclement weather. You will receive a 
                    confirmation email once your order has been processed confirming your scheduled delivery date.
                  </p>
                  </div>
              </li>
          
              <li class="img-copy-row clearfix">
                  <div class="imgContainer">
                    <img src="../images/delivery-shipping/brooklynDelivery.jpg" alt="Brooklyn Wine & Spirits Delivery Map" />
                  </div>
                  <div class="copyContainer gutter">
                  <h3>Brooklyn</h3>
                  <span>Free Delivery On Orders Over $100 (pre-tax)</span>
                  <p>    
                    Astor offers free delivery to Brooklyn on Tuesdays, Wednesdays, Fridays, and Saturdays only on orders that exceed $100 pre-tax. Orders placed before 12 noon on Monday, Tuesday, Thursday, or Friday will generally be delivered the following day, barring seasonal peaks in delivery volume and inclement weather. You will receive a confirmation email once your order has been processed confirming your scheduled delivery date.
                  </p>
                  </div>
              </li>
          
              <li class="img-copy-row clearfix">
                  <div class="imgContainer">
                    <img src="../images/delivery-shipping/queensDelivery.jpg" alt="Queens Wine & Spirits Delivery Map" />
                  </div>
                  <div class="copyContainer gutter">
                  <h3>Queens</h3>
                  <span>Free Delivery On Orders Over $150 (pre-tax)</span>
                  <p>          
                    Astor offers free delivery to Queens on Wednesdays and Saturdays only on orders that exceed $150 pre-tax.
                    Orders placed before 12 noon on Tuesday or Friday will generally be delivered the following day, barring
                    seasonal peaks in delivery volume and inclement weather. You will receive a confirmation email once your
                    order has been processed confirming your scheduled delivery date.
                  </p>
                  </div>
              </li>
          
              <li class="img-copy-row clearfix">
                <div class="imgContainer" style="width:220px;">
                &nbsp;
                </div>
                <div class="copyContainer gutter">
                <h3>Roosevelt Island</h3>
                <span>Free Delivery on Orders Over $100 (Pre-Tax)</span>
                <p>
                Astor offers free delivery to Roosevelt Island on Wednesdays and Saturdays only, for orders that exceed $100 pre-tax. Orders placed before 12:00 noon on Tuesday or Friday will generally be delivered the following day, barring seasonal peaks in delivery volume and inclement weather. Once your order has been processed, you will receive an email confirming your scheduled delivery date.
                </p>
                </div>
              </li>
          
              <li class="img-copy-row clearfix">
                  <div class="imgContainer">
                    <img src="../images/delivery-shipping/NYStateDelivery.jpg" alt="New York State Wine & Spirits Delivery Map" />
                  </div>
                  <div class="copyContainer gutter">
                  <h3>New York State</h3>
                  <span>Free Ground Shipping On Orders Over $150 (pre-tax)</span>
                  <p>
                    Astor offers free shipping via UPS Ground throughout New York State on orders that exceed $150 pre-tax.
                    Expedited shipping via 3rd Day Select and Next Day Air are available, though full shipping charges apply.  
                    For orders under $150, regular UPS rates apply. You will receive a confirmation email once your order has
                    been processed confirming your scheduled shipment date, and then a subsequent email with your tracking
                    number with which you may track your order. Please note: UPS orders do not ship out on Saturday or Sunday.
                 </p>
                 <p>   
                    During times of extreme heat or cold, we will gladly hold your purchases until we can ensure safer travel.
                    If you opt to have your order shipped during such extreme weather, Astor cannot assume responsibility for
                    the condition of your wines upon delivery.
                  </p>
                  </div>
              </li>
          </ul>
      </div>
      <div>
          <h2>Outside New York State</h2>
          <div class="img-copy-row clearfix">
              <div class="imgContainer">
                <img src="../images/delivery-shipping/unitedStatesDelivery.jpg" alt="Outside New York State Wine & Spirits Delivery Map" />
              </div>
              <div class="copyContainer gutter">
              <p>
                Orders are shipped via UPS or FedEx. If your order is being shipped via UPS we offer Ground, 3rd Day Select, or Next Day Air. If your order is being shipped via Fed Ex we offer Ground, Standard Overnight, Express Saver(3rd Day) and Saturday Delivery.
                Shipping costs will be calculated at checkout. You will receive a confirmation email once your order has been
                processed confirming your scheduled shipment date, and then a subsequent email with your tracking number
                with which you may track your order. Please note: UPS and FedEx orders do not ship out on Saturday or Sunday.
             </p>
             <p>
                During times of extreme heat or cold, we will gladly hold your purchases until we can ensure safer travel.
                If you opt to have your order shipped during such extreme weather, Astor cannot assume responsibility for
                the condition of your wines upon delivery.
              </p>
              </div>
          </div>
      </div>
      <div style="margin-bottom:2rem;">
        <h3>Returns & Exchanges</h3>
          <p>
            Defective merchandise may be returned for exchange of product(s) of equal value upon presentation
            of the following: sales receipt, original bottle (with wine to be evaluated) and cork. No cash, credit, or
            store credit can be issued.
          </p>
      
      </div>

        <div style="border-bottom:solid 1px #dddddd;border-top:solid 1px #dddddd;margin-bottom:2rem;padding:2rem 0rem;">
            <uc:afterHoursCourierDetail ID="AfterHoursCourierDetail1" runat="server" />
        </div>
      
  </div>
  <script type="text/javascript">
      _gaq.push(['._setCustomVar',
        1,
        'Page Category',
        'Info',
        3
       ]);
  </script>
  
</asp:Content>