using AutoMapper;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;

namespace EnlightenmentApp.BLL.Services
{
    public class ModuleService : GenericService<Module, ModuleEntity>, IModuleService
    {
        public ModuleService(IModuleRepository repository, IMapper mapper) : base(repository, mapper)
        {
            
        }
    }
}
