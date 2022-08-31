using Volkin.Musihqa.Management.Domain.Models.Management;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Delete;

public class DeleteAlbumResult
{
    public DeleteAlbumResult(Album album)
    {
        Album = album;
    }

    public Album Album { get; }
}