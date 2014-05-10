Imports WebCommon
Imports System.Data
Partial Class secure_AstorCheckoutShoppingCart
    Inherits WebPageBase
    ' Total for shopping basket
    Public fTotal As Double = 0
    Public fSubTotal As Double = 0
    Public fSubTotalTax As Double = 0
    Public fTax As Double = 0
    Public fShipping As Double = 0
    Public fPromo As Double = 0

    Private Cart As New AstorwinesCommerce.CartDB(getConnStr())
    Private Cust As New AstorwinesCommerce.Customer(getConnStr())
    Private dsShoppingCart As DataSet
    Private dsShoppingCartAOS As DataSet
    Private dsn As String = WebAppConfig.ConnectString

    Private dTaxRate As Decimal = 0.0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' If page is not being loaded in response to postback
        If Not Page.IsPostBack Then
            Try

                If Not Session("ReturnUrl") Is Nothing Then
                    ReturnUrl.Value = Session("ReturnUrl")
                    Session("ReturnUrl") = Nothing

                Else
                    ReturnUrl.Value = "~/default.aspx"
                End If
                hyplReturnToShopping.NavigateUrl = ReturnUrl.Value

                dsShoppingCart = Cart.GetShoppingCartItems(GetCustomerID(Request, Response), "co")

                dsShoppingCartAOS = Cart.GetShoppingCartAOSItems(GetCustomerID(Request, Response))
                If dsShoppingCartAOS.Tables.Count > 0 Then
                    If dsShoppingCartAOS.Tables(0).Rows.Count > 0 Then


                        If dsShoppingCart.Tables.Count > 0 Then
                            If dsShoppingCart.Tables(0).Rows.Count > 0 Then
                                PopulateShoppingCartList()
                                'CalcTotals()

                                'lblLTax.Text = "Tax (" & (dTaxRate * 100).ToString & "%):"
                            Else
                                ' show page anyway to show out of stock since present
                                ' but disallow continue button

                                PopulateShoppingCartList()
                                CalcTotals()
                                imgbCheckOut.Visible = False
                            End If
                        Else

                            Response.Redirect("~/AstorError.aspx?errorpage=" & Page.Request.Url.PathAndQuery)
                        End If
                    Else

                        If Cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then

                            If Not IsNothing(Request.QueryString("remote")) = True Then
                                Response.Redirect("~/secure/AstorCheckoutBilling.aspx?remote=true")
                            Else
                                Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
                            End If


                        Else

                            If Not IsNothing(Request.QueryString("remote")) = True Then
                                Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx?remote=true")
                            Else
                                Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")

                            End If

                        End If

                    End If


                Else
                    If Cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then

                        If Not IsNothing(Request.QueryString("remote")) = True Then
                            Response.Redirect("~/secure/AstorCheckoutBilling.aspx?remote=true")
                        Else
                            Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
                        End If


                    Else

                        If Not IsNothing(Request.QueryString("remote")) = True Then
                            Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx?remote=true")
                        Else
                            Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")

                        End If

                    End If
                End If

            Catch ex As Exception
                Throw
            Finally

            End Try
        End If

    End Sub
   
    Private Sub PopulateShoppingCartList()


        datMyList.DataSource = dsShoppingCart
        datMyList.DataBind()

        ' Walk through table and calculate the total value
        Dim dt As DataTable = dsShoppingCart.Tables(0)
        Dim lIndex, Quantity As Integer
        Dim UnitPrice As Double

        For lIndex = 0 To dt.Rows.Count - 1
            UnitPrice = CType(dt.Rows(lIndex)("UnitPrice"), Double)
            Quantity = CType(dt.Rows(lIndex)("Quantity"), Integer)
            If Quantity > 0 Then
                fSubTotal += UnitPrice * Quantity
                If dt.Rows(lIndex)("tax") = "Y" Then
                    fSubTotalTax += UnitPrice * Quantity
                End If
            End If
        Next

    End Sub
    Private Sub CalcTotals()

        fShipping = CalcShipping()
        dTaxRate = GetTaxRate()
        fTax = dTaxRate * ((fSubTotalTax + fPromo) + fShipping)
       
        fTotal = fSubTotal + fTax + fShipping + fPromo
    End Sub
    Private Function CalcShipping() As Decimal
        CalcShipping = Cart.WebCalcShipping(GetCustomerID(Request, Response), String.Empty)
    End Function
    Private Function GetTaxRate() As Decimal
        GetTaxRate = Cart.WebGetTaxRate(GetCustomerID(Request, Response), String.Empty)
    End Function
    Protected Sub imgbCheckOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbCheckOut.Click

        If CheckShoppingCartListHasItems() Then
            If Context.User.Identity.Name <> "" Then
                If cust.CheckCustomerHasBillingInfo(GetCustomerID(Request, Response)) Then

                    If Not IsNothing(Request.QueryString("remote")) = True Then
                        Response.Redirect("~/secure/AstorCheckoutBilling.aspx?remote=true")
                    Else
                        Response.Redirect("~/secure/AstorCheckoutBilling.aspx")
                    End If


                Else

                    If Not IsNothing(Request.QueryString("remote")) = True Then
                        Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx?remote=true")
                    Else
                        Response.Redirect("~/secure/AstorCheckoutBillingNewCustomer.aspx")

                    End If

                End If
            Else

                If Not IsNothing(Request.QueryString("remote")) = True Then
                    Response.Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut & "&remote=true")
                Else
                    Response.Redirect("~/secure/AstorSignin.aspx?si=" & WebAppConfig.SignInReference.CheckOut)
                End If
            End If
        End If
    End Sub
    Private Function CheckShoppingCartListHasItems() As Boolean
        ' 
        Dim iItemsCount As Int16 = cart.ShoppingCartItemsCount(GetCustomerID(Request, Response))

        If iItemsCount > 0 Then
            CheckShoppingCartListHasItems = True
        Else
            CheckShoppingCartListHasItems = False
        End If

    End Function
End Class
