using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using z1.Models;
using z1.ViewModels;
using z1.Views;

namespace z1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() != true)
            {
                Close();
                return;
            }
            DataContext = new JournalViewModel(loginWindow.CurrentUser);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var fadeIn = (Storyboard)FindResource("FadeInAnimation");
            fadeIn.Begin(MainGrid);
        }

        private void StudentsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (StudentsListView.SelectedItem is StudentModel selectedStudent)
            {
                var progressWindow = new StudentProgressWindow(selectedStudent);
                progressWindow.ShowDialog();
            }
        }
    }
}