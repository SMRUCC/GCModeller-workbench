Imports System.Drawing
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.DocumentFormat.HTML
Imports Microsoft.VisualBasic.Serialization

Namespace Nodes

    Public MustInherit Class node
        <XmlAttribute> Public Property style As String
        <XmlAttribute> Public Property [Class] As String

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
    Public Class SVG

#Region "xml root property"

        <XmlAttribute> Public Property width As String
            Get
                Return Size.Width & "px"
            End Get
            Set(value As String)
                Dim size As New Size(Scripting.CTypeDynamic(Of Integer)(value), size.Height)
                _Size = size
            End Set
        End Property
        <XmlAttribute> Public Property height As String
            Get
                Return Size.Height & "px"
            End Get
            Set(value As String)
                Dim size As New Size(size.Width, Scripting.CTypeDynamic(Of Integer)(value))
                _Size = size
            End Set
        End Property
        <XmlAttribute> Public Property version As String
#End Region

        Public ReadOnly Property Size As Size
        Public Property defs As CSS

#Region "SVG"
        <XmlElement("line")> Public Property lines As line()
        <XmlElement("circle")> Public Property circles As circle()
#End Region
    End Class

    Public Class CSS
        <XmlElement("style")> Public Property styles As XmlMeta.CSS()
    End Class
End Namespace