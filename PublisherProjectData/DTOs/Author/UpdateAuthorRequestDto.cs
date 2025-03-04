using PublisherProjectData.Models;
using System.ComponentModel.DataAnnotations;

namespace PublisherProjectData.DTOs.Author
{
    public class UpdateAuthorRequestDto
    {
        // I thought about this. Should i bring in the books? I did not since that would be an update to the book itself.
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
