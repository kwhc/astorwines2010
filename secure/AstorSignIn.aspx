<%@ Page Language="VB" MasterPageFile="~/noColumns.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorSignIn.aspx.vb" Inherits="AstorSignIn" title="Sign In | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCSignIn.ascx" TagName="signIn" TagPrefix="awSgn" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="signIn" class="clearfix">

    <h1>Sign In</h1>

    <div>
      <awSgn:signIn ID="WUCSignIn1" runat="server" />
    </div>

  </div>
</asp:Content>  