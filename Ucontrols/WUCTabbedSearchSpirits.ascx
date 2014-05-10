<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCTabbedSearchSpirits.ascx.vb" Inherits="Ucontrols_WUCTabbedSearch" %>

<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Src="WUCWineSearch.ascx" TagName="WUCWineSearch" TagPrefix="uc1" %>
<%@ Register Src="WUCSpiritsSearch.ascx" TagName="WUCSpiritsSearch" TagPrefix="uc2" %>
<%@ Register Src="WUCSakeSearch.ascx" TagName="WUCSakeSearch" TagPrefix="uc3" %>
<%@ Register Src="~/Ucontrols/WUCBooksAssocSearch.ascx" TagName="WUCBookSearch" TagPrefix="uc4" %>
<%@ Register Src="~/Ucontrols/WUCQuickSearch.ascx" TagName="WUCQuickSearch" TagPrefix="uc5" %>

<div id="advancedSearch">
<div id="advancedSearchTabs">
    <ul> 
      <li><div class="advancedSearchTab"><a href="#wineSearch">Wine Search</a></div></li> 
      <li><div class="advancedSearchTab"><a href="#spiritsSearch" class="selected">Spirits Search</a></div></li>
      <li><div class="advancedSearchTab"><a href="#sakeSearch">Sak&#233; Search</a></div></li> 
    </ul> 
</div>
<div id="wineSearch" style="display: none; "><uc1:WUCWineSearch ID="WUCWineSearch1" runat="server" showheader="false" /></div> 
<div id="spiritsSearch" style="display: block; "><uc2:WUCSpiritsSearch ID="WUCSpiritsSearch1" runat="server" showheader="false" /></div>
<div id="sakeSearch" style="display: none; "><uc3:WUCSakeSearch ID="WUCSakeSearch1" runat="server" showheader="false" /></div>

<script type="text/javascript"> 
  $("#advancedSearchTabs ul").idTabs("spiritsSearch"); 
</script>
</div>