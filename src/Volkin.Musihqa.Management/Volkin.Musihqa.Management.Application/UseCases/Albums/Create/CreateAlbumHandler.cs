using Volkin.Musihqa.Management.Application.Mappers;
using Volkin.Musihqa.Management.Domain.Abstractions;
using Volkin.Musihqa.Management.Domain.Exceptions;
using Volkin.Musihqa.Management.Domain.Models.Management;
using Volkin.Musihqa.Management.Domain.Requests.Tracks;
using Volkin.Musihqa.Management.Domain.UseCases.Handlers;

namespace Volkin.Musihqa.Management.Application.UseCases.Albums.Create;

public class CreateAlbumHandler : ICommandHandler<CreateAlbumCommand, CreateAlbumResult>
{
    private readonly IManagementUnitOfWork _managementUnitOfWork;

    public CreateAlbumHandler(IManagementUnitOfWork managementUnitOfWork)
    {
        _managementUnitOfWork = managementUnitOfWork;
    }
    
    public async Task<CreateAlbumResult> Handle(CreateAlbumCommand createAlbumCommand, CancellationToken cancellationToken)
    {
        var request = createAlbumCommand.Request;
        
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

        return new CreateAlbumResult(album);
    }
    
    private async Task CreateTrackList(List<ICreateTrackRequest> tracksRequest, Album album, CancellationToken cancellationToken)
    {
        foreach (ICreateTrackRequest trackRequest in tracksRequest)
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
}