using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.DAL.Interfaces
{
    public interface IPathRepository
    {
        public Task<IEnumerable<PathEntity>> GetPaths(CancellationToken ct);
        public Task<PathEntity> GetPathById(int id, CancellationToken ct);
        public Task<PathEntity> AddPath(PathEntity pathEntity, CancellationToken ct);
        public Task<PathEntity> UpdatePath(PathEntity pathEntity, CancellationToken ct);
        public Task<bool> DeletePath(int id, CancellationToken ct);
        public Task<bool> PathExists(PathEntity pathEntity, CancellationToken ct);
    }
}
