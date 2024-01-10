using AutoMapper;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.DAL.Entities;
using Path = EnlightenmentApp.BLL.Entities.Path;

namespace EnlightenmentApp.BLL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Section, SectionEntity>().ReverseMap();

            CreateMap<Module, ModuleEntity>().ReverseMap();

            CreateMap<Path, PathEntity>().ReverseMap();

            CreateMap<Tag, TagEntity>().ReverseMap();

            CreateMap<ModuleReview, ModuleReviewEntity>().ReverseMap();
        }
    }
}
