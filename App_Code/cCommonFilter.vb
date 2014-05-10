
#Region " Copyleft "
' Copyright (C) 2003, 2004, 2005, 2007, 2008 Clive Chinery
' This library is free software; you can redistribute it and/or
' modify it under the terms of the GNU Lesser General Public
' License as published by the Free Software Foundation; either
' version 2.1 of the License, or (at your option) any later version.
' 
' This library is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
' Lesser General Public License for more details.
' 
' You should have received a copy of the GNU Lesser General Public
' License along with this library; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
#End Region

#Region " Using "
Imports System
Imports System.Globalization
Imports System.Text
Imports System.Text.RegularExpressions
#End Region

Partial Public NotInheritable Class CommonData
#Region " Filter constants "
    ''' <summary>
    ''' Filter Address Line
    ''' </summary>
    Private Const FilterListAddressLine As String = FilterListAlphanumeric & " .,:/\()-=+"

    ''' <summary>
    ''' Alpha (upper and lower) characters
    ''' </summary>
    Private Const FilterListAlpha As String = FilterListLowercase + FilterListUppercase

    ''' <summary>
    ''' Alpha-numeric characters
    ''' </summary>
    Private Const FilterListAlphanumeric As String = FilterListAlpha + FilterListUnsignedInteger

    ''' <summary>
    ''' Numeric plus negative and decimal point
    ''' </summary>
    Private Const FilterListDecimal As String = FilterListUnsignedInteger & "-."

    ''' <summary>
    ''' Lowercase + numeric + period + @
    ''' </summary>
    Private Const FilterListEmailAddress As String = (FilterListLowercase & ".@-") + FilterListUnsignedInteger

    ''' <summary>
    ''' General text characters
    ''' </summary>
    Private Const FilterListGeneralText As String = FilterListAlphanumeric & " .,:/\()-=+" & vbLf

    ''' <summary>
    ''' Guid Input
    ''' </summary>
    Private Const FilterListGuidString As String = FilterListUnsignedInteger & "-ABCDEF"
    ''' <summary>
    ''' Integer characters
    ''' </summary>
    Private Const FilterListInteger As String = FilterListUnsignedInteger & "-"

    ''' <summary>
    ''' IPAddress characters
    ''' </summary>
    Private Const FilterListIPAddress As String = FilterListUnsignedInteger & "."

    ''' <summary>
    ''' Lower case characters
    ''' </summary>
    Private Const FilterListLowercase As String = "abcdefghijklmnopqrstuvwxyz"

    ''' <summary>
    ''' Characters for name (including space)
    ''' </summary>
    Private Const FilterListName As String = FilterListLowercase + FilterListInteger + FilterListUppercase & " -."

    ''' <summary>
    ''' Password characters
    ''' </summary>
    Private Const FilterListPassword As String = FilterListAlpha + FilterListUnsignedInteger + FilterListSpecial

    ''' <summary>
    ''' Characters in post codes
    ''' </summary>
    Private Const FilterListPostCode As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789"

    ''' <summary>
    ''' Special characters
    ''' </summary>
    ''' <remarks>This list is subject to change owing to
    ''' what might or might not be acceptable in a password.</remarks>
    Private Const FilterListSpecial As String = "#~!£$*@=:"

    ''' <summary>
    ''' Telephone characters
    ''' </summary>
    Private Const FilterListTelephone As String = FilterListLowercase + FilterListInteger & " +()"

    ''' <summary>
    ''' Time characters
    ''' </summary>
    Private Const FilterListTime As String = FilterListUnsignedInteger & ":"

    ''' <summary>
    ''' Numeric characters
    ''' </summary>
    Private Const FilterListUnsignedInteger As String = "0123456789"

    ''' <summary>
    ''' Upper Case Characters
    ''' </summary>
    Private Const FilterListUppercase As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    ''' <summary>
    ''' URL characters
    ''' </summary>
    Private Const FilterListUrl As String = FilterListUppercase + FilterListLowercase + FilterListUnsignedInteger & " /:.?&+=-"

    ''' <summary>
    ''' User name characters
    ''' </summary>
    Private Const FilterListUserName As String = FilterListUppercase + FilterListUnsignedInteger
