using Supermarket.Data.Repository.Implementation;
using Supermarket.Data.Repository.Interface;

namespace Supermarket.Api.App_Start;

public abstract class ConfigureServices
{
    public static void AddServices(IServiceCollection services)
    {
        // repositories
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
    }
}