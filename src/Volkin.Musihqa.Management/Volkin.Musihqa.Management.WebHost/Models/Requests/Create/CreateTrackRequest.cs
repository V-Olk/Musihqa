using Volkin.Musihqa.Management.Domain.Requests.Tracks;

namespace Volkin.Musihqa.Management.WebHost.Models.Requests.Create
{
    public class CreateTrackRequest : ICreateTrackRequest
    {
        public string? TrackName { get; init; }

        public List<Guid>? FeaturedArtistsIds { get; init; }
    }
}
