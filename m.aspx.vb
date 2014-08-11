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

        Dim page = Request.QueryString("p")

        Select Case page
            Case "pm-courier-service"
                If Date.Today >= #4/13/2014# Then
                    pnlPMDelivery.Visible = True
                End If
            Case "free-shipping-first-order"
                If Date.Today >= #4/13/2014# Then
                    pnlFreeShipping.Visible = True
                End If
            Case "customer-survey"
                If Date.Today >= #4/17/2014# Then
                    pnlCustomerSurvey.Visible = True
                End If
        End Select

    End Sub
End Class
