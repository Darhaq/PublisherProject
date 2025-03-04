using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PublisherProjectData.DTOs.Book
{
    public class RequestCreateBookDto
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public DateOnly PublishDate { get; set; }
        [Required]
        public decimal BasePrice { get; set; }

        //[Precision(12, 2)]
        //public decimal SalesPrice { get; set; }
        [Required]
        public int AuthorId { get; set; }
        //public Cover Cover { get; set; }
    }
}
