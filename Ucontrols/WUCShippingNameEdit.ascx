<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCShippingNameEdit.ascx.vb" Inherits="Ucontrols_WUCShippingNameEdit" %>

<%@ Register TagPrefix="igmisc" Namespace="Infragistics.WebUI.Misc" Assembly="Infragistics35.WebUI.Misc.v11.1, Version=11.1.20111.1006, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>


<div>
  <div style="width: 270px;">
        <div class="control-group">
            <asp:Label ID="lblFirstName" runat="server" Text="First Name: *" AssociatedControlID="Firstname" />
            <div class="signInTxt">
              <asp:TextBox ID="Firstname" runat="server" MaxLength="100" Width="240px" CssClass="grey" AutoCompleteType="FirstName" TabIndex="3" />
              <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="Firstname" ErrorMessage="First Name Required" ValidationGroup="vgShipping" display="dynamic"><asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="lblLastname" runat="server" Text="Last Name: *" AssociatedControlID="Lastname" />
            <div class="signInTxt">
              <asp:TextBox ID="Lastname" runat="server" MaxLength="100" Width="240px" CssClass="grey" AutoCompleteType="LastName" TabIndex="4" />
              <asp:TextBox ID="Idt" runat="server" MaxLength="6" Visible="False" Wrap="False"></asp:TextBox>
              <asp:TextBox ID="Ids" runat="server" MaxLength="6" Visible="False" Wrap="False"></asp:TextBox>
              <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="Lastname" ErrorMessage="Last Name Required" ValidationGroup="vgShipping" Display="dynamic"><asp:Image ID="Image1" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="control-group">    
            <asp:Label ID="lblCOmpany" runat="server" Text="Company Name:" AssociatedControlID="Company" />
            <div class="signInTxt">
              <asp:TextBox ID="Company" runat="server" MaxLength="150" Width="240px" CssClass="grey" AutoCompleteType="company" TabIndex="5" />
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="lblAddress" runat="server" Text="Address: *<b>(PO Boxes not permitted)</b>" AssociatedControlID="Address" />
              <div class="signInTxt">
                  <asp:TextBox ID="Address" runat="server" MaxLength="100" Width="240px" CssClass="grey"
                      AutoCompleteType="HomeStreetAddress" TabIndex="6" />
                  <asp:CustomValidator ID="cvAddress" runat="server" ValidationGroup="vgShipping" ErrorMessage="PO Boxes not permitted!"
                      ControlToValidate="Address" ClientValidationFunction="CheckPOBox">
                      <asp:Image ID="Image9" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:CustomValidator>
                  <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="Address"
                      ErrorMessage="Address Required" ValidationGroup="vgShipping" Display="dynamic">
                      <asp:Image ID="Image2" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
             </div>
        </div>


        <div class="control-group">
            <asp:Label ID="lblApt" runat="server" Text="Apartment" AssociatedControlID="Apt" />
            <div class="signInTxt">
              <asp:TextBox ID="Apt" runat="server" MaxLength="25" Width="240px" CssClass="grey" TabIndex="7" />
            </div>
        <%--    <igmisc:WebAsyncRefreshPanel ID="warpBilling" runat="server" TriggerControlIDs="*$Zipcode" TriggerPostBackIDs="*$City,*$ddlState" Height="100px" Width="280px">--%>
        </div>

        <div class="control-group clearfix">
          <div style="float: left; width: 100px;">
            <asp:Label ID="lblZip" runat="server" Text="Zip Code: *" AssociatedControlID="ZipCode" />
            <div class="signInTxt">
              <asp:TextBox ID="Zipcode" runat="server" MaxLength="10" Width="50px" AutoPostBack="True" TabIndex="8" AutoCompleteType="homezipcode" CssClass="grey"></asp:TextBox>
              <asp:RequiredFieldValidator ID="requiredZip" runat="server" ControlToValidate="Zipcode" ErrorMessage="Zip Code Required!" ValidationGroup="vgShipping" Display="static"><asp:Image ID="Image8" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="revZipcode" runat="server" ControlToValidate="Zipcode" ErrorMessage="Zip Code Required!" ValidationExpression="\d{5}(-\d{4})?" ValidationGroup="vgShipping" Display="Static"><asp:Image ID="Image3" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
            </div>
          </div>
          
          <div style="float: left;">
            <asp:Label ID="lblState" runat="server" Text="State: *" AssociatedControlID="ddlState" />
            <div class="signInTxt" style="padding-right: 2px;">
              <asp:DropDownList ID="ddlState" runat="server" Width="130px" AppendDataBoundItems="True" Enabled="False">
                <asp:ListItem>State Code</asp:ListItem>
              </asp:DropDownList>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ddlState" ErrorMessage="State Required!" ValidationExpression="^[A-Z][A-Z]" ValidationGroup="vgShipping" Display="Static"><asp:Image ID="Image5" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
            </div>
          </div>
        </div>
                
          <asp:Label ID="lblInvalidZip" CssClass="errorMessage" runat="server" Text="Invalid Zipcode For Shipping<br />" Visible="False" />
          
        <div class="control-group">
          <asp:Label ID="lblCity" runat="server" Text="City: *" AssociatedControlID="ddlCity" />
          <div class="signInTxt">
              <asp:DropDownList ID="ddlCity" Width="240px" CssClass="grey" runat="server"></asp:DropDownList> 
              <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity" ErrorMessage="City Required!" ValidationGroup="vgShipping" Display="dynamic"><asp:Image ID="Image4" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
          </div>
        <%--    </igmisc:WebAsyncRefreshPanel>--%>
        </div>

        <div class="control-group">
            <asp:Label ID="lblSCross" runat="server" Text="Cross Streets:" AssociatedControlID="txtscross" />
            <div class="signInTxt">
                <asp:TextBox ID="txtscross" runat="server" MaxLength="50" Width="240px" CssClass="grey" TabIndex="9" />
            </div>
        </div>

        <div class="control-group">
            <asp:Label ID="lblShippingEmail" runat="server" Text="Shipping Email (if different then billing):" AssociatedControlID="txtShippingEmail" /><br />
            <asp:LinkButton runat="server" Text="Why do I need this?" CssClass="help" Visible="true" />
            <div class="signInTxt">
                <asp:TextBox ID="txtShippingEmail" runat="server" MaxLength="100" Width="240px" CssClass="grey" TabIndex="9" />
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" ID="lblDayPhone" Text="Day Phone: * <i>ex. 2126747500</i>" AssociatedControlID="txtDayPhone" />
            <div class="signInTxt">
                <asp:TextBox ID="txtDayPhone" runat="server" MaxLength="10" Width="240px" CssClass="grey" TabIndex="10" AutoCompleteType="homephone" />
                <asp:RequiredFieldValidator ID="rfvDayphone" runat="server" ControlToValidate="txtDayPhone" ErrorMessage="Day Phone Required!" ValidationGroup="vgShipping" Display="dynamic"><asp:Image ID="Image6" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revDayPhone" runat="server" ControlToValidate="txtDayPhone" ErrorMessage="Day Phone Must be all numeric!" ValidationExpression="\d{10}" ValidationGroup="vgShipping" Display="dynamic"><asp:Image ID="Image7" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="control-group">
            <asp:Label runat="server" ID="lblEveningPhone" Text="Evening Phone: <i>ex. 2126747500</i>" AssociatedControlID="txtEveningPhone" />
            <div class="signInTxt">
                <asp:TextBox ID="txtEveningPhone" runat="server" MaxLength="10" Width="240px" CssClass="grey" TabIndex="11" />
            </div>
        </div>

        <div class="control-group">
            <asp:CheckBox ID="chkDefaultShippingAddress" Text=" Make Default Shipping Address" runat="server" TabIndex="12" />
        </div>
    
    </div>

      <h3>Continue your checkout to save this address.</h3>
    
     
</div>