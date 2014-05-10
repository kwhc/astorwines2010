<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="testimonials.aspx.vb" Inherits="Testimonials" title="Testimonials | Astor Wines & Spirits" %>

<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
    <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="" class="">                
        <div class="info-page shop-info">
            <h1 style="text-align:center;">What People Are Saying About Us</h1>
        </div>    
         <asp:Repeater runat="server" ID="rptPress">
            <ItemTemplate>
                <div runat="server" id="divTitle" class="info-page" style="color:#fdfdfd;text-align:center;">
                    <asp:Literal runat="server" ID="litIcon" />
                    <h3 style="font-weight:600;text-transform:uppercase;"><%#Eval("title")%></h3>
                    <hr style="width:6rem;border-color:#fdfdfd;border-style:solid;border-width:2px;margin-top:2rem;margin-bottom:2rem;text-align:center;" align="center" />
                    <div style=""><%#Eval("source")%><asp:Literal runat="server" ID="litTest" /></div>
                </div>
                <div class="info-page" style="vertical-align:top;text-align:center;">
                    <asp:HyperLink runat="server" ID="hypImg" NavigateUrl='<%#Eval("link")%>' ImageUrl='<%#Eval("imgUrl")%>' />
                    <p style="text-align:center;"><%#Eval("body")%></p>
                    <p style="text-align:center;text-transform:uppercase;"><span><a href="<%#Eval("link")%>"><asp:Literal runat="server" ID="litAuthor" /> <%#Eval("source")%> <i class="icon-external-link"></i></a></span></p>
                    <p style="color:#aaa;text-align:center;text-transform:uppercase;"><%#Eval("postDate", "{0:MMMM, dd yyyy}")%></p>
                    
                </div>
            </ItemTemplate>
         </asp:Repeater>
            
    </div>
</asp:Content>