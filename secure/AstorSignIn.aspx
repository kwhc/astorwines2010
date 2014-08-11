<%@ Page Language="VB" MasterPageFile="~/noColumns.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="AstorSignIn.aspx.vb" Inherits="AstorSignIn" title="Sign In | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCSignIn.ascx" TagName="signIn" TagPrefix="awSgn" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="signIn" style="padding-top:2rem;text-align:center;">

    <div class="clearfix" style="display:inline-block;margin:0 auto;">
      <awSgn:signIn ID="WUCSignIn1" runat="server" />
    </div>

  </div>
</asp:Content>  