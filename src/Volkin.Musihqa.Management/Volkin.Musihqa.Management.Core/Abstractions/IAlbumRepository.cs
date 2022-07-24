using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.Domain.Abstractions
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IReadOnlyCollection<Album>> GetByArtistIdAsync(Guid artistId, CancellationToken cancellationToken);

        Task<Album?> GetFullAlbumByIdOrDefaultAsync(Guid artistId, CancellationToken cancellationToken);
    }
}
