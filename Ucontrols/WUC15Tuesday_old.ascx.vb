
Imports WebCommon
Imports AstorDataClass
Imports System.Data
Partial Class Ucontrols_WUC15Tuesday_old
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim tuesdayEventsSQLAdapter As New astorWinesTableAdapters.tblWebSpecialFeaturesTableAdapter
            Dim tuesdayEventsDatatable As astorWines.tblWebSpecialFeaturesDataTable = tuesdayEventsSQLAdapter.GetTuesdayEventsByDate(Now.Date)
            If tuesdayEventsDatatable.Rows.Count > 0 Then
                Dim tuesdayEventRow As astorWines.tblWebSpecialFeaturesRow = tuesdayEventsDatatable.Rows(0)
                tuesdayLink.Text = tuesdayEventRow.sFeatureDesc
                tuesdayLink.NavigateUrl = "../AstorTuesdays.aspx?r=" & tuesdayEventRow.iRow
            Else
                tuesdayLink.NavigateUrl = "../AstorTuesdays.aspx"
            End If
        End If

    End Sub
End Class
