using School_WepApi.DTOs;
using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface ITeacher : IGenaricRepo<Teacher>
    {

        Task<bool> HasCoursesAsync(int teacherId);


    }
}
