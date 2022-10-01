Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DockWindow
    Inherits DockContent

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        contextMenuStrip1 = New Windows.Forms.ContextMenuStrip(components)
        option1ToolStripMenuItem = New Windows.Forms.ToolStripMenuItem()
        option2ToolStripMenuItem = New Windows.Forms.ToolStripMenuItem()
        option3ToolStripMenuItem = New Windows.Forms.ToolStripMenuItem()
        contextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' contextMenuStrip1
        ' 
        contextMenuStrip1.Items.AddRange(New Windows.Forms.ToolStripItem() {option1ToolStripMenuItem, option2ToolStripMenuItem, option3ToolStripMenuItem})
        contextMenuStrip1.Name = "contextMenuStrip1"
        contextMenuStrip1.Size = New Drawing.Size(113, 70)
        ' 
        ' option1ToolStripMenuItem
        ' 
        option1ToolStripMenuItem.Name = "option1ToolStripMenuItem"
        option1ToolStripMenuItem.Size = New Drawing.Size(152, 22)
        option1ToolStripMenuItem.Text = "Option&1"
        ' 
        ' option2ToolStripMenuItem
        ' 
        option2ToolStripMenuItem.Name = "option2ToolStripMenuItem"
        option2ToolStripMenuItem.Size = New Drawing.Size(152, 22)
        option2ToolStripMenuItem.Text = "Option&2"
        ' 
        ' option3ToolStripMenuItem
        ' 
        option3ToolStripMenuItem.Name = "option3ToolStripMenuItem"
        option3ToolStripMenuItem.Size = New Drawing.Size(152, 22)
        option3ToolStripMenuItem.Text = "Option&3"
        ' 
        ' ToolWindow
        ' 
        ClientSize = New Drawing.Size(292, 266)
        DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom
        Name = "ToolWindow"
        TabPageContextMenuStrip = contextMenuStrip1
        TabText = "ToolWindow"
        Text = "ToolWindow"
        contextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Private WithEvents contextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Private WithEvents option1ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Private WithEvents option2ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Private WithEvents option3ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
End Class
