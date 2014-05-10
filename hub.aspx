<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="hub.aspx.vb" Inherits="hub" title="Astor Wines &amp; Spirits" %>

<%@ Register Src="~/Ucontrols/WUCWineSearch.ascx" TagName="wineSearch" TagPrefix="awWSr" %>
<%@ Register Src="~/Ucontrols/WUCWineClub.ascx" TagName="WUCWineClub" TagPrefix="uc14" %>
<%@ Register Src="~/Ucontrols/WUCGlossary.ascx" TagName="WUCGlossary" TagPrefix="uc15" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/hubWine.ascx" TagName="wine" TagPrefix="browse" %>
<%@ Register Src="~/Ucontrols/hubSpirits.ascx" TagName="spirits" TagPrefix="browse" %>
<%@ Register Src="~/Ucontrols/hubSake.ascx" TagName="sake" TagPrefix="browse" %>
<%@ Register Src="~/Ucontrols/WUCDailyFeatures.ascx" TagName="WUCDailyFeatures" TagPrefix="uc13" %>
<%@ Register Src="~/Ucontrols/WUCBasePageTop.ascx" TagName="WUCBasePageTop" TagPrefix="uc6" %>


<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <div class="searchResultsSearch">
    <awCmb:combinedSearch runat="server" />
  </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div class="hub-page">

        <h1><asp:Label runat="server" ID="hubTitle" /></h1>

        <asp:Panel ID="spiritSpecial" runat="server" Visible="false">            
            <div class="homepage-special clearfix">
                <a href="../SearchResultsSingle.aspx?search=26623&p=2&ref=hp"><img src="../images/itemimages/lg/26623_lg.jpg" alt="Karlsson's Vodka Batch 2008" class="bottle" /></a>
                <div class="copy">
                    <h3>Special Feature</h3>
                    <h4><a href="../SearchResultsSingle.aspx?search=26623&p=2&ref=hp">Karlsson's Vodka Batch 2008</a></h4>
                    <p>Only 1,980 bottles of this vodka made from the 2008 vintage of the Gammel Svensk Röd potato. A hotter year resulted in a more robust flavored potato which yielded a bold, earthy and peppery vodka. Delicious neat or on the rocks.</p>
                </div>
            </div>
        </asp:Panel>

        <ul class="dailyFeaturesContainer clearfix">
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures1" runat="server" feature="4" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures2" runat="server" feature="5" /></li>
            <li><uc13:WUCDailyFeatures ID="WUCDailyFeatures3" runat="server" feature="6" /></li>
        </ul> <!-- .dailyFeaturesContainer -->
        
        <asp:Panel runat="server" ID="pnlWine" Visible="false">
            <browse:wine runat="server" ID="browseWine" type="wine" />
        </asp:Panel>
        
        <asp:Panel runat="server" ID="pnlSake" Visible="false">
            <browse:sake runat="server" ID="browseSake" />
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlSpirits" Visible="false">
            <browse:spirits runat="server" ID="browseSpirits" />
        </asp:Panel>
        
        
        <uc6:WUCBasePageTop ID="WUCBasePageTop1" runat="server" />
            

    </div> <!-- .main-content -->  
</asp:Content>