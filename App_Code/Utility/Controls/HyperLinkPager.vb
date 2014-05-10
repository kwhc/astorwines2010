'
' This control has its origins in Pager control that belongs to 
' CS project (www.communityserver.org).
'


Imports Microsoft.VisualBasic
Imports System
Imports System.Text.RegularExpressions
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Web.UI
Imports System.Web
Imports System.Text
Imports System.IO

Namespace Commerce.UI.Controls
	' <summary>
	' Summary description for Pager.
	' </summary>
	Public Class HyperLinkPager
		Inherits Label
		Implements INamingContainer
#Region "Member variables"

		Private previousLink As HyperLink
		Private nextLink As HyperLink
		Private firstLink As HyperLink
		Private lastLink As HyperLink
		Private pagingHyperLinks As HyperLink()

		Public Sub New()
		End Sub

#End Region

#Region "Render functions"

		' <summary>
		' This event handler adds the children controls and is resonsible
		' for determining the template type used for the control.
		' </summary>
		Protected Overrides Sub CreateChildControls()
			'AutoBindForTotalRecordsValue();

			Controls.Clear()

			' Add Page buttons
			'
			AddPageLinks()

			' Add Previous Next child controls
			'
			AddPreviousNextLinks()

			' Add First Last child controls
			'
			AddFirstLastLinks()
		End Sub

		Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)
			Dim totalPages As Integer = CalculateTotalPages()

			' Do we have data?
			'
			If totalPages <= 1 Then
				Return
			End If

			If ShowCurrentPage Then
				RenderCurrentPage(writer)
			End If

			AddAttributesToRender(writer)

			' Render the paging buttons
			'
			writer.AddAttribute(HtmlTextWriterAttribute.Class, Me.CssClass, False)

			' Render the first button
			'
			RenderFirst(writer)

			' Render the previous button
			'
			RenderPrevious(writer)

			' Render the page button(s)
			'
			RenderPagingButtons(writer)

			' Render the next button
			'
			RenderNext(writer)

			' Render the last button
			'
			RenderLast(writer)
		End Sub

		Private Sub RenderCurrentPage(ByVal writer As HtmlTextWriter)
			writer.Write(String.Format(Me.CurrentPageStringFormat, (Me.PageIndex + 1), Me.CalculateTotalPages(), Me.TotalRecords))
		End Sub

		Private Sub RenderFirst(ByVal writer As HtmlTextWriter)
			Dim totalPages As Integer = CalculateTotalPages()

			If (PageIndex >= 3) AndAlso (totalPages > 5) Then
				firstLink.RenderControl(writer)

				Dim l As LiteralControl = New LiteralControl("&nbsp;...&nbsp;")
				l.RenderControl(writer)
			End If
		End Sub

		Private Sub RenderLast(ByVal writer As HtmlTextWriter)
			Dim totalPages As Integer = CalculateTotalPages()

			If ((PageIndex + 3) < totalPages) AndAlso (totalPages > 5) Then
				Dim l As LiteralControl = New LiteralControl("&nbsp;...&nbsp;")
				l.RenderControl(writer)

				lastLink.RenderControl(writer)
			End If
		End Sub

		Private Sub RenderPrevious(ByVal writer As HtmlTextWriter)
			Dim l As Literal

			If HasPrevious Then
				previousLink.RenderControl(writer)

				l = New Literal()
				l.Text = "&nbsp;"
				l.RenderControl(writer)
			End If
		End Sub

		Private Sub RenderNext(ByVal writer As HtmlTextWriter)
			Dim l As Literal

			If HasNext Then

				l = New Literal()
				l.Text = "&nbsp;"
				l.RenderControl(writer)

				nextLink.RenderControl(writer)
			End If
		End Sub

		Private Sub RenderButtonRange(ByVal start As Integer, ByVal [end] As Integer, ByVal writer As HtmlTextWriter)
			Dim i As Integer = start
			Do While i < [end]
				' Are we working with the selected index?
				'
				If PageIndex = i Then
					' Render different output
					'
					Dim l As Literal = New Literal()
					l.Text = "<b>" & (i + 1).ToString() & "</b>"

					l.RenderControl(writer)
				Else
					pagingHyperLinks(i).RenderControl(writer)
				End If
				If i < ([end] - 1) Then
					writer.Write(" ")
				End If
				i += 1
			Loop
		End Sub

		Private Sub RenderPagingButtons(ByVal writer As HtmlTextWriter)
			Dim totalPages As Integer

			' Get the total pages available
			'
			totalPages = CalculateTotalPages()

			' If we have <= 5 pages display all the pages and exit
			'
			If totalPages <= 5 Then
				RenderButtonRange(0, totalPages, writer)
			Else
				Dim lowerBound As Integer = (PageIndex - 2)
				Dim upperBound As Integer = (PageIndex + 3)

				If lowerBound <= 0 Then
					lowerBound = 0
				End If

				If PageIndex = 0 Then
					RenderButtonRange(0, 5, writer)

				ElseIf PageIndex = 1 Then
					RenderButtonRange(0, (PageIndex + 4), writer)

				ElseIf PageIndex < (totalPages - 2) Then
					RenderButtonRange(lowerBound, (PageIndex + 3), writer)

				ElseIf PageIndex = (totalPages - 2) Then
					RenderButtonRange((totalPages - 5), (PageIndex + 2), writer)

				ElseIf PageIndex = (totalPages - 1) Then
					RenderButtonRange((totalPages - 5), (PageIndex + 1), writer)
				End If
			End If
		End Sub

