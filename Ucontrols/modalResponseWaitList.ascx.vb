
Partial Class Ucontrols_modalResponseWaitList
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Wait List success message
        If Session("waitListSuccess") = True Then
            pnlWaitListSuccess.Visible = True
            Session("waitListSuccess") = False
        End If

    End Sub
End Class
