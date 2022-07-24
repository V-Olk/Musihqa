using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Exceptions;
using Volkin.Musihqa.Management.Domain.Models.Management;
using Volkin.Musihqa.Management.WebHost.Mappers;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Create;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Update;

namespace Volkin.Musihqa.Management.WebHost.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IManagementUnitOfWork _managementUnitOfWork;

        public AlbumService(IManagementUnitOfWork managementUnitOfWork)
        {
            _managementUnitOfWork = managementUnitOfWork;
        }

        public async Task<Album?> GetAlbumAsync(Guid id, CancellationToken cancellationToken)
            => await _managementUnitOfWork.Album.GetFullAlbumByIdOrDefaultAsync(id, cancellationToken);

        public async Task<IReadOnlyCollection<Album>> GetAlbumsByArtistIdAsync(Guid artistId, CancellationToken cancellationToken)
            => await _managementUnitOfWork.Album.GetByArtistIdAsync(artistId, cancellationToken);

        public async Task<Album> CreateAlbumAsync(CreateAlbumRequest request, CancellationToken cancellationToken)
        {
            Artist? artist = await _managementUnitOfWork.Artist.GetByIdOrDefaultAsync(request.PrimaryArtist, cancellationToken);
            if (artist is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Artist), request.PrimaryArtist);

            IReadOnlyCollection<Artist> featuredArtists;
            if (request.FeaturedArtistsIds is null)
                featuredArtists = new List<Artist>();
            else
                featuredArtists = await _managementUnitOfWork.Artist.GetByIdsAsync(request.FeaturedArtistsIds, cancellationToken);

            Album album = AlbumMapper.MapFromCreateRequest(request, artist, featuredArtists);
            await CreateTrackList(request.TracksRequest!, album, cancellationToken);

            await _managementUnitOfWork.Album.AddAsync(album, cancellationToken);
            await _managementUnitOfWork.CompleteAsync(cancellationToken);

            return album;
        }

        public async Task<Album> UpdateAlbumAsync(Guid id, UpdateAlbumRequest request, CancellationToken cancellationToken)
        {
            Album? album = await _managementUnitOfWork.Album.GetFullAlbumByIdOrDefaultAsync(id, cancellationToken);
            if (album is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Album), id);

            IReadOnlyCollection<Artist> featuredArtists;
            if (request.FeaturedArtistsIds is null)
                featuredArtists = new List<Artist>();
            else
                featuredArtists = await _managementUnitOfWork.Artist.GetByIdsAsync(request.FeaturedArtistsIds, cancellationToken);

            album.Update(request.Name!, request.CoverLink!, request.ReleaseDate, featuredArtists);

            if (request.TracksRequest != null)
                await UpdateTrackList(request.TracksRequest, album, cancellationToken);

            await _managementUnitOfWork.CompleteAsync(cancellationToken);

            return album;
        }

        public async Task<Album> DeleteAlbumAsync(Guid id, CancellationToken cancellationToken)
        {
            Album? album = await _managementUnitOfWork.Album.GetByIdOrDefaultAsync(id, cancellationToken);
            if (album is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Album), id);

            _managementUnitOfWork.Album.Delete(album);
            await _managementUnitOfWork.CompleteAsync(cancellationToken);

            return album;
        }

        private async Task CreateTrackList(List<CreateTrackRequest> tracksRequest, Album album, CancellationToken cancellationToken)
        {
            foreach (CreateTrackRequest trackRequest in tracksRequest)
            {
                IReadOnlyCollection<Artist> featuredArtists;
                if (trackRequest.FeaturedArtistsIds != null)
                {
                    featuredArtists = await _managementUnitOfWork.Artist
                        .GetByIdsAsync(trackRequest.FeaturedArtistsIds, cancellationToken);
                }
                else
                {
                    featuredArtists = new List<Artist>();
                }

                Track track = AlbumMapper.MapTrackFromCreateRequest(trackRequest, album.PrimaryArtist, featuredArtists);
                album.AddTrack(track);
            }
        }

        private async Task UpdateTrackList(List<UpdateTrackRequest> tracksRequest, Album album, CancellationToken cancellationToken)
        {
            var oldTracks = album.Tracks.ToDictionary(key => key.Id);
            album.ClearTracks();

            foreach (UpdateTrackRequest trackRequest in tracksRequest)
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
