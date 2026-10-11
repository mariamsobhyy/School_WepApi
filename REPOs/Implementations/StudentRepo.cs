using Microsoft.EntityFrameworkCore;
using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class StudentRepo : GenaricRepo<Student> , IStudentRepo
    {
        private readonly AppDbContext _context;

        public StudentRepo (AppDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> FilterStudentByGender(string gender)
        {
            return await _context.students.Include(s=> s.StudentProfile)
                .Where(g => g.Gender.ToLower() == gender.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetPage(int pagenumber, int pagesize)
        {
            return await _context.students.Include(s => s.StudentProfile)
                .OrderBy(d => d.Id)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> SearchByName(string name)
        {
           return await _context.students.Include(s => s.StudentProfile)
              .Where(f => f.FullName.Contains(name)).ToListAsync();
        }
    }
}
