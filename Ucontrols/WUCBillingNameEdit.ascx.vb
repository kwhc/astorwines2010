
Imports WebCommon
Imports AstorDataClass
Imports System.Data
Partial Class Ucontrols_WUCBillingNameEdit
    Inherits System.Web.UI.UserControl
    Private _sIdtNew As String
    Private _sLastName As String
    Private _sFirstName As String
    Private _sCompany As String
    Private _sAddress As String
    Private _sApt As String
    Private _sCity As String
    Private _sState As String
    Private _sZipCode As String
    Private _sDayPhone As String
    Private _sEveningPhone As String
    'Private _bMailingList As Boolean
    Public Property BillingIdtNew() As String
        Get
            Return IdtNew.Text
        End Get
        Set(ByVal value As String)
            _sIdtNew = value
            IdtNew.Text = _sIdtNew
        End Set
    End Property
    Public Property BillingLastName() As String
        Get
            _sLastName = Lastname.Text
            Return _sLastName
        End Get
        Set(ByVal value As String)
            _sLastName = value
            Lastname.Text = _sLastName
        End Set
    End Property
    Public Property BillingFirstName() As String
        Get
            Return Firstname.Text
        End Get
        Set(ByVal value As String)
            _sFirstName = value
            Firstname.Text = _sFirstName
        End Set
    End Property
    Public Property BillingCompany() As String
        Get
            Return Company.Text
        End Get
        Set(ByVal value As String)
            _sCompany = value
            Company.Text = _sCompany
        End Set
    End Property
    Public Property BillingAddress() As String
        Get
            Return Address.Text
        End Get
        Set(ByVal value As String)
            _sAddress = value
            Address.Text = _sAddress
        End Set
    End Property
    Public Property BillingApt() As String
        Get
            Return Apt.Text
        End Get
        Set(ByVal value As String)
            _sApt = value
            Apt.Text = _sApt
        End Set
    End Property
    Public Property BillingCity() As String
        Get
            Return ddlCity.SelectedValue 'City.Text
        End Get
        Set(ByVal value As String)
            _sCity = value
            If _sCity = "" Then
                ddlCity.SelectedIndex = -1
            Else
                ddlCity.SelectedValue = _sCity
            End If
            'City.Text = _sCity
        End Set
    End Property
    Public Property BillingState() As String
        Get
            Return ddlState.SelectedValue
        End Get
        Set(ByVal value As String)
            _sState = value
            If _sState = "-1" Then
                ddlState.SelectedIndex = -1
            Else
                ddlState.SelectedValue = _sState
            End If

        End Set
    End Property
    Public Property BillingZipCode() As String
        Get
            Return Zipcode.Text
        End Get
        Set(ByVal value As String)
            _sZipCode = value
            Zipcode.Text = _sZipCode
        End Set
    End Property
    Public Property BillingDayPhone() As String
        Get
            Return txtDayPhone.Text
        End Get
        Set(ByVal value As String)
            _sDayPhone = value
            txtDayPhone.Text = _sDayPhone
        End Set
    End Property
    Public Property BillingEveningPhone() As String
        Get
            Return txtEveningPhone.text
        End Get
        Set(ByVal value As String)
            _sEveningPhone = value
            txtEveningPhone.text = _sEveningPhone
        End Set
    End Property
    'Public Property MailingList() As Boolean
    '    Get
    '        Return chkMailingList.Checked
    '    End Get
    '    Set(ByVal value As Boolean)
    '        _bMailingList = value
    '        chkMailingList.Checked = _bMailingList
    '    End Set
    'End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadUcombo()
            If _sZipCode <> "" Then
                LoadCity(_sZipCode, _sCity)
            End If
            IdtNew.Text = _sIdtNew
            Lastname.Text = _sLastName
            Firstname.Text = _sFirstName
            Company.Text = _sCompany
            Address.Text = _sAddress
            Apt.Text = _sApt
            'City.Text = _sCity
            ddlState.SelectedValue = _sState
            Zipcode.Text = _sZipCode
            txtDayPhone.Text = _sDayPhone
            txtEveningPhone.Text = _sEveningPhone
            '  chkMailingList.Checked = _bMailingList
        End If
    End Sub
    Private Sub LoadUcombo()

        'load state
        With ddlState
            .DataSource = Application("StateCd")
            .DataMember = ""
            .DataValueField = "state"
            .DataTextField = "descr"
            .DataBind()
        End With
    End Sub
    Public Sub LoadCity(ByVal sZipcode As String, ByVal sCity As String)
        Dim dsCityStateZip As New DataSet

        dsCityStateZip = GetCityStateDataset(sZipcode, sCity)
        'load city
        With ddlCity
            .DataSource = dsCityStateZip.Tables(0)
            .DataMember = ""
            .DataValueField = "city"
            .DataTextField = "city"
            .DataBind()
        End With
    End Sub
    Private Sub GetCityStateData(ByVal sZipCode As String, ByRef sCity As String, ByRef sState As String)

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)

        Try

            _odata.GetCityStateForZipCode(sZipCode, sCity, sState, 0)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function bValidateBillingInfo() As Boolean
        Dim bFail As Boolean = False

        If RTrim(Firstname.Text) = "" Then
            bFail = True
        End If
        If RTrim(Lastname.Text) = "" Then
            bFail = True
        End If
        If ddlState.SelectedIndex = 0 Then
            bFail = True
        End If
        If RTrim(Address.Text) = "" Then
            bFail = True
        End If
        If ddlCity.SelectedIndex = -1 Then
            bFail = True
        End If
        'If RTrim(City.Text) = "" Then
        '    bFail = True
        'End If
        If RTrim(Zipcode.Text) = "" Then
            bFail = True
        End If
        If Len(RTrim(Zipcode.Text)) < 5 Then
            bFail = True
        End If
        If RTrim(txtDayPhone.Text) = "" Then
            bFail = True
        End If

        Return bFail
    End Function
    Private Function GetCityStateDataset(ByVal sZipCode As String, ByVal sCity As String) As DataSet

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)

        Try
            GetCityStateDataset = _odata.GetCityStateZipCode(sZipCode, sCity)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Protected Sub Zipcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Zipcode.TextChanged
        If Len(RTrim(Zipcode.Text)) >= 5 Then
            Dim sCity As String = String.Empty
            Dim sState As String = String.Empty
           

            GetCityStateData(Zipcode.Text, sCity, sState)

            If RTrim(sCity) = "" Or RTrim(sState) = "" Then
                lblInvalidZip.Visible = True
                showBreak.Visible = False
                'City.Text = ""
                LoadCity(Zipcode.Text, sCity)
                ddlState.SelectedIndex = 0
                ddlCity.SelectedIndex = -1
            Else

                'City.Text = sCity
                lblInvalidZip.Visible = False
                showBreak.Visible = True
                ddlState.SelectedValue = sState
                LoadCity(Zipcode.Text, sCity)
                ddlCity.SelectedValue = sCity
                ddlCity.Focus()
                'City.Focus()
                RaiseBubbleEvent(sender, e)
            End If
        End If

    End Sub
End Class
