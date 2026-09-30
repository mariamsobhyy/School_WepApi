using School_WepApi.DTOs;
using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface Isubject :IGenaricRepo<Subject>
    {

        ICollection<Subject> GetSubjectsWithTeachers();
        Subject EndPoint2(int id);
        Subject EndPoint7(int teacherid);
        bool EndPoint11(int subid1, int subid2, int subid3);
        ICollection<SubjectDTOEndPoint13> EndPoint13(int teacherid);
        ICollection<Subject> EndPoint14(int departmentid);
        ICollection<Subject> EndPoint16();
    }
}
