﻿Imports GCModeller_win32Desktop.RibbonLib.Controls
Imports RibbonLib.Interop

Public Class Workbench

    Friend Shared ReadOnly Property Ribbon As RibbonItems
    Friend Shared ReadOnly LogTextOutput As New LoggingOutputWindow

    Public Shared Sub Load()
        _Ribbon = New RibbonItems(Globals.host.Ribbon1)

        Call addRibbonEvents()
    End Sub

    Private Shared Sub addRibbonEvents()
        AddHandler Ribbon.About.ExecuteEvent, Sub() Call New FormSplashScreen().Show()
    End Sub

    Public Shared Sub ShowStatusMessage(msg As String)
        Globals.host.Invoke(Sub() Globals.host.ToolStripStatusLabel1.Text = msg)
    End Sub
End Class