#End Region
#Region " Filter Functions "
#Region " FilterAddressLine "
    ''' <summary>
    ''' Filter address line
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterAddressLine(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input, FilterListAddressLine)
    End Function

    ''' <summary>
    ''' Filter address line
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterAddressLineTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input, FilterListAddressLine, output)
    End Function

    ''' <summary>
    ''' Filter address line and reject box numbers
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid </returns>
    Public Function FilterAddressLineNoBoxTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Dim valid = FilterWorkerTry(input, FilterListAddressLine, output)
        If (output Is Nothing) Then
            output = String.Empty
        End If
        Dim upperInput = output.ToUpperInvariant()
        If upperInput.Contains("BOX NO") Then
            valid = False
        End If
        If upperInput.Contains("BOX NUMBER") Then
            valid = False
        End If
        If upperInput.Contains("POBOX") Then
            valid = False
        End If
        If upperInput.Contains("PO BOX") Then
            valid = False
        End If
        If upperInput.Contains("P O BOX") Then
            valid = False
        End If
        If upperInput.Contains("P O BOX") Then
            valid = False
        End If
        If upperInput.Contains("P.O. BOX") Then
            valid = False
        End If
        If upperInput.Contains("P.O BOX") Then
            valid = False
        End If
        If upperInput.Contains("PO. BOX") Then
            valid = False
        End If
        If upperInput.Contains("BOX NO") Then
            valid = False
        End If
        If upperInput.Contains("POST OFFICE BOX") Then
            valid = False
        End If
        If upperInput.Contains("POST BOX") Then
            valid = False
        End If
        If upperInput.Contains("POST OFFICE") Then
            valid = False
        End If
        If upperInput.Contains("P BOX") Then
            valid = False
        End If
        Return valid
    End Function
#End Region
#Region " FilterAlpha "
    ''' <summary>
    ''' Filter Alpha (upper + lower case) Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterAlpha(ByVal input As String) As String
        Return FilterWorker(input, FilterListAlpha)
    End Function

    ''' <summary>
    ''' Try Filter Alpha (upper + lower case) Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterAlphaTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListAlpha, output)
    End Function
#End Region
#Region " FilterAlphanumeric "
    ''' <summary>
    ''' Filter AlphaNumeric (upper + lower + integer) Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterAlphanumeric(ByVal input As String) As String
        Return FilterWorker(input, FilterListAlphanumeric)
    End Function

    ''' <summary>
    ''' Try Filter AlphaNumeric (upper + lower + integer) Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterAlphanumericTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListAlphanumeric, output)
    End Function
#End Region
#Region " FilterDecimal "
    ''' <summary>
    ''' Filter Decimal Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterDecimal(ByVal input As String) As String
        Return FilterWorker(input, FilterListDecimal)
    End Function

    ''' <summary>
    ''' Filter Decimal Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterDecimalTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListDecimal, output)
    End Function
#End Region
#Region " FilterEmailAddress "
    ''' <summary>
    ''' Filter EmailAddress case
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterEmailAddress(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input.ToLowerInvariant(), FilterListEmailAddress)
    End Function

    ''' <summary>
    ''' Filter EmailAddress case
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterEmailAddressTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input.ToLowerInvariant(), FilterListEmailAddress, output)
    End Function
#End Region
#Region " FilterGeneralText (plus notes on usage) "
    ''' <summary>
    ''' Filter general text
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    ''' <remarks>These filter functions are built upon the premise: "All input is evil".
    ''' These functions filter input to a range of permitted values controlled by
    ''' appropriate constants. By defining the allowed values within string constants
    ''' the allowed values can readily be changed.
    ''' Input is usually from a textbox but could also be an argument from the query string.
    ''' When working with non-English languages the General Text will need to be rewritten
    ''' on an exclude basis.
    ''' The filter functions filter on a permitted values basis - Thus FilterDecimal
    ''' would pass the second decimal point in "1.22.2".
    ''' </remarks>
    Public Shared Function FilterGeneralText(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input, FilterListGeneralText)
    End Function

    ''' <summary>
    ''' Filter general text
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterGeneralTextTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input, FilterListGeneralText, output)
    End Function
