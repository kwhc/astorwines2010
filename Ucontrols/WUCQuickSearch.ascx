<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCQuickSearch.ascx.vb" Inherits="Ucontrols_WUCQuickSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
  <div id="quickSearch">
      
      <input type="hidden" id="SelectedReceiver" runat="server" />
      <cc1:AutoCompleteExtender 
        ID="aceLookUp" 
        runat="server"  
        MinimumPrefixLength="2" 
        ServiceMethod="GetAutoCompleteList" 
        TargetControlID="txt_Search"
        CompletionInterval="1"
        EnableCaching="true"
        CompletionSetCount="20" 
        BehaviorID="AC1" 
        Enabled="True"  
        CompletionListElementID="ACE1"
        CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem" 
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
        ShowOnlyCurrentWordInCompletionListItem="True" 
        ServicePath="~/WSLookUp.asmx" OnClientItemSelected="SetSelectedValue"> 
      </cc1:AutoCompleteExtender>
      
      <cc1:TextBoxWatermarkExtender ID="tbwmeSearch" runat="server" TargetControlID="txt_Search" 
      WatermarkText="Search by Keywords or Item #" WatermarkCssClass="watermark white">
      </cc1:TextBoxWatermarkExtender>
     
      <div id="processingSearch">
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
          AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="100">
              <ProgressTemplate>
                  <img alt="" src="../images/general/processing.gif" id="imgProcess" width="25px" />
              </ProgressTemplate>
          </asp:UpdateProgress>
      </div>
     
      <asp:TextBox ID="txt_Search" runat="server" MaxLength="100" TabIndex="1" Width="320px" CssClass="white" />
      
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <asp:ImageButton ID="imbbSearchQS" runat="server" ImageUrl="../images/general/btn_quickSearchGo.png" ToolTip="Click to Submit Search" ImageAlign="Top" CssClass="searchButton" />
        </ContentTemplate>
      </asp:UpdatePanel>
         
      <br />
      
      <asp:Label ID="lblError" runat="server" Visible="False" CssClass="lblError" />
      
  </div>
  
 <%-- <div>
    <asp:HyperLink ID="advancedSearch" runat="Server" />
    <asp:Label CssClass="searchExpl" ID="explanation" runat="server" />    
  </div> --%> 

<script type="text/javascript">
    
    function SetSelectedValue(source, eventArgs) {
        var mySplitResult = eventArgs.get_value().split("(");
        
        document.getElementById("<%= txt_Search.ClientID %>").value = trim(mySplitResult[0]);
        document.getElementById("<%= imbbSearchQS.ClientID %>").click();
        
    }
    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    
    function changeimage()
    {
        document.getElementById("<%= imbbSearchQS.ClientID %>").src = "processing.gif";
    }
    </script>
 