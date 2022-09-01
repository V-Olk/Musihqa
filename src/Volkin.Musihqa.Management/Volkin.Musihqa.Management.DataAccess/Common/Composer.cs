using Microsoft.Extensions.DependencyInjection;
using Volkin.Musihqa.Management.DataAccess.Data;
using Volkin.Musihqa.Management.DataAccess.Repositories;
using Volkin.Musihqa.Management.Domain.Abstractions;

namespace Volkin.Musihqa.Management.DataAccess.Common;

public static class Composer
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<IArtistRepository, ArtistRepository>();

        services.AddScoped<IManagementUnitOfWork, ManagementUnitOfWork>();
        services.AddScoped<IDbInitializer, EfDbInitializer>();

        return services;
    }
}