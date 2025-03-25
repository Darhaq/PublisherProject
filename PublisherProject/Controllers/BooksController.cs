using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherProjectData.DTOs.Author;
using PublisherProjectData.DTOs.Book;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Mappers;
using PublisherProjectData.Repositories;

namespace PublisherProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Beskyt hele controlleren
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            //this._context = context;
            this._bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var books = await _bookRepository.GetAllAsync();
            var bookDtos = books.Select(s => s.FromBookToBookDto());
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            BookDto BookDto = book.FromBookToBookDto();
            return Ok(BookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestCreateBookDto createBookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bookModel = createBookDto.ToBookDto();

            await _bookRepository.CreateAsync(bookModel);

            return Ok(bookModel);
            // return CreatedAtAction(nameof(GetBookById), new { id = authorModel.AuthorId }, authorModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBookRequestDto bookToUpdate)
        {
            if (id != bookToUpdate.AuthorId)
            {
                return BadRequest("BookId mismatch");
            }

            var bookUpdated = await _bookRepository.UpdateAsync(id, bookToUpdate);
            if (bookUpdated == null)
            {
                return BadRequest("Book not updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bookModel = await _bookRepository.DeleteAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
