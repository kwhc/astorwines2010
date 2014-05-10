<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rare.aspx.vb" Inherits="rare" MasterPageFile="~/open.master" %>
<asp:Content runat="server" ContentPlaceHolderID="HeadSupplement">
<style>
    .checkboxlist-alt tr td
    {
        font-size: 1.4em;
        padding: 20px;
        vertical-align: middle;
    }
    .checkboxlist-alt tr td label
    {
        margin-left: 6px;
    }
    .checkboxlist-alt tr:nth-child(even) td
    {
        background: #eee;
    }
    .background-block
    {
        margin-right: 1rem;
        margin-bottom: 1rem;
        padding: 3rem;
    }
    .background-white
    {
        background: #fefefe;
    }
</style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="middleContent">
    <div style="width:42%;display:inline-block;vertical-align:top;">
        <div class="background-block background-white">
            <h1 style="text-transform:uppercase;">Rare Items List</h1>
            <p>
            Astor Wines & Spirits receives small allocations of these items each year. They are extremely rare with a very competitive market.
            </p>
        </div>
        <div class="background-block background-white">    
            <h3 class="font-condensed">How it works</h3>
            <p>
            If you would like to be notified when these items arrive and how they can be acquried please:
            </p>
            <ul class="bullets">
                <li>Login</li>
                <li>Select your items of interest</li>
                <li>Click submit</li>
            </ul>
            <p>
            You will be added to our interest list for the items you have selected.
            </p>
            <p class="note">
            Please note:<br/> This does not guarantee you a bottle.
            </p>
        </div>
    </div>
    <div class="background-block background-white" style="display:inline-block;">
        <h3 class="font-condensed">Please select your bottles of interest:</h3>
        <asp:CheckBoxList runat="server" ID="cblItems" CssClass="checkboxlist-alt">
            <asp:ListItem Text="Pappy Van Winkle's Family Reserve 15yr Bourbon" Value="01454" />
            <asp:ListItem Text="Pappy Van Winkle's Family Reserve 20yr Bourbon" Value="00114" />
            <asp:ListItem Text="Pappy Van Winkle's Family Reserve 23yr Bourbon" Value="14756" />
            <asp:ListItem Text="Van Winkle Family Reserve Rye" Value="00825" />
            <asp:ListItem Text="Eagle Rare 17yr Boubon" Value="04423" />
            <asp:ListItem Text="Sazerac 18yr Rye" Value="01478" />
            <asp:ListItem Text="William Larue Weller Bourbon" Value="04324" />
            <asp:ListItem Text="Thomas Handy Rye" Value="17019" />
            <asp:ListItem Text="George T. Stagg Bourbon" Value="11506" />
        </asp:CheckBoxList>
        <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn" />
        <asp:Literal runat="server" ID="litMsg" />
    </div>
    <a href="#successMsg" id="successLaunch"></a>
    <div id="successMsg" class="modal" style="text-align: center;">
    <p>My selections were saved successfully.</p>
    <a href="#" rel="modal:close">close</a>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="cphJS">
    <asp:Literal runat="server" ID="litJS" />
</asp:Content>