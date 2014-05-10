<%@ Page Language="VB" MasterPageFile="~/as_checkout.master" AutoEventWireup="false" CodeFile="AstorAddEditCreditCard.aspx.vb" Inherits="secure_AstorAddEditCreditCard" title="Untitled Page" EnableEventValidation="false" %>

<%@ Register Src="../Ucontrols/WUCCreditCardEdit.ascx" TagName="WUCCreditCardEdit"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:WUCCreditCardEdit ID="WUCCreditCardEdit1" runat="server" />
</asp:Content>

