using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;
using Microsoft.EntityFrameworkCore;

namespace School_WepApi.REPOs.Implementations
{
    public class EnrollmentCustomRepo : GenaricRepo <Enrollment> , IEnrollment
    {
        private readonly AppDbContext _context;
        public EnrollmentCustomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public ICollection<Enrollment> GetEnrollmentsWithStudentAndSubject()
        {
            return _context.enrollments
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .ToList();
        }
        public Enrollment EndPoint6(int subjectid)
        {
            return  _context.enrollments
                .Include(x => x.Subject)
                .Include(x => x.Student)
                .OrderBy(x => x.EnrollmentDate)
                .Last(x => x.SubjectId == subjectid);
        }
    }
}
