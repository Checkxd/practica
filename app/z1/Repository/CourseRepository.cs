using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using z1.Data;
using z1.Models;

namespace z1.Repositories
{
    public class CourseRepository
    {
        private readonly JournalDbContext _context;

        public CourseRepository(JournalDbContext context)
        {
            _context = context;
        }

        public async Task<ObservableCollection<Course>> GetAllAsync()
        {
            return new ObservableCollection<Course>(await _context.Courses.Include(c => c.Enrollments).ToListAsync());
        }

        public async Task AddAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }
    }
}