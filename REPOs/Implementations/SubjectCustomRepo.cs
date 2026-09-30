using School_WepApi.Data;
using School_WepApi.DTOs;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace School_WepApi.REPOs.Implementations
{
    public class SubjectCustomRepo : GenaricRepo<Subject> , Isubject
    {
        private readonly AppDbContext _context;

        public SubjectCustomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Subject EndPoint2(int id)
        {
            return _context.subjects
                .Include(x => x.Teacher)
                .First(x => x.TeacherId == id);
        }

        public Subject EndPoint7(int teacherId)
        {
            return _context.subjects
                .Include(x => x.Teacher)
                .OrderByDescending(x => x.Id)
                .LastOrDefault(x => x.TeacherId == teacherId);
        }

        public ICollection<Subject> GetSubjectsWithTeachers()
        {
            return _context.subjects
                .Include(x => x.Teacher)
                .ToList();
        }

        public bool EndPoint11(int subId1, int subId2, int subId3)
        {
            return _context.subjects
                .Any(x =>
                    x.Id == subId1 ||
                    x.Id == subId2 ||
                    x.Id == subId3);
        }

        public ICollection<SubjectDTOEndPoint13> EndPoint13(int teacherId)
        {
            return _context.subjects
                .Where(x => x.TeacherId == teacherId)
                .Select(x => new SubjectDTOEndPoint13
                {
                    Id = x.Id,
                    MaxGrade = x.MaxGrade,
                    Name = x.Name
                })
                .ToList();
        }

        public ICollection<Subject> EndPoint14(int departmentId)
        {
            return _context.departments
                .Where(d => d.Id == departmentId)
                .SelectMany(d => d.Teachers)
                .SelectMany(t => t.Subjects)
                .Distinct()
                .ToList();
        }

        public ICollection<Subject> EndPoint16()
        {
            return _context.subjects
                .OrderByDescending(x => x.MaxGrade)
                .ToList();
        }
    }
}
