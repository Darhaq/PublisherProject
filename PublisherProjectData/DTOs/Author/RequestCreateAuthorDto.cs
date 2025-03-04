using System.ComponentModel.DataAnnotations;

namespace PublisherProjectData.DTOs.Author
{
    public class RequestCreateAuthorDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
