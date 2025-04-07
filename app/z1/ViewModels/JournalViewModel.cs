using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using z1.Commands;
using z1.Data;
using z1.Models;
using z1.Repositories;
using z1.Services;
using z1.Views;

namespace z1.ViewModels
{
    public class JournalViewModel : INotifyPropertyChanged
    {
        private readonly JournalDbContext _context;
        private readonly StudentRepository _studentRepo;
        private readonly CourseRepository _courseRepo;
        private readonly EnrollmentRepository _enrollmentRepo;
        private readonly NotificationService _notificationService;
        private readonly ChatService _chatService;
        private readonly User _currentUser;
        private bool _isLoading;
        private Student _selectedStudent;
        private string _newStudentLastName;
        private string _chatMessage;

        public ObservableCollection<Student> Students { get; } = new();
        public ObservableCollection<Course> Courses { get; } = new();
        public ObservableCollection<Enrollment> Enrollments { get; } = new();

        public Student SelectedStudent
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
        public ICommand EnrollStudentCommand { get; }
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
            _context = new JournalDbContext();
            _studentRepo = new StudentRepository(_context);
            _courseRepo = new CourseRepository(_context);
            _enrollmentRepo = new EnrollmentRepository(_context);
            _notificationService = new NotificationService();
            _chatService = new ChatService();
            _currentUser = currentUser;

            AddStudentCommand = new RelayCommand(AddStudent, CanAddStudent);
            EnrollStudentCommand = new RelayCommand(EnrollStudent, CanModifyGrade);
            AddGradeCommand = new RelayCommand(AddGrade, CanModifyGrade);
            DeleteGradeCommand = new RelayCommand(DeleteGrade, CanModifyGrade);
            SaveCommand = new RelayCommand(Save);
            ExportCommand = new RelayCommand(Export);
            SendChatMessageCommand = new RelayCommand(SendChatMessage);

            LoadData();
            CheckNotifications();
            StartChatListener();
        }

        private bool CanAddStudent(object parameter) => !string.IsNullOrWhiteSpace(NewStudentLastName) && _currentUser.Role == "Teacher";
        private bool CanModifyGrade(object parameter) => SelectedStudent != null && _currentUser.Role == "Teacher";

        private async void LoadData()
        {
            IsLoading = true;
            try
            {
                var students = await _studentRepo.GetAllAsync();
                Students.Clear();
                foreach (var student in students) Students.Add(student);

                var courses = await _courseRepo.GetAllAsync();
                Courses.Clear();
                foreach (var course in courses) Courses.Add(course);

                var enrollments = await _enrollmentRepo.GetAllAsync();
                Enrollments.Clear();
                foreach (var enrollment in enrollments) Enrollments.Add(enrollment);

                OnPropertyChanged(nameof(Students));
                OnPropertyChanged(nameof(Courses));
                OnPropertyChanged(nameof(Enrollments));
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
                var newStudent = new Student
                {
                    Id = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1,
                    LastName = NewStudentLastName.Trim()
                };
                await _studentRepo.AddAsync(newStudent);
                Students.Add(newStudent);
                SelectedStudent = newStudent;
                NewStudentLastName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении студента: {ex.Message}");
            }
        }

        private async void EnrollStudent(object parameter)
        {
            if (SelectedStudent == null) return;
            var enrollWindow = new EnrollmentWindow(Courses);
            if (enrollWindow.ShowDialog() == true)
            {
                var enrollment = new Enrollment
                {
                    StudentId = SelectedStudent.Id,
                    CourseId = enrollWindow.SelectedCourse.Id,
                    Date = DateTime.Now
                };
                await _enrollmentRepo.AddAsync(enrollment);
                SelectedStudent.Enrollments.Add(enrollment);
                Enrollments.Add(enrollment);
                OnPropertyChanged(nameof(Enrollments));
            }
        }

        private async void AddGrade(object parameter)
        {
            if (SelectedStudent == null) return;
            var gradeWindow = new GradeWindow();
            if (gradeWindow.ShowDialog() == true)
            {
                var enrollment = SelectedStudent.Enrollments.LastOrDefault();
                if (enrollment != null)
                {
                    enrollment.Grade = gradeWindow.GradeValue;
                    enrollment.Comment = gradeWindow.Comment;
                    enrollment.Date = DateTime.Now;
                    await _enrollmentRepo.UpdateAsync(enrollment);
                    _notificationService.SendNotification($"Новая оценка для {SelectedStudent.LastName}: {gradeWindow.GradeValue}");
                    OnPropertyChanged(nameof(Enrollments));
                    OnPropertyChanged(nameof(SelectedStudent));
                }
            }
        }

        private async void DeleteGrade(object parameter)
        {
            if (SelectedStudent == null || !SelectedStudent.Enrollments.Any()) return;
            if (MessageBox.Show("Удалить последнюю оценку?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var enrollment = SelectedStudent.Enrollments.Last();
                await _enrollmentRepo.DeleteAsync(enrollment.StudentId, enrollment.CourseId);
                SelectedStudent.Enrollments.Remove(enrollment);
                Enrollments.Remove(enrollment);
                OnPropertyChanged(nameof(Enrollments));
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        private async void Save(object parameter)
        {
            await _context.SaveChangesAsync();
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