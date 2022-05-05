using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.WebHost.Models.Requests;

namespace Volkin.Musihqa.Management.WebHost.Services
{
    public interface IAlbumService
    {
        public Task<Album?> GetAlbumAsync(Guid id);
        public Task<List<Album>> GetAlbumsByArtistIdAsync(Guid artistId);
        public Task<Album> CreateAlbumAsync(CreateOrUpdateAlbumRequest request);
        public Task<Album> UpdateAlbumAsync(Guid id, CreateOrUpdateAlbumRequest request);
        public Task<Album> DeleteAlbumAsync(Guid id);
    }
}
