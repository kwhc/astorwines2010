
Partial Class Ucontrols_WUCCreditCardEdit
    Inherits System.Web.UI.UserControl
    Private _sCCType As String
    Private _sCCMM As String
    Private _sCCYYYY As String
    Private _sCVV As String
    Private _sCreditCard As String
    Private _sCCName As String
    Private _bDefault As Boolean
    Public Property CCTypeValue() As String
        Get
            Return ddlCCType.SelectedValue
        End Get
        Set(ByVal value As String)
            _sCCType = value
            ddlCCType.SelectedValue = _sCCType
        End Set
    End Property
    Public Property CCMMValue() As String
        Get
            Return ddlCCMM.SelectedValue
        End Get
        Set(ByVal value As String)
            _sCCMM = value
            ddlCCMM.SelectedValue = _sCCMM
        End Set
    End Property
    Public Property CCYYYYValue() As String
        Get
            Return ddlCCYYYY.SelectedValue
        End Get
        Set(ByVal value As String)
            _sCCYYYY = value
            ddlCCYYYY.SelectedValue = _sCCYYYY
        End Set
    End Property
    Public Property CVVValue() As String
        Get
            Return CVV.Text
        End Get
        Set(ByVal value As String)
            _sCVV = value
            CVV.Text = _sCVV
        End Set
    End Property
    Public Property CCNameValue() As String
        Get
            Return CCName.Text
        End Get
        Set(ByVal value As String)
            _sCCName = value
            CCName.Text = _sCCName
        End Set
    End Property
    Public Property CreditCardNumValue() As String
        Get
            Return txtCreditCard.Text
        End Get
        Set(ByVal value As String)
            _sCreditCard = value
            txtCreditCard.Text = _sCreditCard
        End Set
    End Property
    Public Property CreditCardDefault() As Boolean
        Get
            Return chkDefault.Checked
        End Get
        Set(ByVal value As Boolean)
            _bDefault = value
            If _bDefault = True Then
                chkDefault.Checked = True
            Else
                chkDefault.Checked = False
            End If

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadUcombo()
            ddlCCType.SelectedValue = _sCCType
            ddlCCMM.SelectedValue = _sCCMM
            ddlCCYYYY.SelectedValue = _sCCYYYY
            CVV.Text = _sCVV
            txtCreditCard.Text = _sCreditCard
            CCName.Text = _sCCName
            chkDefault.Checked = _bDefault
        End If
    End Sub
    Private Sub LoadUcombo()
        'load credit card
        With ddlCCType
            .DataSource = Application("CreditCardType")
            .DataMember = ""
            .DataValueField = "sCreditCardTypeCD"
            .DataTextField = "sCreditCardType"
            .DataBind()
        End With
        'load credit card
        With ddlCCMM
            .DataSource = Application("CCDateMM")
            .DataMember = ""
            .DataValueField = "sCCDateMM"
            .DataTextField = "sCCDesc"
            .DataBind()
        End With
        'load credit card
        With ddlCCYYYY
            .DataSource = Application("CCDateYYYY")
            .DataMember = ""
            .DataValueField = "sCCDateYYYY"
            .DataTextField = "sCCDateYYYY"
            .DataBind()
        End With
    End Sub
    Public Function bValidateCC(ByRef sMsg As String) As Boolean
        Dim bFail As Boolean = False
        Dim sCCDate As String
        Dim sDateNow As String
        Dim sDateNowMM As String

        ' check length of card #
        If (ddlCCType.SelectedValue = "A" And Len(RTrim(txtCreditCard.Text)) <> 15) Or _
        (ddlCCType.SelectedValue <> "A" And Len(RTrim(txtCreditCard.Text)) <> 16) Then
            bFail = True
            sMsg = sMsg & " - Invalid Credit Card Number"
        End If
        If ddlCCType.SelectedIndex = 0 Then
            bFail = True
        End If
        If RTrim(txtCreditCard.Text) = "" Then
            bFail = True
        End If
        If ddlCCYYYY.SelectedIndex = 0 Then
            bFail = True
        End If
        If ddlCCMM.SelectedIndex = 0 Then
            bFail = True
        End If
        If RTrim(CVV.Text) = "" Then
            bFail = True
        End If
        If RTrim(CCName.Text) = "" Then
            bFail = True
        End If

        If ddlCCYYYY.SelectedIndex <> 0 And ddlCCMM.SelectedIndex <> 0 Then
            sCCDate = ddlCCYYYY.SelectedValue & ddlCCMM.SelectedValue
            sDateNowMM = Date.Today.Month.ToString
            If Len(sDateNowMM) = 1 Then
                sDateNowMM = "0" & sDateNowMM
            End If
            sDateNow = Date.Today.Year.ToString & sDateNowMM
            If sCCDate < sDateNow Then
                bFail = True
                sMsg = sMsg & " - Invalid Credit Card Date"
            End If
        End If

        Return bFail
    End Function
    Protected Sub ddlCCType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCCType.SelectedIndexChanged
        Select Case ddlCCType.SelectedValue
            Case "A"
                lblCVVHelp.Text = "American Express: Enter the 4 digit, non-embossed number printed above your account number on the FACE of your card."
                'wmeCreditCard.InputMask = "####-####-####-###"
                txtCreditCard.MaxLength = 15
            Case "M"
                lblCVVHelp.Text = "Master Card: Enter the 3-digit, non-embossed number printed on the signature panel on the BACK of the card."
                'wmeCreditCard.InputMask = "####-####-####-####"
                txtCreditCard.MaxLength = 16
            Case "V"
                lblCVVHelp.Text = "Visa Card: Enter the 3-digit, non-embossed number printed on the signature panel on the BACK of the card following the account number."
                'wmeCreditCard.InputMask = "####-####-####-####"
                txtCreditCard.MaxLength = 16
            Case "D"
                lblCVVHelp.Text = "Discover Card: Enter the 3-digit, non-embossed number printed on the signature panel on the BACK of the card."
                'wmeCreditCard.InputMask = "####-####-####-####"
                txtCreditCard.MaxLength = 16
            Case Else
                lblCVVHelp.Text = ""
                'wmeCreditCard.InputMask = "####-####-####-####"
                txtCreditCard.MaxLength = 16
        End Select
    End Sub

End Class
