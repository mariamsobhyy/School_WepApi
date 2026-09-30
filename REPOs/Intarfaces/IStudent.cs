using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IStudent :IGenaricRepo<Student>
    {
        List<Student> IncludeClassRoom();
    }
}
