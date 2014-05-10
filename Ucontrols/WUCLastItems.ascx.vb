Imports WebCommon
Imports AstorDataClass

Partial Class Ucontrols_WUCLastItems
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim prvItem1 As String = Session("prvItem1")
        Dim prvItem2 As String = Session("prvItem2")
        Dim prvItem3 As String = Session("prvItem3")

        If prvItem1 = Nothing Then
            prvItem1 = ""
        Else
            prvItem1 = Session.Item("prvItem1").ToString
        End If
        If prvItem2 = Nothing Then
            prvItem2 = ""
        Else
            prvItem2 = Session.Item("prvItem2").ToString
        End If
        If prvItem3 = Nothing Then
            prvItem3 = ""
        Else
            prvItem3 = Session.Item("prvItem3").ToString
        End If

        If prvItem1 = "" Then
            Dim noItemsViewed As New Literal
            noItemsViewed.Text = "<div class=""muted"" style=""text-align: center;"">Start Browsing!</div>"
            plclastItems.Controls.Add(noItemsViewed)
        Else
            Dim otherInfo As System.Data.DataRow
            If prvItem1 <> "" Then
                Dim item1LinkOpen As New Literal
                item1LinkOpen.Text = "<a " & "href=""../SearchResultsSingle.aspx?p=0&search=" & prvItem1 & "&searchtype=Contains&ref=lv""" & " class=""block-link""><div style=""padding:.6rem .5rem;"">"
                plcLastItems.Controls.Add(item1LinkOpen)

                Dim item1Name As New Literal
                otherInfo = getOtherInfo(prvItem1)
                item1Name.Text = otherInfo.Item("name")
                If RTrim(otherInfo.Item("vintage")) <> "" Then
                    item1Name.Text = item1Name.Text & " (" & otherInfo.Item("vintage") & ")"
                End If
                plcLastItems.Controls.Add(item1Name)

                Dim item1LinkClose As New Literal
                item1LinkClose.Text = "</div></a>"
                plcLastItems.Controls.Add(item1LinkClose)

                Dim break1 As New Literal
                If prvItem2 <> "" Then
                    break1.Text = ""
                Else
                    break1.Text = ""
                End If
                plcLastItems.Controls.Add(break1)
            End If

            If prvItem2 <> "" Then
                Dim item2LinkOpen As New Literal
                item2LinkOpen.Text = "<a " & "href=""../SearchResultsSingle.aspx?p=0&search=" & prvItem2 & "&searchtype=Contains&ref=lv""" & "class=""block-link""><div style=""padding:.6rem .5rem;"">"

                Dim item2Name As New Literal
                otherInfo = getOtherInfo(prvItem2)
                item2Name.Text = otherInfo.Item("name")
                If RTrim(otherInfo.Item("vintage")) <> "" Then
                    item2Name.Text = item2Name.Text & " (" & otherInfo.Item("vintage") & ")"
                End If

                Dim item2LinkClose As New Literal
                item2LinkClose.Text = "</div></a>"

                Dim break2 As New Literal
                If prvItem3 <> "" Then
                    break2.Text = ""
                Else
                    break2.Text = ""
                End If
                If prvItem2 <> "" Then
                    plcLastItems.Controls.Add(item2LinkOpen)
                    plcLastItems.Controls.Add(item2Name)
                    plcLastItems.Controls.Add(item2LinkClose)
                    plcLastItems.Controls.Add(break2)
                End If
            End If

            If prvItem3 <> "" Then
                Dim item3LinkOpen As New Literal
                item3LinkOpen.Text = "<a " & "href=""../SearchResultsSingle.aspx?p=0&search=" & prvItem3 & "&searchtype=Contains&ref=lv""" & "class=""block-link""><div style=""padding:.6rem .5rem;"">"

                Dim item3Name As New Literal
                otherInfo = getOtherInfo(prvItem3)
                item3Name.Text = otherInfo.Item("name")
                If RTrim(otherInfo.Item("vintage")) <> "" Then
                    item3Name.Text = item3Name.Text & " (" & otherInfo.Item("vintage") & ")"
                End If

                Dim item3LinkClose As New Literal
                item3LinkClose.Text = "</div></a>"

                Dim break3 As New Literal
                break3.Text = ""

                If prvItem3 <> "" Then
                    plcLastItems.Controls.Add(item3LinkOpen)
                    plcLastItems.Controls.Add(item3Name)
                    plcLastItems.Controls.Add(item3LinkClose)
                    plcLastItems.Controls.Add(break3)
                End If
            End If
        End If
    End Sub

    Private Function getOtherInfo(ByVal sItem As String) As System.Data.DataRow
        Dim dsn As String = WebAppConfig.ConnectString
        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As System.Data.DataSet
        Dim dtBegindate As Date = Now.AddYears(-1)
        Dim dtEnddate As Date = dtBegindate.AddDays(16)

        Try
            dsLocal = _odata.GetPriceItemInfo(sItem)

            If dsLocal.Tables(0).Rows.Count = 0 Then
                Response.Redirect("SearchError.aspx", True)
            End If
            Return dsLocal.Tables(0).Rows(0)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
