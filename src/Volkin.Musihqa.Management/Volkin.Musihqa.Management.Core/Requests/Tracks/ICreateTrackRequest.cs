namespace Volkin.Musihqa.Management.Domain.Requests.Tracks;

public interface ICreateTrackRequest
{
    public string? TrackName { get; init; }

    public List<Guid>? FeaturedArtistsIds { get; init; }
}