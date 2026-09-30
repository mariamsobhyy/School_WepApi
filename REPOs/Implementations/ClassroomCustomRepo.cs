using School_WepApi.Data;
using School_WepApi.Models;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class ClassroomCustomRepo :GenaricRepo<ClassRoom> , IClassroom
    {
        private readonly AppDbContext _context;
        public ClassroomCustomRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ClassRoom EndPoint3(int capacity)
        {
            return  _context.classRooms
                .FirstOrDefault(x => x.Capacity == capacity);
        }
        public ClassRoom EndPoint5(string name)
        {
            return  _context.classRooms
                .SingleOrDefault(x => x.Name == name);
        }
        public ClassRoom EndPoint8(int index)
        {
            return  _context.classRooms
                .OrderBy(x => x.Id)
                .ElementAt(index);
        }
        public bool EndPoint10(int gradelevel, int capacity)
        {
            return  _context.classRooms
                .Any(x => x.GradeLevel >= gradelevel && x.Capacity >= capacity);
        }

    }
}

