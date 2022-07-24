namespace Volkin.Musihqa.Management.Domain.Models.Management
{
    public class Artist : BaseEntity
    {
        // ReSharper disable once UnusedMember.Local
        private Artist() { }

        public Artist(Guid id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public IReadOnlyCollection<Album>? Albums { get; private set; }
        public IReadOnlyCollection<Track>? Tracks { get; private set; }

        public IReadOnlyCollection<Album>? FeaturedInAlbums { get; private set; }
        public IReadOnlyCollection<Track>? FeaturedInTracks { get; private set; }
    }
}
