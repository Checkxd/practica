using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using z1.Commands;
using z1.Models;
using z1.Services;
using z1.Views;

namespace z1.ViewModels
{
    public class JournalViewModel : INotifyPropertyChanged
    {
        private readonly JournalService _journalService;
        private bool _isLoading;
        private StudentModel _selectedStudent;
        private string _newStudentLastName;

        public ObservableCollection<StudentModel> Students { get; } = new();

        public StudentModel SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string NewStudentLastName
        {
            get => _newStudentLastName;
            set
            {
                _newStudentLastName = value;
                OnPropertyChanged();
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddStudentCommand { get; }
        public ICommand AddGradeCommand { get; }
        public ICommand DeleteGradeCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand ExportCommand { get; }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public JournalViewModel()
        {
            _journalService = new JournalService();

            AddStudentCommand = new RelayCommand(AddStudent, CanAddStudent);
            AddGradeCommand = new RelayCommand(AddGrade, CanModifyGrade);
            DeleteGradeCommand = new RelayCommand(DeleteGrade, CanModifyGrade);
            SaveCommand = new RelayCommand(Save);
            ExportCommand = new RelayCommand(Export);

            LoadStudents();
        }

        private bool CanAddStudent(object parameter) => !string.IsNullOrWhiteSpace(NewStudentLastName);
        private bool CanModifyGrade(object parameter) => SelectedStudent != null;

        private async void LoadStudents()
        {
            IsLoading = true;
            try
            {
                var loadedStudents = await _journalService.LoadStudentsAsync();
                Students.Clear();
                foreach (var student in loadedStudents)
                {
                    Students.Add(student);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void AddStudent(object parameter)
        {
            try
            {
                var newStudent = new StudentModel
                {
                    Id = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1,
                    LastName = NewStudentLastName.Trim()
                };

                Students.Add(newStudent);
                SelectedStudent = newStudent;
                NewStudentLastName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении студента: {ex.Message}");
            }
        }

        private void AddGrade(object parameter)
        {
            if (SelectedStudent == null) return;

            var gradeWindow = new GradeWindow();
            if (gradeWindow.ShowDialog() == true)
            {
                SelectedStudent.Grades.Add(new GradeModel
                {
                    Value = gradeWindow.GradeValue,
                    Comment = gradeWindow.Comment,
                    Date = DateTime.Now
                });
            }
        }

        private void DeleteGrade(object parameter)
        {
            if (SelectedStudent == null || !SelectedStudent.Grades.Any()) return;

            if (MessageBox.Show("Удалить последнюю оценку?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                SelectedStudent.Grades.RemoveAt(SelectedStudent.Grades.Count - 1);
            }
        }

        private void Save(object parameter)
        {
            MessageBox.Show("Данные сохранены", "Сохранение");
        }

        private void Export(object parameter)
        {
            MessageBox.Show("Экспорт выполнен", "Экспорт");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}