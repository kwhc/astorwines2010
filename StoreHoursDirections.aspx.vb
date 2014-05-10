Imports WebCommon
Partial Class StoreHoursDirections
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        holidayHours()

    End Sub

    Sub areWeOpen()
        Dim openPrefix = "We are currently "
        Dim now = Date.Now

        Select Case now.ToString("dddd")
            Case "Monday", "Tuesday", "Wednesday", "Thursday", "Friday"
                If now.TimeOfDay.ToString >= "09:00" AndAlso now.TimeOfDay.ToString <= "21:00" Then
                    lblOpen.Text = openPrefix & "Open"
                Else
                    lblOpen.Text = openPrefix & "Closed"
                End If
            Case Else
                lblOpen.Text = "Testing."
        End Select

    End Sub

    Sub holidayHours()

        Dim year As String
        year = Date.Now.ToString("yyyy")
        litYearHeader.Text = year

        If Date.Now > #1/2/2014# Then
            pnlHolidayHours.Visible = False
        End If

    End Sub

End Class
