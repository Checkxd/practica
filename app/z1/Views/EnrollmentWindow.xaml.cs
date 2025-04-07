using System.Windows;
using z1.Models;

namespace z1.Views
{
    public partial class EnrollmentWindow : Window
    {
        public Course SelectedCourse { get; set; }

        public EnrollmentWindow(System.Collections.ObjectModel.ObservableCollection<Course> courses)
        {
            InitializeComponent();
            DataContext = courses;
        }

        private void Enroll_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCourse != null)
            {
                DialogResult = true;
                Close();
            }
        }
    }
}