Imports System.Data.SqlClient

Partial Class Ucontrols_tastingNotesHomepageFeature
    Inherits System.Web.UI.UserControl
    Dim tnFeatureImg As String
    Dim tnFeatureLink As String
    Dim tnRelatedText As String
    Dim tnRelatedLink As String
    'Show/Hide Toggle
    Dim promoBegin As DateTime 'First day of promotion
    Dim promoEnd As DateTime   'Last day of promotion

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        pnlTastingNotes.Visible = True

        'staticTastingNotesFeature()
        dbTastingNotesFeature()

        If Date.Now < promoBegin Or Date.Now > promoEnd Then
            pnlTastingNotes.Visible = False
        End If

        imgTastingNotesFeature.ImageUrl = tnFeatureImg
        hypTastingNotesLink.NavigateUrl = tnFeatureLink
        hypRelatedBrowse.Text = "<p>" & tnRelatedText & " <i class=""icon-external-link""></i></p>"
        hypRelatedBrowse.NavigateUrl = tnRelatedLink & "&ref=hptn"

        'Check to see if there is a browse link
        If String.IsNullOrEmpty(tnRelatedText) Then
            hypRelatedBrowse.Visible = False
        Else
            hypRelatedBrowse.Visible = True
        End If

    End Sub

    Sub staticTastingNotesFeature()

        tnFeatureImg = "../images/features/tastingNotesFeature/201403_tastingNotes_dirtyAndRowdy.png"
        tnFeatureLink = "http://tastingnotesnyc.com/2014/03/07/meet-the-maker-dirty-rowdy-wines-with-hardy-wallace/" & "?utm_source=astorwines&utm_medium=banner&utm_campaign=homepage"

        tnRelatedText = "Meet the Maker: Hardy Wallace of Dirty & Rowdy Wines"
        tnRelatedLink = "http://tastingnotesnyc.com/2014/03/07/meet-the-maker-dirty-rowdy-wines-with-hardy-wallace/" & "?utm_source=astorwines&utm_medium=banner&utm_campaign=homepage"

        promoBegin = #5/15/2014#
        promoEnd = #6/24/2014#.AddDays(1)

    End Sub

    Sub dbTastingNotesFeature()

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("astorCMSConnectionString").ConnectionString
        Dim comm As SqlCommand
        Dim reader As SqlDataReader
        Dim conn As New SqlConnection(connectionString)
        Dim query As String = "select [url_promoImage],[url_tastingNotesLink],[bonusLinkTitle],[url_bonusLink],[dt_begin],[dt_end] from aws_TastingNotesHomepagePromo where [dt_begin] < GETDATE() and [dt_end] > GETDATE()"

        comm = New SqlCommand(query, conn)

        Try
            conn.Open()
            reader = comm.ExecuteReader()
            If reader.Read() Then
                tnFeatureImg = reader.Item("url_promoImage").ToString()
                tnFeatureLink = reader.Item("url_tastingNotesLink").ToString()
                tnRelatedText = reader.Item("bonusLinkTitle").ToString()
                tnRelatedLink = reader.Item("url_bonusLink").ToString()
                promoBegin = reader.Item("dt_begin")
                promoEnd = reader.Item("dt_end")
            End If
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

        tnFeatureLink = tnFeatureLink & "?utm_source=astorwines&utm_medium=banner&utm_campaign=homepage"

    End Sub

End Class
