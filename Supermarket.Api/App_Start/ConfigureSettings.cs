namespace Supermarket.Api.App_Start;

public static class ConfigureSettings
{
    public static void CorsSettings(this IServiceCollection services)
    {
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", policy =>
            {
                policy.WithOrigins("http://localhost:5173")
                    // .SetIsOriginAllowed(_ => true) // vue specific?
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            })
        );
    }

    public static void SwaggerSettings(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}