<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCNoResultTop.ascx.vb" Inherits="Ucontrols_WUCNoResultTop" %>

<%@ Register Src="~/Ucontrols/WUCSearchNoResultsHelp.ascx" TagName="searchHelp" TagPrefix="awSrc" %>

<div class="row">
  <h1><asp:Literal ID="lblSearchString" runat="server" /></h1>
  <asp:PlaceHolder ID="didYouMean" runat="server">Did you mean <asp:LinkButton ID="suggestTerm" runat="server" /><asp:Literal ID="amountResults" runat="server" /> ?</asp:PlaceHolder>
  <awSrc:searchHelp ID="searchHelp" runat="server" />
</div>
  
  <div class="row">
      <h3>No Luck? </h3>
      <ul class="bullets">
          <li>Check to be sure the spelling is correct</li>
          <li>Try tailoring your search using the advanced search on the left</li>
          <li>If you are looking for a specific item, it may not be in stock at the moment. Please feel free to contact us for more information.</li>
          <li><a href="../WinesOnSale.aspx">Check Out What's On Sale</a></li>
      </ul>
  </div>
  
  <div class="row">
      <h3>Contact us</h3>
      <dl class="dl-horizontal">
        <dt>Send us an email:</dt>
        <dd><a href="mailto:customer-service1@astorwines.com">customer-service1@astorwines.com</a></dd>
        <dt>Call our shop:</dt>
        <dd><a href="tel:+12126747500">(212)674-7500</a></dd>
        <dt>Message us on Twitter:</dt>
        <dd><a href="http://twitter.com/astorwines">@astorwines</a></dd>
      </dl>
      <asp:Literal ID="litSearch" runat="server" EnableViewState="False" />
  </div>
