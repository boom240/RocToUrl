namespace rocToURL.Abstractions
{
    /// <summary>
	/// Url Service
	/// </summary>
    public interface IUrlService
    {
        /// <summary>
		/// Minify a Url string 
		/// </summary>
		/// <param name="longUrl">The long url to minimise</param>
		/// <returns>The minimised short url</returns>
        Task<string> MinifyUrl(string longUrl);
    }
}
