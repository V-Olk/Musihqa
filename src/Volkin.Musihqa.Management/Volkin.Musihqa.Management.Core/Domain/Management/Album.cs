namespace Volkin.Musihqa.Management.Core.Domain.Management
{
    public class Album : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string CoverLink { get; set; } = default!;

        public DateTime ReleaseDate { get; set; } = default!;

        public virtual Artist PrimaryArtist { get; set; } = default!;

        public virtual ICollection<Artist> FeaturedArtists { get; set; } = default!;

        public virtual ICollection<Track> Tracks { get; set; } = default!;

    }
}
