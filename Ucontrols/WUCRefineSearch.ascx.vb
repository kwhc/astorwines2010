Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
Partial Class Ucontrols_WUCRefineSearch
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim dsn As String = WebAppConfig.ConnectString
            Dim _oAstorCommon As New cAstorCommon
            Dim _odata As New cAstorWebData(dsn)
            Dim _oWebCommon As New WebPageBase
            'Dim dsLocal As DataSet
            Dim hstQuery As New Hashtable
            Dim mstrPageName As String = String.Empty
            mstrPageName = Replace(Page.ToString.ToLower, "_aspx", ".aspx")

            'If Not Session("SearchParms") Is Nothing Then
            hstQuery = _oAstorCommon.ProcessQueryStrings(Request.QueryString)

            Session("SearchParms") = hstQuery
            'hstQuery = Session("SearchParms")
            'If Session("DSMulti") Is Nothing Then
            Session("DSMulti") = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))
            'End If
            BindResultDataList()
            SetRemoveButtons()
            'End If
        End If

    End Sub
    Private Sub BindResultDataList()
        Try

            Dim oDS As New DataSet

            If Not Session("DSMulti") Is Nothing Then


                oDS = Session("DSMulti")

                datPrice.DataSource = oDS.Tables(2)
                datPrice.DataBind()
                datCountry.DataSource = oDS.Tables(3)
                datCountry.DataBind()
                datRegion.DataSource = oDS.Tables(4)
                datRegion.DataBind()
                datVarietal.DataSource = oDS.Tables(5)
                datVarietal.DataBind()

           
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetRemoveButtons()
        If Request.QueryString("pricerange") Is Nothing Then
            phRemovePrice.Visible = False
        Else
            phRemovePrice.Visible = True
        End If
        If Request.QueryString("country") Is Nothing Then
            phRemoveCountry.Visible = False
        Else
            phRemoveCountry.Visible = True
        End If
        If Request.QueryString("region") Is Nothing Then
            phRemoveRegion.Visible = False
        Else
            phRemoveRegion.Visible = True
        End If
        If Request.QueryString("grape") Is Nothing Then
            phRemoveVarietal.Visible = False
        Else
            phRemoveVarietal.Visible = True
        End If
    End Sub
    Protected Sub Search(ByVal SrchType As String, ByVal SrchValue As String)
        Dim mstrPageName As String = String.Empty
        Dim hstQuery As New Hashtable
        Dim _oAstorCommon As New cAstorCommon
        mstrPageName = Replace(Page.ToString.ToLower, "_aspx", ".aspx")
        mstrPageName = Replace(mstrPageName, "asp.", "")
        'Select Case mstrPageName
        '    Case "asp.searchresult.aspx"
        '        mstrPageName = "searchresults.aspx"
        '    Case "asp.winesearchresult.aspx"
        '        mstrPageName = "winesearchresult.aspx"

        'End Select

        hstQuery = _oAstorCommon.ProcessQueryStrings(Request.QueryString)
        Session("SearchParms") = hstQuery

        If Not Session("SearchParms") Is Nothing Then

            hstQuery = Session("SearchParms")

            Dim dsn As String = WebAppConfig.ConnectString
            Dim _odata As New cAstorWebData(dsn)
            Dim _oWebCommon As New WebPageBase
            Dim dsLocal As DataSet
            'Dim sItemUPCLookup_value As String = String.Empty
            'Dim sNameLookup_value As String = String.Empty
            'Dim bAllwords As Boolean = False
            'Dim sWord1 As String = String.Empty
            'Dim sWord2 As String = String.Empty
            'Dim sWord3 As String = String.Empty
            'Dim sWord4 As String = String.Empty
            'Dim sWord5 As String = String.Empty
            Dim sCountry As String = String.Empty
            Dim sRegion As String = String.Empty
            'Dim sSubRegion As String = String.Empty
            'Dim sVineyard As String = String.Empty
            Dim sGrape As String = String.Empty
            'Dim sColor As String = String.Empty
            'Dim sSize As String = String.Empty
            'Dim sVintageLow As String = String.Empty
            'Dim sVintageHigh As String = String.Empty
            Dim iPriceRange As Int16 = 0
            'Dim sDryness As String = String.Empty
            'Dim sType As String = String.Empty
            'Dim sStyle As String = String.Empty
            'Dim sDiscriminator As String = String.Empty
            'Dim bKosher As Boolean = False
            'Dim bOrganicall As Boolean = False
            'Dim iLevel1Type As Int16 = 0
            'Dim bSaleItemsOnly As Boolean = False
            'Dim bCoolRoom As Boolean = False
            'Dim bDessert As Boolean = False
            'Dim bGrowerProduce As Boolean = False
            'Dim bJugWall As Boolean = False
            'Dim bSparkling As Boolean = False
            'Dim bVermouth As Boolean = False
            'Dim bLiquorGiftSet As Boolean = False
            'Dim bWineGiftSet As Boolean = False
            'Dim iPolishingGrade As Int16 = 0
            'Dim dPriceLow As Decimal = 0
            'Dim dPriceHigh As Decimal = 0
            'Dim iQty As Int16 = 1
            'Dim iLiquorLevel1Type As Int16 = 0
            'Dim iLiquorLevel2Type As Int16 = 0
            'Dim iLiquorLevel3Type As Int16 = 0
            'Dim sQuickSearch As String = String.Empty
            'Dim sFortified As String = String.Empty
            'Dim bFortifiedAll As Boolean = False
            'Dim sSakeDiscriminator As String = String.Empty
            'Dim sSakeDiscriminatorSave As String = String.Empty
            'Dim sBA As String = String.Empty
            ''Dim queryParam As String()

            With hstQuery
                If SrchType = "price" Then
                    iPriceRange = Convert.ToInt16(SrchValue)
                    .Item("PriceRange") = iPriceRange
                End If
                If SrchType = "removeprice" Then
                    iPriceRange = 0
                    .Item("PriceRange") = iPriceRange
                End If
                If SrchType = "country" Then
                    sCountry = SrchValue.ToString
                    .Item("Country") = sCountry

                End If
                If SrchType = "removecountry" Then
                    .Item("Country") = String.Empty
                    .Item("Region") = String.Empty
                    .Item("SubRegion") = String.Empty
                End If
                If SrchType = "region" Then
                    Dim asRegion() As String
                    asRegion = Split(SrchValue.ToString, ", ")
                    .Item("Country") = asRegion(1)
                    .Item("Region") = asRegion(0)
                End If
                If SrchType = "removeregion" Then
                    .Item("Region") = String.Empty
                    .Item("SubRegion") = String.Empty
                End If
                If SrchType = "varietal" Then
                    sGrape = SrchValue.ToString
                    .Item("Grape") = sGrape
                End If
                If SrchType = "removevarietal" Then
                    .Item("Grape") = String.Empty
                End If
            End With

            Dim sbSearchQuery As New StringBuilder
            sbSearchQuery = _oAstorCommon.SetQueryStrings(hstQuery)

            dsLocal = _odata.FindAdvanced(hstQuery, _oWebCommon.GetCustomerID(Request, Response))

            If dsLocal.Tables(0).Rows.Count = 0 Then
                Session("SearchParms") = hstQuery
                'Redirect("./SearchNoResults.aspx?term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
                Response.Redirect("~/SearchNoResults.aspx?sr=0" & sbSearchQuery.ToString)
            ElseIf dsLocal.Tables(0).Rows.Count = 1 Then
                Session("DSSingle") = dsLocal
                Session("SearchParms") = hstQuery
                Session("ItemName") = dsLocal.Tables(0).Rows(0).Item("name").ToString
                Dim sSearchString As String = dsLocal.Tables(0).Rows(0).Item("item").ToString
                'Redirect("SearchResultsSingle.aspx?p=1&search=" + sSearchString + "&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
                Response.Redirect("~/SearchResultsSingle.aspx?p=1&search=" + sSearchString + "&searchtype=Contains")

            Else
                Session("DSMulti") = dsLocal
                Session("SearchParms") = hstQuery
                'Redirect("./SearchResult.aspx?p=1&search=Advanced&searchtype=Contains&term=" & termQueryString, RedirectOptions.AbsoluteHttp)  https_transfer_6/18/08
                Response.Redirect("~/" & mstrPageName & "?search=Advanced&searchtype=Contains" & sbSearchQuery.ToString)
            End If
        End If
    End Sub

    Protected Sub datPrice_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datPrice.ItemCommand
        If e.CommandName = "price" Then
            ' set the hash table price element to new value
            Search("price", e.CommandArgument.ToString)
        End If
    End Sub

    Protected Sub datPrice_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datPrice.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row


            CType(e.Item.FindControl("lnkbPrice"), LinkButton).CommandArgument = myRow("iOrder").ToString()
            'CType(e.Item.FindControl("lnkbPrice"), LinkButton).Text = myRow("sPriceRangeDesc").ToString()
            CType(e.Item.FindControl("lblPriceAmount"), Label).Text = "(" & myRow("Count").ToString() & ")"
        End If

    End Sub

    Protected Sub datCountry_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datCountry.ItemCommand
        If e.CommandName = "country" Then
            ' set the hash table price element to new value
            Search("country", e.CommandArgument.ToString)
        End If
    End Sub
    Protected Sub datCountry_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datCountry.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row


            CType(e.Item.FindControl("lnkbCountry"), LinkButton).CommandArgument = myRow("scountry").ToString()
            CType(e.Item.FindControl("lblCountryNameCount"), Label).Text = "(" & myRow("Count").ToString() & ")"
        End If

    End Sub

    Protected Sub datRegion_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datRegion.ItemCommand
        If e.CommandName = "region" Then
            ' set the hash table price element to new value
            Search("region", e.CommandArgument.ToString)
        End If
    End Sub

    Protected Sub datRegion_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datRegion.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row


            CType(e.Item.FindControl("lnkbRegion"), LinkButton).CommandArgument = myRow("sregion").ToString()
            CType(e.Item.FindControl("lblRegionNameCount"), Label).Text = "(" & myRow("Count").ToString() & ")"
        End If
    End Sub

    Protected Sub datVarietal_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles datVarietal.ItemCommand
        If e.CommandName = "varietal" Then
            ' set the hash table price element to new value
            Search("varietal", e.CommandArgument.ToString)
        End If
    End Sub

    Protected Sub datVarietal_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles datVarietal.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim myRowView As DataRowView
            Dim myRow As DataRow

            myRowView = e.Item.DataItem
            myRow = myRowView.Row


            CType(e.Item.FindControl("lnkbVarietal"), LinkButton).CommandArgument = myRow("svarietal").ToString()
            CType(e.Item.FindControl("lblVarietalCount"), Label).Text = "(" & myRow("Count").ToString() & ")"
        End If
    End Sub

    Protected Sub imgbRemovePrice_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbRemovePrice.Click
        Search("removeprice", String.Empty)
    End Sub

    Protected Sub imgbRemoveCountry_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbRemoveCountry.Click
        Search("removecountry", String.Empty)
    End Sub

    Protected Sub imgbRemoveRegion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbRemoveRegion.Click
        Search("removeregion", String.Empty)
    End Sub

    Protected Sub imgbVarietal_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbVarietal.Click
        Search("removevarietal", String.Empty)
    End Sub
End Class
