using System.Windows;
using z1.Models;

namespace z1.Views
{
    public partial class StudentProgressWindow : Window
    {
        public StudentProgressWindow(Student student)
        {
            InitializeComponent();
            DataContext = student;
        }
    }
}