<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="MyAccountEmailAddresses.aspx.vb" Inherits="secure_MyAccountEmailAddresses" title="My Login Info | Astor Wines & Spirits" %>

<%@ Register Src="../Ucontrols/WUCBillingNameEdit.ascx" TagName="WUCBillingNameEdit" TagPrefix="uc6" %>
<%@ Register Src="../Ucontrols/WUCBillingName.ascx" TagName="WUCBillingName" TagPrefix="uc2" %>
<%@ Register Src="../Ucontrols/WUCShippingName.ascx" TagName="WUCShippingName" TagPrefix="uc3" %>
<%@ Register Src="../Ucontrols/WUCCreditCard.ascx" TagName="WUCCreditCard" TagPrefix="uc4" %>
<%@ Register Src="../Ucontrols/WUCCreditCardNoCVV.ascx" TagName="WUCCreditCardNoCVV" TagPrefix="uc5" %>
<%@ Register Src="../Ucontrols/WUCMyAccountNav.ascx" TagName="WUCMyAccountNav" TagPrefix="uc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>
<%@ Register Src="~/Ucontrols/WUCMyAccountNav.ascx" TagName="AccountNavigation" TagPrefix="awNav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
  <div id="myLoginInfo">
    <awNav:AccountNavigation ID="AccountNavigation1" runat="server" />
    <div id="mainContentHeader">
        <h1>My Login Info</h1>
    </div>     
    <div class="accountMaintenanceIntro">
        <asp:Panel runat="server" DefaultButton="imgbEmailNew" ID="pnlLogIn" Width="100%">
        From here you can change your account's login credentials.
        <br /><strong>This will sign you off and you will need to sign in again.</strong>
        <asp:Label ID="Label1" runat="server" Text="&nbsp" CssClass="featureshead" />
        </div>
    
    <br /><br />
    <h2>Change My Email Address</h2>
    <strong>Current Email address:</strong><br />
                <asp:Label ID="lblCurrentEmailAddress" runat="server" Text="abc@abc.com" CssClass="textbox" Height="16px" Width="225px" />
                   <br />
        <asp:ValidationSummary ID="vsEmailNew" runat="server" CssClass="errmsg" HeaderText="Please correct the following errors:"
            ValidationGroup="vgEmailNew" />
        <asp:Label ID="lblEmailError" runat="server" CssClass="errmsg" Text="Error" Visible="False" /><br />
                <strong>* New Email address: 
                    <br />
                </strong><span class="pt10size">(ex. username@aol.com)</span><br />
                <asp:TextBox ID="NewUserName" runat="server" Width="225px" CssClass="textbox" TabIndex="10" Wrap="False" MaxLength="100" ValidationGroup="vgSignInNew" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="revNewEmail" runat="server" ErrorMessage="Invaild Email Address"
                    ValidationExpression="^((([a-z]|[0-9]|!|#|$|%|&|'|\*|\+|\-|/|=|\?|\^|_|`|\{|\||\}|~)+(\.([a-z]|[0-9]|!|#|$|%|&|'|\*|\+|\-|/|=|\?|\^|_|`|\{|\||\}|~)+)*)@((((([a-z]|[0-9])([a-z]|[0-9]|\-){0,61}([a-z]|[0-9])\.))*([a-z]|[0-9])([a-z]|[0-9]|\-){0,61}([a-z]|[0-9])\.(af|ax|al|dz|as|ad|ao|ai|aq|ag|ar|am|aw|au|at|az|bs|bh|bd|bb|by|be|bz|bj|bm|bt|bo|ba|bw|bv|br|io|bn|bg|bf|bi|kh|cm|ca|cv|ky|cf|td|cl|cn|cx|cc|co|km|cg|cd|ck|cr|ci|hr|cu|cy|cz|dk|dj|dm|do|ec|eg|sv|gq|er|ee|et|fk|fo|fj|fi|fr|gf|pf|tf|ga|gm|ge|de|gh|gi|gr|gl|gd|gp|gu|gt| gg|gn|gw|gy|ht|hm|va|hn|hk|hu|is|in|id|ir|iq|ie|im|il|it|jm|jp|je|jo|kz|ke|ki|kp|kr|kw|kg|la|lv|lb|ls|lr|ly|li|lt|lu|mo|mk|mg|mw|my|mv|ml|mt|mh|mq|mr|mu|yt|mx|fm|md|mc|mn|ms|ma|mz|mm|na|nr|np|nl|an|nc|nz|ni|ne|ng|nu|nf|mp|no|om|pk|pw|ps|pa|pg|py|pe|ph|pn|pl|pt|pr|qa|re|ro|ru|rw|sh|kn|lc|pm|vc|ws|sm|st|sa|sn|cs|sc|sl|sg|sk|si|sb|so|za|gs|es|lk|sd|sr|sj|sz|se|ch|sy|tw|tj|tz|th|tl|tg|tk|to|tt|tn|tr|tm|tc|tv|ug|ua|ae|gb|us|um|uy|uz|vu|ve|vn|vg|vi|wf|eh|ye|zm|zw|com|edu|gov|int|mil|net|org|biz|info|name|pro|aero|coop|museum|arpa))|(((([0-9]){1,3}\.){3}([0-9]){1,3}))|(\[((([0-9]){1,3}\.){3}([0-9]){1,3})\])))$" ValidationGroup="vgEmailNew" ControlToValidate="NewUserName" CssClass="errmsg" Width="0px"><asp:Image ID="imgrevEmailnew" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvNewEmailAddress" runat="server" ControlToValidate="NewUserName"
                    CssClass="errmsg" ErrorMessage="Missing Email Address" ValidationGroup="vgEmailNew" Width="0px" ><asp:Image ID="imgrfvnewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator><br />
                    <strong>*
                        Verify Email address:
                        <br />
                    </strong>
                <asp:TextBox ID="VerifyNewUserName" runat="server" Width="225px" CssClass="textbox" TabIndex="11" Wrap="False" MaxLength="100" ></asp:TextBox>
                <asp:CompareValidator ID="cvEmailAddress" runat="server" ControlToCompare="NewUserName"
                    ControlToValidate="VerifyNewUserName" ErrorMessage="Email Addresses do not match!"
                    ValidationGroup="vgEmailNew" CssClass="errmsg" Width="0px"><asp:Image ID="imgcvEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="rfvVerifyNewEmailAddress" runat="server" ControlToValidate="VerifyNewUserName"
                    CssClass="errmsg" ErrorMessage="Missing Verify Email Address" ValidationGroup="vgEmailNew" Width="0px">
                    <asp:Image ID="imgrfvVerifyNewEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator><br />
                    <!--
                    <asp:CheckBox ID="chkEmailNewsletterAdd" runat="server" Checked="True" CssClass="pt10size"
                    Text="Yes, I would like to hear from Astor Wines Online about new products, exclusive online shopping and sample offerings, and specialis events." /><br /> -->
                <asp:ImageButton ID="imgbEmailNew" runat="server" ImageUrl="~/images/as_myaccount_changeemailaddress.icon.gif" ValidationGroup="vgEmailNew" /><br />
              
                </asp:Panel><br />
                
               
                <h2>Change My Password</h2>
                <asp:Panel runat="server" DefaultButton="imgbPasswordNew" ID="Panel1" Width="100%">
                <asp:Label ID="Label2" runat="server" Text="Need to Change Your Password?" CssClass="featureshead"></asp:Label><br />
                <br />
                <strong>* Current Password: 
                    <br />
                </strong><span class="pt10size">(Password length must be between 6 and 10 characters/numbers
                and include at least one numeric digit.)</span><br />
                <asp:TextBox ID="Password" runat="server" Width="225px" TextMode="Password" CssClass="textbox" TabIndex="16" Wrap="False" MaxLength="10" ></asp:TextBox><asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="Password"
                ErrorMessage="Invalid Password" ValidationExpression="^.{6,10}$" ValidationGroup="vgNewPassword" CssClass="errmsg" Width="0px">
                    <asp:Image ID="imgrevPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" />
                </asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="Password"
                ErrorMessage="Missing Password" ValidationGroup="vgNewPassword" CssClass="errmsg" Width="0px">
                    <asp:Image ID="imgrfvPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" />
                </asp:RequiredFieldValidator><br /><asp:ValidationSummary ID="vsPasswordNew" runat="server" CssClass="errmsg" HeaderText="Please correct the following errors:"
            ValidationGroup="vgEmailNew" />
                    <asp:Label ID="lblPasswordError" runat="server" CssClass="errmsg" Text="Error" Visible="False"></asp:Label><br />
                <strong>* New Password: 
                    <br />
                </strong><span class="pt10size">(Password length must be between 6 and 10 characters/numbers
            and
            include at least one numeric digit.)</span><br />
                <asp:TextBox ID="NewPassword" runat="server" Width="225px" TextMode="Password" CssClass="textbox" TabIndex="12" Wrap="False" MaxLength="10" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="revNewPassword" runat="server" ControlToValidate="NewPassword"
                ErrorMessage="Invalid Password" ValidationExpression="^.{6,10}$" ValidationGroup="vgNewPassword" CssClass="errmsg" Width="0px">
                <asp:Image ID="imgrevnewPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="NewPassword"
                ErrorMessage="Missing Password" ValidationGroup="vgNewPassword" CssClass="errmsg" Width="0px">
                <asp:Image ID="imgrfvNewPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator><br />
                <strong>* Verify New Password:
                    <br />
                </strong>
                <asp:TextBox ID="VerifyNewPassword" runat="server" Width="225px" TextMode="Password" CssClass="textbox" TabIndex="13" Wrap="False" MaxLength="10" ></asp:TextBox>
            <asp:CompareValidator ID="cvPasswords" runat="server" ControlToCompare="NewPassword"
                ControlToValidate="VerifyNewPassword" ErrorMessage="Passwords do not match!"
                ValidationGroup="vgNewPassword" CssClass="errmsg" Width="0px">
                <asp:Image ID="imgcvPasswords" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvVerifyNewPassword" runat="server" ControlToValidate="VerifyNewPassword"
                ErrorMessage="Missing Verify Password" ValidationGroup="vgNewPassword" CssClass="errmsg" Width="0px">
                <asp:Image ID="imgrfvVerifyNewPassword" runat="server" ImageUrl="~/images/as_error_msg.gif" /></asp:RequiredFieldValidator><br />
                
                 <asp:ImageButton ID="imgbPasswordNew" runat="server" ImageUrl="~/images/as_myaccount_changepassword.icon.gif" ValidationGroup="vgNewPassword" /><br />
               
                </asp:Panel>
                </div>
</asp:Content>