using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IStudentRepo: IGenaricRepo<Student> 
    {
        Task<IEnumerable<Student>> SearchByName(string name);

        Task<IEnumerable<Student>> FilterStudentByGender(string gender);

        Task<IEnumerable<Student>> GetPage(int pagenumber , int pagesize);
    }
}
