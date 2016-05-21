﻿Imports System.Drawing
Imports System.Text
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.DocumentFormat.HTML
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.XmlDoc

Namespace Nodes

    Public MustInherit Class node
        <XmlAttribute> Public Property style As String
        <XmlAttribute> Public Property [class] As String

        Public Overrides Function ToString() As String
            Return MyClass.GetJson
        End Function
    End Class

    Public Class title : Inherits node
        <XmlText> Public Property innerHTML As String
    End Class

    Public Class circle : Inherits node
        <XmlAttribute> Public Property cy As Double
        <XmlAttribute> Public Property cx As Double
        <XmlAttribute> Public Property r As Double
        Public Property title As title
    End Class

    Public Class g : Inherits node
        <XmlAttribute> Public Property transform As String
        <XmlElement("text")> Public Property texts As text()
        <XmlElement("g")> Public Property gs As g()
        <XmlElement> Public Property path As path()
        <XmlElement> Public Property rect As rect()
        <XmlElement> Public Property polygon As polygon()
        <XmlElement("line")> Public Property lines As line()
        <XmlElement("circle")> Public Property circles As circle()
    End Class

    Public Class polygon : Inherits node
        <XmlAttribute> Public Property points As String()
    End Class

    Public Class rect : Inherits node
        Public Property height As String
        Public Property width As String
        Public Property y As String
        Public Property x As String
    End Class

    Public Class path : Inherits node
        <XmlAttribute> Public Property d As String
    End Class

    Public Class line : Inherits node
        <XmlAttribute> Public Property y2 As Double
        <XmlAttribute> Public Property x2 As Double
        <XmlAttribute> Public Property y1 As Double
        <XmlAttribute> Public Property x1 As Double
    End Class

    Public Class text : Inherits node
        <XmlAttribute> Public Property transform As String
        <XmlAttribute> Public Property dy As String
        <XmlText> Public Property value As String
        <XmlAttribute("text-anchor")> Public Property anchor As String
        <XmlAttribute> Public Property y As String
        <XmlAttribute> Public Property x As String
    End Class

    <XmlType("svg")>
    Public Class SVG : Inherits g
        Implements ISaveHandle

#Region "xml root property"

        <XmlAttribute> Public Property width As String
        <XmlAttribute> Public Property height As String
        <XmlAttribute> Public Property version As String
#End Region

        Public Property defs As CSSStyles

        Public Sub SetSize(size As Size)
            width = size.Width & "px"
            height = size.Height & "px"
        End Sub

        Private Function SaveAsXml(Optional Path As String = "", Optional encoding As Encoding = Nothing) As Boolean Implements ISaveHandle.Save
            Dim xml As New XmlDoc(Me.GetXml)
            xml.encoding = XmlEncodings.UTF8
            xml.standalone = False
            xml.xmlns.xlink = "http://www.w3.org/1999/xlink"
            xml.xmlns.xmlns = "http://www.w3.org/2000/svg"

            Return xml.SaveTo(Path, encoding)
        End Function

        Public Function SaveAsXml(Optional Path As String = "", Optional encoding As Encodings = Encodings.UTF8) As Boolean Implements ISaveHandle.Save
            Return SaveAsXml(Path, encoding.GetEncodings)
        End Function
    End Class

    Public Class CSSStyles
        <XmlElement("style")> Public Property styles As XmlMeta.CSS()
    End Class
End Namespace