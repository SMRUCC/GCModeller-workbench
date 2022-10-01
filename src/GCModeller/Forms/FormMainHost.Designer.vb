Imports WeifenLuo.WinFormsUI.Docking

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMainHost
    Inherits System.Windows.Forms.Form

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dockPanel = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.vS2015DarkTheme1 = New WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme()
        Me.vS2015BlueTheme1 = New WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme()
        Me.vS2015LightTheme1 = New WeifenLuo.WinFormsUI.Docking.VS2015LightTheme()
        Me.vsToolStripExtender1 = New WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dockPanel
        '
        Me.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockPanel.DockBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.dockPanel.DockBottomPortion = 150.0R
        Me.dockPanel.DockLeftPortion = 200.0R
        Me.dockPanel.DockRightPortion = 200.0R
        Me.dockPanel.DockTopPortion = 150.0R
        Me.dockPanel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.dockPanel.Location = New System.Drawing.Point(0, 0)
        Me.dockPanel.Name = "dockPanel"
        Me.dockPanel.RightToLeftLayout = True
        Me.dockPanel.ShowAutoHideContentOnHover = False
        Me.dockPanel.Size = New System.Drawing.Size(800, 428)
        Me.dockPanel.TabIndex = 0
        '
        'vsToolStripExtender1
        '
        Me.vsToolStripExtender1.DefaultRenderer = Nothing
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(119, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'FormMainHost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dockPanel)
        Me.Controls.Add(Me.StatusStrip1)
        Me.IsMdiContainer = True
        Me.Name = "FormMainHost"
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents dockPanel As WeifenLuo.WinFormsUI.Docking.DockPanel
    Private WithEvents vsToolStripExtender1 As WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender

    Private vS2015LightTheme1 As WeifenLuo.WinFormsUI.Docking.VS2015LightTheme
    Private vS2015BlueTheme1 As WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme
    Private vS2015DarkTheme1 As WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
End Class
