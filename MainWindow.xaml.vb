Imports Microsoft.Win32
Imports MySql.Data.MySqlClient

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

    Private Sub submit_btn_Click(sender As Object, e As RoutedEventArgs) Handles submit_btn.Click
        Dim conn As New MySqlConnection()
        Dim student_name As String = Val(stdName.Text)
        Dim student_dob As String = datePicker.SelectedDate.ToString
        Dim student_add As String = Val(address.Text)
        Dim student_gender As String = "Male"
        If maleBtn.IsChecked Then
            student_gender = "Male"

        ElseIf femaleBtn.IsChecked Then
            student_gender = "Female"
        End If

        Dim student_courseName As String = coursesList.Items(coursesList.SelectedIndex)
        Dim student_img As String = studentImage.Source.ToString


        conn.ConnectionString = "server=localhost,33602;database=studentadmissionsystem;uid=root;password=sarthakP@2407"

        Try
            conn.Open()

            Dim sql As String = "INSERT INTO students (student_name, student_dob, student_gender, address, course_name, student_image) VALUES (@student_name, @student_dob, @student_gender, @address, @course_name, @student_image)"
            Dim cmd As New MySqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("@student_name", student_name)
            cmd.Parameters.AddWithValue("@student_dob", DateTime.Parse(student_dob))
            cmd.Parameters.AddWithValue("@student_gender", student_gender)
            cmd.Parameters.AddWithValue("@address", student_add)
            cmd.Parameters.AddWithValue("@course_name", student_courseName)
            cmd.Parameters.AddWithValue("@student_image", studentImage)

            cmd.ExecuteNonQuery()

            conn.Close()
            MessageBox.Show("Application Submitted Succesfully")
        Catch ex As MySqlException
            MessageBox.Show("Error connecting to database: " & ex.Message)
        Catch ex As Exception
            MessageBox.Show("Unknown Error occured")

        Finally
            conn.Dispose()
        End Try
    End Sub
End Class
