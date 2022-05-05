namespace Volkin.Musihqa.Management.Core.Domain.Management
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public virtual ICollection<Album>? Albums { get; set; }
        public virtual ICollection<Track>? Tracks { get; set; }

        public virtual ICollection<Album>? FeaturedInAlbums { get; set; }
        public virtual ICollection<Track>? FeaturedInTracks { get; set; }
    }
}
