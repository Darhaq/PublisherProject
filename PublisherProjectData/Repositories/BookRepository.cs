using PublisherProjectData.Data;
using PublisherProjectData.DTOs.Book;
using PublisherProjectData.Interfaces;
using PublisherProjectData.Models;

namespace PublisherProjectData.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly PublisherContext _context;

        public BookRepository(PublisherContext context)
        {
            _context = context;
        }
        public async Task<Book> CreateAsync(Book bookModel)
        {
            
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        
        }

        public Task<Book?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> UpdateAsync(int id, UpdateBookRequestDto bookModel)
        {
            throw new NotImplementedException();
        }
    }
}
