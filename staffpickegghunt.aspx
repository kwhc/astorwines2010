<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="staffpickegghunt.aspx.vb" Inherits="sweetheart" title="Astor's Easter Sale | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">

  <div id="easterEggHunt" class="info-page" style="text-align: center;">        
    
    <img src="images/email/images/easter-sale-trans.png" alt="Staff Pick Easter Egg Hunt" style="margin-bottom: 40px;" width="526" />
    
    <div>
        <a href="Features.aspx?featurepage=a10_1_4_219"><img src="images/email/images/wines.jpg" alt="" style="padding: 6px;" /></a>
        <a href="Features.aspx?featurepage=a10_1_2_214"><img src="images/email/images/spirits.jpg" alt="" style="padding: 6px;" /></a>
    </div>
            
  </div>
</asp:Content>