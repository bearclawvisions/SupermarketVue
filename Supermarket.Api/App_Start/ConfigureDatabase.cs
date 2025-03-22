using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Supermarket.Data.Database;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Models;

namespace Supermarket.Api.App_Start;

public static class ConfigureDatabase
{
    public static void AddDatabaseConnection(this IServiceCollection services)
    {
        services.AddDbContext<SuperContext>((serviceProvider, options) =>
        {
            // Resolve AppSettings instance from the service provider
            var appSettings = serviceProvider.GetRequiredService<IOptionsMonitor<AppSettings>>().CurrentValue;
            
            options.UseSqlServer(appSettings.ConnectionStrings.DefaultConnection);
        });

        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<SuperContext>();
            // .AddDefaultTokenProviders(); // this is for jwt
    }
}