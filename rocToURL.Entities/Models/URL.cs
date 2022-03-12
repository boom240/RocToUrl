using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rocToURL.Entities.Models
{
    public class URL
    {
        public Guid Id { get; set; }

        [Required]
        public string LongUrl { get; set; }

        public string ShortUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("segment")]
        [StringLength(20)]
        public string Segment { get; set; }

        [Required]
        [Column("ip")]
        [StringLength(50)]
        public string Ip { get; set; }
    }
}
