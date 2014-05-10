Imports WebCommon
Imports DownLoadFile
Imports System.IO
Imports AstorDataClass
Imports System.Data
Partial Class maint_ExportEmails
    Inherits WebPageBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SetStartDate("AWS")
        End If

    End Sub

    Private Sub MakeEmailFile()
        'Dim wbp As New WebPageBase
        Dim users As New AstorwinesCommerce.UsersDB(getConnStr())
        Dim _dsLocal As New DataSet
        Dim drRow As DataRow
        'Dim sr As New StreamWriter("files/emails.txt")
        Dim _WebUtils As New WebUtils
        '
        Dim strMessage As String = ""
        Dim t As Type = Me.GetType
        Dim type As String = ddlType.SelectedValue

        Dim stringFilePath As String = Server.MapPath("files") & "\" & type & "_" & "emails.txt"
        'Dim virFilePath As String = "files/emails.txt"
        'Dim objWriter As StreamWriter = New StreamWriter(stringFilePath, False)
        Dim objWriter As StreamWriter = New StreamWriter(File.Open(stringFilePath, FileMode.Create))
        Try
            _dsLocal = users.GetEmailList(wdcStartDate.Value, wdcEndDate.Value, ddlType.SelectedValue)
            Dim iRowCount As Int32 = _dsLocal.Tables(0).Rows.Count
            If iRowCount > 0 Then

                For Each drRow In _dsLocal.Tables(0).Rows
                    With drRow
                        objWriter.WriteLine(drRow.Item(0))
                    End With
                Next drRow
                'sr.Write(Chr(12))

            End If
            objWriter.Close()
            ''''DownLoad.DFile(virFilePath)
            If iRowCount > 0 Then
                DownloadFile(stringFilePath, True)
                'OpenWindow()

            End If
            File.Delete(stringFilePath)
            strMessage = "Exported " & iRowCount.ToString & " email addresses"

        Catch ex As Exception
            Throw ex
            strMessage = "Problem with export"
        Finally
            lblExportMessage.Text = strMessage
            lblExportMessage.Visible = True

            _WebUtils.CreateMessageAlert(Me, t, strMessage, "strKey2")

        End Try

    End Sub
    Private Sub SetStartDate(ByVal Type As String)
        Dim dtStartDate As Date
        Dim users As New AstorwinesCommerce.UsersDB(getConnStr())
        dtStartDate = users.GetLastEmailExportDate(Type)
        wdcStartDate.Value = dtStartDate
    End Sub
    Private Sub DownloadFile(ByVal fname As String, ByVal forceDownload As Boolean)

        'Dim path As Path
        Dim fullpath = Path.GetFullPath(fname)
        Dim name = Path.GetFileName(fullpath)
        Dim ext = Path.GetExtension(fullpath)
        Dim type As String = ""

        Try
            If Not IsDBNull(ext) Then
                ext = LCase(ext)
            End If

            Select Case ext
                Case ".htm", ".html"
                    type = "text/HTML"
                Case ".txt"
                    type = "text/plain"
                Case ".doc", ".rtf"
                    type = "Application/msword"
                Case ".csv", ".xls"
                    type = "Application/x-msexcel"
                Case Else
                    type = "text/plain"
            End Select

            Response.ClearContent()
            Response.ClearHeaders()

            If (forceDownload) Then
                Response.AppendHeader("content-disposition", "attachment; filename=" + name)
            Else
                Response.AddHeader("content-disposition", "attachment; filename=" + name)
            End If
            If type <> "" Then
                Response.ContentType = type
            End If

            Response.WriteFile(fullpath)
            'Response.End()
            Response.Flush()

            Response.Close()

        Catch ex As Exception
            Throw ex

        Finally

        End Try
    End Sub
    Private Sub cmdExportFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportFile.Click

        MakeEmailFile()



    End Sub

    Protected Sub ddlType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        SetStartDate(ddlType.SelectedValue)
    End Sub
End Class
