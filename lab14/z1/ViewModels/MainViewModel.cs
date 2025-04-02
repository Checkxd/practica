using GradeJournal.Commands;
using GradeJournal.Models;
using GradeJournal.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GradeJournal.ViewModels
{
    public class JournalViewModel : INotifyPropertyChanged
    {
        private readonly JournalService _journalService;
        private bool _isLoading;

        public ObservableCollection<StudentModel> Students { get; set; }
        public ObservableCollection<CourseModel> Courses { get; set; }
        public ObservableCollection<GradeModel> Grades { get; set; }

        private GradeModel _selectedGrade;
        public GradeModel SelectedGrade
        {
            get => _selectedGrade;
            set
            {
                _selectedGrade = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public ICommand AddGradeCommand { get; }
        public ICommand EditGradeCommand { get; }
        public ICommand DeleteGradeCommand { get; }
        public ICommand ExportToExcelCommand { get; }
        public ICommand LoadDataCommand { get; }

        public JournalViewModel()
        {
            _journalService = new JournalService();
            Students = new ObservableCollection<StudentModel>();
            Courses = new ObservableCollection<CourseModel>();
            Grades = new ObservableCollection<GradeModel>();

            AddGradeCommand = new RelayCommand(AddGrade);
            EditGradeCommand = new RelayCommand(EditGrade, CanEditOrDelete);
            DeleteGradeCommand = new RelayCommand(DeleteGrade, CanEditOrDelete);
            ExportToExcelCommand = new RelayCommand(ExportToExcel);
            LoadDataCommand = new RelayCommand(async param => await LoadDataAsync());

            // Загрузка данных при старте
            LoadDataCommand.Execute(null);
        }

        private async Task LoadDataAsync()
        {
            IsLoading = true;
            var students = await _journalService.GetStudentsAsync();
            var courses = await _journalService.GetCoursesAsync();
            var grades = await _journalService.GetGradesAsync();

            Students.Clear();
            foreach (var student in students) Students.Add(student);
            Courses.Clear();
            foreach (var course in courses) Courses.Add(course);
            Grades.Clear();
            foreach (var grade in grades) Grades.Add(grade);
            IsLoading = false;
        }

        private void AddGrade(object parameter)
        {
            var newGrade = new GradeModel { Date = DateTime.Now };
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
                var gradeToEdit = new GradeModel
                {
                    Id = SelectedGrade.Id,
                    StudentId = SelectedGrade.StudentId,
                    CourseId = SelectedGrade.CourseId,
                    Value = SelectedGrade.Value,
                    IsPresent = SelectedGrade.IsPresent,
                    Comment = SelectedGrade.Comment,
                    Date = SelectedGrade.Date
                };

                var window = new GradeWindow(gradeToEdit)
                {
                    Owner = Application.Current.MainWindow
                };

                if (window.ShowDialog() == true)
                {
                    SelectedGrade.StudentId = gradeToEdit.StudentId;
                    SelectedGrade.CourseId = gradeToEdit.CourseId;
                    SelectedGrade.Value = gradeToEdit.Value;
                    SelectedGrade.IsPresent = gradeToEdit.IsPresent;
                    SelectedGrade.Comment = gradeToEdit.Comment;
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
        }

        private bool CanEditOrDelete(object parameter) => SelectedGrade != null;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}