Imports WebCommon
Imports System.Data.SqlClient

'Imports SslTools
Partial Class Testimonials
    Inherits WebPageBase
    Sub loadPress()

        Dim title As String = String.Empty
        Dim author As String = String.Empty
        Dim body As String = String.Empty
        Dim source As String = String.Empty
        Dim link As String = String.Empty
        Dim postDate As DateTime
        Dim imgUrl As String = String.Empty

        Dim reader As SqlDataReader
        Dim query As String
        query = "select title,body,author,source,link,postDate,imgUrl,postType from press"
        Dim conn As New SqlConnection
        conn.ConnectionString = ConfigurationManager.ConnectionStrings("astorCMSConnectionString").ToString
        Dim comm As New SqlCommand(query, conn)

        Try
            conn.Open()
            reader = comm.ExecuteReader()
            rptPress.DataSource = reader
            rptPress.DataBind()
            reader.Close()
        Catch ex As Exception
        Finally
            conn.Close()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadPress()
    End Sub

    Dim i As Integer = 0

    Protected Sub rptPress_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptPress.ItemDataBound

        If i Mod 2 Then
            CType(e.Item.FindControl("divTitle"), HtmlGenericControl).Style.Add("background-color", "#784445")
        Else
            CType(e.Item.FindControl("divTitle"), HtmlGenericControl).Style.Add("background-color", "#ab6163")
        End If

        If String.IsNullOrEmpty(e.Item.DataItem("imgUrl").ToString) Then
            e.Item.FindControl("hypImg").Visible = False
        End If

        If Not String.IsNullOrEmpty(e.Item.DataItem("author").ToString) Then
            CType(e.Item.FindControl("litAuthor"), Literal).Text = e.Item.DataItem("author").ToString & ", "
        End If

        Select Case e.Item.DataItem("postType")
            Case 0
            Case 1
                CType(e.Item.FindControl("litIcon"), Literal).Text = "<i class=""icon-heart icon-3x""></i>"
            Case 2
                CType(e.Item.FindControl("litIcon"), Literal).Text = "<i class=""icon-trophy icon-3x""></i>"
            Case 3
                CType(e.Item.FindControl("litIcon"), Literal).Text = "<i class=""icon-user icon-3x""></i>"
        End Select

        i += 1

    End Sub
End Class