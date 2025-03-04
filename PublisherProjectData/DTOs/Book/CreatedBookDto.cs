using System.ComponentModel.DataAnnotations;

namespace PublisherProjectData.DTOs.Book
{
    public class CreatedBookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly PublishDate { get; set; }
        public decimal BasePrice { get; set; }

        //[Precision(12, 2)]
        //public decimal SalesPrice { get; set; }

        [Range(1, 13, ErrorMessage = "Price must be between 1 and 13.")]
        public int Rating { get; set; }
        public Models.Author Author { get; set; } = null!;
        public int AuthorId { get; set; }
    }
}
