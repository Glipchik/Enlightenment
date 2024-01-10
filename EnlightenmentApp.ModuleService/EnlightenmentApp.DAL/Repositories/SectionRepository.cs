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

        }

        public override async Task<SectionEntity?> GetById(int id, CancellationToken ct)
        {
            var section = await _context.Sections
                .FirstOrDefaultAsync(s => s.Id == id, ct);
            return section;
        }
    }
}
