using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Create;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Update;

namespace Volkin.Musihqa.Management.WebHost.Services
{
    public interface IAlbumService
    {
        public Task<Album?> GetAlbumAsync(Guid id);
        public Task<IReadOnlyCollection<Album>> GetAlbumsByArtistIdAsync(Guid artistId);
        public Task<Album> CreateAlbumAsync(CreateAlbumRequest request);
        public Task<Album> UpdateAlbumAsync(Guid id, UpdateAlbumRequest request);
        public Task<Album> DeleteAlbumAsync(Guid id);
    }
}
