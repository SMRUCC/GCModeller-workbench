Public Class Workbench

    Public Shared Sub ShowStatusMessage(msg As String)
        Globals.host.Invoke(Sub() Globals.host.ToolStripStatusLabel1.Text = msg)
    End Sub
End Class
