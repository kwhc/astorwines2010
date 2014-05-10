
Partial Class Ucontrols_WUCBillingName
    Inherits System.Web.UI.UserControl
    Private _sName As String
    Private _sCompany As String
    Private _sAddress As String
    Private _sCityStateZipcode As String
    Private _sDayPhone As String
    Private _sEveningPhone As String
    Private _sEmail As String
    '    Private _bMailingList As Boolean
    Public Property BillingEmail() As String
        Get
            _sEmail = lblEmail.Text
            Return _sEmail
        End Get
        Set(ByVal value As String)
            _sEmail = value
            lblEmail.Text = _sEmail
        End Set
    End Property
    Public Property BillingName() As String
        Get
            _sName = lblName.Text
            Return _sName
        End Get
        Set(ByVal value As String)
            _sName = value
            lblName.Text = _sName
        End Set
    End Property
    Public Property BillingCompany() As String
        Get
            Return lblCompany.Text
        End Get
        Set(ByVal value As String)
            _sCompany = value
            lblCompany.Text = _sCompany
            If RTrim(_sCompany) = "" Then
                lblCompany.Visible = False
            Else
                lblCompany.Visible = True
            End If
        End Set
    End Property
    Public Property BillingAddressApt() As String
        Get
            Return lblAddress.Text
        End Get
        Set(ByVal value As String)
            _sAddress = value
            lblAddress.Text = _sAddress
        End Set
    End Property
    Public Property BillingCityStateZipcode() As String
        Get
            Return lblCityStateZipcode.Text
        End Get
        Set(ByVal value As String)
            _sCityStateZipcode = value
            lblCityStateZipcode.Text = _sCityStateZipcode
        End Set
    End Property
    Public Property BillingDayPhone() As String
        Get
            Return lblDayPhone.Text
        End Get
        Set(ByVal value As String)
            _sDayPhone = value
            lblDayPhone.Text = _sDayPhone
        End Set
    End Property
    Public Property BillingEveningPhone() As String
        Get
            Return lblEveningPhone.Text
        End Get
        Set(ByVal value As String)
            _sEveningPhone = value
            lblEveningPhone.Text = _sEveningPhone
        End Set
    End Property
    'Public Property MailingList() As Boolean
    '    Get
    '        Return _bMailingList
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _bMailingList = value
    '        If _bMailingList = True Then
    '            lblMailingList.Visible = True
    '            lblMailingList.Text = "You are set to receive Astor's monthly newsletter to this address. Edit Billing Address to change."
    '        Else
    '            lblMailingList.Visible = True
    '            lblMailingList.Text = "You currently will NOT receive Astor's monthly newsletter. Edit Billing Address to change."
    '        End If
    '    End Set
    'End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblName.Text = _sName
            lblCompany.Text = _sCompany
            If RTrim(_sCompany) = "" Then
                lblCompany.Visible = False
            Else
                lblCompany.Visible = True
            End If
            lblAddress.Text = _sAddress
            lblCityStateZipcode.Text = _sCityStateZipcode
            lblDayPhone.Text = _sDayPhone
            lblEveningPhone.Text = _sEveningPhone
            'If _bMailingList = True Then
            '    lblMailingList.Visible = True
            '    lblMailingList.Text = "You are set to receive Astor's monthly newsletter to this address. Edit Billing Address to change."
            'Else
            '    lblMailingList.Visible = True
            '    lblMailingList.Text = "You currently will NOT receive Astor's monthly newsletter. Edit Billing Address to change."
            'End If
        End If
    End Sub
End Class
