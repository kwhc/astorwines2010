<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCShipDates.ascx.vb" Inherits="Ucontrols_WUCShipDates" %>

<%@ Register TagName="copy" TagPrefix="uc" Src="~/Ucontrols/afterHoursCourierDetail.ascx" %>

    <asp:Panel runat="server" ID="pnlHolidayAlert" Visible="false">
        <img src="../images/general/alert.gif" alt="Delivery Alert" style="float: left; margin-right: 8px;" />
        <h3>Holiday Shipping Alert</h3>
        <div style="border-bottom: dashed #ccc 1px; padding-bottom: 8px;">
            <p>Unfortunately our 3rd Day shipments will not arrive by Christmas.</p>
        </div>
        <br /><br />
    </asp:Panel>
       
    <asp:PlaceHolder runat="server" ID="phShipDatesContainer">
        <ul class="grid">
            <li class="head">
                <h3>Our Next Shipping Dates</h3> 
            </li>
            <asp:PlaceHolder runat="server" ID="phAfterHoursCourierService">
                <li>
                    <div>
                        <h4 style="font-weight:bold;display:inline-block;vertical-align:top;"><i class="icon-ok"></i></h4>
                        <h4 style="font-weight:bold;display:inline-block;">Free After-Hours Courier Service<br/><span style="font-weight:normal;font-size:1rem;">Available for this order!</span></h4>
                    </div>
                    <p>
                    No Doorman? No Problem!<br/>
                    For deliveries in Manhattan from Battery Park to 125th Street, you may now choose a three-hour window for your delivery between 3:00 p.m. and 9:00 p.m.</p> 
                    <p>Plus: Place your order by 4 p.m. and get it delivered the next day.*
                    </p>
                    <a href="#afterHoursCourierDetail" rel="modal:open" style="text-decoration:none;padding:.2rem 2rem .2rem .5rem;width:inherit;text-align:left;">*View details</a>
                </li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phUPSShipDates">
                <li>        
                    <h4 style="margin-bottom:1em;font-weight:bold;">UPS</h4>
                    <hr style="background:#666666;width:30px;border:0;height:3px;margin-bottom:1em;" align="left" />  
                    <b>Next UPS Ground Shipment <i>Departs</i> Astor on:</b>
                    <h3><asp:Label ID="lblUPS" runat="server" Text="12/1/2007" /></h3>
                    <div style="font-style: italic; line-height:1.6em; margin-top:1em;">
                            Please Note:<br />
                            <ul style="list-style-type: circle; list-style-position: inside;">
                                <li>Shipping days are counted from date shipped</li>
                                <li>Weekends do not count as shipping days</li>
                                <li>UPS orders do not have weekend delivery dates</li>
                            </ul>
                     </div>
                </li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phFedExShipDates">
                <li>
                    <h4>FedEx</h4>
                </li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phAstorTrucks">
                <li class="alt">
                    <h4 style="margin-bottom:1em;font-weight:bold;">Astor Delivery Trucks</h4>
                    <hr style="background:#666666;width:30px;border:0;height:3px;margin-bottom:1em;" align="left" />
                    <h5>Next Delivery Dates</h5>
                    For Lower Manhattan (Battery Park to 125th St.):<br />
                    <b>&#187; </b><asp:Label ID="lblManLower" runat="server" Text="12/1/2007" /><br />
                    <br />
                    For Upper Manhattan (Above 125th Street): <br />
                    <b>&#187; </b><asp:Label ID="lblManUpper" runat="server" Text="12/1/2007" /><br />
                    <br />
                    For Brooklyn:<br />
                    <b>&#187; </b><asp:Label ID="lblBrooklyn" runat="server" Text="12/1/2007" /><br />
                    <i style="font-size: 10px; color: #5F191B;">We now deliver to Brooklyn on Tuesdays!</i><br />
                    <br />
                    For Queens:<br />
                    <b>&#187; </b><asp:Label ID="lblQueens" runat="server" Text="12/1/2007" /><br />
                </li>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phThirdPartyTransfer">
                <li>
                    <h4>Third Party Transfer Dates</h4>
                </li>    
            </asp:PlaceHolder>
        </ul>
        <div>
            <p style="font-size: 10px; font-style: italic; line-height: 14px;">
                Shipment and Delivery dates are not guaranteed, and are subject to change without notice.
            </p>
        </div>
        <div id="afterHoursCourierDetail" style="display:none;">
            <uc:copy runat="server" />
            <p><a href="#" rel="modal:close" style="text-decoration:none;"><i class="icon-remove-sign"></i> close</a></p>
        </div>
    </asp:PlaceHolder>
    
    <div style="text-align:center;margin-top:2rem;">
        <img ID="free-shipping-sticker" src="../images/general/img_free_ship_circle_180.png" alt="Free Shipping on First-Time Orders!" width="160" height="160" />    
    </div>