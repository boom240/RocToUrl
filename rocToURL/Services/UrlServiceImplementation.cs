using rocToURL.Abstractions;

namespace rocToURL.Services
{
    public class UrlServiceImplementation : IUrlService
    {
        /// <inheritdoc/>
        public Task<string> MinifyUrl(string longUrl)
        {
            return Task.Run(() =>
            {
                return "Not yet implemented";
            });
        }
    }
}
