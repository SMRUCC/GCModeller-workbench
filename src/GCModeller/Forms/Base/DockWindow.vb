Imports WeifenLuo.WinFormsUI.Docking

Public Class DockWindow

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AutoScaleMode = AutoScaleMode.Dpi
    End Sub

    Protected Overridable Sub CloseWindow()
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Call CloseWindow()
    End Sub

    Private Sub option3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles option3ToolStripMenuItem.Click
        Select Case Me.DockState
            Case DockState.DockBottom : Me.DockState = DockState.DockBottomAutoHide
            Case DockState.DockLeft : Me.DockState = DockState.DockLeftAutoHide
            Case DockState.DockRight : Me.DockState = DockState.DockRightAutoHide
            Case DockState.DockTop : Me.DockState = DockState.DockTopAutoHide
            Case Else
                ' do nothing
        End Select
    End Sub

    Private Sub DockAsTabbedDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DockAsTabbedDocumentToolStripMenuItem.Click
        Me.DockState = DockState.Document
    End Sub

    Private Sub option2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles option2ToolStripMenuItem.Click
        Select Case Me.DockState
            Case DockState.DockBottomAutoHide : Me.DockState = DockState.DockBottom
            Case DockState.DockLeftAutoHide : Me.DockState = DockState.DockLeft
            Case DockState.DockRightAutoHide : Me.DockState = DockState.DockRight
            Case DockState.DockTopAutoHide : Me.DockState = DockState.DockTop
            Case Else
                ' do nothing
                Me.DockState = DockState.Document
        End Select
    End Sub

    Private Sub option1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles option1ToolStripMenuItem.Click
        Me.DockState = DockState.Float
    End Sub
End Class