using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IEnrollment :IGenaricRepo<Enrollment>
    {
       ICollection<Enrollment> GetEnrollmentsWithStudentAndSubject();
        Enrollment EndPoint6(int subjectid);
    }
}
