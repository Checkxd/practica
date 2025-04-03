using System.Collections.ObjectModel;
using System.Threading.Tasks;
using z1.Models;

namespace z1.Services
{
    public class JournalService
    {
        public async Task<ObservableCollection<StudentModel>> LoadStudentsAsync()
        {
            await Task.Delay(1000); // Имитация загрузки
            return new ObservableCollection<StudentModel>();
        }

        public void AddGrade(StudentModel student, GradeModel grade)
        {
            student.Grades.Add(grade);
        }
    }
}