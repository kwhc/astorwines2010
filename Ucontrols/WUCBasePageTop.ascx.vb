Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools
Partial Class Ucontrols_WUCBasePageTop
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
            SetUpControl()
            '            BindResultDataList()
           
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetUpControl()
        With dsLocal.Tables(0).Rows(0)
            'img_basepage_1_1.ImageUrl = .Item("sImageLocation")
            'img_basepage1_hd.ImageUrl = .Item("sFeatureHeaderImageLocation")
            'hyplBasePage1LearnMore.ImageUrl = .Item("sLearnMoreLocation")
            'hyplBasePage1LearnMore.NavigateUrl = .Item("sLearnMoreURL")
            lblbasepage1_1.Text = .Item("sFeatureDesc")

        End With
       
        'With dsLocal.Tables(0).Rows(1)
        '    img_basepage_2_1.ImageUrl = .Item("sImageLocation")
        '    img_basepage_2_hd.ImageUrl = .Item("sHeaderImageLocation")
        '    imgb_basepage2_learnmore.ImageUrl = .Item("sLearnMoreLocation")
        '    imgb_basepage2_learnmore.PostBackUrl = .Item("sLearnMoreURL")
        '    lblbasepage2_1.Text = .Item("sFeatureDesc")

        'End With
        'With dsLocal.Tables(0).Rows(2)
        '    img_basepage_3_1.ImageUrl = .Item("sImageLocation")
        '    img_basepage_3_hd.ImageUrl = .Item("sHeaderImageLocation")
        '    imgb_basepage3_learnmore.ImageUrl = .Item("sLearnMoreLocation")
        '    imgb_basepage3_learnmore.PostBackUrl = .Item("sLearnMoreURL")
        '    lblbasepage3_1.Text = .Item("sFeatureDesc")

        'End With
        'With dsLocal.Tables(0).Rows(3)
        '    img_basepage_4_1.ImageUrl = .Item("sImageLocation")
        '    img_basepage_4_hd.ImageUrl = .Item("sHeaderImageLocation")
        '    imgb_basepage4_learnmore.ImageUrl = .Item("sLearnMoreLocation")
        '    imgb_basepage4_learnmore.PostBackUrl = .Item("sLearnMoreURL")
        '    lblbasepage4_1.Text = .Item("sFeatureDesc")

        'End With
        'With dsLocal.Tables(0).Rows(4)
        '    img_basepage_5_1.ImageUrl = .Item("sImageLocation")
        '    img_basepage_5_hd.ImageUrl = .Item("sHeaderImageLocation")
        '    imgb_basepage5_learnmore.ImageUrl = .Item("sLearnMoreLocation")
        '    imgb_basepage5_learnmore.PostBackUrl = .Item("sLearnMoreURL")
        '    lblbasepage5_1.Text = .Item("sFeatureDesc")

        'End With


    End Sub
    'Private Sub BindResultDataList()
    '    Try
    '        dvLocal.Table = dsLocal.Tables(0)
    '        dvLocal.RowFilter = "iLocation > 1"
    '        datPageBaseBottom.DataSource = dvLocal

    '        datPageBaseBottom.DataBind()


    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Protected Sub datPageBaseBottom_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datPageBaseBottom.ItemCommand
    '    Dim item As LinkButton
    '    Dim navURL As String
    '    item = e.Item.FindControl("imgb_pagebase1_learnmore")
    '    navURL = item.CommandArgument

    '    Redirect(navURL, RedirectOptions.AbsoluteHttp)

    'End Sub

    'Protected Sub datPageBaseBottom_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datPageBaseBottom.ItemDataBound
    '    If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
    '        Dim myRowView As DataRowView
    '        Dim myRow As DataRow

    '        myRowView = e.Item.DataItem
    '        myRow = myRowView.Row


    '        CType(e.Item.FindControl("imgb_pagebase_1_1"), Image).ImageUrl = myRow("sSmImageLocation")
    '        CType(e.Item.FindControl("imgb_pagebase_1_hd"), Image).ImageUrl = myRow("sFeatureHeaderImageLocation")
    '        'CType(e.Item.FindControl("imgb_pagebase1_learnmore"), ImageButton).ImageUrl = myRow("sLearnMoreLocation")
    '        CType(e.Item.FindControl("imgb_pagebase1_learnmore"), LinkButton).CommandArgument = myRow("sLearnMoreURL")
    '        CType(e.Item.FindControl("lblpagebase1_1"), Label).Text = myRow("sFeatureDesc")

    '    End If
    'End Sub
End Class
