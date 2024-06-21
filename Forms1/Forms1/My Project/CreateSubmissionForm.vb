Imports System.IO

Public Class CreateSubmissionForm
    Private stopwatch As New Stopwatch()

    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            btnStopwatch.Text = "Start Stopwatch"
        Else
            stopwatch.Start()
            btnStopwatch.Text = "Stop Stopwatch"
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Collect data from the form
        Dim name As String = txtName.Text
        Dim email As String = txtEmail.Text
        Dim phone As String = txtPhone.Text
        Dim github As String = txtGitHub.Text

        ' Save the data to a file or database
        SaveSubmission(name, email, phone, github, stopwatch.Elapsed.ToString())
        MessageBox.Show("Submission Saved!")
    End Sub

    Private Sub SaveSubmission(name As String, email As String, phone As String, github As String, time As String)
        ' Append the data to a text file (submissions.txt)
        Using writer As New StreamWriter("submissions.txt", True)
            writer.WriteLine($"{name}|{email}|{phone}|{github}|{time}")
        End Using
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If


    End Sub
    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

End Class
