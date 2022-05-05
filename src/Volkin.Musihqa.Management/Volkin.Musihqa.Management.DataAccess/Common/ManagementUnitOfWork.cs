using Volkin.Musihqa.Management.Core.Abstractions;
using Volkin.Musihqa.Management.DataAccess.Repositories;

namespace Volkin.Musihqa.Management.DataAccess.Common
{
    public class ManagementUnitOfWork : IManagementUnitOfWork, IDisposable
    {
        private readonly DataContext _context;

        public IAlbumRepository Album { get; private set; }
        public IArtistRepository Artist { get; private set; }

        public ManagementUnitOfWork(DataContext context)
        {
            _context = context;

            Album = new AlbumRepository(context);
            Artist = new ArtistRepository(context);
        }

        public async Task CompleteAsync() => await _context.SaveChangesAsync().ConfigureAwait(false);

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
