namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Create
{
    public class CreateTrackRequest
    {
        public string? TrackName { get; init; }

        public List<Guid>? FeaturedArtistsIds { get; init; }
    }
}
