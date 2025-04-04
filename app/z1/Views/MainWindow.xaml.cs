using System.Windows;
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
    }
}