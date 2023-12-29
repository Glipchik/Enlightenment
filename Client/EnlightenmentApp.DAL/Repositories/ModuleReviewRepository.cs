using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Repositories
{
    public class ModuleReviewRepository : IModuleReviewRepository
    {
        private DatabaseContext _context;
        public ModuleReviewRepository(DatabaseContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<ModuleReviewEntity> AddModuleReview(ModuleReviewEntity moduleReviewEntity, CancellationToken ct)
        {
            if (moduleReviewEntity != null)
            {
                await _context.ModuleReviews.AddAsync(moduleReviewEntity, ct);
                await _context.SaveChangesAsync(ct);
                return moduleReviewEntity;
            }
            throw new ArgumentNullException();
        }

        public async Task<bool> DeleteModuleReview(int id, CancellationToken ct)
        {
            var moduleReview = await _context.ModuleReviews.FindAsync(id, ct);
            if (moduleReview != null)
            {
                _context.ModuleReviews.Remove(moduleReview);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            throw new KeyNotFoundException();
        }

        public async Task<ModuleReviewEntity> GetModuleReviewById(int id, CancellationToken ct)
        {
            var moduleReview = await _context.ModuleReviews.FindAsync(id, ct);
            if (moduleReview != null)
            {
                return moduleReview;
            }
            throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<ModuleReviewEntity>> GetModuleReviews(CancellationToken ct)
        {
            var moduleReviews = await _context.ModuleReviews.AsNoTracking().ToListAsync(ct);
            return moduleReviews;
        }
        public async Task<ModuleReviewEntity> UpdateModuleReview(ModuleReviewEntity moduleReviewEntity, CancellationToken ct)
        {
            if (await ModuleReviewExists(moduleReviewEntity, ct))
            {
                var moduleReview = _context.Entry(moduleReviewEntity);
                moduleReview.State = EntityState.Modified;
                await _context.SaveChangesAsync(ct);
                return moduleReviewEntity;
            }
            throw new DbUpdateConcurrencyException();
        }

        public async Task<bool> ModuleReviewExists(ModuleReviewEntity moduleReviewEntity, CancellationToken ct)
        {
            return await _context.ModuleReviews.AnyAsync(c => c.Id == moduleReviewEntity.Id, ct);
        }
    }
}
