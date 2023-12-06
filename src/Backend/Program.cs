using Backend;

using Backend.Services;

using Database.Data;
using Database.Models;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddAuthorization();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddTransient<IEmotionService, EmotionService>();

builder.Services
    .AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<MapOfFeelContext>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api/docs/{documentname}/swagger.json";
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("../docs/v1/swagger.json", "Backend V1");
        c.RoutePrefix = "api/ui";
    });
}

if (app.Environment.IsDevelopment())
{
    // Migrate latest database changes during startup
    using var scope = app.Services.CreateScope();

    var dbContext = scope.ServiceProvider
        .GetRequiredService<MapOfFeelContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapApi();

app.Run();
