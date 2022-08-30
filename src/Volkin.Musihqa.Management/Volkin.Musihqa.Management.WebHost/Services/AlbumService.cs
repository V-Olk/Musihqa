using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Exceptions;
using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.WebHost.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IManagementUnitOfWork _managementUnitOfWork;

        public AlbumService(IManagementUnitOfWork managementUnitOfWork)
        {
            _managementUnitOfWork = managementUnitOfWork;
        }

        public async Task<Album> DeleteAlbumAsync(Guid id, CancellationToken cancellationToken)
        {
            Album? album = await _managementUnitOfWork.Album.GetByIdOrDefaultAsync(id, cancellationToken);
            if (album is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Album), id);

            _managementUnitOfWork.Album.Delete(album);
            await _managementUnitOfWork.CompleteAsync(cancellationToken);

            return album;
        }

        
    }
}
