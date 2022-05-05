namespace Volkin.Musihqa.Management.WebHost.Models.Requests
{
    public class CreateOrUpdateTrackRequest
    {
        public Guid? TrackId { get; set; }

        public string TrackName { get; set; } = default!;

        public List<Guid>? FeaturedArtistsIds { get; set; }
    }
}
