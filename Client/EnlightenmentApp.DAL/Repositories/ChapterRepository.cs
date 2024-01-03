using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;

namespace EnlightenmentApp.DAL.Repositories
{
    public class ChapterRepository : GenericRepository<ChapterEntity>, IChapterRepository
    {
        public ChapterRepository(DatabaseContext dbContext) : base(dbContext) 
        {

        }
    }
}
