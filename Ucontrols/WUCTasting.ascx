<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCTasting.ascx.vb" Inherits="Ucontrols_WUCTasting" %>

<div id="tastingSchedule" class="clearfix">
    <asp:Repeater ID="freeTastingsList" runat="server">
      <HeaderTemplate>
        <ul>
      </HeaderTemplate>
      <ItemTemplate>
        <li><span><%#Container.DataItem("startDate")%></span> <br /> <%#Container.DataItem("sEventName")%></li>
      </ItemTemplate>
      <FooterTemplate>
        </ul>
      </FooterTemplate>
    </asp:Repeater>
</div>