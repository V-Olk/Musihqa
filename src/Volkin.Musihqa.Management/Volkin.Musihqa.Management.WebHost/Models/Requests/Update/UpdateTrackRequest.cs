using Volkin.Musihqa.Management.Domain.Requests.Tracks;

namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Update
{
    public class UpdateTrackRequest : IUpdateTrackRequest
    {
        public Guid? TrackId { get; init; }

        public string? TrackName { get; init; }

        public List<Guid>? FeaturedArtistsIds { get; init; }
    }
}
