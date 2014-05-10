<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCHeader.ascx.vb" Inherits="Ucontrols_WUCHeader" %>

<%@ Register Src="~/Ucontrols/WUCQuickSearch.ascx" TagName="WUCQuickSearch" TagPrefix="uc1" %>
<%@ Register Src="WUCQuickSearchNoAutoComplete.ascx" TagName="WUCQuickSearchNoAutoComplete" TagPrefix="uc2" %>
<%@ Register TagPrefix="ignav" Namespace="Infragistics.WebUI.UltraWebNavigator" Assembly="Infragistics35.WebUI.UltraWebNavigator.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<div id="mainBanner">
      <asp:Panel runat="server" Visible="false" ID="customTout">
          <div id="masthead" class="toast-alert-box toast-alert">
          </div>
      </asp:Panel>
                  
      <div id="navigationBar">
        <div id="menuBar">
          <div id="navBar">
            <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx" Text= "home" />
            <asp:HyperLink runat="server" NavigateUrl="~/WineSearch.aspx" Text="wines" />
            <asp:HyperLink runat="server" NavigateUrl="~/SakeSearch.aspx" Text="sak&#233;s" />
            <asp:HyperLink runat="server" NavigateUrl="~/SpiritsSearch.aspx" Text="spirits" /> 
            <asp:HyperLink runat="server" NavigateUrl="~/BooksAccessoriesSearch.aspx" Text="books &amp; accessories" />
          </div>
        </div>
        
        <div id="breadcrumbBar">
          <!--<div id="breadcrumb"></div>-->
          <div class="quickSearchContainer"> 
            <uc1:WUCQuickSearch ID="WUCQuickSearch1" runat="server" />
            <uc2:WUCQuickSearchNoAutoComplete ID="WUCQuickSearchNoAutoComplete" runat="server" />
          </div>
          <!--<asp:SiteMapPath ID="smpMain" runat="server"><CurrentNodeStyle Font-Bold="True" /></asp:SiteMapPath>
          <asp:Label ID="lblBCItem" runat="server" Font-Bold="True" Text="BC Item"></asp:Label>-->      
        </div>
      </div>
</div>
