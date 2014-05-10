<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" CodeFile="GiftIdeasSearchBlank.aspx.vb" Inherits="GiftIdeasSearchBlank" title="Astor Wines & Spirits - Gift Ideas Search" EnableEventValidation="false" %>

<%@ Register Src="Ucontrols/WUCShoppingCart.ascx" TagName="WUCShoppingCart" TagPrefix="uc1" %>
<%@ Register Src="Ucontrols/WUCTouts1.ascx" TagName="WUCTouts1" TagPrefix="uc2" %>
<%@ Register Src="Ucontrols/WUCEmailSignUp.ascx" TagName="WUCEmailSignUp" TagPrefix="uc3" %>
<%@ Register Src="Ucontrols/WUCFeatures.ascx" TagName="WUCFeatures" TagPrefix="uc4" %>
<%@ Register Src="Ucontrols/WUCGiftSearch.ascx" TagName="WUCGiftSearch" TagPrefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMainLeft" Runat="Server">
    &nbsp;<uc4:WUCFeatures ID="WUCFeatures1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMiddle" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 625px">
        <tr><td align="left" valign="top">
       <table border="0" cellpadding="0" cellspacing="0" >
                <tr><td align="left" valign="top">
                         <asp:Image ID="imgBasePageHd" runat="server" ImageUrl="~/images/as_giftideas_hd.gif" /></td></tr>
                        <tr>
                            <td valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 625px;">
                                    <tr>
                                        <td align="left" valign="top" bgcolor="#613914" >
                                            <asp:Image ID="img_basepage_1_1" runat="server" ImageUrl="~/images/as_giftideas_1_1.gif" /></td>
                                        <td align="left" valign="top"  bgcolor="#613914">
                                            <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 25px">
                                                <tr>
                                                    <td bgcolor="#613914" style="height: 142px" >
                                                        <asp:Image ID="img_basepage1_hd" runat="server" ImageUrl="~/images/as_giftideas1_hd.gif" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%" bgcolor="#613914" valign="top">
                                                       
                                                                    <asp:Label ID="lblbasepage1_1" runat="server" ForeColor="#F7F0DD" Text="Check Back Soon...."
                                                                        Width="284px" CssClass="pt14size"></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                    
                                            </table>
                                         </td>   
                                    </tr>
                                </table>
                            </td>
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

