using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Supermarket.Data.Database;
using Supermarket.Domain.Entities;

namespace Supermarket.Api.App_Start;

public abstract class ConfigureDatabase
{
    public static void AddConnection(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<SuperContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<SuperContext>()
            .AddDefaultTokenProviders();
    }
}