using Volkin.Musihqa.Management.Domain.Models.Management;
using Volkin.Musihqa.Management.Domain.Requests.Albums;
using Volkin.Musihqa.Management.Domain.Requests.Tracks;

namespace Volkin.Musihqa.Management.Application.Mappers
{
    public static class AlbumMapper
    {
        public static Album MapFromCreateRequest(ICreateAlbumRequest request,
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

        internal static Track MapTrackFromCreateRequest(ICreateTrackRequest trackRequest,
            Artist artist,
            IEnumerable<Artist> featuredArtists)
        {
            var track = new Track(trackRequest.TrackName!, artist, featuredArtists.ToList());

            return track;
        }

        public static Track MapTrackFromUpdateRequest(IUpdateTrackRequest trackRequest,
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
