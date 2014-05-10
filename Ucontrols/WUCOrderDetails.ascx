<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCOrderDetails.ascx.vb" Inherits="Ucontrols_WUCOrderDetails" %>
<asp:Image ID="Image7" runat="server" ImageUrl="~/images/as_checkout_confirm_bar.gif" />
    <asp:DataList ID="datMyList" runat="server" Width="718px">
        <HeaderTemplate>
        <table style="width: 100%; border-right: #eee2bc thin double; border-top: #eee2bc thin double; border-left: #eee2bc thin double; border-bottom: #eee2bc thin double;">
           <tr vAlign="top">
				
				<td align="left" width=50><asp:Label ID="Label1" runat="server" Text="Item #" CssClass=featureshead></asp:Label>
				</td>
				<td align="left" width=350><asp:Label ID="Label2" runat="server" Text="Item Name" CssClass=featureshead></asp:Label>
				</td>
				
				<td align="left" width=60><asp:Label ID="Label3" runat="server" Text="Qty" CssClass=featureshead></asp:Label>
				</td>
				<td align="center" width=100><asp:Label ID="Label4" runat="server" Text="Unit Type" CssClass=featureshead></asp:Label>
				</td>
				<td align="right" width=75><asp:Label ID="Label5" runat="server" Text="Unit Price" CssClass=featureshead></asp:Label>
				</td>
				<td align="right" width=120><asp:Label ID="Label6" runat="server" Text="Unit Total" CssClass=featureshead></asp:Label>
				</td>
			</tr></table>
        </HeaderTemplate>
        <ItemTemplate><table style="width: 100%; border-right: #eee2bc thin solid; border-top: #eee2bc thin solid; border-left: #eee2bc thin solid; border-bottom: #eee2bc thin solid;">
           <tr>
					
					<td align="left" width=50>
						
							<asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' CssClass="pt12size"></asp:Label>
						
					</td>
					<td align="left" width=350>
						
							<asp:Label ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>' CssClass="pt12size"></asp:Label>
						<asp:HyperLink ID="hyplItemName" runat="server"><%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
					</td>
					
					<td align="left" width=60>
						<asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>'  CssClass="pt12blsize"></asp:Label>
					
							
							
					</TD>
					<td align="center" width=100>
						
							<asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' CssClass="pt12size"></asp:Label>
					
					</td>
					<td align="right" width=75>
						
							<asp:label id="UnitPrice" runat="server"
								Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size"></asp:label>
					
					</td>
					<td align="right" width=120>
						
							<asp:label id="UnitTotal" runat="server"
								Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size"></asp:label>
						
					</td>
				</tr> </table>
        </ItemTemplate>
        <AlternatingItemTemplate><table style="width: 100%; border-right: #eee2bc thin solid; border-top: #eee2bc thin solid; border-left: #eee2bc thin solid; border-bottom: #eee2bc thin solid; background-color:#f7f0dd";>
           <tr>
					
					<td align="left" width=50>
							<asp:Label ID="lblItemNumber" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Item")) %>' CssClass="pt12size"></asp:Label>
						
					</td>
					<td align="left" width=350>
						
							<asp:Label ID="lblItemName" runat="server" Text='<%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %>' CssClass="pt12size"></asp:Label>
						<asp:HyperLink ID="hyplItemName" runat="server"><%# rtrim(databinder.eval(container.dataitem, "Name"))&" - "&rtrim(databinder.eval(container.dataitem, "vintage"))&" ("&rtrim(databinder.eval(container.dataitem, "size"))&")" %></asp:HyperLink>
					</td>
					
					<td align="left" width=60>
						<asp:Label ID="lblQty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantity", "{0:#####}")%>' CssClass="pt12blsize"></asp:Label>
					
							
							
					</TD>
					<td align="center" width=100>
						
							<asp:Label ID="lblUnitType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UnitType") %>' CssClass="pt12size"></asp:Label>
					
					</td>
					<td align="right" width=75>
						
							<asp:label id="UnitPrice" runat="server"
								Text='<%# DataBinder.Eval(Container.DataItem, "UnitPrice", "{0:C}") %>' CssClass="pt12size"></asp:label>
					
					</td>
					<td align="right" width=120>
						
							<asp:label id="UnitTotal" runat="server"
								Text='<%# String.Format("{0:C}", (DataBinder.Eval(Container.DataItem, "Quantity") * DataBinder.Eval(Container.DataItem, "UnitPrice"))) %>' CssClass="pt12size"></asp:label>
						
					</td>
				</tr> </table>
        </AlternatingItemTemplate>
    </asp:DataList>