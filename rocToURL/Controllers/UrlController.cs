using Microsoft.AspNetCore.Mvc;
using rocToURL.Models;
using rocToURL.Abstractions;

namespace rocToURL.Controllers
{
    public class UrlController : Controller
    {
        #region Fields

        private IUrlService urlService;

        #endregion Fields

        #region Properties

        private URL urlToShorten;

        public URL UrlToShorten
        {
            get { return urlToShorten; }
            set { urlToShorten = value; }    
        }

        #endregion Properties

        public UrlController(IUrlService urlService)
        {
            this.urlService = urlService;

            UrlToShorten = new URL();
        }

        #region Actions

        [HttpGet]
        public IActionResult Shorten()
        {
            return View(UrlToShorten);
        }

        public async Task<ActionResult> Shorten(URL url)
        {
            // checks if all validation requirements are met
            if (ModelState.IsValid)
            {
                url.ShortUrl = await urlService.MinifyUrl(url.LongUrl);
            }

            return View(url);
        }

        #endregion Actions
    }
}
