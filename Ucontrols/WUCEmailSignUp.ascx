<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WUCEmailSignUp.ascx.vb" Inherits="Ucontrols_WUCEmailSignUp" %>
<asp:Panel runat="server" DefaultButton="imbbSubmitEmail" ID="pnlSearch" Width="100%">
<table bgcolor="#f3e7d3" border="0" cellpadding="0" cellspacing="0" 
style="border-right: #cccccc thin solid; border-top: #cccccc thin solid; border-left: #cccccc thin solid; border-bottom: #cccccc thin solid;">
    <tr>
        <td style="width: 125px; height: 40px;" valign="top">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/as_EmailSignUp.gif" /></td>
    </tr>
    <tr>
        <td style="width: 125px;">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; padding-left: 10px;">
                
                <tr> 
                    <td style="width: 125px;" align="left">
                    <asp:ValidationSummary ID="vsEmail" runat="server" HeaderText="Please correct the following error:"
    ValidationGroup="vgEmail" CssClass="errmsg" DisplayMode="SingleParagraph" />
                        <span class="pt12size">Enter your email & receive weekly email alerts on special sales and events.</span><br />
                        <br />
                        <span class="pt9size">(ex. user@aol.com)</span>
                        <asp:Label ID="lblError" runat="server" Text="Invalid Email Address" CssClass="pt12sizered" Visible="False"></asp:Label>
                <asp:TextBox ID="txtEmailAddress" runat="server" Width="125px" CssClass="textbox" TabIndex="0" MaxLength="100" ToolTip="Enter your email & receive weekly email alerts on special sales and events." ></asp:TextBox>
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ErrorMessage="Invaild Email Address"
                    ValidationExpression="^((([a-z]|[0-9]|!|#|$|%|&|'|\*|\+|\-|/|=|\?|\^|_|`|\{|\||\}|~)+(\.([a-z]|[0-9]|!|#|$|%|&|'|\*|\+|\-|/|=|\?|\^|_|`|\{|\||\}|~)+)*)@((((([a-z]|[0-9])([a-z]|[0-9]|\-){0,61}([a-z]|[0-9])\.))*([a-z]|[0-9])([a-z]|[0-9]|\-){0,61}([a-z]|[0-9])\.(af|ax|al|dz|as|ad|ao|ai|aq|ag|ar|am|aw|au|at|az|bs|bh|bd|bb|by|be|bz|bj|bm|bt|bo|ba|bw|bv|br|io|bn|bg|bf|bi|kh|cm|ca|cv|ky|cf|td|cl|cn|cx|cc|co|km|cg|cd|ck|cr|ci|hr|cu|cy|cz|dk|dj|dm|do|ec|eg|sv|gq|er|ee|et|fk|fo|fj|fi|fr|gf|pf|tf|ga|gm|ge|de|gh|gi|gr|gl|gd|gp|gu|gt| gg|gn|gw|gy|ht|hm|va|hn|hk|hu|is|in|id|ir|iq|ie|im|il|it|jm|jp|je|jo|kz|ke|ki|kp|kr|kw|kg|la|lv|lb|ls|lr|ly|li|lt|lu|mo|mk|mg|mw|my|mv|ml|mt|mh|mq|mr|mu|yt|mx|fm|md|mc|mn|ms|ma|mz|mm|na|nr|np|nl|an|nc|nz|ni|ne|ng|nu|nf|mp|no|om|pk|pw|ps|pa|pg|py|pe|ph|pn|pl|pt|pr|qa|re|ro|ru|rw|sh|kn|lc|pm|vc|ws|sm|st|sa|sn|cs|sc|sl|sg|sk|si|sb|so|za|gs|es|lk|sd|sr|sj|sz|se|ch|sy|tw|tj|tz|th|tl|tg|tk|to|tt|tn|tr|tm|tc|tv|ug|ua|ae|gb|us|um|uy|uz|vu|ve|vn|vg|vi|wf|eh|ye|zm|zw|com|edu|gov|int|mil|net|org|biz|info|name|pro|aero|coop|museum|arpa))|(((([0-9]){1,3}\.){3}([0-9]){1,3}))|(\[((([0-9]){1,3}\.){3}([0-9]){1,3})\])))$" ValidationGroup="vgEmail" ControlToValidate="txtEmailAddress" CssClass="errmsg">
                    <asp:Image ID="imgrevEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
                    </asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                    CssClass="errmsg" ErrorMessage="Missing Email Address" ValidationGroup="vgEmail"><asp:Image ID="imgrfvEmailAddress" runat="server" ImageUrl="~/images/as_error_msg.gif" />
                    </asp:RequiredFieldValidator>
                        
                        </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="width: 125px" align="center">
            <asp:ImageButton ID="imbbSubmitEmail" runat="server" ImageUrl="~/images/as_submitEmail.gif" ValidationGroup="vgEmail"  /></td>
    </tr>
</table>
</asp:Panel>
