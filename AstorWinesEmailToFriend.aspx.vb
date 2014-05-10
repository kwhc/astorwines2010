Imports WebCommon
Imports AstorDataClass
Imports AstorUtilsClass
Partial Class AstorWinesEmailToFriend
    Inherits WebPageBase
    Private Sub SendEmailToFriend(ByVal Item As String, ByVal sFromEmail As String, ByVal sToEmail As String, ByVal sItemInfo As String)
        Dim sPassword As String = String.Empty
        Dim _semailServer As String = Application("MailServer")
        Dim _semailUserID As String = Application("MailUserIDOrders")
        Dim _semailPassword As String = Application("MailPasswordOrders")
        Dim users As New AstorwinesCommerce.UsersDB(getConnStr())

        users.EmailServer = _semailServer
        users.EmailUserIDOrders = _semailUserID
        users.EmailPasswordOrders = _semailPassword
        users.EmailToFriendMessage(Item, sFromEmail, sToEmail, sItemInfo)

    End Sub

    Protected Sub cmdSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        If Not IsNothing(Request.QueryString("item")) Then
            Dim sItem As String = Request.QueryString("item")
            Dim sFromEmail As String = RTrim(txtYourEmail.Text)
            Dim sToEmail As String = RTrim(txtFriendsEmail.Text)
            Dim utils As New cMiscUtils
            Dim sItemInfo As String = RTrim(txtEmailNote.Text)

            If Not utils.ValidEmail(sFromEmail) Or Not utils.ValidEmail(sToEmail) Then
                lblError.Visible = True
                lblError.Text = "Invalid Email Address!"
                Return
            End If

            If RTrim(sItem) = "" Or Len(sItem) <> 5 Then
                Exit Sub
            Else
                If RTrim(sFromEmail) = "" Or RTrim(sToEmail) = "" Then
                    Exit Sub
                Else
                    sItemInfo = sItemInfo & vbCrLf & "Here's the items URL " & "http://www.astorwines.com/SearchResultsSingle.aspx?p=0&search=" & sItem & "&searchtype=Contains"
                    SendEmailToFriend(sItem, sFromEmail, sToEmail, sItemInfo)
                    Session("emailSuccess") = True
                    Response.Redirect(Session("ReturnUrlModal"))
                End If
            End If
        End If

    End Sub
End Class
