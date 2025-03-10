﻿using PublisherProjectData.DTOs.Author;
using PublisherProjectData.Models;
using PublisherProjectData.DTOs.Book;

namespace PublisherProjectData.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id); // FirstOrDefault can be NULL
        Task<Book> CreateAsync(Book bookModel);
        Task<BookDto?> UpdateAsync(int id, UpdateBookRequestDto bookModel);
        Task<BookDto?> DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
