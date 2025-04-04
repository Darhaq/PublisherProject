﻿using PublisherData.DTOs.Author;
using PublisherData.Models;

namespace PublisherData.Interfaces
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id, bool withoutBooks); // FirstOrDefault can be NULL
        Task<Author> CreateAsync(Author authorModel);
        Task<Author?> UpdateAsync(int id, UpdateAuthorRequestDto authorModel);
        Task<Author?> DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
