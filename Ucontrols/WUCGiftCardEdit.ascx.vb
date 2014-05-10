
Partial Class Ucontrols_WUCGiftCardEdit
    Inherits System.Web.UI.UserControl
    Private _sGiftCardNumber As String = String.Empty
    Private _sGiftCardPresentValue As String = "Not Retrieved"

    Public Property GiftCardNumber() As String
        Get
            Return txtGiftCardNumber.Text
        End Get
        Set(ByVal value As String)
            _sGiftCardNumber = value
            txtGiftCardNumber.Text = _sGiftCardNumber
        End Set
    End Property
    Public Property GiftCardPresentValue() As String
        Get
            Return lblGiftCardBalance.Text
        End Get
        Set(ByVal value As String)
            _sGiftCardPresentValue = value
            lblGiftCardBalance.Text = _sGiftCardPresentValue
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            txtGiftCardNumber.Text = _sGiftCardNumber
            lblGiftCardBalance.Text = _sGiftCardPresentValue

        End If
    End Sub


   

    Private Sub btnGetBalance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetBalance.Click
        ' ''If txtGiftCardNumber.Text.Length = 16 Then
        ''Dim _oAstorCommon As New cAstorCommon
        ''lblGiftCardBalance.Text = GetGiftCardBalance(txtGiftCardNumber.Text)

        ''If lblGiftCardBalance.Text <> "Invalid Card Number" Then
        ''    Label1.Text = "as of " & Date.Now.ToString
        ''Else
        ''    Label1.Text = ""
        ''End If

        Dim GiftCardNumber As String = txtGiftCardNumber.Text
        Dim Balance As String = String.Empty


        If Len(GiftCardNumber) = 16 Or Len(GiftCardNumber) = 19 Then

            Balance = GetGiftCardBalance(GiftCardNumber)
            lblGiftCardBalance.Text = Balance

            If IsNumeric(Balance) Then

                Label1.Text = "as of " & Date.Now.ToString

            Else

                Label1.Text = ""

            End If
        Else
            lblGiftCardBalance.Text = "INVALID CARD"
            Label1.Text = ""
        End If

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
