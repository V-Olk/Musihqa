using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Exceptions;
using Volkin.Musihqa.Management.Domain.Models.Management;
using Volkin.Musihqa.Management.Domain.UseCases.Handlers;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Delete;

public class DeleteAlbumHandler : ICommandHandler<DeleteAlbumCommand, DeleteAlbumResult>
{
    private readonly IManagementUnitOfWork _managementUnitOfWork;

    public DeleteAlbumHandler(IManagementUnitOfWork managementUnitOfWork)
    {
        _managementUnitOfWork = managementUnitOfWork;
    }
    
    public async Task<DeleteAlbumResult> Handle(DeleteAlbumCommand deleteAlbumCommand, CancellationToken cancellationToken)
    {
        Album? album = await _managementUnitOfWork.Album.GetByIdOrDefaultAsync(deleteAlbumCommand.Id, cancellationToken);
        if (album is null)
            throw new EntityNotFoundException(nameof(_managementUnitOfWork.Album), deleteAlbumCommand.Id);

        _managementUnitOfWork.Album.Delete(album);
        await _managementUnitOfWork.CompleteAsync(cancellationToken);

        return new DeleteAlbumResult(album);
    }
    
}