using AutoMapper;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;

namespace EnlightenmentApp.BLL.Services
{
    public class TagService : GenericService<Tag, TagEntity>, ITagService
    {
        public TagService(ITagRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
