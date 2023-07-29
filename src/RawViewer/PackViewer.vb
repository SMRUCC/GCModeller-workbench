Imports System.IO
Imports System.Runtime.CompilerServices
Imports SMRUCC.genomics.GCModeller.ModellingEngine.IO.Raw

Public Class PackViewer : Implements IDisposable

    Dim disposedValue As Boolean
    Dim file As Reader

    Sub New(file As Stream)
        Call Me.New(New Reader(file))
    End Sub

    Sub New(file As Reader)
        Me.file = file.LoadIndex
    End Sub

    Public Function GetCounts() As Dictionary(Of String, Integer)
        Return file.GetIdCounts
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
