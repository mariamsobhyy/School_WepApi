using School_WepApi.Models;

namespace School_WepApi.REPOs.Intarfaces
{
    public interface IClassroom :IGenaricRepo<ClassRoom>
    {

        ClassRoom EndPoint3(int capacity);
        ClassRoom EndPoint5(string name);
        ClassRoom EndPoint8(int index);
        bool EndPoint10(int gradelevel, int capacity);
    }
}