#End Region
#Region " FilterGuidString "
    ''' <summary>
    ''' Filter Guid String
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterGuidString(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input.ToUpperInvariant(), FilterListGuidString)
    End Function

    ''' <summary>
    ''' Filter Guid String
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterGuidStringTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input.ToUpperInvariant(), FilterListGuidString, output)
    End Function
#End Region
#Region " FilterHtmlText "
    ''' <summary>
    ''' Filters the HTML markup text.
    ''' </summary>
    ''' <param name="input">The input string.</param>
    ''' <returns>Text between the markup</returns>
    Public Shared Function FilterHtmlText(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return Regex.Replace(input, "<(.|\n)*?>", " ").Replace(" ", " ").Replace(" ", " ").Trim()
    End Function
#End Region
#Region " FilterInteger "
    ''' <summary>
    ''' Filter Integer Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterInteger(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input, FilterListInteger)
    End Function

    ''' <summary>
    ''' Filter Integer Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="result">String Filtered and convert</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterIntegerTryParse(ByVal input As String, ByRef result As Integer) As Boolean
        Dim output As String = String.Empty
        result = 0
        If FilterWorkerTry(input, FilterListInteger, output) Then
            Return Int32.TryParse("0" & output, result)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Filter Integer Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterIntegerTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListInteger, output)
    End Function
#End Region
#Region " FilterIPAddress "
    ''' <summary>
    ''' Filter IP Address Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterIPAddress(ByVal input As String) As String
        If input Is Nothing Then
            Return False
        End If
        If FilterWorker(input, ".").Length <> 3 Then
            Return String.Empty
        End If
        Dim segment = input.Split("."c)
        For i = 0 To 3
            Dim result As Integer
            If Not FilterUnsignedIntegerTryParse(segment(i), result) Then
                Return String.Empty
            End If
            If result > 255 Then
                Return String.Empty
            End If
        Next
        Return FilterWorker(input, FilterListIPAddress)
    End Function

    ''' <summary>
    ''' Filter IP Address Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterIPAddressTryParse(ByVal input As String, ByRef output As String) As Boolean
        If input Is Nothing Then
            Return False
        End If
        output = String.Empty
        If FilterWorker(input, ".").Length <> 3 Then
            Return False
        End If
        Dim segment = input.Split("."c)
        For i = 0 To 3
            Dim result As Integer
            If Not FilterUnsignedIntegerTryParse(segment(i), result) Then
                Return False
            End If
            If result > 255 Then
                Return False
            End If
        Next
        Return FilterWorkerTry(input, FilterListIPAddress, output)
    End Function
#End Region
#Region " FilterLowercase "
    ''' <summary>
    ''' Filter lower case
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterLowercase(ByVal input As String) As String
        Return FilterWorker(input, FilterListLowercase)
    End Function

    ''' <summary>
    ''' Filter lower case
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterLowercaseTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListLowercase, output)
    End Function
#End Region
#Region " FilterName "
    ''' <summary>
    ''' Filter Name (with space or hyphen)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterName(ByVal input As String) As String
        Return FilterWorker(input, FilterListName)
    End Function

    ''' <summary>
    ''' Filter Name (with space or hyphen)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterNameTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListName, output)
    End Function
#End Region
#Region " FilterPassword "
    ''' <summary>
    ''' Filter Password (upper + lower case + special) Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterPassword(ByVal input As String) As String
        Return FilterWorker(input, FilterListPassword)
    End Function

    ''' <summary>
    ''' Try Filter Password (upper + lower case + special) Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterPasswordTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListPassword, output)
    End Function
#End Region
#Region " FilterPostcode "
    ''' <summary>
    ''' Filter Postcode (text forced to upper case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterPostcode(ByVal input As String) As String
        If input Is Nothing Then
            Return False
        End If
        Return FilterWorker(input.ToUpperInvariant(), FilterListPostCode)
    End Function

    ''' <summary>
    ''' Filter Postcode (text forced to upper case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterPostcodeTryParse(ByVal input As String, ByRef output As String) As Boolean
        If input Is Nothing Then
            Return False
        End If
        Return FilterWorkerTry(input.ToUpperInvariant(), FilterListPostCode, output)
    End Function
#End Region
#Region " FilterSpecial "
    ''' <summary>
    ''' Filter Special characters (text forced to lower case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterSpecial(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input.ToLowerInvariant(), FilterListSpecial)
    End Function

    ''' <summary>
    ''' Filter Special characters (text forced to lower case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterSpecialTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input.ToLowerInvariant(), FilterListSpecial, output)
    End Function
#End Region
#Region " FilterTelephone "
    ''' <summary>
    ''' Filter Telephone (text forced to lower case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterTelephone(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input.ToLowerInvariant(), FilterListTelephone)
    End Function

    ''' <summary>
    ''' Filter Telephone (text forced to lower case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterTelephoneTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input.ToLowerInvariant(), FilterListTelephone, output)
    End Function
#End Region
#Region " FilterTime "
    ''' <summary>
    ''' FilterTime (00:00 or 00:00:00 format)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterTime(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input, FilterListTime)
    End Function

    ''' <summary>
    ''' FilterTime (00:00 or 00:00:00 format)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterTimeTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input, FilterListTime, output)
    End Function
#End Region
#Region " FilterUnsignedInteger "
    ''' <summary>
    ''' Filter UnsignedInteger Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterUnsignedInteger(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input, FilterListUnsignedInteger)
    End Function
    ''' <summary>
    ''' Filter Unsigned Integer Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="result">String Filtered and convert</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterUnsignedIntegerTryParse(ByVal input As String, ByRef result As Integer) As Boolean
        Dim output As String = String.Empty
        result = 0
        If FilterWorkerTry(input, FilterListUnsignedInteger, output) Then
            Return Int32.TryParse("0" & output, result)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Filter Unsigned Integer Values
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterUnsignedIntegerTryParse(ByVal input As String, ByRef output As String) As Boolean
        Return FilterWorkerTry(input, FilterListUnsignedInteger, output)
    End Function
#End Region
#Region " FilterUppercase "
    ''' <summary>
    ''' Filter upper case
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterUppercase(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input, FilterListUppercase)
    End Function

    ''' <summary>
    ''' Filter upper case
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterUppercaseTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input, FilterListUppercase, output)
    End Function
#End Region
#Region " FilterUrl "
    ''' <summary>
    ''' Filter URL
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    ''' <remarks>
    ''' The absence of an initial http:// or https:// does not constitute an
    ''' error, but an http:// is silently prepended if one is absent.
    ''' Positional validity is not currently included.
    ''' </remarks>
    Public Shared Function FilterUrl(ByVal input As String) As String
        Dim output As String = String.Empty
        Dim valid = FilterWorkerTry(input, FilterListUrl, output)
        If valid Then
            If Not (output.StartsWith("http://", StringComparison.Ordinal) OrElse output.StartsWith("http://", StringComparison.Ordinal)) Then
                output = "http://" & output
            End If
        End If
        Return output
    End Function

    ''' <summary>
    ''' Filter URL
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    ''' <remarks>
    ''' The absence of an initial http:// or https:// does not constitute an
    ''' error, but an http:// is silently prepended if one is absent.
    ''' Positional validity is not currently included.
    ''' </remarks>
    Public Shared Function FilterUrlTryParse(ByVal input As String, ByRef output As String) As Boolean
        Dim valid = FilterWorkerTry(input, FilterListUrl, output)
        If valid Then
            If (output Is Nothing) Then
                output = String.Empty
            End If
            If Not (output.StartsWith("http://", StringComparison.Ordinal) OrElse output.StartsWith("http://", StringComparison.Ordinal)) Then
                output = "http://" & output
            End If
        End If
        Return valid
    End Function
#End Region
#Region " FilterUserName "
    ''' <summary>
    ''' Filter user name (and force to upper case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterUserName(ByVal input As String) As String
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorker(input.ToUpperInvariant(), FilterListUserName)
    End Function

    ''' <summary>
    ''' Filter user name (and force to upper case)
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="output">Filtered string</param>
    ''' <returns>True if input is valid</returns>
    Public Shared Function FilterUserNameTryParse(ByVal input As String, ByRef output As String) As Boolean
        If (input Is Nothing) Then input = String.Empty
        Return FilterWorkerTry(input.ToUpperInvariant(), FilterListUserName, output)
    End Function
