<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" AutoEventWireup="false" CodeFile="GiftIdeasSearch.aspx.vb" Inherits="GiftIdeasSearch" title="Astor Wines & Spirits - Gift Ideas Search" EnableEventValidation="false" %>

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
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td bgcolor="#613914" >
                                                        <asp:Image ID="img_basepage1_hd" runat="server" ImageUrl="~/images/as_giftideas1_hd.gif" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%" bgcolor="#613914" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 25px">
                                                            <tr>
                                                                
                                                                <td valign="top">
                                                                    <asp:Label ID="lblbasepage1_1" runat="server" ForeColor="#F7F0DD" Text="Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Pellentesque placerat lectus sed tortor. Etiam a turpis ut orci hendrerit vehicula. Nam vel sapien. Aenean vitae elit non lacus tincidunt porta. Nunc non purus. In hac habitasse platea dictumst. Aenean mattis congue nibh."
                                                                        Width="284px" CssClass="10ptsize"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#613914" >
                                                        <asp:ImageButton ID="imgBasePage1LearnMore" runat="server" ImageUrl="~/images/as_wines1_learnmore.gif" /></td>
                                                </tr>
                                    
                                            </table>
                                         </td>   
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                    
                        <tr> <td style="height: 10px;" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" bgcolor="#eeeeee">
                                <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/as_giftideas_2_1.gif" NavigateUrl="~/GiftIdeasSearchQuery.aspx">HyperLink</asp:HyperLink></td>
                        </tr>
                        <tr> <td style="height: 10px;" valign="top"></td>
                        </tr>
                        
                    </table>
                    <table border="1" cellpadding="0" cellspacing="0" style="width: 100%" bordercolor="#cccccc">
                        <tr>
                            <td align="left" style="width: 50%" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" bordercolor="#cccccc">
                                    <tr>
                                        <td style="width: 40%" valign="top">
                                            <asp:Image ID="imgGiftIdeas31" runat="server" ImageUrl="~/images/as_giftideas_3_1.gif" BorderStyle="None" /></td>
                                        <td style="width: 60%" valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="bottom">
                                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/as_giftideas_3_hd.gif" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 83px; height: 64px" valign="top">
                                                        <asp:Label ID="lblHP3_2" runat="server" Text="Something about NYC here if you ship ground, totarem Learn more about here if you ship ground, totarem totarem." Width="164px"></asp:Label></td>
                                                </tr>
                                                
                                            </table>
                                            <asp:ImageButton ID="imgHP3LearnMore" runat="server" ImageUrl="~/images/as_giftideas_3_learnmore.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left" style="width: 50%" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" bordercolor="#cccccc">
                                    <tr>
                                        <td style="width: 40%" valign="top">
                                            <asp:Image ID="imgGiftIdeas41" runat="server" ImageUrl="~/images/as_giftideas_4_1.gif" /></td>
                                        <td valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Image ID="Image7" runat="server" ImageUrl="~/images/as_giftideas_4_hd.gif" ImageAlign="Top" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 83px; height: 64px" valign="top">
                                                        <asp:Label ID="lblHP4_2" runat="server" Text="Something about NYC here if you ship ground, totarem Learn more about here if you ship ground, totarem totarem." Width="164px"></asp:Label></td>
                                                </tr>
                                             
                                            </table>
                                                        <asp:ImageButton ID="imgHP4LearnMore" runat="server" ImageUrl="~/images/as_giftideas_4_learnmore.gif" /></td>
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

