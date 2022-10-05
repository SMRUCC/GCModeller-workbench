Imports GCModeller_win32Desktop.RibbonLib.Controls

Public Class Workbench

    Friend Shared ReadOnly Property Ribbon As RibbonItems
    Friend Shared ReadOnly LogTextOutput As New LoggingOutputWindow

    Public Shared Sub Load()
        _Ribbon = New RibbonItems(Globals.host.Ribbon1)

        Call addRibbonEvents()
    End Sub

    Private Shared Sub addRibbonEvents()
        AddHandler Ribbon.About.ExecuteEvent, Sub() Call New FormSplashScreen().Show()
        AddHandler Ribbon.ButtonEnrichmentDatabase.ExecuteEvent, Sub() Call WebApp.Open(Of ImportsUniprot)()
        AddHandler Ribbon.ButtonNCBITaxonomy.ExecuteEvent, Sub() Call WebApp.Open(Of ImportsNCBITaxonomy)()
        AddHandler Ribbon.ViewAppTasks.ExecuteEvent, Sub() Call WebApp.Open(Of AppTasks)()
        AddHandler Ribbon.ButtonStartPage.ExecuteEvent, Sub() Call Globals.host.ShowMainPage()

        AddHandler Ribbon.ZoomIn.ExecuteEvent, Sub() Call WebApp.SetZoomFactor(5)
        AddHandler Ribbon.ZoomOut.ExecuteEvent, Sub() Call WebApp.SetZoomFactor(-5)
        AddHandler Ribbon.Zoom100Percent.ExecuteEvent, Sub() Call WebApp.RemoveZoomFactor()
    End Sub

    Public Shared Sub ShowStatusMessage(msg As String, Optional icon As Image = Nothing)
        Globals.host.Invoke(
            Sub()
                If Not icon Is Nothing Then
                    Globals.host.ToolStripStatusLabel1.Image = icon
                Else
                    Globals.host.ToolStripStatusLabel1.Image = My.Resources.user_invisible
                End If

                Globals.host.ToolStripStatusLabel1.Text = msg
            End Sub)
    End Sub
End Class
