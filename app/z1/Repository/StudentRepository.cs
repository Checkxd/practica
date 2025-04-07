using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using z1.Data;
using z1.Models;

namespace z1.Repositories
{
    public class StudentRepository
    {
        private readonly JournalDbContext _context;

        public StudentRepository(JournalDbContext context)
        {
            _context = context;
        }

        public async Task<ObservableCollection<Student>> GetAllAsync()
        {
            return new ObservableCollection<Student>(await _context.Students.Include(s => s.Enrollments).ToListAsync());
        }

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}