using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Create;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Update;

namespace Volkin.Musihqa.Management.WebHost.Mappers
{
    public static class AlbumMapper
    {
        public static Album MapFromCreateRequest(CreateAlbumRequest request,
            Artist primaryArtist,
            IEnumerable<Artist> featuredArtists)
        {
            var album = new Album(request.Name!,
                request.CoverLink!,
                request.ReleaseDate,
                primaryArtist,
                featuredArtists: featuredArtists.ToList()
            );

            return album;
        }

        internal static Track MapTrackFromCreateRequest(CreateTrackRequest trackRequest,
            Artist artist,
            IEnumerable<Artist> featuredArtists)
        {
            var track = new Track(trackRequest.TrackName!, artist, featuredArtists.ToList());

            return track;
        }

        internal static Track MapTrackFromUpdateRequest(UpdateTrackRequest trackRequest,
            Artist artist,
            IEnumerable<Artist> featuredArtists,
            Dictionary<Guid, Track> oldTracks)
        {
            Track? track = null;

            if (oldTracks.Count == 0 && trackRequest.TrackId != null)
                oldTracks.TryGetValue(trackRequest.TrackId.Value, out track);

            track ??= new Track(trackRequest.TrackName!, artist, featuredArtists.ToList());

            return track;
        }
    }
}
