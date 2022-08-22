namespace Volkin.Musihqa.Management.Domain.Requests.Tracks;

public interface IUpdateTrackRequest
{
    public Guid? TrackId { get; init; }

    public string? TrackName { get; init; }

    public List<Guid>? FeaturedArtistsIds { get; init; }
}