using GradeJournal.Commands;
using GradeJournal.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace GradeJournal.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Grade> Grades { get; set; }
        private Grade _selectedGrade;

        public Grade SelectedGrade
        {
            get => _selectedGrade;
            set
            {
                _selectedGrade = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddGradeCommand { get; }
        public ICommand EditGradeCommand { get; }
        public ICommand DeleteGradeCommand { get; }
        public ICommand ExportToExcelCommand { get; }

        public MainViewModel()
        {
            Grades = new ObservableCollection<Grade>();
            AddGradeCommand = new RelayCommand(AddGrade);
            EditGradeCommand = new RelayCommand(EditGrade, CanEditOrDelete);
            DeleteGradeCommand = new RelayCommand(DeleteGrade, CanEditOrDelete);
            ExportToExcelCommand = new RelayCommand(ExportToExcel);

            // Пример начальных данных
            Grades.Add(new Grade { Id = 1, StudentName = "Иванов", Value = 4.5, Comment = "Хорошо", Date = DateTime.Now, IsPresent = true });
            Grades.Add(new Grade { Id = 2, StudentName = "Петров", Value = 3.0, Comment = "Пропуск", Date = DateTime.Now, IsPresent = false });
        }

        private void AddGrade(object parameter)
        {
            var newGrade = new Grade { Date = DateTime.Now };
            var window = new GradeWindow(newGrade)
            {
                Owner = Application.Current.MainWindow
            };

            if (window.ShowDialog() == true)
            {
                Grades.Add(newGrade);
            }
        }

        private void EditGrade(object parameter)
        {
            if (SelectedGrade != null)
            {
                var gradeToEdit = new Grade
                {
                    Id = SelectedGrade.Id,
                    StudentName = SelectedGrade.StudentName,
                    Value = SelectedGrade.Value,
                    Comment = SelectedGrade.Comment,
                    Date = SelectedGrade.Date,
                    IsPresent = SelectedGrade.IsPresent
                };

                var window = new GradeWindow(gradeToEdit)
                {
                    Owner = Application.Current.MainWindow
                };

                if (window.ShowDialog() == true)
                {
                    SelectedGrade.StudentName = gradeToEdit.StudentName;
                    SelectedGrade.Value = gradeToEdit.Value;
                    SelectedGrade.Comment = gradeToEdit.Comment;
                    SelectedGrade.IsPresent = gradeToEdit.IsPresent;
                }
            }
        }

        private void DeleteGrade(object parameter)
        {
            if (SelectedGrade != null &&
                MessageBox.Show("Вы уверены, что хотите удалить оценку?",
                              "Подтверждение",
                              MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Grades.Remove(SelectedGrade);
            }
        }

        private void ExportToExcel(object parameter)
        {
            MessageBox.Show("Экспорт в Excel пока не реализован.", "Информация");
            // Здесь можно добавить логику экспорта с использованием библиотеки, например, EPPlus
        }

        private bool CanEditOrDelete(object parameter) => SelectedGrade != null;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}