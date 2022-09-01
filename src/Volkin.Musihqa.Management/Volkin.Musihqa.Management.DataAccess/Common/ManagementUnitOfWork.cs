using Volkin.Musihqa.Management.Domain.Abstractions;

namespace Volkin.Musihqa.Management.DataAccess.Common
{
    internal class ManagementUnitOfWork : IManagementUnitOfWork
    {
        private readonly DataContext _context;

        public ManagementUnitOfWork(DataContext context, IAlbumRepository albumRepository, IArtistRepository artistRepository)
        {
            _context = context;

            Album = albumRepository;
            Artist = artistRepository;
        }

        public IAlbumRepository Album { get; }
        public IArtistRepository Artist { get; }

        public async Task CompleteAsync(CancellationToken cancellationToken)
            => await _context.SaveChangesAsync(cancellationToken);

    }
}