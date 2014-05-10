<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="TastingEvents.aspx.vb" Inherits="TastingEvents" title="Astor Wines & Spirits - Free Tastings & Events" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  
  <div id="tastingPage" class="info-page">
    <h1>Free Tastings</h1>
       
   <div style="padding: 5px;"> 
    <img src="images/general/tastings.png" alt="" style="float: right;" />
    We love to let you know what we know by teaching and tasting.<br />
    Here are some scheduled events that will be fun and informative.<br />
    Take advantage of these premier tastings at Astor's Landmark Location - 399 Lafayette at 4th Street.
    <br /><br />
    Aside from the free tastings, enjoy a 15% discount on any wine that's poured, the day of tasting.
    <br /><br />
   </div> 
    <asp:DataList ID="datEvents" runat="server" Width="100%">
      <ItemTemplate>
          <h4 class="date"><strong><%# DataBinder.Eval(Container.DataItem, "sMonth") %></strong><%# DataBinder.Eval(Container.DataItem, "sDay") %>  </h4>
          <div class="tastingRow clearfix">
                    
          <div>
            <h2><asp:Literal ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dw")& ", " & DataBinder.Eval(Container.DataItem, "sEventStart")%>' /></h2>
            <h3><asp:Label ID="lblEventTitle" runat="server" CssClass="tastingTitle" Text='<%# DataBinder.Eval(Container.DataItem, "sEventName") %>' /></h3>
            <asp:Label ID="lblTime" runat="server" CssClass="tastingTime" Text='<%# DataBinder.Eval(Container.DataItem, "sTime") %>' />
            <br />
            <asp:Label ID="lblDesc" runat="server" CssClass="tastingDesc" Text='<%# DataBinder.Eval(Container.DataItem, "sEventDescription") %>' />
          </div>
          
          <asp:PlaceHolder ID="featuredItems" runat="server">       
              <div> 
                <br /> 
                <h4>Featuring:</h4>
                <div class="tastingFeaturing"><asp:PlaceHolder ID="featuringItems" runat="server" /></div>
              </div>
          </asp:PlaceHolder>    
        </div> <!-- tastingRow -->
      </ItemTemplate>
      
      <AlternatingItemTemplate>
        <h4 class="date"><strong><%# DataBinder.Eval(Container.DataItem, "sMonth") %></strong><%# DataBinder.Eval(Container.DataItem, "sDay") %></h4>
        <div class="tastingRowAlt">
          
            <div>
            <h2><asp:Literal ID="lblDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "dw")& " " & DataBinder.Eval(Container.DataItem, "sEventStart")%>' /></h2>
            <h3><asp:Label ID="lblEventTitle" runat="server" CssClass="tastingTitle" Text='<%# DataBinder.Eval(Container.DataItem, "sEventName") %>' /></h3>
            <asp:Label ID="lblTime" runat="server" CssClass="tastingTime" Text='<%# DataBinder.Eval(Container.DataItem, "sTime") %>' />
            <br />
            <asp:Label ID="lblDesc" runat="server" CssClass="tastingDesc" Text='<%# DataBinder.Eval(Container.DataItem, "sEventDescription") %>' />
          </div>
          
          <asp:PlaceHolder ID="featuredItems" runat="server">
          <div>
            <br /> 
            <h4>Featuring:</h4>
            <div class="tastingFeaturing"><asp:PlaceHolder ID="featuringItems" runat="server" /></div>
          </div>
          </asp:PlaceHolder>
        </div> <!-- .tastingRowAlt -->
      </AlternatingItemTemplate>
        <SeparatorStyle CssClass="tasting-event-border" />
    </asp:DataList>
  </div>   
</asp:Content>