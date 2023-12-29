using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Interfaces;
using EnlightenmentApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnlightenmentApp.DAL.DI
{
    public static class DataAccessServices
    {
        public static void RegisterDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IPathRepository, PathRepository>();
            services.AddScoped<IModuleReviewRepository, ModuleReviewRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}
