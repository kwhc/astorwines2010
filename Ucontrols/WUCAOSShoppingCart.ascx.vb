Imports WebCommon
Imports System.Data
Partial Class Ucontrols_WUCAOSShoppingCart
    Inherits System.Web.UI.UserControl
    Private email As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Context.User.Identity.Name <> "" Then
            email = Context.User.Identity.Name
        Else
            email = ""
        End If

        PopulateAOSShoppingCartList()

    End Sub
    Sub PopulateAOSShoppingCartList()
        Dim _oWebCommon As New WebPageBase
        ' Popoulate list with updated shopping cart data
        Dim cart As New AstorwinesCommerce.CartDB(_oWebCommon.getConnStr())
        Dim dsAOSShoppingCart As DataSet = cart.GetShoppingCartAOSItems(_oWebCommon.GetCustomerID(Request, Response))



        datMyList.DataSource = dsAOSShoppingCart
        datMyList.DataBind()


       
    End Sub

    Protected Sub datResults_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datMyList.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow
            Dim iLevel1Type As Int16
            Dim sInfo As String = String.Empty
            'Out of Stock Messages
            Dim outOfStockMsg As String = "<p>This item is currently out of stock.</p>"
            Dim preOrderMsg As String = "<p>This item is expected to arrive soon.</p>"
            Dim reorderMsg As String = "<p>This is expected to be back in stock soon.</p>"

            myRowView = e.Item.DataItem
            myRow = myRowView.Row

            'If myRow("IsItemAvailable").ToString() = "AIS" Then
            '    e.Item.FindControl("pnlInStock").Visible = True
            '    e.Item.FindControl("pnlOutOfStock").Visible = False
            '    CType(e.Item.FindControl("litOutOfStockMsg"), Literal).Text = ""
            'Else
            'e.Item.FindControl("pnlInStock").Visible = False
            e.Item.FindControl("pnlOutOfStock").Visible = True
            CType(e.Item.FindControl("litOutOfStockMsg"), Literal).Text = outOfStockMsg
            CType(e.Item.FindControl("WaitLink"), Literal).Text = "<a href='/secure/AstorWaitList.aspx?item=" + myRow("item") + "&email=" + email + "&height=300&width=200' rel='clearbox[width=300,,height=200]' >Notify Me When This Is Back In &#187;</a>"
            'End If

        End If
    End Sub
End Class
