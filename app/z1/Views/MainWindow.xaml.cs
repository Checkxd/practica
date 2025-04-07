using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using z1.Models;
using z1.ViewModels;

namespace z1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();
            DataContext = new JournalViewModel(user);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var animation = (System.Windows.Media.Animation.Storyboard)FindResource("FadeInAnimation");
            animation.Begin(MainGrid);
        }

        private void StudentsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedItem is Student student)
            {
                new StudentProgressWindow(student).ShowDialog();
            }
        }
    }
}