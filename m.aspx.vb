Imports WebCommon
'Imports SslTools
Partial Class m
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each control In modular.Controls
            If TypeOf control Is Panel Then
                control.Visible = False
            End If
        Next

        ucSale.Visible = False

        Dim page = Request.QueryString("p")

        Dim ucPMDelivery As UserControl = LoadControl("/Ucontrols/promo/after-hours-courier-service.ascx")
        Dim ucFreeShippingFirstOrder As UserControl = LoadControl("/Ucontrols/promo/free-shipping-first-order.ascx")
        Dim ucCustomerSurvey As UserControl = LoadControl("/Ucontrols/promo/customer-survey.ascx")

        Select Case page
            Case "pm-courier-service"
                If Date.Today >= #4/13/2014# Then
                    phPromo.Controls.Add(ucPMDelivery)
                End If
            Case "free-shipping-first-order"
                If Date.Today >= #4/13/2014# Then
                    phPromo.Controls.Add(ucFreeShippingFirstOrder)
                End If
            Case "customer-survey"
                If Date.Today >= #4/17/2014# Then
                    phPromo.Controls.Add(ucCustomerSurvey)
                End If
            Case Else
                ucSale.Visible = True
        End Select

    End Sub
End Class
