using rocToURL.Abstractions;
using rocToURL.Data;
using rocToURL.Entities;
using rocToURL.Entities.Models;
using System.Linq;

namespace rocToURL.Services
{
    public class UrlServiceImplementation : IUrlService
    {
        private rocToURLContext dbContext;

        public UrlServiceImplementation(rocToURLContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc/>
        public Task<URL> MinifyUrl(string longUrl, string ip, string segment = "")
        {
            return Task.Run(() =>
            {
                URL url;

                url = dbContext.URL.Where(u => u.LongUrl == longUrl).FirstOrDefault();

                if (url != null)
                {
                    return url;
                }

                if (!string.IsNullOrEmpty(segment))
                {
                    if (dbContext.URL.Where(url => url.Segment == segment).Any())
                    {
                        throw new ArgumentException("Segment already exists");
                    }
                }
                else
                {
                    segment = this.NewSegment();
                }

                if (string.IsNullOrEmpty(segment))
                {
                    throw new ArgumentException("Segment is empty");
                }

                url = new URL()
                {
                    CreatedDate = DateTime.Now,
                    Ip = ip,
                    LongUrl = longUrl,
                    Segment = segment
                };

                dbContext.URL.Add(url);

                dbContext.SaveChanges();

                return url;
            });
        }

        private string NewSegment()
        {
            int i = 0;
            while (true)
            {
                string segment = Guid.NewGuid().ToString().Substring(0, 6);
                if (!dbContext.URL.Where(url => url.Segment == segment).Any())
                {
                    return segment;
                }
                if (i > 30)
                {
                    break;
                }
                i++;
            }
            return string.Empty;
        }
    }
}
