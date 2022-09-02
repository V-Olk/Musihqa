using Microsoft.AspNetCore.Mvc;
using Volkin.Musihqa.Management.Application.UseCases.Albums.Create;
using Volkin.Musihqa.Management.Application.UseCases.Albums.Delete;
using Volkin.Musihqa.Management.Application.UseCases.Albums.GetByArtistId;
using Volkin.Musihqa.Management.Application.UseCases.Albums.GetById;
using Volkin.Musihqa.Management.Application.UseCases.Albums.Update;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Create;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Update;
using Volkin.Musihqa.Management.WebHost.Models.Responses;

namespace Volkin.Musihqa.Management.WebHost.Controllers
{

    /// <summary> Albums CRUD </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlbumController : MediatRControllerBase
    {
        //private readonly ILogger<AlbumController> _logger;//TODO

        /// <summary> Get albums by artist id </summary>
        /// <param name="artistId">Artist id, like <example>071ac86c-db64-4548-8e24-9af58d036084</example></param>
        /// <param name="cancellationToken"></param>
        [HttpGet("[action]/{artistId:guid}")]
        public async Task<ActionResult<AlbumsByArtistIdResponse>> GetAlbumsByArtistIdAsync(Guid artistId,
            CancellationToken cancellationToken)
        {
            GetAlbumsByArtistIdResult albumsByArtistIdResult = await Send(new GetAlbumsByArtistIdQuery(artistId), cancellationToken);

            if (!albumsByArtistIdResult.Albums.Any())
                return NotFound();

            return Ok(new AlbumsByArtistIdResponse(albumsByArtistIdResult));
        }

        /// <summary> Get album by id with tracks </summary>
        /// <param name="id">Album id, like <example>e17f299f-92d7-459f-896e-078ed53ef99c</example></param>
        /// <param name="cancellationToken"></param>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AlbumResponse>> GetAlbumAsync(Guid id, CancellationToken cancellationToken)
        {
            GetAlbumByIdResult albumByIdResult = await Send(new GetAlbumByIdQuery(id), cancellationToken);

            if (albumByIdResult.Album is null)
                return NotFound();

            return Ok(new AlbumResponse(albumByIdResult.Album));
        }

        /// <summary> Create a new album with tracks </summary>
        /// <param name="request">Request data</param>
        /// <param name="cancellationToken"></param>
        [HttpPost]
        public async Task<ActionResult<AlbumResponse>> CreateAlbumAsync(CreateAlbumRequest request, CancellationToken cancellationToken)
        {
            CreateAlbumResult createAlbumResult = await Send(new CreateAlbumCommand(request), cancellationToken);
            
            return CreatedAtAction("GetAlbum", new { id = createAlbumResult.Album.Id }, null);
        }

        /// <summary> Update album with tracks </summary>
        /// <param name="request">Request data</param>
        /// <param name="cancellationToken"></param>
        /// /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Album
        ///     {
        ///         "id": "e17f299f-92d7-459f-896e-078ed53ef99c",
        ///         "name": "Requiem updated",
        ///         "coverLink": "https://upload.wikimedia.org/wikipedia/en/4/43/Korn_-_Requiem.png",
        ///         "primaryArtist": "071ac86c-db64-4548-8e24-9af58d036084",
        ///         "updateTracksRequests": [
        ///             {
        ///                 "trackId": "b63de284-a032-4c4f-9d51-37ff409b15ae",
        ///                 "trackName": "Forgotten updated"
        ///             },
        ///             {
        ///                 "trackId": "b64de284-a032-4c4f-9d51-37ff409b15ae",
        ///                 "trackName": "Lost in the Grandeur"
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        [HttpPut]
        public async Task<ActionResult<AlbumResponse>> UpdateAlbumAsync(UpdateAlbumRequest request, CancellationToken cancellationToken)
        {
            UpdateAlbumResult createAlbumResult = await Send(new UpdateAlbumCommand(request, request.UpdateTracksRequests), cancellationToken);

            return new AlbumResponse(createAlbumResult.Album);
        }

        /// <summary> Delete album with all its tracks </summary>
        /// <param name="id">Album id, like <example>e17f299f-92d7-459f-896e-078ed53ef99c</example></param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AlbumShortResponse>> DeleteAlbumAsync(Guid id, CancellationToken cancellationToken)
        {
            DeleteAlbumResult deleteAlbumResult = await Send(new DeleteAlbumCommand(id), cancellationToken);

            return new AlbumShortResponse(deleteAlbumResult.Album);
        }
    }
}
