Imports WebCommon
Imports AstorDataClass
Imports System.Data
Partial Class AstorGeneralInformation
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
               
                If Not IsNothing(Request.QueryString("gi")) Then
                    
                    Dim iRow As Int16
                    Dim _dtlocal As DataTable

                    Dim sQueryString As String = Request.QueryString("gi")
                    iRow = Convert.ToInt16(sQueryString)

                    _dtlocal = GetGeneralInformationData(iRow)
                    imgGeneralInfoHeader.ImageUrl = _dtlocal.Rows(0).Item("sHeaderImageLocation").ToString()
                    hyplFeature.ImageUrl = _dtlocal.Rows(0).Item("sImageLocation").ToString()
                    hyplFeature.NavigateUrl = _dtlocal.Rows(0).Item("sNavURLForImage").ToString()
                    featureHeader.Text = _dtlocal.Rows(0).Item("sFeature").ToString()
                    litGeneralInfo.Text = _dtlocal.Rows(0).Item("sFeatureDescLong").ToString()
                   
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub


    Private Function GetGeneralInformationData(ByVal iRow As Int16) As DataTable

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As New DataSet
        Dim dtLocal As New DataTable

        Try

            dsLocal = _odata.GetGeneralInformation(iRow)
            dtLocal = dsLocal.Tables(0)

        Catch ex As Exception
            Throw ex
        End Try

        Return dtLocal

    End Function

End Class
