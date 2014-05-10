Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class Ucontrols_WUCNoResultBottom
    Inherits System.Web.UI.UserControl
    Private dsn As String = WebAppConfig.ConnectString

    Private _odata As New cAstorWebData(dsn)
    Private dsLocal As DataSet
    Private dvLocal As New DataView
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GetFeaturesData()
        End If



    End Sub

    Private Sub GetFeaturesData()
        Try

            Dim _oAstorCommon As New cAstorCommon
            Dim sPageName As String = String.Empty
            Dim iPageNum As Int16

            sPageName = Page.ToString
            'mstrPageName &= Page.ClientQueryString.ToString

            sPageName = Replace(sPageName, "ASP.", "")
            sPageName = Replace(sPageName, "_aspx", "")
            sPageName = sPageName.ToLower
            iPageNum = _oAstorCommon.GetPageNumber(sPageName)
            dsLocal = _odata.GetFeatures(iPageNum, 0, 0)
            If dsLocal.Tables.Count > 0 Then
                BindResultDataList()
            End If
            'SetUpControl()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    
    Private Sub BindResultDataList()
        Try
           
            'Set the DataSource of the datalist
            dvLocal.Table = dsLocal.Tables(0)
            dvLocal.RowFilter = "iLocation > 1"

            datNoResultsBottom.DataSource = dvLocal

            datNoResultsBottom.DataBind()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub datNoResultsBottom_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datNoResultsBottom.ItemCommand
        Dim item As ImageButton
        Dim navURL As String
        item = e.Item.FindControl("imgb_noresult1_learnmore")
        navURL = item.CommandArgument

        'Redirect(navURL, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
        Response.Redirect(navURL)
    End Sub

    Protected Sub datNoResultsBottom_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datNoResultsBottom.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row


            CType(e.Item.FindControl("imgb_noresult_1_1"), Image).ImageUrl = myRow("sSmImageLocation")
            CType(e.Item.FindControl("imgb_noresult_1_hd"), Image).ImageUrl = myRow("sFeatureHeaderImageLocation")
            CType(e.Item.FindControl("imgb_noresult1_learnmore"), ImageButton).ImageUrl = myRow("sLearnMoreLocation")
            CType(e.Item.FindControl("imgb_noresult1_learnmore"), ImageButton).CommandArgument = myRow("sLearnMoreURL")
            CType(e.Item.FindControl("lblnoresult1_1"), Label).Text = myRow("sFeatureDesc")

        End If
    End Sub
End Class