#End Region

#Region "ControlTree functions"

		Private Sub AddPageLinks()
			' First add the lower page buttons
			'
			pagingHyperLinks = New HyperLink(CalculateTotalPages() - 1) {}

			' Create the buttons and add them to 
			' the Controls collection
			'
			Dim i As Integer = 0
			Do While i < pagingHyperLinks.Length
				pagingHyperLinks(i) = New HyperLink()
				pagingHyperLinks(i).EnableViewState = False
				pagingHyperLinks(i).Text = (i + 1).ToString()
				pagingHyperLinks(i).ID = (i + 1).ToString()
				pagingHyperLinks(i).NavigateUrl = CreatePagerURL((i + 1).ToString())
				Controls.Add(pagingHyperLinks(i))
				i += 1
			Loop
		End Sub

		Private Sub AddFirstLastLinks()
			Dim start As Integer = 1
			firstLink = New HyperLink()
			firstLink.ID = "First"
			firstLink.Text = Me.FirstPageText
			firstLink.NavigateUrl = CreatePagerURL(start.ToString())
			Controls.Add(firstLink)

			Dim last As Integer = CalculateTotalPages()
			lastLink = New HyperLink()
			lastLink.ID = "Last"
			lastLink.Text = Me.LastPageText
			lastLink.NavigateUrl = CreatePagerURL(last.ToString())
			Controls.Add(lastLink)
		End Sub

		Private Sub AddPreviousNextLinks()
			Dim previous As Integer

			If Me.PageIndex < 2 Then
				previous = 1
			Else
				previous = Me.PageIndex
			End If

			previousLink = New HyperLink()
			previousLink.ID = "Prev"
			previousLink.Text = Me.PreviousPageText
			previousLink.NavigateUrl = CreatePagerURL(previous.ToString())
			Controls.Add(previousLink)

			Dim [next] As Integer = Me.PageIndex + 2
			nextLink = New HyperLink()
			nextLink.ID = "Next"
			nextLink.Text = Me.NextPageText
			nextLink.NavigateUrl = CreatePagerURL([next].ToString())
			Controls.Add(nextLink)
		End Sub

#End Region

#Region "Properties"

		' <summary>
		' Override how this control handles its controls collection
		' </summary>
		Public Overrides ReadOnly Property Controls() As ControlCollection
			Get
				EnsureChildControls()
				Return MyBase.Controls
			End Get

		End Property

		Private ReadOnly Property HasPrevious() As Boolean
			Get
				If PageIndex > 0 Then
					Return True
				End If

				Return False
			End Get
		End Property

		Private ReadOnly Property HasNext() As Boolean
			Get
				If PageIndex + 1 < CalculateTotalPages() Then
					Return True
				End If

				Return False
			End Get
		End Property

		Private ReadOnly Property IsBoundUsingDataSourceID() As Boolean
			Get
				Return (Me.DataSourceID.Length > 0)
			End Get
		End Property

		Private showCurrentPage_Renamed As Boolean = True
		Public Property ShowCurrentPage() As Boolean
			Get
				Return showCurrentPage_Renamed
			End Get
			Set(ByVal value As Boolean)
				showCurrentPage_Renamed = Value
			End Set
		End Property

		Private currentPageStringFormat_Renamed As String = "Page {0} of {1} ({2} records) &nbsp;-&nbsp; "
		' <summary>
		' CurrentPageStringFormat is the text that should be used to dispaly current page number.
		' It has been provided to allow custom formatting. 
		' There are 2 implicit params that you may use: page index and total pages number.
		' Its implicit format is: "Page {0} of {1} ({2} records) &nbsp;-&nbsp;" and it makes use of both params.
		' </summary>
		Public Property CurrentPageStringFormat() As String
			Get
				Return currentPageStringFormat_Renamed
			End Get
			Set(ByVal value As String)
				currentPageStringFormat_Renamed = Value
			End Set
		End Property

		Private dataSourceID_Renamed As String = String.Empty
		Public Property DataSourceID() As String
			Get
				Dim obj1 As Object = ViewState("DataSourceID")
				If Not obj1 Is Nothing Then
					dataSourceID_Renamed = CStr(obj1)
				End If

				Return dataSourceID_Renamed
			End Get
			Set(ByVal value As String)
				dataSourceID_Renamed = Value

				ViewState("DataSourceID") = dataSourceID_Renamed
			End Set
		End Property

		Private firstPageText_Renamed As String = "&lt;&lt;"
		Public Property FirstPageText() As String
			Get
				Return firstPageText_Renamed
			End Get
			Set(ByVal value As String)
				firstPageText_Renamed = Value
			End Set
		End Property

		Private lastPageText_Renamed As String = "&gt;&gt;"
		Public Property LastPageText() As String
			Get
				Return lastPageText_Renamed
			End Get
			Set(ByVal value As String)
				lastPageText_Renamed = Value
			End Set
		End Property

		Private previousPageText_Renamed As String = "&lt;"
		Public Property PreviousPageText() As String
			Get
				Return previousPageText_Renamed
			End Get
			Set(ByVal value As String)
				previousPageText_Renamed = Value
			End Set
		End Property

		Private nextPageText_Renamed As String = "&gt;"
		Public Property NextPageText() As String
			Get
				Return nextPageText_Renamed
			End Get
			Set(ByVal value As String)
				nextPageText_Renamed = Value
			End Set
		End Property

		Private _pageIndex As Integer = 0
		Public Overridable Property PageIndex() As Integer
			Get
				Dim context As HttpContext = HttpContext.Current

				If Page.IsPostBack AndAlso Not ViewState("PageIndex") Is Nothing Then
					_pageIndex = CInt(Fix(ViewState("PageIndex")))
				Else
					If Not context.Request.QueryString("pageindex") Is Nothing Then
						_pageIndex = Integer.Parse(context.Request.QueryString("pageindex")) - 1
					End If
				End If

				If _pageIndex < 0 Then
					Return 0
				Else
					Return _pageIndex
				End If
			End Get
			Set(ByVal value As Integer)
				ViewState("PageIndex") = Value
				_pageIndex = Value
			End Set
		End Property

		Public Overridable Property PageSize() As Integer
			Get
				'INSTANT VB NOTE: The local variable pageSize was renamed since Visual Basic will not allow local variables with the same name as their method:
				Dim pageSize_Renamed As Integer = Convert.ToInt32(ViewState("PageSize"))

				If pageSize_Renamed = 0 Then
					Return 10
				End If

				Return pageSize_Renamed
			End Get
			Set(ByVal value As Integer)
				ViewState("PageSize") = Value
			End Set

		End Property

		Public Property TotalRecords() As Integer
			Get
				Return Convert.ToInt32(ViewState("TotalRecords"))
			End Get
			Set(ByVal value As Integer)
				ViewState("TotalRecords") = Value
			End Set
		End Property

