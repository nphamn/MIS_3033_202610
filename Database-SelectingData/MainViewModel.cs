using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Database_SelectingData.Models;

namespace Database_SelectingData.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Course> Courses { get; set; } = new ObservableCollection<Course>();

        public MainViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            using var db = new DB_128040_practiceContext();

            Students = new ObservableCollection<Student>(
                db.Students
                  .Include(s => s.Registrations)
                  .ThenInclude(r => r.Course)
                  .ToList());

            Courses = new ObservableCollection<Course>(
                db.Courses
                  .Include(c => c.Registrations)
                  .ThenInclude(r => r.Student)
                  .ToList());
        }
    }
}
