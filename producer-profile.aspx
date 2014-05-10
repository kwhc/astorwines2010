<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="producer-profile.aspx.vb" Inherits="ProducerProfile" title="Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="producer-profile" class="info-page">              

        <asp:Image runat="server" ID="imgProfile" CssClass="profileImg" />   
            
        <div id="topInfo">
            <header class="section">
                <h1><asp:Literal runat="server" ID="litTitle" /></h1>
                <div class="location muted">
                    <i class="icon-map-marker"></i>
                    <asp:Literal runat="server" ID="litSubRegion" />
                    <asp:Literal runat="server" ID="litRegion" />
                    <asp:Literal runat="server" ID="litCountry" />
                </div>
            </header>
            
            <asp:PlaceHolder runat="server" ID="phProducerMeta">
            <div id="shortStats" class="section">
                <table>
                    <%--<tr>
                        <td><asp:Label runat="server" ID="lblEst" /></td>
                        <td><asp:Literal runat="server" ID="litEst" /></td>
                    </tr>--%>
                    <tr>
                        <td><asp:Label runat="server" ID="lblTypes" /></td>
                        <td><asp:Literal runat="server" ID="litTypes" /></td>
                    </tr>
                </table>
            </div>
            </asp:PlaceHolder>
            <div style="margin-bottom: 30px;"><asp:LinkButton runat="server" ID="lnkProducts" /></div>
        </div>
        
        <div id="bioContainer" class="clearfix">
            
            <div id="bio" class="section">
                <asp:Literal runat="server" ID="litBio" />
            </div>
        
        </div>
          
       <%-- <div id="items">
            <asp:Repeater runat="server" ID="rptItems">
                <ItemTemplate>
                    <asp:Image runat="server" ID="imgItm" />
                    <asp:Literal runat="server" ID="litItmTitle" />
                    <asp:Literal runat="server" ID="litItmDesc" />
                    <asp:Literal runat="server" ID="litPrice" />
                    <asp:Literal runat="server" ID="litSalePrice" />
                    <asp:Literal runat="server" ID="litCasePrice" />
                    <asp:Literal runat="server" ID="litCaseSalePrice" />
                    <asp:Button runat="server" ID="btnAddToCart" />
                </ItemTemplate>
            </asp:Repeater>
        </div>--%>
        
    
    
    </div>

</asp:Content>