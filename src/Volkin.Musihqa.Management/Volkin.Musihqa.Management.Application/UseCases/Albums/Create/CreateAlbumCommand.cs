using Volkin.Musihqa.Management.Domain.Requests.Albums;
using Volkin.Musihqa.Management.Domain.Requests.Tracks;
using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Create;

public class CreateAlbumCommand : ICommand<CreateAlbumResult>
{
    public CreateAlbumCommand(ICreateAlbumRequest request, IReadOnlyCollection<ICreateTrackRequest>? tracksRequest)
    {
        Request = request;
        TracksRequests = tracksRequest;
    }

    public ICreateAlbumRequest Request { get; }
    public IReadOnlyCollection<ICreateTrackRequest>? TracksRequests { get; }
}