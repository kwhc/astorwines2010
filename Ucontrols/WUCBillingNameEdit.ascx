<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCBillingNameEdit.ascx.vb" Inherits="Ucontrols_WUCBillingNameEdit" %>

<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>

<asp:Label runat="server" ID="lblFirstName" AssociatedControlID="Firstname" Text="First Name: *" /> 
    <div class="signInTxt">
      <asp:TextBox ID="Firstname" runat="server" MaxLength="100" Width="240px" AutoCompleteType="FirstName" TabIndex="3" CssClass="grey" />
      <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="Firstname" CssClass="errorMessage" ErrorMessage="First Name Required!" ValidationGroup="vgBilling" Display="dynamic"><asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
    </div>

<asp:Label runat="server" ID="lblLastname" AssociatedControlID="Lastname" Text="Last Name: *" /> 
    <div class="signInTxt">
      <asp:TextBox ID="Lastname" runat="server" MaxLength="100" Width="240px" AutoCompleteType="LastName" TabIndex="4" CssClass="grey" />      
      <asp:TextBox ID="IdtNew" runat="server" MaxLength="6" Visible="False" />
      <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="Lastname" CssClass="errorMessage" ErrorMessage="Last Name Required" ValidationGroup="vgBilling" Display="dynamic"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
    </div>

<asp:Label runat="server" ID="lblCompany" AssociatedControlID="Company" Text="Company Name:" /> 
    <div class="signInTxt">
      <asp:TextBox ID="Company" runat="server" MaxLength="150" Width="240px" AutoCompleteType="Company" TabIndex="5" CssClass="grey" />
    </div>

<asp:Label runat="server" ID="lblAddress" AssociatedControlID="Address" Text="Address: *" /> 
    <div class="signInTxt">
      <asp:TextBox ID="Address" runat="server" MaxLength="100" Width="240px" AutoCompleteType="HomeStreetAddress" TabIndex="6" CssClass="grey" />
      <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="Address" CssClass="errorMessage" ErrorMessage="Address Required!" ValidationGroup="vgBilling" Display="dynamic"><asp:Image ID="Image2" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
    </div>

<asp:Label runat="server" ID="lblApt" AssociatedControlID="Apt" Text="Apartment:" /> 
    <div class="signInTxt">
      <asp:TextBox ID="Apt" runat="server" MaxLength="25" Width="240px" TabIndex="7" CssClass="grey" />
    </div>

    <igmisc:WebAsyncRefreshPanel ID="warpBilling" runat="server" TriggerControlIDs="*$Zipcode" TriggerPostBackIDs="*$City,*$ddlState" Width="280px" CssClass="clearfix">
        <div class="clearfix">
          <div style="width: 100px; float: left;">          
            <asp:Label runat="server" ID="lblZipcode" AssociatedControlID="Zipcode" Text="Zip Code: *" /> 
            <div class="signInTxt">
              <asp:TextBox ID="Zipcode" runat="server" MaxLength="10" Width="50px" AutoCompleteType="HomeZipCode" TabIndex="8" AutoPostBack="True" CssClass="grey" />
              <asp:RequiredFieldValidator ID="requiredZip" runat="server" ControlToValidate="Zipcode" ErrorMessage="Zip Code Required!" ValidationGroup="vgBilling" Display="static" EnableClientScript="false"><asp:Image ID="Image7" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Zipcode" CssClass="errorMessage" ErrorMessage="Zip Code Required!" ValidationExpression="\d{5}(-\d{4})?" EnableClientScript="false" ValidationGroup="vgBilling" Display="static"><asp:Image ID="Image3" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
            </div>
          </div>

          <div style="float: left;">
            <asp:Label runat="server" ID="lblState" AssociatedControlID="ddlState" Text="State: *" />       
            <div class="signInTxt">
              <asp:DropDownList ID="ddlState" runat="server" Width="146px" AppendDataBoundItems="True" Enabled="False">
                <asp:ListItem>State Code</asp:ListItem>
              </asp:DropDownList>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ddlState" CssClass="errorMessage" ErrorMessage="State Required!" ValidationExpression="^[A-Z][A-Z]" EnableClientScript="false" ValidationGroup="vgBilling" Display="static"><asp:Image ID="Image4" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
            </div>
          </div>
          
        </div>      
        
        <asp:Label ID="lblInvalidZip" runat="server" CssClass="errorMessage" Text="Invalid Zipcode<br />" Visible="False" />
        <asp:PlaceHolder ID="showBreak" runat="Server"><div class="break"></div></asp:PlaceHolder>

        <asp:Label runat="server" ID="lblCity" AssociatedControlID="ddlCity" Text="City: *" /> 
        <div class="signInTxt">     
            <asp:DropDownList ID="ddlCity" Width="240px" runat="server" /> 
            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" CssClass="errorMessage" ErrorMessage="City Required!" EnableClientScript="false" ValidationGroup="vgBilling" Display="dynamic"><asp:Image ID="Image5" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
        </div>

    </igmisc:WebAsyncRefreshPanel>

    <asp:Label runat="server" ID="lblDayPhone" AssociatedControlID="txtDayPhone" Text="Day Phone: * <i>ex. 2126747500</i>" /> 
    <div class="signInTxt">
      <asp:TextBox ID="txtDayPhone" runat="server" MaxLength="10" Width="240px" TabIndex="9" CssClass="grey" />
      <asp:RequiredFieldValidator ID="rfvDayphone" runat="server" ControlToValidate="txtDayPhone" CssClass="errorMessage" ErrorMessage="Day Phone Required!" ValidationGroup="vgBilling" Display="dynamic"><asp:Image ID="Image6" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
      <asp:RegularExpressionValidator ID="revDayPhone" runat="server" ControlToValidate="txtDayPhone" CssClass="errorMessage" ErrorMessage="Day Phone Must be all numeric!" ValidationExpression="\d{10}" ValidationGroup="vgBilling" Display="dynamic"><asp:Image ID="Image8" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
    </div>

    <asp:Label runat="server" ID="lblEveningPhone" AssociatedControlID="txtEveningPhone" Text="Evening Phone: <i>ex. 2126747500</i>" /> 
    <div class="signInTxt">
      <asp:TextBox ID="txtEveningPhone" runat="server" MaxLength="10" Width="240px" TabIndex="10" CssClass="grey" />
    </div>