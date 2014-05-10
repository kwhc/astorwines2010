Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
Partial Class SearchNoResults
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = strUrl

            'BindResultDataList()
        End If
    End Sub
End Class
