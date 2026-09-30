using School_WepApi.DTOs;
using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface ITeacher : IGenaricRepo<Teacher>
    {
        ICollection<Teacher> GetTeachersWithDepartment();
        ICollection<Teacher> Filter(int id, int salary);
       
    }
}
