Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Web.Security
Imports System.Security.Cryptography
Imports aspNetEmail
Imports AstorUtilsClass
Imports WebCommon

Namespace AstorwinesCommerce

    Public Class UsersDB

        Private _semailServer As String
        Private _semailUserIDOrders As String
        Private _semailPasswordOrders As String
        Private _semailUserIDSubscribe As String
        Private _semailPasswordSubscribe As String
        Private _semailUserIDUnSubscribe As String
        Private _semailPasswordUnSubscribe As String
        Private _semailUserIDAccounts As String
        Private _semailPasswordAccounts As String

        Dim m_ConnectionString As String
        Public WriteOnly Property EmailServer() As String
            Set(ByVal value As String)
                _semailServer = value
            End Set
        End Property
        Public WriteOnly Property EmailUserIDOrders() As String
            Set(ByVal value As String)
                _semailUserIDOrders = value
            End Set
        End Property
        Public WriteOnly Property EmailPasswordOrders() As String
            Set(ByVal value As String)
                _semailPasswordOrders = value
            End Set
        End Property
        Public WriteOnly Property EmailUserIDSubscribe() As String
            Set(ByVal value As String)
                _semailUserIDSubscribe = value
            End Set
        End Property
        Public WriteOnly Property EmailPasswordSubscribe() As String
            Set(ByVal value As String)
                _semailPasswordSubscribe = value
            End Set
        End Property
        Public WriteOnly Property EmailUserIDUnSubscribe() As String
            Set(ByVal value As String)
                _semailUserIDUnSubscribe = value
            End Set
        End Property
        Public WriteOnly Property EmailPasswordUnSubscribe() As String
            Set(ByVal value As String)
                _semailPasswordUnSubscribe = value
            End Set
        End Property
        Public WriteOnly Property EmailUserIDAccounts() As String
            Set(ByVal value As String)
                _semailUserIDAccounts = value
            End Set
        End Property
        Public WriteOnly Property EmailPasswordAccounts() As String
            Set(ByVal value As String)
                _semailPasswordAccounts = value
            End Set
        End Property
        Public Sub New(ByVal dsn As String)
            m_ConnectionString = dsn
        End Sub

        Public Sub AddNewUser(ByVal customerNumber As String, ByVal password As String, ByVal idt As String, ByVal bEmailSubscribe As Boolean, ByVal bEmailSubscribeAC As Boolean)

            Dim sSP As String = "AddNewUser_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim sSalt As String
            Dim sHashPassword As String

            sSalt = CreateSalt(16)
            sHashPassword = CreatePasswordHash(password, sSalt)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@customerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber.ToString.ToLower
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value() = idt
                    .Add(New SqlParameter("@password", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sHashPassword
                    .Add(New SqlParameter("@salt", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sSalt
                    .Add(New SqlParameter("@EmailSubscribe", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = bEmailSubscribe
                    .Add(New SqlParameter("@EmailSubscribeAC", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = bEmailSubscribeAC
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception

                    Throw ex
                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With


        End Sub
        Public Function ResetUserPassword(ByVal customerNumber As String) As String

            Dim sSP As String = "ResetUserPassword_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim sSalt As String
            Dim sHashPassword As String
            Dim sPassword As String

            sSalt = CreateSalt(16)
            sPassword = GenerateNewPassword()
            sHashPassword = CreatePasswordHash(sPassword, sSalt)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@customerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                    .Add(New SqlParameter("@password", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sHashPassword
                    .Add(New SqlParameter("@salt", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sSalt
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception

                    Throw ex
                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With
            ResetUserPassword = sPassword

        End Function
        Public Function ResetUserPassword(ByVal customerNumber As String, ByVal password As String) As Boolean

            Dim sSP As String = "ResetUserPassword_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim sSalt As String
            Dim sHashPassword As String

            sSalt = CreateSalt(16)
            'sPassword = GenerateNewPassword()
            sHashPassword = CreatePasswordHash(password, sSalt)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@customerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                    .Add(New SqlParameter("@password", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sHashPassword
                    .Add(New SqlParameter("@salt", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sSalt
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception
                    ResetUserPassword = False
                    Throw ex
                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With
            ResetUserPassword = True

        End Function
        Public Sub AddNewEmail(ByVal email As String, ByVal subscribe As Boolean, ByVal mailfailure As Boolean)

            Dim sSP As String = "AddNewEmail_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@email", SqlDbType.VarChar, 255, ParameterDirection.Input)).Value = email
                    .Add(New SqlParameter("@subscribe", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = subscribe
                    .Add(New SqlParameter("@mailfailure", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = mailfailure
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception
                    Throw ex
                    'strMessage = "Problem with export"

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With


        End Sub
        Public Function GetEmailList(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Type As String) As DataSet

            Dim sSP As String = "GetEmailList_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet





            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@StartDate", SqlDbType.DateTime, 12, ParameterDirection.Input)).Value = StartDate
                    .Add(New SqlParameter("@EndDate", SqlDbType.DateTime, 12, ParameterDirection.Input)).Value = EndDate
                    .Add(New SqlParameter("@Type", SqlDbType.VarChar, 10, ParameterDirection.Input)).Value = Type
                End With

                _daLocal = New SqlDataAdapter(_scSC)
                _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

                Try
                    _daLocal.Fill(dsReturn)
                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With

            Return dsReturn

        End Function
        Public Sub AddNewEmailSentQueue(ByVal OrderNumber As String, ByVal Idt As String)

            Dim sSP As String = "AddNewEmailSentQueue_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)


            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@OrderNumber", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = OrderNumber
                    .Add(New SqlParameter("@Idt", SqlDbType.VarChar, 6, ParameterDirection.Input)).Value = Idt
                    .Add(New SqlParameter("@Site", SqlDbType.Int, 1, ParameterDirection.Input)).Value = 1
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception

                    Throw ex
                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With


        End Sub
        Public Function GetLastEmailExportDate(ByVal Type As String) As Date

            Dim sSP As String = "GetLastEmailExportDate_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            ' Create the required input parameters 
            Dim _prmType As New SqlParameter
            Dim _prmStartDateOut As New SqlParameter

            Try
                _scSC.CommandType = CommandType.StoredProcedure

                _prmType = _scSC.Parameters.Add("@type", System.Data.SqlDbType.VarChar, 10)
                _prmType.Direction = ParameterDirection.Input
                _prmType.Value = Type

                _prmStartDateOut = _scSC.Parameters.Add("@StartDateOut", System.Data.SqlDbType.DateTime, 12)
                _prmStartDateOut.Direction = ParameterDirection.Output

                _scSC.Connection.Open()
                _scSC.ExecuteNonQuery()

                GetLastEmailExportDate = _scSC.Parameters("@StartDateOut").Value
            Catch ex As Exception
                Throw ex

            Finally
                If _scSC.Connection.State = ConnectionState.Open Then
                    _scSC.Connection.Close()
                End If
            End Try



        End Function
        Public Sub ChangeEmail(ByVal oldemail As String, ByVal newemail As String, ByVal bEmailSubscribe As Boolean)

            Dim sSP As String = "ChangeUserEmail_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@oldCustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = oldemail.ToString.ToLower
                    .Add(New SqlParameter("@newCustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = newemail.ToString.ToLower
                    .Add(New SqlParameter("@EmailSubscribe", SqlDbType.Bit, 1, ParameterDirection.Input)).Value = bEmailSubscribe
                End With
                Try
                    .Connection.Open()
                    .ExecuteNonQuery()

                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try
            End With


        End Sub

        Public Function UserExists(ByVal customerNumber As String) As Boolean
            Dim sSP As String = "UserExists_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                End With

                _daLocal = New SqlDataAdapter(_scSC)
                _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

                Try
                    _daLocal.Fill(dsReturn, "accountDetails")
                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try



            End With

            ' if there is a row then return true
            If dsReturn.Tables(0).Rows.Count < 1 Then
                Return False
            Else
                Return True
            End If

        End Function
        Public Function IsSuspendedEmail(ByVal customerNumber As String) As Boolean
            Dim sSP As String = "SuspendedEmail_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                End With

                _daLocal = New SqlDataAdapter(_scSC)
                _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

                Try
                    _daLocal.Fill(dsReturn, "accountDetails")
                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try



            End With

            ' if there is a row then return true
            If dsReturn.Tables(0).Rows.Count < 1 Then
                Return False
            Else
                Return True
            End If

        End Function
        Public Function CheckEmail(ByVal email As String) As Boolean
            Dim bError As Boolean = False

            If InStr(email, "@") = 0 Then
                bError = True
            End If
            If InStr(email, ".") = 0 Then
                bError = True
            End If

            ' if there is a row then return true
            Return bError

        End Function


        Public Function ValidateLogin(ByVal customerNumber As String, ByVal password As String) As Boolean
            Dim sSP As String = "ValidateLogin_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet
            Dim sSalt As String
            Dim sHashPassword As String

            sSalt = RTrim(GetSaltForLogin(customerNumber))
            sHashPassword = RTrim(CreatePasswordHash(password, sSalt))

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@CustomerNumber", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = customerNumber
                    .Add(New SqlParameter("@Password", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sHashPassword
                    .Add(New SqlParameter("@salt", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sSalt
                End With

                _daLocal = New SqlDataAdapter(_scSC)
                _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

                Try
                    _daLocal.Fill(dsReturn, "accountDetails")
                Catch ex As Exception
                    'MessageBox.Show(ex.Message, "Error Getting Ship Labels!", MessageBoxButtons.OK)

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try



            End With

            ' if there is a row then return true
            If dsReturn.Tables(0).Rows.Count < 1 Then
                Return False
            Else
                Return True
            End If

        End Function
        Private Function GetSaltForLogin(ByVal customerNumber As String) As String
            Dim sSP As String = "GetSaltForLogin_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet
            Dim sSalt As String = String.Empty
            Dim _prmCustomerNumber As New SqlParameter
            Dim _prmSalt As New SqlParameter

            With _scSC
                .CommandType = CommandType.StoredProcedure
                _prmCustomerNumber = .Parameters.Add("@CustomerNumber", System.Data.SqlDbType.VarChar, 100)
                _prmCustomerNumber.Value = customerNumber
                _prmCustomerNumber.Direction = ParameterDirection.Input

                _prmSalt = .Parameters.Add("@salt", System.Data.SqlDbType.VarChar, 100)
                _prmSalt.Direction = ParameterDirection.Output
                .Connection.Open()

                .ExecuteNonQuery()
                If .Parameters("@salt").Value Is DBNull.Value Then
                    sSalt = ""
                Else
                    sSalt = .Parameters("@salt").Value

                End If

                Try

                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try



            End With

            GetSaltForLogin = sSalt

        End Function
        Private Shared Function CreateSalt(ByVal size As Integer) As String
            Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider
            Dim buff(size) As Byte
            rng.GetBytes(buff)
            Return Convert.ToBase64String(buff)
        End Function

        Private Shared Function CreatePasswordHash(ByVal pwd As String, ByVal salt As String) As String
            Dim saltAndPwd As String = String.Concat(pwd, salt)
            Dim hashedPwd As String = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1")
            Return hashedPwd
        End Function
        Public Function GenerateNewPassword() As String
            Dim password As String = Membership.GeneratePassword(6, 1)
            Return password
        End Function
        Public Sub EmailNewPasswordMessage(ByVal sEmail As String, ByVal sPassword As String)

            Dim emailServer As String = _semailServer
            Dim emailUserID As String = _semailUserIDAccounts
            Dim emailPassword As String = _semailPasswordAccounts
            Dim emailFrom As String = _semailUserIDAccounts
            Dim emailTo As String = sEmail
            Dim emailCc As String = String.Empty
            Dim emailBcc As String = "accounts@astorwines.com"
            Dim emailPriority As MailPriority = MailPriority.High
            Dim emailFormat As MailFormat = MailFormat.Text
            Dim emailAttachment As String = String.Empty
            Dim emailSubj As String = "Astor Wines & Spirits Password Reset"

            Dim emailBody As String = "Password for the Astor Wines & Spirits Website for email/user " & sEmail & vbCrLf & _
            "was reset to " & sPassword & vbCrLf & vbCrLf & _
            "Astor Wines & Spirits" & vbCrLf & vbCrLf & _
            "If you did not request this or you have any questions about this email please email us at customer-service1@astorwines.com or call us at (212) 674-7500." & vbCrLf & vbCrLf & _
            "---------------------------------------" & vbCrLf & vbCrLf


            Dim email As New cEmail
            Dim sError As String = String.Empty
            Try
                email.UserID = emailUserID
                email.Password = emailPassword
                email.SendEmailSSL(emailServer, emailFrom, emailTo, emailCc, emailBcc, emailPriority, emailFormat, emailSubj, emailBody, emailAttachment, sError, 465)
                If sError <> String.Empty Then
                    Throw New System.Exception(sError)
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Public Sub EmailNewEmailMessage(ByVal sOldEmail As String, ByVal sNewEmail As String)

            Dim emailServer As String = _semailServer
            Dim emailUserID As String = _semailUserIDAccounts
            Dim emailPassword As String = _semailPasswordAccounts
            Dim emailFrom As String = _semailUserIDAccounts
            Dim emailTo As String = sNewEmail
            Dim emailCc As String = sOldEmail
            Dim emailBcc As String = "accounts@astorwines.com"
            Dim emailPriority As MailPriority = MailPriority.High
            Dim emailFormat As MailFormat = MailFormat.Text
            Dim emailAttachment As String = String.Empty
            Dim emailSubj As String = "Astor Wines & Spirits New Email"

            Dim emailBody As String = "The email/userid " & sOldEmail & vbCrLf & _
            "for the Astor Wines & Spirits Website was changed to " & sNewEmail & vbCrLf & vbCrLf & _
            "Astor Wines & Spirits" & vbCrLf & vbCrLf & _
            "If you did not request this or you have any questions about this email please email us at customer-service1@astorwines.com or call us at (212) 674-7500." & vbCrLf & vbCrLf & _
            "---------------------------------------" & vbCrLf & vbCrLf


            Dim email As New cEmail
            Dim sError As String = String.Empty
            Try
                email.UserID = emailUserID
                email.Password = emailPassword
                email.SendEmailSSL(emailServer, emailFrom, emailTo, emailCc, emailBcc, emailPriority, emailFormat, emailSubj, emailBody, emailAttachment, sError, 465)
                If sError <> String.Empty Then
                    Throw New System.Exception(sError)
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Public Sub EmailOrderConfirmationMessage(ByVal Inum As String, ByVal sNewEmail As String)

            Dim emailServer As String = _semailServer
            Dim emailUserID As String = _semailUserIDOrders
            Dim emailPassword As String = _semailPasswordOrders
            Dim emailFrom As String = _semailUserIDOrders
            Dim emailTo As String = sNewEmail
            Dim emailCc As String = String.Empty
            Dim emailBcc As String = "orders@astorwines.com"
            'Dim emailBcc As String = "kwilhelm@astorcenternyc.com"
            Dim emailPriority As MailPriority = MailPriority.Normal
            Dim emailFormat As MailFormat = MailFormat.Text
            Dim emailAttachment As String = String.Empty
            Dim emailSubj As String = "Astor Wines & Spirits Order Confirmation for Order Number " & Inum

            Dim emailBody As String
            Dim _oWebCommon As New WebPageBase
            Dim custID As String = sNewEmail
            Dim Orders As New AstorwinesCommerce.OrdersDB(_oWebCommon.getConnStr())
            Dim dsOrder As New DataSet

            dsOrder = Orders.GetOrderForCustomerFormatted(custID, Inum)

            emailBody = OrderHeader(dsOrder) & vbCrLf & _
            "----------------------------------------------------------------" & vbCrLf & vbCrLf & _
            "Your Order" & vbCrLf & vbCrLf & _
            OrderDetail(dsOrder) & vbCrLf & _
            "----------------------------------------------------------------" & vbCrLf & vbCrLf & _
            "Again, thank you for your order. We will be processing it shortly." & vbCrLf & vbCrLf & _
            "Astor Wines & Spirits" & vbCrLf & _
            vbCrLf & vbCrLf


            Dim email As New cEmail
            Dim sError As String = String.Empty
            Try
                email.UserID = emailUserID
                email.Password = emailPassword
                email.SendEmailSSL(emailServer, emailFrom, emailTo, emailCc, emailBcc, emailPriority, emailFormat, emailSubj, emailBody, emailAttachment, sError, 465)
                If sError <> String.Empty Then
                    ' display mail server problem message
                    'Throw New System.Exception(sError)
                    AddNewEmailSentQueue(Inum, String.Empty)
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Public Sub EmailToFriendMessage(ByVal Item As String, ByVal sFromEmail As String, ByVal sToEmail As String, ByVal sItemInfo As String)

            Dim emailServer As String = _semailServer
            Dim emailUserID As String = _semailUserIDOrders
            Dim emailPassword As String = _semailPasswordOrders
            Dim emailFrom As String = sFromEmail
            Dim emailTo As String = sToEmail
            Dim emailCc As String = String.Empty
            Dim emailBcc As String = String.Empty
            Dim emailPriority As MailPriority = MailPriority.Normal
            Dim emailFormat As MailFormat = MailFormat.Text
            Dim emailAttachment As String = String.Empty
            Dim emailSubj As String = "Astor Wines & Spirits Recommended Item"

            Dim emailBody As String
            Dim _oWebCommon As New WebPageBase
            'Dim custID As String = _oWebCommon.GetCustomerID()
            Dim Products As New AstorwinesCommerce.ProductsDB(_oWebCommon.getConnStr())

            'sItemInfo = Products.GetInfoForItem(Item)

            emailBody = sItemInfo '"http://www.astorwines.com/SearchResultsSingle.aspx?p=1&search=15092&searchtype=Contains"


            Dim email As New cEmail
            Dim sError As String = String.Empty
            Try
                email.UserID = emailUserID
                email.Password = emailPassword
                email.SendEmailSSL(emailServer, emailFrom, emailTo, emailCc, emailBcc, emailPriority, emailFormat, emailSubj, emailBody, emailAttachment, sError, 465)
                If sError <> String.Empty Then
                    Throw New System.Exception(sError)
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Private Function OrderHeader(ByVal Order As DataSet) As String
            Dim sOrderHeader As String = String.Empty

            With Order.Tables(0)
                If .Rows.Count > 0 Then
                    With .Rows(0)
                        sOrderHeader = "Thank you for your order." & vbCrLf & _
                        "Your order number is: " & .Item("OrderNumber") & vbCrLf & vbCrLf

                        If .Item("b3rdPartyShipInsAgreement") = True Then
                            sOrderHeader = sOrderHeader & "We will be processing your order within the next 24 hours, at which point you will receive an email from the third party shipper with your scheduled date of delivery and in certain cases, tracking information. " & _
                           "Below, please find the details of your order." & vbCrLf & vbCrLf
                        Else
                            sOrderHeader = sOrderHeader & "We will be processing your order within the next 24 hours, " & _
                            "at which point you will receive an email with your scheduled date of delivery or, if your order is being shipped via " & _
                            "UPS, the date it will depart from our store. (In the case of the latter, you will then receive a second email containing " & _
                            "your UPS tracking number.) Below, please find the details of your order." & vbCrLf & vbCrLf
                        End If

                        sOrderHeader = sOrderHeader & "NOTE: DO NOT REPLY TO THIS EMAIL. It is generated from an automated system and won't get to us! If you have any questions " & _
                        "or changes regarding your order, please call us at 212-674-7500." & vbCrLf & vbCrLf & _
                         "----------------------------------------------------------------" & vbCrLf & vbCrLf

                        sOrderHeader = sOrderHeader & "Payment Information" & vbCrLf & .Item("Name") & vbCrLf
                        If RTrim(.Item("Company")) <> "" Then
                            sOrderHeader = sOrderHeader & .Item("Company") & vbCrLf
                        End If
                        sOrderHeader = sOrderHeader & .Item("AddressApt") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("CityStateZipcode") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("Country") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("DayPhone") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("EveningPhone") & vbCrLf & vbCrLf
                        'lblEmail.Text = GetCustomerID(Request, Response)

                        sOrderHeader = sOrderHeader & "Shipping Information" & vbCrLf & .Item("ShipName") & vbCrLf
                        If RTrim(.Item("ShipCompany")) <> "" Then
                            sOrderHeader = sOrderHeader & .Item("ShipCompany") & vbCrLf
                        End If
                        sOrderHeader = sOrderHeader & .Item("ShipAddressApt") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("ShipCityStateZipcode") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("Scross") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("ShipDayPhone") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("ShipEveningPhone") & vbCrLf
                        sOrderHeader = sOrderHeader & .Item("ShipEmail") & vbCrLf & vbCrLf

                        sOrderHeader = sOrderHeader & "Payment Method" & vbCrLf & .Item("ccType") & vbCrLf & .Item("ccnum") & vbCrLf & .Item("ccExpDate") & vbCrLf & vbCrLf

                        If .Item("GiftCardNumber") <> "" Then
                            If Len(.Item("GiftCardNumber")) = 16 Then
                                sOrderHeader = sOrderHeader & "Gift Card: XXXXXXXXXXXX" & Mid(.Item("GiftCardNumber"), 13, 4) & " - Anticipated Gift Card Amount: " & .Item("GiftCardValue") & vbCrLf & vbCrLf
                            Else
                                sOrderHeader = sOrderHeader & "Gift Card: XXXXXXXXXXXXXXX" & Mid(.Item("GiftCardNumber"), 16, 4) & " - Anticipated Gift Card Amount: " & .Item("GiftCardValue") & vbCrLf & vbCrLf
                            End If
                        End If

                        sOrderHeader = sOrderHeader & "Shipping Method" & vbCrLf & .Item("ShipType") & vbCrLf

                        If .Item("ShipType") = "Astor Delivery" Then
                            sOrderHeader = sOrderHeader & "Tentative Delivery Date: " & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & vbCrLf & vbCrLf
                        ElseIf .Item("ShipType") = "PM Messenger" Then
                            sOrderHeader = sOrderHeader & "Tentative Delivery Date: " & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & " in the time range " & .Item("sPMCourier") & vbCrLf & vbCrLf
                        Else
                            If .Item("b3rdPartyShipInsAgreement") = False Then
                                sOrderHeader = sOrderHeader & "Shipment will tentatively depart on " & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & vbCrLf & vbCrLf
                            Else
                                sOrderHeader = sOrderHeader & "Shipment will tentatively transfer on " & FormatDateTime(.Item("ShipDate"), DateFormat.LongDate).ToString & vbCrLf & vbCrLf
                            End If

                        End If

                        If Trim(.Item("ShipInst")) <> "" Then
                            sOrderHeader = sOrderHeader & "Shipping Instructions" & vbCrLf & .Item("ShipInst") & vbCrLf & vbCrLf
                        End If

                        If .Item("Gift") = True Then
                            sOrderHeader = sOrderHeader & "Gift Order: " & .Item("GiftNote") & vbCrLf & vbCrLf
                        End If

                        sOrderHeader = sOrderHeader & "Order Total" & vbCrLf
                        sOrderHeader = sOrderHeader & "Subtotal: " & .Item("SubTotalValue") & vbCrLf
                        sOrderHeader = sOrderHeader & "Tax Rate (" & (.Item("TaxRate") * 100).ToString & "%): " & .Item("TaxValue") & vbCrLf
                        sOrderHeader = sOrderHeader & "Shipping & Handling: " & .Item("ShippingValue") & vbCrLf

                        If .Item("n3rdPartyAmountInsAmount") <> 0 Then
                            sOrderHeader = sOrderHeader & "Shipping Insurance" & ": " & .Item("n3rdPartyAmountInsAmount") & vbCrLf
                        End If

                        If RTrim(.Item("Promo")) <> "" Then
                            sOrderHeader = sOrderHeader & "Promo - " & .Item("Promo") & ": (" & .Item("PromoValue") & ")" & vbCrLf
                        End If
                        sOrderHeader = sOrderHeader & "Order Total: " & .Item("TotalValue") & vbCrLf & vbCrLf





                    End With
                End If
            End With

            Return sOrderHeader

        End Function
        Private Function OrderDetail(ByVal Order As DataSet) As String
            Dim sOrderDetail As String = String.Empty
            Dim sUnitType As String = String.Empty
            Dim vintage As String = String.Empty
            Dim itemNumber As String = String.Empty
            Dim itemName As String = String.Empty
            Dim drRow As DataRow

            With Order.Tables(1)
                If .Rows.Count > 0 Then
                    For Each drRow In Order.Tables(1).Rows

                        With drRow
                            If RTrim(.Item("UnitType")) = "Case" Then
                                sUnitType = "Case of " & RTrim(.Item("Pack")).ToString
                            Else
                                sUnitType = RTrim(.Item("UnitType"))
                            End If

                            itemNumber = .Item("Item")
                            itemName = RTrim(.Item("Name"))

                            If RTrim(.Item("vintage")) <> "" Then
                                vintage = " - " & RTrim(.Item("vintage"))
                            End If

                            sOrderDetail = sOrderDetail & _
                            itemName & vintage & " (#" & itemNumber & ")" & vbCrLf & _
                            "Bottle Size: " & RTrim(.Item("size")) & vbCrLf & _
                            "Quantity: " & RTrim(.Item("Quantity")) & " " & sUnitType & vbCrLf & _
                            "Price: " & (Convert.ToDecimal(.Item("Quantity")) * Convert.ToDecimal(.Item("UnitPrice"))).ToString & vbCrLf & vbCrLf

                        End With
                    Next
                    
                End If
            End With

            Return sOrderDetail

        End Function
        Public Sub EmailSubscribeMessage(ByVal sNewEmail As String)

            Dim emailServer As String = _semailServer
            Dim emailUserID As String = _semailUserIDSubscribe
            Dim emailPassword As String = _semailPasswordSubscribe
            Dim emailFrom As String = _semailUserIDSubscribe
            Dim emailTo As String = sNewEmail
            Dim emailCc As String = String.Empty
            Dim emailBcc As String = "subscribe@astorwines.com"
            Dim emailPriority As MailPriority = MailPriority.High
            Dim emailFormat As MailFormat = MailFormat.Text
            Dim emailAttachment As String = String.Empty
            Dim emailSubj As String = "Astor Wines & Spirits Email List Subscribe"
            Dim emailBody As String

            emailBody = "NOTE:  DO NOT REPLY TO THIS EMAIL.  It is generated from an automated system and won't get to us!" & vbCrLf & vbCrLf

            emailBody = emailBody & "Thank you for subscribing to Astor's Email List. We look forward to keeping you in the know about new " & _
            "and interesting wines and special events at Astor. If, at any time, you decide to unsubscribe, " & _
            "you may do so by following the unsubscribe link at the end of every email sent to you." & vbCrLf & vbCrLf & _
            "The email that was added is: " & sNewEmail & vbCrLf & vbCrLf & _
            "Welcome to the club!" & vbCrLf & vbCrLf & _
            "Astor Wines & Spirits" & vbCrLf & vbCrLf & _
            "If you have any questions about this email please email us at customer-service1@astorwines.com or call us at (212) 674-7500." & vbCrLf & vbCrLf & _
            "---------------------------------------" & vbCrLf & vbCrLf


            Dim email As New cEmail
            Dim sError As String = String.Empty
            Try
                email.UserID = emailUserID
                email.Password = emailPassword
                email.SendEmailSSL(emailServer, emailFrom, emailTo, emailCc, emailBcc, emailPriority, emailFormat, emailSubj, emailBody, emailAttachment, sError, 465)
                If sError <> String.Empty Then
                    Throw New System.Exception(sError)
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Public Function IsEmailOnList(ByVal sEmailToCheck As String) As Boolean
            Dim sSP As String = "IsEmailOnList_sp"
            Dim _cnConnection As New SqlConnection(m_ConnectionString)
            Dim _scSC As New SqlCommand(sSP, _cnConnection)
            Dim _daLocal As New SqlDataAdapter
            Dim dsReturn As New DataSet

            With _scSC
                .CommandType = CommandType.StoredProcedure

                With .Parameters
                    .Add(New SqlParameter("@Email", SqlDbType.VarChar, 100, ParameterDirection.Input)).Value = sEmailToCheck
                End With

                _daLocal = New SqlDataAdapter(_scSC)
                _daLocal.SelectCommand.CommandType = CommandType.StoredProcedure

                Try
                    _daLocal.Fill(dsReturn, "Email")
                Catch ex As Exception
                    Throw ex

                Finally
                    If .Connection.State = ConnectionState.Open Then
                        .Connection.Close()
                    End If
                End Try



            End With

            ' if there is a row then return true
            If dsReturn.Tables.Count = 0 Then
                Return False
            Else
                If dsReturn.Tables(0).Rows.Count < 1 Then
                    Return False
                Else
                    Return True
                End If
            End If


        End Function
        Public Sub EmailUnSubscribeMessage(ByVal sEmail As String)
            Dim emailServer As String = _semailServer
            Dim emailUserID As String = _semailUserIDUnSubscribe
            Dim emailPassword As String = _semailPasswordUnSubscribe
            Dim emailFrom As String = _semailUserIDUnSubscribe
            Dim emailTo As String = sEmail
            Dim emailCc As String = String.Empty
            Dim emailBcc As String = "unsubscribe@astorwines.com"
            Dim emailPriority As MailPriority = MailPriority.High
            Dim emailFormat As MailFormat = MailFormat.Text
            Dim emailAttachment As String = String.Empty
            Dim emailSubj As String = "Astor Wines & Spirits Email List UnSubscribe"
            Dim emailBody As String

            emailBody = "NOTE:  DO NOT REPLY TO THIS EMAIL.  It is generated from an automated system and won't get to us!" & vbCrLf & vbCrLf


            emailBody = emailBody & "You have just unsubscribed from Astors Email List." & vbCrLf & vbCrLf & _
            "The email that was unsubscribed is: " & sEmail & vbCrLf & vbCrLf & _
            "If you decide you would like to join up again, you may do so through www.astorwines.com." & vbCrLf & vbCrLf & _
            "It was a pleasure to serve you," & vbCrLf & _
            "Astor Wines & Spirits" & vbCrLf & vbCrLf & _
            "If you have any questions about this email please email us at customer-service1@astorwines.com or call us at (212) 674-7500." & vbCrLf & vbCrLf & _
            "---------------------------------------" & vbCrLf & vbCrLf


            Dim email As New cEmail
            Dim sError As String = String.Empty
            Try
                email.UserID = emailUserID
                email.Password = emailPassword
                email.SendEmailSSL(emailServer, emailFrom, emailTo, emailCc, emailBcc, emailPriority, emailFormat, emailSubj, emailBody, emailAttachment, sError, 465)
                If sError <> String.Empty Then
                    Throw New System.Exception(sError)
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub
    End Class

End Namespace


