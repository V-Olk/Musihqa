using Volkin.Musihqa.Management.Domain.Models.Management;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Create;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Update;

namespace Volkin.Musihqa.Management.WebHost.Services
{
    public interface IAlbumService
    {
        public Task<Album> CreateAlbumAsync(CreateAlbumRequest request, CancellationToken cancellationToken);
        public Task<Album> UpdateAlbumAsync(Guid id, UpdateAlbumRequest request, CancellationToken cancellationToken);
        public Task<Album> DeleteAlbumAsync(Guid id, CancellationToken cancellationToken);
    }
}
