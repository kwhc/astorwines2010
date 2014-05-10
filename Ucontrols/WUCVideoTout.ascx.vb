
Partial Class Ucontrols_WUCVideoTout
    Inherits System.Web.UI.UserControl
    Private _VideoID As String = String.Empty
    Private _VideoHeight As String = String.Empty
    Private _VideoWidth As String = String.Empty
    Public WriteOnly Property VideoID() As String
        
        Set(ByVal value As String)
            _VideoID = value

        End Set
    End Property
    Public WriteOnly Property VideoHeight() As String

        Set(ByVal value As String)
            _VideoHeight = value

        End Set
    End Property
    Public WriteOnly Property VideoWidth() As String

        Set(ByVal value As String)
            _VideoWidth = value

        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If _VideoID <> "" Then
            VimeoScript()
        End If
    End Sub

    Private Sub VimeoScript()
        ' Define the name, type of the client script on the page.
        Dim csname As String = "VimeoScript"
        Dim cstype As Type = Me.GetType()

        ' Get a ClientScriptManager reference from the Page class.
        Dim cs As ClientScriptManager = Page.ClientScript
        Dim sb As StringBuilder = New StringBuilder()
        Dim _cAstorCommon As New cAstorCommon

        sb = _cAstorCommon.VimeoScript(_VideoID, _VideoHeight, _VideoWidth)

        ' Check to see if the include script is already registered.
        If (Not cs.IsClientScriptIncludeRegistered(cstype, csname)) Then

            cs.RegisterClientScriptBlock(cstype, csname, sb.ToString)


        End If

    End Sub
End Class
