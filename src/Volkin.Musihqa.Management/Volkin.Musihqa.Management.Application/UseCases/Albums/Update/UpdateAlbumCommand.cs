using Volkin.Musihqa.Management.Domain.Requests.Albums;
using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Update;

public class UpdateAlbumCommand : ICommand<UpdateAlbumResult>
{
    public UpdateAlbumCommand(IUpdateAlbumRequest request)
    {
        Request = request;
    }

    public IUpdateAlbumRequest Request { get; }
}