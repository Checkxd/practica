using System.Windows;
using z1.Models;

namespace z1.Views
{
    public partial class StudentProgressWindow : Window
    {
        public StudentProgressWindow(StudentModel student)
        {
            InitializeComponent();
            DataContext = student;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}