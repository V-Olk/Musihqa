using Volkin.Musihqa.Management.Domain.Requests.Albums;

namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Update
{
    public class UpdateAlbumRequest : IUpdateAlbumRequest
    {
        public Guid Id { get; init; }

        public string? Name { get; init; }

        public string? CoverLink { get; init; }
        public DateTime ReleaseDate { get; init; }

        public IReadOnlyCollection<Guid>? FeaturedArtistsIds { get; init; }

        public IReadOnlyCollection<UpdateTrackRequest>? UpdateTracksRequests { get; init; }

    }
}
