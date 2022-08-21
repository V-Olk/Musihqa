using Volkin.Musihqa.Management.Domain.UseCases;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.GetById;

public class GetAlbumByIdQuery : IQuery<GetAlbumByIdResult>
{

    public GetAlbumByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}