<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCSignIn.ascx.vb" Inherits="Ucontrols_WUCSignIn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div id="create-account-container">
    <h3>Create an Account</h3>
    <div class="note input-container">* denotes required field</div>
      <asp:ValidationSummary ID="vsSignInNew" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgSignInNew" CssClass="errorMessage" />
      <asp:Label ID="lblError" runat="server" CssClass="errorMessage" Visible="False" />

      <asp:Panel runat="server" DefaultButton="imgbCreateAccount" ID="pnlCreate">

        <div class="input-container">        
            <asp:Label runat="server" ID="lblNewEmail" Text="EMail*: " AssociatedControlID="NewUserName" /><br />
            <asp:TextBox ID="NewUserName" runat="server" Width="300px" TabIndex="1" Wrap="False" MaxLength="100" ValidationGroup="vgSignInNew" Placeholder="username@gmail.com" CssClass="grey" />
            <asp:RequiredFieldValidator ID="rfvNewEmailAddress" runat="server" ControlToValidate="NewUserName" CssClass="errorMessage" ErrorMessage="Missing Email Address!" ValidationGroup="vgSignInNew" Display="Dynamic" Width="0px"><asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
        </div>

        <div class="input-container">        
            <asp:Label runat="server" ID="lblVerifyNewEmail" Text="Verify EMail*: " AssociatedControlID="VerifyNewUserName" />
            <asp:TextBox ID="VerifyNewUserName" runat="server" Width="300px" TabIndex="2" Wrap="False" MaxLength="100" ValidationGroup="vgSignInNew" AutoCompleteType="Disabled" CssClass="grey" />
            <asp:CompareValidator ID="cvEmailAddress" runat="server" ControlToCompare="NewUserName" ControlToValidate="VerifyNewUserName" ErrorMessage="Email Addresses do not match!" ValidationGroup="vgSignInNew" Display="Dynamic" CssClass="errorMessage" Width="0px"><asp:Image ID="imgcvEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvVerifyNewEmailAddress" runat="server" ControlToValidate="VerifyNewUserName" CssClass="errorMessage" ErrorMessage="Missing Verify Email Address!" ValidationGroup="vgSignInNew" Display="Dynamic" Width="0px"><asp:Image ID="imgrfvVerifyNewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
        </div>
        
        <div class="input-container">
            <asp:Label runat="server" ID="lblNewPassword" Text="Password*: " AssociatedControlID="NewPassword" />
            <div class="note">Password length must be 6&nbsp;- 10 characters and<br /> must include one numeric digit</div>
            <asp:TextBox ID="NewPassword" runat="server" Width="300px" TextMode="Password" TabIndex="3" Wrap="False" MaxLength="10" ValidationGroup="vgSignInNew" CssClass="grey" />
            <asp:RegularExpressionValidator ID="revNewPassword" runat="server" ControlToValidate="NewPassword" ErrorMessage="Invalid Password!" ValidationExpression="^.{6,10}$" ValidationGroup="vgSignInNew" CssClass="errorMessage" Display="dynamic" Width="0px"><asp:Image ID="imgrevnewPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="NewPassword" ErrorMessage="Missing Password!" ValidationGroup="vgSignInNew" CssClass="errorMessage" Display="dynamic" Width="0px"><asp:Image ID="imgrfvNewPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
        </div>

        <div class="input-container">
            <asp:Label runat="server" ID="lblVerifyNewPassword" Text="Verify Password*: " AssociatedControlID="VerifyNewPassword" />
            <asp:TextBox ID="VerifyNewPassword" runat="server" Width="300px" TextMode="Password" TabIndex="4" Wrap="False" MaxLength="10" ValidationGroup="vgSignInNew" CssClass="grey" />
            <asp:CompareValidator ID="cvPasswords" runat="server" ControlToCompare="NewPassword" ControlToValidate="VerifyNewPassword" ErrorMessage="Passwords do not match!" ValidationGroup="vgSignInNew" CssClass="errorMessage" Width="0px"><asp:Image ID="imgcvPasswords" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvVerifyNewPassword" runat="server" ControlToValidate="VerifyNewPassword" ErrorMessage="Missing Verify Password!" ValidationGroup="vgSignInNew" CssClass="errorMessage" Width="0px"><asp:Image ID="imgrfvVerifyNewPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
        </div>

        <div class="input-container"><asp:CheckBox ID="PersistNew" runat="server" Text=" Remember Me" TabIndex="5" Checked="True" /></div>

        <div class="input-container"><asp:CheckBox ID="chkEmailNewsletterAdd" runat="server" Text=" I would like to receive emails about upcoming Sales, Free Tastings and Special Offers from <b>Astor Wines & Spirits.</b>" TabIndex="6" Checked="True" /></div>
        
        <div class="input-container"><asp:CheckBox ID="chkEmailNewsletterACAdd" runat="server" Text=" I would like to receive emails including upcoming events, special offers and exclusive content from <b>Astor Center.</b>" TabIndex="6" Checked="True" /></div>
      
        <asp:ImageButton ID="imgbCreateAccount" runat="server" ImageUrl="~/images/as_createaccount.gif" TabIndex="7" ValidationGroup="vgSignInNew" />
      </asp:Panel>
