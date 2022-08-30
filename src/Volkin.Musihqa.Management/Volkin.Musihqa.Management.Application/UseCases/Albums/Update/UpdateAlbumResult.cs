using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Update;

public class UpdateAlbumResult
{

    public UpdateAlbumResult(Album album)
    {
        Album = album;
    }

    public Album Album { get; }
}