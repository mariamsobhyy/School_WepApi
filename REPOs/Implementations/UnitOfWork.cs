using School_WepApi.Data;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public IStudentRepo Students { get; }

        public ITeacher Teachers { get; }

        public ICourseRepo Courses { get; }

        public IEnrollment Enrollments { get; }

        public IReportRepo Reports { get; }



        public UnitOfWork(AppDbContext context, IStudentRepo studentRepo, ITeacher teacherRepo, ICourseRepo courseRepo, IEnrollment enrollmentRepo, IReportRepo reports)
        {
            _context = context;
            Students = studentRepo;
            Teachers = teacherRepo;
            Courses = courseRepo;
            Enrollments = enrollmentRepo;
            Reports = reports;
        }



        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
 