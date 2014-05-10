<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCGlossaryMain.ascx.vb" Inherits="Ucontrols_WUCGlossaryMain" %>

<%@ Register Src="~/ucontrols/wucglossaryentryofday.ascx" TagName="WUCEntryOfDay" TagPrefix="uc01" %>
<%@ Register Src="~/Ucontrols/WUCGlossaryRelated.ascx" TagName="WUCRelated" TagPrefix="uc02" %>

<div id="glossaryMain" class="glossary">
    <asp:Panel ID="glosSearch" DefaultButton="btnSearch" runat="server">
        <div class="search-container">
            <asp:TextBox ID="glossarySearch" Width="450px" Height="42px" CssClass="txtGlossarySearch grey" runat="server" />
            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/buttons/btn_searchGlass.png" ToolTip="Click to start your search" CssClas="btnGlossarySearch" />
        </div>
    </asp:Panel>
    <div style="float: right; margin-left: 1em;"><img src="images/glossary/glossary.jpg" alt="" /></div>
    <asp:PlaceHolder ID="headerContentFirst" runat="server">
    </asp:PlaceHolder>
    <asp:placeholder ID="headerContentSearchResults" runat="server">
      <div>
        <span class="msgNoSearchResults"><asp:Literal ID="noResults" runat="server" Text="Sorry, no results found." /></span>
        <asp:Repeater ID="searchResults" runat="Server">
          <HeaderTemplate>
          <h2>Multiple results found:</h2>
            <ul>
          </HeaderTemplate>
          <ItemTemplate>
            <li>
              <asp:LinkButton ID="btnSearchTerm" CommandName="startSearch" CommandArgument='<%# databinder.eval(container.dataitem, "iRowID") %>' runat="server"><%# rtrim(databinder.eval(container.dataitem, "sTerm")) %></asp:LinkButton>
            </li>A
          </ItemTemplate>
          <FooterTemplate>
            </ul>
          </FooterTemplate>
        </asp:Repeater>
      </div>
    </asp:placeholder>
    
    <asp:PlaceHolder ID="termResult" runat="server">
        <!-- BEGIN ENTRY -->
      <div>
        <h2><asp:Literal ID="resultTitle" runat="server" /></h2>
        <div>
          <asp:Literal ID="resultDesc" runat="server" />
        </div>
      </div>
      <!-- END ENTRY -->
      <div>
        <uc02:WUCRelated ID="relatedItems" runat="server" Visible="false" />
      </div>
    </asp:PlaceHolder>

      <uc01:WUCEntryOfDay ID="EntryOfDay" runat="server" />

</div>