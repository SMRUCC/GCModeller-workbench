Imports System.Runtime.CompilerServices
Imports WeifenLuo.WinFormsUI.Docking

Partial Public Class LoggingOutputWindow
    Inherits DocumentWindow

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' 这个方法是线程安全的进行日志记录
    ''' </summary>
    ''' <param name="line"></param>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Sub WriteLine(line As String)
        Call Invoke(Sub() textBox1.AppendText(line & vbCrLf))
    End Sub

    Private Sub LoggingOutputWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        DockState = DockState.DockBottomAutoHide
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        textBox1.WordWrap = ToolStripButton2.Checked
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        textBox1.Clear()
    End Sub
End Class
