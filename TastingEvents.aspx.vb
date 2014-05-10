Imports WebCommon
Imports AstorDataClass
Imports System.Data
'Imports SslTools

Partial Class TastingEvents
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If page is not being loaded in response to postback
        If Not Page.IsPostBack Then
            '            calEvents.SelectedDate = Date.Now

            LoadEventsDataList()
        End If


    End Sub
    Private Sub LoadEventsDataList()
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As DataSet
        Dim dtBegindate As Date = Now
        Dim dtEnddate As Date = dtBegindate.AddDays(14)

        Try
            dsLocal = _odata.GetEventsData(dtBegindate, dtEnddate)

            'If dsLocal.Tables(0).Rows.Count = 0 Then
            '    Response.Redirect("SearchError.aspx", True)
            'End If
            datEvents.DataSource = dsLocal.Tables(0)
            datEvents.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Protected Sub calEvents_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles calEvents.SelectionChanged
    '    LoadEventsDataList()
    'End Sub

    Protected Sub datEvents_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datEvents.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim featuresString As PlaceHolder = e.Item.FindControl("featuringItems")
            Dim eventDataItem As Data.DataRowView = e.Item.DataItem
            Dim eventDataRow As Data.DataRow = eventDataItem.Row
            Dim item() As String = {String.Empty, String.Empty, String.Empty, String.Empty}
            Dim showFeaturedItems As Boolean = False
            For i As Integer = 0 To 3
                item(i) = Trim(eventDataRow("sProductItem" & i + 1))
                If item(i) <> "" Then
                    showFeaturedItems = True
                    Dim _odata As New cAstorWebData(dsn)
                    Dim dsLocal As DataSet
                    dsLocal = _odata.GetPriceItemInfo(item(i))
                    If dsLocal.Tables(0).Rows.Count = 1 Then
                        'Redirect("SearchError.aspx", RedirectOptions.AbsoluteHttp)


                        Dim productLink As New HyperLink
                        productLink.Text = dsLocal.Tables(0).Rows(0).Item("name").ToString() & " - " & dsLocal.Tables(0).Rows(0).Item("vintage").ToString() & " " & dsLocal.Tables(0).Rows(0).Item("size").ToString()
                        productLink.NavigateUrl = "./SearchResultsSingle.aspx?p=0&search=" & item(i) & "&searchtype=Contains"
                        featuresString.Controls.Add(productLink)
                        Dim break1 As New Literal
                        break1.Text = "<br />"
                        featuresString.Controls.Add(break1)
                        Dim tags As New Literal
                        Dim tempText As String = String.Empty
                        If Trim(dsLocal.Tables(0).Rows(0).Item("sColor").ToString()) <> "" Then
                            tempText &= Trim(dsLocal.Tables(0).Rows(0).Item("sColor").ToString()) & ", "
                        End If
                        If Trim(dsLocal.Tables(0).Rows(0).Item("sCountry").ToString()) <> "" Then
                            tempText &= Trim(dsLocal.Tables(0).Rows(0).Item("sCountry").ToString()) & ", "
                        End If
                        If Trim(dsLocal.Tables(0).Rows(0).Item("sRegion").ToString()) <> "" Then
                            tempText &= Trim(dsLocal.Tables(0).Rows(0).Item("sRegion").ToString()) & ", "
                        End If
                        If Trim(dsLocal.Tables(0).Rows(0).Item("sSubRegion").ToString()) <> "" Then
                            tempText &= Trim(dsLocal.Tables(0).Rows(0).Item("sSubRegion").ToString()) & ", "
                        End If
                        If Trim(dsLocal.Tables(0).Rows(0).Item("sVineyard").ToString()) <> "" Then
                            tempText &= Trim(dsLocal.Tables(0).Rows(0).Item("sVineyard").ToString()) & ", "
                        End If
                        If tempText.Length > 1 Then
                            tags.Text = tempText.Remove(tempText.Length - 2)
                        Else
                            tags.Text = ""
                        End If

                        featuresString.Controls.Add(tags)
                        Dim break2 As New Literal
                        break2.Text = "<br />"
                        featuresString.Controls.Add(break2)
                        Dim itemNr As New Literal
                        itemNr.Text = "Item #: " & item(i)
                        featuresString.Controls.Add(itemNr)
                        Dim finalBreak As New Literal
                        finalBreak.Text = "<br /><br />"
                        featuresString.Controls.Add(finalBreak)
                    End If
                    End If
            Next
            Dim featuredItems As PlaceHolder = e.Item.FindControl("featuredItems")
            featuredItems.Visible = showFeaturedItems
        End If
    End Sub
End Class
