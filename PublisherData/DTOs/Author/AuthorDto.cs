﻿using PublisherData.DTOs.Book;
using PublisherData.Models;
using System.ComponentModel.DataAnnotations;

namespace PublisherData.DTOs.Author
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RequestCreateBookDto> Books { get; set; } = new List<RequestCreateBookDto>();
    }
}
