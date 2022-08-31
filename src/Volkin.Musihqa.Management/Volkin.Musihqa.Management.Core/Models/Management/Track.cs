namespace Volkin.Musihqa.Management.Domain.Models.Management
{
    public class Track : BaseEntity
    {
        // ReSharper disable once UnusedMember.Local
        private Track() { }

        public Track(string name, Artist primaryArtist, IReadOnlyCollection<Artist>? featuredArtists = null)
        {
            Name = name;
            PrimaryArtist = primaryArtist;

            if (featuredArtists != null)
                FeaturedArtists = featuredArtists;
        }

        public Track(Guid id, string name, Artist primaryArtist, IReadOnlyCollection<Artist>? featuredArtists = null)
            : base(id)
        {
            Name = name;
            PrimaryArtist = primaryArtist;

            if (featuredArtists != null)
                FeaturedArtists = featuredArtists;
        }

        public string Name { get; private set; } = String.Empty;

        public Album Album { get; private set; } = default!;

        public Artist PrimaryArtist { get; private set; } = default!;

        public IReadOnlyCollection<Artist>? FeaturedArtists { get; private set; }
    }
}
