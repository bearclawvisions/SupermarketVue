using Supermarket.Api.App_Start;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices.AddServices(builder.Services);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .SetIsOriginAllowed(_ => true) // vue specific?
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        // policy.AllowAnyMethod()
        //     .SetIsOriginAllowed(_ => true)
        //     .AllowAnyHeader()
        //     .AllowCredentials();
    })
);

ConfigureDatabase.AddConnection(builder.Services, builder.Configuration);

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
app.MapControllers();
app.MapControllers();

app.Run();