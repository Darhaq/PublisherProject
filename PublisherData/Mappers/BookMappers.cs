﻿using PublisherData.DTOs.Book;
using PublisherData.Models;

namespace PublisherData.Mappers
{
    public static class BookMappers
    {
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
