using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EnlightenmentApp.DAL.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private DatabaseContext _context;
        public ModuleRepository(DatabaseContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<ModuleEntity> AddModule(ModuleEntity moduleEntity, CancellationToken ct)
        {
            if (moduleEntity != null)
            {
                if (!moduleEntity.Tags.IsNullOrEmpty())
                {
                    _context.Tags.AddRange(moduleEntity.Tags);
                }
                await _context.Modules.AddAsync(moduleEntity, ct);
                await _context.SaveChangesAsync(ct);
                return moduleEntity;
            }
            throw new ArgumentNullException();
        }

        public async Task<bool> DeleteModule(int id, CancellationToken ct)
        {
            var module = await _context.Modules.FindAsync(id, ct);
            if (module != null)
            {
                _context.Modules.Remove(module);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            throw new KeyNotFoundException();
        }

        public async Task<ModuleEntity> GetModuleById(int id, CancellationToken ct)
        {
            var module = await _context.Modules.FindAsync(id, ct);
            if (module != null)
            {
                return module;
            }
            throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<ModuleEntity>> GetModules(CancellationToken ct)
        {
            var modules = await _context.Modules.AsNoTracking().ToListAsync(ct);
            return modules;
        }
        public async Task<ModuleEntity> UpdateModule(ModuleEntity moduleEntity, CancellationToken ct)
        {
            if (await ModuleExists(moduleEntity, ct))
            {
                var dbModuleEntity = _context.Modules
                .Include(p => p.Tags)
                .First(p => p.Id == moduleEntity.Id);
                SetTagsDiff(moduleEntity, dbModuleEntity);

                dbModuleEntity.Tags.ToList().AddRange(moduleEntity.Tags);
                await _context.SaveChangesAsync();
                return moduleEntity;
            }
            throw new DbUpdateConcurrencyException();
        }
        private static void SetTagsDiff(ModuleEntity moduleEntity, ModuleEntity dbModuleEntity)
        {
            //remove unused tags
            dbModuleEntity.Tags.ToList()
                .RemoveAll(m => !moduleEntity.Tags.ToList()
                    .Exists(x => x.Id == m.Id));
            //store new tags
            moduleEntity.Tags.ToList().RemoveAll(m => dbModuleEntity.Tags.ToList()
                            .Exists(x => x.Id == m.Id));
        }

        public async Task<bool> ModuleExists(ModuleEntity moduleEntity, CancellationToken ct)
        {
            return await _context.Modules.AnyAsync(c => c.Id == moduleEntity.Id, ct);
        }
    }
}
