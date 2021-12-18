using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lingo.Data
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, new()
    {
        protected readonly LingoContext _context;
        protected readonly DbSet<T> DbSet;

        public GenericRepo(LingoContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }
        
        // public async Task<T> GetByIdAsync(int id)
        // {
        //     var entity = await DbSet.FindAsync(id);
        //     return entity;
        // }

        // public async Task<IEnumerable<T>> GetAllAsync()
        // {
        //     var entities = await DbSet.AsNoTracking().ToListAsync();
        //     return entities;
        // }

        // public async Task DeleteAsync(int id)
        // {
        //     var entityToDelete = await GetByIdAsync(id);
        //     DbSet.Remove(entityToDelete);
        // }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        // public async Task UpdateAsync(T entity)
        // {
        //     // DbSet.Attach(entity); //not sure if this is really needed
        //     DbSet.Update(entity);
        // }
    }
}