<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCGlossaryEntryOfDay.ascx.vb" Inherits="Ucontrols_WUCGlossaryEntryOfDay" %>

<div id="glossaryEntryOfDay">
  <h2>Entry of the Day</h2>
    <h3><asp:Literal ID="entryTitel" runat="Server" /></h3>
    <div>
      <asp:Literal ID="entryDesc" runat="server" />
    </div>
</div>