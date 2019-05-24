﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.Language.UnixBash

Namespace HTML

    ''' <summary>
    ''' A report template directory
    ''' </summary>
    Public Class HTMLReport : Implements IDisposable

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' 这个主要是为了兼容PC端的HTML报告和移动端的HTML报告所设置了
        ''' 因为PC端的HTML报告可能就只有一个index.html
        ''' 但是对于移动端，由于设备屏幕比较小以及为了方便在内容分区之间跳转，所以HTML报告往往会被按照内容分区分为多个html文档构成的
        ''' </remarks>
        Public ReadOnly Property templates As Dictionary(Of String, TemplateHandler)

        ''' <summary>
        ''' html报告的根目录，报告也将会被保存在这个文件夹之中
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property directory As String

        Public ReadOnly Property HtmlFiles As String()
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return templates _
                    .Values _
                    .Select(Function(handler) handler.Path) _
                    .ToArray
            End Get
        End Property

        ''' <summary>
        ''' 利用这个属性进行字符串替换的时候。模板之中的占位符的格式应该为``{$key_name}``
        ''' </summary>
        ''' <param name="name">在这里只需要输入``key_name``字符串即可</param>
        Default Public WriteOnly Property assign(name As String) As String
            Set(value As String)
                For Each template In templates.Values
                    template.Builder(name) = value
                Next
            End Set
        End Property

        Sub New(folder$, Optional searchLevel As SearchOption = SearchOption.SearchTopLevelOnly)
            templates = (ls - l - {"*.html", "*.htm"} << searchLevel <= folder) _
                .ToDictionary(Function(path) path.BaseName,
                              Function(path)
                                  Return New TemplateHandler(path)
                              End Function)
            directory = folder.GetDirectoryFullPath
        End Sub

        ''' <summary>
        ''' 这个函数与<see cref="assign(String)"/>属性不同的是，这个是直接执行字符串替换，
        ''' 而<see cref="assign(String)"/>属性则是会将<paramref name="find"/>占位符拓展为
        ''' ``{$<paramref name="find"/>}``
        ''' </summary>
        ''' <param name="find">在模板之中的占位符</param>
        ''' <param name="value">将要替换为这个字符串的值</param>
        ''' <returns></returns>
        Public Function Replace(find$, value$) As HTMLReport
            For Each template In templates.Values
                Call template.Builder.Replace(find, value)
            Next

            Return Me
        End Function

        ''' <summary>
        ''' 这个方法与<see cref="Replace(String, String)"/>的功能一致，
        ''' 只不过这个方法更加方便于XML或者HTML语法的使用
        ''' </summary>
        ''' <param name="find$"></param>
        ''' <param name="value"></param>
        ''' <returns></returns>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function Replace(find$, value As XElement) As HTMLReport
            Return Replace(find, value.ToString)
        End Function

        Public Overrides Function ToString() As String
            Return directory
        End Function

        Public Sub Save()
            For Each template In templates.Values
                Call template.Flush()
            Next
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                    Call Save()
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Operator &(dir As HTMLReport, fileName As String) As String
            Return (dir.directory & "/" & fileName).Replace("\", "/").StringReplace("[/]+", "/")
        End Operator
    End Class
End Namespace