namespace rocToURL.Models
{
    public class URL
    {
        public Guid Id { get; set; }    
        public string LongURL { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
