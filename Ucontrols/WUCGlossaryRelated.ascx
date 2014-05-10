<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCGlossaryRelated.ascx.vb" Inherits="Ucontrols_WUCGlossaryRelated" %>

<%@ Register Src="~/Ucontrols/WUCGlossarySingleRelated.ascx" TagName="WUCSingleRelated" TagPrefix="uc01" %>

<div id="glossaryRelated">
  <h2 style="padding: 2px 0px 3px 0px;">You May Enjoy...</h2>
  <div style="padding: 5px;">
    <div style="float: left; padding-right: 10px;"> 
      <uc01:WUCSingleRelated ID="WUCSingleRelated1" runat="server" />
    </div>
    <div style="float: left; padding-right: 10px;">
      <uc01:WUCSingleRelated ID="WUCSingleRelated2" runat="server" />
    </div>
    <div style="float: left;">
      <uc01:WUCSingleRelated ID="WUCSingleRelated3" runat="server" />
    </div> 
    <div style="clear: left;"></div>
  </div>
</div>