Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
Partial Class Features
    Inherits WebPageBase
    Private intTxt As Integer
    Private sOrderType As String
    Private sItem As String

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        'TextBox1.Text = CStr(Session.Item("queryValue"))
        Session("SearchParms") = Nothing
        If Not IsPostBack Then
            Try
                If Not IsNothing(Request.QueryString("search")) Then

                    Session.Item("queryValue") = Request.QueryString("search")

                End If
                If Not IsNothing(Request.QueryString("searchtype")) Then

                    Session.Item("queryType") = Request.QueryString("searchtype")

                End If
                If Not IsNothing(Request.QueryString("featurepage")) Then
                    Dim iPage As Int16
                    Dim iLocation As Int16
                    Dim iSort As Int16
                    Dim iRow As Int16
                    Dim _dtlocal As DataTable
                    Dim _dslocalDetail As DataSet
                    Dim sQueryString As String = Request.QueryString("featurepage")
                    Dim arQueryString() As String

                    If Mid(sQueryString, 1, 1) = "a" Then
                        sQueryString = Mid(sQueryString, 2, Len(sQueryString))
                    End If

                    arQueryString = Split(sQueryString, "_")
                    iPage = Convert.ToInt16(arQueryString(0))
                    iLocation = Convert.ToInt16(arQueryString(1))
                    iSort = Convert.ToInt16(arQueryString(2))
                    iRow = Convert.ToInt16(arQueryString(3))

                    'changing ipage to iRow now
                    _dtlocal = GetFeaturesData(iPage, iLocation, iSort)

                    'imgFeatureHeader.ImageUrl = _dtlocal.Rows(0).Item("sHeaderImageLocation").ToString()
                    imgFeature.ImageUrl = _dtlocal.Rows(0).Item("sFeatureImageLocation").ToString()
                    'lblFeature.Text = _dtlocal.Rows(0).Item("sFeatureDescLong").ToString()
                    litFeature.Text = _dtlocal.Rows(0).Item("sFeatureDescLong").ToString()
                    featureHeader.Text = _dtlocal.Rows(0).Item("sFeature").ToString()
                    _dslocalDetail = GetFeaturesDetailData(iRow)
                    Session("DSMulti") = _dslocalDetail
                    Session("queryType") = Nothing
                    Session("queryValue") = Nothing
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
   
    Private Function GetFeaturesData(ByVal iPage As Int16, ByVal iLocation As Int16, ByVal iSort As Int16) As DataTable

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As New DataSet
        Dim dtLocal As New DataTable

        Try

            dsLocal = _odata.GetFeatures(iPage, iLocation, iSort)
            dtLocal = dsLocal.Tables(0)

        Catch ex As Exception
            Throw ex
        End Try

        Return dtLocal

    End Function
    Private Function GetFeaturesDetailData(ByVal iRow As Int16) As DataSet

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As New DataSet

        Try

            dsLocal = _odata.GetFeaturesDetail(iRow)


        Catch ex As Exception
            Throw ex
        End Try

        Return dsLocal

    End Function

End Class
