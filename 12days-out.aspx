<%@ Page Language="VB" AutoEventWireup="false" CodeFile="12days-out.aspx.vb" Inherits="_12days_out" MasterPageFile="~/as_master_1.master" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadSupplement">
    <style type="text/css">
        #twelveDaysSoldOutPage{
            text-align: center;
            font-size: 1.2em;
        }
        
        .customPage{ 
            text-align: center;
        }
        
            #twelveDaysSoldOutPage #headerContainer{
                width: 520px;
                height: 300px;
                background-image: url(images/holiday/12daysSoldOut.gif);
                background-repeat: no-repeat;
                text-indent: -9999px; 
                margin: 0 auto;
                margin-top: 20px;
                padding-bottom: 30px;
            }
        
            #twelveDaysSoldOutPage h1{
                text-transform: uppercase;
                font-family: Gill Sans MT, Gill Sans, Arial, hevetica, Sans-Serif;
                font-weight: normal;
            }
            
            #twelveDaysSoldOutPage #copy{
                font-size: 1.2em;
                line-height: 1.6em;
                width: 500px;
                margin: 0px auto;
            }
            
            #twelveDaysSoldOutPage #cats{
                margin-top: 20px;
            }
            
    </style>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="middleContent">

<div class="customPage" id="twelveDaysSoldOutPage">
    
    <div id="headerContainer">
        <h1>Today's 12 Days of Astor Item is Sold Out!</h1>
    </div>
    
    <div id="copy">
    <p>
    We are happy we could offer such a popular deal, and at the same time saddened that not everyone could take part. Keep checking our 12 Days of Astor emails for more amazing offers. Thanks to all of you who showed interest, and our sincerest apologies to those we couldn't accommodate.
    </p>
    <p>
    Happy Holidays!
    </p>
    </div>
    
    <!-- 
    <div id="cats">
        Please enjoy kittens with wine
        <img src="images/holiday/img_catWine.jpg" />
    </div>
    -->

</div>

</asp:Content>