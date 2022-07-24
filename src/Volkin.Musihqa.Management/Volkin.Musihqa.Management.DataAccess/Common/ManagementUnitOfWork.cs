using Volkin.Musihqa.Management.Core.Abstractions;

namespace Volkin.Musihqa.Management.DataAccess.Common
{
    public class ManagementUnitOfWork : IManagementUnitOfWork
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

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

    }
}