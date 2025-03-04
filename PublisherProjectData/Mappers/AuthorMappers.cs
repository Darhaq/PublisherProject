using PublisherProjectData.DTOs.Author;
using PublisherProjectData.Models;
using System.Runtime.CompilerServices;

namespace PublisherProjectData.Mappers
{
    public static class AuthorMappers
    {
        public static Author ToAuthorFromRequestUpdateDTO(this UpdateAuthorRequestDto updateAuthorRequestDto)
        {
            return new Author
            {
                FirstName = updateAuthorRequestDto.FirstName,
                LastName = updateAuthorRequestDto.LastName,
            };
        }

        public static Author ToAuthorFromRequestCreateDto(this RequestCreateAuthorDto createDto)
        {
            return new Author
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName
            };
        }
        public static AuthorDto ToAuthorDto(this Author authorModel)
        {
            return new AuthorDto
            {
                AuthorId = authorModel.AuthorId,
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName,

                // Books = authorModel.Books.Select(c => c.ToBookDto()).ToList(),
                 Books = authorModel.Books.Select(c => c.FromBookToRequestCreateBookDto()).ToList(),
            };
        }

    }
}
