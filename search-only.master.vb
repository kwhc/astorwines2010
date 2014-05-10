Imports WebCommon
Imports AstorDataClass
Imports System.Data

Partial Class as_master_1
    Inherits System.Web.UI.MasterPage
    Private dsOrder As New DataSet
    Private _sInum As String
    Private _oWebCommon As New WebPageBase
    Private Orders As New AstorwinesCommerce.OrdersDB(_oWebCommon.getConnStr())

    Protected Overrides Function OnBubbleEvent(ByVal source As Object, ByVal args As System.EventArgs) As Boolean
        lblErrorMsg.Text = Session.Item("Error")
        lblErrorMsg.Visible = True
        Session.Item("Error") = Nothing
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _webConfig As New WebPageBase
        If Not Page.IsPostBack Then
            Try
                SnoothJS()
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End If

    End Sub
    Protected Sub SnoothJS()
        Dim sPageName As String = String.Empty
        'Dim iPageNum As Int16
        Dim sb As StringBuilder = New StringBuilder()
        Dim sb2 As StringBuilder = New StringBuilder()
        sPageName = Page.ToString
        'mstrPageName &= Page.ClientQueryString.ToString

        sPageName = Replace(sPageName, "ASP.", "")
        sPageName = Replace(sPageName, "_aspx", "")
        sPageName = sPageName.ToLower
        If sPageName <> "secure_astorcheckoutconfirmation" Then


            sb.Append("<script type=""text/javascript"" language=""javascript"">")

            sb.Append("__sn_m = 30;")
            sb.Append("__sn_o = '';")
            sb.Append("__sn_s = 0.00;")
            sb.Append("__sn_d = '';")
            sb.Append("__sn_a = 0, __sn_r = 0;")
            sb.Append("if(document.location.toString().indexOf('__sn_ref=1') >= 0) { __sn_a = 1; }")
            sb.Append("if(document.cookie.toString().indexOf('__sn_stc=1') >= 0) { __sn_r = 1; }")
            sb.Append("if(__sn_a || __sn_o) { document.write(unescape(""%3Cscript src='"" + document.location.protocol + ""//media1.snooth.com/js-compressed/t.js' type='text/javascript'%3E%3C/script%3E"")); }")
            sb.Append("</script>")

            sb2.Append("<script type=""text/javascript"" language=""javascript"">")
            sb2.Append("if(__sn_a) { __sn_ssc(); __sn_r = 1; }")
            sb2.Append("if(__sn_r && __sn_o) { __sn_stc(); }")
            sb2.Append("</script>")
        Else
            Try

                Dim dOrderTotal As Decimal = 0.0
                Dim sSnoothOrderDetail As String = String.Empty

                If Not IsNothing(Request.QueryString("inum")) Then
                    _sInum = Request.QueryString("inum")
                End If
                dsOrder = Orders.GetOrderForCustomerFormatted(_oWebCommon.GetCustomerID(Request, Response), _sInum)

                If dsOrder.Tables.Count > 0 Then
                    dOrderTotal = Convert.ToDecimal(dsOrder.Tables(0).Rows(0).Item("TotalValue"))
                    If dsOrder.Tables(1).Rows.Count > 0 Then

                        sSnoothOrderDetail = MakeSnoothOrderString(dsOrder.Tables(1))

                    Else
                        'Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                        Response.Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                    End If
                Else
                    'Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery, RedirectOptions.AbsoluteHttp)https_transfer_6/18/08
                    Response.Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                End If


                sb.Append("<script type=""text/javascript"" language=""javascript"">")

                sb.Append("__sn_m = 30;")
                sb.Append("__sn_o = '" & _sInum & "';")
                sb.Append("__sn_s = " & dOrderTotal.ToString & ";")
                sb.Append("__sn_d = " & sSnoothOrderDetail & ";")
                sb.Append("__sn_a = 0, __sn_r = 0;")
                sb.Append("if(document.location.toString().indexOf('__sn_ref=1') >= 0) { __sn_a = 1; }")
                sb.Append("if(document.cookie.toString().indexOf('__sn_stc=1') >= 0) { __sn_r = 1; }")
                sb.Append("if(__sn_a || __sn_o) { document.write(unescape(""%3Cscript src='"" + document.location.protocol + ""//media1.snooth.com/js-compressed/t.js' type='text/javascript'%3E%3C/script%3E"")); }")
                sb.Append("</script>")

                sb2.Append("<script type=""text/javascript"" language=""javascript"">")
                sb2.Append("if(__sn_a) { __sn_ssc(); __sn_r = 1; }")
                sb2.Append("if(__sn_r && __sn_o) { __sn_stc(); }")
                sb2.Append("</script>")

            Catch ex As Exception
                Throw ex
            End Try
        End If

        Dim js As String = sb.ToString
        Dim js2 As String = sb2.ToString
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "JScript", js)
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "JScript2", js2)

    End Sub
    Private Function MakeSnoothOrderString(ByVal dtLocal As DataTable) As String
        Dim drRow As DataRow
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append("'")
        '"item sku:item price:item qty;" 
        For Each drRow In dtLocal.Rows
            sb.Append(drRow.Item("item").ToString & ":" & Convert.ToDecimal(drRow.Item("unitprice")).ToString & ":" & drRow.Item("quantity").ToString & ";")
        Next
        sb.Append("'")

        MakeSnoothOrderString = sb.ToString

    End Function
End Class