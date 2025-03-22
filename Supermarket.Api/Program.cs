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
app.UseAuthorization();

app.UseAntiforgery();
app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();
// var antiForgery = app.Services.GetRequiredService<IAntiforgery>();
// app.Use((context, next) =>
// {
//     var requestPath = context.Request.Path.Value;
//
//     if (string.Equals(requestPath, "/", StringComparison.OrdinalIgnoreCase)
//         || string.Equals(requestPath, "/index.html", StringComparison.OrdinalIgnoreCase))
//     {
//         var tokenSet = antiForgery.GetAndStoreTokens(context);
//         context.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!,
//             new CookieOptions { HttpOnly = false });
//     }
//
//     return next(context);
// });

app.MapControllers();

app.Run();