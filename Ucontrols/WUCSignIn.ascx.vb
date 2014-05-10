Imports System.Web.Security
Imports WebCommon
'Imports SslTools



Partial Class Ucontrols_WUCSignIn
    Inherits System.Web.UI.UserControl
    Private _oWebCommonWPB As New WebPageBase
    Private _oWebCommonWAC As New WebAppConfig
    Private _sSignInReference As Int16
    'Public Property SignInReference() As Int16
    '    Get
    '        Return _sSignInReference
    '    End Get
    '    Set(ByVal value As Int16)
    '        _sSignInReference = value
    '    End Set
    'End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ReturnUrl.Value = ""
        'If Not Request.QueryString("ReturnUrl") Is Nothing Then

        '    ReturnUrl.Value = Request.QueryString("ReturnUrl")

        'End If
        'If Not Session("ReturnUrl") Is Nothing Then
        '    ReturnUrl.Value = Session("ReturnUrl")
        '    Session("ReturnUrl") = Nothing

        'Else
        '    ReturnUrl.Value = "~/default.aspx"
        'End If

        'hyplReturnToShopping.NavigateUrl = ReturnUrl.Value

        ' Store Return Url in Page State
        'hyplCreateAccount.NavigateUrl = "~/secure/AstorCheckoutBillingNewCustomer.aspx"

    End Sub

    Sub LoginBtn_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim users As New AstorwinesCommerce.UsersDB(_oWebCommonWPB.getConnStr())
        Dim cart As New AstorwinesCommerce.CartDB(_oWebCommonWPB.getConnStr())
        Try
            If users.ValidateLogin(UserName.Text, Password.Text) Then
                'If Not Session("AnonUID") Is Nothing Then
                If Not Request.Cookies("CustomerID") Is Nothing Then
                    ' Migrate any temporary shopping cart items to logged-in username
                    'cart.MigrateShoppingCartItems(Session("AnonUID").ToString(), UserName.Text)
                    cart.MigrateShoppingCartItems(Request.Cookies("CustomerID").ToString(), UserName.Text)

                    'delete cookie
                    If (Not Request.Cookies("CustomerID") Is Nothing) Then
                        Dim myCookie As HttpCookie
                        myCookie = New HttpCookie("CustomerID")
                        myCookie.Expires = DateTime.Now.AddDays(-1D)
                        Response.Cookies.Add(myCookie)
                    End If

                End If

                ' Set Client Authentication Cookie
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, Persist.Checked)
            Else
                Session.Item("Error") = "Login failed, please check your details and try again."
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Protected Sub imgbSignIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbSignIn.Click
        Dim users As New AstorwinesCommerce.UsersDB(_oWebCommonWPB.getConnStr())
        Dim cart As New AstorwinesCommerce.CartDB(_oWebCommonWPB.getConnStr())
        Dim sError As String = "Please correct the following errors:" & vbCrLf
        Try
            If users.UserExists(UserName.Text) Then
                If users.ValidateLogin(UserName.Text, Password.Text) Then
                    'If Not Session("AnonUID") Is Nothing Then
                    If Not Request.Cookies("CustomerID") Is Nothing Then
                        ' Migrate any temporary shopping cart items to logged-in username
                        'cart.MigrateShoppingCartItems(Session("AnonUID").ToString(), UserName.Text)
                        cart.MigrateShoppingCartItems(Request.Cookies("CustomerID").Value.ToString, UserName.Text)

                        'delete cookie
                        If (Not Request.Cookies("CustomerID") Is Nothing) Then
                            Dim myCookie As HttpCookie
                            myCookie = New HttpCookie("CustomerID")
                            myCookie.Expires = DateTime.Now.AddDays(-1D)
                            Response.Cookies.Add(myCookie)
                        End If

                    End If
                    If Not IsNothing(Request.QueryString("si")) Then

                        _sSignInReference = Convert.ToInt16(Request.QueryString("si"))
                    Else

                        _sSignInReference = WebAppConfig.SignInReference.SignIn
                    End If
                    '' Set Client Authentication Cookie
                    'Dim mstrPageName As String = String.Empty
                    'mstrPageName = Page.ToString
                    ''mstrPageName &= Page.ClientQueryString.ToString

                    'mstrPageName = Replace(mstrPageName, "ASP.", "")
                    'mstrPageName = Replace(mstrPageName, "_aspx", ".aspx")
                    'mstrPageName = mstrPageName.ToLower

                    'If mstrPageName = "secure_astorsignin.aspx" Then
                    '    FormsAuthentication.RedirectFromLoginPage(UserName.Text, Persist.Checked)

                    'Else
                    '    FormsAuthentication.SetAuthCookie(UserName.Text, Persist.Checked)

                    '    Dim cust As New AstorwinesCommerce.Customer(_oWebCommon.getConnStr())
                    '    If cust.CheckCustomerHasBillingInfo(UserName.Text) Then
                    '        Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
                    '    Else
                    '        Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")
                    '    End If

                    'End If
                    If _sSignInReference = WebAppConfig.SignInReference.SignIn Then
                        FormsAuthentication.RedirectFromLoginPage(UserName.Text, Persist.Checked)
                    ElseIf _sSignInReference = 2 Then
                        FormsAuthentication.RedirectFromLoginPage(UserName.Text, Persist.Checked)

                        'session variable is set, go to page else go to default   

                        Dim returnPage As String = String.Empty
                        returnPage = "~/" & Session.Item("page")

                        If Not String.IsNullOrEmpty(returnPage) Then
                            Response.Redirect(returnPage)
                        Else
                            Response.Redirect("~/Default.aspx")
                        End If


                    Else
                        FormsAuthentication.SetAuthCookie(UserName.Text, Persist.Checked)
                        Response.Redirect("~/secure/AstorCheckoutShoppingCart.aspx")

                        'Dim cust As New AstorwinesCommerce.Customer(_oWebCommonWPB.getConnStr())
                        'If cust.CheckCustomerHasBillingInfo(UserName.Text) Then
                        '    'Redirect("~/secure/AstorCheckoutBilling.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
                        '    Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
                        'Else
                        '    'Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
                        '    Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")
                        'End If

                    End If

                    lblReturningError.Text = String.Empty
                    lblReturningError.Visible = False
                Else
                    sError = "Login failed, please check your details and try again."
                    lblReturningError.Text = sError
                    lblReturningError.Visible = True
                End If
            Else
                sError = "Login failed, email does not exist in our database."
                lblReturningError.Text = sError
                lblReturningError.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Function bValidateCreateAccount() As Boolean
        Dim oDataUtils As New AstorUtilsClass.cMiscUtils
        Dim sError As String = "Please correct the following errors:" & vbCrLf
        If NewUserName.Text <> VerifyNewUserName.Text Then
            sError = sError & "    Email Address Mismatch" & vbCrLf
        End If
        If NewPassword.Text <> VerifyNewPassword.Text Then
            sError = sError & "    Password Mismatch" & vbCrLf
        End If
        If Len(RTrim(NewPassword.Text)) < 6 And Len(RTrim(NewPassword.Text)) > 10 Then
            sError = sError & "    Invalid Password" & vbCrLf
        End If
        If Len(RTrim(NewUserName.Text)) < 1 Then
            sError = sError & "    Blank Email Address" & vbCrLf
        End If
        If oDataUtils.ValidEmail(RTrim(NewUserName.Text)) = False Then
            sError = sError & "    Invalid Email Address" & vbCrLf
        End If
        If sError <> "Please correct the following errors:" & vbCrLf Then 'Len(sError) > 0 Then
            lblError.Text = sError
            lblError.Visible = True
            bValidateCreateAccount = False
        Else
            lblError.Text = ""
            lblError.Visible = False
            bValidateCreateAccount = True
        End If
    End Function
    Protected Sub imgbCreateAccount_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbCreateAccount.Click
        If bValidateCreateAccount() Then


            Dim users As New AstorwinesCommerce.UsersDB(_oWebCommonWPB.getConnStr())
            Dim sOrigSessionID As String = String.Empty
            Dim cart As New AstorwinesCommerce.CartDB(_oWebCommonWPB.getConnStr())
            'Dim _oError As New cAstorCommon
            Try


                If users.UserExists(NewUserName.Text) Or users.IsSuspendedEmail(NewUserName.Text) Then
                    'ErrorSummary.AddError("Email Address Exists", Page)
                    Dim sError As String = "Please correct the following errors:" & vbCrLf
                    sError = sError & "    Email Address Already Exists" & vbCrLf
                    lblError.Text = sError
                    lblError.Visible = True
                    Return
                Else
                    lblError.Text = ""
                    lblError.Visible = False
                End If

                If Not IsNothing(Request.QueryString("si")) Then

                    _sSignInReference = Convert.ToInt16(Request.QueryString("si"))
                Else

                    _sSignInReference = WebAppConfig.SignInReference.SignIn
                End If

                'If Not Session("AnonUID") Is Nothing Then
                If Not Request.Cookies("CustomerID") Is Nothing Then
                    'sOrigSessionID = Session("AnonUID").ToString
                    sOrigSessionID = Request.Cookies("CustomerID").Value.ToString
                    'Request.Cookies("CustomerID").ToString()

                End If
                ' check if session had timed out
                If sOrigSessionID Is DBNull.Value Then
                    'Redirect("~/default.aspx", RedirectOptions.AbsoluteHttp)  https_transfer_6/18/08
                    Response.Redirect("~/default.aspx")
                End If
                If RTrim(sOrigSessionID) = "" Then
                    'Redirect("~/default.aspx", RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
                    Response.Redirect("~/default.aspx")
                End If

                ' Create new user account
                '                users.AddNewUser(NewUserName.Text, NewPassword.Text, "", chkEmailNewsletterAdd.Checked)
                users.AddNewUser(NewUserName.Text, NewPassword.Text, "", chkEmailNewsletterAdd.Checked, chkEmailNewsletterACAdd.Checked)


                ' Set Client Authentication Cookie
                FormsAuthentication.SetAuthCookie(NewUserName.Text, (PersistNew.Checked))
                Dim stest As String = Session.SessionID

                ' Migrate any temporary shopping cart items to logged-in username
                cart.MigrateShoppingCartItems(sOrigSessionID, NewUserName.Text)

                'delete cookie
                If (Not Request.Cookies("CustomerID") Is Nothing) Then
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie("CustomerID")
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                End If

                'Dim mstrPageName As String = String.Empty
                'mstrPageName = Page.ToString
                ''mstrPageName &= Page.ClientQueryString.ToString

                'mstrPageName = Replace(mstrPageName, "ASP.", "")
                'mstrPageName = Replace(mstrPageName, "_aspx", ".aspx")
                'mstrPageName = mstrPageName.ToLower

                If _sSignInReference = WebAppConfig.SignInReference.SignIn Then
                    ' Redirect user back to where they came from
                    'Redirect(ReturnUrl.Value, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
                    Response.Redirect(ReturnUrl.Value)
                Else
                    'Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
                    Response.Redirect("~/secure/AstorCheckoutShoppingCart.aspx")
                    'Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
   
    Protected Sub lnkbNewEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbNewEmail.Click
        Dim sError As String
        Dim sPassword As String = String.Empty
        Dim _semailServer As String = Application("MailServer")
        Dim _semailUserID As String = Application("MailUserIDAccounts")
        Dim _semailPassword As String = Application("MailPasswordAccounts")
        Dim users As New AstorwinesCommerce.UsersDB(_oWebCommonWPB.getConnStr())

        If Len(RTrim(UserName.Text)) < 1 Then
            sError = "Please correct the following errors:<br />" & vbCrLf
            sError = sError & "    Blank Email Address - Please enter email address!!" & vbCrLf
            lblReturningError.Text = sError
            lblReturningError.Visible = True
        ElseIf users.UserExists(UserName.Text) Then
            users.EmailServer = _semailServer
            users.EmailUserIDAccounts = _semailUserID
            users.EmailPasswordAccounts = _semailPassword
            sPassword = users.ResetUserPassword(RTrim(UserName.Text))
            users.EmailNewPasswordMessage(RTrim(UserName.Text), sPassword)
            sError = "New password send to " & UserName.Text & " - please check your email and try again." & vbCrLf
            lblReturningError.Text = sError
            lblReturningError.Visible = True
        Else
            sError = "Please correct the following errors:" & vbCrLf
            sError = sError & "    Email Address doesn't exist!!" & vbCrLf
            lblReturningError.Text = sError
            lblReturningError.Visible = True
        End If

    End Sub
   
End Class
