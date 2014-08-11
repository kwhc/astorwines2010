
Partial Class Ucontrols_shopHours
    Inherits System.Web.UI.UserControl

    Sub winterHours()
        Dim hoursPrefix = ""

        'Select Case Now.ToString("dddd")
        '    Case "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"
        '        lblHours.Text = hoursPrefix & "9:00am - 9:00pm"
        '    Case "Saturday"
        '        lblHours.Text = hoursPrefix & "9:00am - 9:00pm"
        '    Case "Sunday"
        '        lblHours.Text = hoursPrefix & "12:00pm - 6:00pm"
        'End Select

        'Select Case Now.ToString("MM/dd/yyyy")
        '    Case "12/17/2011"
        '        lblHours.Text = hoursPrefix & "9:00am - 10:00pm"
        '    Case "12/18/2011"
        '        lblHours.Text = hoursPrefix & "12:00pm - 7:00pm"
        '    Case "12/19/2011" To "12/23/2011"
        '        lblHours.Text = hoursPrefix & "9:00am - 10:00pm"
        '    Case "12/24/2011"
        '        lblHours.Text = hoursPrefix & "9:00am - 7:00pm"
        '    Case "12/25/2011"
        '        lblHours.Text = "We are closed today. Merry Christmas!"
        '    Case "12/26/2011" To "12/28/2011"
        '        lblHours.Text = hoursPrefix & "9:00am - 9:00pm"
        '    Case "12/29/2011" To "12/30/2011"
        '        lblHours.Text = hoursPrefix & "9:00am - 10:00pm"
        '    Case "12/31/2011"
        '        lblHours.Text = hoursPrefix & "9:00am - 8:00pm"
        '    Case "01/01/2012"
        '        lblHours.Text = "We are closed today. Happy New Year!"

        'End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim holiday As String

        holiday = "independenceDay"

        Select Case holiday
            Case "memorialDay"
                lblToday.Text = "Memorial Day"
                lblHours.Text = "10:00am - 4:00pm"
            Case "winterHours"
                winterHours()
            Case "independenceDay"
                lblToday.Text = "Independence Day"
                lblHours.Text = "10:00am - 4:00pm"
            Case "thanksgiving"
                lblToday.Text = "Thanksgiving"
                lblHours.Text = "10:00 am - 6:00 pm"
                'imgIcon.Visible = False
            Case "laborDay"
                lblToday.Text = "Labor Day"
                lblHours.Text = "10:00am - 4:00pm"
        End Select

        'Show/Hide Toggle
        Dim promoBegin As DateTime 'First day of promotion
        Dim promoEnd As DateTime   'Last day of promotion

        promoBegin = #7/3/2014#
        promoEnd = #7/4/2014#.AddDays(1)


        If Date.Now < promoBegin Or Date.Now > promoEnd Then
            pnlShopHours.Visible = False
        End If

        customerSurvery()

    End Sub

    Sub customerSurvery()
        If Date.Now >= #4/18/2014# And Date.Now < #4/26/2014# Then
            phCustomerSurvey.Visible = True
        End If
    End Sub

End Class
