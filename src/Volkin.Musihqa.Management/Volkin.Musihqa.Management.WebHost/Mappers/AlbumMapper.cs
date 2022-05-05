using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.WebHost.Models.Requests;

namespace Volkin.Musihqa.Management.WebHost.Mappers
{
    public static class AlbumMapper
    {
        public static Album MapFromRequest(CreateOrUpdateAlbumRequest request,
            Artist primaryArtist,
            IEnumerable<Artist> featuredArtists,
            Album? album = null)
        {
            album ??= new Album();

            album.Name = request.Name;
            album.CoverLink = request.CoverLink;

            album.PrimaryArtist = primaryArtist;
            album.FeaturedArtists = featuredArtists.ToList();



            return album;
        }

        internal static void MapTrackFromRequest(Album album, CreateOrUpdateTrackRequest trackRequest, Artist artist, IEnumerable<Artist> featuredArtists, ICollection<Track> oldTracks = default!)
        {
            Track? track = null;

            if (oldTracks.Count != 0 && trackRequest.TrackId != null)
                track = oldTracks.FirstOrDefault(tr => tr.Id == trackRequest.TrackId);

            track ??= new Track();

            album.Tracks.Add(track);

            track.Name = trackRequest.TrackName;
            track.PrimaryArtist = artist;
            track.FeaturedArtists = featuredArtists.ToList();
        }
    }
}
