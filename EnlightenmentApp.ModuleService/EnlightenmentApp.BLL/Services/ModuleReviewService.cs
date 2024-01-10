using AutoMapper;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;

namespace EnlightenmentApp.BLL.Services
{
    public class ModuleReviewService : GenericService<ModuleReview, ModuleReviewEntity>, IModuleReviewService
    {
        public ModuleReviewService(IModuleReviewRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
