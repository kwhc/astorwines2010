Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports SslTools
Partial Class Ucontrols_WUCGiftSearch
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            LoadUcombo()
            If Not Session("SearchParms") Is Nothing Then
                Dim hstQuery As New Hashtable
                hstQuery = Session("SearchParms")
                With hstQuery

                    If .Item("PriceRange") <> 0 Then
                        ddlPriceRange.SelectedValue = RTrim(.Item("PriceRange"))
                    End If
                    If .Item("Type") <> "" Then
                        ddlType.SelectedValue = RTrim(.Item("Type"))
                    End If

                End With
            End If

        End If
    End Sub
    Private Sub LoadUcombo()

        Dim _dvPriceRange As New DataView
        Dim _dtPriceRange As DataTable = Application("PriceRange")
        _dvPriceRange.Table = _dtPriceRange
        _dvPriceRange.RowFilter = "sType = 'gift'"

        'load price range
        With ddlPriceRange
            .DataSource = _dvPriceRange
            .DataMember = ""
            .DataValueField = "iOrder"
            .DataTextField = "sPriceRangeDesc"
            .DataBind()
        End With
        
        'load type
        With ddlType
            .DataSource = Application("GiftType")
            .DataMember = ""
            .DataValueField = "iType"
            .DataTextField = "sTypeDescription"
            .DataBind()
        End With


    End Sub
    Private Sub Reset()

        ddlPriceRange.SelectedIndex = -1
        ddlType.SelectedIndex = -1
      
    End Sub
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbutReset.Click
        'LoadUcombo()
        'Reset()
        Session("SearchParms") = Nothing
        Dim sPage As String = Page.Request.Url.ToString
        Redirect(sPage)
    End Sub
End Class
