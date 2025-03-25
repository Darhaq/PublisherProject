using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherProjectData.DTOs.Cover
{
    public class RequestCreateCoverDto
    {
        [Required]
        public string DesignIdeas { get; set; } = null!;
        [Required]
        public bool DigitalOnly { get; set; }
    }
}
