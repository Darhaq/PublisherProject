using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherProjectData.DTOs.Artist;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Models;

namespace PublisherProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistsController(IArtistRepository artistRepository)
        {
            this._artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artists = await _artistRepository.GetAllAsync();
            var artistDtos = artists.Select(s => new ArtistDto
            {
                ArtistId = s.ArtistId,
                FirstName = s.FirstName,
                LastName = s.LastName
            });
            return Ok(artistDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artist = await _artistRepository.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            var artistDto = new ArtistDto
            {
                ArtistId = artist.ArtistId,
                FirstName = artist.FirstName,
                LastName = artist.LastName
            };
            return Ok(artistDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateArtistDto createArtistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artistModel = new Artist
            {
                FirstName = createArtistDto.FirstName,
                LastName = createArtistDto.LastName
            };

            await _artistRepository.CreateAsync(artistModel);
            return CreatedAtAction(nameof(GetArtistById), new { id = artistModel.ArtistId }, artistModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestUpdateArtistDto updateArtistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artistModel = new Artist
            {
                ArtistId = updateArtistDto.ArtistId,
                FirstName = updateArtistDto.FirstName,
                LastName = updateArtistDto.LastName
            };

            var artist = await _artistRepository.UpdateAsync(id, artistModel);
            if (artist == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artist = await _artistRepository.DeleteAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
