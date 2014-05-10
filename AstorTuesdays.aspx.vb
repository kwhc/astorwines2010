Imports WebCommon
Imports AstorDataClass
Imports System.Data

Partial Class AstorTuesdays
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("r") = 294 Then
            Response.Redirect("AstorTuesdays.aspx?r=297")
        End If

        Session("SearchParms") = Nothing
        If Not IsPostBack Then
            Try
                If Date.Now.DayOfWeek = DayOfWeek.Tuesday Then
                    lblResultBottom.Text = "<p>Every Tuesday, our buyers pick a region or type of wine, spirit, or saké and mark it down 15%.</p> <p>Check out these sales:</p>"

                Else
                    lblResultBottom.Text = "<p>Every Tuesday, our buyers pick a region or type of wine, spirit, or saké and mark it down 15%.</p> <p><b>Check back this Tuesday for the sale items, but in the meantime check out these other 15% off sales:</b>"

                End If
                Dim sRow As String
                Dim iRow As Int16 = 0
                If Not IsNothing(Request.QueryString("r")) Then

                    sRow = Request.QueryString("r")
                    If IsNumeric(sRow) Then
                        iRow = CInt(sRow)
                    End If
                End If
                Dim _dslocalDetail As DataSet
                If Date.Now.DayOfWeek = DayOfWeek.Tuesday Then
                    _dslocalDetail = Get15TuesdayData(iRow)
                Else
                    _dslocalDetail = Get15TuesdayData(0)
                End If

                Session("DSMulti") = _dslocalDetail
                Session("queryType") = Nothing
                Session("queryValue") = Nothing


            Catch ex As Exception

                Throw ex
            End Try
        End If
    End Sub

   
    
    Private Function Get15TuesdayData(ByVal iRow As Int16) As DataSet

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As New DataSet

        Try

            dsLocal = _odata.Get15TuesdaysData(iRow)


        Catch ex As Exception
            Throw ex
        End Try

        Return dsLocal

    End Function

End Class
