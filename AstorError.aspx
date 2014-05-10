<%@ Page Language="VB" MasterPageFile="~/search-only.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorError.aspx.vb" Inherits="AstorError" title="Astor Wines & Spirits - Error" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  
  <div id="errorPage">
    <div id="mainImageContainer">
        <img src="images/general/img_bear-with-us.gif" alt="Bear with us!" id="bear" />
    </div>
        
    <div class="halfPageColumn">
        <h2>We're sorry!</h2>
        
        <p>We have logged an error report and will look into it.</p>
        
        <p>For now, please use the browser’s “Back” button and try again.</p>
        
        <p>If it keeps happening, please email us at online@astorwines.com and let us know!</p>
    </div>
    
    <div class="halfPageColumn" id="reasons">
        <h3>Reasons For This Error</h3>
        <ul>
            <li>We have some code that is not playing nice</li>
            <li>You have been idle for too long and your cart has expired</li>
        </ul>
    </div>    
    <br style="clear: both;" />
  </div>
</asp:Content>