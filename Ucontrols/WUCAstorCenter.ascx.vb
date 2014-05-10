Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports WebCommon

Partial Class Ucontrols_WUCAstorCenter
    Inherits System.Web.UI.UserControl

    Private _connectionString As String

    Public Property connectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property

    Public Function readUpcomingAstorCenterClasses() As DataSet
        Dim sSP As String = "sp_readUpcomingAstorClasses"
        Dim _cnConnection As New SqlConnection(connectionString)
        Dim _scSC As New SqlCommand(sSP, _cnConnection)
        Dim _daLocal As New SqlDataAdapter
        Dim dsReturn As New DataSet

        With _scSC
            .CommandType = CommandType.StoredProcedure

            _daLocal = New SqlDataAdapter(_scSC)
            _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

            Try
                _daLocal.Fill(dsReturn)
            Catch ex As Exception
                Throw ex

            Finally
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End Try
        End With

        Return dsReturn
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        classes.DataSource = readUpcomingAstorCenterClasses()
        classes.DataBind()
        DateCheck()

    End Sub

    Public Function makeLink(ByVal inputString As String) As String
        Dim urlFirstPart As String = "class-.aspx?class="
        inputString = Trim(inputString.Replace(".", ""))
        inputString = inputString.Replace(" ", "-")
        inputString = makeSafeForUrl(inputString)
        inputString = System.Web.HttpUtility.UrlEncode(inputString)
        While inputString.Contains("--")
            inputString = inputString.Replace("--", "-")
        End While
        inputString = "http://www.astorcenternyc.com/" & urlFirstPart & inputString.ToLower & "&amp;utm_campaign=EventsatAstorCenter"
        Return inputString
    End Function

    Private Function makeSafeForUrl(ByVal givenString As String) As String
        givenString = givenString.Replace("é", "e")
        givenString = givenString.Replace("&", "")
        givenString = givenString.Replace(":", "")
        givenString = givenString.Replace(",", "")
        givenString = givenString.Replace("/", "")
        givenString = givenString.Replace("?", "")
        givenString = givenString.Replace("!", "")
        givenString = givenString.Replace("’", "")
        givenString = givenString.Replace("(", "")
        givenString = givenString.Replace(")", "")
        givenString = givenString.Replace("[", "")
        givenString = givenString.Replace("]", "")
        givenString = givenString.Replace("ñ", "n")
        givenString = givenString.Replace("â", "a")
        givenString = givenString.Replace("ó", "o")
        givenString = givenString.Replace("í", "i")
        Return givenString
    End Function

    Public Function htmlEncode(ByVal givenString As String) As String
        Return System.Web.HttpUtility.HtmlEncode(givenString)
    End Function

    Protected Sub classes_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles classes.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row


            Dim sFilePath As String
            Dim sFilePath2 As String
            sFilePath = System.Web.HttpContext.Current.Server.MapPath("~/images/ACclasses/thumbs/")
            sFilePath2 = "~/images/ACclasses/thumbs/"

            If File.Exists(sFilePath & myRow("sitemap_id").ToString & ".jpg") Then
                CType(e.Item.FindControl("imgClassPic"), Image).ImageUrl = sFilePath2 & myRow("sitemap_id").ToString & ".jpg"
            Else
                CType(e.Item.FindControl("imgClassPic"), Image).ImageUrl = sFilePath2 & "default.jpg"
            End If

            CType(e.Item.FindControl("litDate"), Literal).Text = myRow("dtclassdatestart").ToString
        End If
    End Sub

    Sub DateCheck()
        If Date.Now > #3/2/2013# Then
            pnlCustom.Visible = False
            classes.Visible = True
        Else
            pnlCustom.Visible = True
            classes.Visible = False
        End If

    End Sub

End Class


