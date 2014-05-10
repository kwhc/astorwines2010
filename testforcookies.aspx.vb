Imports WebCommon
'Imports SslTools

Partial Class testforcookies
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sRedirect As String = Request.QueryString("redirect")
        Dim acceptsCookies As String
        ' Was the cookie accepted?
        If Request.Cookies("TestCookie") Is Nothing Then
            ' No cookie, so it must not have been accepted
            acceptsCookies = 0
        Else
            acceptsCookies = 1
            ' Delete test cookie
            Response.Cookies("TestCookie").Expires = _
               DateTime.Now.AddDays(-1)
        End If
        'Response.Redirect(sRedirect & "?AcceptsCookies=" & acceptsCookies, True)
        'Redirect(sRedirect & "?c=" & acceptsCookies, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
        Response.Redirect(sRedirect & "?c=" & acceptsCookies)
    End Sub
End Class
