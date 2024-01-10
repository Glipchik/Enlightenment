using AutoMapper;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;
using Path = EnlightenmentApp.BLL.Entities.Path;

namespace EnlightenmentApp.BLL.Services
{
    public class PathService : GenericService<Path, PathEntity>, IPathService
    {
        public PathService(IPathRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
