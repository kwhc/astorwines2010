Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.Common
'Imports SubSonic

Namespace Commerce.Common

	Public Class Lookups
		' <summary>
		' This is a simple function to use with lookup tables
		' that are not represented with a business object.
		' </summary>
		' <param name="tableName">Name of the table to query. All results will be returned</param>
		' <returns>IDataReader</returns>
		Private Sub New()
		End Sub
        'Public Shared Function GetList(ByVal tableName As String) As IDataReader

        '	Return New Query(tableName).ExecuteReader()

        'End Function

        '' <summary>
        '' This is a simple function to use with lookup tables
        '' that are not represented with a business object.
        '' You can supply a parameter name and value
        '' </summary>
        '' <param name="tableName">The name of the table</param>
        '' <param name="paramField">The column to use </param>
        '' <param name="paramValue">The column value</param>
        '' <returns></returns>
        'Public Shared Function GetListByIntParam(ByVal tableName As String, ByVal paramField As String, ByVal paramValue As Integer) As IDataReader
        '	Return New Query(tableName).AddWhere(paramField, paramValue).ExecuteReader()

        'End Function
        '' <summary>
        '' This is a simple function to use with lookup tables
        '' that are not represented with a business object.
        '' You can supply a parameter name and value
        '' </summary>
        '' <param name="tableName">The name of the table</param>
        '' <param name="paramField">The column to use </param>
        '' <param name="paramValue">The column value</param>
        '' <returns></returns>
        'Public Shared Function GetListByStringParam(ByVal tableName As String, ByVal paramField As String, ByVal paramValue As String) As IDataReader
        '	Return New Query(tableName).AddWhere(paramField, paramValue).ExecuteReader()

        'End Function

        'Public Shared Sub QuickAdd(ByVal tableName As String, ByVal paramField As String, ByVal paramValue As String)

        '	Dim cmd As QueryCommand = New QueryCommand("INSERT INTO " & tableName & " (" & paramField & ") VALUES(@p1) ")
        '	cmd.AddParameter("@p1", paramValue)
        '	DataService.ExecuteQuery(cmd)

        'End Sub

	End Class
End Namespace
