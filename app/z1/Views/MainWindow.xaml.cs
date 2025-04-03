using System.Windows;
using z1.ViewModels;

namespace z1.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new JournalViewModel();
        }
    }
}