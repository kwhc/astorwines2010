Imports AstorUtilsClass
Imports WebCommon
Partial Class Ucontrols_WUCEmailSignUp
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Page.IsPostBack Then
        '    ' Store Return Url in Page State
        '    If Not Request Is Nothing Then
        '        If Not Request.UrlReferrer Is Nothing Then
        '            If Not Request.UrlReferrer.AbsoluteUri Is Nothing Then
        '                If Not RTrim(Request.UrlReferrer.AbsoluteUri.ToString) = "" Then
        '                    ReturnUrl.Value = Request.UrlReferrer.AbsoluteUri.ToString
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
    End Sub
    Protected Sub imbbSubmitEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbbSubmitEmail.Click
        'Session.Add("Error", "Search must contain at least 3 characters/numbers")
        'RaiseBubbleEvent(sender, e)
        Session.Remove("Error")
        If Len(RTrim(txtEmailAddress.Text)) > 0 Then
            Dim wbp As New WebPageBase
            Dim users As New AstorwinesCommerce.UsersDB(wbp.getConnStr())
            Dim utils As New cMiscUtils
            Dim sEmail As String
            Dim _semailServer As String = Application("MailServer")
            Dim _semailUserID As String = Application("MailUserIDSubscribe")
            Dim _semailPassword As String = Application("MailPasswordSubscribe")

            If Not utils.ValidEmail(txtEmailAddress.Text) Then
                lblError.Visible = True
                lblError.Text = "Invalid Email!"
                Return
            End If

            Try
                ' add new eamil
                sEmail = txtEmailAddress.Text
                users.EmailServer = _semailServer
                users.EmailUserIDSubscribe = _semailUserID
                users.EmailPasswordSubscribe = _semailPassword
                users.AddNewEmail(sEmail, True, False)
                txtEmailAddress.Text = String.Empty
                lblError.Visible = True
                lblError.Text = "Thanks - Email Added!"
                users.EmailSubscribeMessage(sEmail)
            Catch ex As Exception
                Throw ex

            Finally

            End Try

        Else
            lblError.Visible = True
            lblError.Text = "Invalid Email!"

        End If



    End Sub


End Class
