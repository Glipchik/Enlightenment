using AutoMapper;
using EnlightenmentApp.API.Models.Chapter;
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
            CreateMap<Chapter, ChapterViewModel>();
            CreateMap<ChapterViewModel, Chapter>();

            CreateMap<Section, SectionViewModel>();
            CreateMap<SectionViewModel, Section>();

            CreateMap<Module, ModuleViewModel>();
            CreateMap<ModuleViewModel, Module>();

            CreateMap<Path, PathViewModel>();
            CreateMap<PathViewModel, Path>();

            CreateMap<Tag, TagViewModel>();
            CreateMap<TagViewModel, Tag>();

            CreateMap<ModuleReview, ModuleReviewViewModel>();
            CreateMap<ModuleReviewViewModel, ModuleReview>();
        }
    }
}
