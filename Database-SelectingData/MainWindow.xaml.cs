using Database_SelectingData.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database_SelectingData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (StudentList.SelectedItem is Student s)
            {
                string details = $"Student ID: {s.StudentId}\n" +
                                 $"Name: {s.FirstName} {s.LastName}\n" +
                                 $"Favorite Color: {s.FavoriteColor}\n" +
                                 $"Courses Enrolled: {s.Registrations.Count}";
                MessageBox.Show(details, "Student Details");

                // Show student's courses in the bottom ListBox
                RegisteredCoursesList.ItemsSource = s.Registrations
                    .Select(r => $"{r.Course.CourseName} ({r.EnrollmentDate:d})")
                    .ToList();
            }
        }

        private void CourseList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CourseList.SelectedItem is Course c)
            {
                string details = $"Course ID: {c.CourseId}\n" +
                                 $"Course Name: {c.CourseName}\n" +
                                 $"Course Number: {c.CourseNumber}\n" +
                                 $"Term Code: {c.TermCode}\n" +
                                 $"Students Enrolled: {c.Registrations.Count}";
                MessageBox.Show(details, "Course Details");
            }
        }
    }
}