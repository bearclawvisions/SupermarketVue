using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Supermarket.Api.App_Start;

public static class ConfigureAuthentication
{
    public static void ConfigureCookiesAndAuthentication(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(option =>
        {
            option.Cookie.Name = "Supermarket.Auth";
            option.Cookie.SameSite = SameSiteMode.Strict;
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
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.SuppressXFrameOptionsHeader = false;
        });
    }

}

// public class IClaimsProvider
// {
//     public ClaimsPrincipal ClaimsPrincipal { get; }
// }
//
// public class HttpContextClaimsProvider : IClaimsProvider
// {
//     public ClaimsPrincipal ClaimsPrincipal { get; private set; }
//     public HttpContextClaimsProvider(HttpContext httpContext)
//     {
//         ClaimsPovider = httpContext.User.Claims as ClaimsPrincipal;
//     }
// }
