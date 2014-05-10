'Imports SslTools

Partial Class Ucontrols_WUCGlossaryMain
    Inherits System.Web.UI.UserControl


    Protected Sub startSearch(ByVal source As Object, ByVal e As RepeaterCommandEventArgs) Handles searchResults.ItemCommand
        Dim termID As New Guid(e.CommandArgument.ToString)
        showSingleResult(termID)
    End Sub

    Private Sub showSingleResult(ByVal givenID As Guid)
        headerContentFirst.Visible = False
        headerContentSearchResults.Visible = False
        termResult.Visible = True
        EntryOfDay.Visible = False
        Dim glossaryTermsSQLAdapter As New astorWinesTableAdapters.tblDefinitionsTableAdapter
        Dim glossaryTermsDatatable As astorWines.tblDefinitionsDataTable = glossaryTermsSQLAdapter.GetDefinitionsByID(givenID)
        If glossaryTermsDatatable.Rows.Count > 0 Then
            Dim glossaryTerm As astorWines.tblDefinitionsRow = glossaryTermsDatatable.Rows(0)
            resultTitle.Text = glossaryTerm.sTerm
            resultDesc.Text = glossaryTerm.sTermDescription
            relatedItems.term = glossaryTerm.sTerm
            relatedItems.type = glossaryTerm.sTermType
            relatedItems.loadRelatedItem()
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSearch.Click
        headerContentFirst.Visible = False
        EntryOfDay.Visible = True
        termResult.Visible = False
        headerContentSearchResults.Visible = True
        Dim searchTerm As String = Me.glossarySearch.Text
        Dim glossaryTermsSQLAdapter As New astorWinesTableAdapters.tblDefinitionsTableAdapter
        Dim glossaryTermsDatatable As astorWines.tblDefinitionsDataTable = glossaryTermsSQLAdapter.GetDefinitionsByKeyword(searchTerm)
        If glossaryTermsDatatable.Rows.Count > 0 Then
            noResults.Visible = False
            searchResults.Visible = True
            If glossaryTermsDatatable.Rows.Count = 1 Then
                showSingleResult(glossaryTermsDatatable.Rows(0).Item("iRowID"))
            Else
                searchResults.DataSource = glossaryTermsDatatable
                searchResults.DataBind()
            End If
        Else
            noResults.Visible = True
            searchResults.Visible = False
            EntryOfDay.Visible = False
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'glossarySearch.Font.Bold = True
        'glossarySearch.Font.Size = "14px"
        If Not Page.IsPostBack Then
            headerContentFirst.Visible = True
            headerContentSearchResults.Visible = False
            EntryOfDay.Visible = True
            termResult.Visible = False
            If Not IsNothing(Request.QueryString("termid")) Then
                Dim sTermID As New Guid(Request.QueryString("termid"))
                showSingleResult(sTermID)
            End If
        End If
    End Sub
End Class
