using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.DAL.Interfaces
{
    public interface ITagRepository
    {
        public Task<IEnumerable<TagEntity>> GetTags(CancellationToken ct);
        public Task<TagEntity> GetTagById(int id, CancellationToken ct);
        public Task<TagEntity> AddTag(TagEntity tagEntity, CancellationToken ct);
        public Task<TagEntity> UpdateTag(TagEntity tagEntity, CancellationToken ct);
        public Task<bool> DeleteTag(int id, CancellationToken ct);
        public Task<bool> TagExists(TagEntity tagEntity, CancellationToken ct);
    }
}
