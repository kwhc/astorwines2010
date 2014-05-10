Imports System.Collections.Specialized
Imports System.Web.Security
Imports WebCommon
Imports AstorDataClass
Imports System.Data
Imports System.IO
'Imports SslTools
Partial Class Ucontrols_WUCShoppingCart
    Inherits System.Web.UI.UserControl
    Public fTotal As Decimal = 0.0
    Public AOSType As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        updateSignInOutMessage()

        If Not Page.IsPostBack Then

            AOSType = "no"

            PopulateShoppingCartList()
            updateSignInOutMessage()
            'UpdateSelectedItemStatus()

        End If
    End Sub

    Public Sub SignInOut(ByVal sender As Object, ByVal e As EventArgs)
        Dim mstrPageName As String = String.Empty
        mstrPageName = Page.AppRelativeVirtualPath '"~/" & Page.ToString
        If Len(Page.ClientQueryString.ToString) > 0 Then
            mstrPageName &= "?" & Page.ClientQueryString.ToString
        End If
        mstrPageName = Replace(mstrPageName, "ASP.", "")
        mstrPageName = Replace(mstrPageName, "_aspx", ".aspx")


        If Context.User.Identity.IsAuthenticated Then
            Dim _oWebCommon As New WebPageBase
            Dim _odata As New cAstorWebData(_oWebCommon.getConnStr())
            Dim cart As New AstorwinesCommerce.CartDB(_oWebCommon.getConnStr())

            'cart.ResetShoppingCart(_oWebCommon.GetCustomerID(Request, Response))
            FormsAuthentication.SignOut()
            'Redirect("~/Default.aspx", RedirectOptions.AbsoluteHttp) https_transfer_6/18/08
            Response.Redirect("~/Default.aspx")
        Else
            Session("ReturnUrl") = mstrPageName
            'Redirect("~/secure/AstorSignIn.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
            Response.Redirect("~/secure/AstorSignIn.aspx")
        End If
    End Sub

    Sub PopulateShoppingCartList()
        Dim _oWebCommon As New WebPageBase
        Dim _odata As New cAstorWebData(_oWebCommon.getConnStr())
        ' Popoulate list with updated shopping cart data
        Dim cart As New AstorwinesCommerce.CartDB(_oWebCommon.getConnStr())
        Dim ds As DataSet = cart.GetShoppingCartItems(_oWebCommon.GetCustomerID(Request, Response), AOSType)


        'datShoppingCart.DataSource = ds
        'datShoppingCart.DataBind()

        ' Walk through table and calculate the total value
        Dim dt As DataTable = ds.Tables(0)
        Dim lIndex, Quantity As Integer
        Dim UnitPrice As Double

        For lIndex = 0 To dt.Rows.Count - 1
            UnitPrice = dt.Rows(lIndex)("UnitPrice")
            Quantity = dt.Rows(lIndex)("Quantity")
            If Quantity > 0 Then
                fTotal += UnitPrice * Quantity
            End If
        Next
        lblNumItems.Text = dt.Rows.Count
        lblCartSubTotal.Text = "$" & Format(fTotal, "##,##0.00")
    End Sub

    Sub UpdateSelectedItemStatus()

        ''If MyList.Items <> "" Then
        'If datShoppingCart.Items.Count <> 0 Then
        '    status.Text = "You have selected " & datShoppingCart.Items.Count & " items " & "so far:<br>"
        'Else
        '    status.Text = "You have selected no items so far"
        'End If
    End Sub

    Protected Sub imgbShoppingCart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles imgbShoppingCart.Click
        Dim strUrl As String = Request.AppRelativeCurrentExecutionFilePath.ToString
        If Request.QueryString.ToString <> "" Then
            strUrl = strUrl & "?" & Request.QueryString.ToString
        End If
        Session("ReturnUrl") = strUrl
        'Redirect("~/ShoppingCart.aspx", RedirectOptions.AbsoluteHttp)  https_transfer_6/18/08
        Response.Redirect("~/ShoppingCart.aspx")
    End Sub
    Protected Sub imgbSavedShoppingCart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles imgbSavedShoppingCart.Click
        Dim strUrl As String = Request.AppRelativeCurrentExecutionFilePath.ToString
        If Request.QueryString.ToString <> "" Then
            strUrl = strUrl & "?" & Request.QueryString.ToString
        End If
        Session("ReturnUrl") = strUrl
        Response.Redirect("~/ShoppingCartSaved.aspx")
    End Sub
    Protected Sub lnkbSignInNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbSignInNow.Click
        'Redirect("~/secure/AstorSignIn.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
        Response.Redirect("~/secure/AstorSignIn.aspx")
    End Sub

    Public Sub CreateAccount(ByVal sender As Object, ByVal e As EventArgs) Handles lnkbCreateAccount.Click
        Dim mstrPageName As String = String.Empty
        mstrPageName = Page.AppRelativeVirtualPath '"~/" & Page.ToString
        If Len(Page.ClientQueryString.ToString) > 0 Then
            mstrPageName &= "?" & Page.ClientQueryString.ToString
        End If
        mstrPageName = Replace(mstrPageName, "ASP.", "")
        mstrPageName = Replace(mstrPageName, "_aspx", ".aspx")


        If Context.User.Identity.Name <> "" Then
            Dim _oWebCommon As New WebPageBase
            Dim _odata As New cAstorWebData(_oWebCommon.getConnStr())
            Dim cart As New AstorwinesCommerce.CartDB(_oWebCommon.getConnStr())
            'cart.ResetShoppingCart(_oWebCommon.GetCustomerID(Request, Response))
            FormsAuthentication.SignOut()
            Session("ReturnUrl") = mstrPageName
            'Redirect("~/secure/AstorSignIn.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
            Response.Redirect("~/secure/AstorSignIn.aspx")
        Else
            Session("ReturnUrl") = mstrPageName
            'Redirect("~/secure/AstorSignIn.aspx", RedirectOptions.AbsoluteHttps) https_transfer_6/18/08
            Response.Redirect("~/secure/AstorSignIn.aspx")
        End If
    End Sub

    '    Private Sub updateSignInOutMessage()

    '        If Context.User.Identity.Name <> "" Then
    '           pnlSignIn.Visible = False
    '      Else
    '         pnlSignIn.Visible = True
    '    End If

    '    End Sub

    Private Sub updateSignInOutMessage()
        'If Context.User.Identity.Name <> "" Then
        If Context.User.Identity.IsAuthenticated Then
            signInOutMsg1.Text = "<span>Hello " & Context.User.Identity.Name & "</span>"

            signInOutMsg.Text = "sign out"

            CustMsg1.Text = "&nbsp;"
            lnkbCreateAccount.Text = " register"
        Else
            signInOutMsg1.Text = "&nbsp;"
            signInOutMsg.Text = "sign in"

            'CustMsg1.Text = "New customer?"
            lnkbCreateAccount.Text = "sign up"
        End If
        SetSavedShoppingCartButton()
    End Sub
    Private Sub SetSavedShoppingCartButton()
        If Context.User.Identity.IsAuthenticated Then
            Dim _oWebCommon As New WebPageBase
            Dim _odata As New cAstorWebData(_oWebCommon.getConnStr())
            Dim cart As New AstorwinesCommerce.CartDB(_oWebCommon.getConnStr())
            If cart.CheckCartForPreviousItems(_oWebCommon.GetCustomerID(Request, Response)) = True Then
                phSavedShoppingCart.Visible = True
            Else
                phSavedShoppingCart.Visible = False
            End If
        Else
            phSavedShoppingCart.Visible = False
        End If

    End Sub
    Protected Sub lnkMyAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMyAccount.Click
        Response.Redirect("~/secure/MyAccountSummary.aspx")
    End Sub

End Class
