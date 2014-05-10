Imports System.Data


Partial Class Ucontrols_whatsHot
    Inherits UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        setWhatsHot()
    End Sub
    Private Sub setWhatsHot()


        Dim wh1Title As String = String.Empty
        Dim wh1Link As String = String.Empty
        Dim wh2Title As String = String.Empty
        Dim wh2Link As String = String.Empty
        Dim wh3Title As String = String.Empty
        Dim wh3Link As String = String.Empty
        Dim wh4Title As String = String.Empty
        Dim wh4Link As String = String.Empty

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("astorCMSConnectionString").ConnectionString
        Dim dsLocal As New DataSet
        Dim oAWSCMS As New cAstorWinesCMS(connectionString)
        Dim drRow As DataRow

        dsLocal = oAWSCMS.GetCMSWhatsHot()

        Try

            If dsLocal.Tables(0).Rows.Count > 0 Then
                For Each drRow In dsLocal.Tables(0).Rows

                    Dim pk As Integer
                    pk = CType(drRow.Item("id_whatsHot"), Integer)

                    Dim whTitle As String = drRow.Item("title_whatsHot").ToString.Trim
                    Dim whUrl As String = drRow.Item("url_whatsHot").ToString.Trim

                    Select Case pk
                        Case 2
                            wh1Title = whTitle
                            wh1Link = whUrl
                        Case 3
                            wh2Title = whTitle
                            wh2Link = whUrl
                        Case 5
                            wh3Title = whTitle
                            wh3Link = whUrl
                        Case 6
                            wh4Title = whTitle
                            wh4Link = whUrl
                    End Select
                Next

            End If

        Catch ex As Exception
            Throw
        Finally

        End Try


        'wh1Text = "Bordeaux"
        'wh1Link = "../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&country=France&region=Bordeaux"

        'wh2Text = "Bubbles"
        'wh2Link = "../WineSearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=&cat=1&style=2&sparkling=True"

        'wh3Text = "Gordon Macphail Indie Bottles"
        'wh3Link = "../SearchResult.aspx?search=&searchtype=Contains&term=Gordon,Macphail&p=2"

        'wh4Text = "Laurent Cazottes"
        'wh4Link = "../SpiritsSearchResult.aspx?p=2&search=Advanced&searchtype=Contains&term=&cat=2&producer=Laurent+Cazottes"

        whatsHot1.Text = wh1Title
        whatsHot1.NavigateUrl = wh1Link & "&ref=whatshot"
        whatsHot2.Text = wh2Title
        whatsHot2.NavigateUrl = wh2Link & "&ref=whatshot"
        whatsHot3.Text = wh3Title
        whatsHot3.NavigateUrl = wh3Link & "&ref=whatshot"
        whatsHot4.Text = wh4Title
        whatsHot4.NavigateUrl = wh4Link & "&ref=whatshot"

    End Sub


End Class
