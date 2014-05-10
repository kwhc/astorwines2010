<%@ Application Language="VB" %>

<script runat="server">
   
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        WebCommon.WebAppConfig.Init()
        Application.Add("MailServer", "secure.emailsrvr.com")
        Application.Add("MailUserIDOrders", "orders@astorwines.com")
        Application.Add("MailPasswordOrders", "astor399")
        Application.Add("MailUserIDAccounts", "accounts@astorwines.com")
        Application.Add("MailPasswordAccounts", "astor399")
        Application.Add("MailUserIDSubscribe", "subscribe@astorwines.com")
        Application.Add("MailPasswordSubscribe", "astor399")
        Application.Add("MailUserIDUnSubscribe", "unsubscribe@astorwines.com")
        Application.Add("MailPasswordUnSubscribe", "astor399")
        Application.Add("CLIENT_KEY", "CA713207-9CF5-49F0-A9DE-5B7169E61602")
        Application.Add("MERCHANT_ID", "47030")
        Application.Add("LOCATION_ID", "286235")
        Application.Add("TERMINAL_ID", "139790")
        Application.Add("CCSALT", "ff98dd76-f685-47f8-fcfc-f2d9eb925e95")
        GetCodeTables()
        GetShipToStates()
        GetTaxRate()
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
        'Session.Timeout = 1
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
    
    Private Sub GetCodeTables()
        Dim sCN As String = WebCommon.WebAppConfig.ConnectString
        Dim _odata As New AstorDataClass.cAstorWebData(sCN)
        Dim dsLocal As System.Data.DataSet

        Try


            dsLocal = _odata.GetCodeTablesWeb

            Application("Country") = dsLocal.Tables(_odata.CountryWebIndex)
            Application("Region") = dsLocal.Tables(_odata.RegionWebIndex)
            Application("Area") = dsLocal.Tables(_odata.AreaWebIndex)
            Application("Vineyard") = dsLocal.Tables(_odata.VineyardIndex)
            Application("Color") = dsLocal.Tables(_odata.ColorWebIndex)
            Application("Style") = dsLocal.Tables(_odata.StyleWebIndex)
            Application("Dryness") = dsLocal.Tables(_odata.DrynessWebIndex)
            Application("Type") = dsLocal.Tables(_odata.TypeWebIndex)
            Application("Size") = dsLocal.Tables(_odata.SizeWebIndex)
            Application("Grape") = dsLocal.Tables(_odata.GrapeWebIndex)
            Application("PriceRange") = dsLocal.Tables(_odata.PriceRangeWebIndex)
            Application("Vintage") = dsLocal.Tables(_odata.VintageWebIndex)
            Application("Discriminator") = dsLocal.Tables(_odata.DiscriminatorWebIndex)
            Application("CountryCd") = dsLocal.Tables(_odata.CountryCDWebIndex)
            Application("StateCd") = dsLocal.Tables(_odata.StateCDWebIndex)
            Application("CityCd") = dsLocal.Tables(_odata.CityCDWebIndex)
            Application("SakeDiscriminator") = dsLocal.Tables(_odata.SakeDiscriminatorCDWebIndex)
            Application("TypeCodes") = dsLocal.Tables(_odata.TypeCodesCDWebIndex)
            Application("CreditCardType") = dsLocal.Tables(_odata.CreditCardTypeWebIndex)
            Application("SalutationCd") = dsLocal.Tables(_odata.SalutationWebIndex)
            Application("CCDateMM") = dsLocal.Tables(_odata.CCDateMMWebIndex)
            Application("CCDateYYYY") = dsLocal.Tables(_odata.CCDateYYYYWebIndex)
            Application("ShipType") = dsLocal.Tables(_odata.ShipTypeWebIndex)
            Application("WineTypeStyle") = dsLocal.Tables(_odata.WineTypeStyleWebIndex)
            Application("GiftType") = dsLocal.Tables(_odata.GiftTypeWebIndex)
            Application("StateCdShipTo") = dsLocal.Tables(_odata.StateCDShipToWebIndex)
            Application("Producer") = dsLocal.Tables(_odata.ProducerWebIndex)
            Application("PMCourier") = dsLocal.Tables(_odata.PMCourierWebIndex)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GetTaxRate()
        Dim sCN As String = WebCommon.WebAppConfig.ConnectString
        Dim _odata As New AstorDataClass.cAstorWebData(sCN)
        Dim dTaxRate As Double

        Try


            dTaxRate = _odata.GetDefaultTaxRate

            Application("DefaultTaxRate") = dTaxRate


        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetShipToStates()
        Dim sCN As String = WebCommon.WebAppConfig.ConnectString
        Dim _odata As New AstorDataClass.cAstorWebData(sCN)
        Application("ShipToStatesDesc") = _odata.GetShipToStatesDesc()
        Application("ShipToStatesCodes") = _odata.GetShipToStatesCodes()
        Application("NotShipToStatesDesc") = _odata.GetNotShipToStatesDesc()
    End Sub

</script>