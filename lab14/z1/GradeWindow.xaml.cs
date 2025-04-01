using GradeJournal.Models;
using System.Windows;

namespace GradeJournal
{
    public partial class GradeWindow : Window
    {
        public GradeWindow(Grade grade)
        {
            InitializeComponent();
            DataContext = grade;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}