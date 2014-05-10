Imports WebCommon
Imports AstorDataClass
Imports System.Data
Partial Class Ucontrols_WUCShippingNameEdit
    Inherits System.Web.UI.UserControl
    Private _sIdt As String
    Private _sIds As String
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
    Private _sSCross As String
    Private _sEmail As String
    Private _bDefault As Boolean
    Public Property ShippingIdt() As String
        Get
            Return Idt.Text
        End Get
        Set(ByVal value As String)
            _sIdt = value
            Idt.Text = _sIdt
        End Set
    End Property
    Public Property ShippingIds() As String
        Get
            Return Ids.Text
        End Get
        Set(ByVal value As String)
            _sIds = value
            Ids.Text = _sIds
        End Set
    End Property
    Public Property ShippingLastName() As String
        Get
            _sLastName = Lastname.Text
            Return _sLastName
        End Get
        Set(ByVal value As String)
            _sLastName = value
            Lastname.Text = _sLastName
        End Set
    End Property
    Public Property ShippingFirstName() As String
        Get
            Return Firstname.Text
        End Get
        Set(ByVal value As String)
            _sFirstName = value
            Firstname.Text = _sFirstName
        End Set
    End Property
    Public Property ShippingCompany() As String
        Get
            Return Company.Text
        End Get
        Set(ByVal value As String)
            _sCompany = value
            Company.Text = _sCompany
        End Set
    End Property
    Public Property ShippingAddress() As String
        Get
            Return Address.Text
        End Get
        Set(ByVal value As String)
            _sAddress = value
            Address.Text = _sAddress
        End Set
    End Property
    Public Property ShippingApt() As String
        Get
            Return Apt.Text
        End Get
        Set(ByVal value As String)
            _sApt = value
            Apt.Text = _sApt
        End Set
    End Property
    Public Property ShippingCity() As String
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
    Public Property ShippingState() As String
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
    Public Property ShippingZipCode() As String
        Get
            Return Zipcode.Text
        End Get
        Set(ByVal value As String)
            _sZipCode = value
            Zipcode.Text = _sZipCode
        End Set
    End Property
    Public Property ShippingDayPhone() As String
        Get
            Return txtDayPhone.Text
        End Get
        Set(ByVal value As String)
            _sDayPhone = value
            txtDayPhone.Text = _sDayPhone
        End Set
    End Property
    Public Property ShippingEveningPhone() As String
        Get
            Return txtEveningPhone.Text
        End Get
        Set(ByVal value As String)
            _sEveningPhone = value
            txtEveningPhone.Text = _sEveningPhone
        End Set
    End Property
    Public Property Scross() As String
        Get
            Return txtscross.Text
        End Get
        Set(ByVal value As String)
            _sSCross = value
            txtscross.Text = _sSCross
        End Set
    End Property
    Public Property ShippingEmail() As String
        Get
            Return txtShippingEmail.Text
        End Get
        Set(ByVal value As String)
            _sEmail = value
            txtShippingEmail.Text = _sEmail
        End Set
    End Property
    Public Property ShippingDefault() As Boolean
        Get
            Return chkDefaultShippingAddress.Checked
        End Get
        Set(ByVal value As Boolean)
            _bDefault = value
            chkDefaultShippingAddress.Checked = _bDefault
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadUcombo()

            Idt.Text = _sIdt
            Ids.Text = _sIds
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
            txtscross.Text = _sSCross
            txtShippingEmail.Text = _sEmail
            chkDefaultShippingAddress.Checked = _bDefault
            If _sZipCode <> "" Then
                LoadCity(_sZipCode, _sCity)
            End If
        End If
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
   
    Private Sub LoadUcombo()

        'load state
        With ddlState
            .DataSource = Application("StateCdShipTo")
            .DataMember = ""
            .DataValueField = "state"
            .DataTextField = "descr"
            .DataBind()
        End With
    End Sub
    Public Function bValidateShippingInfo(ByRef sMsg As String) As Boolean
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
        If RTrim(Zipcode.Text) = "" Then
            bFail = True
        End If
        If Len(RTrim(Zipcode.Text)) < 5 Then
            bFail = True
        End If
        If RTrim(txtDayPhone.Text) = "" Then
            bFail = True
        End If
        'If Regex.Match(RTrim(Address.Text), "\b[P|p]*(OST|ost)*\.*\s*[O|o|0]*(ffice|FFICE)*\.*\s*[B|b][O|o|0][X|x].*\d+\b").Success Then
        If Regex.Match(RTrim(Address.Text), "[p|P][\s]*[o|O][\s]*[b|B][\s]*[o|O][\s]*[x|X][\s]*[a-zA-Z0-9]*|\b[P|p]+(OST|ost|o|O)?\.?\s*[O|o|0]+(ffice|FFICE)?\.?\s*[B|b][O|o|0]?[X|x]+\.?\s+[#]?(\d+)*(\D+)*\b").Success Then

            bFail = True
            sMsg = sMsg & " - PO Boxes not permitted"
        End If
        Return bFail
    End Function



    Private Sub GetCityStateData(ByVal sZipCode As String, ByRef sCity As String, ByRef sState As String)

        Dim dsn As String = WebAppConfig.ConnectString

        Dim _odata As New cAstorWebData(dsn)

        Try
            _odata.GetCityStateForZipCode(sZipCode, sCity, sState, 1)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
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
                'showBreak.Visible = False
                'City.Text = ""
                LoadCity(Zipcode.Text, sCity)
                ddlState.SelectedIndex = 0
                ddlCity.SelectedIndex = -1

            Else

                'City.Text = sCity
                lblInvalidZip.Visible = False
                'showBreak.Visible = True
                ddlState.SelectedValue = sState
                LoadCity(Zipcode.Text, sCity)
                ddlCity.SelectedValue = sCity
                ddlCity.Focus()
                RaiseBubbleEvent(sender, e)
            End If

        End If
    End Sub
End Class
