namespace Volkin.Musihqa.Management.Core.Domain.Management
{
    public class Track : BaseEntity
    {
        public string Name { get; set; } = default!;

        public virtual Album Album { get; set; } = default!;

        public virtual Artist PrimaryArtist { get; set; } = default!;

        public virtual ICollection<Artist>? FeaturedArtists { get; set; }
    }
}
