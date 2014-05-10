
Partial Class Ucontrols_WUCFeatures
    Inherits System.Web.UI.UserControl

    Dim feature1ImgUrl As String
    Dim feature1Page As String
    Dim feature2ImgUrl As String
    Dim feature2Page As String
    Dim feature3ImgUrl As String
    Dim feature3Page As String
    Dim feature4ImgUrl As String
    Dim feature4Page As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        feature1ImgUrl = "../images/features/feature_1.jpg"
        'feature1Page = "http://tastingnotesnyc.com/2013/11/22/beaujolais-nouveau-2013-winners/"
        feature1Page = "/Features.aspx?featurepage=9_1_1_126"
        feature2ImgUrl = "../images/features/feature_2.jpg"
        feature2Page = "/Features.aspx?featurepage=9_2_1_127"
        feature3ImgUrl = "../images/features/feature_3.jpg"
        feature3Page = "/Features.aspx?featurepage=9_3_1_128"
        feature4ImgUrl = "../images/features/feature_4.jpg"
        feature4Page = "/Features.aspx?featurepage=9_4_1_122"

        roseDaySalePromo()

            imgFeature1.ImageUrl = feature1ImgUrl
            hlFeature1.NavigateUrl = feature1Page
            imgFeature2.ImageUrl = feature2ImgUrl
            hlFeature2.NavigateUrl = feature2Page
            imgFeature3.ImageUrl = feature3ImgUrl
            hlFeature3.NavigateUrl = feature3Page
            imgFeature4.ImageUrl = feature4ImgUrl
            hlFeature4.NavigateUrl = feature4Page

    End Sub

    Sub roseDaySalePromo()
        If Date.Now >= #5/10/2014# And Date.Now <= #5/11/2014#.AddDays(1) Then
            feature1ImgUrl = "../images/features/feature_1_roseDaySale.jpg"
            feature1Page = "../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&color=Rosé" & "&ref=hf"
        End If
    End Sub
End Class
