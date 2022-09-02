namespace Volkin.Musihqa.Management.Domain.Requests.Albums;

public interface ICreateAlbumRequest
{
    public string? Name { get; init; }

    public string? CoverLink { get; init; }
        
    public DateTime ReleaseDate { get; init; }

    public Guid PrimaryArtist { get; init; }

    public IReadOnlyCollection<Guid>? FeaturedArtistsIds { get; init; }
}