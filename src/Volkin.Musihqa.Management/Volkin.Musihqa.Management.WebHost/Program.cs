using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.Core.Abstractions;
using Volkin.Musihqa.Management.DataAccess.Common;
using Volkin.Musihqa.Management.DataAccess.Data;
using Volkin.Musihqa.Management.DataAccess.Repositories;
using Volkin.Musihqa.Management.WebHost.Common.Extensions;
using Volkin.Musihqa.Management.WebHost.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers(x => x.SuppressAsyncSuffixInActionNames = true);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IManagementUnitOfWork, ManagementUnitOfWork>();
builder.Services.AddScoped<IDbInitializer, EfDbInitializer>();

string? connectionString = builder.Configuration.GetConnectionString("ManagementDatabase");
builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseNpgsql(connectionString);
    x.UseLazyLoadingProxies();
});

builder.Services.AddSwaggerGen(options =>
{
    // Set the comments path for the Swagger JSON and UI.
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using IServiceScope scope = app.Services.CreateScope();
    scope.ServiceProvider.GetService<IDbInitializer>()?.InitializeDb();

app.Run();
