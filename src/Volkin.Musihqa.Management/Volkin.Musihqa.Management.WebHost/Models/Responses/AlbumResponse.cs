using Volkin.Musihqa.Management.Core.Domain.Management;

namespace Volkin.Musihqa.Management.WebHost.Models.Responses
{
    public class AlbumResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CoverLink { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ArtistShortResponse PrimaryArtist { get; set; }

        public ICollection<ArtistShortResponse> FeaturedArtists { get; set; }

        public ICollection<TrackShortResponse> Tracks { get; set; }

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