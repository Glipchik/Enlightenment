using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.DAL.Interfaces
{
    public interface IChapterRepository
    {
        public Task<IEnumerable<ChapterEntity>> GetChapters(CancellationToken ct);
        public Task<ChapterEntity> GetChapterById(int id, CancellationToken ct);
        public Task<ChapterEntity> AddChapter(ChapterEntity chapterEntity, CancellationToken ct);
        public Task<ChapterEntity> UpdateChapter(ChapterEntity chapterEntity, CancellationToken ct);
        public Task<bool> DeleteChapter(int id, CancellationToken ct);
        public Task<bool> ChapterExists(ChapterEntity chapterEntity, CancellationToken ct);

    }
}
