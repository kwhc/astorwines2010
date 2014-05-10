Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
Partial Class BooksAccessoriesSearch
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SearchParms") = Nothing
    End Sub
End Class
