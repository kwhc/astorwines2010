
Partial Class secure_SendNewEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(PreviousPage) Then
            'txtEmail.Text = PreviousPage.Email.text
        End If


    End Sub
End Class
