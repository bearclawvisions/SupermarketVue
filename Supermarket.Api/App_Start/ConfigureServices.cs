using Supermarket.Api.Models;
using Supermarket.Business.Services.Implementation;
using Supermarket.Business.Services.Interface;
using Supermarket.Data.Repository.Implementation;
using Supermarket.Data.Repository.Interface;

namespace Supermarket.Api.App_Start;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // https://medium.com/@dozieogbo/a-better-way-to-inject-appsettings-in-asp-net-core-96be36ffa22b
        // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-9.0#bind-hierarchical-configuration-data-using-the-options-pattern
        services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

        // repositories
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        
        // services
        services.AddScoped(typeof(IAppUserService), typeof(AppAppUserService));
    }
}