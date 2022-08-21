using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.GetByArtistId;

public class GetAlbumsByArtistIdQuery : IQuery<GetAlbumsByArtistIdResult>
{
    public GetAlbumsByArtistIdQuery(Guid artistId)
    {
        ArtistId = artistId;
    }

    public Guid ArtistId { get; }
}