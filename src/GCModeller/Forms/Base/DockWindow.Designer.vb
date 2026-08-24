#Region "Microsoft.VisualBasic::73c80b7ef5cd15075bdbf13e819015d9, win32_desktop\src\GCModeller\Forms\Base\DockWindow.Designer.vb"

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

    '   Total Lines: 104
    '    Code Lines: 69 (66.35%)
    ' Comment Lines: 29 (27.88%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 6 (5.77%)
    '     File Size: 5.21 KB


    ' Class DockWindow
    ' 
    '     Sub: Dispose, InitializeComponent
    ' 
    ' /********************************************************************************/

#End Region

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DockWindow))
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.option1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.option2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.option3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DockAsTabbedDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.contextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'contextMenuStrip1
        '
        Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.option1ToolStripMenuItem, Me.option2ToolStripMenuItem, Me.DockAsTabbedDocumentToolStripMenuItem, Me.option3ToolStripMenuItem, Me.ToolStripMenuItem1, Me.CloseToolStripMenuItem})
        Me.contextMenuStrip1.Name = "contextMenuStrip1"
        Me.contextMenuStrip1.Size = New System.Drawing.Size(216, 142)
        '
        'option1ToolStripMenuItem
        '
        Me.option1ToolStripMenuItem.Name = "option1ToolStripMenuItem"
        Me.option1ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.option1ToolStripMenuItem.Text = "Float"
        '
        'option2ToolStripMenuItem
        '
        Me.option2ToolStripMenuItem.Name = "option2ToolStripMenuItem"
        Me.option2ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.option2ToolStripMenuItem.Text = "Dock"
        '
        'option3ToolStripMenuItem
        '
        Me.option3ToolStripMenuItem.Name = "option3ToolStripMenuItem"
        Me.option3ToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.option3ToolStripMenuItem.Text = "Auto Hide"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = CType(resources.GetObject("CloseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'DockAsTabbedDocumentToolStripMenuItem
        '
        Me.DockAsTabbedDocumentToolStripMenuItem.Name = "DockAsTabbedDocumentToolStripMenuItem"
        Me.DockAsTabbedDocumentToolStripMenuItem.Size = New System.Drawing.Size(215, 22)
        Me.DockAsTabbedDocumentToolStripMenuItem.Text = "Dock as Tabbed Document"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(212, 6)
        '
        'DockWindow
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.DockAreas = CType(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) _
            Or WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom), WeifenLuo.WinFormsUI.Docking.DockAreas)
        Me.Name = "DockWindow"
        Me.TabPageContextMenuStrip = Me.contextMenuStrip1
        Me.TabText = "ToolWindow"
        Me.Text = "ToolWindow"
        Me.contextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents contextMenuStrip1 As Windows.Forms.ContextMenuStrip
    Private WithEvents option1ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Private WithEvents option2ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Private WithEvents option3ToolStripMenuItem As Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockAsTabbedDocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
End Class
