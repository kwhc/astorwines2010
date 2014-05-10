Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_MyAccountEmailAddresses
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCurrentEmailAddress.Text = GetCustomerID(Request, Response)
    End Sub
    Function bValidateNewEmail() As Boolean
        Dim sError As String = "Please correct the following errors:" & vbCrLf
        If NewUserName.Text <> VerifyNewUserName.Text Then
            sError = sError & "    New Email Addresses Mismatch!!" & vbCrLf
        End If
        If Len(RTrim(NewUserName.Text)) < 1 Then
            sError = sError & "    Blank Email Address NOT permitted!!" & vbCrLf
        End If
        If sError <> "Please correct the following errors:" & vbCrLf Then 'Len(sError) > 0 Then
            lblEmailError.Text = sError
            lblEmailError.Visible = True
            bValidateNewEmail = False
        Else
            lblEmailError.Text = ""
            lblEmailError.Visible = False
            bValidateNewEmail = True
        End If
    End Function
    Function bValidateNewPassword() As Boolean
        Dim sError As String = "Please correct the following errors:" & vbCrLf
        If NewPassword.Text <> VerifyNewPassword.Text Then
            sError = sError & "    New Password Mismatch!!" & vbCrLf
        End If
        If Len(RTrim(NewPassword.Text)) < 1 Then
            sError = sError & "    Blank Password NOT permitted!!" & vbCrLf
        End If
        If sError <> "Please correct the following errors:" & vbCrLf Then 'Len(sError) > 0 Then
            lblPasswordError.Text = sError
            lblPasswordError.Visible = True
            bValidateNewPassword = False
        Else
            lblPasswordError.Text = ""
            lblPasswordError.Visible = False
            bValidateNewPassword = True
        End If
    End Function
    Private Sub SendEmailForEmailChange(ByVal OldEmail As String, ByVal NewEmail As String)
        Dim sPassword As String = String.Empty
        Dim _semailServer As String = Application("MailServer")
        Dim _semailUserID As String = Application("MailUserIDAccounts")
        Dim _semailPassword As String = Application("MailPasswordAccounts")
        Dim users As New AstorwinesCommerce.UsersDB(getConnStr())

        users.EmailServer = _semailServer
        users.EmailUserIDAccounts = _semailUserID
        users.EmailPasswordAccounts = _semailPassword
        users.EmailNewEmailMessage(OldEmail, NewEmail)

    End Sub
    Private Sub SendEmailForPasswordChange(ByVal Email As String, ByVal NewPassword As String)
        Dim sPassword As String = String.Empty
        Dim _semailServer As String = Application("MailServer")
        Dim _semailUserID As String = Application("MailUserIDAccounts")
        Dim _semailPassword As String = Application("MailPasswordAccounts")
        Dim users As New AstorwinesCommerce.UsersDB(getConnStr())

        users.EmailServer = _semailServer
        users.EmailUserIDAccounts = _semailUserID
        users.EmailPasswordAccounts = _semailPassword
        users.EmailNewPasswordMessage(Email, NewPassword)

    End Sub
    Protected Sub imgbEmailNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbEmailNew.Click
        Try


            If bValidateNewEmail() Then


                Dim users As New AstorwinesCommerce.UsersDB(getConnStr())

                If users.UserExists(NewUserName.Text) Or users.IsSuspendedEmail(NewUserName.Text) Then
                    'ErrorSummary.AddError("Email Address Exists", Page)
                    Dim sError As String = "Please correct the following errors:" & vbCrLf
                    sError = sError & "    Email Address Already Exists!!" & vbCrLf
                    lblEmailError.Text = sError
                    lblEmailError.Visible = True
                    Return
                Else
                    lblEmailError.Text = ""
                    lblEmailError.Visible = False
                End If

                ' Change user name
                users.ChangeEmail(GetCustomerID(Request, Response), NewUserName.Text, chkEmailNewsletterAdd.Checked)
                SendEmailForEmailChange(GetCustomerID(Request, Response), NewUserName.Text)

                FormsAuthentication.SignOut()
                'Redirect("~/secure/AstorSignIn.aspx", RedirectOptions.AbsoluteHttps)https_transfer_6/18/08
                Response.Redirect("~/secure/AstorSignIn.aspx")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Protected Sub imgbPasswordNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbPasswordNew.Click
        Dim users As New AstorwinesCommerce.UsersDB(getConnStr())
        Try


            If users.ValidateLogin(GetCustomerID(Request, Response), Password.Text) Then
                lblEmailError.Text = ""
                lblEmailError.Visible = False
                If users.ResetUserPassword(GetCustomerID(Request, Response), NewPassword.Text) Then
                    SendEmailForPasswordChange(GetCustomerID(Request, Response), NewPassword.Text)
                End If

            Else
                Dim sError As String = "Please correct the following errors:" & vbCrLf
                sError = sError & "    Current Password is incorrect!!" & vbCrLf
                lblPasswordError.Text = sError
                lblPasswordError.Visible = True
                Return
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
