
Partial Class Ucontrols_WUCCreditCardNoCVV
    Inherits System.Web.UI.UserControl
    Private _sCCType As String
    Private _sCCMM As String
    Private _sCCYYYY As String
    Private _sCVV As String
    Private _sCreditCard As String
    Private _sCCName As String
    Private _iCCRowID As Int32
    Private _sCCRowIDU As String
    Private _bDefault As Boolean
    Public Property CCRowIDValue() As Int32
        Get
            Return Convert.ToInt32(lblCCRowID.Text)
        End Get
        Set(ByVal value As Int32)
            _iCCRowID = value
            lblCCRowID.Text = _iCCRowID.ToString
        End Set
    End Property
    Public Property CCRowIDUValue() As String
        Get
            Return lblccRowIDU.Text
        End Get
        Set(ByVal value As String)
            _sCCRowIDU = value
            lblccRowIDU.Text = _sCCRowIDU
        End Set
    End Property
    Public Property CCTypeValue() As String
        Get
            Return lblCCType.Text
        End Get
        Set(ByVal value As String)
            _sCCType = value
            lblCCType.Text = _sCCType
        End Set
    End Property
    Public Property CCMMValue() As String
        Get
            Return lblCCExpDateMM.Text
        End Get
        Set(ByVal value As String)
            _sCCMM = value
            lblCCExpDateMM.Text = _sCCMM
        End Set
    End Property
    Public Property CCYYYYValue() As String
        Get
            Return lblCCExpDateYYYY.Text
        End Get
        Set(ByVal value As String)
            _sCCYYYY = value
            lblCCExpDateYYYY.Text = _sCCYYYY
        End Set
    End Property
   
    Public Property CCNameValue() As String
        Get
            Return lblCCName.Text
        End Get
        Set(ByVal value As String)
            _sCCName = value
            lblCCName.Text = _sCCName
        End Set
    End Property
    Public Property CreditCardNumValue() As String
        Get
            Return lblCreditCard.Text
        End Get
        Set(ByVal value As String)
            _sCreditCard = value
            lblCreditCard.Text = _sCreditCard
        End Set
    End Property
    Public Property CreditCardDefault() As Boolean
        Get
            Return _bDefault
        End Get
        Set(ByVal value As Boolean)
            _bDefault = value
            If _bDefault = True Then
                lblDefault.Visible = True
            Else
                lblDefault.Visible = False
            End If

        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblCCType.Text = _sCCType
            lblCCExpDateMM.Text = _sCCMM
            lblCCExpDateYYYY.Text = _sCCYYYY
            lblCreditCard.Text = _sCreditCard
            lblCCName.Text = _sCCName
        End If
    End Sub
End Class
