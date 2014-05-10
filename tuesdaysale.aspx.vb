Imports WebCommon
Imports AstorDataClass
Imports System.Data

Partial Class AstorTuesdays
    Inherits WebPageBase

    Private dsn As String = WebAppConfig.ConnectString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("SearchParms") = Nothing
        If Not IsPostBack Then
            Try
                If Date.Now.DayOfWeek = DayOfWeek.Tuesday Then
                    lblResultBottom.Text = "<i>Every Tuesday, our buyers pick a region or type of wine, spirit, or saké and mark it down 15%. Check out these sales:</i>"
                    tuesday.Visible = True
                    notTuesday.Visible = False

                    Dim sRow As String
                    Dim iRow As Int16 = 0
                    If Not IsNothing(Request.QueryString("r")) Then

                        sRow = Request.QueryString("r")
                        If IsNumeric(sRow) Then
                            iRow = CInt(sRow)
                        End If
                    End If

                    Dim _dslocalDetail As DataSet
                    If Date.Now.DayOfWeek = DayOfWeek.Tuesday Then
                        _dslocalDetail = Get15TuesdayData(iRow)
                    Else
                        _dslocalDetail = Get15TuesdayData(0)
                    End If

                    Session("DSMulti") = _dslocalDetail
                    Session("queryType") = Nothing
                    Session("queryValue") = Nothing


                Else
                    lblResultBottom.Text = "<i>Every Tuesday, our buyers pick a region or type of wine, spirit, or saké and mark it down 15%.  <b>Check back this Tuesday for the sale items, but in the meantime check out some of our other items on sale.</b></i>"
                    tuesday.Visible = False
                    notTuesday.Visible = True

                    'TUESDAY SALE DISPLAY TEST
                    Dim nextTuesday As Date
                    Dim today As Date = Now.Date

                    Select Case today.DayOfWeek
                        Case 1
                            nextTuesday = today.AddDays(1.0)
                        Case 2
                            nextTuesday = today
                        Case 3
                            nextTuesday = today.AddDays(6.0)
                        Case 4
                            nextTuesday = today.AddDays(5.0)
                        Case 5
                            nextTuesday = today.AddDays(4.0)
                        Case 6
                            nextTuesday = today.AddDays(3.0)
                        Case 7
                            nextTuesday = today.AddDays(2.0)
                    End Select


                    Dim tuesdayEventsSQLAdapter As New astorWinesTableAdapters.tblWebSpecialFeaturesTableAdapter
                    Dim tuesdayEventsDataTable As astorWines.tblWebSpecialFeaturesDataTable
                    Dim tuesdayEventRow As astorWines.tblWebSpecialFeaturesRow

                    '**************first sale
                    tuesdayEventsDataTable = tuesdayEventsSQLAdapter.GetTuesdayEventsByDate(nextTuesday)
                    tuesdayEventRow = tuesdayEventsDataTable.Rows(0)

                    sale1.Text = "<span class=""date"">" & tuesdayEventRow.dtStartDate.ToString("MMMM dd") & "</span>" & " <br /> <span class=""region"">" & tuesdayEventRow.sFeatureDesc & "</span>"

                    '***********second sale
                    tuesdayEventsDataTable = tuesdayEventsSQLAdapter.GetTuesdayEventsByDate(DateAdd(DateInterval.Day, 7, nextTuesday))
                    tuesdayEventRow = tuesdayEventsDataTable.Rows(0)

                    sale2.Text = "<span class=""date"">" & tuesdayEventRow.dtStartDate.ToString("MMMM dd") & "</span>" & " <br /> <span class=""region"">" & tuesdayEventRow.sFeatureDesc & "</span>"

                    '***********third sale
                    tuesdayEventsDataTable = tuesdayEventsSQLAdapter.GetTuesdayEventsByDate(DateAdd(DateInterval.Day, 14, nextTuesday))
                    tuesdayEventRow = tuesdayEventsDataTable.Rows(0)

                    sale3.Text = "<span class=""date"">" & tuesdayEventRow.dtStartDate.ToString("MMMM dd") & "</span>" & " <br /> <span class=""region"">" & tuesdayEventRow.sFeatureDesc & "</span>"

                End If

            Catch ex As Exception

                Throw ex

            End Try

        End If
    End Sub
    
    Private Function Get15TuesdayData(ByVal iRow As Int16) As DataSet

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)
        Dim dsLocal As New DataSet

        Try

            dsLocal = _odata.Get15TuesdaysData(iRow)


        Catch ex As Exception
            Throw ex
        End Try

        Return dsLocal

    End Function

End Class
