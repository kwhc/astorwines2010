
Partial Class Ucontrols_hub_wine
    Inherits System.Web.UI.UserControl

    Private _type As String

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case type
            Case "wine"
            Case "sake"
            Case "spirits"
        End Select
    End Sub
End Class
