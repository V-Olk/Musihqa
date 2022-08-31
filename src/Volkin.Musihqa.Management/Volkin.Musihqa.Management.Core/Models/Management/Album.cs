namespace Volkin.Musihqa.Management.Domain.Models.Management
{
    public class Album : BaseEntity
    {
        private readonly List<Artist> _featuredArtists;
        private readonly List<Track> _tracks;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        // ReSharper disable once UnusedMember.Local
        private Album() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Album(string name
            , string coverLink
            , DateTime releaseDate
            , Artist primaryArtist
            , IEnumerable<Track>? tracks = null
            , IEnumerable<Artist>? featuredArtists = null)
        {
            Name = name;
            CoverLink = coverLink;
            ReleaseDate = releaseDate;
            PrimaryArtist = primaryArtist;

            _tracks = tracks != null ? tracks.ToList() : new List<Track>();

            _featuredArtists = featuredArtists != null ? featuredArtists.ToList() : new List<Artist>();
        }

        public Album(Guid id,
            string name,
            string coverLink,
            DateTime releaseDate,
            Artist primaryArtist,
            IReadOnlyCollection<Track>? tracks = null,
            IReadOnlyCollection<Artist>? featuredArtists = null)
        : base(id)
        {
            Name = name;
            CoverLink = coverLink;
            ReleaseDate = releaseDate;
            PrimaryArtist = primaryArtist;

            _tracks = tracks != null ? tracks.ToList() : new List<Track>();

            _featuredArtists = featuredArtists != null ? featuredArtists.ToList() : new List<Artist>();
        }

        public string Name { get; private set; }

        public string CoverLink { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public Artist PrimaryArtist { get; }

        public IReadOnlyCollection<Artist> FeaturedArtists => _featuredArtists;

        public IReadOnlyCollection<Track> Tracks => _tracks;

        public void AddTrack(Track track)
            => _tracks.Add(track);

        public void ClearTracks() => _tracks.Clear();

        public void Update(string name,
            string coverLink,
            DateTime releaseDate,
            IReadOnlyCollection<Artist> featuredArtists)
        {
            Name = name;
            CoverLink = coverLink;
            ReleaseDate = releaseDate;

            _featuredArtists.Clear();

            if (featuredArtists.Count != 0)
                _featuredArtists.AddRange(featuredArtists);
        }
    }
}
