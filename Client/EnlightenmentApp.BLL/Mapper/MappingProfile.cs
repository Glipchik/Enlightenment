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
            CreateMap<Section, SectionEntity>();
            CreateMap<SectionEntity, Section>();

            CreateMap<Module, ModuleEntity>();
            CreateMap<ModuleEntity, Module>();

            CreateMap<Path, PathEntity>();
            CreateMap<PathEntity, Path>();

            CreateMap<Tag, TagEntity>();
            CreateMap<TagEntity, Tag>();

            CreateMap<ModuleReview, ModuleReviewEntity>();
            CreateMap<ModuleReviewEntity, ModuleReview>();
        }
    }
}
