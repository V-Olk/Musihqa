using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.WebHost.Services
{
    public interface IAlbumService
    {
        public Task<Album> DeleteAlbumAsync(Guid id, CancellationToken cancellationToken);
    }
}
