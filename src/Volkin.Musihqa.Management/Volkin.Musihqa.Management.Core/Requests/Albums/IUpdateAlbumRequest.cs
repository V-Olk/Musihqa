namespace Volkin.Musihqa.Management.Domain.Requests.Albums;

public interface IUpdateAlbumRequest
{
    public Guid Id { get; init; }

    public string? Name { get; init; }

    public string? CoverLink { get; init; }
    public DateTime ReleaseDate { get; init; }

    public IReadOnlyCollection<Guid>? FeaturedArtistsIds { get; init; }

}