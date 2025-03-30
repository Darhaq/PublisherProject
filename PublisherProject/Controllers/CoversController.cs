using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherProjectData.DTOs.Cover;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Mappers;
using PublisherProjectData.Models;

namespace PublisherProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoversController : ControllerBase
    {
        private readonly ICoverRepository _coverRepository;

        public CoversController(ICoverRepository coverRepository)
        {
            this._coverRepository = coverRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCovers()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var covers = await _coverRepository.GetAllAsync();
            var coverDtos = covers.Select(s => s.ToCoverDto());
            return Ok(coverDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoverById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cover = await _coverRepository.GetByIdAsync(id);
            if (cover == null)
            {
                return NotFound();
            }

            return Ok(cover.ToCoverDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateCoverDto createCoverDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var coverModel = createCoverDto.ToCoverFromRequestCreateDto();
            await _coverRepository.CreateAsync(coverModel);
            return CreatedAtAction(nameof(GetCoverById), new { id = coverModel.CoverId }, coverModel.ToCoverDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestUpdateCoverDto updateCoverDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var coverModel = updateCoverDto.ToCoverFromRequestUpdateDto();
            var cover = await _coverRepository.UpdateAsync(id, coverModel);
            if (cover == null)
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

            var cover = await _coverRepository.DeleteAsync(id);
            if (cover == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
