Imports Microsoft.Win32

Class MainWindow
    Public Property Courses As List(Of String)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Courses = New List(Of String) From {"Computer Engineering", "Civil Engineering", "Electrical Engineering", "Mechanical Engineering"}
        Me.DataContext = Me

        'im selectedCourse As String = coursesList.SelectedItem.ToString()
        Try

            'Dim SelectedCourse As String = coursesList.SelectedItem.ToString()
        Catch ex As Exception
            Console.WriteLine("Null")


        End Try








    End Sub

    Private Sub fileButton_Click(sender As Object, e As RoutedEventArgs) Handles fileButton.Click
        Dim dlg As New Microsoft.Win32.OpenFileDialog()
        dlg.Title = "Select an immage file"
        dlg.Filter = "Image Files (*.bmp, *jpg, *.png)|*.bmp;*jpg;*png"
        If dlg.ShowDialog() = True Then
            Dim imagePath As String = dlg.FileName
            Dim image As New BitmapImage(New Uri(imagePath))
            studentImage.Source = image




        End If




    End Sub
End Class
