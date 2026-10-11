using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IUnitOfWork
    {
        IStudentRepo Students { get; }

        ITeacher Teachers { get; }

        ICourseRepo Courses { get; }

        IEnrollment Enrollments { get; }

        IReportRepo Reports { get; }


        Task<int> Save();
    }
}
