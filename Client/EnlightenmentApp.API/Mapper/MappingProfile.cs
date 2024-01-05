using AutoMapper;
using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.API.Models.ModuleReview;
using EnlightenmentApp.API.Models.Path;
using EnlightenmentApp.API.Models.Section;
using EnlightenmentApp.API.Models.Tag;
using EnlightenmentApp.BLL.Entities;
using Path = EnlightenmentApp.BLL.Entities.Path;

namespace EnlightenmentApp.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Section, SectionViewModel>().ReverseMap();

            CreateMap<Module, ModuleViewModel>().ReverseMap();

            CreateMap<Path, PathViewModel>().ReverseMap();

            CreateMap<Tag, TagViewModel>().ReverseMap();

            CreateMap<ModuleReview, ModuleReviewViewModel>().ReverseMap();
        }
    }
}
