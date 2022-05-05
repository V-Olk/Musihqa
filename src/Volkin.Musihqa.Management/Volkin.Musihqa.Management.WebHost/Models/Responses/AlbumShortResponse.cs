using Volkin.Musihqa.Management.Core.Domain.Management;

namespace Volkin.Musihqa.Management.WebHost.Models.Responses
{
    public class AlbumShortResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string CoverLink { get; set; }

        public ArtistShortResponse PrimaryArtist { get; set; }

        public DateTime ReleaseDate { get; set; }

        public AlbumShortResponse(Album album)
        {
            Id = album.Id;
            Name = album.Name;
            CoverLink = album.CoverLink;
            ReleaseDate = album.ReleaseDate;
            PrimaryArtist = new ArtistShortResponse(album.PrimaryArtist);
        }
    }
}
