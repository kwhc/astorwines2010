Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace Commerce.UI.Controls
	' <summary>
	' Summary description for ProductRatingDropDownList
	' </summary>
	Public Class ProductRatingDropDownList
		Inherits DropDownList
		Public Sub New()
			Items.Add(New ListItem("-", "0"))
			Items.Add(New ListItem("5 Stars", "5"))
			Items.Add(New ListItem("4 Stars", "4"))
			Items.Add(New ListItem("3 Stars", "3"))
			Items.Add(New ListItem("2 Stars", "2"))
			Items.Add(New ListItem("1 Star", "1"))
		End Sub
	End Class
End Namespace
