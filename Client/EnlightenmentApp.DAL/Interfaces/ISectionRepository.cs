using EnlightenmentApp.DAL.Entities;

namespace EnlightenmentApp.DAL.Interfaces
{
    public interface ISectionRepository
    {
        public Task<IEnumerable<SectionEntity>> GetSections(CancellationToken ct);
        public Task<SectionEntity> GetSectionById(int id, CancellationToken ct);
        public Task<SectionEntity> AddSection(SectionEntity sectionEntity, CancellationToken ct);
        public Task<SectionEntity> UpdateSection(SectionEntity sectionEntity, CancellationToken ct);
        public Task<bool> DeleteSection(int id, CancellationToken ct);
        public Task<bool> SectionExists(SectionEntity sectionEntity, CancellationToken ct);
    }
}
