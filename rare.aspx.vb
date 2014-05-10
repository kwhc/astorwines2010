Imports System.Data.SqlClient

Partial Class rare
    Inherits System.Web.UI.Page

    Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("astorwebdatabase20ConnectionString").ConnectionString)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Page.Title = "Rare Items at Astor Wines & Spirits"

            If isLoggedIn() Then
                cblItems.Enabled = True
                btnSubmit.Enabled = True
                checkSelections()
            Else
                cblItems.Enabled = False
                cblItems.Attributes.Add("class", "muted")
                btnSubmit.Enabled = False
                litMsg.Text = "Please <a href=""/secure/AstorSignIn.aspx?si=2"">login or create an account</a> to make your selection."
            End If

            Session.Item("page") = "rare.aspx"
        End If
    End Sub

    Function isLoggedIn() As Boolean
        If Context.User.Identity.IsAuthenticated Then
            isLoggedIn = True
        Else
            isLoggedIn = False
        End If
    End Function

    Sub submitSelections()

        Dim cusId As String = String.Empty
        cusId = Context.User.Identity.Name

        'Dim selections As New ArrayList
        Dim selection As String

        For Each item As ListItem In cblItems.Items
            If item.Selected Then
                'selections.Add(item.Value)
                selection = item.Value

                Dim comm As New SqlCommand("spReserveUserSelectionsInsert", conn)
                comm.CommandType = Data.CommandType.StoredProcedure

                comm.Parameters.Add("@userEmail", System.Data.SqlDbType.VarChar, 50)
                comm.Parameters("@userEmail").Value = cusId

                comm.Parameters.Add("@selection", System.Data.SqlDbType.VarChar, 200)
                comm.Parameters("@selection").Value = selection

                comm.Parameters.Add("@dtAdded", System.Data.SqlDbType.DateTime)
                comm.Parameters("@dtAdded").Value = Date.Now

                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    Dim successJquery As String = "<script type=""text/javascript"">" & _
                    "$(document).ready(function(){" & _
                    "event.preventDefault();" & _
                    "$('#successMsg').modal();" & _
                    "});" & _
                    "</script>"
                    litJS.Text = successJquery
                    'litMsg.Text = "<span class=""text-success"">My selections were entered successfully.</span>"
                    'litMsg.Text = successJquery
                    'Page.ClientScript.RegisterStartupScript(Me.GetType, "selectionSuccess", successJquery, True)

                Catch ex As Exception
                    'litMsg.Text = "Oops"
                Finally
                    conn.Close()

                End Try
            ElseIf item.Selected = False Then 'if not selected
                'if exists, delete row
                selection = item.Value

                Dim comm As New SqlCommand("spReserveUserSelectionsDelete", conn)
                comm.CommandType = Data.CommandType.StoredProcedure

                comm.Parameters.Add("@cusEmail", System.Data.SqlDbType.VarChar, 50)
                comm.Parameters("@cusEmail").Value = cusId

                comm.Parameters.Add("@item", System.Data.SqlDbType.VarChar, 200)
                comm.Parameters("@item").Value = selection

                Try
                    conn.Open()
                    comm.ExecuteNonQuery()
                    'litMsg.Text = "Looking good - delete"
                Catch ex As Exception
                    'litMsg.Text = "Oops delete"
                Finally
                    conn.Close()
                End Try

            End If
        Next

        'Dim selectionList() As String = selections.ToArray(GetType(String))
        'Dim selectionsJoined As String
        'selectionsJoined = Join(selectionList, ",")

        'Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("astorwebdatabase20ConnectionString").ConnectionString)
        'Dim comm As New SqlCommand("insert into tblReserveUserSelections (user_id, reserve_selection) values (@userID, @selections)", conn)

    End Sub

    Sub checkSelections()
        Dim reader As SqlDataReader
        'Dim comm As New SqlCommand("select reserve_selection from tblReserveUserSelections where user_id = @cusEmail", conn)
        Dim comm As New SqlCommand("spReserveUserSelectionsSelect", conn)
        comm.CommandType = System.Data.CommandType.StoredProcedure

        Dim cusEmail As String = String.Empty
        cusEmail = Context.User.Identity.Name

        comm.Parameters.Add("@cusEmail", System.Data.SqlDbType.VarChar, 50)
        comm.Parameters("@cusEmail").Value = cusEmail

        Try
            conn.Open()
            reader = comm.ExecuteReader()
            If reader.HasRows Then
                While reader.Read()
                    Dim selection As String
                    selection = reader.Item("item")
                    cblItems.Items.FindByValue(selection).Selected = True
                End While
                reader.Close()

                'litMsg.Text = selections

                'Dim selectionsArray() As String
                'selectionsArray = Split(selections, ",")

                'For Each selection As String In selectionsArray
                '    cblItems.Items.FindByValue(selection).Selected = True
                'Next

            Else
                'litMsg.Text = "No selections."
            End If
        Catch ex As Exception
            litMsg.Text = "Error retrieving data."
        Finally
            conn.Close()
        End Try
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        submitSelections()
    End Sub
End Class
