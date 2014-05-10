<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCNoResultBottom.ascx.vb" Inherits="Ucontrols_WUCNoResultBottom" %>

<asp:DataList ID="datNoResultsBottom" runat="server" GridLines="Both" RepeatColumns="2" RepeatDirection="Horizontal" Width="625px" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px">
    <ItemTemplate>
        <table cellpadding="0" cellspacing="0" style="width: 100%; border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
                                    <tr>
                                        <td valign="top">
                                            <asp:ImageButton ID="imgb_noresult_1_1" runat="server" ImageUrl="~/images/as_wines_2_1.gif" BorderStyle="None" /></td>
                                        <td  valign="top">
                                            <table border="0" cellpadding="0" cellspacing="0" >
                                                <tr>
                                                    <td  valign="top" style="width: 180px">
                                                        <asp:ImageButton ID="imgb_noresult_1_hd" runat="server" ImageUrl="~/images/as_wines_2_hd.gif" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 180px; height: 64px" valign="top">
                                                        <asp:Label ID="lblnoresult1_1" runat="server" Text="Something about NYC here if you ship ground, totarem Learn more about here if you ship ground, totarem totarem." Width="164px"></asp:Label></td>
                                                </tr>
                                                
                                            </table>
                                            <asp:ImageButton ID="imgb_noresult1_learnmore" runat="server" ImageUrl="~/images/as_LearnMore.gif" /></td>
                                    </tr>
                                </table>
    </ItemTemplate>
</asp:DataList>

