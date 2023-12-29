using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnlightenmentApp.BLL.DI
{
    public static class BusinessLogicServices
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            DAL.DI.DataAccessServices.AddDataRepository(services, configuration);
        }
    }
}
