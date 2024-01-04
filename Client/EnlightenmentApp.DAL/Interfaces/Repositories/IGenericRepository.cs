using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.DAL.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<IEnumerable<TEntity>> GetEntities(CancellationToken ct);
        public Task<TEntity?> GetById(int id, CancellationToken ct);
        public Task<TEntity> Add(TEntity entity, CancellationToken ct);
        public Task<TEntity> Update(TEntity entity, CancellationToken ct);
        public Task<TEntity?> Delete(int id, CancellationToken ct);
        public Task<bool> EntityExists(TEntity entity, CancellationToken ct);
        public Task<bool> EntityExists(int id, CancellationToken ct);
    }
}
