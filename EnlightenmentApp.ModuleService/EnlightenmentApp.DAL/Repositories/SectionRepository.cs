using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;

namespace EnlightenmentApp.DAL.Repositories
{
    public class SectionRepository : GenericRepository<SectionEntity>, ISectionRepository
    {
        public SectionRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
