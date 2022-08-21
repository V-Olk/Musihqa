using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.UseCases.Handlers;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.GetByArtistId
{
    internal class GetByArtistIdHandler : IQueryHandler<GetAlbumsByArtistIdQuery, GetAlbumsByArtistIdResult>
    {
        private readonly IManagementUnitOfWork _managementUnitOfWork;

        public GetByArtistIdHandler(IManagementUnitOfWork managementUnitOfWork)
        {
            _managementUnitOfWork = managementUnitOfWork;
        }

        public async Task<GetAlbumsByArtistIdResult> Handle(GetAlbumsByArtistIdQuery request,
            CancellationToken cancellationToken)
        {
            var albums = await _managementUnitOfWork.Album.GetByArtistIdAsync(request.ArtistId, cancellationToken);

            return new GetAlbumsByArtistIdResult(albums);
        }
    }
}
