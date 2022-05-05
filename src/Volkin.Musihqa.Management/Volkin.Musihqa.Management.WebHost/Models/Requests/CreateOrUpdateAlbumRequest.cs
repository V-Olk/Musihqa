namespace Volkin.Musihqa.Management.WebHost.Models.Requests
{
    public class CreateOrUpdateAlbumRequest
    {
        public string Name { get; set; } = default!;

        public string CoverLink { get; set; } = default!;

        public Guid PrimaryArtist { get; set; } = default!;

        public List<Guid>? FeaturedArtistsIds { get; set; }

        public List<CreateOrUpdateTrackRequest>? TracksRequest { get; set; }
    }
}
