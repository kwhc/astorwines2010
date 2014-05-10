Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class secure_MyAccountOrderHistory
    Inherits WebPageBase
    Private Orders As New AstorwinesCommerce.OrdersDB(getConnStr())
    Private dsOrder As New DataSet
    Private dsn As String = WebAppConfig.ConnectString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Try

                dsOrder = Orders.GetOrdersForCustomerFormatted(GetCustomerID(Request, Response))
                Dim strUrl As String = Request.Url.ToString()
                Session("ReturnUrl") = strUrl

                If dsOrder.Tables.Count > 0 Then
                    If dsOrder.Tables(0).Rows.Count > 0 Then
                        lblNoOrders.Visible = False
                        BindResultDataList()

                    Else
                        lblNoOrders.Visible = True
                    End If
                Else
                    lblNoOrders.Visible = True
                End If
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End If
    End Sub
    Private Sub BindResultDataList()
        Try

            colpagSearchResults.DataSource = dsOrder.Tables(0).DefaultView

            'Let the Pager know what Control it needs to DataBind during the PreRender.

            colpagSearchResults.BindToControl = datlOrders
            'The Control now takes the object you are binding to,
            'instead of the name of it (as a string) 

            'Set the DataSource of the Repeater to the PagedData coming from the Pager. 
            datlOrders.DataSource = colpagSearchResults.DataSourcePaged
            datlOrders.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    'Protected Sub datlOrders_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datlOrders.ItemCommand

    '    Dim sInum As String
    '    Dim type As ImageButton
    '    Dim dsOrder As New DataSet
    '    type = e.Item.FindControl("imgbDetail")
    '    sInum = type.CommandArgument
    '    WUCOrderDetails1.Inum = sInum
    '    WUCOrderDetails1.PopulateDetails()

    'End Sub

    Protected Sub datlOrders_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datlOrders.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow
            Dim dsOrderDetail As New DataSet
            Dim Orderdetail As New AstorwinesCommerce.OrdersDB(getConnStr())
            'Dim fTotal As Double = 0

            myRowView = e.Item.DataItem
            myRow = myRowView.Row

            'If myRow("ShipDate") Is DBNull.Value Then
            '    CType(e.Item.FindControl("lblShipInfo"), Label).Text = ""
            'Else
            '    CType(e.Item.FindControl("lblShipInfo"), Label).Text = (myRow("ShipDate")).ToString & ":"
            'End If


            'CType(e.Item.FindControl("imgbDetail"), ImageButton).CommandArgument = myRow("OrderNumber").ToString()
            'CType(e.Item.FindControl("imgbDetail"), ImageButton).ToolTip = "Click to View details for invoice number " + RTrim(myRow("OrderNumber"))
            'CType(e.Item.FindControl("WUCOrderDetails1"), UserControl).Attributes.Item("Inum") = myRow("OrderNumber")

            dsOrderDetail = Orderdetail.GetOrderDetailCompletedForCustomerFormatted(GetCustomerID(Request, Response), myRow("OrderNumber"))
            CType(e.Item.FindControl("datMyList"), DataList).DataSource = dsOrderDetail.Tables(0)
            CType(e.Item.FindControl("datMyList"), DataList).DataBind()


        End If
    End Sub

End Class
