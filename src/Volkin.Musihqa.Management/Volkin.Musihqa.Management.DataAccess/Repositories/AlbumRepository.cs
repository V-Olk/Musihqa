using Microsoft.EntityFrameworkCore;
using Volkin.Musihqa.Management.Core.Abstractions;
using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.DataAccess.Common;

namespace Volkin.Musihqa.Management.DataAccess.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {


        public AlbumRepository(DataContext dataContext) : base(dataContext)
        {

        }

        //TODO: optimize
        public async Task<IReadOnlyCollection<Album>> GetByArtistIdAsync(Guid artistId)
            => await DataContext.Set<Album>().Where(e => e.PrimaryArtist.Id.Equals(artistId)).ToArrayAsync().ConfigureAwait(false);

        public async Task<Album?> GetFullAlbumByIdOrDefaultAsync(Guid artistId)
            => await GetByIdOrDefaultAsync(artistId, a => a.PrimaryArtist, a => a.FeaturedArtists, a => a.Tracks);
    }
}
