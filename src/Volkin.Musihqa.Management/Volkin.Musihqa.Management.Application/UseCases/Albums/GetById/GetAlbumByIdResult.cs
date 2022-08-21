using Volkin.Musihqa.Management.Domain.Models.Management;
using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.GetById;

public class GetAlbumByIdResult : IQuery<GetAlbumByIdResult>
{

    public GetAlbumByIdResult(Album? album)
    {
        Album = album;
    }
    public Album? Album { get; }
}