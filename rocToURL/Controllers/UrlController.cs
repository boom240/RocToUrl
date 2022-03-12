using Microsoft.AspNetCore.Mvc;
using rocToURL.Abstractions;
using rocToURL.Entities.Models;

using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;

namespace rocToURL.Controllers
{
    public class UrlController : Controller
    {
        #region Fields

        private IUrlService urlService;

        #endregion Fields

        #region Properties

        private URL urlShort;

        public URL UrlShort
        {
            get { return urlShort; }
            set { urlShort = value; }    
        }

        #endregion Properties

        public UrlController(IUrlService urlService)
        {
            this.urlService = urlService;
        }

        #region Actions

        [HttpGet]
        public IActionResult Shorten()
        {
            UrlShort = new URL();

            return View(UrlShort);
        }

        public async Task<ActionResult> Shorten(URL url)
        {
            var localIp = this.HttpContext.Connection.LocalIpAddress.ToString();

            Url.Action(new UrlActionContext
            {
                Protocol = Request.Scheme,
                Host = Request.Host.Value,
                Action = "Action"
            });

            // checks if all validation requirements are met
            if (ModelState.IsValid)
            {
                UrlShort = await urlService.MinifyUrl(url.LongUrl, localIp);

                url.ShortUrl = string.Format("{0}://{1}{2}{3}", Request.Scheme, UriPartial.Authority, Url.Content("~"), UrlShort.Segment);
            }

            return View(url);
        }

        #endregion Actions
    }
}
