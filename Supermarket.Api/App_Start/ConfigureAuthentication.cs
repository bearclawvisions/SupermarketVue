using Microsoft.AspNetCore.Identity;

namespace Supermarket.Api.App_Start;

public static class ConfigureAuthentication
{
    public static void ConfigureCookiesAndAuthentication(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(option =>
        {
            option.Cookie.Name = "Supermarket.Auth";
            option.Cookie.SameSite = SameSiteMode.None; // allow cross-origin requests
            option.Cookie.SecurePolicy = CookieSecurePolicy.Always; // require https
            option.Cookie.HttpOnly = true; // Prevents JavaScript access
        });

        services.Configure<IdentityOptions>(option =>
        {
            option.Password.RequiredLength = 8;
            option.User.RequireUniqueEmail = true;
        });
        
        services.AddAntiforgery(options =>
        {
            options.FormFieldName = "__RequestVerificationToken";
            options.HeaderName = "X-XSRF-TOKEN";
            options.Cookie.Name = "X-XSRF-COOKIE";
            options.Cookie.SameSite = SameSiteMode.None; // Required for cross-origin CSRF handling
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.SuppressXFrameOptionsHeader = false;
        });
    }
}