using Volkin.Musihqa.Management.Domain.Requests.Albums;

namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Create
{
    public class CreateAlbumRequest : ICreateAlbumRequest
    {
        public string? Name { get; init; }

        public string? CoverLink { get; init; }
        
        public DateTime ReleaseDate { get; init; }

        public Guid PrimaryArtist { get; init; }

        public IReadOnlyCollection<Guid>? FeaturedArtistsIds { get; init; }

        public IReadOnlyCollection<CreateTrackRequest>? TracksRequest { get; init; }
    }
}
