namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Update
{
    public class UpdateTrackRequest
    {
        public Guid? TrackId { get; init; }

        public string? TrackName { get; init; }

        public List<Guid>? FeaturedArtistsIds { get; init; }
    }
}
