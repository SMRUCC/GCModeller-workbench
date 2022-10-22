Imports GCModeller_win32Desktop.Settings.Programs.IDE
Imports AppSession = GCModeller_win32Desktop.Settings.Session

Namespace My

    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Public Shared Sub SaveSession()
            Dim configs = AppSession.GetSettingsFile
            Dim pos As Point = Globals.host.Location
            Dim size As Size = Globals.host.Size

            configs.Dev2.IDE.Size = New IDEConfig.SizeF With {.Width = size.Width, .Height = size.Height}
            configs.Dev2.IDE.Location = New IDEConfig.PointF With {.Left = pos.X, .Top = pos.Y}

            Call AppSession.Finallize()
        End Sub
    End Class
End Namespace
