using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Repositories
{
    public class ModuleReviewRepository : GenericRepository<ModuleReviewEntity>, IModuleReviewRepository
    {
        public ModuleReviewRepository(DatabaseContext dbContext) : base(dbContext)
        {
            this._context = dbContext;
        }
    }
}
