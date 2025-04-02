using GradeJournal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using z1.Models;

namespace GradeJournal.Services
{
    public class JournalService
    {
        public async Task<List<StudentModel>> GetStudentsAsync()
        {
            // Имитация загрузки студентов
            await Task.Delay(3000);
            return new List<StudentModel>
            {
                new StudentModel { Id = 1, Name = "Иванов" },
                new StudentModel { Id = 2, Name = "Петров" }
            };
        }

        public async Task<List<CourseModel>> GetCoursesAsync()
        {
            // Имитация загрузки курсов
            await Task.Delay(1000);
            return new List<CourseModel>
            {
                new CourseModel { Id = 1, Name = "Математика" },
                new CourseModel { Id = 2, Name = "Физика" }
            };
        }

        public async Task<List<GradeModel>> GetGradesAsync()
        {
            // Имитация загрузки оценок
            await Task.Delay(2000);
            return new List<GradeModel>
            {
                new GradeModel { Id = 1, StudentId = 1, CourseId = 1, Value = 4.5, IsPresent = true, Comment = "Хорошо", Date = DateTime.Now },
                new GradeModel { Id = 2, StudentId = 2, CourseId = 2, Value = 3.0, IsPresent = false, Comment = "Пропуск", Date = DateTime.Now }
            };
        }
    }
}