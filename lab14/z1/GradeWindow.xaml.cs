using GradeJournal.Models;
using System.Windows;

namespace GradeJournal
{
    public partial class GradeWindow : Window
    {
        public GradeWindow(GradeModel grade)
        {
            InitializeComponent();
            DataContext = grade;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var grade = (GradeModel)DataContext;
            if (grade.StudentId == 0 || grade.CourseId == 0 || grade.Value == 0)
            {
                MessageBox.Show("Заполните ID студента, ID курса и оценку.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }
    }
}