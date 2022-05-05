using Volkin.Musihqa.Management.Core.Domain.Management;

namespace Volkin.Musihqa.Management.Core.Abstractions
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<List<Album>> GetByArtistIdAsync(Guid artistId);
    }
}
