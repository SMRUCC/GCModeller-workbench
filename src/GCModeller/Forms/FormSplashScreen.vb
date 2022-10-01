Imports System.Threading
Imports Microsoft.VisualBasic.Parallel

Public Class FormSplashScreen

    Public Property splash As Boolean = False

    Private Sub FormSplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        If splash Then
            Call RunTask(AddressOf InitLoad)
        End If
    End Sub

    Private Sub InitLoad()
        Call Globals.Load()
        Call Globals.host.Invoke(Sub() Globals.host.ShowMainPage())
        Call Thread.Sleep(1500)
        Call Me.Invoke(Sub() Close())
    End Sub
End Class