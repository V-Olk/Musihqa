using Volkin.Musihqa.Management.Domain.Requests.Albums;
using Volkin.Musihqa.Management.Domain.Requests.Tracks;

namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Create
{
    public class CreateAlbumRequest : ICreateAlbumRequest
    {
        public string? Name { get; init; }

        public string? CoverLink { get; init; }
        
        public DateTime ReleaseDate { get; init; }

        public Guid PrimaryArtist { get; init; }

        public List<Guid>? FeaturedArtistsIds { get; init; }

        public List<ICreateTrackRequest>? TracksRequest { get; init; }
    }
}
