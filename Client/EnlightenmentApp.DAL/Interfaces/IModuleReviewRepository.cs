using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.DAL.Interfaces
{
    public interface IModuleReviewRepository
    {
        public Task<IEnumerable<ModuleReviewEntity>> GetModuleReviews(CancellationToken ct);
        public Task<ModuleReviewEntity> GetModuleReviewById(int id, CancellationToken ct);
        public Task<ModuleReviewEntity> AddModuleReview(ModuleReviewEntity moduleReviewEntity, CancellationToken ct);
        public Task<ModuleReviewEntity> UpdateModuleReview(ModuleReviewEntity moduleReviewEntity, CancellationToken ct);
        public Task<bool> DeleteModuleReview(int id, CancellationToken ct);
        public Task<bool> ModuleReviewExists(ModuleReviewEntity moduleReviewEntity, CancellationToken ct);
    }
}
