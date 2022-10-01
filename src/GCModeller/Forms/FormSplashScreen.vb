Imports System.Threading
Imports Microsoft.VisualBasic.Parallel

Public Class FormSplashScreen

    Private Sub FormSplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call RunTask(AddressOf InitLoad)
    End Sub

    Private Sub InitLoad()
        Call Globals.host.Invoke(Sub() Globals.host.ShowMainPage())
        Call Thread.Sleep(1500)
        Call Me.Invoke(Sub() Close())
    End Sub
End Class