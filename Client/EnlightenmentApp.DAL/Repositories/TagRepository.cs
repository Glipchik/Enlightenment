using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;

namespace EnlightenmentApp.DAL.Repositories
{
    internal class TagRepository : GenericRepository<TagEntity>, ITagRepository
    {
        public TagRepository(DatabaseContext dbContext) : base(dbContext)
        {

        }
    }
}
