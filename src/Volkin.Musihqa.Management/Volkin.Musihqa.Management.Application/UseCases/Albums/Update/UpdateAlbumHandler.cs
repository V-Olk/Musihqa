using Volkin.Musihqa.Management.Application.Mappers;
using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Exceptions;
using Volkin.Musihqa.Management.Domain.Models.Management;
using Volkin.Musihqa.Management.Domain.Requests.Tracks;
using Volkin.Musihqa.Management.Domain.UseCases.Handlers;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Update
{
    internal class UpdateAlbumHandler : ICommandHandler<UpdateAlbumCommand, UpdateAlbumResult>
    {
        private readonly IManagementUnitOfWork _managementUnitOfWork;

        public UpdateAlbumHandler(IManagementUnitOfWork managementUnitOfWork)
        {
            _managementUnitOfWork = managementUnitOfWork;
        }

        public async Task<UpdateAlbumResult> Handle(UpdateAlbumCommand updateAlbumCommand, CancellationToken cancellationToken)
        {
            var request = updateAlbumCommand.Request;

            Album? album = await _managementUnitOfWork.Album.GetFullAlbumByIdOrDefaultAsync(request.Id, cancellationToken);
            if (album is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Album), request.Id);

            IReadOnlyCollection<Artist> featuredArtists;
            if (request.FeaturedArtistsIds is null)
                featuredArtists = new List<Artist>();
            else
                featuredArtists = await _managementUnitOfWork.Artist.GetByIdsAsync(request.FeaturedArtistsIds, cancellationToken);

            album.Update(request.Name!, request.CoverLink!, request.ReleaseDate, featuredArtists);

            if (request.TracksRequest != null)
                await UpdateTrackList(request.TracksRequest, album, cancellationToken);

            await _managementUnitOfWork.CompleteAsync(cancellationToken);

            return new UpdateAlbumResult(album);

        }

        private async Task UpdateTrackList(List<IUpdateTrackRequest> tracksRequest, Album album, CancellationToken cancellationToken)
        {
            var oldTracks = album.Tracks.ToDictionary(key => key.Id);
            album.ClearTracks();

            foreach (var trackRequest in tracksRequest)
            {
                IEnumerable<Artist> featuredArtists;
                if (trackRequest.FeaturedArtistsIds != null)
                {
                    featuredArtists = await _managementUnitOfWork.Artist
                        .GetByIdsAsync(trackRequest.FeaturedArtistsIds, cancellationToken);
                }
                else
                {
                    featuredArtists = new List<Artist>();
                }

                Track track = AlbumMapper
                    .MapTrackFromUpdateRequest(trackRequest, album.PrimaryArtist, featuredArtists, oldTracks);

                album.AddTrack(track);

            }
        }
    }
}
