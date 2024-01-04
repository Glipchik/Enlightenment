using AutoMapper;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;

namespace EnlightenmentApp.BLL.Services
{
    public class ChapterService : GenericService<Chapter, ChapterEntity>, IChapterService
    {
        public ChapterService(IChapterRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
