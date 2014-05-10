<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCTouts1.ascx.vb" Inherits="Ucontrols_WUCTouts1" %>

<div align=left><asp:HyperLink ID="hypAstorCenter" runat="server" ImageUrl="~/images/features/astor_center_tout.jpg"
    NavigateUrl="http://www.astorcenternyc.com" Target="_blank">Visit Astor Center</asp:HyperLink></div>

<asp:DataList ID="datlstTouts" runat="server" Width="123px">
    <ItemTemplate>
        <!--<asp:Image ID="imgToutHeader" runat="server" ImageUrl='<%# databinder.eval(container.dataitem, "sHeaderImageLocation") %>' />-->
        
        <table border="0" cellpadding="0" cellspacing="0" style="padding-left: 8px">
        <tr><td><asp:HyperLink ID="hyplFeatureHeader" runat="server" Text='<%# databinder.eval(container.dataitem, "sFeature") %>' NavigateUrl='<%# databinder.eval(container.dataitem, "sLearnMoreURL") %>' 
                                        CssClass="toutshead"></asp:HyperLink>
        <asp:HyperLink ID="hyplFeatures" runat="server" Height="7px" ImageUrl="~/images/features/as_featurespt.gif" NavigateUrl='<%# databinder.eval(container.dataitem, "sLearnMoreURL") %>'
            Width="4px"></asp:HyperLink>
        </td></tr>
            <tr>
                
                <td style="width: 90px;">
                    <table>
                        <tr>
                            <td style="width: 199px;">
                                <asp:Label ID="lblTout" runat="server" Width="133px" Text='<%# databinder.eval(container.dataitem, "sFeatureDesc") %>' CssClass="pt12size"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr><td><br /> <asp:HyperLink ID="hyplLearnMore" runat="server" ImageUrl='<%# databinder.eval(container.dataitem, "sSmImageLocation") %>'>Learn More</asp:HyperLink>
            </td></tr>
            <tr><td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/features/as_touts_line.gif" />
            </td></tr>
        </table>

       
    </ItemTemplate>
</asp:DataList>