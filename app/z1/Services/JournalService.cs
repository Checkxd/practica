using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using z1.Models;

namespace z1.Services
{
    public class JournalService
    {
        private const string JournalFilePath = "journal.json";

        public async Task<ObservableCollection<StudentModel>> LoadStudentsAsync()
        {
            if (!File.Exists(JournalFilePath))
            {
                var defaultJournal = new JournalData
                {
                    Students = new ObservableCollection<StudentModel>(),
                    Courses = new ObservableCollection<CourseModel>(),
                    Schedule = new ObservableCollection<ScheduleModel>()
                };
                var json = JsonSerializer.Serialize(defaultJournal, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(JournalFilePath, json);
            }

            try
            {
                var jsonData = await File.ReadAllTextAsync(JournalFilePath);
                var journal = JsonSerializer.Deserialize<JournalData>(jsonData);
                return journal?.Students ?? new ObservableCollection<StudentModel>();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при загрузке студентов: {ex.Message}");
                return new ObservableCollection<StudentModel>();
            }
        }

        public async Task SaveStudentsAsync(ObservableCollection<StudentModel> students)
        {
            try
            {
                var journal = new JournalData
                {
                    Students = students,
                    Courses = new ObservableCollection<CourseModel>(),
                    Schedule = new ObservableCollection<ScheduleModel>()
                };
                var json = JsonSerializer.Serialize(journal, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(JournalFilePath, json);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка при сохранении студентов: {ex.Message}");
            }
        }

        public async Task AddGrade(StudentModel student, GradeModel grade, ObservableCollection<StudentModel> allStudents)
        {
            student.Grades.Add(grade);
            await SaveStudentsAsync(allStudents); // Сохраняем весь список студентов
        }
    }

    public class JournalData
    {
        public ObservableCollection<StudentModel> Students { get; set; }
        public ObservableCollection<CourseModel> Courses { get; set; }
        public ObservableCollection<ScheduleModel> Schedule { get; set; }
    }

    public class ScheduleModel
    {
        public DateTime Date { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
}