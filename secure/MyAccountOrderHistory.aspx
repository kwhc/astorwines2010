<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="MyAccountOrderHistory.aspx.vb" Inherits="secure_MyAccountOrderHistory" title="Order History | Astor Wines & Spirits" %>

<%@ Register Src="../Ucontrols/WUCOrderDetails.ascx" TagName="WUCOrderDetails" TagPrefix="uc2" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Src="../Ucontrols/WUCShippingNameEdit.ascx" TagName="WUCShippingNameEdit" TagPrefix="uc19" %>
<%@ Register Src="../Ucontrols/WUCCreditCardEdit.ascx" TagName="WUCCreditCardEdit" TagPrefix="uc17" %>
<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc18" %>
<%@ Register TagPrefix="igtxt" Namespace="Infragistics.WebUI.WebDataInput" Assembly="Infragistics35.WebUI.WebDataInput.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc6" %>
<%@ Register Src="../Ucontrols/WUCShippingName.ascx" TagName="WUCShippingName" TagPrefix="uc3" %>
<%@ Register Src="../Ucontrols/WUCCreditCard.ascx" TagName="WUCCreditCard" TagPrefix="uc4" %>
<%@ Register Src="../Ucontrols/WUCCreditCardNoCVV.ascx" TagName="WUCCreditCardNoCVV" TagPrefix="uc5" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="WUCMyAccountNav" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCMyAccountNav.ascx" TagName="AccountNavigation" TagPrefix="awNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="orderHistory" style="margin-bottom:2em;">
        <awNav:AccountNavigation ID="AccountNavigation1" runat="server" />
        <div id="mainContentHeader">
            <h1>My Order History</h1>
        </div>  
        <div class="accountMaintenanceIntro">
        Here you can review your past and current orders with us. You can check your order status, review billing/shipping information anytime of day or night.
        </div>
        <div style="padding: 5px;">
            <asp:Label ID="lblNoOrders" runat="server" Text="No orders placed" CssClass="featureshead"></asp:Label><br />
            <div style="border-top: dotted 1px #dddddd; border-bottom: dotted 1px #dddddd; text-align: right; font-size: 10pt; margin-bottom: 20px; margin-top: 50px;"> 
            <cc1:collectionpager
                id="colpagSearchResults" runat="server" backnextdisplay="HyperLinks" backnextlinkseparator="|"
                backnextlocation="Split" backnextstyle="" backtext="<" firsttext="<<" labelstyle=""
                labeltext="Go to Page:" lasttext=">>" maxpages="30" nexttext=">" pagenumbersseparator="|"
                pagesize="4" resultslocation="None" resultsstyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;"
                sectionpadding="10" showfirstlast="True" showlabel="True" showpagenumbers="True"
                slidersize="4" useslider="True"> </cc1:collectionpager>
            </div>
        </div>
    </div>           
        <asp:DataList ID="datlOrders" runat="server" RepeatLayout="Flow">
        <ItemTemplate>
        <div class="orderHistoryOrder pageRow background-white">
            <h3>Ordered on <asp:Label ID="lblOrdered" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Ordered", "{0:MMMM d, yyyy}")) %>' CssClass="pt12size" /></h3>
            <table>
                <tr>
                <td> 
                 <asp:DataList ID="datMyList" runat="server">
                    <HeaderTemplate>
                      <table style="border-bottom: #dddddd 1px dotted; width: 550px;">
                        <tr vAlign="top">
				            <td class="cartItemName"><asp:Label ID="Label2" runat="server" Text="Item Name" CssClass=ShoppingCarthead /></td>				    
				            <td class="cartQty"><asp:Label ID="Label3" runat="server" Text="Qty" CssClass=ShoppingCarthead /></td>
				            <td class="cartUnitType"><asp:Label ID="Label4" runat="server" Text="Unit Type" CssClass=ShoppingCarthead /></td>
				            <td class="cartUnitPrice"><asp:Label ID="Label5" runat="server" Text="Unit Price" CssClass=ShoppingCarthead /></td>
				            <td class="casrtUnitTot"><asp:Label ID="Label6" runat="server" Text="Unit Total" CssClass=ShoppingCarthead /></td>
			            </tr>
			          </table>
                    </HeaderTemplate>
                    <ItemTemplate>
            <table>
               <tr>			
			    <td class="cartItemName">					
							    <!--<asp:Label ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>' CssClass="pt12size"></asp:Label>-->
			    <asp:HyperLink ID="hyplItemName" runat="server" NavigateUrl='<%# rtrim(databinder.eval(container.dataitem, "NavigateURL")) %>'> 
						    <%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink><br />
						    <div style="font-size: 10px;">
						    Item#: <asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' CssClass="pt12size" />
						    </div>
					    </td>
    					
					    <td class="cartQty">
						    <asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>'  CssClass="pt12blsize" />				
					    </td>
					    <td class="cartUnitType">
						    <asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' CssClass="pt12size" />
					    </td>
					    <td class="cartUnitPrice">
							    <asp:label id="UnitPrice" runat="server"
								    Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size" />
					    </td>
					    <td class="cartUnitTot">
							    <asp:label id="UnitTotal" runat="server"
								    Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size" />
					    </td>
				    </tr>
				    </table>		
            </ItemTemplate>
        
                    <AlternatingItemTemplate>
        <table style="background-color:#d1d1d1;">
           <tr>
					<td class="cartItemName">		
							<asp:HyperLink ID="hyplItemName" runat="server" NavigateUrl='<%# rtrim(databinder.eval(container.dataitem, "NavigateURL")) %>'> 
						<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
						<div style="font-size: 10px;">
						Item#: <asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' CssClass="pt12size" />
						</div>
					</td>
					
					<td class="cartQty">
						<asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' CssClass="pt12blsize" />
					</td>
					
					<td class="cartUnitType">
							<asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' CssClass="pt12size" />
					</td>
					
					<td class="cartUnitPrice">	
							<asp:label id="UnitPrice" runat="server"
								Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size" />
					</td>
					
					<td class="cartUnitTot">
							<asp:label id="UnitTotal" runat="server"
								Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size" />
					</td>
				</tr> </table>
        </AlternatingItemTemplate>
                </asp:DataList>
                </td>
                </tr>
            </table>
        <div style="border-bottom: #dddddd 1px dotted; margin-bottom: 10px;"></div>
            <div class="orderHistoryLabelCol">
                <b>Order #: </b><br />
                <span style="display:none;"><b>Order Status: </b></span><br />
                <b>Ship Date: </b><br />
                <b>Tracking #: </b> <br />
                <b>Billing Info: </b><br /><br />
                <b>Shippping Info: </b><br /><br />
                <b>Shipping Type: </b><br />
                <b>Credit Card: </b><br />
                <b>Order Total: </b>
            </div>
            
            <div class="orderHistoryValueCol">
                <asp:Label ID="lblOrderNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "OrderNumber")) %>' CssClass="pt14blsize" /><br />
                <asp:Label ID="lblStatus" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "sOrderStatus")) %>' CssClass="pt12blsize" Visible="false" /><br />
                <asp:Label ID="lblShipDate" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "ShipDate")) %>' CssClass="pt12size" /><br />
                <asp:Label ID="lblUPSTrack" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "UPSTracking")) %>' CssClass="pt12size" /><br />
                <asp:Label ID="lblBilling" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "BillingInfo")) %>' CssClass="pt12size" /><br />
                <asp:Label ID="lblShippping" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "ShippingInfo")) %>' CssClass="pt12size" /><br />
                <asp:Label ID="lblShippingType" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "ShipType")) %>' CssClass="pt12size" /><br />
                <asp:Label ID="lblCreditCard" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "CCInfo")) %>' CssClass="pt12size" /><br />
                <asp:Label ID="lblOrderTotal" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "TotalValue","{0:C}" )) %>' CssClass="pt12blsize" />
            </div>
            <div style="clear: both;"></div>
        </div>
       <!-- END ORDER TEMPLATE -->
        </ItemTemplate>

       <AlternatingItemTemplate>
      <!-- BEGIN ALTERNATE ORDER TEMPLATE -->
      <div class="orderHistoryOrderAlt pageRow background-gray"> 
           
                <h3>Ordered on <asp:Label ID="lblOrdered" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Ordered", "{0:MMMM d, yyyy}")) %>' CssClass="pt12size" /></h3>
                <table>
                <tr><td> 
    <asp:DataList ID="datMyList" runat="server">
        <HeaderTemplate>
        <table style="border-bottom: #bbbbbb 1px dotted;">
           <tr>
				<td class="cartItemName"><asp:Label ID="Label2" runat="server" Text="Item Name" CssClass=ShoppingCarthead></asp:Label>
				</td>
				<td class="cartQty"><asp:Label ID="Label3" runat="server" Text="Qty" CssClass=ShoppingCarthead></asp:Label>
				</td>
				<td class="cartUnitType"><asp:Label ID="Label4" runat="server" Text="Unit Type" CssClass=ShoppingCarthead></asp:Label>
				</td>
				<td class="cartUnitPrice"><asp:Label ID="Label5" runat="server" Text="Unit Price" CssClass=ShoppingCarthead></asp:Label>
				</td>
				<td class="CartUnitTot"><asp:Label ID="Label6" runat="server" Text="Unit Total" CssClass=ShoppingCarthead></asp:Label>
				</td>
			</tr></table>
        </HeaderTemplate>
        <ItemTemplate>
        <table>
           <tr>
			<td class="cartItemName">				
			<asp:HyperLink ID="hyplItemName" runat="server" NavigateUrl='<%# rtrim(databinder.eval(container.dataitem, "NavigateURL")) %>'> 
						<%#RTrim(DataBinder.Eval(Container.DataItem, "Name")) & " - " & RTrim(DataBinder.Eval(Container.DataItem, "vintage")) & " (" & RTrim(DataBinder.Eval(Container.DataItem, "size")) & ")"%></asp:HyperLink>
						<div style="font-size: 10px;">
						Item#: <asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' CssClass="pt12size"></asp:Label>
						</div>
			</td>
					
			<td class="cartQty">
			    <asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>'  CssClass="pt12blsize"></asp:Label>	
					</td>
					<td class="cartUnitType">
						
							<asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' CssClass="pt12size"></asp:Label>
					
					</td>
					<td class="cartUnitPrice">
						
							<asp:label id="UnitPrice" runat="server"
								Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size"></asp:label>
					
					</td>
					<td class="cartUnitTot">
						
							<asp:label id="UnitTotal" runat="server"
								Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size"></asp:label>
						
					</td>
				</tr> </table>
        </ItemTemplate>
        <AlternatingItemTemplate><table style="background-color:#d1d1d1";>
           <tr>
					<td class="cartItemName">		
							<asp:HyperLink ID="hyplItemName" runat="server" NavigateUrl='<%# rtrim(databinder.eval(container.dataitem, "NavigateURL")) %>'> 
						<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
						<div style="font-size: 10px;">
						Item#: <asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' CssClass="pt12size"></asp:Label>
						</div>
					</td>
					
					<td class="cartQty">
						<asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' CssClass="pt12blsize"></asp:Label>
					</TD>
					<td class="cartUnitType">
							<asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' CssClass="pt12size"></asp:Label>
					</td>
					<td class="cartUnitPrice">
							<asp:label id="UnitPrice" runat="server"
								Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size"></asp:label>
					</td>
					<td class="cartUnitTot">
							<asp:label id="UnitTotal" runat="server"
								Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size"></asp:label>
					</td>
				</tr> </table>
        </AlternatingItemTemplate>
                </asp:DataList>
                </td></tr>
        </table>
        <div style="border-bottom: #bbbbbb 1px dotted; margin-bottom: 10px;"></div>
            <div class="orderHistoryLabelCol">
                    <b>Order #: </b><br />
                    <span style="display:none;"><b>Order Status: </b></span><br />
                    <b>Ship Date: </b><br />
                    <b>Tracking #:</b><br />        
                    <b>Billing Info: </b><br /><br />
                    <b>Shipping Info: </b><br /><br />
                    <b>Shipping Type: </b><br />
                    <b>Credit Card: </b><br />
                    <b>Order Total: </b><br />
            </div>
            <div class="orderHistoryValueCol">
                    <asp:Label ID="lblOrderNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "OrderNumber")) %>' CssClass="pt14blsize" /><br />
                    <asp:Label ID="lblStatus" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "sOrderStatus")) %>' CssClass="pt12blsize" Visible="false" /><br />
                    <asp:Label ID="lblShipDate" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "ShipDate")) %>' CssClass="pt12size" /><br />
                    <asp:Label ID="lblUPSTrack" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "UPSTracking")) %>' CssClass="pt12size" /><br />
                    <asp:Label ID="lblBilling" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "BillingInfo")) %>' CssClass="pt12size" /><br />
                    <asp:Label ID="lblShippping" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "ShippingInfo")) %>' CssClass="pt12size" /><br />
                    <asp:Label ID="lblShippingType" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "ShipType")) %>' CssClass="pt12size" /><br />
                    <asp:Label ID="lblCreditCard" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "CCInfo")) %>' CssClass="pt12size" /><br />
                    <asp:Label ID="lblOrderTotal" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "TotalValue","{0:C}" )) %>' CssClass="pt12blsize" /> 
            </div>
            <div style=" clear: both;"></div>
        </div>
        </AlternatingItemTemplate>
    </asp:DataList>
   
  
</asp:Content>