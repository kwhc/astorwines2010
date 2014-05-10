Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Configuration


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WSLookUp
    Inherits System.Web.Services.WebService
    Private Shared autoCompleteWordList As String()

    Public Sub New()
        'constructor
    End Sub


    '  <WebMethod()> _
    '  Public Function GetWordList(ByVal prefixText As String, ByVal count As Integer) As String()

    '      If (autoCompleteWordList Is Nothing) Then
    '          Dim temp() As String = IO.File.ReadAllLines(Server.MapPath("~/App_Data/words.txt"))
    '          Array.Sort(temp, New CaseInsensitiveComparer)
    '          autoCompleteWordList = temp
    '      End If
    '      Dim index As Integer = Array.BinarySearch(autoCompleteWordList, prefixText, New CaseInsensitiveComparer)
    '      If (index < 0) Then
    '          index = Not index
    '      End If
    '      Dim matchingCount As Integer
    '      matchingCount = 0
    '      Do While ((matchingCount < count) _
    '                  AndAlso (index _
    '                  + (matchingCount < autoCompleteWordList.Length)))
    '          If Not autoCompleteWordList((index + matchingCount)).StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) Then
    '              'TODO: Warning!!! break;If
    '          End If
    '          matchingCount = (matchingCount + 1)
    '      Loop
    '      Dim returnValue() As String = New String((matchingCount) - 1) {}
    '      If (matchingCount > 0) Then
    '          Array.Copy(autoCompleteWordList, index, returnValue, 0, matchingCount)
    '      End If
    '      Return returnValue
    '  End Function
    <WebMethod(Description:="Method to retrieve Auto Complete List")> _
    Public Function GetAutoCompleteList(ByVal prefixText As String, ByVal count As Integer) As Array

        Dim SqlConnection1 As New SqlConnection(ConfigurationManager.ConnectionStrings("astorwebdatabase20ConnectionString").ToString)
        Dim sSP As String = "GetAutoCompleteList_sp"
        Dim _scSC As New SqlCommand(sSP, SqlConnection1)
        Dim suggestions As New List(Of String)

        prefixText = Replace(prefixText, "%", String.Empty)
        prefixText = Replace(prefixText, """", String.Empty)
        prefixText = Replace(prefixText, "'", String.Empty)

        With _scSC
            .CommandType = CommandType.StoredProcedure

            With .Parameters
                .Add(New SqlParameter("@term", SqlDbType.VarChar, 150, ParameterDirection.Input)).Value = prefixText & "%"
                .Add(New SqlParameter("@nrows", SqlDbType.Int, 6, ParameterDirection.Input)).Value() = count

            End With

            Try
                .Connection.Open()
                Dim dr As SqlDataReader = .ExecuteReader(CommandBehavior.CloseConnection)

                While dr.Read
                    suggestions.Add(dr(0).ToString)
                End While

            Catch ex As Exception

                Throw ex
            Finally
                If .Connection.State = ConnectionState.Open Then
                    .Connection.Close()
                End If
            End Try
        End With

        Return suggestions.ToArray

    End Function
End Class
