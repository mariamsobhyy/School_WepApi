using Microsoft.EntityFrameworkCore;
using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class DepartmentCustomRepo : GenaricRepo<Department>, IDepartment
    {
        private readonly AppDbContext _context;

        public DepartmentCustomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Department SearchByTeacherName(string fullName)
        {
            return _context.departments .Include(x => x.Teachers)
                .FirstOrDefault(x => x.Teachers
                .Any(t => (t.FirstName + " " + t.LastName)
                        .Contains(fullName)));
        }
    }
}