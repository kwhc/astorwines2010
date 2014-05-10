Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
'Imports SslTools
Partial Class WinesOnSale
    Inherits WebPageBase

    Private dns As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SearchParms") = Nothing

        If Not IsPostBack Then
            Try
                If Not Session("ReturnUrl") Is Nothing Then
                    ReturnUrl.Value = Session("ReturnUrl")
                    Session("ReturnUrl") = Nothing

                Else
                    ReturnUrl.Value = "~/default.aspx"
                End If

                Dim _dslocal As DataSet


                _dslocal = GetSaleItems()
                If _dslocal.Tables.Count > 0 Then

                    Session("DSMulti") = _dslocal
                    Session("queryType") = Nothing
                    Session("queryValue") = Nothing
                Else
                    'Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                    Response.Redirect("~/astorerror.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Private Function GetSaleItems() As DataSet

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As New DataSet

        Try

            dsLocal = _odata.GetSaleItems


        Catch ex As Exception
            Throw ex
        End Try

        Return dsLocal

    End Function

End Class
