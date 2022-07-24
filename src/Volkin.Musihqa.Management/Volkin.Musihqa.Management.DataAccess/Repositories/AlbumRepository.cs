using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.DataAccess.Common;
using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.DataAccess.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {


        public AlbumRepository(DataContext dataContext) : base(dataContext)
        {

        }

        //TODO: optimize
        public async Task<IReadOnlyCollection<Album>> GetByArtistIdAsync(Guid artistId)
            => await DataContext.Set<Album>().Where(e => e.PrimaryArtist.Id.Equals(artistId)).ToArrayAsync();

        public async Task<Album?> GetFullAlbumByIdOrDefaultAsync(Guid artistId)
            => await GetByIdOrDefaultAsync(artistId, a => a.PrimaryArtist, a => a.FeaturedArtists, a => a.Tracks);
    }
}
