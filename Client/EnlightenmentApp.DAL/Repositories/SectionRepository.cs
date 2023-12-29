using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private DatabaseContext _context;
        public SectionRepository(DatabaseContext dbContext)
        {
            this._context = dbContext;
        }

        public async Task<SectionEntity> AddSection(SectionEntity sectionEntity, CancellationToken ct)
        {
            if (sectionEntity != null)
            {
                await _context.Sections.AddAsync(sectionEntity, ct);
                await _context.SaveChangesAsync(ct);
                return sectionEntity;
            }
            throw new ArgumentNullException();
        }

        public async Task<bool> DeleteSection(int id, CancellationToken ct)
        {
            var section = await _context.Sections.FindAsync(id, ct);
            if (section != null)
            {
                _context.Sections.Remove(section);
                await _context.SaveChangesAsync(ct);
                return true;
            }
            throw new KeyNotFoundException();
        }

        public async Task<SectionEntity> GetSectionById(int id, CancellationToken ct)
        {
            var section = await _context.Sections.FindAsync(id, ct);
            if (section != null)
            {
                return section;
            }
            throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<SectionEntity>> GetSections(CancellationToken ct)
        {
            var sections = await _context.Sections.AsNoTracking().ToListAsync(ct);
            return sections;
        }
        public async Task<SectionEntity> UpdateSection(SectionEntity sectionEntity, CancellationToken ct)
        {
            if (await SectionExists(sectionEntity, ct))
            {
                var section = _context.Entry(sectionEntity);
                section.State = EntityState.Modified;
                await _context.SaveChangesAsync(ct);
                return sectionEntity;
            }
            throw new DbUpdateConcurrencyException();
        }

        public async Task<bool> SectionExists(SectionEntity sectionEntity, CancellationToken ct)
        {
            return await _context.Sections.AnyAsync(c => c.Id == sectionEntity.Id, ct);
        }
    }
}
