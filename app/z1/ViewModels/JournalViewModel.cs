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
        private readonly NotificationService _notificationService;
        private readonly ChatService _chatService;
        private readonly User _currentUser;
        private bool _isLoading;
        private StudentModel _selectedStudent;
        private string _newStudentLastName;
        private string _chatMessage;

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

        public string ChatMessage
        {
            get => _chatMessage;
            set
            {
                _chatMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddStudentCommand { get; }
        public ICommand AddGradeCommand { get; }
        public ICommand DeleteGradeCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand ExportCommand { get; }
        public ICommand SendChatMessageCommand { get; }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public JournalViewModel(User currentUser)
        {
            _journalService = new JournalService();
            _notificationService = new NotificationService();
            _chatService = new ChatService();
            _currentUser = currentUser;

            AddStudentCommand = new RelayCommand(AddStudent, CanAddStudent);
            AddGradeCommand = new RelayCommand(AddGrade, CanModifyGrade);
            DeleteGradeCommand = new RelayCommand(DeleteGrade, CanModifyGrade);
            SaveCommand = new RelayCommand(Save);
            ExportCommand = new RelayCommand(Export);
            SendChatMessageCommand = new RelayCommand(SendChatMessage);

            LoadStudents();
            CheckNotifications();
            StartChatListener();
        }

        private bool CanAddStudent(object parameter) => !string.IsNullOrWhiteSpace(NewStudentLastName) && _currentUser.Role == "Teacher";
        private bool CanModifyGrade(object parameter) => SelectedStudent != null && _currentUser.Role == "Teacher";

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

        private async void AddStudent(object parameter)
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
                await _journalService.SaveStudentsAsync(Students);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении студента: {ex.Message}");
            }
        }

        private async void AddGrade(object parameter)
        {
            if (SelectedStudent == null) return;

            var gradeWindow = new GradeWindow();
            if (gradeWindow.ShowDialog() == true)
            {
                var newGrade = new GradeModel
                {
                    Value = gradeWindow.GradeValue,
                    Comment = gradeWindow.Comment,
                    Date = DateTime.Now
                };
                _journalService.AddGrade(SelectedStudent, newGrade, Students); // Передаем весь список студентов
                _notificationService.SendNotification($"Новая оценка для {SelectedStudent.LastName}: {gradeWindow.GradeValue}");
            }
        }

        private async void DeleteGrade(object parameter)
        {
            if (SelectedStudent == null || !SelectedStudent.Grades.Any()) return;

            if (MessageBox.Show("Удалить последнюю оценку?", "Подтверждение",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                SelectedStudent.Grades.RemoveAt(SelectedStudent.Grades.Count - 1);
                await _journalService.SaveStudentsAsync(Students);
            }
        }

        private async void Save(object parameter)
        {
            await _journalService.SaveStudentsAsync(Students);
            MessageBox.Show("Данные сохранены", "Сохранение");
        }

        private void Export(object parameter)
        {
            MessageBox.Show("Экспорт выполнен", "Экспорт");
        }

        private void CheckNotifications()
        {
            var notification = _notificationService.ReceiveNotification();
            if (!string.IsNullOrEmpty(notification))
            {
                MessageBox.Show(notification, "Уведомление");
            }
        }

        private async void SendChatMessage(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(ChatMessage))
            {
                await _chatService.SendMessageAsync($"{_currentUser.Username}: {ChatMessage}");
                ChatMessage = string.Empty;
            }
        }

        private async void StartChatListener()
        {
            while (true)
            {
                var message = await _chatService.ReceiveMessageAsync();
                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "Сообщение в чате");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}