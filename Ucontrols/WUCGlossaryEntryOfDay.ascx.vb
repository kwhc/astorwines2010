
Partial Class Ucontrols_WUCGlossaryEntryOfDay
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim glossaryEntriesSQLAdapter As New astorWinesTableAdapters.tblDefinitionsTableAdapter
        Dim glossaryEntriesDatatable As astorWines.tblDefinitionsDataTable = glossaryEntriesSQLAdapter.GetDefinitions
        If glossaryEntriesDatatable.Rows.Count > 0 Then
            Dim glossaryEntry As astorWines.tblDefinitionsRow
            If glossaryEntriesDatatable.Rows.Count > Now.Day Then
                glossaryEntry = glossaryEntriesDatatable.Rows(Now.Day - 1)
            Else
                glossaryEntry = glossaryEntriesDatatable.Rows(0)
            End If
            entryTitel.Text = glossaryEntry.sTerm
            entryDesc.Text = glossaryEntry.sTermDescription
        End If
    End Sub
End Class
