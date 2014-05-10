Imports Microsoft.VisualBasic
Public Class borderlessImageButton

    Inherits System.Web.UI.WebControls.ImageButton
    Public Overrides Property BorderWidth() As System.Web.UI.WebControls.Unit

        Get

            If MyBase.BorderWidth.IsEmpty Then

                Return Unit.Pixel(0)

            Else

                Return MyBase.BorderWidth

            End If

        End Get
        Set(ByVal value As System.Web.UI.WebControls.Unit)

            MyBase.BorderWidth = value

        End Set

    End Property

End Class