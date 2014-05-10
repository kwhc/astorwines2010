<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCSearchResultsTop.ascx.vb" Inherits="Ucontrols_WUCSearchResultsTop" %>

    <script type="text/javascript">
        $(function() {
            $('#maxedOut').aqTip('To keep you (and your computer) from being overwhelmed, only the first 100 results will be displayed. Still feeling overwhelmed? Narrow your search using the options on the left.');
            $('#tailor').aqTip('Tailor your search using the options on the left.');   
        });
    </script>

      <!-- <h1 class="mainHeader">Search Results</h1> -->
    <div class="searchResultsHeader">      
        <asp:Literal ID="lblResultTop" runat="server" Visible="false">Your search yielded the following results.</asp:Literal>
        <asp:Literal ID="litResultMiddle" runat="server" />
        <div class="searchTip"><asp:Literal ID="lblResultBottom" runat="server">Don't see what you're looking for?</asp:Literal></div>
    </div>