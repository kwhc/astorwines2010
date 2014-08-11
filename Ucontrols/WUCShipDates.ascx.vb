Imports System.Data
Imports AstorDataClass
Imports WebCommon
Partial Class Ucontrols_WUCShipDates
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'setTitle()
        If Not Page.IsPostBack Then
            PopulateShippingDates()
            ShowDeliveryBoxes()
            HolidayShippingAlert()
        End If
    End Sub
    Sub PopulateShippingDates()
        Dim _oWebCommon As New WebPageBase
        Dim _odata As New cAstorWebData(_oWebCommon.getConnStr())
        Dim ds As DataSet = _odata.GetAllShipDates


        ' Walk through table and set labels accordingly
        Dim dt As DataTable = ds.Tables(0)
        Dim iIndex As Integer
        Dim sVartype As String
        Dim sDate As String

        For iIndex = 0 To dt.Rows.Count - 1
            sVartype = dt.Rows(iIndex).Item("VarType")
            sDate = dt.Rows(iIndex).Item("VarValue")
            sDate = FormatDateTime(sDate, DateFormat.LongDate)

            Select Case sVartype
                Case "sNextShipDateShip"
                    litUPS.Text = sDate
                    litFedEx.Text = sDate
                Case "sNextShipDateLower"
                    lblManLower.Text = sDate
                Case "sNextShipDateUpper"
                    lblManUpper.Text = sDate
                Case "sNextShipDateBrooklyn"
                    lblBrooklyn.Text = sDate
                Case "sNextShipDateQueens"
                    lblQueens.Text = sDate
            End Select

        Next
        
    End Sub

    Sub HolidayShippingAlert()

        If Date.Now > "12/25/2012" Then
            pnlHolidayAlert.Visible = False
        End If

    End Sub

    Sub ShowDeliveryBoxes()

        phAstorTrucks.Visible = False

    End Sub

    Sub setTitle()
        If phThirdPartyTransfer.Visible = True Then
            litTitle.Text = "Our Next Shipping Dates"
        Else
            litTitle.Text = "Our Next Transfer Dates"
        End If
    End Sub

End Class
