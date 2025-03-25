using PublisherProjectData.Models;
using PublisherProjectData.DTOs.Book;
using System.ComponentModel.DataAnnotations;

namespace PublisherProjectData.DTOs.Author
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public List<RequestCreateBookDto> Books { get; set; } = new List<RequestCreateBookDto>();
    }
}
