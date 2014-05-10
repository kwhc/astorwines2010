Imports WebCommon
Imports AstorDataClass
Imports System.Data
Partial Class Ucontrols_WUCShippingName
    Inherits System.Web.UI.UserControl
    Private _sIdt As String
    Private _sIds As String
    Private _sName As String
    Private _sCompany As String
    Private _sAddressApt As String
    Private _sCityStateZipCode As String
    Private _sDayPhone As String
    Private _sEveningPhone As String
    Private _sSCross As String
    Private _sEmail As String
    Private _bDefault As Boolean
    Public Property ShippingIdt() As String
        Get
            Return lblIdt.Text
        End Get
        Set(ByVal value As String)
            _sIdt = value
            lblIdt.Text = _sIdt
        End Set
    End Property
    Public Property ShippingIds() As String
        Get
            Return lblIds.Text
        End Get
        Set(ByVal value As String)
            _sIds = value
            lblIds.Text = _sIds
        End Set
    End Property
    Public Property ShippingName() As String
        Get
            _sName = lblName.Text
            Return _sName
        End Get
        Set(ByVal value As String)
            _sName = value
            lblName.Text = _sName
        End Set
    End Property
    Public Property ShippingCompany() As String
        Get
            Return lblCompany.Text
        End Get
        Set(ByVal value As String)
            _sCompany = value
            lblCompany.Text = _sCompany
        End Set
    End Property
    Public Property ShippingAddressApt() As String
        Get
            Return lblAddressApt.Text
        End Get
        Set(ByVal value As String)
            _sAddressApt = value
            lblAddressApt.Text = _sAddressApt
        End Set
    End Property
    Public Property ShippingCityStateZipcode() As String
        Get
            Return lblCityStateZipcode.Text
        End Get
        Set(ByVal value As String)
            _sCityStateZipCode = value
            lblCityStateZipcode.Text = _sCityStateZipCode
        End Set
    End Property
    
    Public Property ShippingDayPhone() As String
        Get
            Return lblDayPhone.Text
        End Get
        Set(ByVal value As String)
            _sDayPhone = value
            lblDayPhone.Text = _sDayPhone
        End Set
    End Property
    Public Property ShippingEveningPhone() As String
        Get
            Return lblEveningPhone.Text
        End Get
        Set(ByVal value As String)
            _sEveningPhone = value
            lblEveningPhone.Text = _sEveningPhone
        End Set
    End Property
    Public Property Scross() As String
        Get
            Return lblScross.Text
        End Get
        Set(ByVal value As String)
            _sSCross = value
            lblScross.Text = _sSCross
        End Set
    End Property
    Public Property ShippingEmail() As String
        Get
            Return lblEmail.Text
        End Get
        Set(ByVal value As String)
            _sEmail = value
            lblEmail.Text = _sEmail
        End Set
    End Property
    Public Property ShippingDefault() As Boolean
        Get
            Return _bDefault
        End Get
        Set(ByVal value As Boolean)
            _bDefault = value
            If _bDefault = True Then
                pnlDefaultShippingAddress.Visible = True
            Else
                pnlDefaultShippingAddress.Visible = False
            End If

        End Set
    End Property
    Public Function bValidateShippingInfo(ByRef sMsg As String) As Boolean
        Dim bFail As Boolean = False

        If RTrim(lblName.Text) = "" Then
            bFail = True
        End If

        If RTrim(lblAddressApt.Text) = "" Then
            bFail = True
        End If
        If RTrim(lblCityStateZipcode.Text) = "" Then
            bFail = True
        End If
        If RTrim(lblDayPhone.Text) = "" Or RTrim(lblDayPhone.Text) = "() -" Then
            bFail = True
        End If
        If Regex.Match(RTrim(lblAddressApt.Text), "[p|P][\s]*[o|O][\s]*[b|B][\s]*[o|O][\s]*[x|X][\s]*[a-zA-Z0-9]*|\b[P|p]+(OST|ost|o|O)?\.?\s*[O|o|0]+(ffice|FFICE)?\.?\s*[B|b][O|o|0]?[X|x]+\.?\s+[#]?(\d+)*(\D+)*\b").Success Then
            bFail = True
            sMsg = sMsg & " - PO Boxes not permitted"
        End If
        Return bFail
    End Function
End Class
