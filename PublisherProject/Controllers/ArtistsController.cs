using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherProjectData.DTOs.Artist;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Mappers;
using PublisherProjectData.Models;

namespace PublisherProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var artistDtos = artists.Select(s => s.ToArtistDto());
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

            return Ok(artist.ToArtistDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateArtistDto createArtistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artistModel = createArtistDto.ToArtistFromRequestCreateDto();
            await _artistRepository.CreateAsync(artistModel);
            return CreatedAtAction(nameof(GetArtistById), new { id = artistModel.ArtistId }, artistModel.ToArtistDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestUpdateArtistDto updateArtistDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var artistModel = updateArtistDto.ToArtistFromRequestUpdateDto();
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
