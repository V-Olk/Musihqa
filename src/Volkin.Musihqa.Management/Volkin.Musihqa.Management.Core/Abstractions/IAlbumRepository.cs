using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.Domain.Abstractions
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IReadOnlyCollection<Album>> GetByArtistIdAsync(Guid artistId);

        Task<Album?> GetFullAlbumByIdOrDefaultAsync(Guid artistId);
    }
}
