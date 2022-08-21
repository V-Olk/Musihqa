using Volkin.Musihqa.Management.Application.UseCases.Albums.GetByArtistId;
using Volkin.Musihqa.Management.WebHost.Models.Responses;

namespace Volkin.Musihqa.Management.WebHost.Controllers;

public class AlbumsByArtistIdResponse
{
    public AlbumsByArtistIdResponse(GetAlbumsByArtistIdResult result)
    {
        Albums = result.Albums.Select(a => new AlbumShortResponse(a));
    }

    public IEnumerable<AlbumShortResponse> Albums { get; init; }
}