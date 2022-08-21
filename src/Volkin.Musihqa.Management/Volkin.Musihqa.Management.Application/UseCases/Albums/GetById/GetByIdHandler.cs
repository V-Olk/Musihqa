using Volkin.Musihqa.Management.Application.UseCases.Albums.GetByArtistId;
using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.UseCases.Handlers;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.GetById
{
    internal class GetByIdHandler : IQueryHandler<GetAlbumByIdQuery, GetAlbumByIdResult>
    {
        private readonly IManagementUnitOfWork _managementUnitOfWork;

        public GetByIdHandler(IManagementUnitOfWork managementUnitOfWork)
        {
            _managementUnitOfWork = managementUnitOfWork;
        }

        public async Task<GetAlbumByIdResult> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
             var album = await _managementUnitOfWork.Album.GetFullAlbumByIdOrDefaultAsync(request.Id, cancellationToken);
             return new GetAlbumByIdResult(album);
        }
    }
}
