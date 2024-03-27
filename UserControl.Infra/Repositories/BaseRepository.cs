using Microsoft.EntityFrameworkCore;
using UserControl.Domain.Interfaces.Repositories;
using UserControl.Infra.Contexts;

namespace UserControl.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlContexts _context;

        public BaseRepository(SqlContexts context) 
            : base()
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            return _context.Set<TEntity>().FindAsync(id).AsTask();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task DeleteAsync(Guid id)
        {
            var data = await _context.Set<TEntity>().FindAsync(id).AsTask();
            _context.Remove(data);
            _context.SaveChanges();
        }
    }
}
