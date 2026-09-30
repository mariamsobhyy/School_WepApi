using Microsoft.EntityFrameworkCore;
using School_WepApi.Data;
using School_WepApi.REPOs.Intarfaces;

namespace School_WepApi.REPOs.Implementations
{
    public class GenaricRepo<T> : IGenaricRepo<T> where T : class
    {

        private readonly AppDbContext _context;

        public DbSet<T> db;

        public GenaricRepo(AppDbContext context)
        {
            _context = context;
            db = _context.Set<T>();
        }
        public void Add(T Entity)
        {
          db.Add(Entity);

        }

        public void Delete(T Entity)
        {
            db.Remove(Entity);
        }

        public ICollection<T> GetAll()
        {
            return db.ToList();
        }

        public T GetById(int id)
        {
            return db.Find(id);
        }

        public void Update(T Entity)
        {
            db.Update(Entity);
        }

        public void SaveChanges ()
        {
            _context.SaveChanges();
        }
    }
}
