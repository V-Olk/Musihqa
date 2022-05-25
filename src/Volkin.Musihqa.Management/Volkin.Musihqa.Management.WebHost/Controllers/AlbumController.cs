using Microsoft.AspNetCore.Mvc;
using Volkin.Musihqa.Management.Core.Domain.Management;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Create;
using Volkin.Musihqa.Management.WebHost.Models.Requests.Update;
using Volkin.Musihqa.Management.WebHost.Models.Responses;
using Volkin.Musihqa.Management.WebHost.Services;

namespace Volkin.Musihqa.Management.WebHost.Controllers
{

    /// <summary> Albums CRUD </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        //private readonly ILogger<AlbumController> _logger;//TODO

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        /// <summary> Get albums by artist id </summary>
        /// <param name="artistId">Artist id, like <example>071ac86c-db64-4548-8e24-9af58d036084</example></param>
        [HttpGet("[action]/{artistId:guid}")]
        public async Task<ActionResult<List<AlbumShortResponse>>> GetAlbumsByArtistIdAsync(Guid artistId)
        {
            IReadOnlyCollection<Album> albums = await _albumService.GetAlbumsByArtistIdAsync(artistId).ConfigureAwait(false);

            List<AlbumShortResponse> albumsResponse = albums.Select(album => new AlbumShortResponse(album)).ToList();

            return Ok(albumsResponse);
        }

        /// <summary> Get album by id with tracks </summary>
        /// <param name="id">Album id, like <example>e17f299f-92d7-459f-896e-078ed53ef99c</example></param>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AlbumResponse>> GetAlbumAsync(Guid id)
        {
            Album? album = await _albumService.GetAlbumAsync(id).ConfigureAwait(false);
            if (album is null)
                return NotFound();

            return Ok(new AlbumResponse(album));
        }

        /// <summary> Create a new album with tracks </summary>
        /// <param name="request">Request data</param>
        [HttpPost]
        public async Task<ActionResult<AlbumResponse>> CreateAlbumAsync(CreateAlbumRequest request)
        {
            Album album = await _albumService.CreateAlbumAsync(request).ConfigureAwait(false);

            return CreatedAtAction("GetAlbum", new { id = album.Id }, null);
        }

        /// <summary> Update album with tracks </summary>
        /// <param name="id">Album id, like <example>e17f299f-92d7-459f-896e-078ed53ef99c</example></param>
        /// <param name="request">Request data</param>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Album
        ///     {
        ///         "name": "Requiem updated",
        ///         "coverLink": "https://upload.wikimedia.org/wikipedia/en/4/43/Korn_-_Requiem.png",
        ///         "primaryArtist": "071ac86c-db64-4548-8e24-9af58d036084",
        ///         "tracksRequest": [
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
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AlbumResponse>> UpdateAlbumAsync(Guid id, UpdateAlbumRequest request)
        {
            Album album = await _albumService.UpdateAlbumAsync(id, request).ConfigureAwait(false);

            return new AlbumResponse(album);
        }

        /// <summary> Delete album with all its tracks </summary>
        /// <param name="id">Album id, like <example>e17f299f-92d7-459f-896e-078ed53ef99c</example></param>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AlbumShortResponse>> DeleteAlbumAsync(Guid id)
        {
            Album album = await _albumService.DeleteAlbumAsync(id).ConfigureAwait(false);

            return new AlbumShortResponse(album);
        }
    }
}
