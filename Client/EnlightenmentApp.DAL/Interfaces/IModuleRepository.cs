using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.DAL.Interfaces
{
    public interface IModuleRepository
    {
        public Task<IEnumerable<ModuleEntity>> GetModules(CancellationToken ct);
        public Task<ModuleEntity> GetModuleById(int id, CancellationToken ct);
        public Task<ModuleEntity> AddModule(ModuleEntity moduleEntity, CancellationToken ct);
        public Task<ModuleEntity> UpdateModule(ModuleEntity moduleEntity, CancellationToken ct);
        public Task<bool> DeleteModule(int id, CancellationToken ct);
        public Task<bool> ModuleExists(ModuleEntity moduleEntity, CancellationToken ct);
    }
}
