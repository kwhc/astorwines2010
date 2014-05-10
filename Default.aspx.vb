Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class _cDefault
    Inherits WebPageBase
    Private dsn As String = WebAppConfig.ConnectString
    Private _odata As New cAstorWebData(dsn)
    Private dsLocal As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SearchParms") = Nothing
        Session("ReturnUrl") = Nothing
        'If Request.QueryString("c") Is Nothing Then
        '    Response.Cookies("TestCookie").Value = "ok"
        '    Response.Cookies("TestCookie").Expires = DateTime.Now.AddMinutes(1)
        '    'Redirect("TestForCookies.aspx?redirect=" & "~/Default.aspx", RedirectOptions.AbsoluteHttp) 'Server.UrlEncode(Request.Url.ToString))https_transfer_6/18/08
        '    Response.Redirect("TestForCookies.aspx?redirect=" & "~/Default.aspx")
        'Else
        '    Select Case Request.QueryString("c").ToString
        '        Case 0
        '            labelAcceptsCookies.Text = "Please enable cookies to use this site!<br /><br />"
        '        Case 1
        labelAcceptsCookies.Visible = False
        '    End Select

        'End If

        With videoTout1
            .VideoID = "21414275"
            .VideoHeight = "225"
            .VideoWidth = "315"
        End With

        If Not Page.IsPostBack Then

            '     Dim dateTimeInfo As DateTime = DateTime.Now

            '      Dim sMonthYear As String = Replace(dateTimeInfo.ToString("y"), " ", "")
            '       sMonthYear = Replace(sMonthYear, ",", "")

            '            hyplNewsletter.NavigateUrl = "~/images/newsletters/AW-" & sMonthYear & "NEWS.pdf"


            '            GetFeaturesData()

        End If

    End Sub
    'Private Sub GetFeaturesData()
    '    Try

    '        Dim _oAstorCommon As New cAstorCommon
    '        Dim sPageName As String = String.Empty
    '        Dim iPageNum As Int16

    '        sPageName = Page.ToString
    '        'mstrPageName &= Page.ClientQueryString.ToString

    '        sPageName = Replace(sPageName, "ASP.", "")
    '        sPageName = Replace(sPageName, "_aspx", "")
    '        sPageName = sPageName.ToLower
    '        iPageNum = _oAstorCommon.GetPageNumber(sPageName)
    '        dsLocal = _odata.GetFeatures(iPageNum, 0, 0)
    '        '  SetUpControl()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    'Private Sub SetUpControl()

    '    Dim tableRows As Integer = dsLocal.Tables(0).Rows.Count

    '    If tableRows > 0 Then
    '        With dsLocal.Tables(0).Rows(0)
    '            ' img_as_hp_1_1.ImageUrl = .Item("sImageLocation")
    '            ' img_as_hp1_hd.ImageUrl = .Item("sFeatureHeaderImageLocation")
    '            ' hyplBasePage1LearnMore.ImageUrl = .Item("sLearnMoreLocation")
    '            ' hyplBasePage1LearnMore.PostBackUrl = .Item("sLearnMoreURL")
    '            ' lblHP1_1.Text = .Item("sFeatureDesclong")
    '        End With

    '        If tableRows > 1 Then
    '            With dsLocal.Tables(0).Rows(1)
    '                imgbHP31.ImageUrl = .Item("sImageLocation")
    '                imgbHP31.PostBackUrl = .Item("sLearnMoreURL")
    '                imgbHP3_2.ImageUrl = .Item("sFeatureHeaderImageLocation")
    '                imgbHP3_2.PostBackUrl = .Item("sLearnMoreURL")
    '                imgHP3LearnMore.ImageUrl = .Item("sLearnMoreLocation")
    '                imgHP3LearnMore.PostBackUrl = .Item("sLearnMoreURL")
    '                lblHP3_1.Text = .Item("sFeatureDesc")
    '            End With

    '            If tableRows > 2 Then
    '                With dsLocal.Tables(0).Rows(2)
    '                    imgbHP41.ImageUrl = .Item("sImageLocation")
    '                    imgbHP41.PostBackUrl = .Item("sLearnMoreURL")
    '                    imgbHP4_2.ImageUrl = .Item("sFeatureHeaderImageLocation")
    '                    imgbHP4_2.PostBackUrl = .Item("sLearnMoreURL")
    '                    imgHP4LearnMore.ImageUrl = .Item("sLearnMoreLocation")
    '                    imgHP4LearnMore.PostBackUrl = .Item("sLearnMoreURL")
    '                    lblHP4_1.Text = .Item("sFeatureDesc")
    '                End With
    '            Else
    '                imgbHP41.ImageUrl = "~/images/features/as_free_tastings.png"
    '                imgbHP41.PostBackUrl = "~/TastingEvents.aspx"
    '                imgbHP4_2.ImageUrl = "~/images/as_freetastings_hd.gif"
    '                imgbHP4_2.Width = 160
    '                imgbHP4_2.PostBackUrl = "~/TastingEvents.aspx"
    '                imgHP4LearnMore.ImageUrl = "~/images/as_LearnMore.gif"
    '                imgHP4LearnMore.PostBackUrl = "~/TastingEvents.aspx"
    '                lblHP4_1.Text = "We love to let you know what we know by teaching and tasting. Find out what's pouring..."
    '            End If
    '        Else
    '            imgbHP31.ImageUrl = "~/images/features/as_landmarkstore_hd.png"
    '            imgbHP31.PostBackUrl = "~/AstorLandmarkStore.aspx"
    '            imgbHP3_2.ImageUrl = "~/images/as_hp4_hdb.gif"
    '            imgbHP3_2.PostBackUrl = "~/AstorLandmarkStore.aspx"
    '            imgHP3LearnMore.ImageUrl = "~/images/as_LearnMore.gif"
    '            imgHP3LearnMore.PostBackUrl = "~/AstorLandmarkStore.aspx"
    '            lblHP3_1.Text = "Astor Wines & Spirits has been a Greenwich Village fixture since 1946."

    '            imgbHP41.ImageUrl = "~/images/features/as_free_tastings.png"
    '            imgbHP41.PostBackUrl = "~/TastingEvents.aspx"
    '            imgbHP4_2.ImageUrl = "~/images/as_freetastings_hd.gif"
    '            imgbHP4_2.Width = 160
    '            imgbHP4_2.PostBackUrl = "~/TastingEvents.aspx"
    '            imgHP4LearnMore.ImageUrl = "~/images/as_LearnMore.gif"
    '            imgHP4LearnMore.PostBackUrl = "~/TastingEvents.aspx"
    '            lblHP4_1.Text = "We love to let you know what we know by teaching and tasting. Find out what's pouring..."

    '        End If
    '    Else
    '        imgbHP31.ImageUrl = "~/images/features/as_landmarkstore_hd.png"
    '        imgbHP31.PostBackUrl = "~/AstorLandmarkStore.aspx"
    '        imgbHP3_2.ImageUrl = "~/images/as_hp4_hdb.gif"
    '        imgbHP3_2.PostBackUrl = "~/AstorLandmarkStore.aspx"
    '        imgHP3LearnMore.ImageUrl = "~/images/as_LearnMore.gif"
    '        imgHP3LearnMore.PostBackUrl = "~/AstorLandmarkStore.aspx"
    '        lblHP3_1.Text = "Astor Wines & Spirits has been a Greenwich Village fixture since 1946."

    '        imgbHP41.ImageUrl = "~/images/features/as_free_tastings.png"
    '        imgbHP41.PostBackUrl = "~/TastingEvents.aspx"
    '        imgbHP4_2.ImageUrl = "~/images/as_freetastings_hd.gif"
    '        imgbHP4_2.Width = 160
    '        imgbHP4_2.PostBackUrl = "~/TastingEvents.aspx"
    '        imgHP4LearnMore.ImageUrl = "~/images/as_LearnMore.gif"
    '        imgHP4LearnMore.PostBackUrl = "~/TastingEvents.aspx"
    '        lblHP4_1.Text = "We love to let you know what we know by teaching and tasting. Find out what's pouring..."


    '    End If

    'End Sub
    'Protected Sub imgHP4LearnMore_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgHP4LearnMore.Click, imgbHP4_2.Click, imgbHP41.Click
    '    Redirect("~/SpecialPacks.aspx?packitem=17933", RedirectOptions.AbsoluteHttp)
    'End Sub

    'Protected Sub imgHP3LearnMore_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgHP3LearnMore.Click, imgbHP3_2.Click, imgbHP31.Click
    '    Redirect("~/Features.aspx?featurepage=1_3_0_38", RedirectOptions.AbsoluteHttp)
    'End Sub
End Class
