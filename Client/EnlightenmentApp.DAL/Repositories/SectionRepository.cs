using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Repositories
{
    public class SectionRepository : GenericRepository<SectionEntity>, ISectionRepository
    {
        public SectionRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }

        public override async Task<SectionEntity> GetById(int id, CancellationToken ct)
        {
            var section = await _context.Sections
                .Include(s => s.Chapters)
                .FirstOrDefaultAsync(s => s.Id == id, ct);
            if (section != null)
            {
                return section;
            }

            throw new KeyNotFoundException();
        }
    }
}
