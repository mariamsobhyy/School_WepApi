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
        public async Task Add(T Entity)
        {
          await db.AddAsync(Entity);

        }

        public async Task Delete(int id)
        {
            var entity = await db.FindAsync(id);
            if (entity != null)
            {
                db.Remove(entity);
            }
        }

        public async Task  <ICollection<T>> GetAll()
        {
            return await db.ToListAsync();
        }

        public async Task <T>GetById(int id)
        {
            return await db.FindAsync(id);
        }

        public void Update(T Entity)
        {
            db.Update(Entity);
        }

    }
}
