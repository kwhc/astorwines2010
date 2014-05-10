<%@ Page Language="VB" MasterPageFile="~/as_master_1.master" EnableEventValidation="false" AutoEventWireup="false" CodeFile="PrivacyPolicy.aspx.vb" Inherits="PrivacyPolicy" title="Astor Wines & Spirits - Privacy Policy" %>

<%@ Register Src="Ucontrols/WUCVeriSign.ascx" TagName="WUCVeriSign" TagPrefix="uc6" %>
<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>
<%@ Register Src="~/Ucontrols/WUCCombinedSearch.ascx" TagName="combinedSearch" TagPrefix="awCmb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="searchContent" Runat="Server">
  <awCmb:combinedSearch ID="CombinedSearch1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContent" Runat="Server">
    <div id="privacyPolicy" class="info-page">
        <span class="muted" style="letter-spacing:.05rem;text-transform:uppercase;">Information</span>
        <h1 style="margin-bottom:1rem;">Our Privacy Policy</h1>
        <hr style="background:rgb(34,34,34);width:60px;border:0;height:3px;margin-bottom:1rem;" align="left" />  

          <p>
            Astor Wines &amp; Spirits has created this privacy statement in order to demonstrate our firm commitment to
            privacy. The following discloses our information-gathering and dissemination practices for this web site:
            <strong>www.astorwines.com</strong>.
          </p>
          <p>
            We use your IP address to help diagnose problems with our server and to administer this web site. We log
            IP addresses for the purposes of system administration, to track a user's specific session, or to
            investigate cases of fraud or other security violations on our site. Any personally identifiable
            information contained in our IP address logs will be treated with the same respect for your privacy as
            order and registration information is. The aggregate of IP addresses used to access our site may be
            analyzed to provide broad demographic information about the community of users on the site.
          </p>
          <p>
            Cookies are small pieces of information that many web sites use to make online navigation easier. This 
            data is contained on your hard drive in a file that your web browser provides for this purpose. A cookie
            can contain information such as a user ID. Our site cannot read other data on your hard drive, nor read 
            cookies created by other sites. You must have cookies enabled in order to view our site.
          </p>
          <p>
            Our site uses cookies to keep track of your content during visits to the site, and to identify you as you
            move about the site or when you return to the site later.
          </p>
          <p>
            Our site uses an order form for purchasing. When you begin the ordering process, you are sent to our 
            secure server to ensure the security and safety of information collected during ordering. You will notice
            at this point that the site address (URL) changes to the secure server of the company that hosts our web
            site. However, this company will never, in any way, use your personal information.
          </p>
          <p>
            We collect visitors’ contact information (such as their email addresses) and financial information (such
            as their account or credit card numbers). Contact information from the order form is used to send orders
            to our customers. Customers’ contact information is used to get in touch with them when necessary to
            process their orders. Financial information that is collected is used to check the users' qualifications
            and to bill the user for products and services.
          </p>
          <p>
            Astor Wines & Spirits does not sell, rent, or give away your personal information to anyone. We only
            release shipping information to the third party shipping company (such as UPS), and we only release credit
            card information to the actual credit card company for approval and authorization. Additionally, we may
            release account information when we believe, in good faith, that such release is reasonably necessary to
            a) comply with the law, b) enforce or apply the terms of any of our user agreements, or c) protect the
            rights, property, or safety of Astor Wines & Spirits and our customers, or others.
          </p>
          
          <h2>Security</h2>
          <p>
            This site has security measures in place to protect against the loss, misuse, or alteration of the
            information under our control. All ordering information is encrypted via SSL when it is transmitted over
            the open internet. Systems in which personal information is stored are protected using state-of-the-art
            methods, and we routinely and zealously monitor and upgrade our security systems to ensure that we use the
            best security technology available.
          </p>
          
          <h2>Choice/Opt-Out</h2>
          <p>
            Our site provides users the opportunity to opt out of receiving communications from us and for removing
            all your information from our database. You may opt to receive our email alerts, as well as our
            monthly newsletters. You may also opt out of either or both at any time. You may do so in the following
            ways:
          </p>
          <p>
           Each email we send contains an unsubscribe link at the bottom. If you no longer wish to recieve our emails, simply click the link and follow the instructions.
          </p>
          <p>
            You may call the store during regular business hours at 212-674-7500 and ask a salesperson to unsubscribe
            you from both the email list and the newsletter mailing list.
          </p>
          <p>
            Any changes to this privacy policy will be provided to users who have provided us with an email address
            and will also be addressed within the privacy policy document itself.
          </p>
  </div>
</asp:Content>