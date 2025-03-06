using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Models;

namespace PublisherProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoversController : ControllerBase
    {
        private readonly ICoverRepository _coverRepository;
        public CoversController(ICoverRepository coverRepository)
        {
            _coverRepository = coverRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetCovers()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var covers = await _coverRepository.GetAllAsync();
            return Ok(covers);
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
            return Ok(cover);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cover cover)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await _coverRepository.CreateAsync(cover);
            return Ok(cover);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cover cover)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var updatedCover = await _coverRepository.UpdateAsync(id, cover);
            if (updatedCover == null)
            {
                return NotFound();
            }
            return Ok(updatedCover);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var deletedCover = await _coverRepository.DeleteAsync(id);
            if (deletedCover == null)
            {
                return NotFound();
            }
            return Ok(deletedCover);
        }
    }
}
