Imports WebCommon

Partial Class AstorWaitList

    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim email As String = String.Empty
            Dim item As String = String.Empty
            Dim itemDesc As String = String.Empty
            Dim cart As New AstorwinesCommerce.CartDB(getConnStr())

            If Not Session("ReturnUrl") Is Nothing Then
                ReturnUrl.Value = Session("ReturnUrl")
                Session("ReturnUrl") = Nothing

            Else
                ReturnUrl.Value = "~/default.aspx"
            End If

            If Not IsNothing(Request.QueryString("item")) Then
                item = Request.QueryString("item")
            Else
                Response.Redirect("~/default.aspx")
            End If

            If Not IsNothing(Request.QueryString("email")) Then
                email = Request.QueryString("email")
            End If

            itemDesc = cart.GetItemDescription(item)
            lblTitle.Text = itemDesc
            lblItem.Text = "#" & item
            txtYourEmail.Text = email

        End If
    End Sub

    Protected Sub cmdConfirm_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles cmdConfirm.Click
        Dim cart As New AstorwinesCommerce.CartDB(getConnStr())
        Dim Email As String = txtYourEmail.Text
        Dim Item As String = String.Empty

        If Not IsNothing(Request.QueryString("item")) Then
            Item = Request.QueryString("item")
        Else
            Response.Redirect(ReturnUrl.Value)
        End If


        cart.AddItemOutOfStockNotifyList(Email, Item)
        Body.Attributes.Add("onload", "window.parent.CB_Close();")

        'Response.Redirect(ReturnUrl.Value)

    End Sub
End Class
