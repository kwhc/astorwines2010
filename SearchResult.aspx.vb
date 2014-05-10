Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO

Partial Class SearchResult
    Inherits WebPageBase
    Private intTxt As Integer
    Private sOrderType As String
    Private sItem As String
    Private dns As String = WebAppConfig.ConnectString
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
        'TextBox1.Text = CStr(Session.Item("queryValue"))

        If Not IsPostBack Then
            'If Not Session("queryValue") Is Nothing Then
            '    Select Case Session("queryType")

            '        Case "advanced"
            '            'LoadResultAdvancedDataList()
            '        Case "Direct"
            '            'LoadResultDirectDataList()
            '        Case Else
            '            LoadResultSimpleDataList()
            '    End Select

            'End If
            If Not IsNothing(Request.QueryString("p")) Then
                Dim sSearchControls As String = Request.QueryString("p")

                '   WUCWineSearch1.Visible = False
                '  WUCSakeSearch1.Visible = False
                ' WUCSpiritsSearch1.Visible = False
                'WUCBooksAssocSearch1.Visible = False

                If InStr(sSearchControls, "1") > 0 Then
                    '   WUCWineSearch1.Visible = True
                End If
                If InStr(sSearchControls, "2") > 0 Then
                    '  WUCSpiritsSearch1.Visible = True
                End If
                If InStr(sSearchControls, "3") > 0 Then
                    ' WUCSakeSearch1.Visible = True
                End If
                If InStr(sSearchControls, "4") > 0 Then
                    'WUCBooksAssocSearch1.Visible = True
                End If

                'Select Case Request.QueryString("p")
                '    Case 0

                '    Case 1
                '        Me.WUCWineSearch1.Visible = True
                '        Me.WUCSakeSearch1.Visible = False
                '        Me.WUCSpiritsSearch1.Visible = False
                '        Me.WUCBooksAssocSearch1.Visible = False
                '    Case 2
                '        Me.WUCWineSearch1.Visible = False
                '        Me.WUCSakeSearch1.Visible = False
                '        Me.WUCSpiritsSearch1.Visible = True
                '        Me.WUCBooksAssocSearch1.Visible = False
                '    Case 3
                '        Me.WUCWineSearch1.Visible = False
                '        Me.WUCSakeSearch1.Visible = True
                '        Me.WUCSpiritsSearch1.Visible = False
                '        Me.WUCBooksAssocSearch1.Visible = False
                '    Case 4
                '        Me.WUCWineSearch1.Visible = False
                '        Me.WUCSakeSearch1.Visible = False
                '        Me.WUCSpiritsSearch1.Visible = False
                '        Me.WUCBooksAssocSearch1.Visible = True
                'End Select
            End If

            Dim strUrl As String = Request.Url.ToString()
            Session("ReturnUrl") = strUrl

            'BindResultDataList()
        End If
    End Sub
    

  
End Class
