using PublisherProjectData.DTOs.Book;
using PublisherProjectData.Models;
using System.Runtime.CompilerServices;

namespace PublisherProjectData.Mappers
{
    public static class BookMappers
    {
        public static BookDto FromUpdateBookRequestDtoToBookDto(this UpdateBookRequestDto updateBookRequestDto)
        {
            return new BookDto
            {
                BookId = updateBookRequestDto.BookId,
                Title = updateBookRequestDto.Title,
                AuthorId = updateBookRequestDto.AuthorId,
                BasePrice = updateBookRequestDto.BasePrice,
                PublishDate = updateBookRequestDto.PublishDate,
                Rating = updateBookRequestDto.Rating,
            };
        }

        public static RequestCreateBookDto FromBookToRequestCreateBookDto(this Book book)
        {
            return new RequestCreateBookDto
            {
                AuthorId = book.AuthorId,
                BasePrice = book.BasePrice,
                PublishDate = book.PublishDate,
                Title = book.Title,
            };
        }
        public static Book ToBookDto(this RequestCreateBookDto bookDto)
        {
            return new Book
            {
                AuthorId = bookDto.AuthorId,
                BasePrice = bookDto.BasePrice,
                PublishDate = bookDto.PublishDate,
                Title = bookDto.Title,
            };
        }

        public static BookDto FromBookToBookDto(this Book book)
        {
            return new BookDto
            {
                BookId = book.BookId,
                Author = book.Author,
                AuthorId = book.AuthorId,
                BasePrice = book.BasePrice,
                PublishDate = book.PublishDate,
                Title = book.Title,
                Rating = book.Rating,
            };
        }

        public static CreatedBookDto FromBookToCreatedBookDto(this Book bookDto)
        {
            return new CreatedBookDto
            {
                BookId = bookDto.BookId,
                AuthorId = bookDto.AuthorId,
                BasePrice = bookDto.BasePrice,
                PublishDate = bookDto.PublishDate,
                Title = bookDto.Title,
            };

        }
    }
}
