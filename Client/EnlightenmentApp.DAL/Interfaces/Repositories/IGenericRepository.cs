using EnlightenmentApp.DAL.Interfaces.Entities;

namespace EnlightenmentApp.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        public Task<IEnumerable<TEntity>> GetEntities(CancellationToken ct);
        public Task<TEntity> GetById(int id, CancellationToken ct);
        public Task<TEntity> Add(TEntity entity, CancellationToken ct);
        public Task<TEntity> Update(TEntity entity, CancellationToken ct);
        public Task<bool> Delete(int id, CancellationToken ct);
        public Task<bool> EntityExists(TEntity entity, CancellationToken ct);
    }
}
