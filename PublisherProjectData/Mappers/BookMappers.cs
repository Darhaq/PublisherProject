using PublisherProjectData.DTOs.Book;
using PublisherProjectData.Models;
using System.Runtime.CompilerServices;

namespace PublisherProjectData.Mappers
{
    public static class BookMappers
    {
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

        //public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
        //{
        //    return new Comment
        //    {
        //        Title = commentDto.Title,
        //        Content = commentDto.Content,
        //        StockId = stockId
        //    };
        //}

        //public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
        //{
        //    return new Comment
        //    {
        //        Title = commentDto.Title,
        //        Content = commentDto.Content,
        //    };
        //}
    }
}
