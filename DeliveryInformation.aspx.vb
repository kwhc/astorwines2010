Imports WebCommon
Partial Class DeliveryInformation
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblNotShipToStatesCodes.Text = Application("NotShipToStatesDesc")
    End Sub
End Class
