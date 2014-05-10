
Partial Class Ucontrols_tastingNotesHomepageFeature
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        pnlTastingNotes.Visible = True

        Dim tnFeatureImg As String
        Dim tnFeatureLink As String
        Dim tnRelatedText As String
        Dim tnRelatedLink As String

        tnFeatureImg = "../images/features/tastingNotesFeature/201403_tastingNotes_dirtyAndRowdy.png"
        tnFeatureLink = "http://tastingnotesnyc.com/2014/03/07/meet-the-maker-dirty-rowdy-wines-with-hardy-wallace/" & "?utm_source=astorwines&utm_medium=banner&utm_campaign=homepage"

        tnRelatedText = "Meet the Maker: Hardy Wallace of Dirty & Rowdy Wines"
        tnRelatedLink = "http://tastingnotesnyc.com/2014/03/07/meet-the-maker-dirty-rowdy-wines-with-hardy-wallace/" & "?utm_source=astorwines&utm_medium=banner&utm_campaign=homepage"

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

        'Show/Hide Toggle
        Dim promoBegin As DateTime 'First day of promotion
        Dim promoEnd As DateTime   'Last day of promotion

        promoBegin = #3/24/2014#
        promoEnd = #4/24/2014#.AddDays(1)


        If Date.Now < promoBegin Or Date.Now > promoEnd Then
            pnlTastingNotes.Visible = False
        End If

    End Sub
End Class
