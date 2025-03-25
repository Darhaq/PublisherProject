using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherProjectData.Data;
using PublisherProjectData.Models;
using PublisherProjectData.DTOs.Author;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Mappers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PublisherProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
  
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            //this._context = context;
            this._authorRepository = authorRepository;
        }

        // https://localhost:7135/api/authors
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authors = await _authorRepository.GetAllAsync();
            var authorDtos = authors.Select(s => s.ToAuthorDto());
            return Ok(authorDtos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = await _authorRepository.GetByIdAsync(id, false);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author.ToAuthorDto());

        }

        [HttpDelete("{id}")]
        //public string DeleteAuthor(int id)
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorModel = await _authorRepository.DeleteAsync(id);

            if (authorModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateAuthorDto createAuthorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var authorModel = createAuthorDto.ToAuthorFromRequestCreateDto();

            await _authorRepository.CreateAsync(authorModel);

            return CreatedAtAction(nameof(GetAuthorById), new { id = authorModel.AuthorId }, authorModel);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateAuthorRequestDto authorToUpdate)
        {
            if (id != authorToUpdate.AuthorId)
            {
                return BadRequest("AuthorId mismatch");
            }

            var authorUpdated = await _authorRepository.UpdateAsync(id, authorToUpdate);
            if (authorUpdated == null)
            {
                return BadRequest("Author not updated");
            }

            return NoContent();

        }

    }
}
