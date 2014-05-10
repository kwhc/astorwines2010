<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="faq.aspx.vb" Inherits="AstorLandmarkStore" title="Frequently Asked Questions | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

    <div id="faq" class="info-page">        

        <span class="muted" style="letter-spacing:.05rem;text-transform:uppercase;">Information</span>
        <h1 style="margin-bottom:1rem;">Frequently Asked Questions</h1>
        <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" />  

    <div id="faq-nav">    
        <div id="order-assistance">
            <h3>Order Assistance</h3>
            <ul>
                <li><a href="#">Is your selection online identical to what you have in the store?</a></li>
                <li><a href="#">I’m interested in purchasing a wine that you do not carry. Can you order it for me?</a></li>
                <li><a href="#">How can I get on the waiting list for Van Winkle whiskeys?</a></li>
            </ul>
        </div>
        
        <div id="returns">
            <h3>Returns</h3>
            <ul>
                <li><a href="#">What is your policy on exchanges and returns?</a></li>
                <li><a href="#">Is there a restocking fee for returned items?</a></li>
            </ul>
        </div>    

        <div id="shipping-delivery">
            <h3>Shipping &amp; Delivery</h3>
            <ul>
                <li><a href="#">I’m worried my bottles will break during shipment. Is there an insurance fee for shipped bottles?</a></li>
                <li><a href="#">Do you offer same-day delivery?</a></li>
                <li><a href="#">Do you ship out of state?</a></li>
                <li><a href="#">Can I place an order for pick-up on your website?</a></li>
            </ul>
        </div>    

        <div id="our-shop">
            <h3>Our Shop</h3>
            <ul>
                <li></li>
            </ul>
        </div>    
    </div>    
    
    <div id="faq-body">    
    <div>
        <h3>What is your policy on exchanges and returns?</h3>
        <p>
        Here’s the quick version: Unopened spirits may be returned for a full refund. Defective wines, spirits, and sakés may be exchanged for items of equal or greater value.
        </p>
        <p>
        This is all subject to restrictions, of course: <a href="return-policy.aspx">You can read our full policy here.</a>
        </p>
    </div>
    
    <div>
        <h3>Is there a restocking fee for returned items?</h3>
        <p>
        No. When you return an item for a refund, you’ll get back the full amount you paid originally (minus any shipping costs).
        </p>
    </div>

    <div>
        <h3>I’m worried my bottles will break during shipment. Is there an insurance fee for shipped bottles?</h3>
        <p>
        Nope – we’ve got you covered! If your bottle arrives broken, just let us know and we’ll make arrangements to replace it, free of charge.
        </p>
    </div>    
    
    <div>
        <h3>Do you offer same-day delivery?</h3>
        <p>
Yes, we can often deliver your order on the same day as your purchase, using messengers (not our free delivery service). The fee varies according to the number of bottles you are purchasing and where they are being delivered. Please call 212-674-7500 for an estimate. 
        </p>
    </div>    

    <div>
        <h3>Do you ship out of state?</h3>
        <p>
        Astor Wines &amp; Spirits can ship to most states in the US.<br /> 
        <a href="DeliveryInformation.aspx">For a list of states to which we are not able to ship wine and spirits, click here.</a>
        </p>
    </div>    

    <div>
        <h3>Can I place an order for pick-up on your website?</h3>
        <p>
        At this time, it is not possible to place a "will call" order online. If you would like to place an order for pick-up, please call us at 212-674-7500. 
        </p>
    </div>    

    <div>
        <h3>Is your selection online identical to what you have in the store?</h3>
        <p>
        Generally speaking, yes: our in-store stock is largely the same as our online inventory. If we have low stock on certain items, they may be taken offline to avoid overselling.  
        </p>
    </div>    

    <div>
        <h3>Does someone need to sign for my delivery?</h3>
        <p>
        Yes, the law requires that all deliveries of products containing alcohol must be signed for by an adult over the age of 21.
        </p>
    </div>    

    <div>
        <h3>Do you offer discounts on cases?</h3>
        <p>
        Yes. For solid cases of still wine, we offer 10% off for delivery and carryout orders. For mixed cases, we offer a discount of 10% for carryout orders only. This discount does not apply to sparkling wines, but sparkling wines do count toward the 12-bottle order minimum for a mixed-case discount. Once the 12-bottle minimum is met, every additional bottle of still wine purchased will receive the 10% discount as well. We do not offer case discounts on spirits.    
        </p>
    </div>    

    <div>
        <h3>Do you have free tastings?</h3>
        <p>
        Yes, we hold wine and spirits tastings every week that are free and open to the public.<br /> 
        <a href="TastingEvents.aspx">Click here to view our upcoming tastings.</a>
        </p>
    </div>    

    <div>
        <h3>I’m interested in purchasing a wine that you do not carry. Can you order it for me?</h3>
        <p>
        Depending on availability, we may be able to special-order a particular wine for you by the case only.
        </p>
    </div>    

    <div>
        <h3>How can I get on the waiting list for Van Winkle whiskeys?</h3>
        <p>
        Each fall, the Buffalo Trace Distillery releases a highly limited allocation of Van Winkle whiskeys. In order to keep things fair, we maintain a waiting list for each fall's allocation.
        </p>
        <p>
        If you wish to be included on the list, please login or create an account and visit our <a href="rare.aspx">rare items page</a>.
        </p>
        
    </div>    
    </div>
    
  </div>
  
</asp:Content>