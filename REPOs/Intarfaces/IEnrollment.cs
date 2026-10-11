using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IEnrollment :IGenaricRepo<Enrollment>
    {
      Task <IEnumerable<Enrollment>> GetByCourseAsync (int courseid);
      Task <IEnumerable<Enrollment>> GetByStudentAsync (int studentid);

        Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);


    }
}
