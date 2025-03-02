using Microsoft.AspNetCore.Identity;

namespace Supermarket.Api.App_Start;

public static class ConfigureAuthentication
{
    public static void ConfigureCookiesAndAuthentication(this IServiceCollection services)
    {
        // services.ConfigureApplicationCookie(option =>
        // {
        //     option.AccessDeniedPath = "/Account/AccessDenied";
        //     option.LoginPath = "/Account/Login";
        // });

        services.Configure<IdentityOptions>(option =>
        {
            option.Password.RequiredLength = 8;
            option.User.RequireUniqueEmail = true;
        });
    }
}