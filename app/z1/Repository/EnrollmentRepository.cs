using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using z1.Data;
using z1.Models;

namespace z1.Repositories
{
    public class EnrollmentRepository
    {
        private readonly JournalDbContext _context;

        public EnrollmentRepository(JournalDbContext context)
        {
            _context = context;
        }

        public async Task<ObservableCollection<Enrollment>> GetAllAsync()
        {
            return new ObservableCollection<Enrollment>(
                await _context.Enrollments
                    .Include(e => e.Student)
                    .Include(e => e.Course)
                    .ToListAsync());
        }

        public async Task AddAsync(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int studentId, int courseId)
        {
            var enrollment = await _context.Enrollments.FindAsync(studentId, courseId);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
        }
    }
}