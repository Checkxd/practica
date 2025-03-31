using System.Windows;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace ElectronicJournal
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> MathStudents { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Student> PhysicsStudents { get; set; } = new ObservableCollection<Student>();
        public ObservableCollection<Student> HistoryStudents { get; set; } = new ObservableCollection<Student>();

        public ObservableCollection<Student> CurrentStudents =>
            (SubjectsComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() switch
            {
                "Математика" => MathStudents,
                "Физика" => PhysicsStudents,
                "История" => HistoryStudents,
                _ => new ObservableCollection<Student>()
            };

        public MainWindow()
        {
            InitializeComponent();
            StudentsDataGrid.ItemsSource = CurrentStudents;
            LoadData();  // Загрузка данных при открытии приложения
        }

        // Метод для загрузки данных из текстового файла
        // Метод для загрузки данных из текстового файла
        private void LoadData()
        {
            if (File.Exists("students.txt"))
            {
                var lines = File.ReadAllLines("students.txt");

                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 4) // Учитывая, что у нас 4 части теперь: ФИО, Оценка, Комментарий, Предмет
                    {
                        var student = new Student
                        {
                            FullName = parts[0].Trim(),
                            Grade = int.TryParse(parts[1].Trim(), out int gradeValue) ? gradeValue : 0,
                            Comment = parts[2].Trim()
                        };

                        // Добавление студента в соответствующую коллекцию
                        if (parts[3].Trim() == "Математика")
                            MathStudents.Add(student);
                        else if (parts[3].Trim() == "Физика")
                            PhysicsStudents.Add(student);
                        else if (parts[3].Trim() == "История")
                            HistoryStudents.Add(student);
                    }
                }
            }
        }

        // Метод для сохранения данных в текстовый файл
        // Метод для сохранения данных в текстовый файл
        private void SaveData()
        {
            var sb = new StringBuilder();

            foreach (var student in MathStudents)
            {
                sb.AppendLine($"{student.FullName}, {student.Grade}, {student.Comment}, Математика");
            }

            foreach (var student in PhysicsStudents)
            {
                sb.AppendLine($"{student.FullName}, {student.Grade}, {student.Comment}, Физика");
            }

            foreach (var student in HistoryStudents)
            {
                sb.AppendLine($"{student.FullName}, {student.Grade}, {student.Comment}, История");
            }

            // Запись в файл
            File.WriteAllText("students.txt", sb.ToString());
        }

        private void SubjectsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            StudentsDataGrid.ItemsSource = CurrentStudents;
        }

        private void AddGradeButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = SubjectsComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            ObservableCollection<Student> students = CurrentStudents;
            string fullName = FullNameTextBox.Text;
            string grade = GradeTextBox.Text;
            string comment = CommentTextBox.Text;

            if (int.TryParse(grade, out int gradeValue) && gradeValue >= 0 && gradeValue <= 100)
            {
                students.Add(new Student { FullName = fullName, Grade = gradeValue, Comment = comment });
                FullNameTextBox.Clear();
                GradeTextBox.Clear();
                CommentTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректную оценку от 0 до 100.");
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            SaveData(); // Сохранение данных при закрытии приложения
            base.OnClosing(e);
        }
    }

    public class Student
    {
        public string FullName { get; set; } = string.Empty;
        public int Grade { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}