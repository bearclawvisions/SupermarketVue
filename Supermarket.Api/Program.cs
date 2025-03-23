using Microsoft.AspNetCore.Antiforgery;
using Supermarket.Api.App_Start;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.SwaggerSettings();
builder.Services.CorsSettings();
builder.Services.AddDatabaseConnection();
builder.Services.ConfigureCookiesAndAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();
var antiForgery = app.Services.GetRequiredService<IAntiforgery>();
app.Use((context, next) =>
{
        var tokenSet = antiForgery.GetAndStoreTokens(context);
        context.Response.Cookies.Append("X-XSRF-TOKEN", tokenSet.RequestToken!,
            new CookieOptions { HttpOnly = false });

    return next(context);
});
app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();

app.MapControllers();

app.Run();