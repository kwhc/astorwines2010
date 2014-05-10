
Imports System.Data
Partial Class Ucontrols_WUCSearchResultsTop
    Inherits System.Web.UI.UserControl
    Private iResultCount As Int16
    Public Property ResultCount() As Int16
        Get
            Return iResultCount
        End Get
        Set(ByVal value As Int16)
            iResultCount = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _oAstorCommon As New cAstorCommon
        Dim hstQuery As New Hashtable

        'Dim sPageName As String = String.Empty

        'sPageName = Page.ToString
        ''mstrPageName &= Page.ClientQueryString.ToString

        'sPageName = Replace(sPageName, "ASP.", "")
        'sPageName = Replace(sPageName, "_aspx", "")
        'sPageName = sPageName.ToLower
        'Select Case sPageName
        '    Case "winesearchresult"
        '        imgBasePageHd.ImageUrl = "~/images/as_wines_hd.gif"
        '    Case "spiritssearchresult"
        '        imgBasePageHd.ImageUrl = "~/images/as_spirits_hd.gif"
        '    Case "sakesearchresult"
        '        imgBasePageHd.ImageUrl = "~/images/as_sakes_hd.gif"
        '    Case "booksaccessoriessearchresult"
        '        imgBasePageHd.ImageUrl = "~/images/as_ba_hd.gif"
        'End Select

        hstQuery = _oAstorCommon.ProcessQueryStrings(Request.QueryString)
        SetResulttext(hstQuery)

        If Not Session("DSMulti") Is Nothing Then
            Dim oDS As New DataSet
            oDS = Session("DSMulti")
            iResultCount = oDS.Tables(0).Rows.Count
        Else
            iResultCount = 0
        End If
        If iResultCount >= 100 Then
            lblResultTop.Text = "Your search yielded more than 100 results."
            lblResultBottom.Text = "<div id=""maxedOut""  class=""searchTip"">*Displaying first 100 results<a><img class=""inline-img"" src=""images/general/popUp.gif"" alt=""Pop Up"" /></a></div>"
        Else
            lblResultTop.Text = "Your search yielded the following results."
            lblResultBottom.Text = "<div id=""tailor""  class=""searchTip"">Don't see what you're looking for?<a><img class=""inline-img"" src=""images/general/popUp.gif"" alt=""Pop Up"" /></a></div>"

        End If
    End Sub
    Private Sub SetResulttext(ByVal hstQuery As Hashtable)
        Dim sbText As New StringBuilder
        With hstQuery
            sbText.Append("<ul class=""searchString inline"">")
            sbText.Append("<li>Results for:</li>")

            If .Item("NameLookup_value") <> "" Then
                sbText.Append("<li>")
                sbText.Append("<span class=""searchQuery"">" & RTrim(.Item("NameLookup_value")) & "</span>")
                sbText.Append("</li>")
            End If
            If .Item("Country") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("Country")))
                sbText.Append("</li>")
            End If
            If .Item("Region") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("Region")))
                sbText.Append("</li>")
            End If
            If .Item("SubRegion") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("SubRegion")))
                sbText.Append("</li>")
            End If
            If .Item("Color") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("Color")))
                sbText.Append("</li>")
            End If
            If .Item("Producer") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("Producer")))
                sbText.Append("</li>")
            End If
            If .Item("Grape") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("Grape")))
                sbText.Append("</li>")
            End If
            If .Item("VintageBegin") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("VintageBegin")))
                sbText.Append("</li>")
            End If
            If .Item("PriceRange").ToString <> 0 Then
                Dim sPriceRange As String = String.Empty
                sbText.Append("<li>")

                Select Case .Item("PriceRange").ToString
                    Case 1
                        sPriceRange = "Under $10"
                    Case 2
                        sPriceRange = "$10-$20"
                    Case 3
                        sPriceRange = "$21-$50"
                    Case 4
                        sPriceRange = "$51-$100"
                    Case 5
                        sPriceRange = "Above $100"
                End Select

                sbText.Append(sPriceRange)
                sbText.Append("</li>")
            End If
            If .Item("Size") <> "" Then

                sbText.Append("<li>")

                Select Case .Item("Size")
                    Case "187"
                        sbText.Append("187mL (Split Bottles)")
                    Case "250"
                        sbText.Append("250mL")
                    Case "375"
                        sbText.Append("375mL (Half Bottles)")
                    Case "500"
                        sbText.Append("500mL")
                    Case "750"
                        sbText.Append("750mL")
                    Case "LTR"
                        sbText.Append("1 L")
                    Case "1.5"
                        sbText.Append("1.5 L")
                    Case Else
                        sbText.Append(RTrim(.Item("Size")))
                End Select

                sbText.Append("</li>")

                If .Item("Size") = "" Then
                Else
                End If

            End If
            If .Item("Style") <> "" Then
                Dim _dvTypeCode As New DataView
                Dim _dtTypeCode As DataTable = Application("TypeCodes")
                _dvTypeCode.Table = _dtTypeCode
                _dvTypeCode.RowFilter = "sWebLUValue = '" & .Item("Style") & "'"
                If _dvTypeCode.Count > 0 Then
                    Dim sTypeDesc As String = _dvTypeCode.Item(0).Item("sWebTypeDescription").ToString
                    sbText.Append("<li>")
                    sbText.Append(sTypeDesc)
                    sbText.Append("</li>")
                End If
            End If
            If .Item("OrganicAll") = True Then
                sbText.Append("<li>")
                sbText.Append("&nbsp; &#187; &nbsp;<span class=""showingItems"">Organic </span>")
                sbText.Append("</li>")
            End If
            If .Item("Kosher") = True Then
                sbText.Append("<li>")
                sbText.Append("&nbsp; &#187; &nbsp;<span class=""showingItems"">Kosher</span> &nbsp; &#187; &nbsp;")
                sbText.Append("</li>")
            End If
            If .Item("SakeDiscriminatorSave") <> "" Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("SakeDiscriminatorSave")))
                sbText.Append("</li>")
            End If
            If .Item("PolishingGrade") <> 0 Then
                sbText.Append("<li>")
                sbText.Append(RTrim(.Item("PolishingGrade")))
                sbText.Append("</li>")
            End If
            If sbText.Length > 0 Then
                'sbText.Remove(sbText.Length - 1, 1)
            End If

        End With
        sbText.Append("</ul>")
        litResultMiddle.Text = sbText.ToString

    End Sub
End Class
