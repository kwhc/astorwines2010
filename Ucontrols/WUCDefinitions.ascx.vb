Imports WebCommon
Imports AstorDataClass
Imports System.Data
Partial Class Ucontrols_WUCDefinitions
    Inherits System.Web.UI.UserControl
    Private _sCountry As String = String.Empty
    Private _sRegion As String = String.Empty
    Private _sSubRegion As String = String.Empty
    Private _sVineyard As String = String.Empty
    Private _sDiscriminator As String = String.Empty
    Private _sGrapeVariety As String = String.Empty
    Private _sMiscTerms As String = String.Empty

    Public Property Country() As String
        Get
            Return _sCountry
        End Get
        Set(ByVal value As String)
            _sCountry = value
        End Set
    End Property
    Public Property Region() As String
        Get
            Return _sRegion
        End Get
        Set(ByVal value As String)
            _sRegion = value
        End Set
    End Property
    Public Property SubRegion() As String
        Get
            Return _sSubRegion
        End Get
        Set(ByVal value As String)
            _sSubRegion = value
        End Set
    End Property
    Public Property Vineyard() As String
        Get
            Return _sVineyard
        End Get
        Set(ByVal value As String)
            _sVineyard = value
        End Set
    End Property
    Public Property Discriminator() As String
        Get
            Return _sDiscriminator
        End Get
        Set(ByVal value As String)
            _sDiscriminator = value
        End Set
    End Property
    Public Property GrapeVariety() As String
        Get
            Return _sGrapeVariety
        End Get
        Set(ByVal value As String)
            _sGrapeVariety = value
        End Set
    End Property
    Public Property MiscTerms() As String
        Get
            Return _sMiscTerms
        End Get
        Set(ByVal value As String)
            _sMiscTerms = value
        End Set
    End Property

    Public ReadOnly Property showMe() As Boolean
        Get
            Return Me.Visible
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then

        '    BindResultDataList()

        'End If
    End Sub


    Public Sub BindResultDataList()
        Try
            Dim dsn As String = WebAppConfig.ConnectString
            Dim _oAstorCommon As New cAstorCommon
            Dim _odata As New cAstorWebData(dsn)
            Dim _dsLocal As DataSet

            _dsLocal = _odata.GetDefinitions(_sCountry, _sRegion, _sSubRegion, _sVineyard, _sDiscriminator, _sGrapeVariety, _sMiscTerms)
            If _dsLocal.Tables.Count = 0 Then
                Me.Visible = False
                Exit Sub
            End If
            If _dsLocal.Tables(0).Rows.Count = 0 Then
                Me.Visible = False
                Exit Sub
            End If
            datDefinitions.DataSource = _dsLocal.Tables(0)
            datDefinitions.DataBind()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub datDefinitions_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datDefinitions.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow
            Dim cutOffInteger As Int16 = 400
            myRowView = e.Item.DataItem
            myRow = myRowView.Row

            If Len(myRow("sTermDescription").ToString) > cutOffInteger Then 'myRow("sTermDescription")
                CType(e.Item.FindControl("lblDescription"), Literal).Text = Utility.cutOff(myRow("sTermDescription").ToString, cutOffInteger)

                e.Item.FindControl("entryLink").Visible = True
                CType(e.Item.FindControl("entryLink"), HyperLink).NavigateUrl = "~/astorGlossary.aspx" & "?termid=" & myRow("irowid").ToString

            Else
                CType(e.Item.FindControl("lblDescription"), Literal).Text = myRow("sTermDescription").ToString
                e.Item.FindControl("entryLink").Visible = False
            End If
        End If


        '                givenColumn.Controls.Add(description)
        '                endSpanDescription.Text = "</span>"
        '                givenColumn.Controls.Add(endSpanDescription)
        '                startSpanReadMore.Text = "<span class=""listingReadMore"">"
        '                givenColumn.Controls.Add(startSpanReadMore)
        '                readMoreLink.NavigateUrl = packageLink
        '                readMoreLink.Text = "read more"
        '                givenColumn.Controls.Add(readMoreLink)
        '                endSpanReadMore.Text = "</span>"
        '                givenColumn.Controls.Add(endSpanReadMore)
        '                endDivTag.Text = "</div>"
        '                givenColumn.Controls.Add(endDivTag)

    End Sub
End Class
