Imports System
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.XPath

Public Class XmlHelper

    Public Shared Function GetXmlNameSpaceManager(ByVal xpn As XPathNavigator) As XmlNamespaceManager

        xpn.MoveToFollowing(XPathNodeType.Element)

        Dim xmlnsm As New XmlNamespaceManager(xpn.NameTable)
        xmlnsm.AddNamespace("dc", xpn.NamespaceURI)

        For Each xns As KeyValuePair(Of String, String) In xpn.GetNamespacesInScope(XmlNamespaceScope.All)
            xmlnsm.AddNamespace(xns.Key, xns.Value)
        Next

        Return xmlnsm

    End Function

End Class
