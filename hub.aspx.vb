Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
Partial Class hub
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SearchParms") = Nothing

        Dim pageClass As String
        pageClass = Request.QueryString("class")

        Select Case pageClass
            Case "wine"
                hubTitle.Text = "Wines"
                WUCDailyFeatures1.feature = 4
                WUCDailyFeatures2.feature = 5
                WUCDailyFeatures3.feature = 6
                pnlWine.Visible = True

            Case "spirits"
                hubTitle.Text = "Spirits"
                WUCDailyFeatures1.feature = 10
                WUCDailyFeatures2.feature = 11
                WUCDailyFeatures3.feature = 12
                pnlSpirits.Visible = True
                spiritSpecial.Visible = True

            Case "sake"
                hubTitle.Text = "Sak&#233;"
                WUCDailyFeatures1.feature = 7
                WUCDailyFeatures2.feature = 8
                WUCDailyFeatures3.feature = 9
                pnlSake.Visible = True
        End Select

    End Sub
End Class
