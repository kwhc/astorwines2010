Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Text.RegularExpressions


	Public Class TestCondition

		Private Sub New()
		End Sub
		Public Shared Sub IsTrue(ByVal condition As Boolean, ByVal failMessage As String)
			If (Not condition) Then
				AssertFailed(failMessage)
			End If

		End Sub

		Public Shared Sub IsNotNull(ByVal o As Object, ByVal failMessage As String)
			If o Is Nothing Then
				AssertFailed(failMessage)
			End If

		End Sub
		Public Shared Sub IsNotEmptyString(ByVal s As String, ByVal failMessage As String)
			If s = String.Empty Then
				AssertFailed(failMessage)
			End If

		End Sub
		Public Shared Sub IsNotNullOrEmptyString(ByVal s As String, ByVal failMessage As String)
			If (Not String.IsNullOrEmpty(s)) Then
				AssertFailed(failMessage)
			End If

		End Sub
		Public Shared Sub IsGreaterThanZero(ByVal i As Integer, ByVal failMessage As String)

			If i <= 0 Then
				AssertFailed(failMessage)
			End If
		End Sub
		Public Shared Sub IsGreaterThanZero(ByVal i As Decimal, ByVal failMessage As String)

			If i <= 0 Then
				AssertFailed(failMessage)
			End If
		End Sub
		' Function to test for Positive Integers.
		Public Shared Sub IsNaturalNumber(ByVal strNumber As String, ByVal failMessage As String)
			Dim regNotNaturalPattern As Regex = New Regex("[^0-9]")
			Dim regNaturalPattern As Regex = New Regex("0*[1-9][0-9]*")

			If (Not regNotNaturalPattern.IsMatch(strNumber)) AndAlso regNaturalPattern.IsMatch(strNumber) Then
				AssertFailed(failMessage)

			End If
		End Sub

		' Function to test for Positive Integers with zero inclusive

		Public Shared Sub IsWholeNumber(ByVal strNumber As String, ByVal failMessage As String)
			Dim regNotWholePattern As Regex = New Regex("[^0-9]")

			If regNotWholePattern.IsMatch(strNumber) Then
				AssertFailed(failMessage)
			End If
		End Sub

		' Function to Test for Integers both Positive & Negative

		Public Shared Sub IsInteger(ByVal strNumber As String, ByVal failMessage As String)
			Dim regNotIntPattern As Regex = New Regex("[^0-9-]")
			Dim regIntPattern As Regex = New Regex("^-[0-9]+$|^[0-9]+$")

			If regNotIntPattern.IsMatch(strNumber) AndAlso regIntPattern.IsMatch(strNumber) Then
				AssertFailed(failMessage)
			End If
		End Sub

		' Function to test whether the string is valid number or not
		Public Shared Sub IsNumber(ByVal strNumber As String, ByVal failMessage As String)
			Dim regNotNumberPattern As Regex = New Regex("[^0-9.-]")
			Dim regTwoDotPattern As Regex = New Regex("[0-9]*[.][0-9]*[.][0-9]*")
			Dim regTwoMinusPattern As Regex = New Regex("[0-9]*[-][0-9]*[-][0-9]*")
			Dim strValidRealPattern As String = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$"
			Dim strValidIntegerPattern As String = "^([-]|[0-9])[0-9]*$"
			Dim regNumberPattern As Regex = New Regex("(" & strValidRealPattern & ")|(" & strValidIntegerPattern & ")")

			If regNotNumberPattern.IsMatch(strNumber) AndAlso (Not regTwoDotPattern.IsMatch(strNumber)) AndAlso (Not regTwoMinusPattern.IsMatch(strNumber)) AndAlso regNumberPattern.IsMatch(strNumber) Then
				AssertFailed(failMessage)
			End If
		End Sub

		' Function To test for Alphabets.

		Public Shared Sub IsAlpha(ByVal strToCheck As String, ByVal failMessage As String)
			Dim regAlphaPattern As Regex = New Regex("[^a-zA-Z]")

			If regAlphaPattern.IsMatch(strToCheck) Then
				AssertFailed(failMessage)

			End If
		End Sub

		Public Shared Sub IsValidEmail(ByVal email As String, ByVal failMessage As String)
			Dim emailPattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
			Dim regEmailPattern As Regex = New Regex(emailPattern)
			If regEmailPattern.IsMatch(email) Then
				AssertFailed(failMessage)

			End If

		End Sub
		' Function to Check for AlphaNumeric.

		Public Shared Sub IsAlphaNumeric(ByVal strToCheck As String, ByVal failMessage As String)
			Dim regAlphaNumericPattern As Regex = New Regex("[^a-zA-Z0-9]")

			If regAlphaNumericPattern.IsMatch(strToCheck) Then
				AssertFailed(failMessage)

			End If
		End Sub

		Private Shared Sub AssertFailed(ByVal message As String)
			Throw New Exception(message)
		End Sub
	End Class
