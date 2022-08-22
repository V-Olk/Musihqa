using Volkin.Musihqa.Management.Domain.Requests.Albums;
using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Create;

public class CreateAlbumCommand : ICommand<CreateAlbumResult>
{
    public CreateAlbumCommand(ICreateAlbumRequest request)
    {
        Request = request;
    }

    public ICreateAlbumRequest Request { get; }
}