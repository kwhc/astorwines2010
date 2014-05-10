Imports AstorDataClass
Imports System.Data
Imports WebCommon
Partial Class Ucontrols_WUCTouts1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Or Session("Touts") Is Nothing Then
            GetToutsData()
        End If
        BindToutsData()
    End Sub
    Private Sub GetToutsData()
        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet

        Try

            dsLocal = _odata.GetFeatures(10, 2, 0)
            Session("Touts") = dsLocal.Tables(0)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub BindToutsData()
        datlstTouts.DataSource = Session("Touts")
        datlstTouts.DataBind()
    End Sub

    Protected Sub datlistTouts_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datlstTouts.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row
            CType(e.Item.FindControl("hyplLearnMore"), HyperLink).ToolTip = "Click to Learn More about " + RTrim(myRow("sFeature"))
            CType(e.Item.FindControl("hyplLearnMore"), HyperLink).NavigateUrl = RTrim(myRow("sLearnMoreURL"))
            'If RTrim(myRow("sHeaderImageLocation").ToString) = "" Then
            '    e.Item.FindControl("imgFeature").Visible = False

            'End If
        End If
    End Sub
End Class
