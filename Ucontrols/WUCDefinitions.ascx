<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCDefinitions.ascx.vb" Inherits="Ucontrols_WUCDefinitions" %>
<asp:DataList ID="datDefinitions" runat="server">
  <ItemTemplate>
  <div class="glossary-teaser">
    <h3><%# rtrim(databinder.eval(container.dataitem, "sTerm"))%></h3>
    <p><asp:Literal ID="lblDescription" runat="server" /></p>
    <asp:HyperLink ID="entryLink" runat="server" Text="Read More" Visible="false" />
  </div>  
  </ItemTemplate>
 </asp:DataList>