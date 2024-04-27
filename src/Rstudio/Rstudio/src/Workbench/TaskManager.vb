#Region "Microsoft.VisualBasic::b9bffbfc038488bcd308e960bf847646, G:/GCModeller/src/workbench/win32_desktop/src/Rstudio/Rstudio/src//Workbench/TaskManager.vb"

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

    '   Total Lines: 101
    '    Code Lines: 67
    ' Comment Lines: 16
    '   Blank Lines: 18
    '     File Size: 3.56 KB


    ' Class TaskManager
    ' 
    '     Constructor: (+1 Overloads) Sub New
    ' 
    '     Function: LoadTaskList
    ' 
    '     Sub: add, delete, (+2 Overloads) Dispose, update
    ' 
    ' /********************************************************************************/

#End Region

Imports System.IO
Imports Microsoft.VisualBasic.DataStorage.HDSPack
Imports Microsoft.VisualBasic.DataStorage.HDSPack.FileSystem
Imports Microsoft.VisualBasic.Serialization.JSON

Public Class TaskManager : Implements IDisposable

    ReadOnly pool As StreamPack

    Private disposedValue As Boolean

    Public Shared ReadOnly taskDb As String = $"{App.ProductProgramData}/web_task.db"

    Sub New(file As String)
        If file.FileExists Then
            pool = New StreamPack(file.Open(FileMode.Open, doClear:=False, [readOnly]:=False))
        Else
            pool = New StreamPack(
                buffer:=file.Open(FileMode.OpenOrCreate, doClear:=False, [readOnly]:=False),
                init_size:=1024 * 1024 * 4,
                meta_size:=1024 * 1024 * 32,
                [readonly]:=False
            )
        End If
    End Sub

    ''' <summary>
    ''' populate a set of the web task data
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    Public Shared Iterator Function LoadTaskList(file As String) As IEnumerable(Of WebTask)
        Using stream As New StreamPack(
            buffer:=file.Open(FileMode.OpenOrCreate, doClear:=False, [readOnly]:=True),
            [readonly]:=True,
            meta_size:=32 * 1024 * 1024
        )
            Dim group As StreamGroup = TryCast(stream.GetObject("/TaskPool/"), StreamGroup)

            If group Is Nothing Then
                ' file is empty
                Return
            End If

            Dim files As StreamBlock() = group.files _
                .Where(Function(f) TypeOf f Is StreamBlock) _
                .Select(Function(f) DirectCast(f, StreamBlock)) _
                .ToArray

            For Each fobj As StreamBlock In files
                Dim json As String = New StreamReader(stream.OpenBlock(fobj)).ReadLine
                Dim task As WebTask = json.LoadJSON(Of WebTask)

                Yield task
            Next
        End Using
    End Function

    Public Sub add(task As WebTask)
        Dim path As String = $"/TaskPool/{task.session_id}.json"
        Dim json As String = task.GetJson

        Call pool.WriteText(json, path)
    End Sub

    Public Sub delete(id As String)
        Dim dir As StreamGroup = pool.GetObject("/TaskPool/")
        dir.DeleteNode($"{id}.json")
    End Sub

    Public Sub update(id As String, updates As WebTask)
        Call delete(id)
        Call add(updates)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
                Call pool.Dispose()
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class

