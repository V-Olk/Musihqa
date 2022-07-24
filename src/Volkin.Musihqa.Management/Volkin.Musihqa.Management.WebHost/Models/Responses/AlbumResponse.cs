using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.WebHost.Models.Responses
{
    public class AlbumResponse
    {
        public Guid Id { get; }

        public string Name { get; }

        public string CoverLink { get; }

        public DateTime ReleaseDate { get; }

        public ArtistShortResponse PrimaryArtist { get; }

        public IReadOnlyCollection<ArtistShortResponse> FeaturedArtists { get; }

        public IReadOnlyCollection<TrackShortResponse> Tracks { get; }

        public AlbumResponse(Album album)
        {
            Id = album.Id;
            Name = album.Name;
            CoverLink = album.CoverLink;
            ReleaseDate = album.ReleaseDate;
            PrimaryArtist = new ArtistShortResponse(album.PrimaryArtist);
            FeaturedArtists = album.FeaturedArtists.Select(artist => new ArtistShortResponse(artist)).ToList();
            Tracks = album.Tracks.Select(track => new TrackShortResponse(track)).ToList();
        }
    }
}