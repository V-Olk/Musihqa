using Volkin.Musihqa.Management.Core.Abstractions;
using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.WebHost.Common.Exceptions;
using Volkin.Musihqa.Management.WebHost.Mappers;
using Volkin.Musihqa.Management.WebHost.Models.Requests;

namespace Volkin.Musihqa.Management.WebHost.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IManagementUnitOfWork _managementUnitOfWork;

        public AlbumService(IManagementUnitOfWork managementUnitOfWork)
        {
            _managementUnitOfWork = managementUnitOfWork;
        }

        public async Task<Album?> GetAlbumAsync(Guid id)
            => await _managementUnitOfWork.Album.GetByIdAsync(id).ConfigureAwait(false);

        public async Task<List<Album>> GetAlbumsByArtistIdAsync(Guid artistId)
            => await _managementUnitOfWork.Album.GetByArtistIdAsync(artistId).ConfigureAwait(false);

        public async Task<Album> CreateAlbumAsync(CreateOrUpdateAlbumRequest request)
        {
            Artist? artist = await _managementUnitOfWork.Artist.GetByIdAsync(request.PrimaryArtist).ConfigureAwait(false);
            if (artist is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Artist), request.PrimaryArtist);

            IEnumerable<Artist> featuredArtists;
            if (request.FeaturedArtistsIds is null)
                featuredArtists = new List<Artist>();
            else
                featuredArtists = await _managementUnitOfWork.Artist.GetByIdsAsync(request.FeaturedArtistsIds).ConfigureAwait(false);

            Album album = AlbumMapper.MapFromRequest(request, artist, featuredArtists);

            if (request.TracksRequest == null)
                throw new ArgumentException("TracksRequest cannot be null", nameof(request.TracksRequest));

            await UpdateTrackList(request.TracksRequest, album).ConfigureAwait(false);

            await _managementUnitOfWork.Album.AddAsync(album).ConfigureAwait(false);

            return album;
        }

        public async Task<Album> UpdateAlbumAsync(Guid id, CreateOrUpdateAlbumRequest request)
        {
            Album? album = await _managementUnitOfWork.Album.GetByIdAsync(id).ConfigureAwait(false);
            if (album is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Album), id);

            Artist? artist = await _managementUnitOfWork.Artist.GetByIdAsync(request.PrimaryArtist).ConfigureAwait(false);
            if (artist is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Artist), request.PrimaryArtist);

            IEnumerable<Artist> featuredArtists;
            if (request.FeaturedArtistsIds is null)
                featuredArtists = new List<Artist>();
            else
                featuredArtists = await _managementUnitOfWork.Artist.GetByIdsAsync(request.FeaturedArtistsIds).ConfigureAwait(false);
            AlbumMapper.MapFromRequest(request, artist, featuredArtists, album);

            if (request.TracksRequest != null)
                await UpdateTrackList(request.TracksRequest, album).ConfigureAwait(false);

            await _managementUnitOfWork.Album.UpdateAsync().ConfigureAwait(false);

            return album;
        }

        public async Task<Album> DeleteAlbumAsync(Guid id)
        {
            Album? album = await _managementUnitOfWork.Album.GetByIdAsync(id).ConfigureAwait(false);
            if (album is null)
                throw new EntityNotFoundException(nameof(_managementUnitOfWork.Album), id);

            await _managementUnitOfWork.Album.DeleteAsync(album).ConfigureAwait(false);

            return album;
        }

        private async Task UpdateTrackList(List<CreateOrUpdateTrackRequest> tracksRequest, Album album)
        {
            ICollection<Track> oldTracks = album.Tracks;
            album.Tracks = new List<Track>();
            foreach (CreateOrUpdateTrackRequest trackRequest in tracksRequest)
            {
                IEnumerable<Artist> featuredArtists;
                if (trackRequest.FeaturedArtistsIds != null)
                {
                    featuredArtists = await _managementUnitOfWork.Artist
                        .GetByIdsAsync(trackRequest.FeaturedArtistsIds).ConfigureAwait(false);
                }
                else
                {
                    featuredArtists = new List<Artist>();
                }

                AlbumMapper.MapTrackFromRequest(album, trackRequest, album.PrimaryArtist, featuredArtists, oldTracks);
            }
        }
    }
}
