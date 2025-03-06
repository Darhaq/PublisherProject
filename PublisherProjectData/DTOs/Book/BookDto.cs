using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PublisherProjectData.DTOs.Book
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal BasePrice { get; set; }
        public DateOnly PublishDate { get; set; }

        //[Precision(12, 2)]
        //public decimal SalesPrice { get; set; }
        public int Rating { get; set; }
        [JsonIgnore]
        public PublisherProjectData.Models.Author? Author { get; set; }
        public int AuthorId { get; set; }
    }
}