#End Region

#Region "Helper methodss"

		Protected Overridable Function CreatePagerURL(ByVal pageIndex As String) As String
			Dim context As HttpContext = HttpContext.Current

			If context.Request.Url.AbsoluteUri.IndexOf("?") = -1 Then
				Return context.Request.Url.AbsoluteUri.ToString() & "?PageIndex=" & pageIndex
			Else
				If context.Request.Url.AbsoluteUri.IndexOf("PageIndex=") = -1 Then
					Return context.Request.Url.AbsoluteUri.ToString() & "&PageIndex=" & pageIndex
				Else
					Return Regex.Replace(context.Request.Url.AbsoluteUri.ToString(), "PageIndex=(\d+\.?\d*|\.\d+)", "PageIndex=" & pageIndex)
				End If
			End If
		End Function

		' <summary>
		' Static that caculates the total pages available.
		' </summary>
		' 
		Public Overridable Function CalculateTotalPages() As Integer
			Dim totalPagesAvailable As Integer

			If TotalRecords = 0 Then
				Return 0
			End If

			' First calculate the division
			'
			totalPagesAvailable = TotalRecords / PageSize

			' Now do a mod for any remainder
			'
			If (TotalRecords Mod PageSize) > 0 Then
				totalPagesAvailable += 1
			End If

			Return totalPagesAvailable
		End Function

		'
		'protected void AutoBindForTotalRecordsValue()
		'{
		'if (!IsBoundUsingDataSourceID)
		'return;

		'// Is this bound via ObjectDataSource control?
		'// TODO: a better lookup
		'//
		'ObjectDataSource ods = Page.FindControl(this.DataSourceID) as ObjectDataSource;
		'if (ods == null)
		'{
		'ods = this.Parent.FindControl(this.DataSourceID) as ObjectDataSource;
		'if (ods == null)
		'return;
		'}

		'// Wee need to search for TotalRecords bound parameter in ObjectDataSource
		'//
		'foreach (Parameter p in ods.SelectParameters)
		'{
		'if (p is ControlParameter)
		'{
		'if (((ControlParameter)p).ControlID == this.ID)
		'{
		'if (((ControlParameter)p).PropertyName.ToLower() == "totalrecords")
		'{

		'// I found the appropriate param
		'//ctrl.Selected += new ObjectDataSourceStatusEventHandler(ObjectDataSource_Selected);
		'}
		'}
		'}
		'}
		'}

		'public static void ObjectDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
		'{
		'if (e.OutputParameters["TotalRecords"] != null)
		'{
		'//this.TotalRecords = Convert.ToInt32(e.OutputParameters["TotalRecords"]);
		'}
		'}
		'
#End Region
	End Class
End Namespace
