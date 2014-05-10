
Partial Class AstorBlog
    Inherits System.Web.UI.Page

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Dim a As String = "b"
        Select Case a
            Case "a" & "b" & "c"
                a = 3
            Case "d"
                a = 4
            Case Else
                a = 5


        End Select
    End Sub
End Class
