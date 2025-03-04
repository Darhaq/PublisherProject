using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherProject.DTOs.Author;
using PublisherProjectData.DTOs.Book;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Mappers;

namespace PublisherProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            //this._context = context;
            _bookRepository = bookRepository;
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
    }
}
