using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Create;

public class CreateAlbumResult
{
    public CreateAlbumResult(Album album)
    {
        Album = album;
    }

    public Album Album { get; }
}