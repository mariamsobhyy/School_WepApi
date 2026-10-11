using Microsoft.EntityFrameworkCore;
using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class TeacherCustomRepo : GenaricRepo<Teacher>, ITeacher
    {

        private readonly AppDbContext _context;

        public TeacherCustomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> HasCoursesAsync(int teacherId)
        {
            return await _context.teachers.AnyAsync(t => t.Id == teacherId);
        }
    }
}
