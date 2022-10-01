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

    Private Sub FormSplashScreen_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub

    Private Sub FormSplashScreen_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If Not splash Then
            Call Me.Close()
        End If
    End Sub
End Class