Imports System.Data
Imports WebCommon
Partial Class Ucontrols_WUCOrderDetails
    Inherits System.Web.UI.UserControl
    Private _sInum As String
    Public Property Inum() As String
        Get
            Return _sInum
        End Get
        Set(ByVal value As String)
            _sInum = value
        End Set
    End Property
    Public Sub PopulateDetails()
        Dim dsOrderDetail As New DataSet
        Dim Orderdetail As New AstorwinesCommerce.OrdersDB(WebAppConfig.ConnectString)
        Dim _oWebCommon As New WebPageBase

        dsOrderDetail = Orderdetail.GetOrderForCustomerFormatted(_oWebCommon.GetCustomerID(Request, Response), _sInum)
        datMyList.DataSource = dsOrderDetail.Tables(1)
        datMyList.DataBind()

    End Sub
End Class
