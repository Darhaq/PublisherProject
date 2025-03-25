using Microsoft.EntityFrameworkCore;
using PublisherProjectData.Data;
using PublisherProjectData.DTOs.Author;
using PublisherProjectData.DTOs.Book;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Mappers;
using PublisherProjectData.Models;

namespace PublisherProjectData.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly PublisherContext _context;

        public BookRepository(PublisherContext context)
        {
            this._context = context;
        }
        public async Task<Book> CreateAsync(Book bookModel)
        {
            
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        
        }

        public async Task<BookDto?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            if (bookModel == null)
            {
                return null;
            }

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel.FromBookToBookDto();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Books.AnyAsync(s => s.BookId == id);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.Include(c => c.Author).ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author) // Inkluder forfatteren
                .Include(b => b.Covers) // Inkluder covers
                .FirstOrDefaultAsync(x => x.BookId == id);
        }

        public async Task<BookDto?> UpdateAsync(int id, UpdateBookRequestDto bookModel)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.BookId = bookModel.BookId;
            existingBook.PublishDate = bookModel.PublishDate;
            existingBook.AuthorId = bookModel.AuthorId;
            //existingBook.Author = bookModel.Author;
            existingBook.BasePrice = bookModel.BasePrice;
            existingBook.Title = bookModel.Title;
            await _context.SaveChangesAsync();

            return existingBook.FromBookToBookDto();
        }
    }
}
