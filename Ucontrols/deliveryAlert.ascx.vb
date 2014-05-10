
Partial Class Ucontrols_deliveryAlert
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'pnlAlerts.Visible = False

        allOrders.Visible = False
        allNoGuaranteeChristmas.Visible = False
        allNoNextDay.Visible = False
        allNoChristmas.Visible = False

        shipping.Visible = False
        shippingChristmasDeadline.Visible = False
        noNextDayShipping.Visible = False
        shippingNoGuaranteeChristmas.Visible = False
        shippingNoChristmas.Visible = False
        heatAlert.Visible = False
        pnlNoAirShipping.Visible = False
        pnlExtremeCold.Visible = False

        delivery.Visible = False
        noNextDay.Visible = False
        deliveryChristmasDeadline.Visible = False
        deliveryNoGuaranteeChristmas.Visible = False
        deliveryNoChristmas.Visible = False

        special.Visible = False

        Dim shippingDeadline As Date
        shippingDeadline = #12/12/2013#
        litShippingDeadline.Text = shippingDeadline.ToString("MMMM dd")


        If shipping.Visible = True And delivery.Visible = False Then
            shippingPanel.Style.Add("width", "80%")
            shippingPanel.Style.Add("margin", "0 auto")
            shippingPanel.Style.Add("display", "block")
        ElseIf shipping.Visible = False And delivery.Visible = True Then
            deliveryPanel.Style.Add("width", "80%")
        ElseIf shippingPanel.Visible = True And deliveryPanel.Visible = True Then
            shippingPanel.Style.Add("width", "400px")
            shippingPanel.Style.Add("float", "left")
            deliveryPanel.Style.Add("width", "400px")
            deliveryPanel.Style.Add("float", "left")
        End If

        If shipping.Visible = True Or delivery.Visible = True Then
            headerAllOrders.Visible = True
        Else
            headerAllOrders.Visible = False
        End If

        DateCheck()

    End Sub

    Sub DateCheck()
        If Date.Now > #3/15/2014# Then
            pnlAlerts.Visible = False
        End If
    End Sub
End Class
