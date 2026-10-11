using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface ICourseRepo :IGenaricRepo<Course>
    {
        Task<IEnumerable<Course>> Searchcoursesbytitle(string title);

        Task <IEnumerable<Course>> FilterCourses(int? teacherid , int? credithours);

        Task <bool> HasStudent(int courseid);
    }
}
