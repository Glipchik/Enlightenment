using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected DatabaseContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            this._context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetEntities(CancellationToken ct)
        {
            var result = await _dbSet.AsNoTracking().ToListAsync(ct);
            return result;
        }

        public virtual async Task<TEntity?> GetById(int id, CancellationToken ct)
        {
            var result = await _dbSet.FindAsync(id, ct);
            return result;
        }

        public virtual async Task<TEntity> Add(TEntity entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity, CancellationToken ct)
        {
            var result = _context.Entry(entity);
            result.State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public virtual async Task<TEntity?> Delete(int id, CancellationToken ct)
        {
            var result = await _dbSet.FindAsync(id, ct);
            _dbSet.Remove(result);
            await _context.SaveChangesAsync(ct);
            return result;
        }

        public virtual async Task<bool> EntityExists(TEntity entity, CancellationToken ct)
        {
            var result = await _dbSet.AnyAsync(c => c.Id == entity.Id, ct);
            return result;
        }
    }
}
