namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Update
{
    public class UpdateAlbumRequest
    {
        public string? Name { get; init; }

        public string? CoverLink { get; init; }
        public DateTime ReleaseDate { get; init; }

        public List<Guid>? FeaturedArtistsIds { get; init; }

        public List<UpdateTrackRequest>? TracksRequest { get; init; }
    }
}
