using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Delete;

public class DeleteAlbumCommand : ICommand<DeleteAlbumResult>
{

    public DeleteAlbumCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}