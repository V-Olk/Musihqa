using Volkin.Musihqa.Management.Domain.Requests.Albums;
using Volkin.Musihqa.Management.Domain.Requests.Tracks;
using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Update;

public class UpdateAlbumCommand : ICommand<UpdateAlbumResult>
{
    public UpdateAlbumCommand(IUpdateAlbumRequest request, IReadOnlyCollection<IUpdateTrackRequest>? tracksRequests)
    {
        Request = request;
        TracksRequests = tracksRequests;
    }

    public IUpdateAlbumRequest Request { get; }
    public IReadOnlyCollection<IUpdateTrackRequest>? TracksRequests { get; }
}