using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Repositories
{
    public class ChapterRepository : IChapterRepository
    {
        private DatabaseContext _context;
        public ChapterRepository(DatabaseContext dbContext) 
        {
            this._context = dbContext;
        }

        public async Task<ChapterEntity> AddChapter(ChapterEntity chapterEntity, CancellationToken ct)
        {
            if (chapterEntity != null)
            {
                await _context.Chapters.AddAsync(chapterEntity, ct);
                await _context.SaveChangesAsync(ct);
                return chapterEntity;
            }
            throw new ArgumentNullException();
        }

        public async Task<bool> DeleteChapter(int id, CancellationToken ct)
        {
            var chapter = await _context.Chapters.FindAsync(id, ct);
            if (chapter != null)
            {
                _context.Chapters.Remove(chapter);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            throw new KeyNotFoundException();
        }

        public async Task<ChapterEntity> GetChapterById(int id, CancellationToken ct)
        {
            var chapter = await _context.Chapters.FindAsync(id, ct);
            if (chapter != null)
            {
                return chapter;
            }
            throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<ChapterEntity>> GetChapters(CancellationToken ct)
        {
            var chapters = await _context.Chapters.AsNoTracking().ToListAsync(ct);
            return chapters;
        }

        public async Task<ChapterEntity> UpdateChapter(ChapterEntity chapterEntity, CancellationToken ct)
        {
            if (await ChapterExists(chapterEntity, ct))
            {
                var chapter = _context.Entry(chapterEntity);
                chapter.State = EntityState.Modified;
                await _context.SaveChangesAsync(ct);
                return chapterEntity;
            }
            throw new DbUpdateConcurrencyException();
        }

        public async Task<bool> ChapterExists(ChapterEntity chapterEntity, CancellationToken ct)
        {
            return await _context.Chapters.AnyAsync(c => c.Id == chapterEntity.Id, ct);
        }
    }
}
