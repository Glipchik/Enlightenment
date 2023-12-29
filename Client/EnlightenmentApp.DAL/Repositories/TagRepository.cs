using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Repositories
{
    internal class TagRepository : ITagRepository
    {
        private DatabaseContext _context;
        public TagRepository(DatabaseContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<TagEntity> AddTag(TagEntity tagEntity, CancellationToken ct)
        {
            if (tagEntity != null)
            {
                await _context.Tags.AddAsync(tagEntity, ct);
                await _context.SaveChangesAsync(ct);
                return tagEntity;
            }
            throw new ArgumentNullException();
        }

        public async Task<bool> DeleteTag(int id, CancellationToken ct)
        {
            var tag = await _context.Tags.FindAsync(id, ct);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            throw new KeyNotFoundException();
        }

        public async Task<TagEntity> GetTagById(int id, CancellationToken ct)
        {
            var tag = await _context.Tags.FindAsync(id, ct);
            if (tag != null)
            {
                return tag;
            }
            throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<TagEntity>> GetTags(CancellationToken ct)
        {
            var tags = await _context.Tags.AsNoTracking().ToListAsync(ct);
            return tags;
        }
        public async Task<TagEntity> UpdateTag(TagEntity tagEntity, CancellationToken ct)
        {
            if (await TagExists(tagEntity, ct))
            {
                var moduleReview = _context.Entry(tagEntity);
                moduleReview.State = EntityState.Modified;
                await _context.SaveChangesAsync(ct);
                return tagEntity;
            }
            throw new DbUpdateConcurrencyException();
        }

        public async Task<bool> TagExists(TagEntity tagEntity, CancellationToken ct)
        {
            return await _context.Tags.AnyAsync(c => c.Id == tagEntity.Id, ct);
        }
    }
}
