using EnlightenmentApp.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnlightenmentApp.DAL.DI
{
    public static class DataAccessServices
    {
        public static void AddDataRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
