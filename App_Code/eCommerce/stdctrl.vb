Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Web.UI
Imports System.Web.Security
Imports WebCommon


Namespace AstorwinesCommerce

    Public Class ControlBase
        Inherits UserControl

        Public Function getConnStr() As String

            Dim dsn As String = WebAppConfig.ConnectString

            Return dsn

        End Function

    End Class

End Namespace

