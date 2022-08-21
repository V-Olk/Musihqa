using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.GetByArtistId;

public class GetAlbumsByArtistIdResult
{
    public GetAlbumsByArtistIdResult(IReadOnlyCollection<Album> albums)
    {
        Albums = albums;
    }

    public IReadOnlyCollection<Album> Albums { get; }
}