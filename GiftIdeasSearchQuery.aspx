<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" CodeFile="GiftIdeasSearchQuery.aspx.vb" Inherits="GiftIdeasSearchQuery" title="Astor Wines & Spirits - Gift Ideas Search Query" EnableEventValidation="false" %>

<%@ Register Src="Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc1" %>
<%@ Register Src="Ucontrols/WUCTouts1.ascx" TagName="WUCTouts1" TagPrefix="uc2" %>
<%@ Register Src="Ucontrols/WUCEmailSignUp.ascx" TagName="WUCEmailSignUp" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCFeatures.ascx" TagName="WUCFeatures" TagPrefix="uc4" %>
<%@ Register Src="Ucontrols/WUCGiftSearch.ascx" TagName="WUCGiftSearch" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMainLeft" Runat="Server">
  
    <uc5:WUCGiftSearch ID="WUCGiftSearch1" runat="server" />
    <uc4:WUCFeatures ID="WUCFeatures1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMiddle" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 625px">
        <tr><td align="left" valign="top" style="height: 83px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td style="width: 100%; height: 100%;" valign="top">
                            <asp:Image ID="imgGiftIdeasHd" runat="server" ImageUrl="~/images/as_giftideas_hd.gif" />
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%" >
                                    <tr>
                                        <td align="left" valign="top" style="height: 16px">
                                            <asp:Label ID="Label1" runat="server" CssClass="featureshead" Text="Select each value for each question that represents what type of gift you want to give"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td >
                                            </td>
                                            </tr>
                                            <tr>
                                            <td >
                                            </td>
                                            </tr>
                                            <tr>
                                            <td >
                                            </td>
                                            </tr>
                                            <tr>
                                            <td >
                                            </td>
                                            </tr>
                                            <tr>
                                            <td >
                                            </td>
                                            </tr>
                                            <tr>
                                            <td >
                                            </td>
                                            </tr>
                                            <tr>
                                            <td >
                                            </td>
                                            </tr>
                                            <tr>
                                            <td style="height: 15px" >
                                            </td>
                                            </tr>
                                        </table>
                                <asp:ImageButton ID="imgbSubmitGiftQuery" runat="server" ImageUrl="~/images/as_giftideas_submitgiftquery_icon.gif" /></td>
                                        </tr>
        </table>
        </td>
        </tr>
        </table>
                                        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMainRight" Runat="Server">
<uc1:WUCShoppingCart ID="WUCShoppingCart1" runat="server" />
    <uc2:WUCTouts1 ID="WUCTouts1_1" runat="server" />
    <uc3:WUCEmailSignUp ID="WUCEmailSignUp1" runat="server" />
</asp:Content>

