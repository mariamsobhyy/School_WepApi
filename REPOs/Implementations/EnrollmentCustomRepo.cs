using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace School_WepApi.REPOs.Implementations
{
    public class EnrollmentCustomRepo : GenaricRepo<Enrollment>, IEnrollment
    {
        private readonly AppDbContext _context;
        public EnrollmentCustomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enrollment>> GetByCourseAsync(int courseid)
        {
            return await _context.enrollments
                .Include(c => c.Course)
                .Include(s => s.Student)
                .Where(c => c.CourseId == courseid)
                .ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> GetByStudentAsync(int studentid)
        {
            return await _context.enrollments
                 .Include(c => c.Student)
                 .Include(s => s.Student)
                 .Where(s => s.StudentId == studentid)
                 .ToListAsync();
        }

        public async Task<bool> IsStudentEnrolledAsync(int studentId, int courseId)
        {
            return await _context.enrollments
                .AnyAsync(e =>
                    e.StudentId == studentId &&
                    e.CourseId == courseId);
        }
    }
}
