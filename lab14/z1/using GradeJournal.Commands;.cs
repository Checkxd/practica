using GradeJournal.ViewModels;
using System.Windows;

namespace GradeJournal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}