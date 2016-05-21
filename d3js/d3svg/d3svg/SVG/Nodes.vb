Imports System.Drawing
Imports System.Text
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.DocumentFormat.HTML
Imports Microsoft.VisualBasic.Serialization

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

    Public Class line : Inherits node
        <XmlAttribute> Public Property y2 As Double
        <XmlAttribute> Public Property x2 As Double
        <XmlAttribute> Public Property y1 As Double
        <XmlAttribute> Public Property x1 As Double
    End Class

    <XmlType("svg")>
    Public Class SVG : Implements ISaveHandle

#Region "xml root property"

        <XmlAttribute> Public Property width As String
        <XmlAttribute> Public Property height As String
        <XmlAttribute> Public Property version As String
#End Region

        Public Property defs As CSSStyles

#Region "SVG"
        <XmlElement("line")> Public Property lines As line()
        <XmlElement("circle")> Public Property circles As circle()
#End Region

        Public Sub SetSize(size As Size)
            width = size.Width & "px"
            height = size.Height & "px"
        End Sub

        Private Function SaveAsXml(Optional Path As String = "", Optional encoding As Encoding = Nothing) As Boolean Implements ISaveHandle.Save
            Dim xml As String = Me.GetXml

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