using System.ComponentModel.DataAnnotations;

namespace rocToURL.Models
{
    public class URL
    {
        public Guid Id { get; set; }

        [Required]
        public string LongUrl { get; set; }

        public string ShortUrl { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
