using Volkin.Musihqa.Management.Domain.Requests.Tracks;

namespace Volkin.Musihqa.Management.Domain.Requests.Albums;

public interface IUpdateAlbumRequest
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? CoverLink { get; init; }
    public DateTime ReleaseDate { get; init; }

    public List<Guid>? FeaturedArtistsIds { get; init; }

    public List<IUpdateTrackRequest>? TracksRequest { get; init; }
}