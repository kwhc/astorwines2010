<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="bulkOrdering.aspx.vb" Inherits="bulkOrdering" title="Bulk Ordering | Astor Wines & Spirits" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
      <img src="../images/general/middleContentTop.gif" />
    <div id="mainContentHeader">
    <h1>Bulk Ordering</h1> 
    </div>
  <div id="deliveryInfo">
      <p>
        <strong>Due to restrictive regulations, we cannot accept orders for shipment to the following locations:</strong><br />
        <asp:Literal ID="lblNotShipToStatesCodes" runat="server"></asp:Literal><br /><br />
        <strong>We do not ship internationally.</strong><br /><br />
      </p>
      <h2>Within New York State</h2>
      
      <div class="locationContainer">
          <div class="imageContainer">
            <img src="../images/delivery-shipping/man_125toBatteryParkDelivery.jpg" alt="Manhattan (Battery Park to 125th Street) Wine & Spirits Delivery Map" />
          </div>
          <div class="copyContainer">
              <h3>Manhattan (Battery Park to 125th Street)</h3>
              <span>Free Delivery On Orders Over $75 (pre-tax)</span>
              <p>          
                Astor offers free delivery from Battery Park to 125th Street (Mon. through Sat.) on orders that exceed $75
                pre-tax. Orders placed before 12 noon will generally be delivered the following business day, barring
                seasonal peaks in delivery volume and inclement weather.
                Orders placed on Sundays will be delivered as early as Tuesday, unless otherwise informed. You will
                receive a confirmation email once your order has been processed confirming your scheduled delivery date.
              </p>
          </div>
      </div>
      
      <div class="locationContainer">
          <div class="imageContainer">
            <img src="../images/delivery-shipping/man_Above125Delivery.jpg" alt="Upper Manhattan (Above 125th Street) Wine & Spirits Delivery Map" />
          </div>
          <div class="copyContainer">
          <h3>Upper Manhattan (above 125th Street)</h3>
          <span>Free Delivery On Orders Over $100 (pre-tax)</span>
          <p>    
            Astor offers free delivery to Upper Manhattan on Wednesdays and Saturdays only on orders that
            exceed $100 pre-tax. Orders placed before 12 noon on Tuesday or Friday will generally be delivered the
            following day, barring seasonal peaks in delivery volume and inclement weather. You will receive a 
            confirmation email once your order has been processed confirming your scheduled delivery date.
          </p>
          </div>
      </div>
      
      <div class="locationContainer">
          <div class="imageContainer">
            <img src="../images/delivery-shipping/brooklynDelivery.jpg" alt="Brooklyn Wine & Spirits Delivery Map" />
          </div>
          <div class="copyContainer">
          <h3>Brooklyn</h3>
          <span>Free Delivery On Orders Over $100 (pre-tax)</span>
          <p>    
            Astor offers free delivery to Brooklyn on Wednesdays, Fridays and Saturdays only on orders that
            exceed $100 pre-tax. Orders placed before 12 noon on Tuesday, Thursday or Friday will generally be delivered the
            following day, barring seasonal peaks in delivery volume and inclement weather. You will receive a 
            confirmation email once your order has been processed confirming your scheduled delivery date.
          </p>
          </div>
      </div>
      
      <div class="locationContainer">
          <div class="imageContainer">
            <img src="../images/delivery-shipping/queensDelivery.jpg" alt="Queens Wine & Spirits Delivery Map" />
          </div>
          <div class="copyContainer">
          <h3>Queens</h3>
          <span>Free Delivery On Orders Over $150 (pre-tax)</span>
          <p>          
            Astor offers free delivery to Queens on Wednesdays and Saturdays only on orders that exceed $150 pre-tax.
            Orders placed before 12 noon on Tuesday or Friday will generally be delivered the following day, barring
            seasonal peaks in delivery volume and inclement weather. You will receive a confirmation email once your
            order has been processed confirming your scheduled delivery date.
          </p>
          </div>
      </div>
      
      <div class="locationContainer">
          <div class="imageContainer">
            <img src="../images/delivery-shipping/NYStateDelivery.jpg" alt="New York State Wine & Spirits Delivery Map" />
          </div>
          <div class="copyContainer">
          <h3>New York State</h3>
          <span>Free Ground Shipping On Orders Over $150 (pre-tax)</span>
          <p>
            Astor offers free shipping via UPS Ground throughout New York State on orders that exceed $150 pre-tax.
            Expedited shipping via 3rd Day Select and Next Day Air are available, though full shipping charges apply.  
            For orders under $150, regular UPS rates apply. You will receive a confirmation email once your order has
            been processed confirming your scheduled shipment date, and then a subsequent email with your tracking
            number with which you may track your order. Please note: UPS orders do not ship out on Saturday or Sunday.
            During times of extreme heat or cold, we will gladly hold your purchases until we can ensure safer travel.
            If you opt to have your order shipped during such extreme weather, Astor cannot assume responsibility for
            the condition of your wines upon delivery.
          </p>
          </div>
      </div>
      <br />
      <h2>Outside New York State</h2>
      <div class="locationContainer">
          <div class="imageContainer">
            <img src="../images/delivery-shipping/unitedStatesDelivery.jpg" alt="Outside New York State Wine & Spirits Delivery Map" />
          </div>
          <div class="copyContainer">
          <p>
            Orders are shipped via UPS. You may select to ship your order via UPS Ground, 3rd Day Select, or Next Day Air.
            Shipping costs will be calculated at checkout. You will receive a confirmation email once your order has been
            processed confirming your scheduled shi pment date, and then a subsequent email with your tracking number
            with which you may track your order. Please note: UPS orders do not ship out on Saturday or Sunday.
            During times of extreme heat or cold, we will gladly hold your purchases until we can ensure safer travel.
            If you opt to have your order shipped during such extreme weather, Astor cannot assume responsibility for
            the condition of your wines upon delivery.
          </p>
          </div>
      </div>
      
      <div class="extraCopyContainer">
      <p>
        You must be at least 21 years of age to purchase and receive wine and spirits. 
        All deliveries require an adult signature.
      </p>
      <p>
        Defective merchandise may be returned for exchange of product(s) of equal value upon presentation
        of the following: sales receipt, original bottle (with wine to be evaluated) and cork. No cash, credit, or
        store credit can be issued.
      </p>
      
      </div>
      
  </div>
</asp:Content>