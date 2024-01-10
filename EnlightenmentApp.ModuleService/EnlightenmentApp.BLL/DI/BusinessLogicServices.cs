using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnlightenmentApp.DAL.DI;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.BLL.Services;

namespace EnlightenmentApp.BLL.DI
{
    public static class BusinessLogicServices
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDALServices(configuration);
            services.AddAutoMapper(typeof(Mapper.MappingProfile).Assembly);
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IPathService, PathService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IModuleReviewService, ModuleReviewService>();
        }
    }
}
