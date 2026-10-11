using Microsoft.EntityFrameworkCore;
using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class CourseRepo : GenaricRepo<Course>, ICourseRepo
    {

        private readonly AppDbContext _context;

        public CourseRepo (AppDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> FilterCourses(int? teacherid, int? credithours)
        {
            IQueryable<Course> query = _context.courses.Include(t => t.Teacher);


            if (teacherid.HasValue)
            {
               query = query.Where(t => t.TeacherId == teacherid);
            }

            if (credithours.HasValue)
            {
                query = query.Where(c => c.CreditHours == credithours);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> HasStudent(int courseid)
        {
            return await _context.enrollments.AnyAsync( s => s.CourseId == courseid);
        }

        public async Task<IEnumerable<Course>> Searchcoursesbytitle(string title)
        {
            return await _context.courses.Where(s => s.Title.Contains(title)).ToListAsync();
        }
    }
}