#End Region
#Region " FilterWorker "
    ''' <summary>
    ''' Filter Worker
    ''' </summary>
    ''' <param name="input">Input to filter</param>
    ''' <param name="validChars">White list of allowed characters</param>
    ''' <returns>Filtered string</returns>
    Public Shared Function FilterWorker(ByVal input As String, ByVal validChars As String) As String
        input = [String].Empty + input
        If (validChars Is Nothing) Then validChars = String.Empty
        If input.Length = 0 Then
            Return input
        End If
        Dim output = New StringBuilder(input.Length)
        For [loop] = 0 To input.Length - 1
            Dim value = input.Substring([loop], 1)
            If validChars.IndexOf(value, StringComparison.Ordinal) >= 0 Then
                output.Append(value)
            End If
        Next
        Return output.ToString()
    End Function

    ''' <summary>
    ''' Filter worker try action
    ''' </summary>
    ''' <param name="input">The input string</param>
    ''' <param name="validChars">The string of valid characters</param>
    ''' <param name="output">The output string.</param>
    ''' <returns>True if data passed</returns>
    Public Shared Function FilterWorkerTry(ByVal input As String, ByVal validChars As String, ByRef output As String) As Boolean
        output = [String].Empty
        If (validChars Is Nothing) Then validChars = String.Empty
        Dim dataGood = True
        input = [String].Empty + input
        If input.Length <> 0 Then
            Dim work = New StringBuilder(input.Length)
            For [loop] = 0 To input.Length - 1
                Dim value = input.Substring([loop], 1)
                If validChars.IndexOf(value, StringComparison.Ordinal) >= 0 Then
                    work.Append(value)
                Else
                    dataGood = False
                End If
            Next
            output = work.ToString()
        End If
        Return dataGood
    End Function
#End Region
#End Region
#Region " GetWords "
    ''' <summary>
    ''' Get all the words in the input string using Regex
    ''' </summary>
    ''' <param name="input">The input string</param>
    ''' <returns>Returns an array of all the words.</returns>
    ''' <remarks>
    ''' From an idea at http://dotnetperls.com/Content/String-Split-Benchmark.aspx
    ''' Split on all non-word characters.
    ''' @ special verbatim string syntax
    ''' \W+ one or more non-word characters together
    ''' </remarks>
    Public Shared Function GetWords(ByVal input As String) As String()
        Return Regex.Split(input, "\W+")
    End Function
