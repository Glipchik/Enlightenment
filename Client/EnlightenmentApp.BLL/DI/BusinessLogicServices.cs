using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnlightenmentApp.DAL.DI;

namespace EnlightenmentApp.BLL.DI
{
    public static class BusinessLogicServices
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDALServices(configuration);
        }
    }
}