</div> <!-- #create-account-container -->  

<div id="log-in-container">
  <asp:ValidationSummary ID="vsSignIn" runat="server" HeaderText="Please correct the following errors:" ValidationGroup="vgSignIn" CssClass="errorMessage" />
  <asp:Label ID="lblReturningError" runat="server" CssClass="errorMessage" Visible="False" />
        
  <asp:Panel runat="server" DefaultButton="imgbSignIn" ID="pnlLogIn">

    <div class="input-container">
        <asp:Label runat="server" ID="lblEmail" Text="Email:" AssociatedControlID="UserName" /><br />
        <asp:TextBox ID="UserName" runat="server" Width="300px" TabIndex="8" Wrap="False" MaxLength="100" ValidationGroup="vgSignIn" CssClass="grey" Placeholder="username@gmail.com" />
        <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ControlToValidate="UserName" CssClass="errorMessage" ErrorMessage="Missing Email Address!" ValidationGroup="vgSignIn" Width="0px" Display="dynamic"><asp:Image ID="imgrfvEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
    </div>

    <div class="input-container">
        <asp:Label runat="server" ID="lblPassword" Text="Password:" AssociatedControlID="Password" /><br />
        <asp:TextBox ID="Password" runat="server" Width="300px" TextMode="Password" TabIndex="9" Wrap="False" MaxLength="10" ValidationGroup="vgSignIn" CssClass="grey" />
        <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="Password" ErrorMessage="Invalid Password!" ValidationExpression="^.{6,10}$" ValidationGroup="vgSignIn" CssClass="errorMessage" Width="0px" Display="dynamic"><asp:Image ID="imgrevPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="Password" ErrorMessage="Missing Password!" ValidationGroup="vgSignIn" CssClass="errorMessage" Width="0px" Display="dynamic"><asp:Image ID="imgrfvPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator>
    </div>

    <div class="input-container"><asp:CheckBox ID="Persist" runat="server" Text=" Remember Me" TabIndex="11" Checked="True" /></div>

    <div class="input-container"><asp:ImageButton ID="imgbSignIn" runat="server" ImageUrl="~/images/as_signinnow.gif" TabIndex="10" ValidationGroup="vgSignIn" /></div>

    <div id="forgotPassword">

        <h4>Forgot your password?</h4>

        <!--<a href="/SendNewEmail.aspx" class="lightwindow" >New Email</a>-->
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkbNewEmail" 
            DisplayModalPopupID="ModalPopupExtender1" Enabled="True">
        </cc1:ConfirmButtonExtender>
      
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="btnCancel" 
            OkControlID="btnOkay" TargetControlID="lnkbNewEmail" PopupControlID="panel1" BackgroundCssClass="ModalPopupBG">
        </cc1:ModalPopupExtender>
      
        <asp:panel id="Panel1" style="display: none;" runat="server">
            <div class="ModalPopup">
                <div class="PopupHeader" id="PopupHeader">Click OK to RESET your password</div>
                <div class="PopupBody">
                    <p>Note that we email it immediately but your email provider may not pick it up right away. Each
                time you request a new password the password is reset to a different one.  Please click only once.</p>
                </div>
                <div class="Controls">
                    <input id="btnOkay" type="button" value="OK - Reset" />
                    <input id="btnCancel" type="button" value="Cancel" />
                </div>
            </div>
        </asp:panel>

        <p><asp:LinkButton ID="lnkbNewEmail" runat="server" Text="Click Here" /> to have a new password sent to your email.*</p>
        
        <div class="note"> 
          <p><strong>*NOTE:</strong> Please <strong>click only ONCE</strong> - we send it immediately but your email provider may not pick it up right away. Each
          time you click the password is reset to a different password.</p>
        </div>
        
    </div> <!-- #forgotPassword -->
      
  </asp:Panel>
  <input id="ReturnUrl" runat="server" name="ReturnUrl" type="hidden" value="~/Default.aspx" />
</div>