#End Region
#Region " HasAdjacentCharacters "
    ''' <summary>
    ''' Determines whether the input has adjacent characters the same.
    ''' </summary>
    ''' <param name="input">The input.</param>
    ''' <returns>
    ''' <c>true</c> if [is repeated character] [the specified input]; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function HasAdjacentCharacters(ByVal input As String) As Boolean
        If input Is Nothing Then
            Return False
        End If
        Return HasAdjacentCharacters(input, 1)
    End Function

    ''' <summary>
    ''' Determines whether the input has adjacent characters the same.
    ''' </summary>
    ''' <param name="input">The string to test (null treated as empty string).</param>
    ''' <param name="maximumAllowed">The number of repeats allowable (negative values set to 0).</param>
    ''' <returns>
    ''' <c>true</c> if [is repeated character] [the specified input]; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function HasAdjacentCharacters(ByVal input As String, ByVal maximumAllowed As Integer) As Boolean
        If input Is Nothing Then
            Return False
        End If
        If maximumAllowed < 0 Then
            maximumAllowed = 0
        End If
        Dim last = String.Empty
        Dim repeats = 0
        For i = 0 To input.Length - 1
            Dim c = input.Substring(i, 1)
            If c = last Then
                repeats += 1
                If repeats > maximumAllowed Then
                    Return True
                End If
            Else
                repeats = 0
            End If
            last = c
        Next
        Return False
    End Function
#End Region
#Region " HasRepeatedCharacters "
    ''' <summary>
    ''' Determines whether the input has repeated characters.
    ''' </summary>
    ''' <param name="input">The input.</param>
    ''' <returns>
    ''' <c>true</c> if [is repeated character] [the specified input]; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function HasRepeatedCharacters(ByVal input As String) As Boolean
        If input Is Nothing Then
            Return False
        End If
        Return HasRepeatedCharacters(input, 1, FilterListPassword)
    End Function

    ''' <summary>
    ''' Determines whether the input has repeated characters.
    ''' </summary>
    ''' <param name="input">The input.</param>
    ''' <param name="maximumAllowed">The number of repeats allowable (minimum value 1).</param>
    ''' <returns>
    ''' <c>true</c> if [has repeated characters] [the specified input]; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function HasRepeatedCharacters(ByVal input As String, ByVal maximumAllowed As Integer) As Boolean
        If input Is Nothing Then
            Return False
        End If
        Return HasRepeatedCharacters(input, maximumAllowed, FilterListPassword)
    End Function

    ''' <summary>
    ''' Determines whether the input has repeated characters.
    ''' </summary>
    ''' <param name="input">The input.</param>
    ''' <param name="maximumAllowed">The number of repeats allowable (minimum value 1).</param>
    ''' <param name="lookup">Characters to lookup</param>
    ''' <returns>
    ''' <c>true</c> if [has repeated characters] [the specified input]; otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function HasRepeatedCharacters(ByVal input As String, ByVal maximumAllowed As Integer, ByVal lookup As String) As Boolean
        If input Is Nothing Then
            Return False
        End If
        If (lookup Is Nothing) Then lookup = String.Empty
        If maximumAllowed < 1 Then
            maximumAllowed = 1
        End If
        Dim length = lookup.Length
        Dim counts = New Integer(length - 1) {}
        For i = 1 To length - 1
            counts(i) = 0
        Next
        For i = 0 To input.Length - 1
            Dim c = input.Substring(i, 1)
            Dim find = lookup.IndexOf(c, StringComparison.Ordinal)
            If find >= 0 Then
                counts(find) += 1
            End If
        Next
        For i = 0 To length - 1
            If counts(i) > maximumAllowed Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region
