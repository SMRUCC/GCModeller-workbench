Imports System.IO
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.IO
Imports Microsoft.VisualBasic.Serialization
Imports SMRUCC.genomics.GCModeller.ModellingEngine.IO.Raw

Public Class PackViewer : Implements IDisposable

    Dim disposedValue As Boolean
    Dim file As Reader
    Dim ticks As Double()

    Sub New(file As Stream)
        Call Me.New(New Reader(file))
    End Sub

    Sub New(file As Reader)
        Me.file = file.LoadIndex
        Me.ticks = file.AllTimePoints.ToArray
    End Sub

    Public Iterator Function GetVector(modu As String, id As String) As IEnumerable(Of Double)
        Dim p As Integer = file(modu).IndexOf(x:=id)

        If p = -1 Then
            Return
        End If

        Dim offset As Long = p * RawStream.DblFloat

        For Each time As Double In ticks
            Dim file As BinaryDataReader = Me.file.GetFrameFile(modu, time)
            Call file.Seek(offset, SeekOrigin.Begin)
            Yield file.ReadDouble()
        Next
    End Function

    Public Function GetCounts() As Dictionary(Of String, Integer)
        Return file.GetIdCounts
    End Function

    Public Function GetReactionIdSet(id As String) As String()
        Return file.GetRelatedReactions(id).ToArray
    End Function

    Public Function getReactionGraph(id As String, rxn As String) As Dictionary(Of String, String())
        Return file.GetGraphData(id, rxn)
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Function GetMoleculeIdset() As Dictionary(Of String, String())
        Return file.GetMoleculeIdList
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)
                Call file.Dispose()
            End If

            ' TODO: 释放未托管的资源(未托管的对象)并重写终结器
            ' TODO: 将大型字段设置为 null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: 仅当“Dispose(disposing As Boolean)”拥有用于释放未托管资源的代码时才替代终结器
    ' Protected Overrides Sub Finalize()
    '     ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
