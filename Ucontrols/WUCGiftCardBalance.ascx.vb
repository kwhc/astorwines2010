
Partial Class Ucontrols_WUCGiftCardBalance
    Inherits System.Web.UI.UserControl
    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        ''Dim _oAstorCommon As New cAstorCommon
        ''lblResponse.Text = _oAstorCommon.GiftCardBalance(txtCardNumber.Text)


        ''If lblResponse.Text <> "Invalid Card Number" Then
        ''    lblResponse.Text = lblResponse.Text & " as of " & Date.Now.ToString
        ''End If

        Dim GiftCardNumber As String = txtCardNumber.Text
        Dim Balance As String = String.Empty

        'Session("GiftCardNumber") = Nothing
        'Session("GiftCardAmount") = Nothing

        If Len(GiftCardNumber) = 16 Or Len(GiftCardNumber) = 19 Then

            Balance = GetGiftCardBalance(GiftCardNumber)

            If IsNumeric(Balance) Then

                lblResponse.Text = Balance.ToString & " as of " & Date.Now.ToString
                'lblGiftCardNumber.Text = GiftCardNumber.ToString
                'lblGiftCardNumber.Visible = True
                'txtGiftCardNumber.Visible = False
                'cmdGetBalance.Enabled = False
                'cmdApplyBalance.Enabled = True
                'Session("GiftCardNumber") = GiftCardNumber.ToString
                'Session("GiftCardAmount") = Balance
            Else

                lblResponse.Text = Balance
                'lblGiftCardNumber.Visible = False
                'txtGiftCardNumber.Visible = True
                'cmdGetBalance.Enabled = True
                'cmdApplyBalance.Enabled = False

            End If
        Else
            'lblGiftCardNumber.Visible = False
            'txtGiftCardNumber.Visible = True
            'cmdGetBalance.Enabled = True
            'cmdApplyBalance.Enabled = False
            lblResponse.Text = "INVALID CARD"
        End If

        'lblGiftCardError.Visible = False


    End Sub
    Private Function GetGiftCardBalance(ByVal CardNumber As String) As String


        Dim CKey As String = Application("CLIENT_KEY")
        Dim TID As String = Application("TERMINAL_ID")
        Dim MID As String = Application("MERCHANT_ID")
        Dim LID As String = Application("LOCATION_ID")
        Dim _oAstorCommon As New cAstorCommon

        Dim sBalance As String = String.Empty

        sBalance = _oAstorCommon.GetGiftCardBalance(CardNumber, CKey, TID, MID, LID)

        Return sBalance


    End Function
End Class
