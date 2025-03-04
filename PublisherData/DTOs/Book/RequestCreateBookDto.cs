using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PublisherData.DTOs.Book
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

        [Range(1, 13, ErrorMessage = "Price must be between 1 and 13.")]
        public int Rating { get; set; }
        [Required]
        public int AuthorId { get; set; }
        //public Cover Cover { get; set; }
    }
}
