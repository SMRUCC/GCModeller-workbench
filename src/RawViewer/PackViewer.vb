#Region "Microsoft.VisualBasic::f364782a82ba49e9b26020030a0d9f64, G:/GCModeller/src/workbench/win32_desktop/src/RawViewer//PackViewer.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:


    ' Code Statistics:

    '   Total Lines: 80
    '    Code Lines: 54
    ' Comment Lines: 10
    '   Blank Lines: 16
    '     File Size: 2.72 KB


    ' Class PackViewer
    ' 
    '     Constructor: (+2 Overloads) Sub New
    ' 
    '     Function: GetCounts, GetMoleculeIdset, getReactionGraph, GetReactionIdSet, GetVector
    ' 
    '     Sub: (+2 Overloads) Dispose
    ' 
    ' /********************************************************************************/

#End Region

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

