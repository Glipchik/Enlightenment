using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EnlightenmentApp.DAL.Repositories
{
    public class PathRepository : GenericRepository<PathEntity>, IPathRepository
    {
        public PathRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }

        public override async Task<IEnumerable<PathEntity>> GetEntities(CancellationToken ct)
        {
            var paths = await _context.Paths.Include(p => p.Tags)
                .AsNoTracking().ToListAsync(ct);
            return paths;
        }

        public override async Task<PathEntity> Add(PathEntity pathEntity, CancellationToken ct)
        {
            if (!pathEntity.Modules.IsNullOrEmpty())
            {
                _context.Modules.AttachRange(pathEntity.Modules);
            }

            if (!pathEntity.Tags.IsNullOrEmpty())
            {
                _context.Tags.AttachRange(pathEntity.Tags);
            }

            await _context.Paths.AddAsync(pathEntity, ct);
            await _context.SaveChangesAsync(ct);
            return pathEntity;
        }

        public override async Task<PathEntity?> GetById(int id, CancellationToken ct)
        {
            var path = await _context.Paths
                .Include(p => p.Modules)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Id == id, ct);
            return path;
        }

        public override async Task<PathEntity> Update(PathEntity pathEntity, CancellationToken ct)
        {
            var dbPathEntity = _context.Paths
            .Include(p => p.Modules)
            .Include(p => p.Tags)
            .First(p => p.Id == pathEntity.Id);
            SetTagsDiff(pathEntity, dbPathEntity);
            SetModulesDiff(pathEntity, dbPathEntity);

            dbPathEntity.Tags.ToList().AddRange(pathEntity.Tags);
            dbPathEntity.Modules.ToList().AddRange(pathEntity.Modules);
            await _context.SaveChangesAsync(ct);
            return pathEntity;
        }

        private static void SetTagsDiff(PathEntity pathEntity, PathEntity dbPathEntity)
        {
            //remove unused tags
            dbPathEntity.Tags.ToList()
                .RemoveAll(m => !pathEntity.Tags.ToList()
                    .Exists(x => x.Id == m.Id));
            //store new tags
            pathEntity.Tags.ToList().RemoveAll(m => dbPathEntity.Tags.ToList()
                            .Exists(x => x.Id == m.Id));
        }

        private static void SetModulesDiff(PathEntity pathEntity, PathEntity dbPathEntity)
        {
            //remove unused modules
            dbPathEntity.Modules.ToList()
                .RemoveAll(m => !pathEntity.Modules.ToList()
                    .Exists(x => x.Id == m.Id));
            //store new modules
            pathEntity.Modules.ToList().RemoveAll(m => dbPathEntity.Modules.ToList()
                            .Exists(x => x.Id == m.Id));
        }
    }
}
