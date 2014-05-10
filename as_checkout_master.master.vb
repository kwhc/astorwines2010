
Partial Class Ucontrols_as_checkout_master
    Inherits System.Web.UI.MasterPage
    Protected Overrides Function OnBubbleEvent(ByVal source As Object, ByVal args As System.EventArgs) As Boolean
        lblErrorMsg.Text = Session.Item("Error")
        lblErrorMsg.Visible = True
        Session.Item("Error") = Nothing
    End Function

    'Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    '    lblErrorMsg.Text = Session.Item("Error")
    '    lblErrorMsg.Visible = True
    '    Session.Item("Error") = Nothing
    'End Sub
End Class

