using Volkin.Musihqa.Management.Core.Domain.Management;

namespace Volkin.Musihqa.Management.Core.Abstractions
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IReadOnlyCollection<Album>> GetByArtistIdAsync(Guid artistId);

        Task<Album?> GetFullAlbumByIdOrDefaultAsync(Guid artistId);
    }
}
