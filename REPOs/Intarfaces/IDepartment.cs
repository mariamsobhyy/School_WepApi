using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IDepartment :IGenaricRepo<Department>
    {
        Department SearchByTeacherName(string fullName);
    }
}
