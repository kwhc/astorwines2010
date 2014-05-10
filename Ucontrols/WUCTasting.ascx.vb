
Partial Class Ucontrols_WUCTasting
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tastingsSQLAdapter As New astorWinesTableAdapters.tblEventsTableAdapter
        Dim tastingsDatatable As astorWines.tblEventsDataTable = tastingsSQLAdapter.GetEventsByStartDate(Now)
        freeTastingsList.DataSource = tastingsDatatable
        freeTastingsList.DataBind()
    End Sub
End Class
