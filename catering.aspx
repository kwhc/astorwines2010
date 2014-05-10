<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="catering.aspx.vb" Inherits="Catering" title="Catering | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <img src="images/general/middleContentTop.gif" alt="" />
    <div id="mainContentHeader">
        <h1>Catering</h1>
    </div>
    <div id="cateringPage">
        <div id="mainImageContainer">
            <img src="images/catering/catering1.jpg" alt="" />
        </div>
        
        <div class="featureList" id="greatFor">
            <h2>A Great Resource for:</h2>
            <ul>
                <li>Caterers</li>
                <li>Party Planners</li>
                <li>Galleries</li>
            </ul>
        </div>
        
        <div id="copyContainer">
            
            <h3>Planning a party?</h3>
            
            <p>
            Astor Wines provides excellently priced case discounts to help you keep your catering costs to a minimum.</p> 
            <br />
            <div>
                Have any questions or want to get started?
                <h2 id="contact"><a href="mailto:ali@astorwines.com">Contact Ali</a></h2>
            </div>
        </div>
        <div class="featureList">
            <h2>We offer:</h2>          
            <ul>
                <li>Free delivery in NYC</li>
                <li>Phenomenal wines from $45/case</li>
                <li>Advice from our experts</li>
                <li>Personalized tastings</li>
            </ul>
        </div>   


    </div>
</asp:Content>