Imports System.IO

Public Class ViewSubmissionsForm
    Private submissions As List(Of Submission)
    Private currentIndex As Integer = 0

    ' Initialize the form and set KeyPreview to True
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
    End Sub

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load submissions from the backend
        submissions = LoadSubmissions()
        DisplaySubmission()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission()
        End If
    End Sub

    Private Sub DisplaySubmission()
        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            Dim submission As Submission = submissions(currentIndex)
            lblName.Text = submission.Name
            lblEmail.Text = submission.Email
            lblPhone.Text = submission.Phone
            lblGitHub.Text = submission.GitHub
            lblTime.Text = submission.Time
        End If
    End Sub

    Private Function LoadSubmissions() As List(Of Submission)
        Dim submissionsList As New List(Of Submission)
        If File.Exists("submissions.txt") Then
            Using reader As New StreamReader("submissions.txt")
                Dim line As String
                Do
                    line = reader.ReadLine()
                    If line IsNot Nothing Then
                        Dim parts As String() = line.Split("|"c)
                        If parts.Length = 5 Then
                            submissionsList.Add(New Submission With {
                                .Name = parts(0),
                                .Email = parts(1),
                                .Phone = parts(2),
                                .GitHub = parts(3),
                                .Time = parts(4)
                            })
                        End If
                    End If
                Loop Until line Is Nothing
            End Using
        End If
        Return submissionsList
    End Function

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious.PerformClick()
        End If
    End Sub

    Private Sub lblTime_Click(sender As Object, e As EventArgs) Handles lblTime.Click

    End Sub
End Class

Public Class Submission
    Public Property Name As String
    Public Property Email As String
    Public Property Phone As String
    Public Property GitHub As String
    Public Property Time As String
End Class
