using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using rocToURL.Models;

namespace rocToURL.Controllers
{
    public class UrlController : Controller
    {
        [HttpGet]
        public IActionResult Shorten()
        {
            return View();
        }

        public ActionResult Shorten(URL url)
        {
            // checks if all validation requirements are met
            if (ModelState.IsValid)
            {
                url.ShortUrl = String.Empty;
            }

            return View(url);
        }
    }
}
