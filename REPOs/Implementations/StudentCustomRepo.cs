using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace School_WepApi.REPOs.Implementations
{
    public class StudentCustomRepo :GenaricRepo<Student> , IStudent
    {

        private readonly AppDbContext _context;
        public StudentCustomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Student> IncludeClassRoom()
        {
            return  _context.students .Include(x => x.ClassRoom) .ToList();
        }
    }
}
