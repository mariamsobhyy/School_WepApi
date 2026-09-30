using Microsoft.EntityFrameworkCore;
using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class TeacherCustomRepo : GenaricRepo<Teacher>, ITeacher
    {

        private readonly AppDbContext _context;

        public TeacherCustomRepo (AppDbContext context) :base(context)
        {
            _context = context;
        }

        public ICollection<Teacher> Filter(int id, int salary)
        {
           var m = _context.teachers.Where(x => x.Id == id && x.Salary >= salary) .ToList();
            return m;
        }

        public ICollection<Teacher> GetTeachersWithDepartment()
        {
            return _context.teachers.Include( x => x.Department).ToList();
        }
    }
}
