<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCGiftSearch.ascx.vb" Inherits="Ucontrols_WUCGiftSearch" %>
<asp:Panel runat="server" DefaultButton="imbbSubmitSearch" ID="pnlSearch" Width="100%">
<table style="width: 179px;" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td valign="top" bgcolor="#eeeeee" >
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/as_giftideassearch_hd.gif" /></td>
    </tr>
   <tr>
        <td bgcolor="#eeeeee" valign="top">
            <table>
                <tr>
                    <td style="width: 4px; height: 31px;">
                    </td>
                    <td style="height: 31px">
                        <asp:Label ID="Label3" runat="server" CssClass="pt12blsize" Text="Select one criterion or many."></asp:Label><br />
                        <asp:Label ID="Label4" runat="server" CssClass="pt10size"
                                Text="Need some help?  Try our "></asp:Label>
                        <asp:HyperLink ID="hyplSearchTips" CssClass="pt10size" runat="server" NavigateUrl="~/SearchError.aspx">search tips.</asp:HyperLink>
                                
                                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td bgcolor="#eeeeee" valign="top">
            <table border="0" cellpadding="0" cellspacing="0">
               <tr>
                     <td style="width: 575px; height: 25px;">
                    </td><td style="width: 758px" valign="top">
                        <asp:DropDownList ID="ddlType" runat="server" Width="200px" CssClass="dropdown" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True">Choose a Gift Type</asp:ListItem>
                        </asp:DropDownList></td>
                   
                </tr>
                <tr>
                     <td style="width: 575px; height: 25px;">
                    </td><td style="width: 758px" valign="top">
                        <asp:DropDownList ID="ddlPriceRange" runat="server" Width="200px" CssClass="dropdown" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True">Choose a Price Range</asp:ListItem>
                        </asp:DropDownList></td>
                   
                </tr>
                
               
            </table>        
        </td>
    </tr>

    <tr>
        <td bgcolor="#eeeeee" style="width: 220px; height: 36px;" valign=top>
            <asp:ImageButton ID="imbbSubmitSearch" runat="server" ImageUrl="~/images/as_submitSearch.gif" ToolTip="Click to Submit Gift Search"/>
               </td>
    </tr>
    <tr>
        <td bgcolor="#eeeeee" valign="top">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 216px">
                <tr>
                    <td style="width: 12px; height: 19px;">
                    </td>
                    <td valign=top>
            <asp:LinkButton ID="lbutReset" runat="server" CssClass="pt12size">Click here</asp:LinkButton>
            <asp:Label ID="Label2" runat="server" Text=" to reset the search bars." CssClass="pt12size"></asp:Label></td>
                </tr>
                
            </table><br />
        </td>
    </tr>
</table></asp:Panel>