#Region " InitCaps "
    ''' <summary>
    ''' Capitalise initial letters of words
    ''' </summary>
    ''' <param name="input">The input string</param>
    ''' <returns>String with start of words capitalised</returns>
    Public Shared Function InitCaps(ByVal input As String) As String
        input = [String].Empty + input
        Dim output = New StringBuilder(input.Length)
        Dim start = True
        For i = 0 To input.Length - 1
            Dim letter = input.Substring(i, 1)
            If start AndAlso FilterListAlpha.Contains(letter) Then
                output.Append(letter.ToUpper(CultureInfo.InvariantCulture))
                start = False
            Else
                output.Append(letter)
            End If
            If letter = " " Then
                start = True
            End If
        Next
        Return output.ToString()
    End Function
#End Region
#Region " IsInitCaps "
    ''' <summary>
    ''' Determines whether the specified input is an initial letter capitalised word.
    ''' </summary>
    ''' <param name="input">The input.</param>
    ''' <returns>
    ''' <c>true</c> if the specified input is initial letter capitalised otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Function IsInitCaps(ByVal input As String) As Boolean
        If String.IsNullOrEmpty(input) Then
            Throw New ArgumentException("input may not be null or empty")
        End If
        If input.Length < 1 Then
            Throw New ArgumentException("input must be at least 1 character")
        End If
        If input.Length = 1 Then
            Return FilterUppercase(input.Substring(0, 1)).Length > 0
        End If
        Dim rest = input.Substring(1)
        Return (FilterUppercase(input.Substring(0, 1)).Length > 0) AndAlso (rest = FilterLowercase(rest))
    End Function
#End Region
End Class